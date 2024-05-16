#define DEBUG
using System;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public class DbContextScope : IDbContextScope, IDisposable
{
	private bool _disposed;

	private bool _readOnly;

	private bool _completed;

	private bool _nested;

	private DbContextScope _parentScope;

	private DbContextCollection _dbContexts;

	private static readonly string AmbientDbContextScopeKey = "AmbientDbcontext_" + Guid.NewGuid().ToString();

	private static readonly ConditionalWeakTable<InstanceIdentifier, DbContextScope> DbContextScopeInstances = new ConditionalWeakTable<InstanceIdentifier, DbContextScope>();

	private InstanceIdentifier _instanceIdentifier = new InstanceIdentifier();

	public IDbContextCollection DbContexts => _dbContexts;

	public DbContextScope(IDbContextFactory dbContextFactory = null)
		: this(DbContextScopeOption.JoinExisting, readOnly: false, null, dbContextFactory)
	{
	}

	public DbContextScope(bool readOnly, IDbContextFactory dbContextFactory = null)
		: this(DbContextScopeOption.JoinExisting, readOnly, null, dbContextFactory)
	{
	}

	public DbContextScope(DbContextScopeOption joiningOption, bool readOnly, IsolationLevel? isolationLevel, IDbContextFactory dbContextFactory = null)
	{
		if (isolationLevel.HasValue && joiningOption == DbContextScopeOption.JoinExisting)
		{
			throw new ArgumentException("Cannot join an ambient DbContextScope when an explicit database transaction is required. When requiring explicit database transactions to be used (i.e. when the 'isolationLevel' parameter is set), you must not also ask to join the ambient context (i.e. the 'joinAmbient' parameter must be set to false).");
		}
		_disposed = false;
		_completed = false;
		_readOnly = readOnly;
		_parentScope = GetAmbientScope();
		if (_parentScope != null && joiningOption == DbContextScopeOption.JoinExisting)
		{
			if (_parentScope._readOnly && !_readOnly)
			{
				throw new InvalidOperationException("Cannot nest a read/write DbContextScope within a read-only DbContextScope.");
			}
			_nested = true;
			_dbContexts = _parentScope._dbContexts;
		}
		else
		{
			_nested = false;
			_dbContexts = new DbContextCollection(readOnly, isolationLevel, dbContextFactory);
		}
		SetAmbientScope(this);
	}

	public int SaveChanges()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("DbContextScope");
		}
		if (_completed)
		{
			throw new InvalidOperationException("You cannot call SaveChanges() more than once on a DbContextScope. A DbContextScope is meant to encapsulate a business transaction: create the scope at the start of the business transaction and then call SaveChanges() at the end. Calling SaveChanges() mid-way through a business transaction doesn't make sense and most likely mean that you should refactor your service method into two separate service method that each create their own DbContextScope and each implement a single business transaction.");
		}
		int result = 0;
		if (!_nested)
		{
			result = CommitInternal();
		}
		_completed = true;
		return result;
	}

	private int CommitInternal()
	{
		return _dbContexts.Commit();
	}

	private void RollbackInternal()
	{
		_dbContexts.Rollback();
	}

	public void RefreshEntitiesInParentScope(IEnumerable entities)
	{
		if (entities == null || _parentScope == null || _nested)
		{
			return;
		}
		foreach (DbContext contextInCurrentScope in _dbContexts.InitializedDbContexts.Values)
		{
			IObjectContextAdapter objectContextAdapter = _parentScope._dbContexts.InitializedDbContexts.Values.SingleOrDefault((DbContext parentContext) => parentContext.GetType() == ((object)contextInCurrentScope).GetType());
			if (objectContextAdapter == null)
			{
				continue;
			}
			foreach (object entity in entities)
			{
				if (((IObjectContextAdapter)contextInCurrentScope).ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out var entry))
				{
					EntityKey entityKey = entry.EntityKey;
					if (objectContextAdapter.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entityKey, out var entry2) && entry2.State == EntityState.Unchanged)
					{
						objectContextAdapter.ObjectContext.Refresh(RefreshMode.StoreWins, entry2.Entity);
					}
				}
			}
		}
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		if (!_nested)
		{
			if (!_completed)
			{
				try
				{
					if (_readOnly)
					{
						CommitInternal();
					}
					else
					{
						RollbackInternal();
					}
				}
				catch (Exception value)
				{
					Debug.WriteLine(value);
				}
				_completed = true;
			}
			_dbContexts.Dispose();
		}
		DbContextScope ambientScope = GetAmbientScope();
		if (ambientScope != this)
		{
			throw new InvalidOperationException("DbContextScope instances must be disposed of in the order in which they were created!");
		}
		RemoveAmbientScope();
		if (_parentScope != null)
		{
			if (_parentScope._disposed)
			{
				string message = "PROGRAMMING ERROR - When attempting to dispose a DbContextScope, we found that our parent DbContextScope has already been disposed! This means that someone started a parallel flow of execution (e.g. created a TPL task, created a thread or enqueued a work item on the ThreadPool) within the context of a DbContextScope without suppressing the ambient context first. \r\n\r\nIn order to fix this:\r\n1) Look at the stack trace below - this is the stack trace of the parallel task in question.\r\n2) Find out where this parallel task was created.\r\n3) Change the code so that the ambient context is suppressed before the parallel task is created. You can do this with IDbContextScopeFactory.SuppressAmbientContext() (wrap the parallel task creation code block in this). \r\n\r\nStack Trace:\r\n" + Environment.StackTrace;
				Debug.WriteLine(message);
			}
			else
			{
				SetAmbientScope(_parentScope);
			}
		}
		_disposed = true;
	}

	internal static void SetAmbientScope(DbContextScope newAmbientScope)
	{
		if (newAmbientScope == null)
		{
			throw new ArgumentNullException("newAmbientScope");
		}
		InstanceIdentifier instanceIdentifier = CallContext.LogicalGetData(AmbientDbContextScopeKey) as InstanceIdentifier;
		if (instanceIdentifier != newAmbientScope._instanceIdentifier)
		{
			CallContext.LogicalSetData(AmbientDbContextScopeKey, newAmbientScope._instanceIdentifier);
			DbContextScopeInstances.GetValue(newAmbientScope._instanceIdentifier, (InstanceIdentifier key) => newAmbientScope);
		}
	}

	internal static void RemoveAmbientScope()
	{
		InstanceIdentifier instanceIdentifier = CallContext.LogicalGetData(AmbientDbContextScopeKey) as InstanceIdentifier;
		CallContext.LogicalSetData(AmbientDbContextScopeKey, null);
		if (instanceIdentifier != null)
		{
			DbContextScopeInstances.Remove(instanceIdentifier);
		}
	}

	internal static void HideAmbientScope()
	{
		CallContext.LogicalSetData(AmbientDbContextScopeKey, null);
	}

	internal static DbContextScope GetAmbientScope()
	{
		if (!(CallContext.LogicalGetData(AmbientDbContextScopeKey) is InstanceIdentifier key))
		{
			return null;
		}
		if (DbContextScopeInstances.TryGetValue(key, out var value))
		{
			return value;
		}
		Debug.WriteLine("Programming error detected. Found a reference to an ambient DbContextScope in the CallContext but didn't have an instance for it in our DbContextScopeInstances table. This most likely means that this DbContextScope instance wasn't disposed of properly. DbContextScope instance must always be disposed. Review the code for any DbContextScope instance used outside of a 'using' block and fix it so that all DbContextScope instances are disposed of.");
		return null;
	}
}
