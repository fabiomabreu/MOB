using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("motlcverba")]
public class MotivoLancamentoVerbaMO : EntidadeBaseMO
{
	[Column("cd_motlcverba")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_MOTIVO_LANCAMENTO_VERBA { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("tipo_dc")]
	public string TIPO_DOCUMENTO { get; set; }

	[Column("automatico")]
	public BoolEnum AUTOMATICO { get; set; }

	[Column("ativo")]
	public BoolEnum ATIVO { get; set; }

	[Column("transferencia")]
	public bool? TRANSFERENCIA { get; set; }
}
