using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ConsultaProdutoBLL : EntidadeBaseBLL<ConsultaProdutoMO>
{
	protected override EntidadeBaseDAL<ConsultaProdutoMO> GetInstanceDAL()
	{
		return new ConsultaProdutoDAL();
	}

	public void GerarConsultaProduto(PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PARAMETROS_TELA.VENDA.REGISTRA_DADOS_DE_CONSULTA_AO_PRODUTO)
		{
			return;
		}
		ConsultaProdutoDAL consultaProdutoDAL = BaseDAL as ConsultaProdutoDAL;
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			if (!consultaProdutoDAL.VerificarConsultaProduto(pedidoVenda, iTEN))
			{
				consultaProdutoDAL.InserirConsultaProduto(iTEN, pedidoVenda);
			}
			else
			{
				consultaProdutoDAL.AtualizaConsultaProduto(iTEN, pedidoVenda);
			}
		}
	}
}
