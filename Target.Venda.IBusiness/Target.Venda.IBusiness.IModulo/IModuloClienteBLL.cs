using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloClienteBLL : IModuloBaseBLL
{
	void CarregarCliente(PedidoVendaMO pedidoVenda);

	void AtualizarTransportadoraCliente(PedidoVendaMO pedidoVenda);

	void ValidarCliente(PedidoVendaMO pedidoVenda);

	void AtualizarCondicaoComercialDoCliente(PedidoVendaMO pedidoVenda);

	void ValidarLimiteDeVendaPFxPJ(PedidoVendaMO pedidoVenda);
}
