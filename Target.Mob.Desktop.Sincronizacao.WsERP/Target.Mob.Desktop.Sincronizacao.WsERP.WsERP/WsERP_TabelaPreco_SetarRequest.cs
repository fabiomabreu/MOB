using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TabelaPreco_Setar", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TabelaPreco_SetarRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public TabelaPrecoWsModel[] tabelas;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_TabelaPreco_SetarRequest()
	{
	}

	public WsERP_TabelaPreco_SetarRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, TabelaPrecoWsModel[] tabelas, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.tabelas = tabelas;
		this.hostName = hostName;
	}
}
