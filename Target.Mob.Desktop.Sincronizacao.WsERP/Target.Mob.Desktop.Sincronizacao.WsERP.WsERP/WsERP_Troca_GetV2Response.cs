using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Troca_GetV2Response", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Troca_GetV2Response
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfTrocaWsModel WsERP_Troca_GetV2Result;

	public WsERP_Troca_GetV2Response()
	{
	}

	public WsERP_Troca_GetV2Response(RetornoWsModelOfTrocaWsModel WsERP_Troca_GetV2Result)
	{
		this.WsERP_Troca_GetV2Result = WsERP_Troca_GetV2Result;
	}
}
