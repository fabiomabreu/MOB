using System;
using System.Linq.Expressions;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class AcaoComercialPromocaoDAL : EntidadeBaseDAL<AcaoComercialPromocaoMO>
{
	protected override Expression<Func<AcaoComercialPromocaoMO, bool>> GetWhere(Expression<Func<AcaoComercialPromocaoMO, bool>> whereClause, AcaoComercialPromocaoMO exemplo)
	{
		if (exemplo.SEQ_ACAO_COMERCIAL > 0)
		{
			whereClause = whereClause.And((AcaoComercialPromocaoMO x) => x.SEQ_ACAO_COMERCIAL == exemplo.SEQ_ACAO_COMERCIAL);
		}
		return whereClause;
	}

	public int ObterSeqAcaoPromocao(AcaoComercialParamVO parametro)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(" SELECT TOP 1 a.seq_acao_comercial\r\n                                FROM acao_comercial a\r\n                                JOIN acao_comercial_prom ap\r\n                                  ON a.seq_acao_comercial = ap.seq_acao_comercial\r\n                                WHERE \r\n                                    a.dt_fim > GETDATE()\r\n                                AND a.situacao = 'AN'\r\n                                AND a.seq_kit = {0}\r\n                                AND ap.cd_prod = {1} ", parametro.SEQ_KIT, parametro.CODIGO_PRODUTO);
			if (parametro.BONIFICADO)
			{
				stringBuilder.Append(" AND ap.bonificado = 1 AND ap.verba_fabr_bonif = 1 ");
			}
			else
			{
				stringBuilder.Append(" AND ap.bonificado = 0 ");
			}
			return ExecutarScalarSQL<int>(stringBuilder.ToString(), Array.Empty<object>());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public decimal ObterValorVerbaFabricantePromocao(ItemPedidoMO item)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("  SELECT a.vl_verba_fabr\r\n                                       FROM acao_comercial_prom a\r\n                                      WHERE a.seq_acao_comercial = {0}\r\n                                        AND a.cd_prod = {1}\r\n                                        AND a.bonificado = 0 ", item.SEQ_ACAO_COMERCIAL, item.CODIGO_PRODUTO);
			return ExecutarScalarSQL<decimal>(stringBuilder.ToString(), Array.Empty<object>());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
