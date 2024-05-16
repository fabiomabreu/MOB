using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class LogDesempenhoDAL : EntidadeBaseDAL<LogDesempenhoMO>
{
	protected override Expression<Func<LogDesempenhoMO, bool>> GetWhere(Expression<Func<LogDesempenhoMO, bool>> whereClause, LogDesempenhoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public int LogDesempenhoInicio(LogDesempenhoVO logDesempenho)
	{
		try
		{
			string procedure = "usp_log_desempenho_inicio_sp";
			List<SqlParameter> list = new List<SqlParameter>();
			list.Add(new SqlParameter("@par_cd_tela", logDesempenho.CODIGO_TELA));
			list.Add(new SqlParameter("@par_operacao", logDesempenho.OPERACAO));
			list.Add(new SqlParameter("@par_observacao", logDesempenho.OBSERVACAO));
			SqlParameter sqlParameter = new SqlParameter("@rpar_id", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			list.Add(sqlParameter);
			ExecutarStoredProcedureScalar<string>(procedure, list);
			return Convert.ToInt32(sqlParameter.Value.ToString());
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void LogDesempenhoFim(int pCodigoRetorno)
	{
		try
		{
			string procedure = "usp_log_desempenho_fim_sp";
			List<SqlParameter> list = new List<SqlParameter>();
			list.Add(new SqlParameter("@par_id", pCodigoRetorno));
			ExecutarStoredProcedureScalar<string>(procedure, list);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
