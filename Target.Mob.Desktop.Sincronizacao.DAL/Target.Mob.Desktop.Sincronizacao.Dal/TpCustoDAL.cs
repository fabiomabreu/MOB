using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class TpCustoDAL
{
	private const string SELECT = "uspTpCustoSelect";

	public static TpCustoTO[] Select(DbConnection connection, string TpCusto, string Descricao, bool? Contabil)
	{
		connection.ClearParameters();
		connection.AddParameters("@tp_custo", TpCusto);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@contabil", Contabil);
		connection.AddParameters("@rowid", null);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTpCustoSelect"));
	}

	public static TpCustoTO[] Select(DbConnection connection, string TpCusto, string Descricao, bool? Contabil, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@tp_custo", TpCusto);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@contabil", Contabil);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTpCustoSelect"));
	}

	private static TpCustoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TpCustoTO tpCustoTO = new TpCustoTO();
				tpCustoTO.TpCusto = rs.GetString("tp_custo");
				tpCustoTO.Descricao = rs.GetString("descricao");
				tpCustoTO.Contabil = rs.GetNullableInteger("contabil");
				tpCustoTO.RowID = rs.GetArrayByte("rowid");
				arrayList.Add(tpCustoTO);
			}
		}
		return (TpCustoTO[])arrayList.ToArray(typeof(TpCustoTO));
	}
}
