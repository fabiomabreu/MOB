using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://webservices.maplink2.com.br")]
public class getXYRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public Address address;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string token;

	public getXYRequestBody()
	{
	}

	public getXYRequestBody(Address address, string token)
	{
		this.address = address;
		this.token = token;
	}
}
