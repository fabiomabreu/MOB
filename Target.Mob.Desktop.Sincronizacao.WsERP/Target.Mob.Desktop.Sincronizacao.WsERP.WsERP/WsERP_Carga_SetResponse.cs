using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Carga_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Carga_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Carga_SetResult;

	public WsERP_Carga_SetResponse()
	{
	}

	public WsERP_Carga_SetResponse(RetornoWsModelOfBoolean WsERP_Carga_SetResult)
	{
		this.WsERP_Carga_SetResult = WsERP_Carga_SetResult;
	}
}
