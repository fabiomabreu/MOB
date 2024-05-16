using System;

namespace Target.Mob.Desktop.Api.Model;

public class IndenizacaoHistoricoTO
{
	public int? IndenizacaoHistoricoID { get; set; }

	public int? IndenizacaoID { get; set; }

	public int? IndenizacaoStatusID { get; set; }

	public string CdUsuario { get; set; }

	public DateTime? Data { get; set; }

	public int? IndenizacaoMotivoID { get; set; }

	public IndenizacaoHistoricoTO()
	{
	}

	public IndenizacaoHistoricoTO(int indenizacaoID)
	{
		IndenizacaoID = indenizacaoID;
	}
}
