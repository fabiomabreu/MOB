using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MonitoramentoRetaguarda_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MonitoramentoRetaguarda_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_MonitoramentoRetaguarda_SetResult;

	public WsERP_MonitoramentoRetaguarda_SetResponse()
	{
	}

	public WsERP_MonitoramentoRetaguarda_SetResponse(RetornoWsModelOfBoolean WsERP_MonitoramentoRetaguarda_SetResult)
	{
		this.WsERP_MonitoramentoRetaguarda_SetResult = WsERP_MonitoramentoRetaguarda_SetResult;
	}
}
