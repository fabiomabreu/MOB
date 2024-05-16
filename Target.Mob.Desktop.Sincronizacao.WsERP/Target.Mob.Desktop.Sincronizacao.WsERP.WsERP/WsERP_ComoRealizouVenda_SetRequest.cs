using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_ComoRealizouVenda_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_ComoRealizouVenda_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public ComoRealizouVendaWsModel[] comoRealizouVendas;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_ComoRealizouVenda_SetRequest()
	{
	}

	public WsERP_ComoRealizouVenda_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, ComoRealizouVendaWsModel[] comoRealizouVendas, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.comoRealizouVendas = comoRealizouVendas;
		this.hostName = hostName;
	}
}
