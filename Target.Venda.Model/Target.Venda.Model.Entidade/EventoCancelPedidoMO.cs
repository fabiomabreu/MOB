using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("ev_cpedv")]
public class EventoCancelPedidoMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_EVENTO { get; set; }

	[Column("cd_motcanc")]
	public string CODIGO_MOTIVO_CANCELAMENTO { get; set; }
}
