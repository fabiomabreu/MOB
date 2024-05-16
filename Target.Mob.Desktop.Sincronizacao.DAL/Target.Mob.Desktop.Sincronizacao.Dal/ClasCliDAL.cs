using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ClasCliDAL
{
	private const string INSERT = "uspClasCliInsert";

	private const string UPDATE = "uspClasCliUpdate";

	private const string DELETE = "uspClasCliDelete";

	private const string SELECT = "uspClasCliSelect";

	private const string SELECTNewCustomer = "uspClasCliSelectNewCustomer";

	private const string EXISTS = "uspClasCliExists";

	public static void Insert(DbConnection connection, ClasCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_classe", instance.CdClasse);
		connection.AddParameters("@classe", instance.RetornaClasse());
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspClasCliInsert");
	}

	public static void Update(DbConnection connection, ClasCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_classe", instance.CdClasse);
		connection.AddParameters("@classe", instance.RetornaClasse());
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspClasCliUpdate");
	}

	public static void Delete(DbConnection connection, ClasCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_classe", instance.CdClasse);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspClasCliDelete");
	}

	public static ClasCliTO[] Select(DbConnection connection, int? CdClien)
	{
		return Select(connection, null, CdClien, null, null);
	}

	public static ClasCliTO[] Select(DbConnection connection, int? CdEmp, int? CdClien, string CdClasse)
	{
		return Select(connection, CdEmp, CdClien, CdClasse, null);
	}

	public static ClasCliTO[] Select(DbConnection connection, int? CdEmp, int? CdClien, string CdClasse, string Classe)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_classe", CdClasse);
		connection.AddParameters("@classe", Classe);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspClasCliSelect"));
	}

	public static ClasCliTO[] SelectNewCustomer(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspClasCliSelectNewCustomer"));
	}

	public static bool Exists(DbConnection connection, int? CdEmp, int? CdClien, string CdClasse, string Classe)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_classe", CdClasse);
		connection.AddParameters("@classe", Classe);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspClasCliExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static ClasCliTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ClasCliTO clasCliTO = new ClasCliTO();
				clasCliTO.CdEmp = rs.GetInteger("cd_emp");
				clasCliTO.CdClien = rs.GetInteger("cd_clien");
				clasCliTO.CdClasse = rs.GetString("cd_classe");
				switch (rs.GetString("classe"))
				{
				case "A":
					clasCliTO.Classe = ClasseCliente.ClasseA;
					break;
				case "B":
					clasCliTO.Classe = ClasseCliente.ClasseB;
					break;
				case "C":
					clasCliTO.Classe = ClasseCliente.ClasseC;
					break;
				case "N":
					clasCliTO.Classe = ClasseCliente.ClasseN;
					break;
				default:
					clasCliTO.Classe = ClasseCliente.ClasseN;
					break;
				}
				arrayList.Add(clasCliTO);
			}
		}
		return (ClasCliTO[])arrayList.ToArray(typeof(ClasCliTO));
	}
}
