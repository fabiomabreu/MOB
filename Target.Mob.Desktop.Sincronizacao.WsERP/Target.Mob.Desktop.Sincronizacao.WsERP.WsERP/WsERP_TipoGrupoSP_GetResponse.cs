using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TipoGrupoSP_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TipoGrupoSP_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfTipoGrupoSPWsModel WsERP_TipoGrupoSP_GetResult;

	public WsERP_TipoGrupoSP_GetResponse()
	{
	}

	public WsERP_TipoGrupoSP_GetResponse(RetornoWsModelOfListOfTipoGrupoSPWsModel WsERP_TipoGrupoSP_GetResult)
	{
		this.WsERP_TipoGrupoSP_GetResult = WsERP_TipoGrupoSP_GetResult;
	}
}
