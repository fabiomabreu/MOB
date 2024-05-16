using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_EquipePromotor_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_EquipePromotor_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_EquipePromotor_SetResult;

	public WsERP_EquipePromotor_SetResponse()
	{
	}

	public WsERP_EquipePromotor_SetResponse(RetornoWsModelOfBoolean WsERP_EquipePromotor_SetResult)
	{
		this.WsERP_EquipePromotor_SetResult = WsERP_EquipePromotor_SetResult;
	}
}
