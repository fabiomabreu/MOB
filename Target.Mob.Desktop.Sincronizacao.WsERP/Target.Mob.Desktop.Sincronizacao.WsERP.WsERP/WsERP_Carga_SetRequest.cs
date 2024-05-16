using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Carga_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Carga_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public CargaWsModel cargaWs;

	public WsERP_Carga_SetRequest()
	{
	}

	public WsERP_Carga_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, CargaWsModel cargaWs)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.cargaWs = cargaWs;
	}
}
