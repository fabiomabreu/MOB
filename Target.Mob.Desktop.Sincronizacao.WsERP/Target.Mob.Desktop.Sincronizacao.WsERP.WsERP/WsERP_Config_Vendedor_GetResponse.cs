using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Config_Vendedor_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Config_Vendedor_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfConfiguracaoVendedorWsModel WsERP_Config_Vendedor_GetResult;

	public WsERP_Config_Vendedor_GetResponse()
	{
	}

	public WsERP_Config_Vendedor_GetResponse(RetornoWsModelOfListOfConfiguracaoVendedorWsModel WsERP_Config_Vendedor_GetResult)
	{
		this.WsERP_Config_Vendedor_GetResult = WsERP_Config_Vendedor_GetResult;
	}
}
