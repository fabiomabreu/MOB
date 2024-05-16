using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.EntityMapping;

public class PromocaoMap : BaseMap<PromocaoMO>
{
	public PromocaoMap()
	{
		if (VersaoDAL.ReleaseAtualMaiorMinima())
		{
			Property((PromocaoMO x) => x.CONSIDERA_PRAZO_FIXO_PRODUTO).HasColumnName("ConsideraPrzFixoProd");
		}
		else
		{
			Ignore((PromocaoMO x) => x.CONSIDERA_PRAZO_FIXO_PRODUTO);
		}
	}
}
