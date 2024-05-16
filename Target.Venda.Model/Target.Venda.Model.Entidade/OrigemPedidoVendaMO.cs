using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("OrigemPedidoVenda")]
public class OrigemPedidoVendaMO : EntidadeBaseMO
{
	[Column("OrigemPedidoVenda")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string ORIGEM_PEDIDO { get; set; }

	[Column("Descricao")]
	public string DESCRICAO { get; set; }

	[Column("Ativo")]
	public BoolEnum? ATIVO { get; set; }

	[Column("DetalhePedVdaEle")]
	public BoolEnum? DETALHE_PEDVDAELE { get; set; }

	[Column("ListaPedidoPendente")]
	public BoolEnum? LISTA_PEDIDO_PENDENTE { get; set; }
}
