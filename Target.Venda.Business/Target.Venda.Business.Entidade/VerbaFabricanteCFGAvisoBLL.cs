using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class VerbaFabricanteCFGAvisoBLL : EntidadeBaseBLL<VerbaFabricanteCFGAvisoMO>
{
	protected override EntidadeBaseDAL<VerbaFabricanteCFGAvisoMO> GetInstanceDAL()
	{
		return new VerbaFabricanteCFGAvisoDAL();
	}

	public List<DestinatarioEmailVO> ObterDestinatariosEmailVerbaFabricante()
	{
		return (BaseDAL as VerbaFabricanteCFGAvisoDAL).ObterDestinatariosEmailVerbaFabricante();
	}
}
