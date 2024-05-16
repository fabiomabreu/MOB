using System;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class PedVdaEleBLL
{
	public static PedVdaEleTO Select(DbConnection connection, bool ApenasCabecalho, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		PedVdaEleTO pedVdaEleTO = PedVdaEleDAL.Select(connection, CdEmpEle, NuPedEle, SeqPed)[0];
		if (pedVdaEleTO != null && !ApenasCabecalho)
		{
			pedVdaEleTO.oItPedvEle = ItPedvEleBLL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
			pedVdaEleTO.oObsPedEle = ObsPedEleBLL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
			pedVdaEleTO.oPedVdaEleTextoGravacao = PedVdaEleTextoGravacaoBLL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
			pedVdaEleTO.oPedVdaEleDuplic = PedVdaEleDuplicBLL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
		}
		return pedVdaEleTO;
	}

	public static PedVdaEleTO[] AtendimentoPendente(DbConnection connection)
	{
		return PedVdaEleDAL.AtendimentoPendente(connection);
	}

	internal static void Insert(DbConnection connection, PedVdaEleTO PedVdaEle)
	{
		if (PedVdaEle.oTrocaPedvEle != null)
		{
			TrocaBLL.Insert(connection, PedVdaEle.oTrocaPedvEle);
			PedVdaEle.SeqTroca = PedVdaEle.oTrocaPedvEle.SeqTroca;
		}
		PedVdaEleDAL.Insert(connection, PedVdaEle);
		int num = 1;
		ItPedvEleTO[] oItPedvEle = PedVdaEle.oItPedvEle;
		foreach (ItPedvEleTO itPedvEleTO in oItPedvEle)
		{
			itPedvEleTO.CdEmpEle = PedVdaEle.CdEmpEle;
			itPedvEleTO.NuPedEle = PedVdaEle.NuPedEle;
			itPedvEleTO.SeqPed = PedVdaEle.SeqPed;
			itPedvEleTO.Seq = num;
			ItPedvEleDAL.Insert(connection, itPedvEleTO);
			num++;
		}
		num = 1;
		ObsPedEleTO[] oObsPedEle = PedVdaEle.oObsPedEle;
		foreach (ObsPedEleTO obsPedEleTO in oObsPedEle)
		{
			obsPedEleTO.CdEmpEle = PedVdaEle.CdEmpEle;
			obsPedEleTO.NuPedEle = PedVdaEle.NuPedEle;
			obsPedEleTO.SeqPed = PedVdaEle.SeqPed;
			obsPedEleTO.Seq = num;
			ObsPedEleBLL.Insert(connection, obsPedEleTO);
			num++;
		}
		PedVdaEleTextoGravacaoTO[] oPedVdaEleTextoGravacao = PedVdaEle.oPedVdaEleTextoGravacao;
		foreach (PedVdaEleTextoGravacaoTO pedVdaEleTextoGravacaoTO in oPedVdaEleTextoGravacao)
		{
			pedVdaEleTextoGravacaoTO.cdEmpEle = PedVdaEle.CdEmpEle;
			pedVdaEleTextoGravacaoTO.nuPedEle = PedVdaEle.NuPedEle;
			pedVdaEleTextoGravacaoTO.seqPed = PedVdaEle.SeqPed;
			PedVdaEleTextoGravacaoBLL.Insert(connection, pedVdaEleTextoGravacaoTO);
		}
	}

	public static void Update(DbConnection connection, PedVdaEleTO PedVdaEle)
	{
		PedVdaEleDAL.Update(connection, PedVdaEle);
	}

	public static int Count(DbConnection connection, int CdEmpEle, string CdVend, int CdClien, DateTime DtPed, string NuPedPalm)
	{
		return PedVdaEleDAL.Count(connection, CdEmpEle, CdVend, CdClien, DtPed, NuPedPalm);
	}

	public static void SetAtendimentoEnviado(DbConnection connection, PedVdaEleTO PedVdaEle, StatusAtendimentoEnviadoTR statusEnviado)
	{
		PedVdaEleDAL.SetAtendimentoEnviado(connection, PedVdaEle, statusEnviado);
	}

	public static int LiberacaoPendenciaQtde(DbConnection connection, TipoLiberacaoTR tipoLiberacao)
	{
		return PedVdaEleDAL.LiberacaoPendenciaQtde(connection, (int)tipoLiberacao);
	}

	public static DateTime? LiberacaoPendenciaMaisAntiga(DbConnection connection, TipoLiberacaoTR tipoLiberacao)
	{
		return PedVdaEleDAL.LiberacaoPendenciaMaisAntiga(connection, (int)tipoLiberacao);
	}

	public static DateTime? AtendimentoPendenciaMaisAntiga(DbConnection connection)
	{
		return PedVdaEleDAL.AtendimentoPendenciaMaisAntiga(connection);
	}

	public static int? AtendimentoPendenciaQtd(DbConnection connection)
	{
		return PedVdaEleDAL.AtendimentoPendenciaQtd(connection);
	}
}
