using System;
using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class MPAgendaDAL
{
	private const string SELECT_EXPORT = "uspMPAgendaSelectExport";

	public static List<MPAgendaTO> SelectExport(DbConnection connection, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@RowId", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspMPAgendaSelectExport"));
	}

	public static List<MPAgendaTO> Select(DbConnection connection, MPAgendaTO model)
	{
		throw new NotImplementedException();
	}

	private static List<MPAgendaTO> CreateInstances(BasicRS rs)
	{
		List<MPAgendaTO> list = new List<MPAgendaTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				MPAgendaTO mPAgendaTO = new MPAgendaTO();
				mPAgendaTO.SeqVisita = rs.GetInteger("SeqVisita");
				mPAgendaTO.PromotorId = rs.GetInteger("PromotorId");
				mPAgendaTO.CodigoCliente = rs.GetInteger("CodigoCliente");
				mPAgendaTO.DtVisita = rs.GetDateTime("DtVisita");
				mPAgendaTO.HrVisita = rs.GetString("HrVisita");
				mPAgendaTO.DtUltVisita = rs.GetNullableDateTime("DtUltVisita");
				mPAgendaTO.VisitaExcluida = rs.GetNullableBoolean("VisitaExcluida");
				mPAgendaTO.FrequenciaVisitaId = rs.GetInteger("FrequenciaVisitaId");
				mPAgendaTO.VisitaTelefonica = rs.GetNullableBoolean("VisitaTelefonica");
				mPAgendaTO.OpcoesRota = rs.GetString("OpcoesRota");
				mPAgendaTO.RowId = rs.GetArrayByte("RowId");
				list.Add(mPAgendaTO);
			}
			return list;
		}
	}
}
