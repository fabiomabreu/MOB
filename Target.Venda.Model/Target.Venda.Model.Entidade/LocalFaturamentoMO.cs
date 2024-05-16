using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("local_fatu")]
public class LocalFaturamentoMO : EntidadeBaseMO
{
	[Column("seq_lc_fatu")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_LOCAL_FATURAMENTO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("ativo")]
	public BoolEnum? ATIVO { get; set; }
}
