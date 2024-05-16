using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_AcaVisitas_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_AcaVisitas_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_AcaVisitas_SetResult;

	public WsERP_AcaVisitas_SetResponse()
	{
	}

	public WsERP_AcaVisitas_SetResponse(RetornoWsModelOfBoolean WsERP_AcaVisitas_SetResult)
	{
		this.WsERP_AcaVisitas_SetResult = WsERP_AcaVisitas_SetResult;
	}
}
