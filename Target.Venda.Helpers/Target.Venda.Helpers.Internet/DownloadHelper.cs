using System;

namespace Target.Venda.Helpers.Internet;

public static class DownloadHelper
{
	public static bool VerificarUrlValido(string caminho, TipoAcessoWebEnum tipoAcessoWeb)
	{
		Uri result = null;
		if (Uri.TryCreate(caminho, UriKind.Absolute, out result) && result.Scheme.ToUpper().Equals(tipoAcessoWeb.ToString()))
		{
			return true;
		}
		return false;
	}
}
