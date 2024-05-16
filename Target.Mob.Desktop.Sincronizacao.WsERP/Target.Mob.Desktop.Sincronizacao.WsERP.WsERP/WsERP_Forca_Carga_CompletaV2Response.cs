using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Forca_Carga_CompletaV2Response", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Forca_Carga_CompletaV2Response
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfVendedorWsModel WsERP_Forca_Carga_CompletaV2Result;

	public WsERP_Forca_Carga_CompletaV2Response()
	{
	}

	public WsERP_Forca_Carga_CompletaV2Response(RetornoWsModelOfListOfVendedorWsModel WsERP_Forca_Carga_CompletaV2Result)
	{
		this.WsERP_Forca_Carga_CompletaV2Result = WsERP_Forca_Carga_CompletaV2Result;
	}
}
