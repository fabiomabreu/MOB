using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Linha_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Linha_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public LinhaWsModel[] linhas;

	public WsERP_Linha_SetRequest()
	{
	}

	public WsERP_Linha_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, LinhaWsModel[] linhas)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.linhas = linhas;
	}
}
