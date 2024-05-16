using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloFiscalBLL : IModuloBaseBLL
{
	void CarregarCFOPdoPedido(PedidoVendaMO pedidoVenda);

	void TratarICMSDiferido(PedidoVendaMO pedidoVenda);

	void ValidarLiberacaoFiscal(PedidoVendaMO pedidoVenda);

	void ValidarCFOPdoPedido(PedidoVendaMO pedidoVenda);
}
