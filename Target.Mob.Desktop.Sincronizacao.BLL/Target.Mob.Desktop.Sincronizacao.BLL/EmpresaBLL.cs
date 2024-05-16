using System;
using System.Collections.Generic;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class EmpresaBLL
{
	public static EmpresaTO[] Select(DbConnection connection, int? CdEmp, string RazSoc, string NomeFant, string Cgc, bool? Ativo)
	{
		EmpresaTO[] source = EmpresaDAL.Select(connection, CdEmp, RazSoc, NomeFant, Cgc, Ativo);
		source = source.OrderBy((EmpresaTO x) => x.CdEmp).ToArray();
		if (source == null || source.Length == 0)
		{
			return null;
		}
		return source;
	}

	public static EmpresaTO[] Select(DbConnection connection, int? CdEmp, string RazSoc, string NomeFant, string Cgc, bool? Ativo, byte[] RowId)
	{
		EmpresaTO[] array = EmpresaDAL.Select(connection, CdEmp, RazSoc, NomeFant, Cgc, Ativo, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static string GetCnpj(DbConnection connection)
	{
		EmpresaTO[] array = Select(connection, null, null, null, null, true);
		if (array == null || array.Length == 0)
		{
			throw new Exception("Impossível obter o Cnpj. Nenhuma empresa ativa foi localizada!");
		}
		return array[0].Cgc;
	}

	public static string GetCnpj(string stringConnErp)
	{
		string text = null;
		using DbConnection dbConnection = new DbConnection(stringConnErp);
		dbConnection.Open();
		text = GetCnpj(dbConnection);
		dbConnection.Close();
		return text;
	}

	public static EmpresaTO[] Select(string connTargetERP, int? CdEmp, string RazSoc, string NomeFant, string Cgc, bool? Ativo, byte[] RowId)
	{
		EmpresaTO[] array = new EmpresaTO[0];
		using DbConnection dbConnection = new DbConnection(connTargetERP);
		dbConnection.Open();
		array = EmpresaDAL.Select(dbConnection, CdEmp, RazSoc, NomeFant, Cgc, Ativo, RowId);
		dbConnection.Close();
		return array;
	}

	public static List<string> getCnpjs(string connTargetERP, int? CdEmp, string RazSoc, string NomeFant, string Cgc, bool? Ativo, byte[] RowId)
	{
		new List<string>();
		_ = new EmpresaTO[0];
		return (from x in Select(connTargetERP, CdEmp, RazSoc, NomeFant, Cgc, Ativo, RowId)
			select x.Cgc).ToList();
	}
}
