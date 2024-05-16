using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Pagamento_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Pagamento_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Pagamento_SetImportResult;

	public WsERP_Pagamento_SetImportResponse()
	{
	}

	public WsERP_Pagamento_SetImportResponse(RetornoWsModelOfBoolean WsERP_Pagamento_SetImportResult)
	{
		this.WsERP_Pagamento_SetImportResult = WsERP_Pagamento_SetImportResult;
	}
}
