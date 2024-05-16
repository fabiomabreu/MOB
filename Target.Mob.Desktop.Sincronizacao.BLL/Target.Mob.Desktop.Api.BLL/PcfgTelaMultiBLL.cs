using System.Collections.Generic;
using System.Linq;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.BLL;

public class PcfgTelaMultiBLL
{
	private static PcfgTelaMultiTO SelectById(DbConnection connection, PcfgTelaMultiTO model)
	{
		List<PcfgTelaMultiTO> list = PcfgTelaMultiDAL.SelectById(connection, model);
		if (list.Count == 1)
		{
			return list.First();
		}
		return null;
	}

	public static string getDiretorioRaizDeArquivoDeCliente(DbConnection connection)
	{
		PcfgTelaMultiTO pcfgTelaMultiTO = new PcfgTelaMultiTO();
		pcfgTelaMultiTO.CdTela = "CLIENTE";
		pcfgTelaMultiTO.Seq = 4;
		return SelectById(connection, pcfgTelaMultiTO)?.Texto;
	}
}
