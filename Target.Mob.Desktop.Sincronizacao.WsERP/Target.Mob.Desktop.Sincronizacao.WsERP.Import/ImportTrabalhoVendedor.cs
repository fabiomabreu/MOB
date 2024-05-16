using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

public class ImportTrabalhoVendedor
{
	private string _StringConnTargetMob;

	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportTrabalhoVendedor(string stringConnTargetErp, string stringConnTargetMob, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		try
		{
			dbConnection.Open();
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			byte[] rowId = RelatorioTrabalhoVendedorBLL.selectMaxRowId(dbConnection);
			RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt = wsErpSoapClient.WsERP_RelatorioTrabalhoVendedor_GetNews(validationSoapHeader, _CnpjEmpresa, rowId, Seguranca.getHostName());
			do
			{
				if (retornoWsModelOfListOfInt.RetornoWs != null)
				{
					if (retornoWsModelOfListOfInt.RetornoWs.Count() > 0)
					{
						foreach (int item in retornoWsModelOfListOfInt.RetornoWs.ToList())
						{
							RetornoWsModelOfRelatorioTrabalhoVendedorWsModel retornoWsModelOfRelatorioTrabalhoVendedorWsModel = wsErpSoapClient.WsERP_RelatorioTrabalhoVendedor_Get(validationSoapHeader, _CnpjEmpresa, item, Seguranca.getHostName());
							dbConnection.BeginTransaction();
							RelatorioTrabalhoVendedorBLL.Merge(dbConnection, ConstruirRelatorioTrabalhoVendedor(retornoWsModelOfRelatorioTrabalhoVendedorWsModel.RetornoWs));
							dbConnection.CommitTransaction();
						}
					}
					rowId = RelatorioTrabalhoVendedorBLL.selectMaxRowId(dbConnection);
					retornoWsModelOfListOfInt = wsErpSoapClient.WsERP_RelatorioTrabalhoVendedor_GetNews(validationSoapHeader, _CnpjEmpresa, rowId, Seguranca.getHostName());
					continue;
				}
				throw new Exception("RelatorioTrabalhoVendedor - " + retornoWsModelOfListOfInt.Excecao.Erro);
			}
			while (retornoWsModelOfListOfInt.RetornoWs != null && retornoWsModelOfListOfInt.RetornoWs.Count() > 0);
			byte[] rowId2 = CoordenadaRoteiroVendedorPermanenciaBLL.selectMaxRowId(dbConnection);
			RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt2 = wsErpSoapClient.WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews(validationSoapHeader, _CnpjEmpresa, rowId2, Seguranca.getHostName());
			do
			{
				if (retornoWsModelOfListOfInt2.RetornoWs != null)
				{
					if (retornoWsModelOfListOfInt2.RetornoWs.Count() > 0)
					{
						List<int> list = retornoWsModelOfListOfInt2.RetornoWs.ToList();
						List<CoordenadaRoteiroVendedorPermanenciaTO> list2 = new List<CoordenadaRoteiroVendedorPermanenciaTO>();
						foreach (int item2 in list)
						{
							RetornoWsModelOfCoordenadaRoteiroVendedorPermanenciaWsModel retornoWsModelOfCoordenadaRoteiroVendedorPermanenciaWsModel = wsErpSoapClient.WsERP_CoordenadaRoteiroVendedorPermanencia_Get(validationSoapHeader, _CnpjEmpresa, item2, Seguranca.getHostName());
							list2.Add(ConstruirCoordenadaRoteiroVendedorPermanencia(retornoWsModelOfCoordenadaRoteiroVendedorPermanenciaWsModel.RetornoWs));
						}
						List<CoordenadaRoteiroVendedorPermanenciaTO> listaCRVPDelete = (from item in list2
							group item by new { item.IdVendedor, item.Data } into @group
							select @group.First()).ToList();
						dbConnection.BeginTransaction();
						CoordenadaRoteiroVendedorPermanenciaBLL.CRVPMerge(dbConnection, list2, listaCRVPDelete);
						dbConnection.CommitTransaction();
					}
					rowId2 = CoordenadaRoteiroVendedorPermanenciaBLL.selectMaxRowId(dbConnection);
					retornoWsModelOfListOfInt2 = wsErpSoapClient.WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews(validationSoapHeader, _CnpjEmpresa, rowId2, Seguranca.getHostName());
					continue;
				}
				throw new Exception("CoordenadaRoteiroVendedorPermanencia - " + retornoWsModelOfListOfInt2.Excecao.Erro);
			}
			while (retornoWsModelOfListOfInt2.RetornoWs != null && retornoWsModelOfListOfInt2.RetornoWs.Count() > 0);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
		}
	}

