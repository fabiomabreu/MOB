using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class PedVdaEleTextoGravacaoDAL
{
	private const string INSERT = "uspPedVdaEleTextoGravacaoInsert";

	private const string SELECT = "uspPedVdaEleTextoGravacaoSelect";

	public static void Insert(DbConnection connection, PedVdaEleTextoGravacaoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cdEmpEle", instance.cdEmpEle);
		connection.AddParameters("@nuPedEle", instance.nuPedEle);
		connection.AddParameters("@seqPed", instance.seqPed);
		connection.AddParameters("@nuLinha", instance.nuLinha);
		connection.AddParameters("@texto", instance.texto);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspPedVdaEleTextoGravacaoInsert");
	}

	public static PedVdaEleTextoGravacaoTO[] Select(DbConnection connection, int? cdEmpEle, int? nuPedEle, decimal? seqPed)
	{
		return Select(connection, cdEmpEle, nuPedEle, seqPed, null, null);
	}

	public static PedVdaEleTextoGravacaoTO[] Select(DbConnection connection, int? cdEmpEle, decimal? nuPedEle, decimal? seqPed, int? nuLinha, string texto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cdEmpEle", cdEmpEle);
		connection.AddParameters("@nuPedEle", nuPedEle);
		connection.AddParameters("@seqPed", seqPed);
		connection.AddParameters("@nuLinha", nuLinha);
		connection.AddParameters("@texto", texto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleTextoGravacaoSelect"));
	}

	private static PedVdaEleTextoGravacaoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PedVdaEleTextoGravacaoTO pedVdaEleTextoGravacaoTO = new PedVdaEleTextoGravacaoTO();
				pedVdaEleTextoGravacaoTO.cdEmpEle = rs.GetInteger("cdEmpEle");
				pedVdaEleTextoGravacaoTO.nuPedEle = rs.GetInteger("nuPedEle");
				pedVdaEleTextoGravacaoTO.seqPed = rs.GetDecimal("seqPed");
				pedVdaEleTextoGravacaoTO.nuLinha = rs.GetShort("nuLinha");
				pedVdaEleTextoGravacaoTO.texto = rs.GetString("texto");
				arrayList.Add(pedVdaEleTextoGravacaoTO);
			}
		}
		return (PedVdaEleTextoGravacaoTO[])arrayList.ToArray(typeof(PedVdaEleTextoGravacaoTO));
	}
}
