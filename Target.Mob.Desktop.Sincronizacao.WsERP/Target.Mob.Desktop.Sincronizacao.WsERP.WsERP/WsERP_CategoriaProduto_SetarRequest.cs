using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CategoriaProduto_Setar", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CategoriaProduto_SetarRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public CategoriaProdutoWsModel[] categorias;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_CategoriaProduto_SetarRequest()
	{
	}

	public WsERP_CategoriaProduto_SetarRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, CategoriaProdutoWsModel[] categorias, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.categorias = categorias;
		this.hostName = hostName;
	}
}
