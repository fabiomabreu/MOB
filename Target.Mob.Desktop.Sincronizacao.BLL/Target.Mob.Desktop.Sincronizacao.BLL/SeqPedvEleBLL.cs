using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class SeqPedvEleBLL
{
	internal static SeqPedvEleTO[] Select(DbConnection connection, int CdEmp)
	{
		SeqPedvEleTO[] array = SeqPedvEleDAL.Select(connection, CdEmp);
		if (array == null || array.Length == 0)
		{
			SeqPedvEleTO seqPedvEleTO = new SeqPedvEleTO();
			seqPedvEleTO.CdEmp = CdEmp;
			seqPedvEleTO.Numero = 1;
			Insert(connection, seqPedvEleTO);
			array = SeqPedvEleDAL.Select(connection, CdEmp);
		}
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, SeqPedvEleTO SeqPedvEle)
	{
		SeqPedvEleDAL.Insert(connection, SeqPedvEle);
	}

	public static int GeraSeqPorEmpresa(DbConnection connection, int CdEmpEle)
	{
		return SeqPedvEleDAL.GeraSeqPorEmpresa(connection, CdEmpEle);
	}
}
