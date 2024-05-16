using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("itpvcomp")]
public class ItemPedidoCompMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("nu_ped", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO { get; set; }

	[Column("seq", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public short SEQ { get; set; }

	[Column("comp_cortado")]
	public int? COMP_CORTADO { get; set; }

	[Column("larg_cortado")]
	public int? LARG_CORTADO { get; set; }

	[Column("num_folhas_pctcort")]
	public int? NUMERO_FOLHAS_PCT_CORT { get; set; }

	[Column("qtde_milheiro")]
	public decimal? QUANTIDADE_MILHEIRO { get; set; }

	[Column("preco_unit_cort")]
	public decimal? PRECO_UNITARIO_CORT { get; set; }

	[Column("qtde_pct_cort")]
	public int? QUANTIDADE_PCT_CORT { get; set; }
}
