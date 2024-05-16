using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TGTFatMesAnoFabric_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TGTFatMesAnoFabric_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TGTFatMesAnoFabric_SetResult;

	public WsERP_TGTFatMesAnoFabric_SetResponse()
	{
	}

	public WsERP_TGTFatMesAnoFabric_SetResponse(RetornoWsModelOfBoolean WsERP_TGTFatMesAnoFabric_SetResult)
	{
		this.WsERP_TGTFatMesAnoFabric_SetResult = WsERP_TGTFatMesAnoFabric_SetResult;
	}
}
