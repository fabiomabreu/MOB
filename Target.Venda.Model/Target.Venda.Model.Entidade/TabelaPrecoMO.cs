using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("tab_pre")]
public class TabelaPrecoMO : EntidadeBaseMO
{
	[Key]
	[Column("cd_tabela")]
	public string CD_TABELA { get; set; }

	[Column("dt_cad")]
	public DateTime DT_CAD { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("venda_especial")]
	public BoolEnum? VENDA_ESPECIAL { get; set; }

	[Column("cd_tabela_ant")]
	public string CD_TABELA_ANT { get; set; }

	[Column("cd_tabela_prox")]
	public string CD_TABELA_PROX { get; set; }

	[Column("desc_embutido")]
	public decimal? DESC_EMBUTIDO { get; set; }

	[Column("dt_validade")]
	public DateTime? DT_VALIDADE { get; set; }

	[Column("tp_entrega")]
	public string TP_ENTREGA { get; set; }

	[Column("nf_imp_desc_itens")]
	public BoolEnum? NF_IMP_DESC_ITENS { get; set; }

	[Column("estado")]
	public string ESTADO { get; set; }

	[Column("arq_consys")]
	public BoolEnum? ARQ_CONSYS { get; set; }

	[Column("cd_tab_pre_categ")]
	public string CD_TAB_PRE_CATEG { get; set; }

	[Column("nf_preco_cheio_desc_bol")]
	public BoolEnum? NF_PRECO_CHEIO_DESC_BOL { get; set; }

	[Column("cd_texto")]
	public int? CD_TEXTO { get; set; }
}
