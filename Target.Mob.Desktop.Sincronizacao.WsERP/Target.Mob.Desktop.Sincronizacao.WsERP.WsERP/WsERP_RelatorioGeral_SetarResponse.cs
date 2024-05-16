using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_RelatorioGeral_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_RelatorioGeral_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_RelatorioGeral_SetarResult;

	public WsERP_RelatorioGeral_SetarResponse()
	{
	}

	public WsERP_RelatorioGeral_SetarResponse(RetornoWsModelOfBoolean WsERP_RelatorioGeral_SetarResult)
	{
		this.WsERP_RelatorioGeral_SetarResult = WsERP_RelatorioGeral_SetarResult;
	}
}
