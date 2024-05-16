using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_LogErro_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_LogErro_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public LogErroWsModel logErroWs;

	public WsERP_LogErro_SetRequest()
	{
	}

	public WsERP_LogErro_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, LogErroWsModel logErroWs)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.logErroWs = logErroWs;
	}
}
