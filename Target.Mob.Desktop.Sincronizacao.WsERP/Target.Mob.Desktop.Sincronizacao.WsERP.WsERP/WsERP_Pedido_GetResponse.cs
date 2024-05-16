using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Pedido_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Pedido_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfPedVdaWsModel WsERP_Pedido_GetResult;

	public WsERP_Pedido_GetResponse()
	{
	}

	public WsERP_Pedido_GetResponse(RetornoWsModelOfPedVdaWsModel WsERP_Pedido_GetResult)
	{
		this.WsERP_Pedido_GetResult = WsERP_Pedido_GetResult;
	}
}
