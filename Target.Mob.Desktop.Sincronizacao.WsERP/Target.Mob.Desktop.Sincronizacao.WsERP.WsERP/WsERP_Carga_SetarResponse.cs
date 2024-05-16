using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Carga_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Carga_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Carga_SetarResult;

	public WsERP_Carga_SetarResponse()
	{
	}

	public WsERP_Carga_SetarResponse(RetornoWsModelOfBoolean WsERP_Carga_SetarResult)
	{
		this.WsERP_Carga_SetarResult = WsERP_Carga_SetarResult;
	}
}
