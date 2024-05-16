using System.IO;
using System.Text;

namespace Target.Venda.Helpers.IO;

public static class ArquivoHelper
{
	public static byte[] ObterBytesPeloCaminhoArquivo(string CaminhoCompleto)
	{
		if (File.Exists(CaminhoCompleto))
		{
			return File.ReadAllBytes(CaminhoCompleto);
		}
		return null;
	}

	public static void GravarArquivo(string caminhoDestino, string conteudo)
	{
		using StreamWriter streamWriter = new StreamWriter(caminhoDestino, append: false, Encoding.GetEncoding("ISO-8859-1"));
		streamWriter.WriteLine(conteudo);
		streamWriter.Close();
	}

	public static string LerArquivo(string caminhoOrigem)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (StreamReader streamReader = new StreamReader(caminhoOrigem, Encoding.GetEncoding("ISO-8859-1")))
		{
			stringBuilder.Append(streamReader.ReadToEnd());
			streamReader.Close();
		}
		return stringBuilder.ToString();
	}
}
