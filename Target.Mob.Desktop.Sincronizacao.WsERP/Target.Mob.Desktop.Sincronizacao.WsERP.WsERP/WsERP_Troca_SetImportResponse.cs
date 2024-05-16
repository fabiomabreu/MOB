using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Troca_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Troca_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Troca_SetImportResult;

	public WsERP_Troca_SetImportResponse()
	{
	}

	public WsERP_Troca_SetImportResponse(RetornoWsModelOfBoolean WsERP_Troca_SetImportResult)
	{
		this.WsERP_Troca_SetImportResult = WsERP_Troca_SetImportResult;
	}
}
