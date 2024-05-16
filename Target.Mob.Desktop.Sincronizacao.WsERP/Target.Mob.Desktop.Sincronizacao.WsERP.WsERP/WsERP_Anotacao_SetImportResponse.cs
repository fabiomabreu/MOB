using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Anotacao_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Anotacao_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Anotacao_SetImportResult;

	public WsERP_Anotacao_SetImportResponse()
	{
	}

	public WsERP_Anotacao_SetImportResponse(RetornoWsModelOfBoolean WsERP_Anotacao_SetImportResult)
	{
		this.WsERP_Anotacao_SetImportResult = WsERP_Anotacao_SetImportResult;
	}
}
