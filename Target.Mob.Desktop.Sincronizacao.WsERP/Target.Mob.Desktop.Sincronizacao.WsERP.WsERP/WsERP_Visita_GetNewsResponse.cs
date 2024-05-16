using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Visita_GetNewsResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Visita_GetNewsResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_Visita_GetNewsResult;

	public WsERP_Visita_GetNewsResponse()
	{
	}

	public WsERP_Visita_GetNewsResponse(RetornoWsModelOfListOfInt32 WsERP_Visita_GetNewsResult)
	{
		this.WsERP_Visita_GetNewsResult = WsERP_Visita_GetNewsResult;
	}
}
