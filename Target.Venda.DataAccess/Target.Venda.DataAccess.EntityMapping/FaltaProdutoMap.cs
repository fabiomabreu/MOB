using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.EntityMapping;

public class FaltaProdutoMap : BaseMap<FaltaProdutoMO>
{
	public FaltaProdutoMap()
	{
		if (VersaoDAL.VERSAO_ERP_ATUAL.MAJOR > 11 || VersaoDAL.VERSAO_ERP_ATUAL.MINOR > 2 || VersaoDAL.VERSAO_ERP_ATUAL.BUILD >= 15)
		{
			Property((FaltaProdutoMO x) => x.CODIGO_EMPRESA_LOCAL_ESTOQUE).HasColumnName("CdEmpLocalEstoque");
			Property((FaltaProdutoMO x) => x.CODIGO_LOCAL).HasColumnName("CdLocal");
		}
		else
		{
			Ignore((FaltaProdutoMO x) => x.CODIGO_EMPRESA_LOCAL_ESTOQUE);
			Ignore((FaltaProdutoMO x) => x.CODIGO_LOCAL);
		}
	}
}
