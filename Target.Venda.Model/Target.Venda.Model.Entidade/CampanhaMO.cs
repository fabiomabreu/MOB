using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("Campanha")]
public class CampanhaMO : EntidadeBaseMO
{
	[Column("CampanhaID")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CAMPANHAID { get; set; }

	[Column("DescCampanha")]
	public string DESCCAMPANHA { get; set; }

	[Column("DtInicio")]
	public DateTime DTINICIO { get; set; }

	[Column("DtFim")]
	public DateTime DTFIM { get; set; }

	[Column("VlTicketMinimo")]
	public int VLTICKETMINIMO { get; set; }

	[Column("Flexivel")]
	public bool FLEXIVEL { get; set; }

	[Column("Ativo")]
	public bool ATIVO { get; set; }
}
