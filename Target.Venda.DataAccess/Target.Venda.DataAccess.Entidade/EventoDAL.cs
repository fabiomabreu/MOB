using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoDAL : EntidadeBaseDAL<EventoMO>
{
	protected override Expression<Func<EventoMO, bool>> GetWhere(Expression<Func<EventoMO, bool>> whereClause, EventoMO exemplo)
	{
		if (exemplo.CODIGO_EMPRESA > 0)
		{
			whereClause = whereClause.And((EventoMO x) => x.CODIGO_EMPRESA == exemplo.CODIGO_EMPRESA);
		}
		if (exemplo.NUMERO_PEDIDO > 0)
		{
			whereClause = whereClause.And((EventoMO x) => x.NUMERO_PEDIDO == exemplo.NUMERO_PEDIDO);
		}
		if (!string.IsNullOrEmpty(exemplo.SITUACAO))
		{
			whereClause = whereClause.And((EventoMO x) => x.SITUACAO == exemplo.SITUACAO);
		}
		return whereClause;
	}

	public void InserirEventoErroNaTabelaTemp(string nomeTabelaTemp, int codigoErro)
	{
		try
		{
			string comando = $" INSERT {nomeTabelaTemp}\r\n                                              SELECT e.seq_erro, e.descricao\r\n                                              FROM erro e\r\n                                              WHERE e.seq_erro = {codigoErro} ";
			ExecutarSqlCommand(comando);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void CancelarEventoPedidoEletronico(EventoPedidoEletronicoMO eventoEletronico)
	{
		try
		{
			string comando = "UPDATE evento\r\n                           SET cd_usr_enc = {0},\r\n                               dt_encer = getDate(),\r\n                               situacao = 'CA'\r\n                           WHERE seq_evento = {1} ";
			ExecutarSqlCommand(comando, eventoEletronico.CODIGO_USUARIO_GERACAO, eventoEletronico.SEQ_EVENTO);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void CancelarEvento(EventoMO evento)
	{
		try
		{
			string comando = "UPDATE evento\r\n                           SET cd_usr_enc = {0},\r\n                               dt_encer = getDate(),\r\n                               situacao = 'CA'\r\n                           WHERE seq_evento = {1} ";
			ExecutarSqlCommand(comando, evento.CODIGO_USUARIO_GERENTE, evento.SEQ_EVENTO);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public int GerarSeq(string nomeTabela)
	{
		try
		{
			string text = "Erro ao executar a procedure: usp_gera_seq(...)";
			int num = 0;
			string procedure = "usp_gera_seq";
			List<SqlParameter> list = new List<SqlParameter>
			{
				new SqlParameter("@par_str_tabela", nomeTabela)
			};
			SqlParameter sqlParameter = new SqlParameter("@rpar_nu_seq", num)
			{
				Direction = ParameterDirection.Output
			};
			list.Add(sqlParameter);
			SqlParameter item = new SqlParameter("@rpar_msg", text)
			{
				Direction = ParameterDirection.Output
			};
			list.Add(item);
			int returnValue = -1;
			string text2 = ExecutarStoredProcedureScalar<string>(procedure, list, out returnValue);
			text2 = ((text2 != null) ? text2 : text);
			if (returnValue < 0)
			{
				new Exception(text2);
			}
			return Convert.ToInt32(sqlParameter.Value);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
