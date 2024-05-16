using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evento_pdel_ab")]
public class EventoPedidoEletronicoAbertoMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_EVENTO { get; set; }

	[ForeignKey("SEQ_EVENTO")]
	[Required]
	public EventoPedidoEletronicoMO EVENTO_PEDIDO_ELETRONICO { get; set; }
}
