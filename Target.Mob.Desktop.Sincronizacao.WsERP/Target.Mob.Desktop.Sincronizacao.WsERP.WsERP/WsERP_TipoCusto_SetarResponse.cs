using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TipoCusto_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TipoCusto_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TipoCusto_SetarResult;

	public WsERP_TipoCusto_SetarResponse()
	{
	}

	public WsERP_TipoCusto_SetarResponse(RetornoWsModelOfBoolean WsERP_TipoCusto_SetarResult)
	{
		this.WsERP_TipoCusto_SetarResult = WsERP_TipoCusto_SetarResult;
	}
}
