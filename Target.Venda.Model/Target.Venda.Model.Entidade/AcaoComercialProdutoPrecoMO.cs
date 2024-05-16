using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("acao_comercial_prod_preco")]
public class AcaoComercialProdutoPrecoMO : EntidadeBaseMO
{
	[Column("seq_acao_comercial_prod_preco")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_ACAO_COMERCIAL_PRODUTO_PRECO { get; set; }

	[Column("seq_acao_comercial")]
	public int SEQ_ACAO_COMERCIAL { get; set; }

	[Column("cd_tabela")]
	public string CODIGO_TABELA { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("vl_preco_acao_com")]
	public decimal VALOR_PRECO_ACAO_COMERCIAL { get; set; }

	[Column("vl_preco_pos_acao_com")]
	public decimal VALOR_PRECO_POS_ACAO_COMERCIAL { get; set; }

	[ForeignKey("SEQ_ACAO_COMERCIAL")]
	public AcaoComercialMO ACAO_COMERCIAL { get; set; }
}
