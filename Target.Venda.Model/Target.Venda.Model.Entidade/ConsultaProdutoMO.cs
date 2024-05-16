using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("cons_prd")]
public class ConsultaProdutoMO : EntidadeBaseMO
{
	[Column("cd_prod", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("dt_consulta", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public DateTime DATA_CONSULTA { get; set; }

	[Column("cd_linha", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_LINHA { get; set; }

	[Column("cd_vend", Order = 4)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("cd_clien", Order = 5)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_CLIENTE { get; set; }

	[Column("qtde")]
	public string QUANTIDADE { get; set; }
}
