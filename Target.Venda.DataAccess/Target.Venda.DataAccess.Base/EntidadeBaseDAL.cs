using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Context;
using Target.Venda.DataAccess.Context.DbContextScope;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Base;

namespace Target.Venda.DataAccess.Base;

public abstract class EntidadeBaseDAL<T> where T : EntidadeBaseMO
{
	public const string PARAMETER_NAME_RETURN_VALUE = "return_value";

	private static object _lock = new object();

	private DbContext GetContext()
	{
		IAmbientDbContextLocator ambientDbContextLocator = AmbientLocatorSingleton.AmbientDbContext();
		ERPContext eRPContext = ambientDbContextLocator.Get<ERPContext>();
		if (eRPContext == null)
		{
			eRPContext = ContextFactory.CreateContext();
		}
		return eRPContext;
	}

	protected void Commit(DbContext contextCommit)
	{
		try
		{
			contextCommit.SaveChanges();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public virtual void Insert(T objeto)
	{
		try
		{
			DbContext context = GetContext();
			context.Set<T>().Add(objeto);
			Commit(context);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public void Insert(List<T> models)
	{
		try
		{
			DbContext context = GetContext();
			foreach (T model in models)
			{
				context.Set<T>().Add(model);
			}
			Commit(context);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public virtual void Update(T objeto)
	{
		try
		{
			DbContext context = GetContext();
			context.Entry(objeto).State = EntityState.Modified;
			Commit(context);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public virtual void Delete(T objeto)
	{
		try
		{
			DbContext context = GetContext();
			context.Set<T>().Attach(objeto);
			context.Set<T>().Remove(objeto);
			Commit(context);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	protected int ExecutarSqlCommand(string comando, params object[] valores)
	{
		try
		{
			DbContext context = GetContext();
			int result = context.Database.ExecuteSqlCommand(comando, valores);
			Commit(context);
			return result;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public int GerarSequencialIdentity(string nomeTabelaSeq)
	{
		try
		{
			string procedure = "uspGeraSeqTabelaAuxiliarIdentity";
			List<SqlParameter> list = new List<SqlParameter>();
			list.Add(new SqlParameter("@parStrTabela", nomeTabelaSeq));
			list.Add(new SqlParameter("@parChamadaCentura", false));
			int num = 0;
			string value = "";
			SqlParameter sqlParameter = new SqlParameter("@rpar_nu_seq", num);
			sqlParameter.Direction = ParameterDirection.Output;
			list.Add(sqlParameter);
			SqlParameter sqlParameter2 = new SqlParameter("@rpar_msg", value);
			sqlParameter2.Direction = ParameterDirection.Output;
			list.Add(sqlParameter2);
			int returnValue = -1;
			ExecutarStoredProcedureScalar<string>(procedure, list, out returnValue);
			value = sqlParameter2.Value.ToString();
			num = Convert.ToInt32(sqlParameter.Value.ToString());
			value = ((value != null) ? value : value);
			if (returnValue < 0)
			{
				new Exception(value);
			}
			return num;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public int GerarSequencial(string nomeTabelaSeq, int? codigoEmpresa = null)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("SELECT TabelaAuxiliar FROM TGTTabelasGeraSeqPorIdentity WHERE TabelaOriginal = '{0}' ", nomeTabelaSeq);
			string text = ExecutarScalarSQL<string>(stringBuilder.ToString(), Array.Empty<object>());
			int num = 0;
			if (text != null)
			{
				num = GerarSequencialIdentity(text);
			}
			else
			{
				lock (_lock)
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					stringBuilder2.AppendFormat(" UPDATE {0} SET NUMERO = NUMERO ", nomeTabelaSeq);
					if (codigoEmpresa.HasValue && codigoEmpresa.Value > 0)
					{
						stringBuilder2.AppendFormat(" WHERE CD_EMP = {0}", codigoEmpresa);
					}
					ExecutarSqlCommand(stringBuilder2.ToString());
					StringBuilder stringBuilder3 = new StringBuilder();
					stringBuilder3.AppendFormat("SELECT NUMERO FROM {0} WITH(NOLOCK)", nomeTabelaSeq);
					if (codigoEmpresa.HasValue && codigoEmpresa.Value > 0)
					{
						stringBuilder3.AppendFormat(" WHERE CD_EMP = {0}", codigoEmpresa);
					}
					num = ExecutarScalarSQL<int>(stringBuilder3.ToString(), Array.Empty<object>());
					if (num > 0)
					{
						StringBuilder stringBuilder4 = new StringBuilder();
						stringBuilder4.AppendFormat("UPDATE {0} SET NUMERO = NUMERO + 1 ", nomeTabelaSeq);
						if (codigoEmpresa.HasValue && codigoEmpresa.Value > 0)
						{
							stringBuilder4.AppendFormat(" WHERE CD_EMP = {0}", codigoEmpresa);
						}
						ExecutarSqlCommand(stringBuilder4.ToString());
					}
					else
					{
						num = 1;
						string empty = string.Empty;
						empty = ((!codigoEmpresa.HasValue || codigoEmpresa.Value <= 0) ? $"INSERT INTO {nomeTabelaSeq} (NUMERO) VALUES (2) " : $"INSERT INTO {nomeTabelaSeq} (NUMERO, CD_EMP) VALUES (2, {codigoEmpresa}) ");
						ExecutarSqlCommand(empty);
					}
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public virtual T ObterPeloID(params object[] ids)
	{
		try
		{
			DbContext context = GetContext();
			DbSet<T> dbSet = context.Set<T>();
			return ids.Length switch
			{
				1 => dbSet.Find(ids[0]), 
				2 => dbSet.Find(ids[0], ids[1]), 
				3 => dbSet.Find(ids[0], ids[1], ids[2]), 
				4 => dbSet.Find(ids[0], ids[1], ids[2], ids[3]), 
				5 => dbSet.Find(ids[0], ids[1], ids[2], ids[3], ids[4]), 
				_ => dbSet.Find(ids[0]), 
			};
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public virtual List<T> ObterPeloExemplo(T exemplo)
	{
		ExpressionStarter<T> expressionStarter = PredicateBuilder.New<T>(defaultExpression: true);
		expressionStarter = GetWhere(expressionStarter, exemplo);
		return ExecutarSelect(expressionStarter, 500);
	}

	public virtual List<T> ObterPeloExemplo(T exemplo, int qtdeRegistros)
	{
		ExpressionStarter<T> expressionStarter = PredicateBuilder.New<T>(defaultExpression: true);
		expressionStarter = GetWhere(expressionStarter, exemplo);
		return ExecutarSelect(expressionStarter, qtdeRegistros);
	}

	public virtual List<T> ObterPeloExemplo(T exemplo, params string[] includes)
	{
		ExpressionStarter<T> expressionStarter = PredicateBuilder.New<T>(defaultExpression: true);
		expressionStarter = GetWhere(expressionStarter, exemplo);
		return ExecutarSelect(expressionStarter, 500, includes);
	}

	public virtual List<T> ObterPeloExemplo(T exemplo, int qtdeRegistros, params string[] includes)
	{
		ExpressionStarter<T> expressionStarter = PredicateBuilder.New<T>(defaultExpression: true);
		expressionStarter = GetWhere(expressionStarter, exemplo);
		return ExecutarSelect(expressionStarter, qtdeRegistros, includes);
	}

	public virtual T ObterUnicoPeloExemplo(T exemplo)
	{
		ExpressionStarter<T> expressionStarter = PredicateBuilder.New<T>(defaultExpression: true);
		expressionStarter = GetWhere(expressionStarter, exemplo);
		return ExecutarSelect(expressionStarter, 1).FirstOrDefault();
	}

	public virtual T ObterUnicoPeloExemplo(T exemplo, params string[] includes)
	{
		ExpressionStarter<T> expressionStarter = PredicateBuilder.New<T>(defaultExpression: true);
		expressionStarter = GetWhere(expressionStarter, exemplo);
		return ExecutarSelect(expressionStarter, 1, includes).FirstOrDefault();
	}

	protected abstract Expression<Func<T, bool>> GetWhere(Expression<Func<T, bool>> whereClause, T exemplo);

	protected List<T> ExecutarSelect(Expression<Func<T, bool>> whereClause, int quebra, params string[] includes)
	{
		try
		{
			DbContext context = GetContext();
			DbSet<T> dbSet = context.Set<T>();
			List<T> list = new List<T>();
			if (includes.Length != 0)
			{
				DbQuery<T> dbQuery = dbSet;
				foreach (string path in includes)
				{
					dbQuery = dbQuery.Include(path);
				}
				return dbQuery.AsExpandable().Where(whereClause).Take(quebra)
					.ToList();
			}
			return dbSet.AsExpandable().Where(whereClause).Take(quebra)
				.ToList();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	protected List<T> ExecutarSelectSQL(string select, params object[] filtros)
	{
		try
		{
			DbContext context = GetContext();
			return context.Database.SqlQuery<T>(select, filtros).ToList();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	protected List<Y> ExecutarSelectSQL<Y>(string select, params object[] filtros)
	{
		try
		{
			DbContext context = GetContext();
			return context.Database.SqlQuery<Y>(select, filtros).ToList();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	protected List<Y> ExecutarSelectSQLToDataReader<Y>(string selectSQL)
	{
		try
		{
			DbContext context = GetContext();
			if (context.Database.Connection.State != ConnectionState.Open)
			{
				context.Database.Connection.Open();
			}
			DbCommand dbCommand = context.Database.Connection.CreateCommand();
			dbCommand.CommandText = selectSQL;
			dbCommand.CommandType = CommandType.Text;
			if (context.Database.CurrentTransaction != null)
			{
				dbCommand.Transaction = context.Database.CurrentTransaction.UnderlyingTransaction;
			}
			dbCommand.CommandTimeout = 60;
			DbDataReader dbDataReader = dbCommand.ExecuteReader();
			List<Y> list = new List<Y>();
			List<PropertyInfo> list2 = typeof(Y).GetProperties().ToList();
			while (dbDataReader.Read())
			{
				if (!dbDataReader.HasRows)
				{
					continue;
				}
				Y val = Activator.CreateInstance<Y>();
				for (int i = 0; i < dbDataReader.FieldCount; i++)
				{
					string columnName = dbDataReader.GetName(i);
					PropertyInfo propertyInfo = list2.Find((PropertyInfo p) => p.Name.Equals(columnName, StringComparison.CurrentCultureIgnoreCase));
					if (!(propertyInfo == null))
					{
						object value = dbDataReader[columnName];
						propertyInfo.SetValue(val, value, null);
					}
				}
				list.Add(val);
			}
			dbDataReader.Close();
			return list;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	protected T ExecutarScalarSQL(string select, params object[] filtros)
	{
		try
		{
			DbContext context = GetContext();
			return context.Database.SqlQuery<T>(select, filtros).FirstOrDefault();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	protected Y ExecutarScalarSQL<Y>(string select, params object[] filtros)
	{
		try
		{
			DbContext context = GetContext();
			return context.Database.SqlQuery<Y>(select, filtros).FirstOrDefault();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public int ExecutarStoredProcedureNonQuery(string procedure, List<SqlParameter> parameters, out int returnValue)
	{
		SqlParameter sqlParameter = new SqlParameter("return_value", SqlDbType.Int);
		sqlParameter.Direction = ParameterDirection.ReturnValue;
		parameters.Add(sqlParameter);
		ExecutarStoredProcedureNonQueryInternal(procedure, parameters, out returnValue);
		return returnValue;
	}

	public int ExecutarStoredProcedureNonQuery(string procedure, List<SqlParameter> parameters)
	{
		ExecutarStoredProcedureNonQueryInternal(procedure, parameters, out var returnValue);
		return returnValue;
	}

	private void ExecutarStoredProcedureNonQueryInternal(string procedure, List<SqlParameter> parameters, out int returnValue)
	{
		try
		{
			DbContext context = GetContext();
			DbCommand dbCommand = ObterCommandProcedure(context, procedure, parameters);
			dbCommand.ExecuteNonQuery();
			returnValue = 0;
			if (dbCommand.Parameters != null && dbCommand.Parameters.Contains("return_value"))
			{
				DbParameter dbParameter = dbCommand.Parameters["return_value"];
				bool flag = dbParameter.Direction == ParameterDirection.ReturnValue && dbParameter.DbType == DbType.Int32;
				if (dbParameter.Value != null && flag)
				{
					returnValue = ConvertHelper.ToInt(dbCommand.Parameters["return_value"].Value);
				}
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public TEntity ExecutarStoredProcedureScalar<TEntity>(string procedure, List<SqlParameter> parameters, out int returnValue)
	{
		SqlParameter sqlParameter = new SqlParameter("return_value", SqlDbType.Int);
		sqlParameter.Direction = ParameterDirection.ReturnValue;
		parameters.Add(sqlParameter);
		return ExecutarStoredProcedureScalarInternal<TEntity>(procedure, parameters, out returnValue);
	}

	public TEntity ExecutarStoredProcedureScalar<TEntity>(string procedure, List<SqlParameter> parameters)
	{
		int returnValue;
		return ExecutarStoredProcedureScalarInternal<TEntity>(procedure, parameters, out returnValue);
	}

	private TEntity ExecutarStoredProcedureScalarInternal<TEntity>(string procedure, List<SqlParameter> parameters, out int returnValue)
	{
		try
		{
			DbContext context = GetContext();
			DbCommand dbCommand = ObterCommandProcedure(context, procedure, parameters);
			TEntity result = (TEntity)dbCommand.ExecuteScalar();
			returnValue = 0;
			if (dbCommand.Parameters != null && dbCommand.Parameters.Contains("return_value"))
			{
				DbParameter dbParameter = dbCommand.Parameters["return_value"];
				bool flag = dbParameter.Direction == ParameterDirection.ReturnValue && dbParameter.DbType == DbType.Int32;
				if (dbParameter.Value != null && flag)
				{
					returnValue = ConvertHelper.ToInt(dbCommand.Parameters["return_value"].Value);
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private DbCommand ObterCommandProcedure(DbContext context, string procedure, List<SqlParameter> parameters)
	{
		if (context.Database.Connection.State != ConnectionState.Open)
		{
			context.Database.Connection.Open();
		}
		DbCommand dbCommand = context.Database.Connection.CreateCommand();
		dbCommand.CommandText = procedure;
		dbCommand.CommandType = CommandType.StoredProcedure;
		if (context.Database.CurrentTransaction != null)
		{
			dbCommand.Transaction = context.Database.CurrentTransaction.UnderlyingTransaction;
		}
		if (parameters != null)
		{
			dbCommand.Parameters.AddRange(parameters.ToArray());
		}
		dbCommand.CommandTimeout = 360;
		return dbCommand;
	}

	public List<TEntity> ExecutarStoredProcedureToList<TEntity>(string procedure, List<SqlParameter> parameters, out int returnValue)
	{
		SqlParameter sqlParameter = new SqlParameter("return_value", SqlDbType.Int);
		sqlParameter.Direction = ParameterDirection.ReturnValue;
		parameters.Add(sqlParameter);
		return ExecutarStoredProcedureInternal<TEntity>(procedure, parameters, out returnValue);
	}

	public List<TEntity> ExecutarStoredProcedureToList<TEntity>(string procedure, List<SqlParameter> parameters)
	{
		int returnValue;
		return ExecutarStoredProcedureInternal<TEntity>(procedure, parameters, out returnValue);
	}

	private List<TEntity> ExecutarStoredProcedureInternal<TEntity>(string procedure, List<SqlParameter> parameters, out int returnValue)
	{
		try
		{
			DbContext context = GetContext();
			DbCommand dbCommand = ObterCommandProcedure(context, procedure, parameters);
			DbDataReader dbDataReader = dbCommand.ExecuteReader();
			ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
			List<TEntity> list = new List<TEntity>();
			list = objectContext.Translate<TEntity>(dbDataReader).ToList();
			dbDataReader.Close();
			returnValue = 0;
			if (dbCommand.Parameters != null && dbCommand.Parameters.Contains("return_value"))
			{
				DbParameter dbParameter = dbCommand.Parameters["return_value"];
				bool flag = dbParameter.Direction == ParameterDirection.ReturnValue && dbParameter.DbType == DbType.Int32;
				if (dbParameter.Value != null && flag)
				{
					returnValue = ConvertHelper.ToInt(dbCommand.Parameters["return_value"].Value);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public DbDataReader ExecutarStoredProcedureToDataRead(string procedure, List<SqlParameter> parameters, out int returnValue)
	{
		SqlParameter sqlParameter = new SqlParameter("return_value", SqlDbType.Int);
		sqlParameter.Direction = ParameterDirection.ReturnValue;
		parameters.Add(sqlParameter);
		DbContext context = GetContext();
		DbCommand dbCommand = ObterCommandProcedure(context, procedure, parameters);
		DbDataReader result = dbCommand.ExecuteReader();
		returnValue = ConvertHelper.ToInt(dbCommand.Parameters["return_value"].Value);
		return result;
	}
}
