using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class FabricDAL
{
	private const string SELECT = "uspFabricSelect";

	public static FabricTO[] Select(DbConnection connection, string CdFabric, string Descricao, bool? Ativo, bool? EnvioPalmTop, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_fabric", CdFabric);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@envio_palm_top", EnvioPalmTop);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspFabricSelect"));
	}

	private static FabricTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				FabricTO fabricTO = new FabricTO();
				fabricTO.CdFabric = rs.GetString("cd_fabric");
				fabricTO.Descricao = rs.GetString("descricao");
				fabricTO.Ativo = rs.GetNullableBoolean("ativo");
				fabricTO.EnvioPalmTop = rs.GetNullableBoolean("envio_palm_top");
				fabricTO.RowId = rs.GetArrayByte("rowid");
				arrayList.Add(fabricTO);
			}
		}
		return (FabricTO[])arrayList.ToArray(typeof(FabricTO));
	}
}
