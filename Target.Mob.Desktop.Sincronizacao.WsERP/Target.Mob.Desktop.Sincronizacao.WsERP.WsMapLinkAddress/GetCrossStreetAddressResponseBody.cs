using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://webservices.maplink2.com.br")]
public class GetCrossStreetAddressResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public AddressLocation[] GetCrossStreetAddressResult;

	public GetCrossStreetAddressResponseBody()
	{
	}

	public GetCrossStreetAddressResponseBody(AddressLocation[] GetCrossStreetAddressResult)
	{
		this.GetCrossStreetAddressResult = GetCrossStreetAddressResult;
	}
}
