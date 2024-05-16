using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloComercialBLL : IModuloBaseBLL
{
	void CarregarTrocaPedido(PedidoVendaMO pedidoVenda);

	void AssociarTrocaPedido(PedidoVendaMO pedidoVenda);

	void ValidarTroca(PedidoVendaMO pedidoVenda);

	void CalcularVerbaPedido(PedidoVendaMO pedidoVenda);

	void EfetivarVerbaPedido(PedidoVendaMO pedidoVenda);

	void CalcularVerbaFabricanteItensPedido(PedidoVendaMO pedidoVenda);

	void CancelarVerbaPedido(PedidoVendaMO pedidoVenda);

	void CarregarAcaoComercial(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda);

	void AtualizarAcaoComercialFabricante(PedidoVendaMO pedidoVenda);

	void CarregarCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda);

	void DeletarCampanha(PedidoEletronicoMO pedidoEletronico);

	void AtualizaItPedvCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda);
}
