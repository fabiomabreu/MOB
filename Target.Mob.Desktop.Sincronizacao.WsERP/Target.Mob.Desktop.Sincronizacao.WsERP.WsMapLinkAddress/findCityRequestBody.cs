using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://webservices.maplink2.com.br")]
public class findCityRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public City cidade;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public AddressOptions ao;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string token;

	public findCityRequestBody()
	{
	}

	public findCityRequestBody(City cidade, AddressOptions ao, string token)
	{
		this.cidade = cidade;
		this.ao = ao;
		this.token = token;
	}
}
