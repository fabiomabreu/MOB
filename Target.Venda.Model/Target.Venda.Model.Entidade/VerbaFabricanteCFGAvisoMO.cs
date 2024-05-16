using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("verba_fabr_cfg_avisos")]
public class VerbaFabricanteCFGAvisoMO : EntidadeBaseMO
{
	[Column("cd_usuario")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_USUARIO { get; set; }

	[Column("seq_email_conta")]
	public short SEQ_EMAIL_CONTA { get; set; }
}
