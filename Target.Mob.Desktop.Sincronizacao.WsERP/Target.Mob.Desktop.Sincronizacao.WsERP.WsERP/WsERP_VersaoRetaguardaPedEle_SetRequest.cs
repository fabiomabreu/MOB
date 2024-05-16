using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_VersaoRetaguardaPedEle_Set", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_VersaoRetaguardaPedEle_SetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	[XmlElement(IsNullable = true)]
	public int? major;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	[XmlElement(IsNullable = true)]
	public int? minor;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 3)]
	[XmlElement(IsNullable = true)]
	public int? build;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 4)]
	[XmlElement(IsNullable = true)]
	public int? revision;

	public WsERP_VersaoRetaguardaPedEle_SetRequest()
	{
	}

	public WsERP_VersaoRetaguardaPedEle_SetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, int? major, int? minor, int? build, int? revision)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.major = major;
		this.minor = minor;
		this.build = build;
		this.revision = revision;
	}
}
