using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class ProdutoCustoBLL : EntidadeBaseBLL<ProdutoCustoMO>
{
	protected override EntidadeBaseDAL<ProdutoCustoMO> GetInstanceDAL()
	{
		return new ProdutoCustoDAL();
	}

	public ProdutoCustoVO CalcularCustoProduto(int codigoProduto, EmpresaMO empresa, EstadoMO estadoDestino, string tipoCusto)
	{
		return (BaseDAL as ProdutoCustoDAL).CalcularCustoProduto(codigoProduto, empresa, estadoDestino, tipoCusto);
	}

	public List<ProdutoCustoVO> CalcularCustoProdutoPedido(EmpresaMO empresa, EstadoMO estadoDestino, PedidoEletronicoMO pedidoEletronico)
	{
		return (BaseDAL as ProdutoCustoDAL).CalcularCustoProdutoPedido(empresa, estadoDestino, pedidoEletronico);
	}

	public decimal ObterValorVerbaFabricanteBonificado(ItemPedidoMO item, EmpresaMO empresa, string tipoCusto)
	{
		object[] ids = new object[3] { empresa.CODIGO_EMPRESA, item.CODIGO_PRODUTO, tipoCusto };
		ProdutoCustoMO produtoCustoMO = ObterPeloID(ids);
		return produtoCustoMO.VALOR_CUSTO.ToDecimal();
	}
}
