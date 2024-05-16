using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MPAgenda_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MPAgenda_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public MPAgendaWsModel[] listaItens;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_MPAgenda_SetRequest()
	{
	}

	public WsERP_MPAgenda_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, MPAgendaWsModel[] listaItens, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.listaItens = listaItens;
		this.hostName = hostName;
	}
}
