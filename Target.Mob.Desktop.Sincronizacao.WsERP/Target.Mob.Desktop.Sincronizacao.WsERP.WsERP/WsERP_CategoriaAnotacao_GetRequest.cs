using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CategoriaAnotacao_Get", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CategoriaAnotacao_GetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public int IdCategoriaAnotacao;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_CategoriaAnotacao_GetRequest()
	{
	}

	public WsERP_CategoriaAnotacao_GetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdCategoriaAnotacao, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.IdCategoriaAnotacao = IdCategoriaAnotacao;
		this.hostName = hostName;
	}
}
