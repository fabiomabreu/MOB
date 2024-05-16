using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Empresa_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Empresa_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Empresa_SetarResult;

	public WsERP_Empresa_SetarResponse()
	{
	}

	public WsERP_Empresa_SetarResponse(RetornoWsModelOfBoolean WsERP_Empresa_SetarResult)
	{
		this.WsERP_Empresa_SetarResult = WsERP_Empresa_SetarResult;
	}
}
