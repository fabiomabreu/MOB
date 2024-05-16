using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("verba_fabr_lc")]
public class VerbaFabricanteLancamentoMO : EntidadeBaseMO
{
	[Column("seq_verba_fabr_lc")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_VERBA_FABRICANTE_LANCAMENTO { get; set; }

	[Column("dt_criacao")]
	public DateTime DATA_CRIACAO { get; set; }

	[Column("cd_usuario")]
	public string CODIGO_USUARIO { get; set; }

	[Column("dt_lanc")]
	public DateTime DATA_LANCAMENTO { get; set; }

	[Column("cd_fabric")]
	public string CODIGO_FABRICANTE { get; set; }

	[Column("cd_verba_fabr_tp_lanc")]
	public string CODIGO_VERBA_FABRICANTE_TIPO_LANCAMENTO { get; set; }

	[Column("valor")]
	public decimal VALOR { get; set; }

	[Column("seq_acao_comercial")]
	public int? SEQ_ACAO_COMERCIAL { get; set; }

	[Column("cd_emp")]
	public int? CODIGO_EMPRESA { get; set; }

	[Column("nu_ped")]
	public int? NUMERO_PEDIDO { get; set; }

	[Column("seq_it_pedv")]
	public int? SEQ_ITEM_PEDIDO_VENDA { get; set; }

	[Column("nu_tit")]
	public int? NUMERO_TITULO { get; set; }

	[Column("serie")]
	public string SERIE { get; set; }

	[Column("cd_forn_compra")]
	public int? CODIGO_FORNECEDOR_COMPRA { get; set; }

	[Column("nu_nf_compra")]
	public int? NUMERO_NOTA_FISCAL_COMPRA { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("cd_texto")]
	public int? CD_TEXTO { get; set; }

	[Column("referencia")]
	public string REFERENCIA { get; set; }

	[Column("cd_prod")]
	public int? CODIGO_PRODUTO { get; set; }

	[Column("permite_consolidacao")]
	public bool? PERMITE_CONSOLIDACAO { get; set; }

	[Column("seq_verba_fabr_lc_cons")]
	public int? SEQ_VERBA_FABRICANTE_LANCAMENTO_CONS { get; set; }

	[Column("dt_canc")]
	public DateTime? DATA_CANCELAMENTO { get; set; }

	[Column("cd_usr_canc")]
	public string CODIGO_USUARIO_CANCELAMENTO { get; set; }

	[Column("nu_ped_compra")]
	public int? NUMERO_PEDIDO_COMPRA { get; set; }
}
