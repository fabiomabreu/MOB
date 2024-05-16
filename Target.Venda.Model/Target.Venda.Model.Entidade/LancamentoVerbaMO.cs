using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("lc_verba")]
public class LancamentoVerbaMO : EntidadeBaseMO
{
	[Column("seq_lc_verba")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_LANCAMENTO_VERBA { get; set; }

	[Column("dt_lanc")]
	public DateTime DATA_LANCAMENTO { get; set; }

	[Column("cd_vend")]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("cd_clien")]
	public int? CODIGO_CLIENTE { get; set; }

	[Column("cd_motlcverba")]
	public string CODIGO_MOTIVO_LANCAMENTO_VERBA { get; set; }

	[Column("valor")]
	public decimal VALOR { get; set; }

	[Column("cd_emp")]
	public int? CODIGO_EMPRESA { get; set; }

	[Column("nu_ped")]
	public int? NUMERO_PEDIDO { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("seq_fech_verba")]
	public int? SEQ_FECHAMENTO_VERBA { get; set; }

	[Column("tp_verba")]
	public string TIPO_VERBA { get; set; }

	[Column("compensacao")]
	public BoolEnum? COMPENSACAO { get; set; }

	[Column("nu_tit")]
	public int? NUMERO_TITULO { get; set; }

	[Column("serie")]
	public string SERIE { get; set; }

	[Column("seq_pgtrec")]
	public int? SEQ_PAGAMENTO_TITULO_RECEBER { get; set; }

	[Column("CdUsuario")]
	public string CODIGO_USUARIO { get; set; }

	[Column("SeqEventoDev")]
	public int? SEQ_EVENTO_DEVOLUCAO { get; set; }
}
