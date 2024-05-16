using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class PcfgTelaMultiDAL
{
	private const string SELECT_BY_ID = "uspPcfgTelaMultiSelect";

	public static List<PcfgTelaMultiTO> SelectById(DbConnection connection, PcfgTelaMultiTO model)
	{
		connection.ClearParameters();
		connection.AddParameters("@CdTela", model.CdTela);
		connection.AddParameters("@Seq", model.Seq);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPcfgTelaMultiSelect"));
	}

	private static List<PcfgTelaMultiTO> CreateInstances(BasicRS rs)
	{
		List<PcfgTelaMultiTO> list = new List<PcfgTelaMultiTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PcfgTelaMultiTO pcfgTelaMultiTO = new PcfgTelaMultiTO();
				pcfgTelaMultiTO.CdTela = rs.GetString("CdTela");
				pcfgTelaMultiTO.Seq = rs.GetInteger("Seq");
				pcfgTelaMultiTO.Descricao = rs.GetString("Descricao");
				pcfgTelaMultiTO.Tipo = rs.GetString("Tipo");
				pcfgTelaMultiTO.Texto = rs.GetString("Texto");
				pcfgTelaMultiTO.Data = rs.GetNullableDateTime("Data");
				pcfgTelaMultiTO.Numero = rs.GetNullableDecimal("Numero");
				pcfgTelaMultiTO.Ativo = rs.GetNullableBoolean("Ativo");
				pcfgTelaMultiTO.Versao = rs.GetString("Versao");
				pcfgTelaMultiTO.PcfgTelaMultiId = rs.GetInteger("PcfgTelaMultiId");
				pcfgTelaMultiTO.RowId = rs.GetArrayByte("RowId");
				list.Add(pcfgTelaMultiTO);
			}
			return list;
		}
	}
}
