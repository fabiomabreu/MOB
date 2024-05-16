using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaCliente_SetImport", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaCliente_SetImportRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public string hostName;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public int idCoordenadaCliente;

	public WsERP_CoordenadaCliente_SetImportRequest()
	{
	}

	public WsERP_CoordenadaCliente_SetImportRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, int idCoordenadaCliente)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.hostName = hostName;
		this.idCoordenadaCliente = idCoordenadaCliente;
	}
}
