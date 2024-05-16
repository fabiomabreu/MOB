using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("kit_prom_pgto")]
public class KitPromocaoPagamentoMO : EntidadeBaseMO
{
	[Column("seq_kit", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_KIT { get; set; }

	[Column("seq_prom", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_PROMOCAO { get; set; }

	[Column("desc_fin")]
	public BoolEnum? DESCONTO_FINANCEIRO { get; set; }

	[ForeignKey("SEQ_PROMOCAO")]
	public PromocaoMO PROMOCAO { get; set; }
}
