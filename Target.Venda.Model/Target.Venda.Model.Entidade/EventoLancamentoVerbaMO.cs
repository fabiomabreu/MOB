using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evento_lc_verba")]
public class EventoLancamentoVerbaMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public string SEQ_EVENTO { get; set; }

	[Column("seq_lc_verba")]
	public int SEQ_LANCAMENTO_VERBA { get; set; }

	[Column("dt_criacao")]
	public DateTime DATA_CRIACAO { get; set; }

	[Column("cd_usuario")]
	public string CODIGO_USUARIO { get; set; }

	[Column("cd_tp_ocor_lc_verba")]
	public short CODIGO_TIPO_OCORRENCIA_LANCAMENTO_VERBA { get; set; }
}
