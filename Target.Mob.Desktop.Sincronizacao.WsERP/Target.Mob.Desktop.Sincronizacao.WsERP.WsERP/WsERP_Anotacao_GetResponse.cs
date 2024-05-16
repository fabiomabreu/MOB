using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Anotacao_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Anotacao_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfAnotacaoWsModel WsERP_Anotacao_GetResult;

	public WsERP_Anotacao_GetResponse()
	{
	}

	public WsERP_Anotacao_GetResponse(RetornoWsModelOfAnotacaoWsModel WsERP_Anotacao_GetResult)
	{
		this.WsERP_Anotacao_GetResult = WsERP_Anotacao_GetResult;
	}
}
