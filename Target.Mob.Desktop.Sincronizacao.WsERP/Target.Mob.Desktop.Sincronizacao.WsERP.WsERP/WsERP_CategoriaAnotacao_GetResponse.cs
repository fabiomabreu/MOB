using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_CategoriaAnotacao_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_CategoriaAnotacao_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfCategoriaAnotacaoWsModel WsERP_CategoriaAnotacao_GetResult;

	public WsERP_CategoriaAnotacao_GetResponse()
	{
	}

	public WsERP_CategoriaAnotacao_GetResponse(RetornoWsModelOfCategoriaAnotacaoWsModel WsERP_CategoriaAnotacao_GetResult)
	{
		this.WsERP_CategoriaAnotacao_GetResult = WsERP_CategoriaAnotacao_GetResult;
	}
}
