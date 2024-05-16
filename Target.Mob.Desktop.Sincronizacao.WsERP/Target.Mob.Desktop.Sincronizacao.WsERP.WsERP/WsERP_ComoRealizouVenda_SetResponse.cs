using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_ComoRealizouVenda_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_ComoRealizouVenda_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_ComoRealizouVenda_SetResult;

	public WsERP_ComoRealizouVenda_SetResponse()
	{
	}

	public WsERP_ComoRealizouVenda_SetResponse(RetornoWsModelOfBoolean WsERP_ComoRealizouVenda_SetResult)
	{
		this.WsERP_ComoRealizouVenda_SetResult = WsERP_ComoRealizouVenda_SetResult;
	}
}
