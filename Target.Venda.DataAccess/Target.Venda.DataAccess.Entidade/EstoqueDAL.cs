using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class EstoqueDAL : EntidadeBaseDAL<EstoqueMO>
{
	protected override Expression<Func<EstoqueMO, bool>> GetWhere(Expression<Func<EstoqueMO, bool>> whereClause, EstoqueMO exemplo)
	{
		throw new NotImplementedException();
	}

	public decimal ObterQuantidadeDisponivel(EstoqueMO exemploEstoque)
	{
		string select = " SELECT ISNULL(vi.qtde - ISNULL(vi.qtde_pend_pedv,0),0)\r\n                        FROM vi_estoque vi\r\n                        WHERE vi.cd_local = {0}\r\n                        AND vi.cd_emp = {1}\r\n                        AND vi.cd_prod = {2}";
		return ExecutarScalarSQL<decimal>(select, new object[3] { exemploEstoque.CODIGO_LOCAL, exemploEstoque.CODIGO_EMPRESA, exemploEstoque.CODIGO_PRODUTO });
	}

	public decimal ObterQuantidadeDisponivelReservada(EstoqueMO exemploEstoque, string nomeTabelaTemporaria)
	{
		string select = " SELECT ISNULL( vi.qtde_pend_pedv, 0 )\r\n                        FROM estoque_dig_pend vi\r\n                        WHERE vi.cd_local = {0}\r\n                        AND vi.cd_emp = {1}\r\n                        AND vi.cd_prod = {2}\r\n                        AND vi.nome_tbl_temp_pedv = {3}    ";
		return ExecutarScalarSQL<decimal>(select, new object[4] { exemploEstoque.CODIGO_LOCAL, exemploEstoque.CODIGO_EMPRESA, exemploEstoque.CODIGO_PRODUTO, nomeTabelaTemporaria });
	}

	public void ForcarLockEstoque(string nomeTabelaTemporaria)
	{
		try
		{
			string comando = " UPDATE estoque_dig_pend\r\n                                       SET qtde_pend_pedv = qtde_pend_pedv\r\n                                     WHERE nome_tbl_temp_pedv = {0} ";
			ExecutarSqlCommand(comando, nomeTabelaTemporaria);
			string comando2 = "   UPDATE lote_est_dig_pend\r\n                                         SET qtde_pend_pedv = qtde_pend_pedv\r\n                                       WHERE nome_tbl_temp_pedv = {0}";
			ExecutarSqlCommand(comando2, nomeTabelaTemporaria);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AtualizarReservaEstoque(string nomeTabelaTemporaria)
	{
		try
		{
			List<ItemReservaEstoqueVO> list = ObterItensReservaDigPend(nomeTabelaTemporaria);
			string text = "";
			foreach (ItemReservaEstoqueVO item in list)
			{
				string text2 = item.QUANTIDADE.ToString().Replace(",", ".");
				text = "   \r\n                                            UPDATE\testoque\r\n\t                                        SET\tqtde_pend_pedv = qtde_pend_pedv + {0},\r\n\t\t                                        dt_ult_reserva = GETDATE()\r\n\t                                        WHERE\r\n\t\t                                        cd_emp = {1}\r\n\t                                        AND\tcd_prod = {2}\r\n\t                                        AND\tcd_local = '{3}'  ";
				text = string.Format(text, text2, item.CODIGO_EMPRESA, item.CODIGO_PRODUTO, item.CODIGO_LOCAL);
				ExecutarSqlCommand(text);
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void DroparTabelaTemporaria(string nomeTabelaTemporaria)
	{
		try
		{
			string select = $" SELECT \r\n                                                            count(1)\r\n                                                      FROM tempdb.dbo.sysobjects\r\n                                                      WHERE id = OBJECT_ID(N'tempdb.dbo.{nomeTabelaTemporaria}') ";
			if (Convert.ToBoolean(ExecutarScalarSQL<int>(select, Array.Empty<object>())))
			{
				string comando = $" DROP TABLE {nomeTabelaTemporaria}";
				ExecutarSqlCommand(comando);
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ItemReservaEstoqueVO> ObterItensReservaDigPend(string nomeTabelaTemporaria)
	{
		string select = "    SELECT\t\r\n                                    e.cd_emp as CODIGO_EMPRESA,\r\n\t                                e.cd_prod as CODIGO_PRODUTO,\r\n\t                                e.cd_local as CODIGO_LOCAL,\r\n\t                               CAST( SUM( ISNULL( e.qtde_pend_pedv, 0 ) ) AS DECIMAL(13,4)) as QUANTIDADE\r\n                                FROM\t\r\n                                    estoque_dig_pend e\r\n                                WHERE\t\r\n                                    e.nome_tbl_temp_pedv = {0}\r\n                                GROUP BY\r\n\t                                e.cd_emp,\r\n\t                                e.cd_local,\r\n\t                                e.cd_prod    ";
		return ExecutarSelectSQL<ItemReservaEstoqueVO>(select, new object[1] { nomeTabelaTemporaria });
	}

	public List<ItemReservaLoteEstoqueVO> ObterLoteEstItensReservaDigPend(string nomeTabelaTemporaria)
	{
		string select = "    SELECT\t\r\n                                e.cd_emp as CODIGO_EMPRESA,\r\n\t\t\t                    e.cd_local AS CODIGO_LOCAL,\r\n\t\t\t                    e.cd_prod AS CODIGO_PRODUTO,\r\n\t\t\t                    SUM( ISNULL( e.qtde_pend_pedv, 0 ) ) AS QUANTIDADE,\r\n\t\t\t                    e.seq_lote AS SEQ_LOTE\r\n\t\t                    FROM\t\r\n                                lote_est_dig_pend e\r\n\t\t                    WHERE\t\r\n                                e.nome_tbl_temp_pedv = {0}\r\n\t\t                    GROUP BY\r\n\t\t\t                    e.cd_emp,\r\n\t\t\t                    e.cd_local,\r\n\t\t\t                    e.cd_prod,\r\n\t\t\t                    e.seq_lote   ";
		return ExecutarSelectSQL<ItemReservaLoteEstoqueVO>(select, new object[1] { nomeTabelaTemporaria });
	}

	public void ExcluirQtdePendentes(string nomeTabelaTemporaria)
	{
		try
		{
			string comando = $" DELETE FROM estoque_dig_pend\r\n                                                        WHERE EstoqueDigPendID IN(  SELECT\r\n                                                                                        edp.EstoqueDigPendID\r\n                                                                                    FROM\r\n                                                                                        estoque_dig_pend edp\r\n                                                                                    WHERE\r\n                                                                                        edp.nome_tbl_temp_pedv = '{nomeTabelaTemporaria}' ) ";
			ExecutarSqlCommand(comando);
			string comando2 = $"DELETE FROM lote_est_dig_pend\r\n                                                    WHERE LoteEstDigPendID IN(  SELECT\r\n                                                                                    ledp.LoteEstDigPendID\r\n                                                                                FROM\r\n                                                                                    lote_est_dig_pend ledp\r\n                                                                                WHERE\r\n                                                                                    ledp.nome_tbl_temp_pedv = '{nomeTabelaTemporaria}' ) ";
			ExecutarSqlCommand(comando2);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void RemoverReservaEstoque(string nomeTabelaTemporaria)
	{
		try
		{
			string comando = $"   DELETE FROM estoque_dig_pend\r\n                                                WHERE EstoqueDigPendID IN(  SELECT\r\n                                                                                edp.EstoqueDigPendID\r\n                                                                            FROM\r\n                                                                                estoque_dig_pend edp WITH (NOLOCK)\r\n                                                                            WHERE\r\n                                                                                edp.nome_tbl_temp_pedv = '{nomeTabelaTemporaria}' )   ";
			ExecutarSqlCommand(comando, nomeTabelaTemporaria);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void RegistraReservaEstoque(PedidoVendaMO pedidoVenda, ItemPedidoMO item, ItemPedidoLocalMO itemLocal, string nomeTabelaTemporaria, string nomePrograma, TipoPedidoVO tipoPedido)
	{
		try
		{
			string procedure = "sp_atualiza_qtde_pend";
			List<SqlParameter> list = new List<SqlParameter>();
			list.Add(new SqlParameter("@par_nu_cd_emp", itemLocal.CODIGO_EMPRESA));
			list.Add(new SqlParameter("@par_str_cd_local", itemLocal.CODIGO_LOCAL));
			list.Add(new SqlParameter("@par_nu_cd_prod", item.CODIGO_PRODUTO));
			list.Add(new SqlParameter("@par_nu_qtde", itemLocal.QUANTIDADE));
			list.Add(new SqlParameter("@par_str_tp_mov", "E"));
			list.Add(new SqlParameter("@par_boo_mov_est_ctb", tipoPedido.ATUALIZA_ESTOQUE_CTB));
			list.Add(new SqlParameter("@par_boo_mov_est_fis", tipoPedido.ATUALIZA_ESTOQUE));
			list.Add(new SqlParameter("@par_boo_digitacao", true));
			list.Add(new SqlParameter("@par_str_nome_tbl_temp_pedv", nomeTabelaTemporaria));
			list.Add(new SqlParameter("@par_str_nome_programa", nomePrograma));
			list.Add(new SqlParameter("@par_str_tipo_retorno", "C"));
			string text = "Erro ao executar a procedure: sp_atualiza_qtde_pend(...)";
			SqlParameter sqlParameter = new SqlParameter("@rpar_str_msg_erro", text);
			sqlParameter.Direction = ParameterDirection.Output;
			list.Add(sqlParameter);
			int returnValue = -1;
			string text2 = ExecutarStoredProcedureScalar<string>(procedure, list, out returnValue);
			text2 = ((text2 != null) ? text2 : text);
			if (returnValue < 0)
			{
				new Exception(text2);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void AtualizarHorarioReservaEstoque(string nomeTabelaTemporaria)
	{
		try
		{
			string format = "   UPDATE es\r\n                                            SET es.dt_ult_reserva = GETDATE()\r\n                                            FROM estoque es\r\n                                            WHERE\r\n                                                es.EstoqueID IN(    SELECT \r\n\t\t\t\t\t\t\t                                            e.EstoqueDigPendID\r\n\t                                                                FROM\r\n                                                                        estoque_dig_pend e\r\n\t                                                                WHERE\r\n                                                                        e.nome_tbl_temp_pedv = '{0}'\r\n\t\t\t\t\t\t                                            AND\te.cd_emp = es.cd_emp\r\n\t\t\t\t\t\t                                            AND\te.cd_local = es.cd_local\r\n\t\t\t\t\t\t                                            AND\te.cd_prod = es.cd_prod\t)   ";
			format = string.Format(format, nomeTabelaTemporaria);
			ExecutarSqlCommand(format);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public bool ExisteEnderecoFinalWMS(string codigoLocal, int codigoEmpresa)
	{
		string select = "SELECT CAST( CASE WHEN COUNT(1) > 0 \r\n\t\t\t                              THEN 1 \r\n\t\t\t                              ELSE 0 \r\n\t\t\t                              END AS BIT)\r\n\t                    FROM wms_end w\r\n\t                    WHERE cd_emp = {1}\r\n\t                    AND\tcd_local = {0}\r\n\t                    AND\tend_final = 1";
		return ExecutarScalarSQL<bool>(select, new object[2] { codigoLocal, codigoEmpresa });
	}

	public bool ExisteQtdSuficienteLoteEscolhaAuto(int codigoEmpresa, int codigoProduto, decimal quantidade, string codigoLocal, DateTime? dtIniValidadeLote, DateTime? dtFimValidadeLote)
	{
		if (!dtFimValidadeLote.HasValue)
		{
			dtFimValidadeLote = DateTime.MaxValue;
		}
		string select = "SELECT\r\n                            CAST(1 AS BIT)\r\n                        FROM\r\n                            lote_prd l\r\n                        WHERE\r\n                             1 = 1\r\n                        AND  l.ativo = 1\r\n                        AND l.cd_prod = {0}  \r\n                        AND l.dt_validade >= {1}\r\n                        AND l.dt_validade <= {2}";
		if (!ExecutarScalarSQL<bool>(select, new object[3] { codigoProduto, dtIniValidadeLote, dtFimValidadeLote }))
		{
			return false;
		}
		select = "SELECT \r\n\t                    SUM(ISNULL(vi.qtde - (vi.qtde_pend_pedv + ISNULL(e.qtde, 0)),0))\r\n                    FROM\r\n\t                    vi_lote_est vi\r\n\t                    JOIN lote_prd l\r\n\t                    ON l.cd_prod = vi.cd_prod\r\n\t                    AND l.seq_lote = vi.seq_lote\r\n\t\t\t\t\tLEFT JOIN (\tSELECT\t\r\n\t\t\t\t\t\t\t\t\tee.qtde,\r\n\t\t\t\t\t\t\t\t\tee.cd_emp,\r\n\t\t\t\t\t\t\t\t\tee.cd_local,\r\n\t\t\t\t\t\t\t\t\tee.cd_prod,\r\n\t\t\t\t\t\t\t\t\tee.seq_lote\r\n\t\t\t\t\t\t\t\tFROM\r\n\t\t\t\t\t\t\t\t\twms_estoque ee\r\n\t\t\t\t\t\t\t\t\t\tJOIN wms_end w\r\n\t\t\t\t\t\t\t\t\t\t\tON\tee.cd_emp = w.cd_emp\r\n\t\t\t\t\t\t\t\t\t\t\tAND\tee.cd_local = w.cd_local\r\n\t\t\t\t\t\t\t\t\t\t\tAND\tee.seq_wms_end = w.seq_wms_end\r\n\t\t\t\t\t\t\t\t\t\t\tAND\tw.end_inicial = 1\t) as e\r\n\t\t\t\t\t\t\t\tON\tvi.cd_emp = e.cd_emp\r\n\t\t\t\t\t\t\t\tAND\tvi.cd_local = e.cd_local\r\n\t\t\t\t\t\t\t\tAND\tvi.cd_prod = e.cd_prod\r\n\t\t\t\t\t\t\t\tAND\tvi.seq_lote = e.seq_lote\r\n                    WHERE\r\n\t                    l.dt_validade >= {0}\r\n                    AND l.ativo = 1\r\n                    AND vi.cd_emp = {1}                        \r\n                    AND l.cd_prod = {2}\r\n                    AND vi.cd_local = {3}\r\n                    AND vi.qtde <> 0    \r\n                    AND l.dt_validade <= {4}";
		decimal num = ExecutarScalarSQL<decimal>(select, new object[5] { dtIniValidadeLote, codigoEmpresa, codigoProduto, codigoLocal, dtFimValidadeLote });
		if (num >= quantidade)
		{
			return true;
		}
		return false;
	}

	public void ReservaLotesManual(int cdEmp, int nuPed, int seqItPedv, int cdProd, string cdLocal, decimal qtdeLog, decimal qtdeEst, DateTime? dtValidadeIni, DateTime? dtValidadeFim, bool EscolhaLoteAuto)
	{
		try
		{
			LoteEstDAL loteEstDAL = new LoteEstDAL();
			List<LoteEstMO> list = loteEstDAL.ObterLotesDisponiveis(cdEmp, cdLocal, cdProd, dtValidadeIni, dtValidadeFim, EscolhaLoteAuto);
			decimal num = qtdeEst;
			decimal num2 = default(decimal);
			string empty = string.Empty;
			foreach (LoteEstMO item in list)
			{
				if (!(num > 0m))
				{
					continue;
				}
				if (item.QTDE - item.QTDE_PEND_PEDV > 0m)
				{
					if (item.QTDE_PEND_PEDV + num <= item.QTDE)
					{
						num2 = num;
						num = default(decimal);
					}
					else
					{
						num2 = item.QTDE - item.QTDE_PEND_PEDV;
						num -= num2;
					}
				}
				empty = "uspItPedvReservaLoteManual";
				List<SqlParameter> parameters = new List<SqlParameter>
				{
					new SqlParameter("@pCdEmp", cdEmp),
					new SqlParameter("@pNuPed", nuPed),
					new SqlParameter("@pSeqItPedv", seqItPedv),
					new SqlParameter("@pSeqLote", item.SEQ_LOTE),
					new SqlParameter("@pQtdeLote", num2)
				};
				ExecutarStoredProcedureNonQuery(empty, parameters, out var returnValue);
				if (returnValue == -100)
				{
					throw new Exception("uspItPedvReservaLoteManual - Erro na execução da procedure");
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
