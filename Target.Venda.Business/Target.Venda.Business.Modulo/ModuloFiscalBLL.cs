using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Modulo;

public class ModuloFiscalBLL : ModuloBaseBLL, IModuloFiscalBLL, IModuloBaseBLL
{
	public void CarregarCFOPdoPedido(PedidoVendaMO pedidoVenda)
	{
		CfopBLL cfopBLL = new CfopBLL();
		cfopBLL.CarregarCFOPPedido(pedidoVenda);
		cfopBLL.CarregarCFOPSRPedido(pedidoVenda);
	}

	public void TratarICMSDiferido(PedidoVendaMO pedidoVenda)
	{
		ClienteBLL clienteBLL = new ClienteBLL();
		bool icmsDiferido = clienteBLL.VerificaICMSDiferido(pedidoVenda.CLIENTE);
		TipoPedidoBLL tipoPedidoBLL = new TipoPedidoBLL();
		tipoPedidoBLL.ValidarIcmsDiferido(pedidoVenda.TIPO_PEDIDO, icmsDiferido);
		ProdutoBLL produtoBLL = new ProdutoBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			bool icmsDiferido2 = produtoBLL.VerificaICMSDiferido(iTEN);
			tipoPedidoBLL.ValidarIcmsDiferido(pedidoVenda.TIPO_PEDIDO, icmsDiferido2);
		}
		tipoPedidoBLL.CarregarIcmsDiferidoNoPedido(pedidoVenda);
	}

	public void ValidarLiberacaoFiscal(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.ValidarLiberacaoFiscalItensPedido(pedidoVenda);
	}

	public void ValidarCFOPdoPedido(PedidoVendaMO pedidoVenda)
	{
		CfopBLL cfopBLL = new CfopBLL();
		cfopBLL.ValidarCFOPdoPedido(pedidoVenda);
	}
}
