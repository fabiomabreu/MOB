using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evento")]
public class EventoMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_EVENTO { get; set; }

	[Column("cd_fila")]
	public string CODIGO_FILA { get; set; }

	[Column("cd_emp")]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_clien")]
	public int? CODIGO_CLIENTE { get; set; }

	[Column("nu_ped")]
	public int? NUMERO_PEDIDO { get; set; }

	[Column("cd_usr_ger")]
	public string CODIGO_USUARIO_GERENTE { get; set; }

	[Column("cd_usr_resp")]
	public string CODIGO_USUARIO_RESPONSAVEL { get; set; }

	[Column("cd_usr_enc")]
	public string CODIGO_USUARIO_ENCERRAMENTO { get; set; }

	[Column("dt_criacao")]
	public DateTime DATA_CRIACAO { get; set; }

	[Column("dt_reserva")]
	public DateTime? DATA_RESERVA { get; set; }

	[Column("dt_encer")]
	public DateTime? DATA_ENCERRAMENTO { get; set; }

	[Column("dt_prevista")]
	public DateTime? DATA_RPEVISTA { get; set; }

	[Column("dt_follow")]
	public DateTime? DATA_FOLLOW { get; set; }

	[Column("num_follow")]
	public int? NUMERO_FOLLOW { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("comentario")]
	public int? COMENTARIO { get; set; }
}
