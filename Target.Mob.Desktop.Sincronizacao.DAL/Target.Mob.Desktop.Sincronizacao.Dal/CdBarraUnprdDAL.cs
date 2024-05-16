using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class CdBarraUnprdDAL
{
	private const string SELECT = "uspCdBarraUnprdSelect";

	public static CdBarraUnprdTO[] Select(DbConnection connection, byte[] rowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@rowid", rowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspCdBarraUnprdSelect"));
	}

	private static CdBarraUnprdTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CdBarraUnprdTO cdBarraUnprdTO = new CdBarraUnprdTO();
				cdBarraUnprdTO.CdProd = rs.GetNullableInteger("cd_prod");
				cdBarraUnprdTO.UnidVda = rs.GetString("unid_vda");
				cdBarraUnprdTO.Seq = rs.GetNullableInteger("seq");
				cdBarraUnprdTO.TpCdBarra = rs.GetString("tp_cd_barra");
				cdBarraUnprdTO.CdBarra = rs.GetString("cd_barra");
				cdBarraUnprdTO.Imprime = Convert.ToBoolean(rs.GetInteger("imprime"));
				cdBarraUnprdTO.Ativo = Convert.ToBoolean(rs.GetInteger("ativo"));
				cdBarraUnprdTO.RowId = rs.GetArrayByte("rowid");
				arrayList.Add(cdBarraUnprdTO);
			}
		}
		return (CdBarraUnprdTO[])arrayList.ToArray(typeof(CdBarraUnprdTO));
	}
}
