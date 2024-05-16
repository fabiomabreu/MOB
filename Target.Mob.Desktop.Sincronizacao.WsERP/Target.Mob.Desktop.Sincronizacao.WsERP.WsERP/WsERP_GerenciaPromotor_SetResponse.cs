using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_GerenciaPromotor_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_GerenciaPromotor_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_GerenciaPromotor_SetResult;

	public WsERP_GerenciaPromotor_SetResponse()
	{
	}

	public WsERP_GerenciaPromotor_SetResponse(RetornoWsModelOfBoolean WsERP_GerenciaPromotor_SetResult)
	{
		this.WsERP_GerenciaPromotor_SetResult = WsERP_GerenciaPromotor_SetResult;
	}
}
