using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_DistribuidoraEDI_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_DistribuidoraEDI_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_DistribuidoraEDI_SetResult;

	public WsERP_DistribuidoraEDI_SetResponse()
	{
	}

	public WsERP_DistribuidoraEDI_SetResponse(RetornoWsModelOfBoolean WsERP_DistribuidoraEDI_SetResult)
	{
		this.WsERP_DistribuidoraEDI_SetResult = WsERP_DistribuidoraEDI_SetResult;
	}
}
