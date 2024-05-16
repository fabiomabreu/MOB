using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloPrecoBLL : IModuloBaseBLL
{
	void CalcularPrecoVenda(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda);

	void RatearDescontoGeral(PedidoVendaMO pedidoVenda);

	void CalcularTotaisPedido(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico);

	void CalcularCustoVenda(PedidoVendaMO pedidoVenda);

	void CarregarDescontoCondicaoPagamento(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda);

	void CarregarDescontoCampanha(ItemPedidoMO itemPedido, PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda);

	void CarregarDescontoPorQuantidade(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda);

	void CalcularDescontoPermitido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda);

	void CalcularTotalItemPedido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda);

	void ValidarDescontoGeral(PedidoVendaMO pedidoVenda);

	void ValidarDescontoMaximoPermitidoItens(PedidoVendaMO pedidoVenda);

	void ValidarLimiteDescontoItens(PedidoVendaMO pedidoVenda);

	void ValidarDesconto(PedidoVendaMO pedidoVenda);

	void ValidarPreco(PedidoVendaMO pedidoVenda);

	void ValidarKitPromocao(PedidoVendaMO pedidoVenda);

	void TratarItensBonificados(PedidoVendaMO pedidoVenda);

	void TratarArredondamentoPrecoBasico(PedidoVendaMO pedidoVenda);

	void CalcularJurosRateioCartaoCredito(PedidoVendaMO pedidoVenda);
}
