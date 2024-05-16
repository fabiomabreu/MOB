using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Cliente_SetImportarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Cliente_SetImportarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Cliente_SetImportarResult;

	public WsERP_Cliente_SetImportarResponse()
	{
	}

	public WsERP_Cliente_SetImportarResponse(RetornoWsModelOfBoolean WsERP_Cliente_SetImportarResult)
	{
		this.WsERP_Cliente_SetImportarResult = WsERP_Cliente_SetImportarResult;
	}
}
