using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_RamAtiv_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_RamAtiv_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_RamAtiv_SetResult;

	public WsERP_RamAtiv_SetResponse()
	{
	}

	public WsERP_RamAtiv_SetResponse(RetornoWsModelOfBoolean WsERP_RamAtiv_SetResult)
	{
		this.WsERP_RamAtiv_SetResult = WsERP_RamAtiv_SetResult;
	}
}
