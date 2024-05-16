using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloFinanceiroBLL : IModuloBaseBLL
{
	void CalcularDescontoFinanceiro(PedidoVendaMO pedidoVenda);

	void GerarParcelasPedido(PedidoVendaMO pedidoVenda);

	void AtualizaPrazoMedioPedido(PedidoVendaMO pedidoVenda);

	void ValidarFormaPagamento(PedidoVendaMO pedidoVenda);

	void ValidarCondicaoPagamento(PedidoVendaMO pedidoVenda);

	bool PedidoAtingiuValorMinimo(PedidoVendaMO pedidoVenda, ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle);
}
