using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_ClienteERP_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_ClienteERP_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_ClienteERP_SetResult;

	public WsERP_ClienteERP_SetResponse()
	{
	}

	public WsERP_ClienteERP_SetResponse(RetornoWsModelOfBoolean WsERP_ClienteERP_SetResult)
	{
		this.WsERP_ClienteERP_SetResult = WsERP_ClienteERP_SetResult;
	}
}
