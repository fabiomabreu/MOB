using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	[XmlElement(DataType = "base64Binary")]
	public byte[] rowId;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public string hostName;

	public WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest()
	{
	}

	public WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, byte[] rowId, string hostName)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.rowId = rowId;
		this.hostName = hostName;
	}
}
