using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class TpPedDAL
{
	private const string SELECT = "uspTpPedSelect";

	public static TpPedTO[] Select(DbConnection connection, TpPedTO tpPed)
	{
		connection.ClearParameters();
		connection.AddParameters("@tp_ped", tpPed.TpPed);
		connection.AddParameters("@descricao", tpPed.Descricao);
		connection.AddParameters("@bonificacao", tpPed.Bonificacao);
		connection.AddParameters("@estat_com", tpPed.EstatCom);
		connection.AddParameters("@ativo", tpPed.Ativo);
		connection.AddParameters("@rowid", tpPed.RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTpPedSelect"));
	}

	private static TpPedTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TpPedTO tpPedTO = new TpPedTO();
				tpPedTO.TpPed = rs.GetString("tp_ped");
				tpPedTO.Descricao = rs.GetString("descricao");
				tpPedTO.Bonificacao = rs.GetNullableBoolean("bonificacao");
				tpPedTO.Ativo = rs.GetInteger("ativo");
				tpPedTO.EstatCom = rs.GetNullableBoolean("estat_com");
				tpPedTO.RowId = rs.GetArrayByte("rowid");
				arrayList.Add(tpPedTO);
			}
		}
		return (TpPedTO[])arrayList.ToArray(typeof(TpPedTO));
	}
}
