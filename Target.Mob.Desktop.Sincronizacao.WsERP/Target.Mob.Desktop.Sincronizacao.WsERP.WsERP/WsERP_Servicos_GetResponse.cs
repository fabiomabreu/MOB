using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Servicos_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Servicos_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfServicoWsModel WsERP_Servicos_GetResult;

	public WsERP_Servicos_GetResponse()
	{
	}

	public WsERP_Servicos_GetResponse(RetornoWsModelOfListOfServicoWsModel WsERP_Servicos_GetResult)
	{
		this.WsERP_Servicos_GetResult = WsERP_Servicos_GetResult;
	}
}
