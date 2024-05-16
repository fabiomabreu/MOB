using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("verba_fabr_tp_lanc")]
public class VerbaFabricanteTipoLancamentoMO : EntidadeBaseMO
{
	[Column("cd_verba_fabr_tp_lanc")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_VERBA_FABRICANTE_TIPO_LANCAMENTO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("automatico")]
	public bool AUTOMATICO { get; set; }

	[Column("tipo")]
	public string TIPO { get; set; }

	[Column("ativo")]
	public bool ATIVO { get; set; }

	[Column("cd_verba_fabr_tp_cred")]
	public string CODIGO_VERBA_FABRICANTE_TIPO_CREDITO { get; set; }

	[Column("permite_cancelamento")]
	public bool PERMITE_CANCELAMENTO { get; set; }

	[Column("permite_consolidacao")]
	public bool PERMITE_CONSOLIDACAO { get; set; }

	[Column("cd_verba_fabr_tp_lanc_cons")]
	public string CODIGO_VERBA_FABRICANTE_TIPO_LANCAMENTO_CONS { get; set; }
}
