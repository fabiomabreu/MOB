using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

internal class ImportVisita
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private int _CodigoVisita;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportVisita(string stringConnTargetErp, string stringConnTargetMob, int codigoVisita, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_CodigoVisita = codigoVisita;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		using DbConnection dbConnection2 = new DbConnection(_StringConnTargetMob);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			if (_CnpjEmpresa == null)
			{
				_ = _CodigoVisita;
			}
			RetornoWsModelOfVisitaWsModel retornoWsModelOfVisitaWsModel = wsErpSoapClient.WsERP_Visita_GetV2(validationSoapHeader, _CnpjEmpresa, _CodigoVisita, Seguranca.getHostName());
			if (retornoWsModelOfVisitaWsModel.RetornoWs != null)
			{
				VisitaWsModel retornoWs = retornoWsModelOfVisitaWsModel.RetornoWs;
				dbConnection.Open();
				dbConnection2.Open();
				dbConnection.BeginTransaction();
				AcaVisitasTO acaVisitasTO = ConstruirVisita(dbConnection, dbConnection2, retornoWs);
				try
				{
					if ("E".Equals(acaVisitasTO.TipoOperacao.ToUpper()))
					{
						_ = acaVisitasTO.SeqVisita;
						if (acaVisitasTO.SeqVisita != 0)
						{
							AcaVisitasBLL.ExcluirVisita(dbConnection, DateTime.Now, acaVisitasTO.SeqVisita);
						}
					}
					else
					{
						AcaVisitasBLL.InsertVisita(dbConnection, acaVisitasTO.CdVend, acaVisitasTO.CdClien, acaVisitasTO.DtVisita, acaVisitasTO.SeqVisita, acaVisitasTO.HrVisita, acaVisitasTO.FrequenciaVisitaID, acaVisitasTO.CdTpFreqVisita);
					}
					AtualizacaoMovimento(dbConnection);
				}
				catch (Exception ex)
				{
					dbConnection.RollbackTransaction();
					throw ex;
				}
				dbConnection.CommitTransaction();
				wsErpSoapClient.WsERP_Visita_SetImportar(validationSoapHeader, _CnpjEmpresa, _CodigoVisita, Seguranca.getHostName());
				return;
			}
			throw new Exception(retornoWsModelOfVisitaWsModel.Excecao.Erro);
		}
		catch (Exception ex2)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex2.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
			dbConnection2.Close();
		}
	}

	private void AtualizacaoMovimento(DbConnection connTargetErp)
	{
		AtualizacaoMovimentoTO atualizacaoMovimentoTO = new AtualizacaoMovimentoTO();
		atualizacaoMovimentoTO.Tabela = "Visita";
		if (AtualizacaoMovimentoBLL.Exists(connTargetErp, atualizacaoMovimentoTO))
		{
			atualizacaoMovimentoTO.ID = _CodigoVisita;
			AtualizacaoMovimentoBLL.Update(connTargetErp, atualizacaoMovimentoTO);
		}
		else
		{
			atualizacaoMovimentoTO.ID = _CodigoVisita;
			AtualizacaoMovimentoBLL.Insert(connTargetErp, atualizacaoMovimentoTO);
		}
	}

	private AcaVisitasTO ConstruirVisita(DbConnection connTargetErp, DbConnection connTargetMob, VisitaWsModel visitaWs)
	{
		AcaVisitasTO acaVisitasTO = new AcaVisitasTO();
		if (visitaWs.ClienteBDMovimento == true)
		{
			if (visitaWs.CodigoClienteProspeccao.HasValue && visitaWs.CodigoClienteProspeccao > 0)
			{
				acaVisitasTO.CdClien = visitaWs.CodigoClienteProspeccao.Value;
			}
			else
			{
				acaVisitasTO.CdClien = ClienteBLL.getCodigoClienteByCnpj(visitaWs.CnpjCpfCliente, visitaWs.CodigoVisita.Value, "Visita", visitaWs.CodigoPais, _StringConnTargetErp).Value;
			}
		}
		else
		{
			acaVisitasTO.CdClien = Convert.ToInt32(visitaWs.CodigoCliente);
		}
		acaVisitasTO.DtVisita = Convert.ToDateTime(visitaWs.DataHoraVisita.Value.ToString("yyyy-MM-dd"));
		acaVisitasTO.HrVisita = $"{visitaWs.DataHoraVisita:HHmm}";
		VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), Convert.ToInt32(visitaWs.IDVendedor));
		if (vendedorTO != null)
		{
			acaVisitasTO.CdVend = vendedorTO.CodigoVendedor;
			acaVisitasTO.TipoOperacao = visitaWs.TipoOperacao;
			acaVisitasTO.VisitaExcluida = ((!acaVisitasTO.VisitaExcluida.HasValue) ? new bool?(false) : acaVisitasTO.VisitaExcluida);
			acaVisitasTO.SeqVisita = (visitaWs.SeqVisita.HasValue ? visitaWs.SeqVisita.Value : 0);
			acaVisitasTO.FrequenciaVisitaID = visitaWs.CodigoFrequenciaVisita;
			acaVisitasTO.CdTpFreqVisita = visitaWs.TipoFrequenciaVisita;
			return acaVisitasTO;
		}
		throw new Exception($"Vendedor não localizado na tabela de configuração de vendedores. IdVendedor: {visitaWs.IDVendedor}");
	}
}
