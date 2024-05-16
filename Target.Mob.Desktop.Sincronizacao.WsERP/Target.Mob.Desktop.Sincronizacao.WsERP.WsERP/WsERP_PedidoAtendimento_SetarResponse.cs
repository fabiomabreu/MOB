using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_PedidoAtendimento_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_PedidoAtendimento_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_PedidoAtendimento_SetarResult;

	public WsERP_PedidoAtendimento_SetarResponse()
	{
	}

	public WsERP_PedidoAtendimento_SetarResponse(RetornoWsModelOfBoolean WsERP_PedidoAtendimento_SetarResult)
	{
		this.WsERP_PedidoAtendimento_SetarResult = WsERP_PedidoAtendimento_SetarResult;
	}
}
