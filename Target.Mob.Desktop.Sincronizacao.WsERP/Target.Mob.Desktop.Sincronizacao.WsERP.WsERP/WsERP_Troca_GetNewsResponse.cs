using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Troca_GetNewsResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Troca_GetNewsResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_Troca_GetNewsResult;

	public WsERP_Troca_GetNewsResponse()
	{
	}

	public WsERP_Troca_GetNewsResponse(RetornoWsModelOfListOfInt32 WsERP_Troca_GetNewsResult)
	{
		this.WsERP_Troca_GetNewsResult = WsERP_Troca_GetNewsResult;
	}
}
