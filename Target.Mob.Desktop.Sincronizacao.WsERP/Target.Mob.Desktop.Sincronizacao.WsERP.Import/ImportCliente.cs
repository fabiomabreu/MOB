using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

internal class ImportCliente
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private int _IdCliente;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	private ClienteTO clienteERP;

	public ImportCliente(string stringConnTargetErp, string stringConnTargetMob, int idCliente, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_IdCliente = idCliente;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar(object eventosAtivos)
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		using DbConnection dbConnection2 = new DbConnection(_StringConnTargetMob);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			RetornoWsModelOfClienteWsModel retornoWsModelOfClienteWsModel = wsErpSoapClient.WsERP_Cliente_GetV2(validationSoapHeader, _CnpjEmpresa, _IdCliente, Seguranca.getHostName());
			if (retornoWsModelOfClienteWsModel.RetornoWs != null)
			{
				ClienteWsModel retornoWs = retornoWsModelOfClienteWsModel.RetornoWs;
				dbConnection.Open();
				dbConnection2.Open();
				ClienteTO clienteTO = ConstruirCliente(dbConnection, dbConnection2, retornoWs);
				SituacaoCliente situacaoCliente = SituacaoCliente.Provisorio;
				if (clienteTO != null && retornoWs.CodigoClienteProspeccao.HasValue && retornoWs.CodigoClienteProspeccao > 0)
				{
					clienteERP = ClienteBLL.SelectByCdClien(_StringConnTargetErp, retornoWs.CodigoClienteProspeccao.Value, carregaFilhos: true);
					if (clienteERP == null)
					{
						throw new Exception($"Cliente não encontrado para atualização, Código ERP: {retornoWs.CodigoClienteProspeccao}");
					}
					situacaoCliente = clienteERP.Situacao;
				}
				if (!"A".ToUpper().Equals(retornoWs.TipoOperacao))
				{
					dbConnection.BeginTransaction();
					try
					{
						if (SituacaoCliente.Prospeccao.Equals(situacaoCliente))
						{
							clienteTO.CdClien = retornoWs.CodigoClienteProspeccao.Value;
							clienteTO.Situacao = SituacaoCliente.Provisorio;
							ClienteBLL.Update(dbConnection, clienteTO);
						}
						else
						{
							EndCliTO endCliTO = null;
							EndCliTO[] oEndCli = clienteTO.oEndCli;
							foreach (EndCliTO endCliTO2 in oEndCli)
							{
								if (endCliTO2.TpEnd == TipoEndereco.Entrega)
								{
									endCliTO = (EndCliTO)endCliTO2.Clone();
									endCliTO2.Latitude = default(decimal);
									endCliTO2.Longitude = default(decimal);
									endCliTO2.FonteCoordenadaID = 1;
								}
							}
							ClienteBLL.Insert(dbConnection, clienteTO);
							if (endCliTO.Latitude.HasValue && endCliTO.Longitude.HasValue)
							{
								decimal? latitude = endCliTO.Latitude;
								if (!((latitude.GetValueOrDefault() == default(decimal)) & latitude.HasValue))
								{
									latitude = endCliTO.Longitude;
									if (!((latitude.GetValueOrDefault() == default(decimal)) & latitude.HasValue) && endCliTO.FonteCoordenadaID > 0)
									{
										VendedorTO vendedorTO = VendedorBLL.Select(dbConnection2.GetConnection(), retornoWs.IDVendedor);
										CoordenadaClienteBLL.InsereCoordenadaCliente(dbConnection, clienteTO.CdClien, endCliTO.Latitude, endCliTO.Longitude, vendedorTO.CodigoVendedor, clienteTO.DtCad);
									}
								}
							}
						}
						if (!SituacaoCliente.Prospeccao.Equals(situacaoCliente) && ClienteDuplicado(dbConnection, clienteTO))
						{
							dbConnection.RollbackTransaction();
							GeraNotificacaoParaVendedor(dbConnection, dbConnection2, retornoWs);
						}
						else
						{
							dbConnection.CommitTransaction();
						}
					}
					catch (Exception ex)
					{
						dbConnection.RollbackTransaction();
						throw ex;
					}
				}
				else
				{
					dbConnection.BeginTransaction();
					try
					{
						if (retornoWs.CodigoClienteProspeccao.HasValue && retornoWs.CodigoClienteProspeccao > 0)
						{
							ClienteBLL.UpdateLimitadoProspeccao(dbConnection, clienteTO, retornoWs.CodigoClienteProspeccao.Value, _StringConnTargetErp);
						}
						else
						{
							ClienteBLL.UpdateLimitado(dbConnection, clienteTO, _StringConnTargetErp);
						}
						dbConnection.CommitTransaction();
					}
					catch (Exception ex2)
					{
						dbConnection.RollbackTransaction();
						throw ex2;
					}
				}
				if (wsErpSoapClient.WsERP_Cliente_SetImportar(validationSoapHeader, _CnpjEmpresa, _IdCliente, Seguranca.getHostName()).RetornoWs)
				{
					AtualizacaoMovimentoTO atualizacaoMovimentoTO = new AtualizacaoMovimentoTO();
					atualizacaoMovimentoTO.Tabela = "Cliente";
					if (AtualizacaoMovimentoBLL.Exists(dbConnection, atualizacaoMovimentoTO))
					{
						atualizacaoMovimentoTO.ID = _IdCliente;
						AtualizacaoMovimentoBLL.Update(dbConnection, atualizacaoMovimentoTO);
					}
					else
					{
						atualizacaoMovimentoTO.ID = _IdCliente;
						AtualizacaoMovimentoBLL.Insert(dbConnection, atualizacaoMovimentoTO);
					}
				}
				dbConnection2.Close();
				dbConnection.Close();
				return;
			}
			throw new Exception(retornoWsModelOfClienteWsModel.Excecao.Erro);
		}
		catch (Exception ex3)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex3.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
			dbConnection2.Close();
			((CountdownEvent)eventosAtivos).Signal();
		}
	}

	private void GeraNotificacaoParaVendedor(DbConnection connTargetErp, DbConnection connTargetMob, ClienteWsModel clienteWs)
	{
		if (string.IsNullOrEmpty(clienteWs.CnpjCpf))
		{
			return;
		}
		ClienteTO clienteTO = ClienteBLL.SelectByCnpjEPais(_StringConnTargetErp, clienteWs.CnpjCpf, obterPaisDoEndCliWs(clienteWs), loadFilhos: false);
		if (clienteTO != null)
		{
			string descricao = "";
			string text = "";
			VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), clienteWs.IDVendedor);
			if (vendedorTO != null)
			{
				text = vendedorTO.CodigoVendedor;
			}
			string codigoPaisPorVendedor = VendedorErpBLL.getCodigoPaisPorVendedor(connTargetErp, text);
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			switch (codigoPaisPorVendedor)
			{
			case "ESP":
				text2 = "Cliente ";
				text3 = " con el CIF/NIF ";
				text4 = " ya se encuentra registrado e inactivo en la base de datos. Póngase en contacto con la distribuidora";
				text5 = " se encuentra en la cartera de otro vendedor. Póngase en contacto con la distribuidora";
				text6 = " registrado y activo. Póngase en contacto con la distribuidora";
				text7 = "Error en el registro del cliente";
				break;
			default:
				text2 = "Cliente ";
				text3 = " com o CNPJ/CPF ";
				text4 = " já se encontra cadastrado e inativo na base do ERP. Entre em contato com a distribuidora";
				text5 = " se encontra na carteira de outro vendedor. Entre em contato com a distribuidora";
				text6 = " cadastrado e ativo. Entre em contato com a distribuidora";
				text7 = "Erro no Cadastro do Cliente";
				break;
			}
			if (!clienteTO.Ativo)
			{
				descricao = text2 + clienteTO.Nome + text3 + clienteTO.CgcCpf + text4;
			}
			else if (clienteTO.Ativo)
			{
				descricao = ((!(clienteTO.CdVend != text)) ? (text2 + clienteTO.Nome + text3 + clienteTO.CgcCpf + text6) : (text2 + clienteTO.Nome + text3 + clienteTO.CgcCpf + text5));
			}
			NotificacaoTO notificacaoTO = new NotificacaoTO();
			notificacaoTO.IDTipoNotificacao = 7;
			notificacaoTO.DataPublicacao = DateTime.Now;
			notificacaoTO.Titulo = text7;
			notificacaoTO.Descricao = descricao;
			notificacaoTO.IDVendedor = clienteWs.IDVendedor;
			notificacaoTO.CodigoVendedor = text;
			NotificacaoBLL.Insert(connTargetMob, notificacaoTO);
		}
	}

	private string obterPaisDoEndCliWs(ClienteWsModel clienteWs)
	{
		return (from p in clienteWs.EndCliWs.ToList()
			where "FA".Equals(p.TipoEndereco)
			select p.Pais)?.FirstOrDefault();
	}

	public ClienteTO ConstruirCliente(DbConnection connTargetErp, DbConnection connTargetMob, ClienteWsModel clienteWs)
	{
		ClienteTO clienteTO = new ClienteTO();
		clienteTO.AltTabPrecoAfv = clienteWs.PermiteAlterarTabPre;
		clienteTO.AltTpPedAfv = clienteWs.PermiteAlterarTpPed;
		clienteTO.Ativo = true;
		clienteTO.CdForn = clienteWs.CodigoTransportadora;
		clienteTO.CdGrupocli = clienteWs.CodigoGrupoCli;
		clienteTO.CgcCpf = clienteWs.CnpjCpf;
		clienteTO.Desconto = clienteWs.PercDesconto;
		clienteTO.DtCad = DateTime.Now;
		clienteTO.DtUltAlt = DateTime.Now;
		clienteTO.DtUltCompra = clienteWs.DtUltimaCompra;
		clienteTO.DtUltContato = DateTime.Now;
		clienteTO.DtValProdControlado = clienteWs.DtPrazoProdutoControlado;
		clienteTO.EMail = clienteWs.Email;
		clienteTO.Inscricao = clienteWs.Inscricao;
		clienteTO.Nome = clienteWs.RazaoSocial;
		clienteTO.NomeRes = clienteWs.NomeFantasia;
		clienteTO.NumLock = 0;
		clienteTO.ProdControlado = Convert.ToInt32(clienteWs.ProdutoControlado);
		clienteTO.RamAtiv = clienteWs.CodigoRamAtiv;
		clienteTO.Situacao = SituacaoCliente.Provisorio;
		clienteTO.StCred = clienteWs.CodigoStCred;
		clienteTO.TpCliente = TipoCliente.Cliente;
		clienteTO.AtribuiTpFrete(clienteWs.TipoFrete);
		clienteTO.AtribuiTpInscr(clienteWs.TipoInscricao);
		clienteTO.TpPed = clienteWs.CodigoTpPed;
		clienteTO.AtribuiTpPes(clienteWs.TipoPessoa);
		clienteTO.VlLimCred = clienteWs.TotalLimiteCredito;
		clienteTO.QtdeCheckout = clienteWs.QtdeCheckout;
		clienteTO.TipoOperacao = clienteWs.TipoOperacao;
		clienteTO.SeqTribCli = clienteWs.CodigoTributacao;
		clienteTO.WebSite = clienteWs.WebSite;
		clienteTO.Iban = clienteWs.Iban;
		clienteTO.DtFundacao = clienteWs.DtFundacao;
		EmpresaTO[] array = EmpresaBLL.Select(connTargetErp, null, null, null, null, true);
		if (array.Length != 0)
		{
			clienteTO.CdEmp = array[0].CdEmp;
			VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), clienteWs.IDVendedor);
			if (vendedorTO != null)
			{
				clienteTO.CdVend = vendedorTO.CodigoVendedor;
				if (clienteWs.TextoGeral != null && clienteWs.TextoGeral != "")
				{
					TextoTO textoTO = new TextoTO();
					textoTO.GeraTexto(clienteWs.TextoGeral);
					TextoBLL.Insert(connTargetErp, textoTO);
					clienteTO.CdTexto = textoTO.CdTexto;
				}
				if (clienteWs.TextoAlerta != null && clienteWs.TextoAlerta != "")
				{
					TextoTO textoTO2 = new TextoTO();
					textoTO2.GeraTexto(clienteWs.TextoAlerta);
					TextoBLL.Insert(connTargetErp, textoTO2);
					clienteTO.CdTextoAlerta = textoTO2.CdTexto;
				}
				if (clienteWs.TextoExpedicao != null && clienteWs.TextoExpedicao != "")
				{
					TextoTO textoTO3 = new TextoTO();
					textoTO3.GeraTexto(clienteWs.TextoExpedicao);
					TextoBLL.Insert(connTargetErp, textoTO3);
					clienteTO.CdTextoExpe = textoTO3.CdTexto;
				}
				List<ContCliTO> list = new List<ContCliTO>();
				ContCliWsModel[] contCliWs = clienteWs.ContCliWs;
				foreach (ContCliWsModel contCliWsModel in contCliWs)
				{
					ContCliTO contCliTO = new ContCliTO();
					contCliTO.Aniversario = contCliWsModel.DtAniversario;
					contCliTO.Cargo = contCliWsModel.Cargo;
					contCliTO.Email = contCliWsModel.Email;
					contCliTO.EmailComercial = contCliWsModel.EmailComercial;
					if (!contCliWsModel.DDD.HasValue)
					{
						contCliTO.Ddd = null;
					}
					else
					{
						contCliTO.Ddd = (short?)contCliWsModel.DDD;
					}
					if (!contCliWsModel.Telefone.HasValue)
					{
						contCliTO.Fone = null;
					}
					else
					{
						contCliTO.Fone = contCliWsModel.Telefone.Value;
					}
					contCliTO.Hobby = contCliWsModel.Hobby;
					contCliTO.Nome = contCliWsModel.Nome;
					contCliTO.Seq = contCliWsModel.Seq.Value;
					contCliTO.Time = contCliWsModel.Time;
					contCliTO.TpTel = contCliWsModel.TpTel;
					contCliTO.TipoOperacao = contCliWsModel.TipoOperacao;
					contCliTO.EmailNFe = contCliWsModel.EmailNFe;
					contCliTO.EmailFinanceiro = contCliWsModel.EmailFinanceiro;
					contCliTO.CargoID = contCliWsModel.IdCargo;
					contCliTO.EnviaWhatsAppEcommerce = contCliWsModel.EnviaWhatsAppEcommerce;
					list.Add(contCliTO);
				}
				clienteTO.oContCli = list.ToArray();
				List<EndCliTO> list2 = new List<EndCliTO>();
				EndCliWsModel[] endCliWs = clienteWs.EndCliWs;
				foreach (EndCliWsModel endCliWsModel in endCliWs)
				{
					EndCliTO endCliTO = new EndCliTO();
					endCliTO.AtribuiTpEnd(endCliWsModel.TipoEndereco);
					endCliTO.Bairro = endCliWsModel.Bairro;
					string text = endCliWsModel.Logradouro + ", " + endCliWsModel.Numero + ", " + endCliWsModel.Complemento;
					if (text.Substring(text.Length - 1, 1).Equals(","))
					{
						endCliTO.Endereco = text.Remove(text.Length - 1);
					}
					else
					{
						endCliTO.Endereco = text;
					}
					endCliTO.IncMobLogradouro = endCliWsModel.Logradouro;
					endCliTO.IncMobNumero = endCliWsModel.Numero;
					endCliTO.IncMobComplemento = endCliWsModel.Complemento;
					endCliTO.Estado = endCliWsModel.CodigoEstado;
					endCliTO.Municipio = endCliWsModel.Municipio;
					endCliTO.CdPais = (string.IsNullOrEmpty(endCliWsModel.Pais) ? "BRA" : endCliWsModel.Pais.ToUpper());
					if ("BRA".Equals(endCliTO.CdPais))
					{
						int result = 0;
						if (int.TryParse(endCliWsModel.Cep, out result))
						{
							endCliTO.Cep = result;
						}
						else
						{
							endCliTO.Cep = 0;
						}
					}
					else
					{
						endCliTO.Cep = 0;
						endCliTO.CodigoPostal = endCliWsModel.Cep;
					}
					endCliTO.Latitude = endCliWsModel.Latitude;
					endCliTO.Longitude = endCliWsModel.Longitude;
					endCliTO.Distrito = endCliWsModel.Distrito;
					endCliTO.FonteCoordenadaID = 2;
					endCliTO.OrigemCoordenadaID = 1;
					endCliTO.TipoOperacao = endCliWsModel.TipoOperacao;
					list2.Add(endCliTO);
				}
				clienteTO.oEndCli = list2.ToArray();
				List<TelCliTO> list3 = new List<TelCliTO>();
				TelCliWsModel[] telCliWs = clienteWs.TelCliWs;
				foreach (TelCliWsModel telCliWsModel in telCliWs)
				{
					TelCliTO telCliTO = new TelCliTO();
					telCliTO.Compl = telCliWsModel.Complemento;
					telCliTO.Ddd = telCliWsModel.DDD;
					telCliTO.Numero = telCliWsModel.Telefone.Value;
					telCliTO.Seq = telCliWsModel.Seq.Value;
					telCliTO.TpTel = telCliWsModel.CodigoTpTel;
					telCliTO.TipoOperacao = telCliWsModel.TipoOperacao;
					list3.Add(telCliTO);
				}
				clienteTO.oTelCli = list3.ToArray();
				List<ClientePermCompTO> list4 = new List<ClientePermCompTO>();
				ClientePermCompWsModel[] clientePermCompWs = clienteWs.ClientePermCompWs;
				foreach (ClientePermCompWsModel clientePermCompWsModel in clientePermCompWs)
				{
					ClientePermCompTO clientePermCompTO = new ClientePermCompTO();
					clientePermCompTO.CdDoc = clientePermCompWsModel.CodigoDocumento.Value;
					clientePermCompTO.NumeroDoc = clientePermCompWsModel.NumeroDocumento;
					clientePermCompTO.DtVencimento = clientePermCompWsModel.DtVencimento;
					clientePermCompTO.SitRegular = clientePermCompWsModel.SitRegular;
					list4.Add(clientePermCompTO);
				}
				clienteTO.OPermComp = list4.ToArray();
				return clienteTO;
			}
			throw new Exception($"Vendedor não localizado na tabela de configuração de vendedores. IdVendedor: {clienteWs.IDVendedor}");
		}
		throw new Exception("Nenhuma empresa ativa foi localizada");
	}

	private bool ClienteDuplicado(DbConnection connTargetErp, ClienteTO cliente)
	{
		string cgcCpf = cliente.CgcCpf;
		return ClienteBLL.Count(connTargetErp, cgcCpf) != 1;
	}
}
