using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("obs_ped_ele")]
public class ObservacaoPedidoEletronicoMO : EntidadeBaseMO
{
	[Column("cd_emp_ele", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA_ELETRONICO { get; set; }

	[Column("nu_ped_ele", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	[Column("seq_ped", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public decimal SEQ_PEDIDO { get; set; }

	[Column("seq", Order = 4)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public decimal SEQ { get; set; }

	[Column("setor")]
	public string SETOR { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[ForeignKey("CODIGO_EMPRESA_ELETRONICO, NUMERO_PEDIDO_ELETRONICO,SEQ_PEDIDO")]
	public PedidoEletronicoMO PEDVDAELETO { get; set; }
}