	private CoordenadaRoteiroVendedorPermanenciaTO ConstruirCoordenadaRoteiroVendedorPermanencia(CoordenadaRoteiroVendedorPermanenciaWsModel crvpWsModel)
	{
		return new CoordenadaRoteiroVendedorPermanenciaTO
		{
			IdCoordenadaRoteiroVendedorPermanencia = crvpWsModel.IdCoordenadaRoteiroVendedorPermanencia,
			IdVendedor = crvpWsModel.IdVendedor,
			CodigoVendedor = crvpWsModel.CodigoVendedor,
			Data = crvpWsModel.Data,
			CodigoCliente = crvpWsModel.CodigoCliente,
			HoraInicio = TimeSpan.FromSeconds(crvpWsModel.HoraInicio),
			HoraFim = TimeSpan.FromSeconds(crvpWsModel.HoraFim),
			Roteiro = crvpWsModel.Roteiro,
			CodigoAcao = crvpWsModel.CodigoAcao,
			RowId = crvpWsModel.RowId
		};
	}

	private RelatorioTrabalhoVendedorTO ConstruirRelatorioTrabalhoVendedor(RelatorioTrabalhoVendedorWsModel rtvWsModel)
	{
		return new RelatorioTrabalhoVendedorTO
		{
			IdRelatorioTrabalhoVendedor = rtvWsModel.IdRelatorioTrabalhoVendedor,
			Data = rtvWsModel.Data,
			IdVendedor = rtvWsModel.IDVendedor,
			CodigoVendedor = rtvWsModel.CodigoVendedor,
			Nome = rtvWsModel.Nome,
			QtdeVisitasRoteiroProgramadas = rtvWsModel.QtdeVisitasRoteiroProgramadas,
			QtdeVisitasRoteiroRealizadas = rtvWsModel.QtdeVisitasRoteiroRealizadas,
			QtdeVisitasForaRoteiro = rtvWsModel.QtdeVisitasForaRoteiro,
			QtdePedidos = rtvWsModel.QtdePedidos,
			QtdePedidosRoteiro = rtvWsModel.QtdePedidosRoteiro,
			QtdePedidosRoteiroCliente = rtvWsModel.QtdePedidosRoteiroCliente,
			QtdePedidosForaRoteiro = rtvWsModel.QtdePedidosForaRoteiro,
			QtdePedidosForaRoteiroCliente = rtvWsModel.QtdePedidosForaRoteiroCliente,
			KmRodado = rtvWsModel.KmRodado,
			DataInicioTrabalho = rtvWsModel.DataInicioTrabalho,
			DataFimTrabalho = rtvWsModel.DataFimTrabalho,
			TempoImprodutivo = rtvWsModel.TempoImprodutivo,
			TempoCliente = rtvWsModel.TempoCliente,
			TempoClienteRota = rtvWsModel.TempoClienteRota,
			TempoClienteFora = rtvWsModel.TempoClienteFora,
			TempoAlmoco = rtvWsModel.TempoAlmoco,
			TempoTotal = rtvWsModel.TempoTotal,
			DataInicioAlmoco = rtvWsModel.DataInicioAlmoco,
			DataFimAlmoco = rtvWsModel.DataFimAlmoco,
			KmRodadoTotal = rtvWsModel.KmRodadoTotal,
			KmAjudaCusto = rtvWsModel.KmAjudaCusto,
			KmPrevistoInicio = rtvWsModel.KmPrevistoInicio,
			KmPrevistoFim = rtvWsModel.KmPrevistoFim,
			KmPrevistoRoteiro = rtvWsModel.KmPrevistoRoteiro,
			RowId = rtvWsModel.RowId,
			KmAjudaCustoDescricao = rtvWsModel.KmAjudaCustoDescricao
		};
	}
}
