using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Cliente_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Cliente_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfClienteWsModel WsERP_Cliente_GetResult;

	public WsERP_Cliente_GetResponse()
	{
	}

	public WsERP_Cliente_GetResponse(RetornoWsModelOfClienteWsModel WsERP_Cliente_GetResult)
	{
		this.WsERP_Cliente_GetResult = WsERP_Cliente_GetResult;
	}
}
