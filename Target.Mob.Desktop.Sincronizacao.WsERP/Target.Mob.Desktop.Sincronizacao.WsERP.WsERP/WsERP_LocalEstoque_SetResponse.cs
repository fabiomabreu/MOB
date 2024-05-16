using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_LocalEstoque_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_LocalEstoque_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_LocalEstoque_SetResult;

	public WsERP_LocalEstoque_SetResponse()
	{
	}

	public WsERP_LocalEstoque_SetResponse(RetornoWsModelOfBoolean WsERP_LocalEstoque_SetResult)
	{
		this.WsERP_LocalEstoque_SetResult = WsERP_LocalEstoque_SetResult;
	}
}
