namespace Target.Mob.Desktop.Api.Model;

public class ArquivoImagemClienteTO
{
	public string FileName { get; set; }

	public byte[] Conteudo { get; set; }

	public ArquivoImagemClienteTO(string fileName, byte[] conteudo)
	{
		Conteudo = conteudo;
		FileName = fileName;
	}
}
