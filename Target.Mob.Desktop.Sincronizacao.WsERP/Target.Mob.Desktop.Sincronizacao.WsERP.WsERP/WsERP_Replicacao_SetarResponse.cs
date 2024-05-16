using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Replicacao_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Replicacao_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Replicacao_SetarResult;

	public WsERP_Replicacao_SetarResponse()
	{
	}

	public WsERP_Replicacao_SetarResponse(RetornoWsModelOfBoolean WsERP_Replicacao_SetarResult)
	{
		this.WsERP_Replicacao_SetarResult = WsERP_Replicacao_SetarResult;
	}
}
