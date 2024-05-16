using Target.Venda.Model.Enum;

namespace Target.Venda.Model.Visao;

public class ConfiguracaoVO
{
	public int CODIGO_EMPRESA { get; set; }

	public bool PERM_PED_VDA_END_DESATU { get; set; }

	public bool FORMPGTO_BANCO_TPED_VS { get; set; }

	public bool FORMA_PAGTO_ASSOC_CLIEN { get; set; }

	public bool UTILIZA_NFE { get; set; }

	public bool UTILIZA_SIT_TRIB_ESP_TP_PED { get; set; }

	public OrigemVolumePedidoEnum VOL_PEDVDA_ORIGEM { get; set; }

	public TipoVolumePedidoEnum VOL_PEDVDA_TIPO { get; set; }

	public bool VOLPEDVDAOBRIGARINFORMACAO { get; set; }

	public bool FILA_SEPARACAO { get; set; }

	public string TP_DESC_FIN_AUTO { get; set; }

	public bool DESC_FIN_TOT_NF { get; set; }

	public short NU_DIAS_DESC_FIN_AUTO { get; set; }

	public bool UNID_PEDIDA { get; set; }

	public bool UNID_VDA_VAR { get; set; }

	public bool DESCONTO_POR_QUANTIDADE { get; set; }

	public bool ACRESCIMO_DIF_ICM { get; set; }

	public bool TITREC_PROX_DIA_UTIL { get; set; }

	public bool UTILIZA_FRETE_ESTADO { get; set; }

	public bool ACRESCIMO_FRETE { get; set; }

	public bool FRETE_UTILIZA_REGTRANS { get; set; }

	public string TIPO_RATEIO_FRETE { get; set; }

	public short QTDE_DEF_REGIAO { get; set; }

	public string TP_VL_BASE_COMISSAO { get; set; }

	public bool COMIS_CLIEN { get; set; }

	public decimal VERBA_PERC_CRED { get; set; }

	public decimal VERBA_PERC_CRED_EMP { get; set; }

	public decimal VERBA_PERC_CRED_EQUIP { get; set; }

	public string VERBA_TP_LANC { get; set; }

	public bool DESC_GERAL_RED_COMIS { get; set; }

	public string TP_REDUTOR_COMISSAO { get; set; }

	public string TP_CUSTO_COMIS_MG { get; set; }

	public bool UTILIZA_COMIS_RT { get; set; }

	public bool DESCITEM_BLQ_PEDVDA { get; set; }

	public bool BLOQ_NF_PF { get; set; }

	public bool PEDIDO_PF_X_PJ { get; set; }

	public decimal PERC_PEDIDO_PF_X_PJ { get; set; }

	public bool UTIL_CONTROLE_GRUPO_PRODUTO { get; set; }

	public bool UTILIZA_GRADE_DESC { get; set; }

	public bool NF_ITEM_BONIF_VALOR_VDA { get; set; }

	public string LANC_CRED_VERBA { get; set; }

	public bool MG_BRUTA_DESC_FIN { get; set; }

	public string CRED_VERBA_FABR_NEG_IND { get; set; }

	public bool IND_PRODPAPEL { get; set; }

	public bool VERBA_FABR_ENC_ITEM_ESTOQUE { get; set; }

	public string SIGLA_CLIENTE { get; set; }

	public bool PRECO_VENDA_4_DEC { get; set; }

	public bool PRECO_VENDA_4_DEC_CLIENTE { get; set; }

	public int PRECO_VENDA_4_DEC_QTDE { get; set; }

	public string VERBA_FABR_TP_CUSTO_BONIF { get; set; }

	public bool UTILIZA_WMS { get; set; }

	public bool CONSIDERA_PRAZO_MEDIO_PROM { get; set; }

	public bool SUBST_TRIB_MAIOR_VALOR { get; set; }

	public bool VDA_PF_FE_REDICM { get; set; }

	public bool DESCGERALPROD { get; set; }

	public bool DESCGERALNAORECALCULACORTE { get; set; }

	public bool UTILIZA_CAMPANHA { get; set; }

	public bool CAMPANHA_UTILIZA_FILA_APUR { get; set; }

	public bool CANCPEDVLMINORIGPED { get; set; }

	public bool TPPEDBONIFICACAOVALORZERO { get; set; }
}
