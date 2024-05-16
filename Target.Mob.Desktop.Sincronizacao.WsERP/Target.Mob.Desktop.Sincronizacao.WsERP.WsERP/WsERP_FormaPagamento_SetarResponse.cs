using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_FormaPagamento_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_FormaPagamento_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_FormaPagamento_SetarResult;

	public WsERP_FormaPagamento_SetarResponse()
	{
	}

	public WsERP_FormaPagamento_SetarResponse(RetornoWsModelOfBoolean WsERP_FormaPagamento_SetarResult)
	{
		this.WsERP_FormaPagamento_SetarResult = WsERP_FormaPagamento_SetarResult;
	}
}
