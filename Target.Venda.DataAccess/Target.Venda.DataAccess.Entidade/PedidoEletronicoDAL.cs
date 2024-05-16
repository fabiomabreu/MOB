using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class PedidoEletronicoDAL : EntidadeBaseDAL<PedidoEletronicoMO>
{
	protected override Expression<Func<PedidoEletronicoMO, bool>> GetWhere(Expression<Func<PedidoEletronicoMO, bool>> whereClause, PedidoEletronicoMO exemplo)
	{
		if (exemplo.NUMERO_PEDIDO_ELETRONICO > 0)
		{
			whereClause = whereClause.And((PedidoEletronicoMO x) => x.NUMERO_PEDIDO_ELETRONICO == exemplo.NUMERO_PEDIDO_ELETRONICO);
		}
		if (exemplo.CODIGO_EMPRESA_ELETRONICO > 0)
		{
			whereClause = whereClause.And((PedidoEletronicoMO x) => x.CODIGO_EMPRESA_ELETRONICO == exemplo.CODIGO_EMPRESA_ELETRONICO);
		}
		if (exemplo.SEQ_PEDIDO_ELETRONICO > 0m)
		{
			whereClause = whereClause.And((PedidoEletronicoMO x) => x.SEQ_PEDIDO_ELETRONICO == exemplo.SEQ_PEDIDO_ELETRONICO);
		}
		if (exemplo.NUMERO_PEDIDO > 0)
		{
			whereClause = whereClause.And((PedidoEletronicoMO x) => x.NUMERO_PEDIDO == exemplo.NUMERO_PEDIDO);
		}
		if (exemplo.CODIGO_EMPRESA > 0)
		{
			whereClause = whereClause.And((PedidoEletronicoMO x) => x.CODIGO_EMPRESA == exemplo.CODIGO_EMPRESA);
		}
		return whereClause;
	}

	public int? RealizarCorteItensPedidoEletronico(PedidoEletronicoMO pedidoEletronicoMO)
	{
		string procedure = "UspCorteAutomaticoPedEle";
		List<SqlParameter> list = new List<SqlParameter>();
		list.Add(new SqlParameter("@parCdEmpEle", pedidoEletronicoMO.CODIGO_EMPRESA_ELETRONICO));
		list.Add(new SqlParameter("@parNuPedEle", pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO));
		return ExecutarStoredProcedureScalar<int?>(procedure, list);
	}

	public int? RealizarReservaCorteItensPedidoEletronico(PedidoEletronicoMO pedidoEletronicoMO, string nomeTabelaTemporaria)
	{
		string procedure = "uspCorteAutomaticoPendTempPedEle";
		List<SqlParameter> list = new List<SqlParameter>();
		list.Add(new SqlParameter("@parCdEmpEle", pedidoEletronicoMO.CODIGO_EMPRESA_ELETRONICO));
		list.Add(new SqlParameter("@parNuPedEle", pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO));
		list.Add(new SqlParameter("@NomeTblTempPedv", nomeTabelaTemporaria));
		return ExecutarStoredProcedureScalar<int?>(procedure, list);
	}

	public bool ValidarNumeroPedidoEletronico(int codigoEmpresa, int numeroPedido, int seq)
	{
		try
		{
			string select = " SELECT CAST(COUNT(1) AS BIT)\r\n                                   FROM ped_vda_ele\r\n                                   WHERE cd_emp_ele = {0}\r\n                                     AND nu_ped_ele = {1}\r\n                                     AND seq_ped = {2} ";
			return ExecutarScalarSQL<bool>(select, new object[3] { codigoEmpresa, numeroPedido, seq });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AtualizarNumeroPedidoERP(PedidoEletronicoMO pedidoEletronico)
	{
		try
		{
			string comando = " UPDATE ped_vda_ele SET nu_ped = {0},\r\n                                                          cd_emp = {1},\r\n                                                          pend_ele_libera_auto = {2}\r\n                                    WHERE nu_ped_ele = {3}\r\n                                      AND cd_emp_ele = {4}\r\n                                      AND seq_ped = {5} ";
			ExecutarSqlCommand(comando, pedidoEletronico.NUMERO_PEDIDO, pedidoEletronico.CODIGO_EMPRESA, pedidoEletronico.PEDIDO_ELETRONICO_LIBERA_AUTO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AtualizaLiberacaoManualPedVdaEle(PedidoEletronicoMO pedidoEletronico)
	{
		try
		{
			string comando = " UPDATE ped_vda_ele\r\n                                   SET\r\n                                       liberacao_automatica = 0 \r\n                                   WHERE\r\n                                       cd_emp_ele = {0}\r\n                                   AND nu_ped_ele = {1}\r\n                                   AND seq_ped = {2}";
			ExecutarSqlCommand(comando, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AtualizaVersaoLiberacaoTargetVendasPedVdaEle(PedidoEletronicoMO pedidoEletronico)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
		string fileVersion = versionInfo.FileVersion;
		try
		{
			string comando = " UPDATE ped_vda_ele\r\n                                   SET\r\n                                       VersaoLiberacaoTargetVendas = {3}\r\n                                   WHERE\r\n                                       cd_emp_ele = {0}\r\n                                   AND nu_ped_ele = {1}\r\n                                   AND seq_ped = {2}";
			ExecutarSqlCommand(comando, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO, fileVersion);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void CancelaPedVdaEle(PedidoEletronicoMO pedidoEletronico)
	{
		try
		{
			string comando = " UPDATE ped_vda_ele SET situacao = {0},\r\n                                    CancelamentoManual = {1}\r\n                                    WHERE nu_ped_ele = {2}\r\n                                      AND cd_emp_ele = {3}\r\n                                      AND seq_ped = {4} ";
			ExecutarSqlCommand(comando, "CA", pedidoEletronico.CANCELAMENTO_MANUAL, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<PedidoEletronicoVO> ObterPedidosParaLiberar(PedidoEletronicoMO pedidoEletronicoMO)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = (pedidoEletronicoMO.LIBERACAO_AUTOMATICA.ToBool() ? 1 : 0);
		try
		{
			stringBuilder.AppendFormat("  SELECT TOP 100\r\n                                            \r\n\t                                        pv.cd_emp_ele CODIGO_EMPRESA_ELETRONICO, \r\n\t                                        pv.nu_ped_ele NUMERO_PEDIDO_ELETRONICO,\r\n                                            pv.dt_ped DATA_PEDIDO,\r\n                                            cl.nome NOME_CLIENTE,\r\n                                            ep.seq_evento SEQ_EVENTO, \r\n\t                                        ep.dt_criacao DATA_CRIACAO, \r\n\t                                        pv.nu_ped_cli NRO_PEDIDO_CLIENTE, \r\n\t                                        pv.tp_ped TIPO_PEDIDO, \r\n\t                                        pv.cd_clien CODIGO_CLIENTE, \r\n\t                                        pv.cd_vend CODIGO_VENDEDOR,\r\n                                            pv.valor_tot VALOR_TOTAL, \r\n                                            cd_int_ped_ele TIPO_INTEGRACAO,\r\n\r\n                                          (SELECT SUM(CONVERT(NUMERIC(13,2), (ipe.vl_unit_ped * (1 - ISNULL(ipe.desc_apl, 0)))) * ipe.qtde_unid_ped)\r\n                                           FROM it_pedv_ele ipe (nolock)\r\n                                           WHERE ipe.nu_ped_ele = pv.nu_ped_ele\r\n                                             AND ipe.cd_emp_ele = pv.cd_emp_ele\r\n                                             AND ipe.seq_ped = pv.seq_ped) VALOR_TOTAL_COM_DESCONTO,\r\n\r\n                                          (SELECT COUNT(1) \r\n                                           FROM it_pedv_ele i (nolock)\r\n                                           WHERE i.cd_emp_ele = pv.cd_emp_ele\r\n                                             AND i.nu_ped_ele = pv.nu_ped_ele  ) TOTAL_ITENS\r\n\r\n                                        FROM ped_vda_ele pv (nolock)\r\n                                        JOIN evento_pdel ep (nolock)\r\n                                        JOIN evento_pdel_ab epa  (nolock) ON ep.seq_evento = epa.seq_evento ON pv.nu_ped_ele = ep.nu_ped_ele\r\n                                        AND pv.cd_emp_ele = ep.cd_emp_ele\r\n                                        AND pv.seq_ped = ep.seq_ped\r\n                                        JOIN cliente cl  (nolock)\r\n                                        JOIN end_cli ec  (nolock) ON cl.cd_clien = ec.cd_clien\r\n                                        AND ec.tp_end = 'EN' ON pv.cd_clien = cl.cd_clien\r\n                                        JOIN tp_ped tp  (nolock) ON pv.tp_ped = tp.tp_ped\r\n                                        LEFT JOIN rot_prdf rp  (nolock) ON cl.cd_rot_prdf = rp.cd_rot_prdf\r\n                                        JOIN tab_pre tab  (nolock) ON pv.cd_tabela = tab.cd_tabela\r\n                                        WHERE pv.cd_emp_ele = {0}\r\n                                        AND ISNULL(pv.imp_via_sp, 0) = 0\r\n                                        AND ISNULL(pv.pedido_direto, 0) = 0\r\n                                        AND ISNULL(tp.inventario, 0) = 0\r\n                                        AND ISNULL(pv.liberacao_automatica, 0) = {1}\r\n                                        AND pv.origem_pedido IN( {2} )\r\n                                        ", pedidoEletronicoMO.CODIGO_EMPRESA_ELETRONICO, num, pedidoEletronicoMO.OrigemPedidoVendaIn());
			if (pedidoEletronicoMO.CODIGO_CLIENTE.HasValue && pedidoEletronicoMO.CODIGO_CLIENTE > 0)
			{
				stringBuilder.AppendFormat(" AND cl.cd_clien = {0}", pedidoEletronicoMO.CODIGO_CLIENTE);
			}
			if (pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO > 0)
			{
				stringBuilder.AppendFormat(" AND pv.nu_ped_ele = {0}", pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO);
			}
			stringBuilder.Append("ORDER BY \r\n                                   pv.cd_vend,\r\n                                   pv.cd_clien ");
			return ExecutarSelectSQL<PedidoEletronicoVO>(stringBuilder.ToString(), Array.Empty<object>()).ToList();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ProdutoNaoConfigVendaVO> ObterItensPedidoEletronicoComProblemasCadastro(PedidoEletronicoMO pedidoEletronico)
	{
		try
		{
			string select = "\r\n                                    SELECT  vi.cd_prod AS CODIGO_PRODUTO,\r\n\t\t\t\t                            vi.descricao AS DESCRICAO_PRODUTO,\r\n\r\n\t\t\t\t                            tp.descricao AS DESCRICAO_TIPO_PEDIDO,\r\n\t\t\t\t                            vi.existe_promocao_emp AS EXISTE_PROMOCAO_EMPRESA,\r\n\r\n\t\t\t\t                            vi.existe_tab_pre_emp AS EXISTE_TABELA_PRECO_EMPRESA,\r\n\t\t\t\t                            ta.descricao AS DESCRICAO_TABELA_PRECO, \r\n\t\t\t\t                            vi.vl_preco AS VALOR_PRECO,\r\n\t\t\t\t                            vi.vl_parcela AS VALOR_PARCELA,\r\n\t\t\t\t\r\n\t\t\t\t                            vi.existe_icm_prod AS EXISTE_ICM_PROD,\r\n\t\t\t\t                            vi.cd_sit_trib AS CODIGO_SITUACAO_TRIB,\r\n\t\t\t\t                            vi.tipo_sit_trib AS TIPO_SITUACAO_TRIB,\r\n\t\t\t\t\r\n\t\t\t\t                            vi.unid_est  AS UNIDADE_ESTOQUE,\r\n\t\t\t\t                            lo.descricao AS DESCRICAO_LOCAL_ESTOQUE, \r\n\t\t\t\t                            gc.descricao AS DESCRICAO_GRUPO_COMISSAO\r\n\t\t                            FROM\r\n\t\t\t\t                            vi_pdel_prd_n_cfg vi\r\n\t\t\t\t                            LEFT OUTER JOIN tp_ped tp\r\n\t\t\t\t\t                            ON vi.tp_ped = tp.tp_ped\r\n\t\t\t\t                            LEFT OUTER JOIN tab_pre ta\r\n\t\t\t\t\t                            ON vi.cd_tabela = ta.cd_tabela\r\n\t\t\t\t                            LEFT OUTER JOIN grp_comis gc\r\n\t\t\t\t\t                            ON vi.cd_grp_comis = gc.cd_grp_comis\r\n\t\t\t\t                            LEFT OUTER JOIN local lo\r\n\t\t\t\t\t                            ON vi.cd_local = lo.cd_local\r\n\t\t\t\t\t                            AND vi.cd_emp_ele = lo.cd_emp\r\n\t\t\t                            WHERE\r\n\t\t\t\t                            vi.cd_emp_ele = {0}\r\n\t\t\t                            AND\tvi.nu_ped_ele = {1} ";
			return ExecutarSelectSQL<ProdutoNaoConfigVendaVO>(select, new object[2] { pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<decimal> ObterObservacoesPossuemLinhas(PedidoEletronicoMO pedidoEletronico)
	{
		string select = "SELECT op.seq\r\n                        FROM obs_ped_ele op\r\n                        JOIN lin_txt lt on op.cd_texto = lt.cd_texto\r\n                        WHERE op.cd_emp_ele = {0}\r\n                        AND op.nu_ped_ele = {1}\r\n                        AND op.seq_ped = {2}\r\n                        AND lt.num_lin = 1";
		return ExecutarSelectSQL<decimal>(select, new object[3] { pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO });
	}
}
