using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaResidencia_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaResidencia_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfCoordenadaResidenciaWsModel WsERP_CoordenadaResidencia_GetResult;

	public WsERP_CoordenadaResidencia_GetResponse()
	{
	}

	public WsERP_CoordenadaResidencia_GetResponse(RetornoWsModelOfCoordenadaResidenciaWsModel WsERP_CoordenadaResidencia_GetResult)
	{
		this.WsERP_CoordenadaResidencia_GetResult = WsERP_CoordenadaResidencia_GetResult;
	}
}
