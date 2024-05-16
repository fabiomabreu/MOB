using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Cliente_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Cliente_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Cliente_SetImportResult;

	public WsERP_Cliente_SetImportResponse()
	{
	}

	public WsERP_Cliente_SetImportResponse(RetornoWsModelOfBoolean WsERP_Cliente_SetImportResult)
	{
		this.WsERP_Cliente_SetImportResult = WsERP_Cliente_SetImportResult;
	}
}
