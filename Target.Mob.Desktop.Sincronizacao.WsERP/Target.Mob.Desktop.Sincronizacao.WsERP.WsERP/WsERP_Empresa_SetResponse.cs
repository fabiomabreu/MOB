using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Empresa_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Empresa_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_Empresa_SetResult;

	public WsERP_Empresa_SetResponse()
	{
	}

	public WsERP_Empresa_SetResponse(RetornoWsModelOfBoolean WsERP_Empresa_SetResult)
	{
		this.WsERP_Empresa_SetResult = WsERP_Empresa_SetResult;
	}
}
