using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_VersaoRetaguardaPedEle_GetPermissaoResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_VersaoRetaguardaPedEle_GetPermissaoResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_VersaoRetaguardaPedEle_GetPermissaoResult;

	public WsERP_VersaoRetaguardaPedEle_GetPermissaoResponse()
	{
	}

	public WsERP_VersaoRetaguardaPedEle_GetPermissaoResponse(RetornoWsModelOfBoolean WsERP_VersaoRetaguardaPedEle_GetPermissaoResult)
	{
		this.WsERP_VersaoRetaguardaPedEle_GetPermissaoResult = WsERP_VersaoRetaguardaPedEle_GetPermissaoResult;
	}
}
