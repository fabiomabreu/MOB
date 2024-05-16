using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Replicacao_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Replicacao_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfString WsERP_Replicacao_GetResult;

	public WsERP_Replicacao_GetResponse()
	{
	}

	public WsERP_Replicacao_GetResponse(RetornoWsModelOfString WsERP_Replicacao_GetResult)
	{
		this.WsERP_Replicacao_GetResult = WsERP_Replicacao_GetResult;
	}
}
