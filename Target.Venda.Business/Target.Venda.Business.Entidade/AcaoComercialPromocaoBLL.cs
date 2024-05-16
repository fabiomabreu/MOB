using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class AcaoComercialPromocaoBLL : EntidadeBaseBLL<AcaoComercialPromocaoMO>
{
	protected override EntidadeBaseDAL<AcaoComercialPromocaoMO> GetInstanceDAL()
	{
		return new AcaoComercialPromocaoDAL();
	}

	public int ObterSeqAcaoPromocao(AcaoComercialParamVO parametro)
	{
		return (BaseDAL as AcaoComercialPromocaoDAL).ObterSeqAcaoPromocao(parametro);
	}

	public decimal ObterValorVerbaFabricantePromocao(ItemPedidoMO item)
	{
		return (BaseDAL as AcaoComercialPromocaoDAL).ObterValorVerbaFabricantePromocao(item);
	}
}
