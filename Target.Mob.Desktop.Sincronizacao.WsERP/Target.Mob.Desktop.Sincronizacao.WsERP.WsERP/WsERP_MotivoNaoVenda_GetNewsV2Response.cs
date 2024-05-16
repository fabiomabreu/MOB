using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MotivoNaoVenda_GetNewsV2Response", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MotivoNaoVenda_GetNewsV2Response
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_MotivoNaoVenda_GetNewsV2Result;

	public WsERP_MotivoNaoVenda_GetNewsV2Response()
	{
	}

	public WsERP_MotivoNaoVenda_GetNewsV2Response(RetornoWsModelOfListOfInt32 WsERP_MotivoNaoVenda_GetNewsV2Result)
	{
		this.WsERP_MotivoNaoVenda_GetNewsV2Result = WsERP_MotivoNaoVenda_GetNewsV2Result;
	}
}
