using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Target.Venda.Model.Entidade;

[Table("Fabric")]
public class FabricanteMO
{
	[Column("cd_fabric")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_FABRICANTE { get; set; }

	[Column("sigla")]
	public string SIGLA { get; set; }

	public List<ProdutoMO> PRODUTO { get; set; }
}
