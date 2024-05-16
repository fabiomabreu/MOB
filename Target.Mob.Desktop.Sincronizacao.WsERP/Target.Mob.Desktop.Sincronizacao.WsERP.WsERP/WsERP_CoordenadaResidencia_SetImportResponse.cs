using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaResidencia_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaResidencia_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_CoordenadaResidencia_SetImportResult;

	public WsERP_CoordenadaResidencia_SetImportResponse()
	{
	}

	public WsERP_CoordenadaResidencia_SetImportResponse(RetornoWsModelOfBoolean WsERP_CoordenadaResidencia_SetImportResult)
	{
		this.WsERP_CoordenadaResidencia_SetImportResult = WsERP_CoordenadaResidencia_SetImportResult;
	}
}
