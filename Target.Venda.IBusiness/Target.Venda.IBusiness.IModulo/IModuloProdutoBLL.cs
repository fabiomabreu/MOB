using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloProdutoBLL : IModuloBaseBLL
{
	void GerarConsultaProduto(PedidoVendaMO pedidoVenda);

	void ValidarDadosProduto(PedidoVendaMO pedidoVenda);
}
