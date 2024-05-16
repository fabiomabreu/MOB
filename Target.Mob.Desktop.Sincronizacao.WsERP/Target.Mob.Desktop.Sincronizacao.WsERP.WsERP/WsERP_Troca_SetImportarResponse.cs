using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Troca_SetImportarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Troca_SetImportarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Troca_SetImportarResult;

	public WsERP_Troca_SetImportarResponse()
	{
	}

	public WsERP_Troca_SetImportarResponse(RetornoWsModelOfBoolean WsERP_Troca_SetImportarResult)
	{
		this.WsERP_Troca_SetImportarResult = WsERP_Troca_SetImportarResult;
	}
}
