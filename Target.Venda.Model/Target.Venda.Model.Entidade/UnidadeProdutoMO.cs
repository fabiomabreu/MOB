using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("unid_prod")]
public class UnidadeProdutoMO : EntidadeBaseMO
{
	[Column("cd_prod", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("unid_vda", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string UNIDADE_VENDA { get; set; }

	[Column("principal")]
	public BoolEnum PRINCIPAL { get; set; }

	[Column("qtde_unid")]
	public decimal? QUANTIDADE_UNIDADE { get; set; }

	[Column("fator_preco")]
	public decimal? FATOR_PRECO { get; set; }

	[Column("ind_relacao")]
	public string INDICE_RELACAO { get; set; }

	[Column("fator_estoque")]
	public decimal? FATOR_ESTOQUE { get; set; }

	[Column("ativo")]
	public BoolEnum ATIVO { get; set; }

	[Column("ordem")]
	public int? ORDEM { get; set; }

	[Column("venda")]
	public BoolEnum VENDA { get; set; }

	[Column("pedida")]
	public BoolEnum PEDIDA { get; set; }

	[Column("separacao_fixa")]
	public BoolEnum? SEPARACAO_FIXA { get; set; }

	[Column("pront_ent")]
	public BoolEnum? PRONTA_ENTREGA { get; set; }

	[Column("formadora_preco")]
	public BoolEnum? FORMADORA_PRECO { get; set; }

	[Column("inventario")]
	public BoolEnum? INVENTARIO { get; set; }

	[Column("descricao_pdv")]
	public string DESCRICAO_PDV { get; set; }

	[Column("fator_estoque_direto")]
	public decimal? FATOR_ESTOQUE_DIRETO { get; set; }
}
