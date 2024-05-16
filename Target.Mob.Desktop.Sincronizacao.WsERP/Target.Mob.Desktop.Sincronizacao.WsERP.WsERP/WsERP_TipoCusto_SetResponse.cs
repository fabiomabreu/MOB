using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TipoCusto_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TipoCusto_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TipoCusto_SetResult;

	public WsERP_TipoCusto_SetResponse()
	{
	}

	public WsERP_TipoCusto_SetResponse(RetornoWsModelOfBoolean WsERP_TipoCusto_SetResult)
	{
		this.WsERP_TipoCusto_SetResult = WsERP_TipoCusto_SetResult;
	}
}
