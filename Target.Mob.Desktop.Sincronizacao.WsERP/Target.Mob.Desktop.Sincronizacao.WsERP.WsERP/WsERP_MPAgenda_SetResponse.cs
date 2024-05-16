using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MPAgenda_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MPAgenda_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_MPAgenda_SetResult;

	public WsERP_MPAgenda_SetResponse()
	{
	}

	public WsERP_MPAgenda_SetResponse(RetornoWsModelOfBoolean WsERP_MPAgenda_SetResult)
	{
		this.WsERP_MPAgenda_SetResult = WsERP_MPAgenda_SetResult;
	}
}
