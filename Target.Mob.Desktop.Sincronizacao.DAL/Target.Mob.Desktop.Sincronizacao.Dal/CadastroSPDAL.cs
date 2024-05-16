using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class CadastroSPDAL
{
	private const string INSERT = "uspCadastroSPIns";

	private const string UPDATE = "uspCadastroSPUpd";

	private const string DELETE = "uspCadastroSPDel";

	private const string SELECT = "uspCadastroSPSel";

	private const string EXISTS = "uspCadastroSPSelId";

	private const string COUNT = "";

	public static void Insert(DbConnection connection, CadastroSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDCadastroSP", instance.IDCadastroSP);
		connection.AddParameters("@Descricao", instance.Descricao);
		connection.AddParameters("@Texto", instance.Texto);
		connection.AddParameters("@Ativo", instance.Ativo);
		connection.AddParameters("@Automatica", instance.Automatica);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspCadastroSPIns");
	}

	public static void Update(DbConnection connection, CadastroSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDCadastroSP", instance.IDCadastroSP);
		connection.AddParameters("@Descricao", instance.Descricao);
		connection.AddParameters("@Texto", instance.Texto);
		connection.AddParameters("@Ativo", instance.Ativo);
		connection.AddParameters("@Automatica", instance.Automatica);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCadastroSPUpd");
	}

	public static void Delete(DbConnection connection, CadastroSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDCadastroSP", instance.IDCadastroSP);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCadastroSPDel");
	}

	public static CadastroSPTO[] Select(DbConnection connection)
	{
		return Select(connection);
	}

	public static CadastroSPTO[] Select(DbConnection connection, CadastroSPTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDCadastroSP", instance.IDCadastroSP);
		connection.AddParameters("@Descricao", instance.Descricao);
		connection.AddParameters("@Texto", instance.Texto);
		connection.AddParameters("@Ativo", instance.Ativo);
		connection.AddParameters("@Automatica", instance.Automatica);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspCadastroSPSel"));
	}

	public static bool Exists(DbConnection connection, int? IDCadastroSP)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDCadastroSP", IDCadastroSP);
		return connection.ExecuteScalar(CommandType.StoredProcedure, "uspCadastroSPSelId") != null;
	}

	public static bool CriarProc(DbConnection connection, CadastroSPTO instance)
	{
		connection.ClearParameters();
		return (object)connection.ExecuteNonQuery(CommandType.Text, instance.Texto) != null;
	}

	private static CadastroSPTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CadastroSPTO cadastroSPTO = new CadastroSPTO();
				cadastroSPTO.IDCadastroSP = rs.GetInteger("IDCadastroSP");
				cadastroSPTO.Descricao = rs.GetString("Descricao");
				cadastroSPTO.Texto = rs.GetString("Texto");
				cadastroSPTO.Ativo = rs.GetNullableBoolean("Ativo");
				cadastroSPTO.Automatica = rs.GetNullableBoolean("Automatica");
				arrayList.Add(cadastroSPTO);
			}
		}
		return (CadastroSPTO[])arrayList.ToArray(typeof(CadastroSPTO));
	}
}
