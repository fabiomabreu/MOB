using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_FormaPagamento_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_FormaPagamento_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_FormaPagamento_SetResult;

	public WsERP_FormaPagamento_SetResponse()
	{
	}

	public WsERP_FormaPagamento_SetResponse(RetornoWsModelOfBoolean WsERP_FormaPagamento_SetResult)
	{
		this.WsERP_FormaPagamento_SetResult = WsERP_FormaPagamento_SetResult;
	}
}
