using System.Web.Services.Protocols;

namespace Target.Mob.Common.Seguranca;

public class ValidationSoapHeader : SoapHeader
{
	private string _token;

	public string Token
	{
		get
		{
			return _token;
		}
		set
		{
			_token = value;
		}
	}

	public ValidationSoapHeader()
	{
	}

	public ValidationSoapHeader(string devToken)
	{
		_token = devToken;
	}
}
