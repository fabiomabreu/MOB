using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class GrupoComissaoBLL : EntidadeBaseBLL<GrupoComissaoMO>
{
	protected override EntidadeBaseDAL<GrupoComissaoMO> GetInstanceDAL()
	{
		return new GrupoComissaoDAL();
	}
}
