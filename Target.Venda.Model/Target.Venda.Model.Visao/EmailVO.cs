namespace Target.Venda.Model.Visao;

public class EmailVO
{
	public DestinatarioEmailVO DESTINATARIO { get; set; }

	public DestinatarioEmailVO DESTINATARIO_COPIA { get; set; }

	public string ASSUNTO { get; set; }

	public string MENSAGEM { get; set; }

	public bool FORMATO_HTML { get; set; }
}
