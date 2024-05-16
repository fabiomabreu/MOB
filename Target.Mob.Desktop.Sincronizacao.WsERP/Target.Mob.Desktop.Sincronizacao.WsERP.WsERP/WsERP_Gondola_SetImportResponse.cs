using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Gondola_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Gondola_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Gondola_SetImportResult;

	public WsERP_Gondola_SetImportResponse()
	{
	}

	public WsERP_Gondola_SetImportResponse(RetornoWsModelOfBoolean WsERP_Gondola_SetImportResult)
	{
		this.WsERP_Gondola_SetImportResult = WsERP_Gondola_SetImportResult;
	}
}
