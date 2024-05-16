namespace Target.Venda.Helpers.Geral;

public static class RegexHelper
{
	public static string StringToExpressionRegular(string valor)
	{
		valor = "^" + valor;
		valor = valor.Replace("{0}", "([A-Za-z0-9])*");
		valor = valor.Replace("{1}", "([A-Za-z0-9_])*");
		valor = valor.Replace("{2}", "([A-Za-z0-9_-])*");
		valor = valor.Replace(".", "\\.{1}");
		valor += "$";
		return valor;
	}
}
