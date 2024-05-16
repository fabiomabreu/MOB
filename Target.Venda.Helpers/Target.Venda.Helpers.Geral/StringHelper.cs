using System.Text;
using System.Text.RegularExpressions;

namespace Target.Venda.Helpers.Geral;

public class StringHelper
{
	public static string LimparFormat(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return value.Replace("-", "").Replace("/", "").Replace(",", "")
				.Replace(".", "")
				.Replace("_", "")
				.Replace("(", "")
				.Replace(")", "")
				.Replace("%", "");
		}
		return string.Empty;
	}

	public static string RemoverAcentos(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return "";
		}
		byte[] bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(input);
		return Encoding.UTF8.GetString(bytes);
	}

	public static string RemoverCaracteres(string valor)
	{
		if (!string.IsNullOrEmpty(valor))
		{
			return Regex.Match(valor, "\\d+").Value;
		}
		return "";
	}

	public static string RemoverEspacosAmaisEntrePalavras(string texto)
	{
		if (!string.IsNullOrEmpty(texto))
		{
			while (texto.IndexOf("  ") >= 0)
			{
				texto = texto.Replace("  ", " ");
			}
		}
		return texto;
	}
}
