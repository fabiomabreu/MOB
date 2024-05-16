using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.Helpers;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Modulo;

public class ModuloVendedorBLL : ModuloBaseBLL, IModuloVendedorBLL, IModuloBaseBLL
{
	public void CalcularComissaoVendedor(PedidoVendaMO pedidoVenda)
	{
		TipoPedidoVO tIPO_PEDIDO = pedidoVenda.TIPO_PEDIDO;
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		ClienteMO cliente = pedidoVenda.CLIENTE;
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		if (tIPO_PEDIDO.INVENTARIO || !tIPO_PEDIDO.COMISSAO)
		{
			itemPedidoBLL.LimparValoresComissaoDeTodosItensPedido(pedidoVenda);
			return;
		}
		ProdutoComissaoBLL produtoComissaoBLL = new ProdutoComissaoBLL();
		bool utilizaComissaoCliente = cliente.PERCENTUAL_COMISSAO.HasValue && pAR_CFG.COMIS_CLIEN;
		List<ItemPedidoComissaoVO> itensPedidoComissao = produtoComissaoBLL.ObterComissaoItemPedido(pedidoVenda);
		pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO i)
		{
			ItemPedidoComissaoVO itemPedidoComissaoVO = itensPedidoComissao.Find((ItemPedidoComissaoVO x) => x.SEQ == i.SEQ);
			i.COMISSAO_PADRAO = itemPedidoComissaoVO.COMISSAO_PADRAO;
			i.COMISSAO_PROMOCAO = itemPedidoComissaoVO.COMISSAO_PROMOCAO;
			if (utilizaComissaoCliente && itemPedidoComissaoVO.COMISSAO_PROMOCAO == 0m)
			{
				i.COMISSAO_PADRAO = cliente.PERCENTUAL_COMISSAO.ToDecimal();
			}
		});
		pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO i)
		{
			produtoComissaoBLL.CalcularComisssaoItemPedido(i, pedidoVenda);
		});
		produtoComissaoBLL.RatearComisssaoRT(pedidoVenda);
	}

	public void ValidarVendedor(PedidoVendaMO pedidoVenda)
	{
		MyException ex = new MyException();
		if (!pedidoVenda.VENDEDOR.ATIVO.HasValue || !pedidoVenda.VENDEDOR.ATIVO.Value)
		{
			ex.AddErro("O vendedor: {0}, está inativo.", pedidoVenda.VENDEDOR.CODIGO_VENDEDOR);
		}
		if (string.IsNullOrEmpty(pedidoVenda.VENDEDOR.CODIGO_EQUIPE))
		{
			ex.AddErro("O vendedor: {0}, está sem Equipe Associada.", pedidoVenda.VENDEDOR.CODIGO_VENDEDOR);
		}
		ex.ThrowException();
	}
}
