using System;

namespace Target.Mob.Desktop.Geracao.Model;

public class CargaTemplateSqlTO
{
	public int idCargaTemplateSql { get; set; }

	public string nomeTemplateSql { get; set; }

	public string scriptTemplateSql { get; set; }

	public DateTime data { get; set; }

	public byte[] rowid { get; set; }
}
