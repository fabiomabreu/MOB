using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ImportacaoLogErroDAL
{
	private const string INSERT = "uspImportacaoLogErroInsert";

	private const string UPDATE = "uspImportacaoLogErroUpdate";

	private const string DELETE = "uspImportacaoLogErroDelete";

	private const string SELECT = "uspImportacaoLogErroSelect";

	public static void Insert(DbConnection connection, ImportacaoLogErroTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdImportacaoItem", instance.IdImportacaoItem);
		connection.AddParameters("@Classe", instance.Classe);
		connection.AddParameters("@Metodo", instance.Metodo);
		connection.AddParameters("@Erro", instance.Erro);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspImportacaoLogErroInsert");
		instance.Id = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, ImportacaoLogErroTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", instance.Id);
		connection.AddParameters("@IdImportacaoItem", instance.IdImportacaoItem);
		connection.AddParameters("@Classe", instance.Classe);
		connection.AddParameters("@Metodo", instance.Metodo);
		connection.AddParameters("@Erro", instance.Erro);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspImportacaoLogErroUpdate");
	}

	public static void Delete(DbConnection connection, ImportacaoLogErroTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", instance.Id);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspImportacaoLogErroDelete");
	}

	public static ImportacaoLogErroTO[] Select(DbConnection connection, int? Id)
	{
		return Select(connection, Id, null, null, null, null);
	}

	public static ImportacaoLogErroTO[] Select(DbConnection connection, int? Id, int? IdImportacaoItem, string Classe, string Metodo, object Erro)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", Id);
		connection.AddParameters("@IdImportacaoItem", IdImportacaoItem);
		connection.AddParameters("@Classe", Classe);
		connection.AddParameters("@Metodo", Metodo);
		connection.AddParameters("@Erro", Erro);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspImportacaoLogErroSelect"));
	}

	private static ImportacaoLogErroTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ImportacaoLogErroTO importacaoLogErroTO = new ImportacaoLogErroTO();
				importacaoLogErroTO.Id = rs.GetInteger("Id");
				importacaoLogErroTO.IdImportacaoItem = rs.GetInteger("IdImportacaoItem");
				importacaoLogErroTO.Classe = rs.GetString("Classe");
				importacaoLogErroTO.Metodo = rs.GetString("Metodo");
				importacaoLogErroTO.Erro = rs.GetString("Erro");
				arrayList.Add(importacaoLogErroTO);
			}
		}
		return (ImportacaoLogErroTO[])arrayList.ToArray(typeof(ImportacaoLogErroTO));
	}
}
