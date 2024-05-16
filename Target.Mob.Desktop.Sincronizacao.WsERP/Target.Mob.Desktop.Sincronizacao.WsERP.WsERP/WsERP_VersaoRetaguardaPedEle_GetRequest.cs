using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_VersaoRetaguardaPedEle_Get", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_VersaoRetaguardaPedEle_GetRequest
{
	[MessageHeader(Namespace = "Target.WsERP")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public string cnpj;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 1)]
	public int major;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 2)]
	public int minor;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 3)]
	public int build;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 4)]
	public int revision;

	[MessageBodyMember(Namespace = "Target.WsERP", Order = 5)]
	public bool comArquivo;

	public WsERP_VersaoRetaguardaPedEle_GetRequest()
	{
	}

	public WsERP_VersaoRetaguardaPedEle_GetRequest(ValidationSoapHeader ValidationSoapHeader, string cnpj, int major, int minor, int build, int revision, bool comArquivo)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.cnpj = cnpj;
		this.major = major;
		this.minor = minor;
		this.build = build;
		this.revision = revision;
		this.comArquivo = comArquivo;
	}
}
