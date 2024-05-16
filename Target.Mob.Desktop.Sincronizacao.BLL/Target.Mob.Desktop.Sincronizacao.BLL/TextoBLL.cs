using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class TextoBLL
{
	public static TextoTO[] Select(DbConnection connection, int? CdTexto)
	{
		TextoTO[] array = TextoDAL.Select(connection, CdTexto);
		if (array != null)
		{
			TextoTO[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].oLinTxt = LinTxtBLL.Select(connection, CdTexto);
			}
		}
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, TextoTO Texto)
	{
		Texto.CdTexto = TextoDAL.GeraSeq(connection);
		TextoDAL.Insert(connection, Texto);
		LinTxtTO[] oLinTxt = Texto.oLinTxt;
		foreach (LinTxtTO linTxtTO in oLinTxt)
		{
			linTxtTO.CdTexto = Texto.CdTexto;
			LinTxtDAL.Insert(connection, linTxtTO);
		}
	}
}
