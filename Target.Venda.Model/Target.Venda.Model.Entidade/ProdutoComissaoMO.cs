using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("prod_comis")]
public class ProdutoComissaoMO : EntidadeBaseMO
{
	[Column("cd_tabela", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_TABELA { get; set; }

	[Column("cd_grupo", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_GRUPO { get; set; }

	[Column("cd_prod", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("cd_grp_comis")]
	public string CODIGO_GRUPO_COMISSAO { get; set; }
}
