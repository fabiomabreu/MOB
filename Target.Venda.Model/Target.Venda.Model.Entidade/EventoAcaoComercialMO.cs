using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evento_acao_com")]
public class EventoAcaoComercialMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_EVENTO { get; set; }

	[Column("cd_usuario")]
	public string CODIGO_USUARIO { get; set; }

	[Column("dt_criacao")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	public DateTime DATA_CRIACAO { get; set; }

	[Column("seq_acao_comercial")]
	public int SEQ_ACAO_COMERCIAL { get; set; }

	[Column("cd_tp_ocor_acao_com")]
	public string CODIGO_TIPO_OCORRENCIA_ACAO_COMERCIAL { get; set; }

	[Column("cd_prod")]
	public int? CODIGO_PRODUTO { get; set; }
}
