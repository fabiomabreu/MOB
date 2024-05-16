using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("VsControl")]
public class VsControlMO : EntidadeBaseMO
{
	[Column("VsControlID")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public long VS_CONTROL_ID { get; set; }

	[Column("Ocorrencia")]
	public long OCORRENCIA { get; set; }

	[Column("Seq")]
	public int SEQ { get; set; }
}
