using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("cliente")]
public class ClienteMO : EntidadeBaseMO
{
	[Column("cd_clien")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_CLIENTE { get; set; }

	[Column("tp_cliente")]
	public string TIPO_CLIENTE { get; set; }

	[Column("nome")]
	public string NOME { get; set; }

	[Column("nome_res")]
	public string NOME_RESUMIDO { get; set; }

	[Column("tp_pes")]
	public string TIPO_PESSOA { get; set; }

	[Column("cgc_cpf")]
	public string CNPJ_CPF { get; set; }

	[Column("tp_inscr")]
	public string TIPO_INSCRICAO { get; set; }

	[Column("inscricao")]
	public string INSCRICAO { get; set; }

	[Column("ram_ativ")]
	public string RAMO_ATIVIDADE { get; set; }

	[Column("st_cred")]
	public string SITUACAO_CREDITO { get; set; }

	[Column("crt")]
	public string CODIGO_REGIME_TRIBUTARIO { get; set; }

	[Column("cd_grupocli")]
	public string CODIGO_GRUPO_CLIENTE { get; set; }

	[Column("cd_area")]
	public string CODIGO_AREA { get; set; }

	[Column("dt_cad")]
	public DateTime DATA_CADASTRO { get; set; }

	[Column("cd_vend")]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("cd_vend_tecnico")]
	public string CODIGO_VENDEDOR_TECNICO { get; set; }

	[Column("dt_ult_alt")]
	public DateTime? DATA_ULTIMA_ALTERACAO { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("estrangeiro")]
	public BoolEnum? ESTRANGEIRO { get; set; }

	[Column("area_livre_comercio")]
	public BoolEnum? AREA_LIVRE_COMERCIO { get; set; }

	[Column("suframa")]
	public BoolEnum? SUFRAMA { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("desconto")]
	public decimal? DESCONTO { get; set; }

	[Column("cd_texto_alerta")]
	public int? CODIGO_TEXTO_ALERTA { get; set; }

	[Column("cd_texto_expe")]
	public int? CODIGO_TEXTO_EXPEDICAO { get; set; }

	[Column("perc_comis")]
	public decimal? PERCENTUAL_COMISSAO { get; set; }

	[Column("prod_controlado")]
	public BoolEnum? PRODUTO_CONTROLADO { get; set; }

	[Column("dt_val_prod_controlado")]
	public DateTime? DATA_VALIDADE_PRODUTO_CONTROLADO { get; set; }

	[Column("dias_prorr_venc")]
	public byte? DIAS_PRORROGACAO_VENCIMENTO { get; set; }

	[Column("cd_rot_prdf")]
	public string CODIGO_ROTA { get; set; }

	[Column("nao_fat_maior_un")]
	public BoolEnum? NAO_FATURAR_MAIOR_UNIDADE { get; set; }

	[Column("perc_desc_fin_auto")]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO_AUTO { get; set; }

	[Column("seq_trib_cli")]
	public int? SEQ_TRIBUTACAO_CLIENTE { get; set; }

	[Column("cd_coligacao")]
	public string CODIGO_COLIGACAO { get; set; }

	[Column("cd_forn")]
	public int? CODIGO_FORNECEDOR { get; set; }

	[Column("tp_frete")]
	public string TIPO_FRETE { get; set; }

	[Column("ATIVO")]
	public bool? ATIVO { get; set; }

	[Column("PrecoVenda4Dec")]
	public bool PRECO_VENDA_4_DEC { get; set; }

	public List<ClienteEmpresaMO> EMPRESAS { get; set; }

	public List<EnderecoClienteMO> ENDERECOS { get; set; }

	public List<ClienteEmpresaFormaPagamentoMO> FORMAS_PAGAMENTO { get; set; }

	public TributacaoClienteMO TRIBUTACAO { get; set; }

	public List<ClienteDiaVencimentoMO> CLIENTE_DIA_VENCIMENTO { get; set; }
}
