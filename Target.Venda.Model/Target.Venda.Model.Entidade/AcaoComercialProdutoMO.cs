using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("acao_comercial_prod")]
public class AcaoComercialProdutoMO : EntidadeBaseMO
{
	[Column("seq_acao_comercial_prod")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_ACAO_COMERCIAL_PRODUTO { get; set; }

	[Column("seq_acao_comercial")]
	public int SEQ_ACAO_COMERCIAL { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("vl_verba_fabr")]
	public decimal VALOR_VERBA_FABRICANTE { get; set; }

	[Column("qtde_limite")]
	public int? QUANTIDADE_LIMITE { get; set; }

	[Column("item_encerrado")]
	public bool ITEM_ENCERRADO { get; set; }

	[ForeignKey("SEQ_ACAO_COMERCIAL")]
	public AcaoComercialMO ACAO_COMERCIAL { get; set; }
}
