using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Pedido_SetImportarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Pedido_SetImportarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Pedido_SetImportarResult;

	public WsERP_Pedido_SetImportarResponse()
	{
	}

	public WsERP_Pedido_SetImportarResponse(RetornoWsModelOfBoolean WsERP_Pedido_SetImportarResult)
	{
		this.WsERP_Pedido_SetImportarResult = WsERP_Pedido_SetImportarResult;
	}
}
