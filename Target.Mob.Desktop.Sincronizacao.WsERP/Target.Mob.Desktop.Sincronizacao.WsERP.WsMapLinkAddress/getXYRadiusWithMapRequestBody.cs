using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://webservices.maplink2.com.br")]
public class getXYRadiusWithMapRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public Address address;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public MapOptions mo;

	[DataMember(Order = 2)]
	public int radius;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string token;

	public getXYRadiusWithMapRequestBody()
	{
	}

	public getXYRadiusWithMapRequestBody(Address address, MapOptions mo, int radius, string token)
	{
		this.address = address;
		this.mo = mo;
		this.radius = radius;
		this.token = token;
	}
}
