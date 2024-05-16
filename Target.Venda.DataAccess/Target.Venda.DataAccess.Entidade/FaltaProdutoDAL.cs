using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class FaltaProdutoDAL : EntidadeBaseDAL<FaltaProdutoMO>
{
	protected override Expression<Func<FaltaProdutoMO, bool>> GetWhere(Expression<Func<FaltaProdutoMO, bool>> whereClause, FaltaProdutoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public List<FaltaProdutoMO> ObterFaltasPedidoEletronico(PedidoEletronicoMO pedidoEletronicoMO)
	{
		string format = " SELECT  it.cd_prod CODIGO_PRODUTO,\r\n                                 GETDATE() AS DATA_FALTA,\r\n                                 it.QtdeFalta QUANTIDADE_FALTA,\r\n                                 CAST(CASE WHEN it.ind_relacao = 'MAIOR'\r\n                                          THEN it.QtdeFalta / it.fator_est_ped\r\n                                          ELSE it.QtdeFalta * it.fator_est_ped\r\n                                     END AS numeric(15,4)) AS QUANTIDADE_FALTA_VENDA,\r\n                                 pre.vl_preco PRECO_BASICO,\r\n                                 CONVERT(NUMERIC(15,4),pre.vl_preco - ((1 - ( 1 - ISNULL(it.desc_apl, 0))) * pre.vl_preco)) PRECO_UNITARIO,   \r\n                                 pr.unid_est UNIDADE_ESTOQUE,\r\n                                 it.unid_ped UNIDADE_VENDA,\r\n                                 CAST(isnull(it.bonificado,0) AS BIT) BONIFICADO,\r\n                                 it.seq_kit SEQ_KIT_PROMOCAO,\r\n                                 it.SEQ AS SEQ_ITEM_PEDIDO,\r\n                                 'CELE' as CODIGO_TIPO_FALTA_PRODUTO,\r\n                                 (SELECT TOP 1 cd_emp\r\n\t\t                            FROM tped_loc\r\n\t\t                            WHERE tp_ped = p.tp_ped) CODIGO_EMPRESA_LOCAL_ESTOQUE,\r\n\t\t                        (SELECT TOP 1 cd_local\r\n\t\t                            FROM tped_loc\r\n\t\t                            WHERE tp_ped = p.tp_ped) CODIGO_LOCAL\r\n                         FROM it_pedv_ele it\r\n                         JOIN preco pre \r\n                            ON pre.cd_prod = it.cd_prod\r\n                            AND pre.cd_tabela = '{2}'\r\n                         JOIN produto pr \r\n                            ON pr.cd_prod = it.cd_prod\r\n                         JOIN ped_vda_ele p\r\n\t\t                    ON p.cd_emp_ele = it.cd_emp_ele\r\n\t\t                    AND p.nu_ped_ele = it.nu_ped_ele\r\n                         WHERE it.cd_emp_ele = {0}\r\n                         AND it.nu_ped_ele = {1}\r\n                         AND it.QtdeFalta > 0    ";
		string selectSQL = string.Format(format, pedidoEletronicoMO.CODIGO_EMPRESA_ELETRONICO, pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO, pedidoEletronicoMO.CODIGO_TABELA);
		return ExecutarSelectSQLToDataReader<FaltaProdutoMO>(selectSQL);
	}
}
