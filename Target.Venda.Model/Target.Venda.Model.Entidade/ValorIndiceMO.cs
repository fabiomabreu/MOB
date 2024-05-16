using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("vlindice")]
public class ValorIndiceMO : EntidadeBaseMO
{
	[Column("cd_indice", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_INDICE { get; set; }

	[Column("sequencia", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQUENCIA { get; set; }

	[Column("dt_inicial")]
	public DateTime DATA_INICIAL { get; set; }

	[Column("valor")]
	public double VALOR { get; set; }

	[Column("ativo")]
	public bool ATIVO { get; set; }
}
