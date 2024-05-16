using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Pagamento_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Pagamento_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfPagamentoWsModel WsERP_Pagamento_GetResult;

	public WsERP_Pagamento_GetResponse()
	{
	}

	public WsERP_Pagamento_GetResponse(RetornoWsModelOfListOfPagamentoWsModel WsERP_Pagamento_GetResult)
	{
		this.WsERP_Pagamento_GetResult = WsERP_Pagamento_GetResult;
	}
}
