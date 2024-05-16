using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Troca_GetV2", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Troca_GetV2Request
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public int codigoTroca;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostname;

	public WsERP_Troca_GetV2Request()
	{
	}

	public WsERP_Troca_GetV2Request(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoTroca, string hostname)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.codigoTroca = codigoTroca;
		this.hostname = hostname;
	}
}
