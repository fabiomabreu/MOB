using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CategoriaProduto_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CategoriaProduto_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_CategoriaProduto_SetResult;

	public WsERP_CategoriaProduto_SetResponse()
	{
	}

	public WsERP_CategoriaProduto_SetResponse(RetornoWsModelOfBoolean WsERP_CategoriaProduto_SetResult)
	{
		this.WsERP_CategoriaProduto_SetResult = WsERP_CategoriaProduto_SetResult;
	}
}
