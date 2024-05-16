using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class PedVdaEleTextoGravacaoBLL
{
	public static PedVdaEleTextoGravacaoTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		PedVdaEleTextoGravacaoTO[] array = PedVdaEleTextoGravacaoDAL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, PedVdaEleTextoGravacaoTO pedVdaEleTextoGravacao)
	{
		PedVdaEleTextoGravacaoDAL.Insert(connection, pedVdaEleTextoGravacao);
	}
}
