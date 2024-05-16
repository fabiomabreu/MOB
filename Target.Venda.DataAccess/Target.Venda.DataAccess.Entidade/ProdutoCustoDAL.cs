using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class ProdutoCustoDAL : EntidadeBaseDAL<ProdutoCustoMO>
{
	protected override Expression<Func<ProdutoCustoMO, bool>> GetWhere(Expression<Func<ProdutoCustoMO, bool>> whereClause, ProdutoCustoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public ProdutoCustoVO CalcularCustoProduto(int codigoProduto, EmpresaMO empresa, EstadoMO estadoDestino, string tipoCusto)
	{
		string text = " SELECT\r\n                                (SELECT MAX( p.seq )\r\n                                FROM produto_custo_log p\r\n                                WHERE p.cd_emp = pc.cd_emp\r\n                                AND p.tp_custo = pc.tp_custo\r\n                                AND p.cd_prod = pc.cd_prod ) AS SEQ,\r\n                                pc.vl_custo AS VALOR_CUSTO,\r\n                                pc.vl_custo_sem_imposto AS VALOR_CUSTO_SEM_IMPOSTOS,\r\n                                pc.vl_icm_subst AS VALOR_ICMS_SUBST,\r\n                                pc.vl_icm_compra AS VALOR_ICMS_COMPRA,\r\n                                pc.vl_pis AS VALOR_PIS,\r\n                                pc.vl_cofins AS VALOR_CONFINS,\r\n                                ic.cred_icm_presumido AS CRED_ICMS_PRESUMIDO,\r\n                                CAST(pc.custo_capado_cred_icm AS BIT) AS CUSTO_CAPADO_CRED_ICMS\r\n                               FROM\r\n                                produto_custo pc ";
		text += "\r\n\r\n                            CROSS APPLY dbo.ufnIcmProd( {2}, pc.cd_prod , {0}, {1} ) ic                                \r\n\r\n                            WHERE\r\n                                pc.cd_emp = {2}\r\n                            AND pc.cd_prod = {3}\r\n                            AND  pc.tp_custo = {4} \r\n                            AND pc.cd_prod = ic.cd_prod ";
		return ExecutarScalarSQL<ProdutoCustoVO>(text, new object[5] { empresa.ESTADO, estadoDestino.ESTADO, empresa.CODIGO_EMPRESA, codigoProduto, tipoCusto });
	}

	public List<ProdutoCustoVO> CalcularCustoProdutoPedido(EmpresaMO empresa, EstadoMO estadoDestino, PedidoEletronicoMO pedidoEletronico)
	{
		string text = " SELECT DISTINCT\r\n                                pc.cd_prod as CODIGO_PRODUTO,\r\n                                pc.tp_custo  as TIPO_CUSTO,\r\n                                (SELECT MAX( p.seq )\r\n                                FROM produto_custo_log p\r\n                                WHERE p.cd_emp = pc.cd_emp\r\n                                AND p.tp_custo = pc.tp_custo\r\n                                AND p.cd_prod = pc.cd_prod ) AS SEQ,\r\n                                pc.vl_custo AS VALOR_CUSTO,\r\n                                pc.vl_custo_sem_imposto AS VALOR_CUSTO_SEM_IMPOSTOS,\r\n                                pc.vl_icm_subst AS VALOR_ICMS_SUBST,\r\n                                pc.vl_icm_compra AS VALOR_ICMS_COMPRA,\r\n                                pc.vl_pis AS VALOR_PIS,\r\n                                pc.vl_cofins AS VALOR_CONFINS,\r\n                                ISNULL(ic.cred_icm_presumido,0) AS CRED_ICMS_PRESUMIDO,\r\n                                ISNULL(CAST(pc.custo_capado_cred_icm AS BIT),0) AS CUSTO_CAPADO_CRED_ICMS\r\n                               FROM\r\n                                produto_custo pc ";
		text += "\r\n                            CROSS APPLY dbo.ufnIcmProd( {2}, pc.cd_prod , {0}, {1} ) ic\r\n\r\n                            JOIN it_pedv_ele it\r\n                            ON it.cd_prod = pc.cd_prod\r\n                            AND it.cd_emp_ele = pc.cd_emp\r\n                            WHERE\r\n                                it.cd_emp_ele = {2}\r\n                            AND it.nu_ped_ele = {3}\r\n                            AND pc.cd_prod = ic.cd_prod\r\n                            AND pc.tp_custo IN ('CUE', 'CMP', 'CRP') \r\n                            ORDER BY 1,2";
		return ExecutarSelectSQL<ProdutoCustoVO>(text, new object[4] { empresa.ESTADO, estadoDestino.ESTADO, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO });
	}
}
