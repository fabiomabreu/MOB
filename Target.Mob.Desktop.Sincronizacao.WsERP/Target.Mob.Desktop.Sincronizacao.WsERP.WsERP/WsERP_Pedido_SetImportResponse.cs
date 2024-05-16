using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Pedido_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Pedido_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Pedido_SetImportResult;

	public WsERP_Pedido_SetImportResponse()
	{
	}

	public WsERP_Pedido_SetImportResponse(RetornoWsModelOfBoolean WsERP_Pedido_SetImportResult)
	{
		this.WsERP_Pedido_SetImportResult = WsERP_Pedido_SetImportResult;
	}
}
