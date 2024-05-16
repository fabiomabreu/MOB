using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("texto")]
public class TextoMO : EntidadeBaseMO
{
	[Column("cd_texto")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_TEXTO { get; set; }

	public List<LinhaTextoMO> LINHAS_TEXTO { get; set; }
}
