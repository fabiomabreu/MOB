using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_ProdutoErp_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_ProdutoErp_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_ProdutoErp_SetResult;

	public WsERP_ProdutoErp_SetResponse()
	{
	}

	public WsERP_ProdutoErp_SetResponse(RetornoWsModelOfBoolean WsERP_ProdutoErp_SetResult)
	{
		this.WsERP_ProdutoErp_SetResult = WsERP_ProdutoErp_SetResult;
	}
}
