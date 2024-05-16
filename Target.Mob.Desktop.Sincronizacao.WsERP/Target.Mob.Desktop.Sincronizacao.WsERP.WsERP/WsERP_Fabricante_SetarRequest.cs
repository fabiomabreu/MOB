using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Fabricante_Setar", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Fabricante_SetarRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public FabricanteWsModel[] fabricantes;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_Fabricante_SetarRequest()
	{
	}

	public WsERP_Fabricante_SetarRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, FabricanteWsModel[] fabricantes, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.fabricantes = fabricantes;
		this.hostName = hostName;
	}
}
