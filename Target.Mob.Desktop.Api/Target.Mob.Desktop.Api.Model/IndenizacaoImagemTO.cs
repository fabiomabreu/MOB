namespace Target.Mob.Desktop.Api.Model;

public class IndenizacaoImagemTO
{
	public int? IndenizacaoImagemID { get; set; }

	public int? IndenizacaoID { get; set; }

	public string Nome { get; set; }

	public byte[] Arquivo { get; set; }

	public IndenizacaoImagemTO()
	{
	}

	public IndenizacaoImagemTO(int? indenizacaoID, string nome, byte[] arquivo)
	{
		IndenizacaoID = indenizacaoID;
		Nome = nome;
		Arquivo = arquivo;
	}
}
