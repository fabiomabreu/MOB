using System;
using System.Data;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public class DbContextReadOnlyScope : IDbContextReadOnlyScope, IDisposable
{
	private DbContextScope _internalScope;

	public IDbContextCollection DbContexts => _internalScope.DbContexts;

	public DbContextReadOnlyScope(IDbContextFactory dbContextFactory = null)
		: this(DbContextScopeOption.JoinExisting, null, dbContextFactory)
	{
	}

	public DbContextReadOnlyScope(IsolationLevel isolationLevel, IDbContextFactory dbContextFactory = null)
		: this(DbContextScopeOption.ForceCreateNew, isolationLevel, dbContextFactory)
	{
	}

	public DbContextReadOnlyScope(DbContextScopeOption joiningOption, IsolationLevel? isolationLevel, IDbContextFactory dbContextFactory = null)
	{
		_internalScope = new DbContextScope(joiningOption, readOnly: true, isolationLevel, dbContextFactory);
	}

	public void Dispose()
	{
		_internalScope.Dispose();
	}
}
