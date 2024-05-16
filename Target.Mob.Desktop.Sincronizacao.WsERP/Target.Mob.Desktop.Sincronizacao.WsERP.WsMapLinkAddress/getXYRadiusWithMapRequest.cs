using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class getXYRadiusWithMapRequest
{
	[MessageBodyMember(Name = "getXYRadiusWithMap", Namespace = "http://webservices.maplink2.com.br", Order = 0)]
	public getXYRadiusWithMapRequestBody Body;

	public getXYRadiusWithMapRequest()
	{
	}

	public getXYRadiusWithMapRequest(getXYRadiusWithMapRequestBody Body)
	{
		this.Body = Body;
	}
}
