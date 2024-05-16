using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Promotor_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Promotor_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Promotor_SetResult;

	public WsERP_Promotor_SetResponse()
	{
	}

	public WsERP_Promotor_SetResponse(RetornoWsModelOfBoolean WsERP_Promotor_SetResult)
	{
		this.WsERP_Promotor_SetResult = WsERP_Promotor_SetResult;
	}
}
