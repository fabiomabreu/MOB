using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.EntityMapping;

public class PedidoEletronicoMap : BaseMap<PedidoEletronicoMO>
{
	public PedidoEletronicoMap()
	{
		if (VersaoDAL.ReleaseAtualMaiorMinima())
		{
			Property((PedidoEletronicoMO x) => x.DESCRICAO_VAN).HasColumnName("DescricaoVan");
		}
		else
		{
			Ignore((PedidoEletronicoMO x) => x.DESCRICAO_VAN);
		}
	}
}
