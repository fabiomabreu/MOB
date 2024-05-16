using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MonitGerarDados_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MonitGerarDados_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_MonitGerarDados_SetResult;

	public WsERP_MonitGerarDados_SetResponse()
	{
	}

	public WsERP_MonitGerarDados_SetResponse(RetornoWsModelOfBoolean WsERP_MonitGerarDados_SetResult)
	{
		this.WsERP_MonitGerarDados_SetResult = WsERP_MonitGerarDados_SetResult;
	}
}
