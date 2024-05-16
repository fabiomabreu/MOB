using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Anotacao_SetImport", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Anotacao_SetImportRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public int IdAnotacao;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_Anotacao_SetImportRequest()
	{
	}

	public WsERP_Anotacao_SetImportRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdAnotacao, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.IdAnotacao = IdAnotacao;
		this.hostName = hostName;
	}
}
