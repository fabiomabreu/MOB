using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class KitPromocaoBLL : EntidadeBaseBLL<KitPromocaoMO>
{
	protected override EntidadeBaseDAL<KitPromocaoMO> GetInstanceDAL()
	{
		return new KitPromocaoDAL();
	}

	public void AlterarVigenciaKitPromocao(AlterarVigenciaVO parametro)
	{
		(BaseDAL as KitPromocaoDAL).AlterarVigenciaKitPromocao(parametro);
	}
}
