using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("calend")]
public class CalendarioMO : EntidadeBaseMO
{
	[Column("data", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public DateTime DATA { get; set; }

	[Column("cd_emp", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIOGO_EMPRESA { get; set; }

	[Column("util")]
	public bool UTIL { get; set; }

	[Column("horario_ini")]
	public DateTime HORARIO_INICIO { get; set; }

	[Column("horario_fim")]
	public DateTime HORARIO_FIM { get; set; }

	[Column("DiaSemanaID")]
	public short ID_DIA_SEMANA { get; set; }
}
