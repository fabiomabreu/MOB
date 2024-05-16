using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_PedidoAtendimento_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_PedidoAtendimento_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public PedVdaAtendimentoWsModel pedido;

	public WsERP_PedidoAtendimento_SetRequest()
	{
	}

	public WsERP_PedidoAtendimento_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, PedVdaAtendimentoWsModel pedido)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.pedido = pedido;
	}
}
