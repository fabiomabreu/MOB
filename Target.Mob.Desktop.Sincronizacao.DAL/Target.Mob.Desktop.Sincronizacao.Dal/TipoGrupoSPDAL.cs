using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class TipoGrupoSPDAL
{
	private const string INSERT = "uspTipoGrupoSPIns";

	private const string UPDATE = "uspTipoGrupoSPUpd";

	private const string DELETE = "uspTipoGrupoSPDel";

	private const string SELECT = "uspTipoGrupoSPSel";

	private const string EXISTS = "uspTipoGrupoSPSel";

	private const string COUNT = "";

	public static void Insert(DbConnection connection, TipoGrupoSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupo", instance.IDTipoGrupo);
		connection.AddParameters("@IDCadastroSP", instance.IDCadastroSP);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspTipoGrupoSPIns");
	}

	public static void Update(DbConnection connection, TipoGrupoSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupoSP", instance.IDTipoGrupoSP);
		connection.AddParameters("@IdTipoGrupo", instance.IDTipoGrupo);
		connection.AddParameters("@IDCadastroSP", instance.IDCadastroSP);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTipoGrupoSPUpd");
	}

	public static void Delete(DbConnection connection, TipoGrupoSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDTipoGrupoSP", instance.IDTipoGrupoSP);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTipoGrupoSPDel");
	}

	public static TipoGrupoSPTO[] Select(DbConnection connection)
	{
		return Select(connection);
	}

	public static TipoGrupoSPTO[] Select(DbConnection connection, TipoGrupoSPTO values)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupoSP", values.IDTipoGrupoSP);
		connection.AddParameters("@IdTipoGrupo", values.IDTipoGrupo);
		connection.AddParameters("@IDCadastroSP", values.IDCadastroSP);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTipoGrupoSPSel"));
	}

	public static bool Exists(DbConnection connection, TipoGrupoSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupoSP", instance.IDTipoGrupoSP);
		connection.AddParameters("@IdTipoGrupo", instance.IDTipoGrupo);
		connection.AddParameters("@IDCadastroSP", instance.IDCadastroSP);
		return connection.ExecuteScalar(CommandType.StoredProcedure, "uspTipoGrupoSPSel") != null;
	}

	public static int Count(DbConnection connection, int? IDTipoGrupoSP, int? IDTipoGrupo, int? IDCadastroSP)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdTipoGrupoSP", IDTipoGrupoSP);
		connection.AddParameters("@IdTipoGrupo", IDTipoGrupo);
		connection.AddParameters("@IDCadastroSP", IDCadastroSP);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, ""));
	}

	private static TipoGrupoSPTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TipoGrupoSPTO tipoGrupoSPTO = new TipoGrupoSPTO();
				tipoGrupoSPTO.IDTipoGrupoSP = rs.GetNullableInteger("IDTipoGrupoSP");
				tipoGrupoSPTO.IDTipoGrupo = rs.GetNullableInteger("IDTipoGrupo");
				tipoGrupoSPTO.IDCadastroSP = rs.GetNullableInteger("IDCadastroSP");
				arrayList.Add(tipoGrupoSPTO);
			}
		}
		return (TipoGrupoSPTO[])arrayList.ToArray(typeof(TipoGrupoSPTO));
	}
}
