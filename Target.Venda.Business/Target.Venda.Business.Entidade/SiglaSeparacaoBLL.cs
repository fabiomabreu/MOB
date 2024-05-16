using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class SiglaSeparacaoBLL : EntidadeBaseBLL<SiglaSeparacaoMO>
{
	protected override EntidadeBaseDAL<SiglaSeparacaoMO> GetInstanceDAL()
	{
		return new SiglaSeparacaoDAL();
	}
}
