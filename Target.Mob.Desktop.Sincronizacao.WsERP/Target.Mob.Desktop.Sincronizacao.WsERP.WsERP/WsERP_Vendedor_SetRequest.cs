using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Vendedor_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Vendedor_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public VendedorWsModel[] vendedores;

	public WsERP_Vendedor_SetRequest()
	{
	}

	public WsERP_Vendedor_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, VendedorWsModel[] vendedores)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.vendedores = vendedores;
	}
}
