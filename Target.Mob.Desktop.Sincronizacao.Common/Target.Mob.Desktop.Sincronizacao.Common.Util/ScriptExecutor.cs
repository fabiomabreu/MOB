using System;

namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public class ScriptExecutor
{
	public static string[] SplitScript(string script)
	{
		string[] array = new string[33]
		{
			"\nGO\n", "\r\nGO\r\n", "\r\ngo\r\n", "\r\nGo\r\n", "\r\ngO\r\n", " GO ", " go ", " Go ", " gO ", "\r\nGO ",
			"\r\ngo ", "\r\nGo ", "\r\ngO ", "\r\nGO", "\r\ngo", "\r\nGo", "\r\ngO", " GO\r\n", " go\r\n", " Go\r\n",
			" gO\r\n", "\n\t\t\n\t\tGO\n\t\t\n\t\t", "\n\t\t\n\t\tGo\n\t\t\n\t\t", "\n\t\t\n\t\tgo\n\t\t\n\t\t", "\n\t\t\n\t\tgO\n\t\t\n\t\t", "\n\t\n\t\t GO\t\n\n\t\t", "\n\t\n\t\t Go\t\n\n\t\t", "\n\t\n\t\t go\t\n\n\t\t", "\n\t\n\t\t gO\t\n\n\t\t", "\n\t    \n\t\tGO\n\n\t\t",
			"\n\t    \n\t\tGo\n\n\t\t", "\n\t    \n\t\tgo\n\n\t\t", "\n\t    \n\t\tgO\n\n\t\t"
		};
		string[] array2 = script.Split(array, StringSplitOptions.RemoveEmptyEntries);
		string[] array3 = array2;
		foreach (string text in array3)
		{
			string[] array4 = array;
			foreach (string oldValue in array4)
			{
				text.Replace(oldValue, string.Empty);
			}
		}
		return array2;
	}
}
