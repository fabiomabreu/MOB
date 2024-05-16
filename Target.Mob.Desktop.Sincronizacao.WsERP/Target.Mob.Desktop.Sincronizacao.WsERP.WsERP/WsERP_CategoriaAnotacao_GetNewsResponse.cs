using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CategoriaAnotacao_GetNewsResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CategoriaAnotacao_GetNewsResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_CategoriaAnotacao_GetNewsResult;

	public WsERP_CategoriaAnotacao_GetNewsResponse()
	{
	}

	public WsERP_CategoriaAnotacao_GetNewsResponse(RetornoWsModelOfListOfInt32 WsERP_CategoriaAnotacao_GetNewsResult)
	{
		this.WsERP_CategoriaAnotacao_GetNewsResult = WsERP_CategoriaAnotacao_GetNewsResult;
	}
}
