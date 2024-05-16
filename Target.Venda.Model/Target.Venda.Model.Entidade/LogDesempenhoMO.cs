using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("log_desempenho")]
public class LogDesempenhoMO : EntidadeBaseMO
{
	[Column("id")]
	[Key]
	public int ID { get; set; }

	[Column("cd_tela")]
	public string CD_TELA { get; set; }

	[Column("operacao")]
	public string OPERACAO { get; set; }

	[Column("cd_usuario")]
	public string CD_USUARIO { get; set; }

	[Column("dt_inicio")]
	public DateTime? DT_INICIO { get; set; }

	[Column("dt_fim")]
	public DateTime? DT_FIM { get; set; }

	[Column("duracao_minuto")]
	public int? DURACAO_MINUTO { get; set; }

	[Column("duracao_segundo")]
	public int? DURACAO_SEGUNDO { get; set; }

	[Column("duracao_millisegundo")]
	public int? DURACAO_MILLISEGUNDO { get; set; }

	[Column("observacao")]
	public string OBSERVACAO { get; set; }
}
