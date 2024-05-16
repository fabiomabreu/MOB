using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Equipe_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Equipe_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public string hostName;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public EquipeWsModel[] listaItens;

	public WsERP_Equipe_SetRequest()
	{
	}

	public WsERP_Equipe_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, EquipeWsModel[] listaItens)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.hostName = hostName;
		this.listaItens = listaItens;
	}
}
