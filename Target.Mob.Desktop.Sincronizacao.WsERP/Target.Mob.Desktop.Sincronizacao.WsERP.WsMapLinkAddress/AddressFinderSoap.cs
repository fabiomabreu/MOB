using System.CodeDom.Compiler;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "http://webservices.maplink2.com.br", ConfigurationName = "WsMapLinkAddress.AddressFinderSoap")]
public interface AddressFinderSoap
{
	[OperationContract(Action = "http://webservices.maplink2.com.br/findPOI", ReplyAction = "*")]
	findPOIResponse findPOI(findPOIRequest request);

	[OperationContract(Action = "http://webservices.maplink2.com.br/findAddress", ReplyAction = "*")]
	findAddressResponse findAddress(findAddressRequest request);

	[OperationContract(Action = "http://webservices.maplink2.com.br/getAddress", ReplyAction = "*")]
	getAddressResponse getAddress(getAddressRequest request);

	[OperationContract(Action = "http://webservices.maplink2.com.br/getXY", ReplyAction = "*")]
	getXYResponse getXY(getXYRequest request);

	[OperationContract(Action = "http://webservices.maplink2.com.br/getXYRadiusWithMap", ReplyAction = "*")]
	getXYRadiusWithMapResponse getXYRadiusWithMap(getXYRadiusWithMapRequest request);

	[OperationContract(Action = "http://webservices.maplink2.com.br/findCity", ReplyAction = "*")]
	findCityResponse findCity(findCityRequest request);

	[OperationContract(Action = "http://webservices.maplink2.com.br/GetCrossStreetXY", ReplyAction = "*")]
	GetCrossStreetXYResponse GetCrossStreetXY(GetCrossStreetXYRequest request);

	[OperationContract(Action = "http://webservices.maplink2.com.br/GetCrossStreetAddress", ReplyAction = "*")]
	GetCrossStreetAddressResponse GetCrossStreetAddress(GetCrossStreetAddressRequest request);
}
