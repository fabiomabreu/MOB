using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://webservices.maplink2.com.br")]
public class getAddressRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public Point point;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string token;

	[DataMember(Order = 2)]
	public double tolerance;

	public getAddressRequestBody()
	{
	}

	public getAddressRequestBody(Point point, string token, double tolerance)
	{
		this.point = point;
		this.token = token;
		this.tolerance = tolerance;
	}
}
