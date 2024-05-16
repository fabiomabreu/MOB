using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Modulo;

public class ModuloProdutoBLL : ModuloBaseBLL, IModuloProdutoBLL, IModuloBaseBLL
{
	public void GerarConsultaProduto(PedidoVendaMO pedidoVenda)
	{
		ConsultaProdutoBLL consultaProdutoBLL = new ConsultaProdutoBLL();
		consultaProdutoBLL.GerarConsultaProduto(pedidoVenda);
	}

	public void ValidarDadosProduto(PedidoVendaMO pedidoVenda)
	{
		ProdutoBLL produtoBLL = new ProdutoBLL();
		produtoBLL.ValidarGrupoProdutoItensPedido(pedidoVenda);
		produtoBLL.ValidarProdutoControlado(pedidoVenda);
	}
}
