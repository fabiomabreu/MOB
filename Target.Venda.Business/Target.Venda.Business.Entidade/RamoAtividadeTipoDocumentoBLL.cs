using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class RamoAtividadeTipoDocumentoBLL : EntidadeBaseBLL<RamoAtividadeTipoDocumentoMO>
{
	protected override EntidadeBaseDAL<RamoAtividadeTipoDocumentoMO> GetInstanceDAL()
	{
		return new RamoAtividadeTipoDocumentoDAL();
	}
}
