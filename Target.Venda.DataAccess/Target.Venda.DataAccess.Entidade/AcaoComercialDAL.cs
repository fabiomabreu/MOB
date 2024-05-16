using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class AcaoComercialDAL : EntidadeBaseDAL<AcaoComercialMO>
{
	protected override Expression<Func<AcaoComercialMO, bool>> GetWhere(Expression<Func<AcaoComercialMO, bool>> whereClause, AcaoComercialMO exemplo)
	{
		if (exemplo.SEQ_ACAO_COMERCIAL > 0)
		{
			whereClause = whereClause.And((AcaoComercialMO x) => x.SEQ_ACAO_COMERCIAL == exemplo.SEQ_ACAO_COMERCIAL);
		}
		return whereClause;
	}

	public List<AcaoComercialVO> ObterSeqAcaoComercial(PedidoEletronicoMO parametro)
	{
		try
		{
			string select = " SELECT\r\n\t                                i.seq SEQ_ITEM,\r\n\t                                CASE WHEN (i.seq_kit > 0 AND i.bonificado = 1)\r\n\t\t                                THEN \r\n\t\t\t\t                                (\tSELECT TOP 1 a.seq_acao_comercial\r\n\t\t\t\t\t                                FROM acao_comercial a\r\n\t\t\t\t\t\t\t                                JOIN acao_comercial_prom ap\r\n\t\t\t\t\t\t\t                                  ON a.seq_acao_comercial = ap.seq_acao_comercial\r\n\t\t\t\t\t\t\t                                WHERE a.situacao = 'AN'\r\n\t\t\t\t\t\t\t                                AND a.seq_kit = i.seq_kit\r\n\t\t\t\t\t\t\t                                AND ap.cd_prod = i.cd_prod\r\n\t\t\t\t\t\t\t                                AND ap.bonificado = 1 AND ap.verba_fabr_bonif = 1 )\r\n\t\t                                WHEN i.seq_kit > 0\r\n\t\t                                THEN \r\n\t\t\t\t                                ISNULL((\tSELECT TOP 1 a.seq_acao_comercial\r\n\t\t\t\t\t                                FROM acao_comercial a\r\n\t\t\t\t\t\t\t                                JOIN acao_comercial_prom ap\r\n\t\t\t\t\t\t\t                                  ON a.seq_acao_comercial = ap.seq_acao_comercial\r\n\t\t\t\t\t\t\t                                WHERE a.situacao = 'AN'\r\n\t\t\t\t\t\t\t                                AND a.seq_kit = i.seq_kit\r\n\t\t\t\t\t\t\t                                AND ap.cd_prod = i.cd_prod\r\n\t\t\t\t\t\t\t                                AND ap.bonificado = 0 ),\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(\tSELECT TOP 1 a.seq_acao_comercial\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tFROM acao_comercial a\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tJOIN acao_comercial_prod ad\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  ON a.seq_acao_comercial = ad.seq_acao_comercial\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tJOIN acao_comercial_prod_preco ap\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  ON ad.seq_acao_comercial = ap.seq_acao_comercial AND ad.cd_prod = ap.cd_prod\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tWHERE a.situacao = 'AN' \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  AND ap.cd_tabela = p.cd_tabela\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  AND ap.cd_prod = i.cd_prod\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  AND ad.item_encerrado = 0\t) \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t)\r\n\t\t\r\n\t\t                                WHEN ISNULL(i.bonificado,0) = 0 \r\n\t\t                                THEN\r\n\t\t\t\t                                (\tSELECT TOP 1 a.seq_acao_comercial\r\n\t\t\t\t\t\t\t                                FROM acao_comercial a\r\n\t\t\t\t\t\t\t                                JOIN acao_comercial_prod ad\r\n\t\t\t\t\t\t\t                                  ON a.seq_acao_comercial = ad.seq_acao_comercial\r\n\t\t\t\t\t\t\t                                JOIN acao_comercial_prod_preco ap\r\n\t\t\t\t\t\t\t                                  ON ad.seq_acao_comercial = ap.seq_acao_comercial AND ad.cd_prod = ap.cd_prod\r\n\t\t\t\t\t\t\t                                WHERE a.situacao = 'AN' \r\n\t\t\t\t\t\t\t                                  AND ap.cd_tabela = p.cd_tabela\r\n\t\t\t\t\t\t\t                                  AND ap.cd_prod = i.cd_prod\r\n\t\t\t\t\t\t\t                                  AND ad.item_encerrado = 0\r\n                                                              AND(  \r\n\t\t\t\t\t\t\t                                    EXISTS(\r\n\t\t\t\t\t\t\t                                        SELECT TOP 1 1\r\n\t\t\t\t\t\t\t                                        FROM AcaoComercialCliente WITH(NOLOCK)\r\n\t\t\t\t\t\t\t                                        WHERE SeqAcaoComercial = a.seq_acao_comercial\r\n\t\t\t\t\t\t\t                                        AND CdClien = p.cd_clien\t)\r\n\t\t\t\t\t\t\t                                          \r\n                                                                OR NOT EXISTS(\r\n\t\t\t\t\t\t\t                                        SELECT TOP 1 1\r\n\t\t\t\t\t\t\t                                        FROM AcaoComercialCliente WITH(NOLOCK)\r\n\t\t\t\t\t\t\t                                        WHERE SeqAcaoComercial = a.seq_acao_comercial )\r\n\t\t\t\t\t\t\t                                    )\r\n                                                )\r\n\t\t                                ELSE null\r\n\t                                END SEQ_ACAO_COMERCIAL\r\n                                FROM it_pedv_ele i\r\n                                JOIN ped_vda_ele p ON p.cd_emp_ele = i.cd_emp_ele\r\n\t\t\t\t                                  AND p.nu_ped_ele = i.nu_ped_ele\r\n\t\t\t                                      AND p.seq_ped = i.seq_ped\r\n                                WHERE i.cd_emp_ele = {0}\r\n                                  AND i.nu_ped_ele = {1} ";
			return ExecutarSelectSQL<AcaoComercialVO>(select, new object[2] { parametro.CODIGO_EMPRESA_ELETRONICO, parametro.NUMERO_PEDIDO_ELETRONICO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<AcaoComercialEncerradaVO> ObterAcaoComercialEncerradas(PedidoVendaMO pedidoVenda)
	{
		try
		{
			string select = " SELECT DISTINCT i.seq_acao_comercial as SEQ_ACAO_COMERCIAL,\r\n                                                   a.descricao as DESCRICAO_ACAO_COMERCIAL,\r\n                                                   'LVL' as MOTIVO_ENCERRAMENTO\r\n                                              FROM it_pedv i\r\n                                              JOIN acao_comercial a\r\n                                                ON a.seq_acao_comercial = i.seq_acao_comercial\r\n                                             WHERE i.cd_emp = {0}\r\n                                               AND i.nu_ped = {1}\r\n                                        AND EXISTS (SELECT 1 FROM vi_venda_acao_com_valor\r\n                                                     WHERE  seq_acao_comercial = i.seq_acao_comercial\r\n                                                       AND vl_verba_utilizada >= limite_verba) ";
			return ExecutarSelectSQL<AcaoComercialEncerradaVO>(select, new object[2] { pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<AcaoComercialEncerradaVO> ObterProdutosDaAcaoComercialEncerrada(int seqAcaoComercial)
	{
		try
		{
			string select = "   SELECT DISTINCT \r\n                                            a.cd_prod as CODIGO_PRODUTO,\r\n                                            p.desc_resum as DESCRICAO_PRODUTO,\r\n                                            a.seq_acao_comercial as SEQ_ACAO_COMERCIAL\r\n                                            a.descricao as DESCRICAO_ACAO_COMERCIAL\r\n                                       FROM acao_comercial_prod a\r\n                                       JOIN produto p ON a.cd_prod = p.cd_prod\r\n                                      WHERE a.seq_acao_comercial = {0}\r\n                                        AND a.item_encerrado = 0 ";
			return ExecutarSelectSQL<AcaoComercialEncerradaVO>(select, new object[1] { seqAcaoComercial });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public decimal ObterValorUtilizadoAcaoComercial(int seqAcaoComercial)
	{
		try
		{
			string select = " SELECT SUM( ISNULL(i.vl_verba_fabr, 0) ) as VALOR_UTILIZADO\r\n                                     FROM it_pedv i WITH (NOLOCK)\r\n                                    WHERE i.seq_acao_comercial = {0}\r\n                                     AND  i.situacao IN('AB','FA') ";
			return ExecutarScalarSQL<decimal>(select, new object[1] { seqAcaoComercial });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void EncerrarAcaoComercial(int seqAcaoComercial)
	{
		try
		{
			string comando = " UPDATE acao_comercial\r\n                                      SET situacao = 'EN'\r\n                                    WHERE seq_acao_comercial = {0}\r\n                                      AND situacao = 'AN' ";
			ExecutarSqlCommand(comando, seqAcaoComercial);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AlterarVigenciaAcaoComercial(AlterarVigenciaVO parametro)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" UPDATE acao_comercial\r\n                                 SET descricao = descricao ");
			if (parametro.DATA_INICIO.HasValue)
			{
				stringBuilder.AppendFormat(", dt_inicio = '{0}' ", parametro.DATA_INICIO.Value.ToString("yyyy-MM-dd"));
			}
			if (parametro.DATA_FIM.HasValue)
			{
				stringBuilder.AppendFormat(", dt_fim = '{0}' ", parametro.DATA_FIM.Value.ToString("yyyy-MM-dd"));
			}
			stringBuilder.AppendFormat(" WHERE seq_acao_comercial = {0} ", parametro.SEQ_ACAO_COMERCIAL);
			ExecutarSqlCommand(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
