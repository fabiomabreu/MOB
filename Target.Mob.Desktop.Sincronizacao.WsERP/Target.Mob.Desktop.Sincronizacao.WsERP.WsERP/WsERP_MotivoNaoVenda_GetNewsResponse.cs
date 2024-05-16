using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MotivoNaoVenda_GetNewsResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MotivoNaoVenda_GetNewsResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_MotivoNaoVenda_GetNewsResult;

	public WsERP_MotivoNaoVenda_GetNewsResponse()
	{
	}

	public WsERP_MotivoNaoVenda_GetNewsResponse(RetornoWsModelOfListOfInt32 WsERP_MotivoNaoVenda_GetNewsResult)
	{
		this.WsERP_MotivoNaoVenda_GetNewsResult = WsERP_MotivoNaoVenda_GetNewsResult;
	}
}
