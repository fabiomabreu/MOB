using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class CliLogAltObsBLL
{
	public static CliLogAltObsTO[] Select(DbConnection connection, int? CdClien)
	{
		CliLogAltObsTO[] array = CliLogAltObsDAL.Select(connection, CdClien);
		if (array != null)
		{
			CliLogAltObsTO[] array2 = array;
			foreach (CliLogAltObsTO cliLogAltObsTO in array2)
			{
				cliLogAltObsTO.oLinTxtLog = LinTxtLogBLL.Select(connection, cliLogAltObsTO.CdTexto);
			}
		}
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, CliLogAltObsTO CliLogAltObs)
	{
		if (CliLogAltObs.oLinTxtLog != null)
		{
			CliLogAltObsDAL.Insert(connection, CliLogAltObs);
			SeqTxtLogDAL.Update(connection, new SeqTxtLogTO());
			SeqTxtLogTO seqTxtLogTO = SeqTxtLogBLL.Select(connection);
			LinTxtLogTO[] oLinTxtLog = CliLogAltObs.oLinTxtLog;
			foreach (LinTxtLogTO linTxtLogTO in oLinTxtLog)
			{
				linTxtLogTO.CdTextoLog = Convert.ToInt32(seqTxtLogTO.Numero);
				linTxtLogTO.CdTextoOrig = CliLogAltObs.CdTexto;
				LinTxtLogDAL.Insert(connection, linTxtLogTO);
			}
			seqTxtLogTO.Numero++;
			SeqTxtLogDAL.Update(connection, seqTxtLogTO);
		}
	}
}
