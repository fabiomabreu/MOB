using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_ProdutoErp_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_ProdutoErp_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_ProdutoErp_SetarResult;

	public WsERP_ProdutoErp_SetarResponse()
	{
	}

	public WsERP_ProdutoErp_SetarResponse(RetornoWsModelOfBoolean WsERP_ProdutoErp_SetarResult)
	{
		this.WsERP_ProdutoErp_SetarResult = WsERP_ProdutoErp_SetarResult;
	}
}
