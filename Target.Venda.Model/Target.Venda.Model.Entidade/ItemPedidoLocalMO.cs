using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("it_pedv_local")]
public class ItemPedidoLocalMO : EntidadeBaseMO
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

	[Column("cd_emp_local_est", Order = 4)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA_LOCAL_ESTOQUE { get; set; }

	[Column("cd_local", Order = 5)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_LOCAL { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("qtde")]
	public decimal QUANTIDADE { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("trans_efet")]
	public BoolEnum? TRANSFERENCIA_EFETIVA { get; set; }

	[Column("cd_emp_transf")]
	public int? CODIGO_EMPRESA_TRANSFERENCIA { get; set; }

	[Column("nu_ped_transf")]
	public int? NUUMERO_PEDIDO_TRANSFERENCIA { get; set; }

	[Column("unid_est")]
	public string UNIDADE_ESTOQUE { get; set; }

	[Column("qtde_unid_ped")]
	public decimal QUATIDADE_UNIDADE_PEDIDA { get; set; }

	[Column("unid_ped")]
	public string UNIDADE_PEDIDA { get; set; }

	[ForeignKey("CODIGO_EMPRESA, NUMERO_PEDIDO, SEQ")]
	public ItemPedidoMO FK_ITEM_PEDIDO { get; set; }
}
