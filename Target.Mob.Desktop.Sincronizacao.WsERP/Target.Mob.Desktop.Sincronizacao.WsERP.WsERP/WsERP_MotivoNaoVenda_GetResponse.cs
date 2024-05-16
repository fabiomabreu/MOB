using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MotivoNaoVenda_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MotivoNaoVenda_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfMotivoNaoVendaWsModel WsERP_MotivoNaoVenda_GetResult;

	public WsERP_MotivoNaoVenda_GetResponse()
	{
	}

	public WsERP_MotivoNaoVenda_GetResponse(RetornoWsModelOfMotivoNaoVendaWsModel WsERP_MotivoNaoVenda_GetResult)
	{
		this.WsERP_MotivoNaoVenda_GetResult = WsERP_MotivoNaoVenda_GetResult;
	}
}
