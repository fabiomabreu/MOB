using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("faltaprd")]
public class FaltaProdutoMO : EntidadeBaseMO
{
	[Column("seq")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ { get; set; }

	[Column("dt_falta", TypeName = "smalldatetime")]
	public DateTime DATA_FALTA { get; set; }

	[Column("cd_vend")]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("cd_usuario")]
	public string CODIGO_USUARIO { get; set; }

	[Column("cd_clien")]
	public int CODIGO_CLIENTE { get; set; }

	[Column("cd_emp")]
	public int? CODIGO_EMPRESA { get; set; }

	[Column("nu_ped")]
	public int? NUMERO_PEDIDO { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("qtde_falta")]
	public decimal QUANTIDADE_FALTA { get; set; }

	[Column("unid_est")]
	public string UNIDADE_ESTOQUE { get; set; }

	[Column("preco_basico")]
	public decimal PRECO_BASICO { get; set; }

	[Column("cd_vend_lc")]
	public string CODIGO_VENDEDOR_LANCADOR { get; set; }

	[Column("preco_unit")]
	public decimal? PRECO_UNITARIO { get; set; }

	[Column("cd_tp_faltaprd")]
	public string CODIGO_TIPO_FALTA_PRODUTO { get; set; }

	[Column("unid_vda")]
	public string UNIDADE_VENDA { get; set; }

	[Column("qtde_falta_vda")]
	public decimal? QUANTIDADE_FALTA_VENDA { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("seq_acao_comercial")]
	public int? SEQ_ACAO_COMERCIAL { get; set; }

	[ForeignKey("CODIGO_EMPRESA, NUMERO_PEDIDO")]
	public PedidoVendaMO PEDIDO { get; set; }

	[NotMapped]
	public decimal SEQ_ITEM_PEDIDO { get; set; }

	[Column("CdEmpLocalEstoque")]
	public int? CODIGO_EMPRESA_LOCAL_ESTOQUE { get; set; }

	[Column("CdLocal")]
	public string CODIGO_LOCAL { get; set; }
}
