using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaRoteiroVendedorPermanencia_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaRoteiroVendedorPermanencia_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfCoordenadaRoteiroVendedorPermanenciaWsModel WsERP_CoordenadaRoteiroVendedorPermanencia_GetResult;

	public WsERP_CoordenadaRoteiroVendedorPermanencia_GetResponse()
	{
	}

	public WsERP_CoordenadaRoteiroVendedorPermanencia_GetResponse(RetornoWsModelOfCoordenadaRoteiroVendedorPermanenciaWsModel WsERP_CoordenadaRoteiroVendedorPermanencia_GetResult)
	{
		this.WsERP_CoordenadaRoteiroVendedorPermanencia_GetResult = WsERP_CoordenadaRoteiroVendedorPermanencia_GetResult;
	}
}
