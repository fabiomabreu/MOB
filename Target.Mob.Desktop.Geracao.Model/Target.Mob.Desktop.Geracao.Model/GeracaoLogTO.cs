using System;
using Target.Mob.Desktop.Geracao.Enum;

namespace Target.Mob.Desktop.Geracao.Model;

public class GeracaoLogTO
{
	public int Id { get; set; }

	public DateTime DataInicio { get; set; }

	public DateTime? DataFim { get; set; }

	public StatusGeracaoTR IdStatusGeracaoTR { get; set; }

	public string Erro { get; set; }

	public bool MultiThread { get; set; }

	public string Versao { get; set; }

	public int VersaoMajor { get; set; }

	public int VersaoMinor { get; set; }

	public string Etapa { get; set; }
}
