using System;
using System.Data;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public interface IDbContextScopeFactory
{
	IDbContextScope Create(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting);

	IDbContextReadOnlyScope CreateReadOnly(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting);

	IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel);

	IDbContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel);

	IDisposable SuppressAmbientContext();
}
