using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class SeqPedvEleDAL
{
	private const string INSERT = "uspSeqPedvEleInsert";

	private const string UPDATE = "uspSeqPedvEleUpdate";

	private const string DELETE = "uspSeqPedvEleDelete";

	private const string SELECT = "uspSeqPedvEleSelect";

	private const string EXISTS = "uspSeqPedvEleExists";

	public static void Insert(DbConnection connection, SeqPedvEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@numero", instance.Numero);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspSeqPedvEleInsert");
	}

	public static void Update(DbConnection connection, SeqPedvEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@numero", instance.Numero);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspSeqPedvEleUpdate");
	}

	public static void Delete(DbConnection connection, SeqPedvEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspSeqPedvEleDelete");
	}

	public static SeqPedvEleTO[] Select(DbConnection connection, int? CdEmp)
	{
		return Select(connection, CdEmp, null);
	}

	public static SeqPedvEleTO[] Select(DbConnection connection, int? CdEmp, decimal? Numero)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@numero", Numero);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspSeqPedvEleSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdEmp, int? Numero)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@numero", Numero);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspSeqPedvEleExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static SeqPedvEleTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				SeqPedvEleTO seqPedvEleTO = new SeqPedvEleTO();
				seqPedvEleTO.CdEmp = rs.GetInteger("cd_emp");
				seqPedvEleTO.Numero = rs.GetNullableDecimal("numero");
				arrayList.Add(seqPedvEleTO);
			}
		}
		return (SeqPedvEleTO[])arrayList.ToArray(typeof(SeqPedvEleTO));
	}

	public static int GeraSeqPorEmpresa(DbConnection connection, int CdEmpEle)
	{
		return DbUtils.GeraSeqPorEmpresa(connection, "seq_pedv_ele", CdEmpEle);
	}
}
