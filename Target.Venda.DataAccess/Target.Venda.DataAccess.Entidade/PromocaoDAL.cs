using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class PromocaoDAL : EntidadeBaseDAL<PromocaoMO>
{
	protected override Expression<Func<PromocaoMO, bool>> GetWhere(Expression<Func<PromocaoMO, bool>> whereClause, PromocaoMO exemplo)
	{
		if (exemplo.SEQ_PROMOCAO > 0)
		{
			whereClause = whereClause.And((PromocaoMO x) => x.SEQ_PROMOCAO == exemplo.SEQ_PROMOCAO);
		}
		return whereClause;
	}

	public decimal? ObterPrecoProdutoPelaPromocao(int codigoProduto, string codigoTabela, int seqPromocao, int? seqKit, Enum bonificado, int cdClien, int cdEmp)
	{
		if (VersaoDAL.VersaoAtualMaiorMinima())
		{
			try
			{
				string select = " SELECT dbo.fn_preco_condpgto({0}, {1}, {2}, 0, {3}, {4}, {5}, {6}) ";
				return ExecutarScalarSQL<decimal?>(select, new object[7] { codigoProduto, codigoTabela, seqPromocao, seqKit, bonificado, cdClien, cdEmp });
			}
			catch (Exception ex)
			{
				LogHelper.ErroLog(ex);
				throw ex;
			}
		}
		try
		{
			string select2 = " SELECT dbo.fn_preco_condpgto({0}, {1}, {2}, 0, {3}, {4}) ";
			return ExecutarScalarSQL<decimal?>(select2, new object[5] { codigoProduto, codigoTabela, seqPromocao, seqKit, bonificado });
		}
		catch (Exception ex2)
		{
			LogHelper.ErroLog(ex2);
			throw ex2;
		}
	}

	public List<ProdutoNaoAssoiadoCondicaoPagamentoVO> ObterItensPedidoNaoAssociadosCondicaoPagamento(PedidoEletronicoMO pedidoEletronico)
	{
		string select = " SELECT   DISTINCT\r\n                                        pv.seq_prom  SEQ_PROMOCAO,\r\n\t\t                                pm.descricao DESCRICAO_PROMOCAO,\r\n\t\t                                it.cd_prod   CODIGO_PRODUTO,\r\n\t\t                                pr.descricao DESCRICAO_PRODUTO\r\n\t                                 FROM\r\n\t \t                                ped_vda_ele pv (nolock)\r\n\t\t\t                                JOIN\tit_pedv_ele it (nolock)\r\n\t\t\t                                ON\tpv.cd_emp_ele = it.cd_emp_ele\r\n\t\t\t                                 AND\tpv.nu_ped_ele = it.nu_ped_ele\r\n\t\t\t                                 AND\tpv.seq_ped = it.seq_ped\r\n\t\t\t\t\r\n\t\t\t                                JOIN\tpromocao pm (nolock)\r\n\t\t\t                                ON\tpv.seq_prom = pm.seq_prom\r\n\t\t\t\r\n\t\t\t                                JOIN\tproduto pr (nolock)\r\n\t\t\t                                ON\tit.cd_prod = pr.cd_prod\r\n\t                                 WHERE\r\n\t  \t                                    it.cd_emp_ele = {0}\r\n\t                                 AND\tit.nu_ped_ele = {1}\r\n\t                                 AND\tit.seq_ped = {2}\r\n\t                                 AND \tNOT EXISTS ( SELECT\t1\r\n\t\t\t                                             FROM \tprom_prd (nolock)\r\n\t \t\t                                             WHERE \tseq_prom = pv.seq_prom\r\n\t \t\t                                             AND \tcd_prod = it.cd_prod )\r\n\t                                 ORDER BY 1, 2";
		return ExecutarSelectSQL<ProdutoNaoAssoiadoCondicaoPagamentoVO>(select, new object[3] { pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO });
	}

	public decimal ObterCoeficienteParcela(int seqPromocao)
	{
		string select = "select Cast(coef_parc as decimal(23,20))\r\n                        from Promocao a\r\n                        where a.seq_prom = {0}";
		return ExecutarScalarSQL<decimal>(select, new object[1] { seqPromocao });
	}

	public bool? CancelaPedidoVlMinPorOrigemPed(int cdEmp, string OrigemPedidoVenda)
	{
		string select = "SELECT\tISNULL(Ativo, 0)\r\n\t\t\t\t\t\tFROM\tAssocOrigPedVdaPcfg a\r\n\t\t\t\t\t\tWHERE\ta.CdEmp = {0}\r\n\t\t\t\t\t\tAND\t\ta.OrigemPedidoVenda = {1}";
		return ExecutarScalarSQL<bool?>(select, new object[2] { cdEmp, OrigemPedidoVenda });
	}
}
