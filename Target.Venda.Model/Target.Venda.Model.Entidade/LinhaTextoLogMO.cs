using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("lin_txt_log")]
public class LinhaTextoLogMO : EntidadeBaseMO
{
	[Column("cd_texto_log", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CD_TEXTO_LOG { get; set; }

	[Column("cd_texto_orig", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CD_TEXTO_ORIG { get; set; }

	[Column("num_lin")]
	public int NUM_LIN { get; set; }

	[Column("texto")]
	public string TEXTO { get; set; }

	[Column("data")]
	public DateTime DATA { get; set; }

	[Column("cd_usuario")]
	public string CD_USUARIO { get; set; }
}
