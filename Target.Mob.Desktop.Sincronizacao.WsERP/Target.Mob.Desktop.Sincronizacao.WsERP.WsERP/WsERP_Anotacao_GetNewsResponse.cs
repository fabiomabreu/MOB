using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Anotacao_GetNewsResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Anotacao_GetNewsResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_Anotacao_GetNewsResult;

	public WsERP_Anotacao_GetNewsResponse()
	{
	}

	public WsERP_Anotacao_GetNewsResponse(RetornoWsModelOfListOfInt32 WsERP_Anotacao_GetNewsResult)
	{
		this.WsERP_Anotacao_GetNewsResult = WsERP_Anotacao_GetNewsResult;
	}
}
