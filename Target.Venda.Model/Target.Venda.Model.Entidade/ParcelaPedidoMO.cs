using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("ped_parc")]
public class ParcelaPedidoMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("nu_ped", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO { get; set; }

	[Column("seq_ped_parc", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public short SEQ_PARCELA_PEDIDO { get; set; }

	[Column("tp_tit")]
	public string TIPO_TITULO { get; set; }

	[Column("dt_parcela", TypeName = "smalldatetime")]
	public DateTime DATA_PARCELA { get; set; }

	[Column("vl_parcela")]
	public decimal VALOR_PARCELA { get; set; }

	[ForeignKey("CODIGO_EMPRESA, NUMERO_PEDIDO")]
	public PedidoVendaMO PEDIDO { get; set; }

	[Column("DtParcelaSugerida")]
	public DateTime? DATA_PARCELA_SUGERIDA { get; set; }
}
