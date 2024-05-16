using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_PedidoAtendimento_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_PedidoAtendimento_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_PedidoAtendimento_SetResult;

	public WsERP_PedidoAtendimento_SetResponse()
	{
	}

	public WsERP_PedidoAtendimento_SetResponse(RetornoWsModelOfBoolean WsERP_PedidoAtendimento_SetResult)
	{
		this.WsERP_PedidoAtendimento_SetResult = WsERP_PedidoAtendimento_SetResult;
	}
}
