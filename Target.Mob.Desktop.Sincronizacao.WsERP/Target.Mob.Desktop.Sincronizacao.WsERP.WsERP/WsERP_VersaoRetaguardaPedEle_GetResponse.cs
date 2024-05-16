using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_VersaoRetaguardaPedEle_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_VersaoRetaguardaPedEle_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfProdutoVersaoWsModel WsERP_VersaoRetaguardaPedEle_GetResult;

	public WsERP_VersaoRetaguardaPedEle_GetResponse()
	{
	}

	public WsERP_VersaoRetaguardaPedEle_GetResponse(RetornoWsModelOfProdutoVersaoWsModel WsERP_VersaoRetaguardaPedEle_GetResult)
	{
		this.WsERP_VersaoRetaguardaPedEle_GetResult = WsERP_VersaoRetaguardaPedEle_GetResult;
	}
}
