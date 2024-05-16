using System;
using System.Data;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public class DbContextScopeFactory : IDbContextScopeFactory
{
	private readonly IDbContextFactory _dbContextFactory;

	public DbContextScopeFactory(IDbContextFactory dbContextFactory = null)
	{
		_dbContextFactory = dbContextFactory;
	}

	public IDbContextScope Create(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting)
	{
		return new DbContextScope(joiningOption, readOnly: false, null, _dbContextFactory);
	}

	public IDbContextReadOnlyScope CreateReadOnly(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting)
	{
		return new DbContextReadOnlyScope(joiningOption, null, _dbContextFactory);
	}

	public IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel)
	{
		return new DbContextScope(DbContextScopeOption.ForceCreateNew, readOnly: false, isolationLevel, _dbContextFactory);
	}

	public IDbContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel)
	{
		return new DbContextReadOnlyScope(DbContextScopeOption.ForceCreateNew, isolationLevel, _dbContextFactory);
	}

	public IDisposable SuppressAmbientContext()
	{
		return new AmbientContextSuppressor();
	}
}
