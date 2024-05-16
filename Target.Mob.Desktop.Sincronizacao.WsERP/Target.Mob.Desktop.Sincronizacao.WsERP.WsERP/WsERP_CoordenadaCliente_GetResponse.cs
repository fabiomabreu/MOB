using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaCliente_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaCliente_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfCoordenadaClienteWsModel WsERP_CoordenadaCliente_GetResult;

	public WsERP_CoordenadaCliente_GetResponse()
	{
	}

	public WsERP_CoordenadaCliente_GetResponse(RetornoWsModelOfListOfCoordenadaClienteWsModel WsERP_CoordenadaCliente_GetResult)
	{
		this.WsERP_CoordenadaCliente_GetResult = WsERP_CoordenadaCliente_GetResult;
	}
}
