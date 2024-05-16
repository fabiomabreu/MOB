using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Modulo;

public class ModuloClienteBLL : ModuloBaseBLL, IModuloClienteBLL, IModuloBaseBLL
{
	public void CarregarCliente(PedidoVendaMO pedidoVenda)
	{
		int value = pedidoVenda.PEDIDO_ELETRONICO.CODIGO_CLIENTE.Value;
		ClienteBLL clienteBLL = new ClienteBLL();
		pedidoVenda.CLIENTE = clienteBLL.CarregarClientePeloCodigo(value);
	}

	public void AtualizarTransportadoraCliente(PedidoVendaMO pedidoVenda)
	{
		ClienteBLL clienteBLL = new ClienteBLL();
		clienteBLL.AtualizaTransportadora(pedidoVenda);
	}

	public void ValidarCliente(PedidoVendaMO pedidoVenda)
	{
		ClienteBLL clienteBLL = new ClienteBLL();
		clienteBLL.ValidarClienteParaVenda(pedidoVenda);
	}

	public void AtualizarCondicaoComercialDoCliente(PedidoVendaMO pedidoVenda)
	{
		ClienteBLL clienteBLL = new ClienteBLL();
		clienteBLL.AtualizaCondicaoComercialPadrao(pedidoVenda);
	}

	public void ValidarLimiteDeVendaPFxPJ(PedidoVendaMO pedidoVenda)
	{
		ClienteBLL clienteBLL = new ClienteBLL();
		clienteBLL.ValidarLimiteDeVenda(pedidoVenda);
	}
}
