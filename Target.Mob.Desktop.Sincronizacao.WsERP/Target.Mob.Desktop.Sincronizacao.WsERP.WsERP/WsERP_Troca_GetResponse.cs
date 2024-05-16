using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Troca_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Troca_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfTrocaWsModel WsERP_Troca_GetResult;

	public WsERP_Troca_GetResponse()
	{
	}

	public WsERP_Troca_GetResponse(RetornoWsModelOfTrocaWsModel WsERP_Troca_GetResult)
	{
		this.WsERP_Troca_GetResult = WsERP_Troca_GetResult;
	}
}
