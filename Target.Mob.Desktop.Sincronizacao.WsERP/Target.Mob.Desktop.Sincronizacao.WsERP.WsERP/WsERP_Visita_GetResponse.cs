using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Visita_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Visita_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfVisitaWsModel WsERP_Visita_GetResult;

	public WsERP_Visita_GetResponse()
	{
	}

	public WsERP_Visita_GetResponse(RetornoWsModelOfVisitaWsModel WsERP_Visita_GetResult)
	{
		this.WsERP_Visita_GetResult = WsERP_Visita_GetResult;
	}
}
