using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Cliente_GetNews", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Cliente_GetNewsRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	public WsERP_Cliente_GetNewsRequest()
	{
	}

	public WsERP_Cliente_GetNewsRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
	}
}
