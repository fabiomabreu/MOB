using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Forca_Carga_CompletaResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Forca_Carga_CompletaResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfVendedorWsModel WsERP_Forca_Carga_CompletaResult;

	public WsERP_Forca_Carga_CompletaResponse()
	{
	}

	public WsERP_Forca_Carga_CompletaResponse(RetornoWsModelOfListOfVendedorWsModel WsERP_Forca_Carga_CompletaResult)
	{
		this.WsERP_Forca_Carga_CompletaResult = WsERP_Forca_Carga_CompletaResult;
	}
}
