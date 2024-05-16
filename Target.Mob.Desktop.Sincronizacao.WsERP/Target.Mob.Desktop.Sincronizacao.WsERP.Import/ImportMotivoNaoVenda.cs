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

internal class ImportMotivoNaoVenda
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private int _IdMotivoNaoVenda;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportMotivoNaoVenda(string stringConnTargetErp, string stringConnTargetMob, int idMotivoNaoVenda, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_IdMotivoNaoVenda = idMotivoNaoVenda;
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
			RetornoWsModelOfMotivoNaoVendaWsModel retornoWsModelOfMotivoNaoVendaWsModel = wsErpSoapClient.WsERP_MotivoNaoVenda_GetV2(validationSoapHeader, _CnpjEmpresa, _IdMotivoNaoVenda, Seguranca.getHostName());
			if (retornoWsModelOfMotivoNaoVendaWsModel.RetornoWs != null)
			{
				MotivoNaoVendaWsModel retornoWs = retornoWsModelOfMotivoNaoVendaWsModel.RetornoWs;
				dbConnection.Open();
				dbConnection2.Open();
				dbConnection.BeginTransaction();
				if (retornoWs.CodigoProduto.HasValue)
				{
					AcaNaoVendaProdTO acaNaoVendaProd = ConstruirNaoVendaProd(dbConnection, dbConnection2, retornoWs);
					AcaNaoVendaProdBLL.Insert(dbConnection, acaNaoVendaProd);
					if (MotivoDuplicado(dbConnection, acaNaoVendaProd))
					{
						dbConnection.RollbackTransaction();
					}
					else
					{
						dbConnection.CommitTransaction();
					}
				}
				else if (retornoWs.ComVisita == true)
				{
					AcaNaoVendaTO acaNaoVendaTO = ConstruirNaoVenda(dbConnection, dbConnection2, retornoWs);
					AcaNaoVendaBLL.Insert(dbConnection, acaNaoVendaTO);
					VendedorTO vendedorTO = VendedorBLL.Select(dbConnection2.GetConnection(), Convert.ToInt32(retornoWs.IDVendedor));
					ConfiguracaoVendedorTO configuracaoVendedorTO = ConfiguracaoVendedorBLL.Select(dbConnection2.GetConnection(), Convert.ToInt32(vendedorTO.IdConfiguracaoVendedor));
					if (configuracaoVendedorTO != null)
					{
						AcaVisitasForaRotaBLL.InsertVisitaForaRota(dbConnection, acaNaoVendaTO.CdClien.Value, acaNaoVendaTO.CdVend, acaNaoVendaTO.Data.Value, configuracaoVendedorTO);
					}
					if (MotivoDuplicado(dbConnection, acaNaoVendaTO))
					{
						dbConnection.RollbackTransaction();
					}
					else
					{
						dbConnection.CommitTransaction();
					}
				}
				else
				{
					AcaNaoVisitaTO acaNaoVisita = ConstruirNaoVisita(dbConnection, dbConnection2, retornoWs);
					AcaNaoVisitaBLL.Insert(dbConnection, acaNaoVisita);
					if (MotivoDuplicado(dbConnection, acaNaoVisita))
					{
						dbConnection.RollbackTransaction();
					}
					else
					{
						dbConnection.CommitTransaction();
					}
				}
				dbConnection2.Close();
				dbConnection.Close();
				wsErpSoapClient.WsERP_MotivoNaoVenda_SetImportar(validationSoapHeader, _CnpjEmpresa, _IdMotivoNaoVenda, Seguranca.getHostName());
				return;
			}
			throw new Exception(retornoWsModelOfMotivoNaoVendaWsModel.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
			dbConnection2.Close();
		}
	}

	private AcaNaoVendaProdTO ConstruirNaoVendaProd(DbConnection connTargetErp, DbConnection connTargetMob, MotivoNaoVendaWsModel motivoNaoVendaWs)
	{
		AcaNaoVendaProdTO acaNaoVendaProdTO = new AcaNaoVendaProdTO();
		if (motivoNaoVendaWs.ClienteBDMovimento == true)
		{
			if (motivoNaoVendaWs.CodigoClienteProspeccao.HasValue && motivoNaoVendaWs.CodigoClienteProspeccao > 0)
			{
				acaNaoVendaProdTO.CdClien = motivoNaoVendaWs.CodigoClienteProspeccao.Value;
			}
			else
			{
				acaNaoVendaProdTO.CdClien = ClienteBLL.getCodigoClienteByCnpj(motivoNaoVendaWs.CnpjCpfCliente, motivoNaoVendaWs.IDMotivoNaoVenda.Value, "MotivoNaoVendaProd", motivoNaoVendaWs.CodigoPais, _StringConnTargetErp).Value;
			}
		}
		else
		{
			acaNaoVendaProdTO.CdClien = Convert.ToInt32(motivoNaoVendaWs.CodigoCliente);
		}
		acaNaoVendaProdTO.CdMotivo = motivoNaoVendaWs.CodigoMotivo;
		acaNaoVendaProdTO.CdProd = Convert.ToInt32(motivoNaoVendaWs.CodigoProduto);
		acaNaoVendaProdTO.Data = Convert.ToDateTime(motivoNaoVendaWs.DataHora);
		VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), Convert.ToInt32(motivoNaoVendaWs.IDVendedor));
		if (vendedorTO != null)
		{
			acaNaoVendaProdTO.CdVend = vendedorTO.CodigoVendedor;
			if (!string.IsNullOrEmpty(motivoNaoVendaWs.Observacao))
			{
				acaNaoVendaProdTO.DescMotivo = ((motivoNaoVendaWs.Observacao.Length > 60) ? motivoNaoVendaWs.Observacao.Substring(0, 60) : motivoNaoVendaWs.Observacao.Substring(0, motivoNaoVendaWs.Observacao.Length));
			}
			return acaNaoVendaProdTO;
		}
		throw new Exception($"Vendedor não localizado na tabela de configuração de vendedores. IdVendedor: {motivoNaoVendaWs.IDVendedor}");
	}

	private AcaNaoVendaTO ConstruirNaoVenda(DbConnection connTargetErp, DbConnection connTargetMob, MotivoNaoVendaWsModel motivoNaoVendaWs)
	{
		AcaNaoVendaTO acaNaoVendaTO = new AcaNaoVendaTO();
		if (motivoNaoVendaWs.ClienteBDMovimento == true)
		{
			if (motivoNaoVendaWs.CodigoClienteProspeccao.HasValue && motivoNaoVendaWs.CodigoClienteProspeccao > 0)
			{
				acaNaoVendaTO.CdClien = motivoNaoVendaWs.CodigoClienteProspeccao.Value;
			}
			else
			{
				acaNaoVendaTO.CdClien = ClienteBLL.getCodigoClienteByCnpj(motivoNaoVendaWs.CnpjCpfCliente, motivoNaoVendaWs.IDMotivoNaoVenda.Value, "MotivoNaoVenda", motivoNaoVendaWs.CodigoPais, _StringConnTargetErp).Value;
			}
		}
		else
		{
			acaNaoVendaTO.CdClien = Convert.ToInt32(motivoNaoVendaWs.CodigoCliente);
		}
		acaNaoVendaTO.CdMotivo = motivoNaoVendaWs.CodigoMotivo;
		acaNaoVendaTO.Data = Convert.ToDateTime(motivoNaoVendaWs.DataHora);
		VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), Convert.ToInt32(motivoNaoVendaWs.IDVendedor));
		if (vendedorTO != null)
		{
			acaNaoVendaTO.CdVend = vendedorTO.CodigoVendedor;
			if (!string.IsNullOrEmpty(motivoNaoVendaWs.Observacao))
			{
				acaNaoVendaTO.DescMotivo = ((motivoNaoVendaWs.Observacao.Length > 60) ? motivoNaoVendaWs.Observacao.Substring(0, 60) : motivoNaoVendaWs.Observacao.Substring(0, motivoNaoVendaWs.Observacao.Length));
				TextoTO textoTO = new TextoTO();
				textoTO.GeraTexto(motivoNaoVendaWs.Observacao);
				TextoBLL.Insert(connTargetErp, textoTO);
				acaNaoVendaTO.CdTexto = textoTO.CdTexto;
			}
			return acaNaoVendaTO;
		}
		throw new Exception($"Vendedor não localizado na tabela de configuração de vendedores. IdVendedor: {motivoNaoVendaWs.IDVendedor}");
	}

	private AcaNaoVisitaTO ConstruirNaoVisita(DbConnection connTargetErp, DbConnection connTargetMob, MotivoNaoVendaWsModel motivoNaoVendaWs)
	{
		AcaNaoVisitaTO acaNaoVisitaTO = new AcaNaoVisitaTO();
		if (motivoNaoVendaWs.ClienteBDMovimento == true)
		{
			if (motivoNaoVendaWs.CodigoClienteProspeccao.HasValue && motivoNaoVendaWs.CodigoClienteProspeccao > 0)
			{
				acaNaoVisitaTO.CdClien = motivoNaoVendaWs.CodigoClienteProspeccao.Value;
			}
			else
			{
				acaNaoVisitaTO.CdClien = ClienteBLL.getCodigoClienteByCnpj(motivoNaoVendaWs.CnpjCpfCliente, motivoNaoVendaWs.IDMotivoNaoVenda.Value, "MotivoNaoVisita", motivoNaoVendaWs.CodigoPais, _StringConnTargetErp).Value;
			}
		}
		else
		{
			acaNaoVisitaTO.CdClien = Convert.ToInt32(motivoNaoVendaWs.CodigoCliente);
		}
		acaNaoVisitaTO.CdMotivo = motivoNaoVendaWs.CodigoMotivo;
		acaNaoVisitaTO.Data = Convert.ToDateTime(motivoNaoVendaWs.DataHora);
		VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), Convert.ToInt32(motivoNaoVendaWs.IDVendedor));
		if (vendedorTO != null)
		{
			acaNaoVisitaTO.CdVend = vendedorTO.CodigoVendedor;
			if (!string.IsNullOrEmpty(motivoNaoVendaWs.Observacao))
			{
				acaNaoVisitaTO.DescMotivo = ((motivoNaoVendaWs.Observacao.Length > 60) ? motivoNaoVendaWs.Observacao.Substring(0, 60) : motivoNaoVendaWs.Observacao.Substring(0, motivoNaoVendaWs.Observacao.Length));
				TextoTO textoTO = new TextoTO();
				textoTO.GeraTexto(motivoNaoVendaWs.Observacao);
				TextoBLL.Insert(connTargetErp, textoTO);
				acaNaoVisitaTO.CdTexto = textoTO.CdTexto;
			}
			return acaNaoVisitaTO;
		}
		throw new Exception($"Vendedor não localizado na tabela de configuração de vendedores. IdVendedor: {motivoNaoVendaWs.IDVendedor}");
	}

	private bool MotivoDuplicado(DbConnection connTargetErp, AcaNaoVendaProdTO acaNaoVendaProd)
	{
		string cdVend = acaNaoVendaProd.CdVend;
		int cdClien = acaNaoVendaProd.CdClien;
		int cdProd = acaNaoVendaProd.CdProd;
		string cdMotivo = acaNaoVendaProd.CdMotivo;
		_ = acaNaoVendaProd.DescMotivo;
		DateTime data = acaNaoVendaProd.Data;
		return AcaNaoVendaProdBLL.Count(connTargetErp, cdVend, cdClien, cdProd, cdMotivo, data) != 1;
	}

	private bool MotivoDuplicado(DbConnection connTargetErp, AcaNaoVendaTO acaNaoVenda)
	{
		string cdVend = acaNaoVenda.CdVend;
		int cdClien = Convert.ToInt32(acaNaoVenda.CdClien);
		string cdMotivo = acaNaoVenda.CdMotivo;
		_ = acaNaoVenda.DescMotivo;
		DateTime data = Convert.ToDateTime(acaNaoVenda.Data);
		return AcaNaoVendaBLL.Count(connTargetErp, cdVend, cdClien, cdMotivo, data) != 1;
	}

	private bool MotivoDuplicado(DbConnection connTargetErp, AcaNaoVisitaTO acaNaoVisita)
	{
		string cdVend = acaNaoVisita.CdVend;
		int cdClien = Convert.ToInt32(acaNaoVisita.CdClien);
		string cdMotivo = acaNaoVisita.CdMotivo;
		_ = acaNaoVisita.DescMotivo;
		DateTime data = Convert.ToDateTime(acaNaoVisita.Data);
		return AcaNaoVisitaBLL.Count(connTargetErp, cdVend, cdClien, cdMotivo, data) != 1;
	}
}
