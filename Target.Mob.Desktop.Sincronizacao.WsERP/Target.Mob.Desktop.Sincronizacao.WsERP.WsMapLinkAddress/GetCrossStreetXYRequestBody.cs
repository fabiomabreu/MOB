using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://webservices.maplink2.com.br")]
public class GetCrossStreetXYRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public City cidade;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string firstStreet;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string secondStreet;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string token;

	public GetCrossStreetXYRequestBody()
	{
	}

	public GetCrossStreetXYRequestBody(City cidade, string firstStreet, string secondStreet, string token)
	{
		this.cidade = cidade;
		this.firstStreet = firstStreet;
		this.secondStreet = secondStreet;
		this.token = token;
	}
}
