using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Notificacao_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Notificacao_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public NotificacaoWsModel[] notificacoes;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_Notificacao_SetRequest()
	{
	}

	public WsERP_Notificacao_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, NotificacaoWsModel[] notificacoes, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.notificacoes = notificacoes;
		this.hostName = hostName;
	}
}
