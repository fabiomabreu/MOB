using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Linha_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Linha_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Linha_SetResult;

	public WsERP_Linha_SetResponse()
	{
	}

	public WsERP_Linha_SetResponse(RetornoWsModelOfBoolean WsERP_Linha_SetResult)
	{
		this.WsERP_Linha_SetResult = WsERP_Linha_SetResult;
	}
}
