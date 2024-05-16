using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class AtualizacaoMovimentoDAL
{
	private const string INSERT = "uspAtualizacaoMovimentoInsert";

	private const string UPDATE = "uspAtualizacaoMovimentoUpdate";

	private const string DELETE = "uspAtualizacaoMovimentoDelete";

	private const string SELECT = "uspAtualizacaoMovimentoSelect";

	private const string EXISTS = "uspAtualizacaoMovimentoExists";

	public static void Insert(DbConnection connection, AtualizacaoMovimentoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@ID", instance.ID);
		connection.AddParameters("@Tabela", instance.Tabela);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspAtualizacaoMovimentoInsert");
	}

	public static void Update(DbConnection connection, AtualizacaoMovimentoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@ID", instance.ID);
		connection.AddParameters("@Tabela", instance.Tabela);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAtualizacaoMovimentoUpdate");
	}

	public static void Delete(DbConnection connection, AtualizacaoMovimentoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@ID)", instance.ID);
		connection.AddParameters("@Tabela", instance.Tabela);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAtualizacaoMovimentoDelete");
	}

	public static AtualizacaoMovimentoTO[] Select(DbConnection connection, int ID, string Tabela)
	{
		return Select(connection, ID, Tabela);
	}

	public static bool Exists(DbConnection connection, string Tabela)
	{
		connection.ClearParameters();
		connection.AddParameters("@Tabela", Tabela);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAtualizacaoMovimentoExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static AtualizacaoMovimentoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AtualizacaoMovimentoTO atualizacaoMovimentoTO = new AtualizacaoMovimentoTO();
				atualizacaoMovimentoTO.ID = rs.GetInteger("ID");
				atualizacaoMovimentoTO.Tabela = rs.GetString("Tabela");
				arrayList.Add(atualizacaoMovimentoTO);
			}
		}
		return (AtualizacaoMovimentoTO[])arrayList.ToArray(typeof(AtualizacaoMovimentoTO));
	}
}
