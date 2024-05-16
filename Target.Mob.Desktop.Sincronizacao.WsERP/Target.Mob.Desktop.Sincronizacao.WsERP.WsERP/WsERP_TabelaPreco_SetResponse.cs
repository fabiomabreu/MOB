using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TabelaPreco_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TabelaPreco_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TabelaPreco_SetResult;

	public WsERP_TabelaPreco_SetResponse()
	{
	}

	public WsERP_TabelaPreco_SetResponse(RetornoWsModelOfBoolean WsERP_TabelaPreco_SetResult)
	{
		this.WsERP_TabelaPreco_SetResult = WsERP_TabelaPreco_SetResult;
	}
}
