using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Config_Vendedor_GetV3", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Config_Vendedor_GetV3Request
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public string hostname;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	[XmlElement(DataType = "base64Binary")]
	public byte[] rowId;

	public WsERP_Config_Vendedor_GetV3Request()
	{
	}

	public WsERP_Config_Vendedor_GetV3Request(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname, byte[] rowId)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.hostname = hostname;
		this.rowId = rowId;
	}
}
