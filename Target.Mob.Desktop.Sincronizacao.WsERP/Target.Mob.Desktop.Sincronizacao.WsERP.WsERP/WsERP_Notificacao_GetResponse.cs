using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Notificacao_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Notificacao_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfInt32 WsERP_Notificacao_GetResult;

	public WsERP_Notificacao_GetResponse()
	{
	}

	public WsERP_Notificacao_GetResponse(RetornoWsModelOfInt32 WsERP_Notificacao_GetResult)
	{
		this.WsERP_Notificacao_GetResult = WsERP_Notificacao_GetResult;
	}
}
