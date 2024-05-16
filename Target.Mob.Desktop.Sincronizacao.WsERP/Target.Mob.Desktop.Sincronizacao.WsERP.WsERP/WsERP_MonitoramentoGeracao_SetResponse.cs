using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MonitoramentoGeracao_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MonitoramentoGeracao_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_MonitoramentoGeracao_SetResult;

	public WsERP_MonitoramentoGeracao_SetResponse()
	{
	}

	public WsERP_MonitoramentoGeracao_SetResponse(RetornoWsModelOfBoolean WsERP_MonitoramentoGeracao_SetResult)
	{
		this.WsERP_MonitoramentoGeracao_SetResult = WsERP_MonitoramentoGeracao_SetResult;
	}
}
