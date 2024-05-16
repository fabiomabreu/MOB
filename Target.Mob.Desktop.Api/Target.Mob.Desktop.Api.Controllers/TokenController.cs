using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using Target.Mob.Desktop.Api.BLL;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Model;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/token")]
public class TokenController : ApiController
{
	private IConfiguration _configuration;

	public TokenController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[AllowAnonymous]
	[Route("")]
	public IHttpActionResult RequestToken([FromBody] UsuarioTO usuario)
	{
		if (!"PAINELTARGET".Equals(usuario.Role) && usuario.Tipo == null)
		{
			usuario.Tipo = "V";
		}
		if (UsuarioBLL.IsValid(_configuration.GetConnectionString(), usuario))
		{
			Claim[] claims = new Claim[2]
			{
				new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", usuario.Username),
				new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", usuario.Role ?? "")
			};
			SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSecretKey())), "HS256");
			string issuer = _configuration.GetIssuer();
			string audience = _configuration.GetAudience();
			DateTime? expires = DateTime.Now.AddMinutes(_configuration.GetExpiresMinutes());
			SigningCredentials signingCredentials2 = signingCredentials;
			JwtSecurityToken token = new JwtSecurityToken(issuer, audience, claims, null, expires, signingCredentials2);
			return Ok(new
			{
				token = new JwtSecurityTokenHandler().WriteToken(token)
			});
		}
		return BadRequest("Credenciais inválidas.");
	}
}
