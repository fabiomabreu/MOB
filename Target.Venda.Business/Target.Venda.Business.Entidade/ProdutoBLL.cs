using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ProdutoBLL : EntidadeBaseBLL<ProdutoMO>
{
	protected override EntidadeBaseDAL<ProdutoMO> GetInstanceDAL()
	{
		return new ProdutoDAL();
	}

	public bool VerificaICMSDiferido(ItemPedidoMO item)
	{
		ProdutoDAL produtoDAL = (ProdutoDAL)BaseDAL;
		return produtoDAL.VerificaICMSDiferido(item);
	}

	public decimal BuscaCustoProdutoCalculo(ItemPedidoMO item, PedidoVendaMO pedidoVenda)
	{
		ProdutoDAL produtoDAL = (ProdutoDAL)BaseDAL;
		return produtoDAL.BuscaCustoProdutoCalculo(item.CODIGO_PRODUTO, LoginERP.EMPRESA_LOGADA.CODIGO_EMPRESA, pedidoVenda.TIPO_PEDIDO);
	}

	public void ValidarGrupoProdutoItensPedido(PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PAR_CFG.UTIL_CONTROLE_GRUPO_PRODUTO)
		{
			return;
		}
		ItemPedidoMO itemPedidoMO = pedidoVenda.ITENS.Find((ItemPedidoMO x) => x.CODIGO_GRUPO_PRODUTO != null);
		if (itemPedidoMO == null)
		{
			return;
		}
		pedidoVenda.CODIGO_GRUPO_PRODUTO = itemPedidoMO.CODIGO_GRUPO_PRODUTO;
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			if (iTEN.CODIGO_GRUPO_PRODUTO != null && !pedidoVenda.CODIGO_GRUPO_PRODUTO.Equals(iTEN.CODIGO_GRUPO_PRODUTO))
			{
				throw new MyException($"O Produto: {iTEN.CODIGO_PRODUTO}, não pertence ao mesmo grupo de produto dos demais itens do pedido.");
			}
		}
	}

	public void ValidarProdutoControlado(PedidoVendaMO pedidoVenda)
	{
		if (!pedidoVenda.TIPO_PEDIDO.PRODUTO_CONTROLADO && pedidoVenda.ITENS.Exists((ItemPedidoMO x) => x.PRODUTO_CONTROLADO))
		{
			throw new MyException("Tipo de pedido não suporta produtos controlados");
		}
	}

	public bool VerificaDescGeralProd(ItemPedidoMO item)
	{
		ProdutoDAL produtoDAL = (ProdutoDAL)BaseDAL;
		return produtoDAL.VerificaDescGeralProd(item);
	}
}
