using System;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class AcaVisitasForaRotaBLL
{
	public static void Insert(DbConnection connection, AcaVisitasForaRotaTO AcaVisitasForaRota)
	{
		AcaVisitasForaRotaDAL.Insert(connection, AcaVisitasForaRota);
	}

	public static bool Exists(DbConnection connection, AcaVisitasForaRotaTO AcaVisitasForaRota)
	{
		return AcaVisitasForaRotaDAL.Exists(connection, AcaVisitasForaRota.SeqVisita, AcaVisitasForaRota.CdVend, AcaVisitasForaRota.CdClien, AcaVisitasForaRota.DtVisita, AcaVisitasForaRota.HrVisita);
	}

	public static void InsertVisitaForaRota(DbConnection connection, int CdClien, string CdVend, DateTime Data, ConfiguracaoVendedorTO configuracao)
	{
		if (!AcaVisitasBLL.ExistsVisita(connection, CdVend, CdClien, Data) && (!configuracao.NaoImportarInformacaoVisitaForaRota.HasValue || !Convert.ToBoolean(configuracao.NaoImportarInformacaoVisitaForaRota)))
		{
			AcaVisitasForaRotaTO acaVisitasForaRotaTO = new AcaVisitasForaRotaTO();
			acaVisitasForaRotaTO.CdClien = CdClien;
			acaVisitasForaRotaTO.CdVend = CdVend;
			acaVisitasForaRotaTO.DtVisita = Data;
			acaVisitasForaRotaTO.HrVisita = Data.ToString("HHmm");
			if (!Exists(connection, acaVisitasForaRotaTO))
			{
				Insert(connection, acaVisitasForaRotaTO);
			}
		}
	}
}
