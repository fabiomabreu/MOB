using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Notificacao_Get", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Notificacao_GetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public string hostName;

	public WsERP_Notificacao_GetRequest()
	{
	}

	public WsERP_Notificacao_GetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.hostName = hostName;
	}
}
