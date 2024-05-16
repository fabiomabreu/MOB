using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class CategPrdDAL
{
	private const string SELECT = "uspCategPrdSelect";

	public static CategPrdTO[] Select(DbConnection connection, string CdCategPrd, string Descricao, bool? Ativo, bool? EnvioPalmTop, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_categPrd", CdCategPrd);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@envio_palm_top", EnvioPalmTop);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspCategPrdSelect"));
	}

	private static CategPrdTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CategPrdTO categPrdTO = new CategPrdTO();
				categPrdTO.CdCategPrd = rs.GetString("cd_categPrd");
				categPrdTO.Descricao = rs.GetString("descricao");
				categPrdTO.Ativo = rs.GetBoolean("ativo");
				categPrdTO.EnvioPalmTop = rs.GetNullableBoolean("envio_palm_top");
				categPrdTO.RowId = rs.GetArrayByte("rowid");
				arrayList.Add(categPrdTO);
			}
		}
		return (CategPrdTO[])arrayList.ToArray(typeof(CategPrdTO));
	}
}
