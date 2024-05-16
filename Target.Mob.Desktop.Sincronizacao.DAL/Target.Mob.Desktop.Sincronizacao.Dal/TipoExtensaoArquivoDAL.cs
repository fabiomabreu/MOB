using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class TipoExtensaoArquivoDAL
{
	private const string INSERT = "TipoExtensaoArquivoIns";

	private const string UPDATE = "TipoExtensaoArquivoUpd";

	private const string DELETE = "TipoExtensaoArquivoDel";

	private const string SELECT = "TipoExtensaoArquivoSel";

	private const string EXISTS = "";

	private const string COUNT = "";

	public static void Insert(DbConnection connection, TipoExtensaoArquivoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Descricao", instance.Descricao);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "TipoExtensaoArquivoIns");
		instance.IDTipoExtensaoArquivo = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, TipoExtensaoArquivoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDTipoExtensaoArquivo", instance.IDTipoExtensaoArquivo);
		connection.AddParameters("@Descricao", instance.Descricao);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "TipoExtensaoArquivoUpd");
	}

	public static void Delete(DbConnection connection, TipoExtensaoArquivoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDTipoExtensaoArquivo", instance.IDTipoExtensaoArquivo);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "TipoExtensaoArquivoDel");
	}

	public static TipoExtensaoArquivoTO[] Select(DbConnection connection, int? IDTipoExtensaoArquivo)
	{
		return Select(connection, IDTipoExtensaoArquivo, null);
	}

	public static TipoExtensaoArquivoTO[] Select(DbConnection connection, int? IDTipoExtensaoArquivo, string Descricao)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDTipoExtensaoArquivo", IDTipoExtensaoArquivo);
		connection.AddParameters("@Descricao", Descricao);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "TipoExtensaoArquivoSel"));
	}

	public static bool Exists(DbConnection connection, int? IDTipoExtensaoArquivo, string Descricao)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDTipoExtensaoArquivo", IDTipoExtensaoArquivo);
		connection.AddParameters("@Descricao", Descricao);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	public static int Count(DbConnection connection, int? IDTipoExtensaoArquivo, string Descricao)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDTipoExtensaoArquivo", IDTipoExtensaoArquivo);
		connection.AddParameters("@Descricao", Descricao);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, ""));
	}

	private static TipoExtensaoArquivoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TipoExtensaoArquivoTO tipoExtensaoArquivoTO = new TipoExtensaoArquivoTO();
				tipoExtensaoArquivoTO.IDTipoExtensaoArquivo = rs.GetInteger("IDTipoExtensaoArquivo");
				tipoExtensaoArquivoTO.Descricao = rs.GetString("Descricao");
				arrayList.Add(tipoExtensaoArquivoTO);
			}
		}
		return (TipoExtensaoArquivoTO[])arrayList.ToArray(typeof(TipoExtensaoArquivoTO));
	}
}
