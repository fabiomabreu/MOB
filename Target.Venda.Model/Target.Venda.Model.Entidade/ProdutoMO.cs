using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("Produto")]
public class ProdutoMO : EntidadeBaseMO
{
	[Column("cd_prod")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("cd_linha")]
	public string CODIGO_LINHA { get; set; }

	[Column("tp_prod")]
	public string TIPO_PRODUTO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("desc_resum")]
	public string DESCRICAO_RESUMIDA { get; set; }

	[Column("cd_barra")]
	public string CODIGO_BARRA { get; set; }

	[Column("cd_fabric")]
	public string CODIGO_FABRIC { get; set; }

	[Column("unid_est")]
	public string UNIDADE_ESTOQUE { get; set; }

	[Column("unid_cmp")]
	public string UNIDADE_COMPRA { get; set; }

	[Column("aliq_ipi")]
	public double? ALIQUOTA_IPI { get; set; }

	[Column("produzido")]
	public bool? PRODUZIDO { get; set; }

	[Column("ProdutoID")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int PRODUTO_ID { get; set; }

	[Column("desc_internacional")]
	public string DESCRICAO_INTERNACIONAL { get; set; }

	[Column("desc_nf")]
	public string DESCRICAO_NOTA_FISCAL { get; set; }

	[Column("controlado")]
	public bool? CONTROLADO { get; set; }

	[Column("controle_lote")]
	public bool? CONTROLE_LOTE { get; set; }

	[Column("peso_brt")]
	public decimal PESO_BRUTO { get; set; }

	[Column("pesado")]
	public BoolEnum? PESADO { get; set; }

	[Column("peso_liq")]
	public decimal PESO_LIQUIDO { get; set; }

	[Column("fardo")]
	public bool? FARDO { get; set; }

	[Column("inf_volumes")]
	public bool? INFO_VOLUMES { get; set; }

	[Column("volume")]
	public decimal? VOLUME { get; set; }

	[Column("prz_medio_max")]
	public int? PRAZO_MEDIO_MAX { get; set; }

	[Column("cd_grupo_prd")]
	public string CODIGO_GRUPO_PRODUTO { get; set; }

	[Column("venda_casada")]
	public BoolEnum? VENDA_CASADA { get; set; }

	[Column("lib_fiscal")]
	public bool? LIB_FISCAL { get; set; }

	[Column("vl_preco_minimo")]
	public decimal? VALOR_PRECO_MINIMO { get; set; }

	[Column("qtde_multipla")]
	public decimal? QUANTIDADE_MULTIPLA { get; set; }

	[ForeignKey("CODIGO_FABRIC")]
	public FabricanteMO FK_FABRICANTE { get; set; }

	public List<UnidadeProdutoMO> LISTA_UNIDADE_PRODUTO { get; set; }
}
