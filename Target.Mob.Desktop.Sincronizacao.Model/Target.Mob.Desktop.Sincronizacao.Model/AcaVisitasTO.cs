using System;
using System.Linq;
using System.Reflection;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class AcaVisitasTO : ICloneable
{
	public int SeqVisita { get; set; }

	public string CdVend { get; set; }

	public int CdClien { get; set; }

	public DateTime DtVisita { get; set; }

	public string HrVisita { get; set; }

	public DateTime? DtUltVisita { get; set; }

	public byte[] RowId { get; set; }

	public bool? VisitaExcluida { get; set; }

	public int? FrequenciaVisitaID { get; set; }

	public string TipoOperacao { get; set; }

	public string CdTpFreqVisita { get; set; }

	public string OpcoesRota { get; set; }

	public bool? VisitaTelefonica { get; set; }

	public object Clone()
	{
		AcaVisitasTO acaVisitasTO = new AcaVisitasTO();
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo item in properties)
		{
			object value = item.GetValue(this, null);
			acaVisitasTO.GetType().GetProperties().ToList()
				.Find((PropertyInfo x) => x.Name == item.Name)
				.SetValue(acaVisitasTO, value, null);
		}
		return acaVisitasTO;
	}
}
