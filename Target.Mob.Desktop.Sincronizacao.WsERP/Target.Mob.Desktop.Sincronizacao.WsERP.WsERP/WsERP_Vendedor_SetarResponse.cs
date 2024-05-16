using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Vendedor_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Vendedor_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Vendedor_SetarResult;

	public WsERP_Vendedor_SetarResponse()
	{
	}

	public WsERP_Vendedor_SetarResponse(RetornoWsModelOfBoolean WsERP_Vendedor_SetarResult)
	{
		this.WsERP_Vendedor_SetarResult = WsERP_Vendedor_SetarResult;
	}
}
