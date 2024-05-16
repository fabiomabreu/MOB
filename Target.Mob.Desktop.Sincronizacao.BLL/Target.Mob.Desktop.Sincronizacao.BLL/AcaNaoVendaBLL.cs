using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class AcaNaoVendaBLL
{
	public static AcaNaoVendaTO[] Select(DbConnection connection, int? Seq)
	{
		AcaNaoVendaTO[] array = AcaNaoVendaDAL.Select(connection, Seq);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, AcaNaoVendaTO AcaNaoVenda)
	{
		AcaNaoVendaDAL.Insert(connection, AcaNaoVenda);
	}

	public static int Count(DbConnection connection, string CdVend, int CdClien, string CdMotivo, DateTime Data)
	{
		return AcaNaoVendaDAL.Count(connection, CdVend, CdClien, CdMotivo, Data);
	}
}
