using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("vendedor")]
public class VendedorMO : EntidadeBaseMO
{
	[Column("CD_vend")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("CD_emp")]
	public int CODIGO_EMPRESA { get; set; }

	[Column("CD_equipe")]
	public string CODIGO_EQUIPE { get; set; }

	[ForeignKey("CODIGO_EMPRESA, CODIGO_EQUIPE")]
	public EquipeMO EQUIPE { get; set; }

	[Column("nome")]
	public string NOME { get; set; }

	[Column("nome_gue")]
	public string NOME_GUERRA { get; set; }

	[Column("categ")]
	public string CATEGORIA { get; set; }

	[Column("CD_grupo")]
	public string CODIGO_GRUPO { get; set; }

	[Column("ramal_emp")]
	public int? RAMAL_EMPRESA { get; set; }

	[Column("vda_periodo")]
	public decimal? VENDA_PERIODO { get; set; }

	[Column("end_res")]
	public string ENDERECO_RESIDENCIAL { get; set; }

	[Column("bairro_res")]
	public string BAIRRO_RESIDENCIAL { get; set; }

	[Column("munic_res")]
	public string MUNICIPIO_RESIDENCIAL { get; set; }

	[Column("est_res")]
	public string ESTADO_RESIDENCIAL { get; set; }

	[Column("cep_res")]
	public int? CEP_RESIDENCIAL { get; set; }

	[Column("perc_desc")]
	public decimal? PERCENTUAL_DESCONTO { get; set; }

	[Column("seq_crgprd")]
	public int? SEQ_CRG_PRODUTO { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("cgc")]
	public string CGC { get; set; }

	[Column("inscricao")]
	public string INSCRICAO { get; set; }

	[Column("perc_ir")]
	public decimal? PERCENTUAL_IR { get; set; }

	[Column("tp_pes")]
	public string TIPO_PESSOA { get; set; }

	[Column("cd_vend_res")]
	public int? CODIGO_VENDEDOR_RES { get; set; }

	[Column("e_mail")]
	public string E_MAIL { get; set; }

	[Column("perc_desc_absoluto")]
	public decimal? PERCENTUAL_DESCONTO_ABSOLUTO { get; set; }

	[Column("perc_desc_adicional")]
	public decimal? PERCENTUAL_DESCONTO_ADICIONAL { get; set; }

	[Column("vl_troca_mes")]
	public decimal? VALOR_TROCA_MES { get; set; }

	[Column("desc_item")]
	public decimal? DESC_ITEM { get; set; }

	[Column("qtde_cli_carteira")]
	public int? QTDE_CLI_CARTEIRA { get; set; }

	[Column("vl_limite_verba")]
	public decimal? VALOR_LIMITE_VERBA { get; set; }

	[Column("CD_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("dt_admissao")]
	public DateTime? DATA_ADMISSAO { get; set; }

	[Column("CD_forn")]
	public int? CODIGO_FORNECEDOR { get; set; }

	[Column("enviar_tp_discagem")]
	public bool? ENVIAR_TIPO_DISCAGEM { get; set; }

	[Column("qtde_max_visitas_dia")]
	public int? QUANTIDADE_MAX_VISITAS_DIA { get; set; }

	[Column("tecnico")]
	public bool? TECNICO { get; set; }

	[Column("CD_cep_munic")]
	public int? CODIGO_CEP_MUNICIPIO { get; set; }

	[Column("logradouro")]
	public string LOGRADOURO { get; set; }

	[Column("numero")]
	public string NUMERO { get; set; }

	[Column("complemento")]
	public string COMPLEMENTO { get; set; }

	[Column("CD_pais")]
	public string CODIGO_PAIS { get; set; }

	[Column("distrito_res")]
	public string DISTRITO_RESIDENCIAL { get; set; }

	[Column("VendedorID")]
	public int VENDEDOR_ID { get; set; }
}
