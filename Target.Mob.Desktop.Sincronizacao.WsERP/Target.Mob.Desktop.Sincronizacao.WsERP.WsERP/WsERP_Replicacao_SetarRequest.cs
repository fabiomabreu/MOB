using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Replicacao_Setar", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Replicacao_SetarRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public string hostName;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string tabela;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 3)]
	public string versaoRetaguarda;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 4)]
	public string dadosReplicacao;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 5)]
	public int totalLinhas;

	public WsERP_Replicacao_SetarRequest()
	{
	}

	public WsERP_Replicacao_SetarRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, string tabela, string versaoRetaguarda, string dadosReplicacao, int totalLinhas)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.hostName = hostName;
		this.tabela = tabela;
		this.versaoRetaguarda = versaoRetaguarda;
		this.dadosReplicacao = dadosReplicacao;
		this.totalLinhas = totalLinhas;
	}
}
