using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TipoGrupoSP_GetV2", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TipoGrupoSP_GetV2Request
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public string hostname;

	public WsERP_TipoGrupoSP_GetV2Request()
	{
	}

	public WsERP_TipoGrupoSP_GetV2Request(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.hostname = hostname;
	}
}
