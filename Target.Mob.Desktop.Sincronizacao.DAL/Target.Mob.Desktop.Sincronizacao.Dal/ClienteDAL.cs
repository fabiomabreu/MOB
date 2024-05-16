using System;
using System.Collections;
using System.Data;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ClienteDAL
{
	private const string INSERT = "uspClienteInsert";

	private const string UPDATE = "uspClienteUpdate";

	private const string SELECT_BY_CNPJ = "uspClienteSelectByCNPJ";

	private const string SELECT_BY_CNPJ_PAIS = "uspClienteSelectByCnpjEPais";

	private const string SELECT_BY_CDCLIEN = "uspClienteSelectByCdClien";

	private const string EXISTS = "uspClienteExists";

	private const string COUNT = "uspClienteCount";

	private const string SELECTEXPORT = "uspClienteSelectExport";

	private const string UPDATE_LIMITADO = "uspClienteUpdateLimitado";

	public static void Insert(DbConnection connection, ClienteTO instance)
	{
		connection.ClearParameters();
		setParametros(connection, instance);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspClienteInsert");
	}

	public static void UpdateLimitado(DbConnection connection, ClienteTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@e_mail", instance.EMail);
		connection.AddParameters("@QtdeCheckout", instance.QtdeCheckout);
		connection.AddParameters("@iban", instance.Iban);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspClienteUpdateLimitado");
	}

	public static ClienteTO[] SelectExport(DbConnection connection, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspClienteSelectExport"));
	}

	public static bool Exists(string strConnectionERP, string CgcCpf)
	{
		using DbConnection dbConnection = new DbConnection(strConnectionERP);
		dbConnection.Open();
		dbConnection.ClearParameters();
		dbConnection.AddParameters("@cgc_cpf", CgcCpf);
		object obj = dbConnection.ExecuteScalar(CommandType.StoredProcedure, "uspClienteExists");
		return obj != null && int.Parse(obj.ToString()) == 1;
	}

	public static int Count(DbConnection connection, string CgcCpf)
	{
		connection.ClearParameters();
		connection.AddParameters("@cgc_cpf", CgcCpf);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, "uspClienteCount"));
	}

	private static ClienteTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ClienteTO clienteTO = new ClienteTO();
				clienteTO.CdClien = rs.GetInteger("cd_clien");
				string @string = rs.GetString("tp_cliente");
				if (!(@string == "CL"))
				{
					if (@string == "DI")
					{
						clienteTO.TpCliente = TipoCliente.Distribuidora;
					}
					else
					{
						clienteTO.TpCliente = TipoCliente.Cliente;
					}
				}
				else
				{
					clienteTO.TpCliente = TipoCliente.Cliente;
				}
				clienteTO.Nome = rs.GetString("nome");
				clienteTO.NomeRes = rs.GetString("nome_res");
				@string = rs.GetString("tp_pes");
				if (!(@string == "F"))
				{
					if (@string == "J")
					{
						clienteTO.TpPes = TipoPessoa.Juridica;
					}
					else
					{
						clienteTO.TpPes = TipoPessoa.Juridica;
					}
				}
				else
				{
					clienteTO.TpPes = TipoPessoa.Fisica;
				}
				clienteTO.CgcCpf = rs.GetString("cgc_cpf");
				switch (rs.GetString("tp_inscr"))
				{
				case "I":
					clienteTO.TpInscr = TipoInscricao.Isento;
					break;
				case "E":
					clienteTO.TpInscr = TipoInscricao.Estadual;
					break;
				case "M":
					clienteTO.TpInscr = TipoInscricao.Municipal;
					break;
				default:
					clienteTO.TpInscr = TipoInscricao.Isento;
					break;
				}
				clienteTO.Inscricao = rs.GetString("inscricao");
				clienteTO.RamAtiv = rs.GetString("ram_ativ");
				clienteTO.StCred = rs.GetString("st_cred");
				clienteTO.Crt = rs.GetString("crt");
				clienteTO.CdGrupocli = rs.GetString("cd_grupocli");
				clienteTO.CdClienCol = rs.GetNullableInteger("cd_clien_col");
				clienteTO.CdArea = rs.GetString("cd_area");
				clienteTO.DtCad = rs.GetDateTime("dt_cad");
				clienteTO.CdVend = rs.GetString("cd_vend");
				clienteTO.DtUltAlt = rs.GetNullableDateTime("dt_ult_alt");
				clienteTO.CdTexto = rs.GetNullableInteger("cd_texto");
				clienteTO.DtMaiorAcumulo = rs.GetNullableDateTime("dt_maior_acumulo");
				clienteTO.VlMaiorAcumulo = rs.GetNullableDecimal("vl_maior_acumulo");
				clienteTO.DtMaiorCompra = rs.GetNullableDateTime("dt_maior_compra");
				clienteTO.DtPrimCompra = rs.GetNullableDateTime("dt_prim_compra");
				clienteTO.VlMaiorCompra = rs.GetNullableDecimal("vl_maior_compra");
				clienteTO.QtdeCompraMes = rs.GetNullableDecimal("qtde_compra_mes");
				clienteTO.DtUltCompra = rs.GetNullableDateTime("dt_ult_compra");
				clienteTO.VlUltCompra = rs.GetNullableDecimal("vl_ult_compra");
				clienteTO.VlLimCred = rs.GetNullableDecimal("vl_lim_cred");
				clienteTO.DtUltContato = rs.GetNullableDateTime("dt_ult_contato");
				clienteTO.CdRotPrdf = rs.GetString("cd_rot_prdf");
				clienteTO.SeqRotPrdf = rs.GetNullableInteger("seq_rot_prdf");
				clienteTO.RotVisita = rs.GetString("rot_visita");
				clienteTO.SeqVisita = rs.GetNullableDecimal("seq_visita");
				clienteTO.TurmaPlantao = rs.GetString("turma_plantao");
				clienteTO.MedAtraso = rs.GetNullableInteger("med_atraso");
				clienteTO.TotProtestos = rs.GetNullableInteger("tot_protestos");
				clienteTO.CdTextoCred = rs.GetNullableInteger("cd_texto_cred");
				switch (rs.GetString("situacao"))
				{
				case "PR":
					clienteTO.Situacao = SituacaoCliente.Provisorio;
					break;
				case "CO":
					clienteTO.Situacao = SituacaoCliente.Completo;
					break;
				case "CP":
					clienteTO.Situacao = SituacaoCliente.Prospeccao;
					break;
				default:
					clienteTO.Situacao = SituacaoCliente.Provisorio;
					break;
				}
				clienteTO.NuDiasProtesto = rs.GetNullableInteger("nu_dias_protesto");
				clienteTO.Desconto = rs.GetNullableDecimal("desconto");
				clienteTO.VendaEspecial = rs.GetNullableInteger("venda_especial");
				clienteTO.Suframa = rs.GetNullableInteger("suframa");
				clienteTO.CdSuframa = rs.GetString("cd_suframa");
				clienteTO.Fornec = rs.GetNullableInteger("fornec");
				clienteTO.Estrangeiro = rs.GetNullableInteger("estrangeiro");
				clienteTO.CdTextoAlerta = rs.GetNullableInteger("cd_texto_alerta");
				clienteTO.CdTextoNf = rs.GetNullableInteger("cd_texto_nf");
				clienteTO.WebSite = rs.GetString("web_site");
				clienteTO.EMail = rs.GetString("e_mail");
				@string = rs.GetString("tp_frete");
				if (!(@string == "C"))
				{
					if (@string == "F")
					{
						clienteTO.TpFrete = TipoFrete.FOB;
					}
					else
					{
						clienteTO.TpFrete = TipoFrete.CIF;
					}
				}
				else
				{
					clienteTO.TpFrete = TipoFrete.CIF;
				}
				clienteTO.CdForn = rs.GetNullableInteger("cd_forn");
				clienteTO.NumLock = rs.GetInteger("num_lock");
				try
				{
					clienteTO.Ativo = rs.GetBoolean("ativo");
				}
				catch (Exception)
				{
					clienteTO.Ativo = rs.GetInteger("ativo") == 1;
				}
				clienteTO.Ean13 = rs.GetString("ean13");
				clienteTO.PotCompraMes = rs.GetNullableDecimal("pot_compra_mes");
				clienteTO.PercComis = rs.GetNullableDecimal("perc_comis");
				clienteTO.TpPed = rs.GetString("tp_ped");
				clienteTO.CobraBoleto = rs.GetNullableInteger("cobra_boleto");
				clienteTO.CdTextoExpe = rs.GetNullableInteger("cd_texto_expe");
				clienteTO.AtualizaLimCred = rs.GetNullableInteger("atualiza_lim_cred");
				clienteTO.ProdControlado = rs.GetNullableInteger("prod_controlado");
				clienteTO.EnviarArqGenexis = rs.GetInteger("enviar_arq_genexis");
				clienteTO.ClienteNovoGenexis = rs.GetInteger("cliente_novo_genexis");
				clienteTO.EnviarArqJanssen = rs.GetInteger("enviar_arq_janssen");
				clienteTO.ClienteNovoJanssen = rs.GetInteger("cliente_novo_janssen");
				clienteTO.DtValProdControlado = rs.GetNullableDateTime("dt_val_prod_controlado");
				clienteTO.EnviarArqNestle = rs.GetInteger("enviar_arq_nestle");
				clienteTO.EnvioSerasa = rs.GetNullableInteger("envio_serasa");
				clienteTO.CdGrdescli = rs.GetString("cd_grdescli");
				clienteTO.CdTpFreqVisita = rs.GetString("cd_tp_freq_visita");
				clienteTO.CdEmp = rs.GetNullableInteger("cd_emp");
				clienteTO.Senha = rs.GetString("senha");
				clienteTO.TolerJurosQtdeDias = rs.GetNullableInteger("toler_juros_qtde_dias");
				clienteTO.TolerJurosAteVenc = rs.GetNullableInteger("toler_juros_ate_venc");
				clienteTO.CodClf = rs.GetString("cod_clf");
				clienteTO.AreaLivreComercio = rs.GetNullableInteger("area_livre_comercio");
				clienteTO.DiasProrrVenc = rs.GetNullableInteger("dias_prorr_venc");
				clienteTO.ClienteNovoProceda = rs.GetInteger("cliente_novo_proceda");
				clienteTO.EnviarArqProceda = rs.GetInteger("enviar_arq_proceda");
				clienteTO.NaoFatMaiorUn = rs.GetNullableInteger("nao_fat_maior_un");
				clienteTO.ClienteNovoNestle = rs.GetInteger("cliente_novo_nestle");
				clienteTO.CdColigacao = rs.GetString("cd_coligacao");
				clienteTO.DtUltAltLimCred = rs.GetNullableDateTime("dt_ult_alt_lim_cred");
				clienteTO.DtRecadastramento = rs.GetNullableDateTime("dt_recadastramento");
				clienteTO.EstrangeiroNuDoc = rs.GetString("estrangeiro_nu_doc");
				clienteTO.AtuUltMaiorCompra = rs.GetInteger("atu_ult_maior_compra");
				clienteTO.EnviaArqMasterfoods = rs.GetNullableInteger("envia_arq_masterfoods");
				clienteTO.DtPenultCompra = rs.GetNullableDateTime("dt_penult_compra");
				clienteTO.VlPenultCompra = rs.GetNullableDecimal("vl_penult_compra");
				clienteTO.EnviadoRedbull = rs.GetNullableInteger("enviado_redbull");
				clienteTO.Consumidor = rs.GetNullableInteger("consumidor");
				clienteTO.PercAceitoPrazoValidade = rs.GetNullableDecimal("perc_aceito_prazo_validade");
				clienteTO.CobraSeguro = rs.GetNullableInteger("cobra_seguro");
				clienteTO.BloqAtuUltMaiorCompra = rs.GetNullableInteger("bloq_atu_ult_maior_compra");
				clienteTO.PercDescFinAuto = rs.GetNullableDecimal("perc_desc_fin_auto");
				clienteTO.EnviarArqPharmadis = rs.GetNullableBoolean("enviar_arq_pharmadis");
				clienteTO.ClienteNovoPharmadis = rs.GetNullableBoolean("cliente_novo_pharmadis");
				clienteTO.NcUtilCfgAbatClien = rs.GetNullableInteger("nc_util_cfg_abat_clien");
				switch (rs.GetString("nc_tp_abat_clien"))
				{
				case "AF":
					clienteTO.NcTpAbatClien = TipoAbatNotaCreditoCliente.AutomaticoFaturamento;
					break;
				case "CF":
					clienteTO.NcTpAbatClien = TipoAbatNotaCreditoCliente.Confirmacao;
					break;
				case "MA":
					clienteTO.NcTpAbatClien = TipoAbatNotaCreditoCliente.ManualCtaRec;
					break;
				default:
					clienteTO.NcTpAbatClien = TipoAbatNotaCreditoCliente.Confirmacao;
					break;
				}
				clienteTO.CdVendTecnico = rs.GetString("cd_vend_tecnico");
				clienteTO.CdFornInst = rs.GetNullableInteger("cd_forn_inst");
				clienteTO.ImpDescGrdCom = rs.GetNullableInteger("imp_desc_grd_com");
				clienteTO.Cnae = rs.GetString("cnae");
				clienteTO.SeqTribCli = rs.GetNullableInteger("seq_trib_cli");
				clienteTO.AltTabPrecoAfv = rs.GetNullableBoolean("alt_tab_preco_afv");
				clienteTO.AltTpPedAfv = rs.GetNullableBoolean("alt_tp_ped_afv");
				clienteTO.SeqRotPrdfProvisorio = rs.GetNullableBoolean("seq_rot_prdf_provisorio");
				clienteTO.RowId = rs.GetArrayByte("RowId");
				clienteTO.QtdeCheckout = rs.GetNullableInteger("qtde_check_out");
				clienteTO.Iban = rs.GetString("iban");
				clienteTO.DtFundacao = rs.GetNullableDateTime("DtFundacao");
				arrayList.Add(clienteTO);
			}
		}
		return (ClienteTO[])arrayList.ToArray(typeof(ClienteTO));
	}

	public static void Update(DbConnection connection, ClienteTO instance)
	{
		connection.ClearParameters();
		setParametros(connection, instance);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspClienteUpdate");
	}

	public static ClienteTO SelectByCnpj(string connection, string Cnpj)
	{
		if (string.IsNullOrEmpty(Cnpj) || string.IsNullOrWhiteSpace(Cnpj))
		{
			throw new Exception("CNPJ vazio ou nulo");
		}
		ClienteTO clienteTO = null;
		using (DbConnection dbConnection = new DbConnection(connection))
		{
			try
			{
				dbConnection.Open();
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@Cnpj", Cnpj);
				ClienteTO[] array = CreateInstances(dbConnection.ExecuteReaderRS(CommandType.StoredProcedure, "uspClienteSelectByCNPJ"));
				if (array != null && array.Length != 0)
				{
					clienteTO = (from c in array.ToList()
						orderby c.Ativo descending
						select c).First();
					loadFilhos(dbConnection, clienteTO);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				dbConnection.Close();
			}
		}
		return clienteTO;
	}

	private static void loadFilhos(DbConnection dbConnection, ClienteTO cliente)
	{
		if (cliente != null)
		{
			cliente.oContCli = ContCliDAL.Select(dbConnection, cliente.CdClien);
			cliente.oTelCli = TelCliDAL.Select(dbConnection, cliente.CdClien);
			cliente.oEndCli = EndCliDAL.Select(dbConnection, cliente.CdClien);
		}
	}

	public static ClienteTO SelectByCdClien(string stringConnTargetERP, int cdClien, bool carregaFilhos)
	{
		ClienteTO clienteTO = null;
		using (DbConnection dbConnection = new DbConnection(stringConnTargetERP))
		{
			try
			{
				dbConnection.Open();
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@CdClien", cdClien);
				ClienteTO[] array = CreateInstances(dbConnection.ExecuteReaderRS(CommandType.StoredProcedure, "uspClienteSelectByCdClien"));
				if (array != null && array.Length != 0)
				{
					clienteTO = array.ToList().First();
					if (carregaFilhos)
					{
						loadFilhos(dbConnection, clienteTO);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				dbConnection.Close();
			}
		}
		return clienteTO;
	}

	public static ClienteTO SelectByCnpjEPais(string _StringConnTargetErp, string cnpj, string pais, bool carregaFilhos)
	{
		if (string.IsNullOrEmpty(cnpj) || string.IsNullOrWhiteSpace(cnpj))
		{
			throw new Exception("CNPJ vazio ou nulo");
		}
		ClienteTO clienteTO = null;
		using (DbConnection dbConnection = new DbConnection(_StringConnTargetErp))
		{
			try
			{
				dbConnection.Open();
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@Cnpj", cnpj);
				dbConnection.AddParameters("@Pais", pais);
				ClienteTO[] array = CreateInstances(dbConnection.ExecuteReaderRS(CommandType.StoredProcedure, "uspClienteSelectByCnpjEPais"));
				if (array != null && array.Length != 0)
				{
					clienteTO = (from c in array.ToList()
						orderby c.Ativo descending
						select c).First();
					if (carregaFilhos)
					{
						loadFilhos(dbConnection, clienteTO);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				dbConnection.Close();
			}
		}
		return clienteTO;
	}

	private static void setParametros(DbConnection connection, ClienteTO instance)
	{
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@tp_cliente", instance.RetornaTpCliente());
		connection.AddParameters("@nome", instance.Nome);
		connection.AddParameters("@nome_res", instance.NomeRes);
		connection.AddParameters("@tp_pes", instance.RetornaTpPes());
		connection.AddParameters("@cgc_cpf", instance.CgcCpf);
		connection.AddParameters("@tp_inscr", instance.RetornaTpInscr());
		connection.AddParameters("@inscricao", instance.Inscricao);
		connection.AddParameters("@ram_ativ", instance.RamAtiv);
		connection.AddParameters("@st_cred", (instance.StCred == "") ? null : instance.StCred);
		connection.AddParameters("@crt", instance.Crt);
		connection.AddParameters("@cd_grupocli", (instance.CdGrupocli == "") ? null : instance.CdGrupocli);
		connection.AddParameters("@cd_clien_col", instance.CdClienCol);
		connection.AddParameters("@cd_area", instance.CdArea);
		connection.AddParameters("@dt_cad", instance.DtCad);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@dt_ult_alt", instance.DtUltAlt);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.AddParameters("@dt_maior_acumulo", instance.DtMaiorAcumulo);
		connection.AddParameters("@vl_maior_acumulo", instance.VlMaiorAcumulo);
		connection.AddParameters("@dt_maior_compra", instance.DtMaiorCompra);
		connection.AddParameters("@dt_prim_compra", instance.DtPrimCompra);
		connection.AddParameters("@vl_maior_compra", instance.VlMaiorCompra);
		connection.AddParameters("@qtde_compra_mes", instance.QtdeCompraMes);
		connection.AddParameters("@dt_ult_compra", instance.DtUltCompra);
		connection.AddParameters("@vl_ult_compra", instance.VlUltCompra);
		connection.AddParameters("@vl_lim_cred", instance.VlLimCred);
		connection.AddParameters("@dt_ult_contato", instance.DtUltContato);
		connection.AddParameters("@cd_rot_prdf", instance.CdRotPrdf);
		connection.AddParameters("@seq_rot_prdf", instance.SeqRotPrdf);
		connection.AddParameters("@rot_visita", instance.RotVisita);
		connection.AddParameters("@seq_visita", instance.SeqVisita);
		connection.AddParameters("@turma_plantao", instance.TurmaPlantao);
		connection.AddParameters("@med_atraso", instance.MedAtraso);
		connection.AddParameters("@tot_protestos", instance.TotProtestos);
		connection.AddParameters("@cd_texto_cred", instance.CdTextoCred);
		connection.AddParameters("@situacao", instance.RetornaSituacao());
		connection.AddParameters("@nu_dias_protesto", instance.NuDiasProtesto);
		connection.AddParameters("@desconto", instance.Desconto);
		connection.AddParameters("@venda_especial", instance.VendaEspecial);
		connection.AddParameters("@suframa", instance.Suframa);
		connection.AddParameters("@cd_suframa", instance.CdSuframa);
		connection.AddParameters("@fornec", instance.Fornec);
		connection.AddParameters("@estrangeiro", instance.Estrangeiro);
		connection.AddParameters("@cd_texto_alerta", instance.CdTextoAlerta);
		connection.AddParameters("@cd_texto_nf", instance.CdTextoNf);
		connection.AddParameters("@web_site", instance.WebSite);
		connection.AddParameters("@e_mail", instance.EMail);
		connection.AddParameters("@tp_frete", instance.RetornaTpFrete());
		connection.AddParameters("@cd_forn", instance.CdForn);
		connection.AddParameters("@num_lock", instance.NumLock);
		connection.AddParameters("@ativo", instance.Ativo);
		connection.AddParameters("@ean13", instance.Ean13);
		connection.AddParameters("@pot_compra_mes", instance.PotCompraMes);
		connection.AddParameters("@perc_comis", instance.PercComis);
		connection.AddParameters("@tp_ped", instance.TpPed);
		connection.AddParameters("@cobra_boleto", instance.CobraBoleto);
		connection.AddParameters("@cd_texto_expe", instance.CdTextoExpe);
		connection.AddParameters("@atualiza_lim_cred", instance.AtualizaLimCred);
		connection.AddParameters("@prod_controlado", instance.ProdControlado);
		connection.AddParameters("@enviar_arq_genexis", instance.EnviarArqGenexis);
		connection.AddParameters("@cliente_novo_genexis", instance.ClienteNovoGenexis);
		connection.AddParameters("@enviar_arq_janssen", instance.EnviarArqJanssen);
		connection.AddParameters("@cliente_novo_janssen", instance.ClienteNovoJanssen);
		connection.AddParameters("@dt_val_prod_controlado", instance.DtValProdControlado);
		connection.AddParameters("@enviar_arq_nestle", instance.EnviarArqNestle);
		connection.AddParameters("@envio_serasa", instance.EnvioSerasa);
		connection.AddParameters("@cd_grdescli", instance.CdGrdescli);
		connection.AddParameters("@cd_tp_freq_visita", instance.CdTpFreqVisita);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@senha", instance.Senha);
		connection.AddParameters("@toler_juros_qtde_dias", instance.TolerJurosQtdeDias);
		connection.AddParameters("@toler_juros_ate_venc", instance.TolerJurosAteVenc);
		connection.AddParameters("@cod_clf", instance.CodClf);
		connection.AddParameters("@area_livre_comercio", instance.AreaLivreComercio);
		connection.AddParameters("@dias_prorr_venc", instance.DiasProrrVenc);
		connection.AddParameters("@cliente_novo_proceda", instance.ClienteNovoProceda);
		connection.AddParameters("@enviar_arq_proceda", instance.EnviarArqProceda);
		connection.AddParameters("@nao_fat_maior_un", instance.NaoFatMaiorUn);
		connection.AddParameters("@cliente_novo_nestle", instance.ClienteNovoNestle);
		connection.AddParameters("@cd_coligacao", instance.CdColigacao);
		connection.AddParameters("@dt_ult_alt_lim_cred", instance.DtUltAltLimCred);
		connection.AddParameters("@dt_recadastramento", instance.DtRecadastramento);
		connection.AddParameters("@estrangeiro_nu_doc", instance.EstrangeiroNuDoc);
		connection.AddParameters("@atu_ult_maior_compra", instance.AtuUltMaiorCompra);
		connection.AddParameters("@envia_arq_masterfoods", instance.EnviaArqMasterfoods);
		connection.AddParameters("@dt_penult_compra", instance.DtPenultCompra);
		connection.AddParameters("@vl_penult_compra", instance.VlPenultCompra);
		connection.AddParameters("@enviado_redbull", instance.EnviadoRedbull);
		connection.AddParameters("@consumidor", instance.Consumidor);
		connection.AddParameters("@perc_aceito_prazo_validade", instance.PercAceitoPrazoValidade);
		connection.AddParameters("@cobra_seguro", instance.CobraSeguro);
		connection.AddParameters("@bloq_atu_ult_maior_compra", instance.BloqAtuUltMaiorCompra);
		connection.AddParameters("@perc_desc_fin_auto", instance.PercDescFinAuto);
		connection.AddParameters("@enviar_arq_pharmadis", instance.EnviarArqPharmadis);
		connection.AddParameters("@cliente_novo_pharmadis", instance.ClienteNovoPharmadis);
		connection.AddParameters("@nc_util_cfg_abat_clien", instance.NcUtilCfgAbatClien);
		connection.AddParameters("@nc_tp_abat_clien", instance.RetornaNcTpAbatClien());
		connection.AddParameters("@cd_vend_tecnico", instance.CdVendTecnico);
		connection.AddParameters("@cd_forn_inst", instance.CdFornInst);
		connection.AddParameters("@imp_desc_grd_com", instance.ImpDescGrdCom);
		connection.AddParameters("@cnae", instance.Cnae);
		connection.AddParameters("@seq_trib_cli", instance.SeqTribCli);
		connection.AddParameters("@alt_tab_preco_afv", instance.AltTabPrecoAfv);
		connection.AddParameters("@alt_tp_ped_afv", instance.AltTpPedAfv);
		connection.AddParameters("@seq_rot_prdf_provisorio", instance.SeqRotPrdfProvisorio);
		connection.AddParameters("@qtde_check_out", instance.QtdeCheckout);
		connection.AddParameters("@iban", instance.Iban);
		connection.AddParameters("@DtFundacao", instance.DtFundacao);
	}
}
