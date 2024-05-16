using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class ComoRealizouVendaDAL
{
	private const string SELECT = "uspComoRealizouVendaSelect";

	public static List<ComoRealizouVendaTO> Select(DbConnection connection, ComoRealizouVendaTO comoRealizouVenda)
	{
		connection.ClearParameters();
		connection.AddParameters("@ComoRealizouVendaId", comoRealizouVenda.ComoRealizouVendaId);
		connection.AddParameters("@Descricao", comoRealizouVenda.Descricao);
		connection.AddParameters("@RowId", comoRealizouVenda.RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspComoRealizouVendaSelect"));
	}

	private static List<ComoRealizouVendaTO> CreateInstances(BasicRS rs)
	{
		List<ComoRealizouVendaTO> list = new List<ComoRealizouVendaTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ComoRealizouVendaTO comoRealizouVendaTO = new ComoRealizouVendaTO();
				comoRealizouVendaTO.ComoRealizouVendaId = rs.GetNullableInteger("ComoRealizouVendaId");
				comoRealizouVendaTO.Descricao = rs.GetString("Descricao");
				comoRealizouVendaTO.RowId = rs.GetArrayByte("RowId");
				list.Add(comoRealizouVendaTO);
			}
			return list;
		}
	}
}
