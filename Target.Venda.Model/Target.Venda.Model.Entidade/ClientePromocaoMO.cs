using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("clienprm")]
public class ClientePromocaoMO : EntidadeBaseMO
{
	[Column("cd_clien", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_CLIENTE { get; set; }

	[Column("seq_prom", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_PROMOCAO { get; set; }
}
