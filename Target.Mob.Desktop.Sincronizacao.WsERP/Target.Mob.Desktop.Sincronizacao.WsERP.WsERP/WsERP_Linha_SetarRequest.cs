using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Linha_Setar", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Linha_SetarRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public LinhaWsModel[] linhas;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_Linha_SetarRequest()
	{
	}

	public WsERP_Linha_SetarRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, LinhaWsModel[] linhas, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.linhas = linhas;
		this.hostName = hostName;
	}
}
