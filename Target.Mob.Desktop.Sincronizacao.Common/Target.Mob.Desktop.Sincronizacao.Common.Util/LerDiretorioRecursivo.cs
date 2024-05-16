using System;
using System.IO;
using Target.Mob.Common.IO;

namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public class LerDiretorioRecursivo
{
	public static void LerDiretorioSubDiretorio(string Path_Origem, string Path_Destino, bool MostraMensagem)
	{
		try
		{
			if (!Directory.Exists(Path_Origem))
			{
				return;
			}
			string text = "";
			string text2 = "";
			if (!Directory.Exists(Path_Origem))
			{
				return;
			}
			string[] files = Directory.GetFiles(Path_Origem);
			string[] directories = Directory.GetDirectories(Path_Origem);
			if (directories.Length != 0)
			{
				string[] array = directories;
				foreach (string text3 in array)
				{
					string text4 = Path_Destino + "\\" + text3.Substring(text3.LastIndexOf("\\"));
					if (!Directory.Exists(text4))
					{
						Directory.CreateDirectory(text4);
						LerDiretorioSubDiretorio(text3, text4, MostraMensagem: false);
					}
					else
					{
						LerDiretorioSubDiretorio(text3, text4, MostraMensagem: false);
					}
				}
			}
			if (files.Length != 0)
			{
				string[] array = files;
				foreach (string obj in array)
				{
					text = Path.GetFileName(obj);
					text2 = Path.Combine(Path_Destino, text);
					File.Copy(obj, text2, overwrite: true);
					string text5 = Path_Destino + "\\" + text;
					ZipFile.Compacta(text5, text5 + ".ZIP");
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			string[] array = Directory.GetDirectories(Path_Origem);
			for (int i = 0; i < array.Length; i++)
			{
				Directory.Delete(array[i], recursive: true);
			}
			array = Directory.GetFiles(Path_Origem);
			for (int i = 0; i < array.Length; i++)
			{
				File.Delete(array[i]);
			}
		}
	}
}
