using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_ProdutoErpSku_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_ProdutoErpSku_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_ProdutoErpSku_SetarResult;

	public WsERP_ProdutoErpSku_SetarResponse()
	{
	}

	public WsERP_ProdutoErpSku_SetarResponse(RetornoWsModelOfBoolean WsERP_ProdutoErpSku_SetarResult)
	{
		this.WsERP_ProdutoErpSku_SetarResult = WsERP_ProdutoErpSku_SetarResult;
	}
}
