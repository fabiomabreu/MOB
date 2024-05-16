using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Target.Mob.Desktop.Api.Interface;

namespace Target.Mob.Desktop.Api.Security;

internal class ConfigureAuth
{
	public static JwtBearerAuthenticationOptions GetOptionsAuth(IConfiguration configuration)
	{
		JwtBearerAuthenticationOptions jwtBearerAuthenticationOptions = new JwtBearerAuthenticationOptions();
		jwtBearerAuthenticationOptions.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = configuration.GetIssuer(),
			ValidAudience = configuration.GetAudience(),
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSecretKey()))
		};
		jwtBearerAuthenticationOptions.AuthenticationMode = AuthenticationMode.Active;
		jwtBearerAuthenticationOptions.IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[1]
		{
			new SymmetricKeyIssuerSecurityKeyProvider(configuration.GetIssuer(), Encoding.UTF8.GetBytes(configuration.GetSecretKey()))
		};
		jwtBearerAuthenticationOptions.Provider = new OAuthBearerAuthenticationProvider
		{
			OnValidateIdentity = (OAuthValidateIdentityContext context) => Task.FromResult<object>(null)
		};
		return jwtBearerAuthenticationOptions;
	}
}
