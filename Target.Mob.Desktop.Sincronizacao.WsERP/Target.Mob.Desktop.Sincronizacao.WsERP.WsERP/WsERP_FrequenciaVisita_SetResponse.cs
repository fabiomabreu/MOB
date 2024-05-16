using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_FrequenciaVisita_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_FrequenciaVisita_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_FrequenciaVisita_SetResult;

	public WsERP_FrequenciaVisita_SetResponse()
	{
	}

	public WsERP_FrequenciaVisita_SetResponse(RetornoWsModelOfBoolean WsERP_FrequenciaVisita_SetResult)
	{
		this.WsERP_FrequenciaVisita_SetResult = WsERP_FrequenciaVisita_SetResult;
	}
}
