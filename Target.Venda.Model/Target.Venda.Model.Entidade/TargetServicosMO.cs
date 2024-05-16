using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("TargetServicos")]
public class TargetServicosMO : EntidadeBaseMO
{
	[Column("TargetServicosID")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int TargetServicosID { get; set; }

	[Column("EnderecoServidor")]
	public string EnderecoServidor { get; set; }

	[Column("HostnameServidor")]
	public string HostnameServidor { get; set; }

	[Column("PortaAPI")]
	public int? PortaAPI { get; set; }

	[Column("Ativo")]
	public bool? Ativo { get; set; }
}
