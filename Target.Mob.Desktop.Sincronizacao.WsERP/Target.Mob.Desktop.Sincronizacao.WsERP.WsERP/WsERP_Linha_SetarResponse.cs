using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Linha_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Linha_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Linha_SetarResult;

	public WsERP_Linha_SetarResponse()
	{
	}

	public WsERP_Linha_SetarResponse(RetornoWsModelOfBoolean WsERP_Linha_SetarResult)
	{
		this.WsERP_Linha_SetarResult = WsERP_Linha_SetarResult;
	}
}
