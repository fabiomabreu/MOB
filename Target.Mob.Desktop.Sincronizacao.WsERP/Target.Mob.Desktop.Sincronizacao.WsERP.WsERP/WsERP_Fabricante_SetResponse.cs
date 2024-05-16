using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Fabricante_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Fabricante_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Fabricante_SetResult;

	public WsERP_Fabricante_SetResponse()
	{
	}

	public WsERP_Fabricante_SetResponse(RetornoWsModelOfBoolean WsERP_Fabricante_SetResult)
	{
		this.WsERP_Fabricante_SetResult = WsERP_Fabricante_SetResult;
	}
}
