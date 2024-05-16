using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("descprod")]
public class DescontoProdutoMO : EntidadeBaseMO
{
	[Column("cd_prod", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("seq_descprod", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_DESCONTO_PRODUTO { get; set; }

	[Column("cd_tabela", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_TABELA { get; set; }

	[Column("qtde_de")]
	public decimal QUANTIDADE_DE { get; set; }

	[Column("qtde_ate")]
	public decimal QUANTIDADE_ATE { get; set; }

	[Column("desconto")]
	public decimal DESCONTO { get; set; }
}
