using System.Collections.Generic;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class CargaTemplateSqlBLL
{
	internal static List<CargaTemplateSqlTO> Select(string connStringTargetERP)
	{
		return CargaTemplateSqlDAL.Select(connStringTargetERP);
	}
}
