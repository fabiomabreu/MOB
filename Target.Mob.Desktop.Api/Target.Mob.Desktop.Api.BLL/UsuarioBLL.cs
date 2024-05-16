using System;
using System.Text;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Model;

namespace Target.Mob.Desktop.Api.BLL;

public class UsuarioBLL
{
	internal static bool IsValid(string stringConnTargetErp, UsuarioTO usuario)
	{
		try
		{
			string @string = Encoding.UTF8.GetString(Convert.FromBase64String(usuario.Password));
			if (@string.Length < 15 || @string.Length > 22)
			{
				return false;
			}
			string cnpj = @string.Substring(0, 14).Trim();
			string text = @string.Substring(14, @string.Length - 14);
			if (text.Trim().ToUpper() != usuario.Username.Trim().ToUpper())
			{
				return false;
			}
			if (usuario.Role == "PAINELTARGET" && usuario.Username != "PAINEL")
			{
				return false;
			}
			if (!UsuarioDAL.IsValid(stringConnTargetErp, cnpj, text, usuario.Role, usuario.Tipo))
			{
				return false;
			}
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}
}
