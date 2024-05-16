using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class TrocaBLL
{
	public static TrocaTO[] Select(DbConnection connection, int? SeqTroca)
	{
		TrocaTO[] array = TrocaDAL.Select(connection, SeqTroca);
		if (array != null)
		{
			TrocaTO[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].oItTroca = ItTrocaBLL.Select(connection, SeqTroca);
			}
		}
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, TrocaTO troca)
	{
		TrocaDAL.Insert(connection, troca);
		int num = 1;
		ItTrocaTO[] oItTroca = troca.oItTroca;
		foreach (ItTrocaTO itTrocaTO in oItTroca)
		{
			itTrocaTO.SeqTroca = troca.SeqTroca;
			itTrocaTO.SeqItTroca = num;
			ItTrocaDAL.Insert(connection, itTrocaTO);
			num++;
		}
	}

	public static int Count(DbConnection connection, int CdEmpEle, string CdVend, int CdClien, DateTime DtCadPalm, string CdTrocaPalm)
	{
		return TrocaDAL.Count(connection, CdEmpEle, CdVend, CdClien, DtCadPalm, CdTrocaPalm);
	}
}
