using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Vendedor_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Vendedor_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Vendedor_SetResult;

	public WsERP_Vendedor_SetResponse()
	{
	}

	public WsERP_Vendedor_SetResponse(RetornoWsModelOfBoolean WsERP_Vendedor_SetResult)
	{
		this.WsERP_Vendedor_SetResult = WsERP_Vendedor_SetResult;
	}
}
