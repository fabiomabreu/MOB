using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class AddressFinderSoapClient : ClientBase<AddressFinderSoap>, AddressFinderSoap
{
	public AddressFinderSoapClient()
	{
	}

	public AddressFinderSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public AddressFinderSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public AddressFinderSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public AddressFinderSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	findPOIResponse AddressFinderSoap.findPOI(findPOIRequest request)
	{
		return base.Channel.findPOI(request);
	}

	public POIInfo findPOI(string name, City city, ResultRange resultRange, string token)
	{
		findPOIRequest findPOIRequest2 = new findPOIRequest();
		findPOIRequest2.Body = new findPOIRequestBody();
		findPOIRequest2.Body.name = name;
		findPOIRequest2.Body.city = city;
		findPOIRequest2.Body.resultRange = resultRange;
		findPOIRequest2.Body.token = token;
		return ((AddressFinderSoap)this).findPOI(findPOIRequest2).Body.findPOIResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	findAddressResponse AddressFinderSoap.findAddress(findAddressRequest request)
	{
		return base.Channel.findAddress(request);
	}

	public AddressInfo findAddress(Address address, AddressOptions ao, string token)
	{
		findAddressRequest findAddressRequest2 = new findAddressRequest();
		findAddressRequest2.Body = new findAddressRequestBody();
		findAddressRequest2.Body.address = address;
		findAddressRequest2.Body.ao = ao;
		findAddressRequest2.Body.token = token;
		return ((AddressFinderSoap)this).findAddress(findAddressRequest2).Body.findAddressResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	getAddressResponse AddressFinderSoap.getAddress(getAddressRequest request)
	{
		return base.Channel.getAddress(request);
	}

	public AddressLocation getAddress(Point point, string token, double tolerance)
	{
		getAddressRequest getAddressRequest2 = new getAddressRequest();
		getAddressRequest2.Body = new getAddressRequestBody();
		getAddressRequest2.Body.point = point;
		getAddressRequest2.Body.token = token;
		getAddressRequest2.Body.tolerance = tolerance;
		return ((AddressFinderSoap)this).getAddress(getAddressRequest2).Body.getAddressResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	getXYResponse AddressFinderSoap.getXY(getXYRequest request)
	{
		return base.Channel.getXY(request);
	}

	public Point getXY(Address address, string token)
	{
		getXYRequest getXYRequest2 = new getXYRequest();
		getXYRequest2.Body = new getXYRequestBody();
		getXYRequest2.Body.address = address;
		getXYRequest2.Body.token = token;
		return ((AddressFinderSoap)this).getXY(getXYRequest2).Body.getXYResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	getXYRadiusWithMapResponse AddressFinderSoap.getXYRadiusWithMap(getXYRadiusWithMapRequest request)
	{
		return base.Channel.getXYRadiusWithMap(request);
	}

	public MapInfo getXYRadiusWithMap(Address address, MapOptions mo, int radius, string token)
	{
		getXYRadiusWithMapRequest getXYRadiusWithMapRequest2 = new getXYRadiusWithMapRequest();
		getXYRadiusWithMapRequest2.Body = new getXYRadiusWithMapRequestBody();
		getXYRadiusWithMapRequest2.Body.address = address;
		getXYRadiusWithMapRequest2.Body.mo = mo;
		getXYRadiusWithMapRequest2.Body.radius = radius;
		getXYRadiusWithMapRequest2.Body.token = token;
		return ((AddressFinderSoap)this).getXYRadiusWithMap(getXYRadiusWithMapRequest2).Body.getXYRadiusWithMapResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	findCityResponse AddressFinderSoap.findCity(findCityRequest request)
	{
		return base.Channel.findCity(request);
	}

	public CityLocationInfo findCity(City cidade, AddressOptions ao, string token)
	{
		findCityRequest findCityRequest2 = new findCityRequest();
		findCityRequest2.Body = new findCityRequestBody();
		findCityRequest2.Body.cidade = cidade;
		findCityRequest2.Body.ao = ao;
		findCityRequest2.Body.token = token;
		return ((AddressFinderSoap)this).findCity(findCityRequest2).Body.findCityResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCrossStreetXYResponse AddressFinderSoap.GetCrossStreetXY(GetCrossStreetXYRequest request)
	{
		return base.Channel.GetCrossStreetXY(request);
	}

	public CrossStreetLocation[] GetCrossStreetXY(City cidade, string firstStreet, string secondStreet, string token)
	{
		GetCrossStreetXYRequest getCrossStreetXYRequest = new GetCrossStreetXYRequest();
		getCrossStreetXYRequest.Body = new GetCrossStreetXYRequestBody();
		getCrossStreetXYRequest.Body.cidade = cidade;
		getCrossStreetXYRequest.Body.firstStreet = firstStreet;
		getCrossStreetXYRequest.Body.secondStreet = secondStreet;
		getCrossStreetXYRequest.Body.token = token;
		return ((AddressFinderSoap)this).GetCrossStreetXY(getCrossStreetXYRequest).Body.GetCrossStreetXYResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCrossStreetAddressResponse AddressFinderSoap.GetCrossStreetAddress(GetCrossStreetAddressRequest request)
	{
		return base.Channel.GetCrossStreetAddress(request);
	}

	public AddressLocation[] GetCrossStreetAddress(Point point, string token)
	{
		GetCrossStreetAddressRequest getCrossStreetAddressRequest = new GetCrossStreetAddressRequest();
		getCrossStreetAddressRequest.Body = new GetCrossStreetAddressRequestBody();
		getCrossStreetAddressRequest.Body.point = point;
		getCrossStreetAddressRequest.Body.token = token;
		return ((AddressFinderSoap)this).GetCrossStreetAddress(getCrossStreetAddressRequest).Body.GetCrossStreetAddressResult;
	}
}
