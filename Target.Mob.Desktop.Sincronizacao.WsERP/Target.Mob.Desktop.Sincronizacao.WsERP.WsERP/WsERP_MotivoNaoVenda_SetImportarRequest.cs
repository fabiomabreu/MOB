using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MotivoNaoVenda_SetImportar", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MotivoNaoVenda_SetImportarRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public int codigoMotivoNaoVenda;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_MotivoNaoVenda_SetImportarRequest()
	{
	}

	public WsERP_MotivoNaoVenda_SetImportarRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoMotivoNaoVenda, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.codigoMotivoNaoVenda = codigoMotivoNaoVenda;
		this.hostName = hostName;
	}
}
