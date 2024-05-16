using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("email")]
public class EmailMO : EntidadeBaseMO
{
	[Column("seq_email")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_EMAIL { get; set; }

	[Column("seq_email_conta")]
	public short SEQ_EMAIL_CONTA { get; set; }

	[Column("destinatario")]
	public string DESTINATARIO { get; set; }

	[Column("destinatario_copia")]
	public string DESTINATARIO_COPIA { get; set; }

	[Column("assunto")]
	public string ASSUNTO { get; set; }

	[Column("mensagem")]
	public string MENSAGEM { get; set; }

	[Column("qtde_envio")]
	public short QUANTIDADE_ENVIO { get; set; }

	[Column("dt_ult_envio")]
	public DateTime? DATA_ULTIMO_ENVIO { get; set; }

	[Column("formato_html")]
	public bool FORMATO_HTML { get; set; }

	[Column("ult_envio_retorno")]
	public DateTime? DATA_ULTIMO_ENVIO_RETORNO { get; set; }

	[Column("ult_envio_mensagem")]
	public DateTime? ULTIMO_ENVIO_MENSAGEM { get; set; }
}
