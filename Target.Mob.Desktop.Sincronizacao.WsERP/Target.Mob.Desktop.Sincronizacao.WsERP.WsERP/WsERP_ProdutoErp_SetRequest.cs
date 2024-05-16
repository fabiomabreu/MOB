using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_ProdutoErp_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_ProdutoErp_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public ProdutoErpWsModel[] produtos;

	public WsERP_ProdutoErp_SetRequest()
	{
	}

	public WsERP_ProdutoErp_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, ProdutoErpWsModel[] produtos)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.produtos = produtos;
	}
}
