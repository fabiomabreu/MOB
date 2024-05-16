using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evento_log")]
public class EventoLogMO : EntidadeBaseMO
{
	[Column("seq_evento_log")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_EVENTO_LOG { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("cd_usuario")]
	public string CODIGO_USUARIO { get; set; }

	[Column("cd_fila")]
	public string CODIGO_FILA { get; set; }

	[Column("dt_criacao")]
	public DateTime? DATA_CRIACAO { get; set; }
}
