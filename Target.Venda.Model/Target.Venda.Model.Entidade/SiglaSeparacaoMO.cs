using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("sigla_separacao")]
public class SiglaSeparacaoMO : EntidadeBaseMO
{
	[Column("seq")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ { get; set; }

	[Column("sigla_separacao")]
	public string SIGLA_SEPARACAO { get; set; }
}
