using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Equipe_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Equipe_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Equipe_SetResult;

	public WsERP_Equipe_SetResponse()
	{
	}

	public WsERP_Equipe_SetResponse(RetornoWsModelOfBoolean WsERP_Equipe_SetResult)
	{
		this.WsERP_Equipe_SetResult = WsERP_Equipe_SetResult;
	}
}
