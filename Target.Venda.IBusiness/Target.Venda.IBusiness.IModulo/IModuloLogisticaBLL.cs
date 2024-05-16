using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloLogisticaBLL : IModuloBaseBLL
{
	void CarregarMensagemExpedicao(PedidoVendaMO pedidoVenda);

	void CarregarTransportadoraPedido(PedidoVendaMO pedidoVenda);

	void CarregarVolumesItensPedido(PedidoVendaMO pedidoVenda);

	void CalcularPesoTotalPedido(PedidoVendaMO pedidoVenda);

	void GerarSiglaSeparacao(PedidoVendaMO pedidoVenda);

	void CalcularVolumeTotalPedido(PedidoVendaMO pedidoVenda);

	void ValidarTransportadora(PedidoVendaMO pedidoVenda);

	void CarregarVolumeItensPedidoSemInfoVolumes(PedidoVendaMO pedidoVenda);

	void ValidarEnderecoPedidoVenda(PedidoVendaMO pedidoVenda);

	void CalcularFrete(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico);
}
