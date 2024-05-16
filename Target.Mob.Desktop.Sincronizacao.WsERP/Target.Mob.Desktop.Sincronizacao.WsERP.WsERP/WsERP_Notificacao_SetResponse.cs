using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Notificacao_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Notificacao_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Notificacao_SetResult;

	public WsERP_Notificacao_SetResponse()
	{
	}

	public WsERP_Notificacao_SetResponse(RetornoWsModelOfBoolean WsERP_Notificacao_SetResult)
	{
		this.WsERP_Notificacao_SetResult = WsERP_Notificacao_SetResult;
	}
}
