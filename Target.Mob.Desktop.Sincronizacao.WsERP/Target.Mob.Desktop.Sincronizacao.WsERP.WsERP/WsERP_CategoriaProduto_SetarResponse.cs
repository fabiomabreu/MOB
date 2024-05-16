using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CategoriaProduto_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CategoriaProduto_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_CategoriaProduto_SetarResult;

	public WsERP_CategoriaProduto_SetarResponse()
	{
	}

	public WsERP_CategoriaProduto_SetarResponse(RetornoWsModelOfBoolean WsERP_CategoriaProduto_SetarResult)
	{
		this.WsERP_CategoriaProduto_SetarResult = WsERP_CategoriaProduto_SetarResult;
	}
}
