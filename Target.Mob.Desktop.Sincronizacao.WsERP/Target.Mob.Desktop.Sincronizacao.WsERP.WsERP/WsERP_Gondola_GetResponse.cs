using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_Gondola_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_Gondola_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfGondolaWsModel WsERP_Gondola_GetResult;

	public WsERP_Gondola_GetResponse()
	{
	}

	public WsERP_Gondola_GetResponse(RetornoWsModelOfListOfGondolaWsModel WsERP_Gondola_GetResult)
	{
		this.WsERP_Gondola_GetResult = WsERP_Gondola_GetResult;
	}
}
