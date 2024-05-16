using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TabelaPreco_SetarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TabelaPreco_SetarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TabelaPreco_SetarResult;

	public WsERP_TabelaPreco_SetarResponse()
	{
	}

	public WsERP_TabelaPreco_SetarResponse(RetornoWsModelOfBoolean WsERP_TabelaPreco_SetarResult)
	{
		this.WsERP_TabelaPreco_SetarResult = WsERP_TabelaPreco_SetarResult;
	}
}
