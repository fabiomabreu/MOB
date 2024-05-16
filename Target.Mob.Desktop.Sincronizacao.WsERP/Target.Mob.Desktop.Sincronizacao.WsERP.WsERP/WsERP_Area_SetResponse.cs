using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Area_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Area_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Area_SetResult;

	public WsERP_Area_SetResponse()
	{
	}

	public WsERP_Area_SetResponse(RetornoWsModelOfBoolean WsERP_Area_SetResult)
	{
		this.WsERP_Area_SetResult = WsERP_Area_SetResult;
	}
}
