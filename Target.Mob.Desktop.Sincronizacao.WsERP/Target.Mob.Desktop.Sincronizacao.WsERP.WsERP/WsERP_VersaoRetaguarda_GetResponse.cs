using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_VersaoRetaguarda_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_VersaoRetaguarda_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfProdutoVersaoWsModel WsERP_VersaoRetaguarda_GetResult;

	public WsERP_VersaoRetaguarda_GetResponse()
	{
	}

	public WsERP_VersaoRetaguarda_GetResponse(RetornoWsModelOfProdutoVersaoWsModel WsERP_VersaoRetaguarda_GetResult)
	{
		this.WsERP_VersaoRetaguarda_GetResult = WsERP_VersaoRetaguarda_GetResult;
	}
}
