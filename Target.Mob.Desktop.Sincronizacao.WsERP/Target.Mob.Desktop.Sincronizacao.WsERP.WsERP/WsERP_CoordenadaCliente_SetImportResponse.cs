using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaCliente_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaCliente_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_CoordenadaCliente_SetImportResult;

	public WsERP_CoordenadaCliente_SetImportResponse()
	{
	}

	public WsERP_CoordenadaCliente_SetImportResponse(RetornoWsModelOfBoolean WsERP_CoordenadaCliente_SetImportResult)
	{
		this.WsERP_CoordenadaCliente_SetImportResult = WsERP_CoordenadaCliente_SetImportResult;
	}
}
