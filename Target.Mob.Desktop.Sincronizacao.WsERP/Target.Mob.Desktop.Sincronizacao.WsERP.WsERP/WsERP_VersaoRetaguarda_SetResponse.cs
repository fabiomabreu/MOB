using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_VersaoRetaguarda_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_VersaoRetaguarda_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_VersaoRetaguarda_SetResult;

	public WsERP_VersaoRetaguarda_SetResponse()
	{
	}

	public WsERP_VersaoRetaguarda_SetResponse(RetornoWsModelOfBoolean WsERP_VersaoRetaguarda_SetResult)
	{
		this.WsERP_VersaoRetaguarda_SetResult = WsERP_VersaoRetaguarda_SetResult;
	}
}
