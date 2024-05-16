using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class LinhaDAL
{
	private const string SELECT = "uspLinhaSelect";

	public static LinhaTO[] Select(DbConnection connection, string CdLinha, string Descricao, bool? Ativo, bool? EnvioPalmTop, string CdCategPrd, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_linha", CdLinha);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@envio_palm_top", EnvioPalmTop);
		connection.AddParameters("@cd_CategPrd", CdCategPrd);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspLinhaSelect"));
	}

	private static LinhaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				LinhaTO linhaTO = new LinhaTO();
				linhaTO.CdLinha = rs.GetString("cd_linha");
				linhaTO.Descricao = rs.GetString("descricao");
				linhaTO.Ativo = rs.GetNullableBoolean("ativo");
				linhaTO.EnvioPalmTop = rs.GetNullableBoolean("envio_palm_top");
				linhaTO.CdCategprd = rs.GetString("cd_categprd");
				linhaTO.RowId = rs.GetArrayByte("rowid");
				arrayList.Add(linhaTO);
			}
		}
		return (LinhaTO[])arrayList.ToArray(typeof(LinhaTO));
	}
}
