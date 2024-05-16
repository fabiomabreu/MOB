using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_FormaPagamento_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_FormaPagamento_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public FormaPagamentoWsModel[] formasPagamento;

	public WsERP_FormaPagamento_SetRequest()
	{
	}

	public WsERP_FormaPagamento_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, FormaPagamentoWsModel[] formasPagamento)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.formasPagamento = formasPagamento;
	}
}
