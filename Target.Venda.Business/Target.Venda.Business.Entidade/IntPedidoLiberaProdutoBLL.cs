using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class IntPedidoLiberaProdutoBLL : EntidadeBaseBLL<IntPedidoLiberaProdutoMO>
{
	protected override EntidadeBaseDAL<IntPedidoLiberaProdutoMO> GetInstanceDAL()
	{
		return new IntPedidoLiberaProdutoDAL();
	}

	public void GerarIntPedidoLiberaProduto(int codigoProduto, string tipoAlteracaoEvento, string codigoTabela)
	{
		(BaseDAL as IntPedidoLiberaProdutoDAL).GerarIntPedidoLiberaProduto(codigoProduto, tipoAlteracaoEvento, codigoTabela);
	}

	public void AlterarIntPedidoLiberaProduto(int codigoProduto, string tipoAlteracaoEvento, bool emiteEtiqueta)
	{
		(BaseDAL as IntPedidoLiberaProdutoDAL).AlterarIntPedidoLiberaProduto(codigoProduto, tipoAlteracaoEvento, emiteEtiqueta);
	}
}
