using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Fabricante_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Fabricante_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Fabricante_SetarResult;

	public WsERP_Fabricante_SetarResponse()
	{
	}

	public WsERP_Fabricante_SetarResponse(RetornoWsModelOfBoolean WsERP_Fabricante_SetarResult)
	{
		this.WsERP_Fabricante_SetarResult = WsERP_Fabricante_SetarResult;
	}
}
