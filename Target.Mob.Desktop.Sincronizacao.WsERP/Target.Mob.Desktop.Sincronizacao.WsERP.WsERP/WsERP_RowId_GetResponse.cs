using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_RowId_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_RowId_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	[XmlElement(DataType = "base64Binary")]
	public byte[] WsERP_RowId_GetResult;

	public WsERP_RowId_GetResponse()
	{
	}

	public WsERP_RowId_GetResponse(byte[] WsERP_RowId_GetResult)
	{
		this.WsERP_RowId_GetResult = WsERP_RowId_GetResult;
	}
}
