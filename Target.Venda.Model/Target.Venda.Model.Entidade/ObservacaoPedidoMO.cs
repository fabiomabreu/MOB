using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("obs_ped")]
public class ObservacaoPedidoMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("nu_ped", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO { get; set; }

	[Column("seq", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public short SEQ { get; set; }

	[Column("setor")]
	public string SETOR { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[ForeignKey("CODIGO_EMPRESA, NUMERO_PEDIDO")]
	public PedidoVendaMO PEDIDO { get; set; }
}
