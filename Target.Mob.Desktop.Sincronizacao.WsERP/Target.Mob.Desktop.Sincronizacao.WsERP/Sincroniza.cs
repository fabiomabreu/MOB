using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Bll;
using Target.Mob.Desktop.Geracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.BLL.Socket;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.Export;
using Target.Mob.Desktop.Sincronizacao.WsERP.Import;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP;

public class Sincroniza
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private string _NomeServidorOrigemReplicacao;

	private string _NomeDbOrigemReplicacao;

	private string _TargetMobPath;

	private string _LiberaAutoNomeProcesso;

	private string _LiberaAutoCaminhoExe;

	private string _LiberaAutoConnOdbc;

	private int _LiberaAutoTimeout;

	private int _LiberaAutoNumeroTentativas;

	private string _LiberaAutoUsuarioLiberacao;

	private int _LiberaAutoQtdeLiberacaoSimultanea;

	private bool _GeracaoLogaEtapa;

	private string _PathMobRelatorioDestino;

	private string _PathMobRelatorioOrigem;

	private string _PathMobRelatorioTamanho;

	private string _SiglaCliente;

	private string _EmailSmtpServidor;

	private int _EmailSmtpPort;

	private string _EmailUser;

	private string _EmailPassword;

	private bool _EmailUseSSL;

	private string _EmailFrom;

	private string _UriSocket;

	private string _ApiBaseAddress;

	private string _PathMobDownload;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public Sincroniza(string stringConnTargetErp, string stringConnTargetMob, string nomeServidorOrigemReplicacao, string targetMobPath, int qtdeThreadSimultaneaGeral, int qtdeThreadSimultaneaIO, string liberaAutoNomeProcesso, string liberaAutoCaminhoExe, string liberaAutoConnOdbc, int liberaAutoTimeout, int liberaAutoNumeroTentativas, string liberaAutoUsuarioLiberacao, int liberaAutoQtdeLiberacaoSimultanea, bool geracaoLogaEtapa, string targetRelatoriPathDestino, string targetRelatorioPathOrigem, string targetRelatorioTamanho, string PathMobDownload, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress, string siglaCliente, string emailSmtpServidor, int emailSmtpPort, string emailUser, string emailPassword, bool emailUseSSL, string emailFrom, string uriSocket, string apiBaseAddress)
	{
		try
		{
			string stringConnTargetErp2 = EncrypterHelper.Descriptografia_ConnectionString(stringConnTargetErp);
			string stringConnTargetMob2 = EncrypterHelper.Descriptografia_ConnectionString(stringConnTargetMob);
			_StringConnTargetErp = stringConnTargetErp2;
			_StringConnTargetMob = stringConnTargetMob2;
			_NomeServidorOrigemReplicacao = nomeServidorOrigemReplicacao;
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(stringConnTargetErp);
			_NomeDbOrigemReplicacao = sqlConnectionStringBuilder.InitialCatalog;
			_TargetMobPath = targetMobPath;
			_GeracaoLogaEtapa = geracaoLogaEtapa;
			_PathMobRelatorioDestino = targetRelatoriPathDestino;
			_PathMobRelatorioOrigem = targetRelatorioPathOrigem;
			_PathMobRelatorioTamanho = targetRelatorioTamanho;
			_PathMobDownload = PathMobDownload;
			_LiberaAutoNomeProcesso = liberaAutoNomeProcesso;
			_LiberaAutoCaminhoExe = liberaAutoCaminhoExe;
			_LiberaAutoConnOdbc = liberaAutoConnOdbc;
			_LiberaAutoTimeout = liberaAutoTimeout;
			_LiberaAutoNumeroTentativas = liberaAutoNumeroTentativas;
			_LiberaAutoUsuarioLiberacao = liberaAutoUsuarioLiberacao;
			_LiberaAutoQtdeLiberacaoSimultanea = liberaAutoQtdeLiberacaoSimultanea;
			_SiglaCliente = siglaCliente;
			_EmailSmtpServidor = emailSmtpServidor;
			_EmailSmtpPort = emailSmtpPort;
			_EmailUser = emailUser;
			_EmailPassword = emailPassword;
			_EmailUseSSL = emailUseSSL;
			_EmailFrom = emailFrom;
			_UriSocket = uriSocket;
			_ApiBaseAddress = apiBaseAddress;
			_bindingBasicHttp = bindingBasicHttp;
			_remoteAddress = remoteAddress;
			ThreadPool.SetMaxThreads(qtdeThreadSimultaneaGeral, qtdeThreadSimultaneaIO);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(string.Concat(str2: GetType().Name, str0: currentMethod.Name, str1: "."), ex.Message, EventLogEntryType.Information);
		}
	}

	public SocketManager SocketManagerFactory()
	{
		return new SocketManager(_StringConnTargetErp, _UriSocket);
	}

	public void ImportaCliente()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using (ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaCliente"))
			{
				controleProcessoSimultaneo.IniciaProcesso();
				string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
				Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
				validationSoapHeader.Token = Seguranca.GeraTokenERP(cnpj, DateTime.Now);
				RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_Cliente_GetNewsV2(validationSoapHeader, cnpj, Seguranca.getHostName());
				if (retornoWsModelOfListOfInt.RetornoWs == null)
				{
					throw new Exception(retornoWsModelOfListOfInt.Excecao.Erro);
				}
				int[] retornoWs = retornoWsModelOfListOfInt.RetornoWs;
				using (CountdownEvent countdownEvent = new CountdownEvent(1))
				{
					int[] array = retornoWs;
					foreach (int idCliente in array)
					{
						countdownEvent.AddCount();
						ThreadPool.QueueUserWorkItem(new ImportCliente(_StringConnTargetErp, _StringConnTargetMob, idCliente, cnpj, _bindingBasicHttp, _remoteAddress).Importar, countdownEvent);
					}
					countdownEvent.Signal();
					countdownEvent.Wait();
				}
				controleProcessoSimultaneo.EncerraProcesso();
			}
			ImportCoordenadaCliente();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportCoordenadaCliente()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaCoordenada");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader().Token = Seguranca.GeraTokenERP(cnpj, DateTime.Now);
			new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			new ImportCoordenada(_StringConnTargetErp, _StringConnTargetMob, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaConfiguracaoVendedor()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaConfiguracaoVendedor");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ImportConfiguracaoVendedor(_StringConnTargetErp, _StringConnTargetMob, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaMotivoNaoVenda()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaMotivoNaoVenda");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(cnpj, DateTime.Now);
			RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_MotivoNaoVenda_GetNewsV2(validationSoapHeader, cnpj, Seguranca.getHostName());
			if (retornoWsModelOfListOfInt.RetornoWs != null)
			{
				int[] retornoWs = retornoWsModelOfListOfInt.RetornoWs;
				foreach (int idMotivoNaoVenda in retornoWs)
				{
					new ImportMotivoNaoVenda(_StringConnTargetErp, _StringConnTargetMob, idMotivoNaoVenda, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
				}
				controleProcessoSimultaneo.EncerraProcesso();
				return;
			}
			throw new Exception(retornoWsModelOfListOfInt.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaPedido()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using (ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaPedido"))
			{
				string nomeServico = "Pedido";
				if (!string.IsNullOrEmpty(_SiglaCliente))
				{
					nomeServico = string.Concat(_SiglaCliente + ".Pedido");
				}
				if (!PermiteExecucaoServico(nomeServico))
				{
					throw new Exception("Execução da importação de pedidos fora do horário permitido");
				}
				controleProcessoSimultaneo.IniciaProcesso();
				string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
				Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
				validationSoapHeader.Token = Seguranca.GeraTokenERP(cnpj, DateTime.Now);
				RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_Pedido_GetNewsV2(validationSoapHeader, cnpj, Seguranca.getHostName());
				if (retornoWsModelOfListOfInt.RetornoWs == null)
				{
					throw new Exception(retornoWsModelOfListOfInt.Excecao.Erro);
				}
				int[] retornoWs = retornoWsModelOfListOfInt.RetornoWs;
				using (CountdownEvent countdownEvent = new CountdownEvent(1))
				{
					int[] array = retornoWs;
					foreach (int idPedido in array)
					{
						countdownEvent.AddCount();
						ThreadPool.QueueUserWorkItem(new ImportPedido(_StringConnTargetErp, _StringConnTargetMob, idPedido, cnpj, _bindingBasicHttp, _remoteAddress).Importar, countdownEvent);
					}
					countdownEvent.Signal();
					countdownEvent.Wait();
				}
				controleProcessoSimultaneo.EncerraProcesso();
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo2 = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaGondola");
			controleProcessoSimultaneo2.IniciaProcesso();
			string cnpj2 = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ImportGondola(_StringConnTargetErp, _StringConnTargetMob, cnpj2, _bindingBasicHttp, _remoteAddress).Importar();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaPlanoVisita()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaPlanoVisita");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(cnpj, DateTime.Now);
			RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_Visita_GetNewsV2(validationSoapHeader, cnpj, Seguranca.getHostName());
			if (retornoWsModelOfListOfInt.RetornoWs != null)
			{
				int[] retornoWs = retornoWsModelOfListOfInt.RetornoWs;
				foreach (int codigoVisita in retornoWs)
				{
					new ImportVisita(_StringConnTargetErp, _StringConnTargetMob, codigoVisita, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
				}
				controleProcessoSimultaneo.EncerraProcesso();
				return;
			}
			throw new Exception(retornoWsModelOfListOfInt.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaServico()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaServico");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ImportServico(_StringConnTargetMob, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaTroca()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaTroca");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(cnpj, DateTime.Now);
			RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_Troca_GetNewsV2(validationSoapHeader, cnpj, Seguranca.getHostName());
			if (retornoWsModelOfListOfInt.RetornoWs != null)
			{
				int[] retornoWs = retornoWsModelOfListOfInt.RetornoWs;
				using (CountdownEvent countdownEvent = new CountdownEvent(1))
				{
					int[] array = retornoWs;
					foreach (int idTroca in array)
					{
						countdownEvent.AddCount();
						ThreadPool.QueueUserWorkItem(new ImportTroca(_StringConnTargetErp, _StringConnTargetMob, idTroca, cnpj, _bindingBasicHttp, _remoteAddress).Importar, countdownEvent);
					}
					countdownEvent.Signal();
					countdownEvent.Wait();
				}
				controleProcessoSimultaneo.EncerraProcesso();
				return;
			}
			throw new Exception(retornoWsModelOfListOfInt.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportarTipoGrupo()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportarRelatorio");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ImportTipoGrupo(_StringConnTargetMob, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaVersaoRetaguarda()
	{
		try
		{
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaVersaoRetaguarda");
			controleProcessoSimultaneo.IniciaProcesso();
			new ImportVersao().enviarVersaoWS();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaPagamento()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportarPagamento");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ImportPagamento(_StringConnTargetMob, _StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ImportaTrabalhoVendedor()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ImportaTrabalhoVendedor");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ImportTrabalhoVendedor(_StringConnTargetErp, _StringConnTargetMob, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaTabela()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaTabela");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ExportReplicacao(_StringConnTargetMob, cnpj, _NomeServidorOrigemReplicacao, _NomeDbOrigemReplicacao, _bindingBasicHttp, _remoteAddress).Exportar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaPedidoAtendimento()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaPedidoAtendimento");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			PedVdaEleTO[] array;
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetErp))
			{
				dbConnection.Open();
				array = PedVdaEleBLL.AtendimentoPendente(dbConnection);
				dbConnection.Close();
			}
			using (CountdownEvent countdownEvent = new CountdownEvent(1))
			{
				PedVdaEleTO[] array2 = array;
				foreach (PedVdaEleTO pedVdaEle in array2)
				{
					countdownEvent.AddCount();
					ThreadPool.QueueUserWorkItem(new ExportPedidoAtendimento(_StringConnTargetErp, _StringConnTargetMob, pedVdaEle, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				}
				countdownEvent.Signal();
				countdownEvent.Wait();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaLogSincronizacao()
	{
		try
		{
			throw new NotImplementedException();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaCarga()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaCarga");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			List<VendedorTO> list;
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetMob))
			{
				dbConnection.Open();
				list = VendedorBLL.Select(dbConnection.GetConnection(), new VendedorTO());
				dbConnection.Close();
			}
			foreach (VendedorTO item in list)
			{
				List<CargaTO> list2 = new List<CargaTO>();
				using (DbConnection dbConnection2 = new DbConnection(_StringConnTargetMob))
				{
					dbConnection2.Open();
					list2 = CargaBLL.SelectEnvio(dbConnection2.GetConnection(), item.Id);
					dbConnection2.Close();
				}
				foreach (CargaTO item2 in list2)
				{
					try
					{
						new ExportCarga(_StringConnTargetMob, cnpj, item2, _bindingBasicHttp, _remoteAddress).Exportar();
					}
					catch (Exception)
					{
						break;
					}
				}
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex2)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex2.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaCadastroBasico()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaCadastroBasico");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			using (CountdownEvent countdownEvent = new CountdownEvent(1))
			{
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroEmpresa(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroFormaPagamento(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroLocalEstoque(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroProduto(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroProduto(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).ExportarSKU, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroFabricante(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroLinha(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroCategoria(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroTabelaPreco(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroTipoCusto(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroTipoPedido(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroVendedor(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportFrequenciaVisita(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroVisita(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportVersaoRetaguarda(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportEquipe(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportCadastroCliente(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportComoRealizouVenda(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportPromotor(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportEquipePromotor(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportGerenciaPromotor(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportArea(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportGrupoCli(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportRamAtiv(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.AddCount();
				ThreadPool.QueueUserWorkItem(new ExportMPAgenda(_StringConnTargetErp, cnpj, _bindingBasicHttp, _remoteAddress).Exportar, countdownEvent);
				countdownEvent.Signal();
				countdownEvent.Wait();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaRelatorio()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaRelatorio");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			RelatorioGerencialTO relatorioGerencialTO = new RelatorioGerencialTO();
			relatorioGerencialTO.DtImportacao = null;
			new List<RelatorioGerencialTO>();
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetMob))
			{
				dbConnection.Open();
				RelatorioGerencialTO[] array = RelatorioGerencialBLL.Select_Arquivo(dbConnection, relatorioGerencialTO);
				if (array != null)
				{
					foreach (RelatorioGerencialTO item in array.ToList())
					{
						new ExportRelatorios(_StringConnTargetMob, cnpj, item, _bindingBasicHttp, _remoteAddress).Exportar();
					}
				}
				dbConnection.Close();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaMonitoramento()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaMonitoramento");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ExportMonitoramento(_TargetMobPath, _StringConnTargetMob, _StringConnTargetErp, cnpj, _NomeServidorOrigemReplicacao, _NomeDbOrigemReplicacao, _bindingBasicHttp, _remoteAddress, _SiglaCliente).Exportar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaNotificacao()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaNotificacao");
			controleProcessoSimultaneo.IniciaProcesso();
			using (CountdownEvent countdownEvent = new CountdownEvent(1))
			{
				string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
				countdownEvent.AddCount();
				new ExportNotificacao(_StringConnTargetMob, cnpj, _NomeServidorOrigemReplicacao, _NomeDbOrigemReplicacao, _bindingBasicHttp, _remoteAddress).Exportar();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ExportaCoordenadaCliente()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ExportaCoordenadaCliente");
			controleProcessoSimultaneo.IniciaProcesso();
			using (CountdownEvent countdownEvent = new CountdownEvent(1))
			{
				string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
				countdownEvent.AddCount();
				new ExportCoordenadaCliente(_StringConnTargetErp, cnpj).Exportar();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void LiberaPedido()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "LiberaPedido");
			string nomeServico = "LiberacaoPedido";
			if (!string.IsNullOrEmpty(_SiglaCliente))
			{
				nomeServico = string.Concat(_SiglaCliente + ".LiberacaoPedido");
			}
			if (!PermiteExecucaoServico(nomeServico))
			{
				throw new Exception("Execução da liberação de pedidos fora do horário permitido");
			}
			controleProcessoSimultaneo.IniciaProcesso();
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetErp))
			{
				using DbConnection dbConnection2 = new DbConnection(_StringConnTargetMob);
				dbConnection.Open();
				dbConnection2.Open();
				if (ConfigHelper.getAppConfig("HabilitarVendasApi").ToUpper().Equals("TRUE") && LiberacaoPedidoBLL.isVendasAPIDisponivel(dbConnection))
				{
					LiberacaoPedidoBLL.LiberaPedidoVendasApi(dbConnection, dbConnection2);
				}
				else if (ConfigHelper.getAppConfig("HabilitarNovaPedTmk").ToUpper().Equals("TRUE"))
				{
					LiberacaoPedidoBLL.LiberaPedidosNovaLiberacao(dbConnection, dbConnection2);
				}
				else
				{
					LiberacaoPedidoBLL.LiberaPedidos(dbConnection, dbConnection2, _LiberaAutoNomeProcesso, _LiberaAutoCaminhoExe, _LiberaAutoConnOdbc, _LiberaAutoTimeout, _LiberaAutoNumeroTentativas, _LiberaAutoUsuarioLiberacao, null, _LiberaAutoQtdeLiberacaoSimultanea);
				}
				dbConnection2.Close();
				dbConnection.Close();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void GeraCarga()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "GeraCarga");
			controleProcessoSimultaneo.IniciaProcesso();
			ForcaCargaCompleta();
			new CargaGeralBLL(_StringConnTargetMob, _NomeServidorOrigemReplicacao, _NomeDbOrigemReplicacao, _TargetMobPath, _GeracaoLogaEtapa).Gera();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void GeraDados(bool multiThread)
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "GeraDados");
			controleProcessoSimultaneo.IniciaProcesso();
			new GeraDadosBLL(_StringConnTargetErp, multiThread).Gera();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void ForcaCargaCompleta()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "ForcaCargaCompleta");
			controleProcessoSimultaneo.IniciaProcesso();
			string cnpj = EmpresaBLL.GetCnpj(_StringConnTargetErp);
			new ImportForcaCargaCompleta(_StringConnTargetMob, cnpj, _bindingBasicHttp, _remoteAddress).Importar();
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void LimpaDadosAntigos()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "Limpeza");
			controleProcessoSimultaneo.IniciaProcesso();
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetMob))
			{
				dbConnection.SetCommandTimeout(0);
				dbConnection.Open();
				dbConnection.ClearParameters();
				dbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "uspLimparDadosMOB");
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@NomeTabela", "Carga");
				dbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "uspReindex");
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@NomeTabela", "GeracaoLogErro");
				dbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "uspReindex");
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@NomeTabela", "GeracaoItem");
				dbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "uspReindex");
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@NomeTabela", "Geracao");
				dbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "uspReindex");
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@NomeTabela", "RelatorioGerencial");
				dbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "uspReindex");
				dbConnection.Close();
			}
			using (DbConnection dbConnection2 = new DbConnection(_StringConnTargetErp))
			{
				dbConnection2.SetCommandTimeout(0);
				dbConnection2.Open();
				dbConnection2.ClearParameters();
				dbConnection2.ExecuteNonQuery(CommandType.StoredProcedure, "uspTGTMOB_HistoricoPedVda");
				dbConnection2.ClearParameters();
				dbConnection2.ExecuteNonQuery(CommandType.StoredProcedure, "tgtmob_uspLimparDados");
				dbConnection2.Close();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void GravaRelatorio()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "GravaRelatorio");
			controleProcessoSimultaneo.IniciaProcesso();
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetMob))
			{
				dbConnection.Open();
				RelatorioGerencialBLL.GravarRelatorio(dbConnection, _PathMobRelatorioOrigem, _PathMobRelatorioDestino);
				dbConnection.Close();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void GeraRelatorio()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "GeraRelatorio");
			controleProcessoSimultaneo.IniciaProcesso();
			TipoGrupoTO[] array = null;
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetMob))
			{
				dbConnection.Open();
				array = TipoGrupoBLL.Select(dbConnection, null, null, true);
				if (array != null)
				{
					using (DbConnection dbConnection2 = new DbConnection(_StringConnTargetErp))
					{
						dbConnection2.Open();
						RelatorioPreDefinidoBLL.Select_Carga(dbConnection2, _NomeDbOrigemReplicacao, _NomeServidorOrigemReplicacao, dbConnection);
						dbConnection2.Close();
					}
					VendedorRelatorioTO vendedorRelatorioTO = new VendedorRelatorioTO();
					VendedorRelatorioTO[] array2 = null;
					TipoGrupoSPTO tipoGrupoSPTO = new TipoGrupoSPTO();
					TipoGrupoSPTO[] array3 = null;
					TipoGrupoTO[] array4 = array;
					foreach (TipoGrupoTO tipoGrupoTO in array4)
					{
						vendedorRelatorioTO.IDTipoGrupo = tipoGrupoTO.IdTipoGrupo;
						vendedorRelatorioTO.Ativo = true;
						array2 = VendedorRelatoBLL.Select(dbConnection, vendedorRelatorioTO);
						tipoGrupoSPTO.IDTipoGrupo = tipoGrupoTO.IdTipoGrupo;
						array3 = TipoGrupoSPBLL.Select(dbConnection, tipoGrupoSPTO);
						if (array2 == null || array3 == null)
						{
							continue;
						}
						string empty = string.Empty;
						int? num = null;
						VendedorRelatorioTO[] array5 = array2;
						foreach (VendedorRelatorioTO obj in array5)
						{
							empty = obj.CodigoVendedor.Trim();
							num = obj.IdVendedor;
							CadastroSPTO[] array6 = null;
							TipoGrupoSPTO[] array7 = array3;
							foreach (TipoGrupoSPTO tipoGrupoSPTO2 in array7)
							{
								CadastroSPTO cadastroSPTO = new CadastroSPTO();
								cadastroSPTO.IDCadastroSP = tipoGrupoSPTO2.IDCadastroSP;
								cadastroSPTO.Ativo = true;
								array6 = CadastroSPBLL.Select(dbConnection, cadastroSPTO);
								if (array6.Count() <= 0)
								{
									continue;
								}
								using DbConnection dbConnection3 = new DbConnection(_StringConnTargetErp);
								dbConnection3.Open();
								CadastroSPTO[] array8 = array6;
								foreach (CadastroSPTO cadastroSPTO2 in array8)
								{
									try
									{
										CadastroSPBLL.GerarRelatorioPreDefinidos(dbConnection3, cadastroSPTO2, num, empty, _PathMobRelatorioOrigem);
									}
									catch (Exception ex)
									{
										MethodBase currentMethod = MethodBase.GetCurrentMethod();
										LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, "Relatorio não gerado. Vendedor: " + empty + " - Relatorio: " + cadastroSPTO2.Descricao + " - Erro: " + ex.Message, EventLogEntryType.Information);
									}
								}
								dbConnection3.Close();
							}
						}
					}
				}
				dbConnection.Close();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex2)
		{
			MethodBase currentMethod2 = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod2.Name, ex2.Message, EventLogEntryType.Information);
		}
	}

	public bool PermiteExecucaoServico(string nomeServico)
	{
		bool flag = false;
		using SqlConnection sqlConnection = new SqlConnection(_StringConnTargetMob);
		using SqlCommand sqlCommand = new SqlCommand("uspPermiteExecucaoServico", sqlConnection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@NomeServico", nomeServico);
		sqlConnection.Open();
		flag = (bool)sqlCommand.ExecuteScalar();
		sqlConnection.Close();
		return flag;
	}

	public void EmailTransfer()
	{
		try
		{
			if (!SistemaAutenticado())
			{
				return;
			}
			using ControleProcessoSimultaneo controleProcessoSimultaneo = new ControleProcessoSimultaneo(_StringConnTargetErp, "EmailTransfer");
			controleProcessoSimultaneo.IniciaProcesso();
			using (DbConnection dbConnection = new DbConnection(_StringConnTargetErp))
			{
				dbConnection.Open();
				EmailTransferBLL.Enviar(dbConnection, _EmailSmtpServidor, _EmailSmtpPort, _EmailUser, _EmailPassword, _EmailUseSSL, _EmailFrom);
				dbConnection.Close();
			}
			controleProcessoSimultaneo.EncerraProcesso();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Information);
		}
	}

	public void TesteEmailTransfer()
	{
		EmailTransferBLL.EnviarTeste(_EmailSmtpServidor, _EmailSmtpPort, _EmailUser, _EmailPassword, _EmailUseSSL, _EmailFrom);
	}

	public bool SistemaAutenticado()
	{
		if (Environment.MachineName.Equals("RMATEUS"))
		{
			return true;
		}
		string text = ConfigHelper.getAppConfig("Autenticado").ToUpper().Trim();
		if (string.IsNullOrEmpty(text) || text.Equals("FALSE"))
		{
			return false;
		}
		return true;
	}

	public string GetApiBaseAddress()
	{
		return _ApiBaseAddress;
	}
}
