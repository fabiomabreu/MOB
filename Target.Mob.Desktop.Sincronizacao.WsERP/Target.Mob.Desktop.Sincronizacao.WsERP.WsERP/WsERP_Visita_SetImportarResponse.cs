using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Visita_SetImportarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Visita_SetImportarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Visita_SetImportarResult;

	public WsERP_Visita_SetImportarResponse()
	{
	}

	public WsERP_Visita_SetImportarResponse(RetornoWsModelOfBoolean WsERP_Visita_SetImportarResult)
	{
		this.WsERP_Visita_SetImportarResult = WsERP_Visita_SetImportarResult;
	}
}
