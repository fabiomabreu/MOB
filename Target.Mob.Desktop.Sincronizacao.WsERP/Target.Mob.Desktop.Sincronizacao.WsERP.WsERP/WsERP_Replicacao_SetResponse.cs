using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Replicacao_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Replicacao_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Replicacao_SetResult;

	public WsERP_Replicacao_SetResponse()
	{
	}

	public WsERP_Replicacao_SetResponse(RetornoWsModelOfBoolean WsERP_Replicacao_SetResult)
	{
		this.WsERP_Replicacao_SetResult = WsERP_Replicacao_SetResult;
	}
}
