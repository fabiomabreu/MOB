using System.Text.RegularExpressions;

namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public class StringUtil
{
	public static string RemoveSpecialCharacters(string input)
	{
		return new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant).Replace(input, "_");
	}
}
