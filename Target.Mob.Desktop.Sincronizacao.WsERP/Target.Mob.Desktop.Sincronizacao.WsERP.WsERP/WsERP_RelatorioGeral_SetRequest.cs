using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_RelatorioGeral_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_RelatorioGeral_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public RelatorioGerencialWsModel relatorioGerencialWs;

	public WsERP_RelatorioGeral_SetRequest()
	{
	}

	public WsERP_RelatorioGeral_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, RelatorioGerencialWsModel relatorioGerencialWs)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.relatorioGerencialWs = relatorioGerencialWs;
	}
}
