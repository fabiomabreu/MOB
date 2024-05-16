using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_TGTFatMesAno_SetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_TGTFatMesAno_SetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_TGTFatMesAno_SetResult;

	public WsERP_TGTFatMesAno_SetResponse()
	{
	}

	public WsERP_TGTFatMesAno_SetResponse(RetornoWsModelOfBoolean WsERP_TGTFatMesAno_SetResult)
	{
		this.WsERP_TGTFatMesAno_SetResult = WsERP_TGTFatMesAno_SetResult;
	}
}
