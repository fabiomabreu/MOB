using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("fopg_prm")]
public class FormaPagamentoPromocaoMO : EntidadeBaseMO
{
	[Column("seq_prom", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_PROMOCAO { get; set; }

	[Column("formpgto", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string FORMA_PAGAMENTO { get; set; }

	[Column("padrao")]
	public bool? PADRAO { get; set; }

	[Column("vl_min_pedv")]
	public decimal? VALOR_MINIMO_PEDIDO { get; set; }

	public PromocaoMO PROMOCAO { get; set; }
}
