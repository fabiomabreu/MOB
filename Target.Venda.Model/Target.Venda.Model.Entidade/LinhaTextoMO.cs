using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("lin_txt")]
public class LinhaTextoMO : EntidadeBaseMO
{
	[Column("cd_texto", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_TEXTO { get; set; }

	[Column("num_lin", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_LINHA { get; set; }

	[Column("texto")]
	public string TEXTO { get; set; }
}
