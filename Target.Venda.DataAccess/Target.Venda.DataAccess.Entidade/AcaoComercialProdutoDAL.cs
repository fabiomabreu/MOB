using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class AcaoComercialProdutoDAL : EntidadeBaseDAL<AcaoComercialProdutoMO>
{
	protected override Expression<Func<AcaoComercialProdutoMO, bool>> GetWhere(Expression<Func<AcaoComercialProdutoMO, bool>> whereClause, AcaoComercialProdutoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public decimal ObterValorVerbaFabricanteProduto(ItemPedidoMO item)
	{
		try
		{
			string select = " SELECT a.vl_verba_fabr\r\n                                  FROM acao_comercial_prod a\r\n                                 WHERE a.seq_acao_comercial = {0}\r\n                                   AND a.cd_prod = {1} ";
			return ExecutarScalarSQL<decimal>(select, new object[2] { item.SEQ_ACAO_COMERCIAL, item.CODIGO_PRODUTO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<AcaoComercialEncerradaVO> ObterAcaoComercialProdutoEncerradasFaltaEstoque(PedidoVendaMO pedidoVenda)
	{
		try
		{
			string select = "   SELECT DISTINCT\r\n                                        f.seq_acao_comercial as SEQ_ACAO_COMERCIAL,\r\n                                        a.descricao as DESCRICAO_ACAO_COMERCIAL,\r\n                                        f.cd_prod as CODIGO_PRODUTO,\r\n                                        p.desc_resum as DESCRICAO_PRODUTO,\r\n                                        'EZ' as MOTIVO_ENCERRAMENTO\r\n                                       FROM faltaprd f\r\n                                       JOIN acao_comercial a\r\n                                         ON f.seq_acao_comercial = a.seq_acao_comercial\r\n                                       JOIN produto p\r\n                                         ON f.cd_prod = p.cd_prod\r\n                                      WHERE f.cd_emp = {0}\r\n                                        AND f.nu_ped = {1}\r\n                                        AND a.tp_acao_comercial = 'TPR' ";
			return ExecutarSelectSQL<AcaoComercialEncerradaVO>(select, new object[2] { pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<AcaoComercialEncerradaVO> ObterAcaoComercialProdutoEncerradasLimite(PedidoVendaMO pedidoVenda)
	{
		try
		{
			string select = " SELECT DISTINCT i.seq_acao_comercial as SEQ_ACAO_COMERCIAL,\r\n                                                i.cd_prod AS CODIGO_PRODUTO,\r\n                                                'LV' AS MOTIVO_ENCERRAMENTO\r\n                                          FROM it_pedv i\r\n                                         WHERE i.cd_emp = {0}\r\n                                           AND i.nu_ped = {1}\r\n                                           AND EXISTS (SELECT 1 FROM vi_venda_acao_comercial\r\n                                                       WHERE  cd_prod = i.cd_prod\r\n                                                         AND seq_acao_comercial = i.seq_acao_comercial\r\n                                                         AND item_encerrado = 0\r\n                                                         AND qtde_venda >= limite_venda\r\n                                                         AND limite_venda > 0) ";
			return ExecutarSelectSQL<AcaoComercialEncerradaVO>(select, new object[2] { pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void EncerrarAcaoComercialProduto(AcaoComercialEncerradaVO acaoComercialEnc)
	{
		try
		{
			string comando = " UPDATE acao_comercial_prod\r\n                                      SET item_encerrado = 1\r\n                                    WHERE seq_acao_comercial = {0}\r\n                                      AND cd_prod = {1} ";
			ExecutarSqlCommand(comando, acaoComercialEnc.SEQ_ACAO_COMERCIAL, acaoComercialEnc.CODIGO_PRODUTO);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void EncerrarTodosProdutosAcaoComercial(int seqAcaoComercial)
	{
		try
		{
			string comando = "   UPDATE acao_comercial_prod\r\n                                        SET item_encerrado = 1\r\n                                      WHERE seq_acao_comercial = {0} ";
			ExecutarSqlCommand(comando, seqAcaoComercial);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public bool VerificarAcaoComercialProdutoEstaEncerrada(AcaoComercialEncerradaVO acaoComercialEncerrada)
	{
		try
		{
			string select = " SELECT CAST( CASE WHEN COUNT(1) = 0 \r\n                                                     THEN 1\r\n                                                     ELSE 0 END AS BIT)\r\n                                     FROM acao_comercial_prod\r\n                                    WHERE seq_acao_comercial = {0}\r\n                                      AND item_encerrado = 0 ";
			return ExecutarScalarSQL<bool>(select, new object[1] { acaoComercialEncerrada.SEQ_ACAO_COMERCIAL });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
