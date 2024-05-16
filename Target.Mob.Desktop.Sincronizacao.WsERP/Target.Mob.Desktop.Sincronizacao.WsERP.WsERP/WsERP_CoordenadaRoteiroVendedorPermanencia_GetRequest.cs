using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaRoteiroVendedorPermanencia_Get", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public int IdCoordenadaRoteiroVendedorPermanencia;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest()
	{
	}

	public WsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdCoordenadaRoteiroVendedorPermanencia, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.IdCoordenadaRoteiroVendedorPermanencia = IdCoordenadaRoteiroVendedorPermanencia;
		this.hostName = hostName;
	}
}
