using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evento_alt_preco")]
public class EventoAlteracaoPrecoMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_EVENTO { get; set; }

	[Column("dt_criacao")]
	public DateTime DATA_CRIACAO { get; set; }

	[Column("cd_usuario")]
	public string CODIGO_USUARIO { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("cd_tabela")]
	public string CODIGO_TABELA { get; set; }

	[Column("vl_preco_ant")]
	public decimal VALOR_PRECO_ANTERIOR { get; set; }

	[Column("vl_preco_novo")]
	public decimal VALOR_PRECO_NOVO { get; set; }

	[Column("programa_origem")]
	public string PROGRAMA_ORIGEM { get; set; }
}
