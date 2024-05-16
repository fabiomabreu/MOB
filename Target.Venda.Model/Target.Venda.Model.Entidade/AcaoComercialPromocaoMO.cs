using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("acao_comercial_prom")]
public class AcaoComercialPromocaoMO : EntidadeBaseMO
{
	[Column("seq_acao_comercial_prom")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_ACAO_COMERCIAL_PROMOCAO { get; set; }

	[Column("seq_acao_comercial")]
	public int SEQ_ACAO_COMERCIAL { get; set; }

	[Column("seq_kit")]
	public int SEQ_KIT { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("bonificado")]
	public bool BONIFICADO { get; set; }

	[Column("verba_fabr_bonif")]
	public bool VERBA_FABRICANTE_BONIFICADO { get; set; }

	[Column("vl_verba_fabr")]
	public decimal VALOR_VERBA_FABRICANTE { get; set; }

	[ForeignKey("SEQ_ACAO_COMERCIAL")]
	public AcaoComercialMO ACAO_COMERCIAL { get; set; }
}
