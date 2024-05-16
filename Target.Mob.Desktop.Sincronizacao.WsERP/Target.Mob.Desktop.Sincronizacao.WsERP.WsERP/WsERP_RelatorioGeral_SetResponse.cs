using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_RelatorioGeral_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_RelatorioGeral_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_RelatorioGeral_SetResult;

	public WsERP_RelatorioGeral_SetResponse()
	{
	}

	public WsERP_RelatorioGeral_SetResponse(RetornoWsModelOfBoolean WsERP_RelatorioGeral_SetResult)
	{
		this.WsERP_RelatorioGeral_SetResult = WsERP_RelatorioGeral_SetResult;
	}
}
