using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_LogErro_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_LogErro_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_LogErro_SetarResult;

	public WsERP_LogErro_SetarResponse()
	{
	}

	public WsERP_LogErro_SetarResponse(RetornoWsModelOfBoolean WsERP_LogErro_SetarResult)
	{
		this.WsERP_LogErro_SetarResult = WsERP_LogErro_SetarResult;
	}
}
