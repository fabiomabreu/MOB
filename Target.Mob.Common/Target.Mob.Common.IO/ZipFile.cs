using System.IO;
using Resco.IO.Zip;

namespace Target.Mob.Common.IO;

public static class ZipFile
{
	public static void Compacta(string pathArquivoOrigem, string pathArquivoDestino)
	{
		using FileStream stream = File.Create(pathArquivoDestino);
		ZipArchive zipArchive = new ZipArchive(stream);
		zipArchive.Temp = zipArchive.Temp + "Target Mob\\" + pathArquivoDestino.GetHashCode() + "\\";
		if (!Directory.Exists(zipArchive.Temp))
		{
			Directory.CreateDirectory(zipArchive.Temp);
		}
		zipArchive.Add(pathArquivoOrigem, "\\", replace: true, delegate
		{
		});
		zipArchive.Close();
	}

	public static void Descompacta(string pathArquivoOrigem, string pathArquivoDestino)
	{
		ZipArchive zipArchive = new ZipArchive(pathArquivoOrigem, ZipArchiveMode.Open, FileShare.None);
		zipArchive.Extract("\\", pathArquivoDestino, delegate
		{
		});
		zipArchive.Close();
	}
}
