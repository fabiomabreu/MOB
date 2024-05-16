using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_VersaoRetaguarda_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_VersaoRetaguarda_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_VersaoRetaguarda_SetarResult;

	public WsERP_VersaoRetaguarda_SetarResponse()
	{
	}

	public WsERP_VersaoRetaguarda_SetarResponse(RetornoWsModelOfBoolean WsERP_VersaoRetaguarda_SetarResult)
	{
		this.WsERP_VersaoRetaguarda_SetarResult = WsERP_VersaoRetaguarda_SetarResult;
	}
}
