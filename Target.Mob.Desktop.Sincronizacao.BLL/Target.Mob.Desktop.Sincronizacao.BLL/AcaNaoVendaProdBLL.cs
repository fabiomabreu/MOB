using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class AcaNaoVendaProdBLL
{
	public static AcaNaoVendaProdTO[] Select(DbConnection connection, int? Seq)
	{
		AcaNaoVendaProdTO[] array = AcaNaoVendaProdDAL.Select(connection, Seq);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, AcaNaoVendaProdTO AcaNaoVendaProd)
	{
		AcaNaoVendaProdDAL.Insert(connection, AcaNaoVendaProd);
	}

	public static int Count(DbConnection connection, string CdVend, int CdClien, int CdProd, string CdMotivo, DateTime Data)
	{
		return AcaNaoVendaProdDAL.Count(connection, CdVend, CdClien, CdProd, CdMotivo, Data);
	}
}
