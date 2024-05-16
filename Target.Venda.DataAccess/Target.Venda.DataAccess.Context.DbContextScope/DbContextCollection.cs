#define DEBUG
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public class DbContextCollection : IDbContextCollection, IDisposable
{
	private Dictionary<Type, DbContext> _initializedDbContexts;

	private Dictionary<DbContext, DbContextTransaction> _transactions;

	private IsolationLevel? _isolationLevel;

	private readonly IDbContextFactory _dbContextFactory;

	private bool _disposed;

	private bool _completed;

	private bool _readOnly;

	internal Dictionary<Type, DbContext> InitializedDbContexts => _initializedDbContexts;

	public DbContextCollection(bool readOnly = false, IsolationLevel? isolationLevel = null, IDbContextFactory dbContextFactory = null)
	{
		_disposed = false;
		_completed = false;
		_initializedDbContexts = new Dictionary<Type, DbContext>();
		_transactions = new Dictionary<DbContext, DbContextTransaction>();
		_readOnly = readOnly;
		_isolationLevel = isolationLevel;
		_dbContextFactory = dbContextFactory;
	}

	public TDbContext Get<TDbContext>() where TDbContext : DbContext
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("DbContextCollection");
		}
		Type typeFromHandle = typeof(TDbContext);
		if (!_initializedDbContexts.ContainsKey(typeFromHandle))
		{
			TDbContext val = ((_dbContextFactory != null) ? _dbContextFactory.CreateDbContext<TDbContext>() : Activator.CreateInstance<TDbContext>());
			_initializedDbContexts.Add(typeFromHandle, val);
			if (_readOnly)
			{
				val.Configuration.AutoDetectChangesEnabled = false;
			}
			if (_isolationLevel.HasValue)
			{
				DbContextTransaction value = val.Database.BeginTransaction(_isolationLevel.Value);
				_transactions.Add(val, value);
			}
		}
		return _initializedDbContexts[typeFromHandle] as TDbContext;
	}

	public int Commit()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("DbContextCollection");
		}
		if (_completed)
		{
			throw new InvalidOperationException("You can't call Commit() or Rollback() more than once on a DbContextCollection. All the changes in the DbContext instances managed by this collection have already been saved or rollback and all database transactions have been completed and closed. If you wish to make more data changes, create a new DbContextCollection and make your changes there.");
		}
		Exception ex = null;
		int num = 0;
		foreach (DbContext value in _initializedDbContexts.Values)
		{
			try
			{
				if (!_readOnly)
				{
					num += value.SaveChanges();
				}
				DbContextTransaction valueOrDefault = GetValueOrDefault(_transactions, value);
				if (valueOrDefault != null)
				{
					valueOrDefault.Commit();
					valueOrDefault.Dispose();
				}
			}
			catch (Exception innerException)
			{
				ex = new Exception("Erro ao comitar os Dados", innerException);
			}
		}
		_transactions.Clear();
		_completed = true;
		if (ex != null)
		{
			throw ex;
		}
		return num;
	}

	public void Rollback()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("DbContextCollection");
		}
		if (_completed)
		{
			throw new InvalidOperationException("You can't call Commit() or Rollback() more than once on a DbContextCollection. All the changes in the DbContext instances managed by this collection have already been saved or rollback and all database transactions have been completed and closed. If you wish to make more data changes, create a new DbContextCollection and make your changes there.");
		}
		Exception ex = null;
		foreach (DbContext value in _initializedDbContexts.Values)
		{
			DbContextTransaction valueOrDefault = GetValueOrDefault(_transactions, value);
			if (valueOrDefault != null)
			{
				try
				{
					valueOrDefault.Rollback();
					valueOrDefault.Dispose();
				}
				catch (Exception innerException)
				{
					ex = new Exception("Erro ao dar Rollback nos Dados", innerException);
				}
			}
		}
		_transactions.Clear();
		_completed = true;
		if (ex != null)
		{
			throw ex;
		}
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		if (!_completed)
		{
			try
			{
				if (_readOnly)
				{
					Commit();
				}
				else
				{
					Rollback();
				}
			}
			catch (Exception value)
			{
				Debug.WriteLine(value);
			}
		}
		foreach (DbContext value3 in _initializedDbContexts.Values)
		{
			try
			{
				value3.Dispose();
			}
			catch (Exception value2)
			{
				Debug.WriteLine(value2);
			}
		}
		_initializedDbContexts.Clear();
		_disposed = true;
	}

	private static TValue GetValueOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
	{
		TValue value;
		return dictionary.TryGetValue(key, out value) ? value : default(TValue);
	}
}
