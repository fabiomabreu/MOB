using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TipoPedido_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TipoPedido_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TipoPedido_SetarResult;

	public WsERP_TipoPedido_SetarResponse()
	{
	}

	public WsERP_TipoPedido_SetarResponse(RetornoWsModelOfBoolean WsERP_TipoPedido_SetarResult)
	{
		this.WsERP_TipoPedido_SetarResult = WsERP_TipoPedido_SetarResult;
	}
}
