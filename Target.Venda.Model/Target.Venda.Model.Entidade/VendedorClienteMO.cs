using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("vend_cli")]
public class VendedorClienteMO : EntidadeBaseMO
{
	[Column("cd_clien", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_CLIENTE { get; set; }

	[Column("cd_vend", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("prioritario")]
	public bool PRIORITARIO { get; set; }

	[Column("vl_limite_verba")]
	public decimal VALOR_LIMITE_VERBA { get; set; }
}
