using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("estoque")]
public class EstoqueMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_local", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_LOCAL { get; set; }

	[Column("cd_prod", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("qtde")]
	public decimal QUANTIDADE { get; set; }

	[Column("qtde_pend_pedv")]
	public decimal QUANTIDADE_PENDENTE_PEDIDO_VENDA { get; set; }

	[Column("qtde_outros")]
	public decimal QUANTIDADE_OUTROS { get; set; }

	[Column("qtde_ctb")]
	public decimal QUANTIDADE_CTB { get; set; }

	[Column("qtde_pend_pedv_ctb")]
	public decimal QUANTIDADE_PENDENTE_PEDIDO_VENDA_CTB { get; set; }

	[Column("dt_ult_movimentacao")]
	public DateTime DATA_ULTIMA_MOVIMENTACAO { get; set; }

	[Column("dt_ult_reserva")]
	public DateTime DATA_ULTIMA_RESERVA { get; set; }
}
