using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TipoPedido_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TipoPedido_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TipoPedido_SetResult;

	public WsERP_TipoPedido_SetResponse()
	{
	}

	public WsERP_TipoPedido_SetResponse(RetornoWsModelOfBoolean WsERP_TipoPedido_SetResult)
	{
		this.WsERP_TipoPedido_SetResult = WsERP_TipoPedido_SetResult;
	}
}
