using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class TipoGrupoDAL
{
	private const string INSERT = "uspTipoGrupoIns";

	private const string UPDATE = "uspTipoGrupoUpd";

	private const string DELETE = "uspTipoGrupoDel";

	private const string SELECT = "uspTipoGrupoSel";

	private const string EXISTS = "uspTipoGrupoSelId";

	private const string COUNT = "";

	public static void Insert(DbConnection connection, TipoGrupoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDTipoGrupo", instance.IdTipoGrupo);
		connection.AddParameters("@Descricao", instance.Descricao);
		connection.AddParameters("@Ativo", instance.Ativo);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspTipoGrupoIns");
	}

	public static void Update(DbConnection connection, TipoGrupoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupo", instance.IdTipoGrupo);
		connection.AddParameters("@Descricao", instance.Descricao);
		connection.AddParameters("@Ativo", instance.Ativo);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTipoGrupoUpd");
	}

	public static void Delete(DbConnection connection, TipoGrupoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupo", instance.IdTipoGrupo);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTipoGrupoDel");
	}

	public static TipoGrupoTO[] Select(DbConnection connection, int? IdTipoGrupo)
	{
		return Select(connection, IdTipoGrupo, null, null);
	}

	public static TipoGrupoTO[] Select(DbConnection connection, int? IdTipoGrupo, string Descricao, bool? Ativo)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupo", IdTipoGrupo);
		connection.AddParameters("@Descricao", Descricao);
		connection.AddParameters("@Ativo", Ativo);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTipoGrupoSel"));
	}

	public static bool Exists(DbConnection connection, int? IdTipoGrupo)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupo", IdTipoGrupo);
		return connection.ExecuteScalar(CommandType.StoredProcedure, "uspTipoGrupoSelId") != null;
	}

	public static int Count(DbConnection connection, int? IdTipoGrupo, string Descricao, bool? Ativo)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupo", IdTipoGrupo);
		connection.AddParameters("@Descricao", Descricao);
		connection.AddParameters("@Ativo", Ativo);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, ""));
	}

	private static TipoGrupoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TipoGrupoTO tipoGrupoTO = new TipoGrupoTO();
				tipoGrupoTO.IdTipoGrupo = rs.GetInteger("IdTipoGrupo");
				tipoGrupoTO.Descricao = rs.GetString("Descricao");
				tipoGrupoTO.Ativo = rs.GetNullableBoolean("Ativo");
				arrayList.Add(tipoGrupoTO);
			}
		}
		return (TipoGrupoTO[])arrayList.ToArray(typeof(TipoGrupoTO));
	}
}
