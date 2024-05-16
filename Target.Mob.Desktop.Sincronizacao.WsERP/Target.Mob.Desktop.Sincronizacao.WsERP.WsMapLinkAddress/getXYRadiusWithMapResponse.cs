using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class getXYRadiusWithMapResponse
{
	[MessageBodyMember(Name = "getXYRadiusWithMapResponse", Namespace = "http://webservices.maplink2.com.br", Order = 0)]
	public getXYRadiusWithMapResponseBody Body;

	public getXYRadiusWithMapResponse()
	{
	}

	public getXYRadiusWithMapResponse(getXYRadiusWithMapResponseBody Body)
	{
		this.Body = Body;
	}
}
