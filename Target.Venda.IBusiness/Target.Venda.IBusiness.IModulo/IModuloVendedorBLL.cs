using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloVendedorBLL : IModuloBaseBLL
{
	void CalcularComissaoVendedor(PedidoVendaMO pedidoVenda);

	void ValidarVendedor(PedidoVendaMO pedidoVenda);
}
