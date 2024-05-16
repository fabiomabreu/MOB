using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Config_Vendedor_GetV3Response", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Config_Vendedor_GetV3Response
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfConfiguracaoVendedorWsModel WsERP_Config_Vendedor_GetV3Result;

	public WsERP_Config_Vendedor_GetV3Response()
	{
	}

	public WsERP_Config_Vendedor_GetV3Response(RetornoWsModelOfListOfConfiguracaoVendedorWsModel WsERP_Config_Vendedor_GetV3Result)
	{
		this.WsERP_Config_Vendedor_GetV3Result = WsERP_Config_Vendedor_GetV3Result;
	}
}
