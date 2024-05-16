using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_LocalEstoque_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_LocalEstoque_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_LocalEstoque_SetarResult;

	public WsERP_LocalEstoque_SetarResponse()
	{
	}

	public WsERP_LocalEstoque_SetarResponse(RetornoWsModelOfBoolean WsERP_LocalEstoque_SetarResult)
	{
		this.WsERP_LocalEstoque_SetarResult = WsERP_LocalEstoque_SetarResult;
	}
}
