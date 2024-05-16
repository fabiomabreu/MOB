using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Pedido_GetNewsResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Pedido_GetNewsResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_Pedido_GetNewsResult;

	public WsERP_Pedido_GetNewsResponse()
	{
	}

	public WsERP_Pedido_GetNewsResponse(RetornoWsModelOfListOfInt32 WsERP_Pedido_GetNewsResult)
	{
		this.WsERP_Pedido_GetNewsResult = WsERP_Pedido_GetNewsResult;
	}
}
