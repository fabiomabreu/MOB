using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("prod_desc_prz")]
public class ProdutoDescontoPrazoMO : EntidadeBaseMO
{
	[Column("cd_tabela", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_TABELA { get; set; }

	[Column("seq_prom", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_PROMOCAO { get; set; }

	[Column("cd_prod", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("desconto", Order = 4)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public decimal DESCONTO { get; set; }

	[Column("descprom_lancprod")]
	public BoolEnum? DESCONTO_PROMOCAO_LANCAMENTO_PRODUTO { get; set; }
}
