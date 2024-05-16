using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://webservices.maplink2.com.br")]
public class findPOIRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string name;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public City city;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public ResultRange resultRange;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string token;

	public findPOIRequestBody()
	{
	}

	public findPOIRequestBody(string name, City city, ResultRange resultRange, string token)
	{
		this.name = name;
		this.city = city;
		this.resultRange = resultRange;
		this.token = token;
	}
}
