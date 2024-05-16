using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class FrequenciaVisitaDAL
{
	private const string SELECT = "uspFrequenciaVisitaSelect";

	public static FrequenciaVisitaTO[] Select(DbConnection connection, FrequenciaVisitaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@FrequenciaVisitaID", instance.FrequenciaVisitaID);
		connection.AddParameters("@Descricao", instance.Descricao);
		connection.AddParameters("@TipoFrequencia", instance.TipoFrequencia);
		connection.AddParameters("@Quantidade", instance.Quantidade);
		connection.AddParameters("@Ativo", instance.Ativo);
		connection.AddParameters("@RowID", instance.RowID);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspFrequenciaVisitaSelect"));
	}

	private static FrequenciaVisitaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				FrequenciaVisitaTO frequenciaVisitaTO = new FrequenciaVisitaTO();
				frequenciaVisitaTO.FrequenciaVisitaID = rs.GetInteger("FrequenciaVisitaID");
				frequenciaVisitaTO.Descricao = rs.GetString("Descricao");
				frequenciaVisitaTO.TipoFrequencia = rs.GetString("TipoFrequencia");
				frequenciaVisitaTO.Ativo = rs.GetNullableBoolean("Ativo");
				frequenciaVisitaTO.Quantidade = rs.GetNullableInteger("Quantidade");
				frequenciaVisitaTO.RowID = rs.GetArrayByte("RowID");
				arrayList.Add(frequenciaVisitaTO);
			}
		}
		return (FrequenciaVisitaTO[])arrayList.ToArray(typeof(FrequenciaVisitaTO));
	}
}
