using System;
using System.Data;
using Target.Venda.DataAccess.Context.DbContextScope;

namespace Target.Venda.Business.Helpers;

public class TransactionManager
{
	private static IDbContextScopeFactory _factoryDbContextScope;

	private static IDbContextScopeFactory FactoryDbContextScope
	{
		get
		{
			if (_factoryDbContextScope == null)
			{
				_factoryDbContextScope = new DbContextScopeFactory();
			}
			return _factoryDbContextScope;
		}
	}

	public static void ExecutarComTransacao(Action operacoes)
	{
		using IDbContextScope dbContextScope = FactoryDbContextScope.CreateWithTransaction(IsolationLevel.ReadCommitted);
		operacoes();
		dbContextScope.SaveChanges();
		dbContextScope.Dispose();
	}

	public static IDbContextScope BeginTransaction()
	{
		return FactoryDbContextScope.CreateWithTransaction(IsolationLevel.ReadCommitted);
	}

	public static void Commit(IDbContextScope scope)
	{
		using (scope)
		{
			scope.SaveChanges();
		}
	}

	public static void RollBack(IDbContextScope scope)
	{
		using (scope)
		{
			scope.Dispose();
		}
	}
}
