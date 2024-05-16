using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_LogErro_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_LogErro_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_LogErro_SetResult;

	public WsERP_LogErro_SetResponse()
	{
	}

	public WsERP_LogErro_SetResponse(RetornoWsModelOfBoolean WsERP_LogErro_SetResult)
	{
		this.WsERP_LogErro_SetResult = WsERP_LogErro_SetResult;
	}
}
