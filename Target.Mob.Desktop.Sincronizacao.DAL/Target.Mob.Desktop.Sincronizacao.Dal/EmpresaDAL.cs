using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class EmpresaDAL
{
	private const string SELECT = "uspEmpresaSelect";

	public static EmpresaTO[] Select(DbConnection connection, int? CdEmp, string RazSoc, string NomeFant, string Cgc, bool? Ativo)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@raz_soc", RazSoc);
		connection.AddParameters("@nome_fant", NomeFant);
		connection.AddParameters("@cgc", Cgc);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", null);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspEmpresaSelect"));
	}

	public static EmpresaTO[] Select(DbConnection connection, int? CdEmp, string RazSoc, string NomeFant, string Cgc, bool? Ativo, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@raz_soc", RazSoc);
		connection.AddParameters("@nome_fant", NomeFant);
		connection.AddParameters("@cgc", Cgc);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspEmpresaSelect"));
	}

	private static EmpresaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				EmpresaTO empresaTO = new EmpresaTO();
				empresaTO.CdEmp = rs.GetNullableInteger("cd_emp");
				empresaTO.RazSoc = rs.GetString("raz_soc");
				empresaTO.NomeFant = rs.GetString("nome_fant");
				empresaTO.Cgc = rs.GetString("cgc");
				empresaTO.Ativo = rs.GetNullableBoolean("ativo");
				empresaTO.RowId = rs.GetArrayByte("rowid");
				empresaTO.Endereco = rs.GetString("endereco");
				empresaTO.Numero = rs.GetString("numero");
				empresaTO.Complemento = rs.GetString("complemento");
				empresaTO.Bairro = rs.GetString("bairro");
				empresaTO.Municipio = rs.GetString("municipio");
				empresaTO.Cep = rs.GetNullableInteger("cep");
				empresaTO.Estado = rs.GetString("estado");
				arrayList.Add(empresaTO);
			}
		}
		return (EmpresaTO[])arrayList.ToArray(typeof(EmpresaTO));
	}
}
