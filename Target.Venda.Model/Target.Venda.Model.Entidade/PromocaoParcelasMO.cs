using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("prm_parc")]
public class PromocaoParcelasMO : EntidadeBaseMO
{
	[Column("seq_prom", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_PROMOCAO { get; set; }

	[Column("nu_parc", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PARCELA { get; set; }

	[Column("qt_prazo")]
	public int? QUANTIDADE_PRAZO { get; set; }

	[Column("dt_venc_fixo")]
	public DateTime? DATA_VENCIMENTO_FIXO { get; set; }

	[ForeignKey("SEQ_PROMOCAO")]
	public PromocaoMO PROMOCAO { get; set; }
}
