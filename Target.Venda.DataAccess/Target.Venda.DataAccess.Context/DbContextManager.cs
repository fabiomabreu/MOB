using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using Target.Venda.Helpers.Log;

namespace Target.Venda.DataAccess.Context;

public class DbContextManager
{
	private static ConcurrentDictionary<string, DbContext> _dicContext;

	public static void BeginTransaction(string dbContextID)
	{
		DbContext dbContext = CreateDbContext(dbContextID);
		if (dbContext.Database.CurrentTransaction == null)
		{
			dbContext.Database.BeginTransaction();
		}
	}

	public static void Commit(string dbContextID)
	{
		DbContext dbContextById = GetDbContextById(dbContextID);
		dbContextById.Database.CurrentTransaction.Commit();
		RemoveDbContext(dbContextID, dbContextById);
	}

	public static void Rollback(string dbContextID)
	{
		DbContext dbContextById = GetDbContextById(dbContextID);
		dbContextById.Database.CurrentTransaction.Rollback();
		RemoveDbContext(dbContextID, dbContextById);
	}

	internal static DbContext CreateDbContext(string dbContextID)
	{
		if (ContainsDbContextKey(dbContextID))
		{
			return GetDbContextById(dbContextID);
		}
		DbContext dbContext = ContextFactory.CreateContext();
		bool flag = false;
		while (!flag)
		{
			flag = _dicContext.TryAdd(dbContextID, dbContext);
		}
		return dbContext;
	}

	internal static DbContext GetDbContextById(string dbContextID)
	{
		try
		{
			if (ContainsDbContextKey(dbContextID))
			{
				return _dicContext[dbContextID];
			}
			string message = $"Não foi possivel carregar o DbContext pelo ID: {dbContextID}";
			throw new Exception(message);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private static void RemoveDbContext(string dbContextID, DbContext dbContext)
	{
		try
		{
			if (dbContext.Database.CurrentTransaction != null)
			{
				dbContext.Database.CurrentTransaction.Dispose();
			}
			using (dbContext)
			{
				dbContext.Database.Connection.Close();
				dbContext.Database.Connection.Dispose();
				dbContext.Dispose();
			}
			_dicContext.TryRemove(dbContextID, out dbContext);
			GC.Collect();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private static bool ContainsDbContextKey(string DbContextID)
	{
		if (_dicContext == null)
		{
			_dicContext = new ConcurrentDictionary<string, DbContext>();
		}
		if (string.IsNullOrWhiteSpace(DbContextID))
		{
			return false;
		}
		return _dicContext.ContainsKey(DbContextID);
	}

	public static void DisposeTransaction(string DbContextID)
	{
		DbContext dbContextById = GetDbContextById(DbContextID);
		RemoveDbContext(DbContextID, dbContextById);
	}
}
