using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Target.Venda.Helpers.Geral;

namespace Target.Venda.Business.Helpers;

public class ImpostoWS
{
	public class ImpostoParametros
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("par_nu_cd_emp")]
		public int par_nu_cd_emp { get; set; }

		[JsonProperty("par_nu_cd_prod")]
		public int par_nu_cd_prod { get; set; }

		[JsonProperty("par_str_estado_origem")]
		public string par_str_estado_origem { get; set; }

		[JsonProperty("par_str_estado_destino")]
		public string par_str_estado_destino { get; set; }

		[JsonProperty("par_str_tp_inscricao")]
		public string par_str_tp_inscricao { get; set; }

		[JsonProperty("par_boo_isento_subst_trib")]
		public bool par_boo_isento_subst_trib { get; set; }

		[JsonProperty("par_boo_imp_aliq_icm_isentos")]
		public bool par_boo_imp_aliq_icm_isentos { get; set; }

		[JsonProperty("par_boo_devol_fornec")]
		public bool par_boo_devol_fornec { get; set; }

		[JsonProperty("par_str_tp_ped")]
		public string par_str_tp_ped { get; set; }

		[JsonProperty("par_boo_papel_cortado")]
		public bool par_boo_papel_cortado { get; set; }

		[JsonProperty("par_boo_bonificado")]
		public bool par_boo_bonificado { get; set; }

		[JsonProperty("par_boo_base_icms_com_ipi_cli")]
		public bool par_boo_base_icms_com_ipi_cli { get; set; }

		[JsonProperty("par_boo_base_icms_com_ipi_tped")]
		public bool par_boo_base_icms_com_ipi_tped { get; set; }

		[JsonProperty("par_boo_frete_base_calc_icm")]
		public bool par_boo_frete_base_calc_icm { get; set; }

		[JsonProperty("par_boo_subst_margem_esp")]
		public bool par_boo_subst_margem_esp { get; set; }

		[JsonProperty("par_boo_calc_icm_ressarc_bonif")]
		public bool par_boo_calc_icm_ressarc_bonif { get; set; }

		[JsonProperty("par_boo_strib_sem_credito_icm")]
		public bool par_boo_strib_sem_credito_icm { get; set; }

		[JsonProperty("par_boo_sit_trib_esp_tped")]
		public bool par_boo_sit_trib_esp_tped { get; set; }

		[JsonProperty("par_str_trib_tp_sit_trib")]
		public string par_str_trib_tp_sit_trib { get; set; }

		[JsonProperty("par_str_trib_tp_red_icms")]
		public string par_str_trib_tp_red_icms { get; set; }

		[JsonProperty("par_nu_qtde_unid_valor")]
		public decimal par_nu_qtde_unid_valor { get; set; }

		[JsonProperty("par_nu_qtde_unid_est")]
		public decimal par_nu_qtde_unid_est { get; set; }

		[JsonProperty("par_boo_calc_repasse")]
		public bool par_boo_calc_repasse { get; set; }

		[JsonProperty("par_boo_util_aliq_interestadual")]
		public bool par_boo_util_aliq_interestadual { get; set; }

		[JsonProperty("par_boo_vda_pf_foraest_redicm")]
		public bool par_boo_vda_pf_foraest_redicm { get; set; }

		[JsonProperty("par_boo_calc_frete_ipi")]
		public bool par_boo_calc_frete_ipi { get; set; }

		[JsonProperty("par_boo_util_aliq_st_interestadual")]
		public bool par_boo_util_aliq_st_interestadual { get; set; }

		[JsonProperty("parNuPed")]
		public int? parNuPed { get; set; }

		[JsonProperty("parNuSeqItPedv")]
		public int? parNuSeqItPedv { get; set; }

		[JsonProperty("pnuSeqTribCli")]
		public int pnuSeqTribCli { get; set; }

		[JsonProperty("str_global_sigla_clien")]
		public string str_global_sigla_clien { get; set; }

		[JsonProperty("boo_global_subst_trib_maior_valor")]
		public bool boo_global_subst_trib_maior_valor { get; set; }

		[JsonProperty("par_nu_vet_valores_00")]
		public decimal? par_nu_vet_valores_00 { get; set; }

		[JsonProperty("par_nu_vet_valores_01")]
		public decimal? par_nu_vet_valores_01 { get; set; }

		[JsonProperty("par_nu_vet_valores_04")]
		public decimal? par_nu_vet_valores_04 { get; set; }

		[JsonProperty("par_nu_vet_valores_05")]
		public decimal? par_nu_vet_valores_05 { get; set; }

		[JsonProperty("par_nu_vet_valores_06")]
		public decimal? par_nu_vet_valores_06 { get; set; }

		[JsonProperty("par_nu_vet_valores_07")]
		public decimal? par_nu_vet_valores_07 { get; set; }

		[JsonProperty("par_nu_vet_valores_08")]
		public decimal? par_nu_vet_valores_08 { get; set; }

		[JsonProperty("par_nu_vet_valores_09")]
		public decimal? par_nu_vet_valores_09 { get; set; }

		[JsonProperty("par_nu_vet_valores_10")]
		public decimal? par_nu_vet_valores_10 { get; set; }

		[JsonProperty("par_nu_vet_valores_11")]
		public decimal? par_nu_vet_valores_11 { get; set; }

		[JsonProperty("par_nu_vet_valores_12")]
		public decimal? par_nu_vet_valores_12 { get; set; }

		[JsonProperty("par_nu_vet_valores_14")]
		public decimal? par_nu_vet_valores_14 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_00")]
		public bool par_boo_vet_indicadores_calc_00 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_01")]
		public bool par_boo_vet_indicadores_calc_01 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_02")]
		public bool par_boo_vet_indicadores_calc_02 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_03")]
		public bool par_boo_vet_indicadores_calc_03 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_04")]
		public bool par_boo_vet_indicadores_calc_04 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_05")]
		public bool par_boo_vet_indicadores_calc_05 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_06")]
		public bool par_boo_vet_indicadores_calc_06 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_07")]
		public bool par_boo_vet_indicadores_calc_07 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_08")]
		public bool par_boo_vet_indicadores_calc_08 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_09")]
		public bool par_boo_vet_indicadores_calc_09 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_10")]
		public bool par_boo_vet_indicadores_calc_10 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_11")]
		public bool par_boo_vet_indicadores_calc_11 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_12")]
		public bool par_boo_vet_indicadores_calc_12 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_13")]
		public bool par_boo_vet_indicadores_calc_13 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_14")]
		public bool par_boo_vet_indicadores_calc_14 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_15")]
		public bool par_boo_vet_indicadores_calc_15 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_16")]
		public bool par_boo_vet_indicadores_calc_16 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_17")]
		public bool par_boo_vet_indicadores_calc_17 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_18")]
		public bool par_boo_vet_indicadores_calc_18 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_19")]
		public bool par_boo_vet_indicadores_calc_19 { get; set; }

		[JsonProperty("par_boo_vet_indicadores_calc_50")]
		public bool par_boo_vet_indicadores_calc_50 { get; set; }
	}

	public class ImpostoRetorno
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_00")]
		public decimal? rpar_nu_vet_vl_calculados_00 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_01")]
		public decimal? rpar_nu_vet_vl_calculados_01 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_02")]
		public decimal? rpar_nu_vet_vl_calculados_02 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_03")]
		public decimal? rpar_nu_vet_vl_calculados_03 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_04")]
		public decimal? rpar_nu_vet_vl_calculados_04 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_05")]
		public decimal? rpar_nu_vet_vl_calculados_05 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_06")]
		public decimal? rpar_nu_vet_vl_calculados_06 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_07")]
		public decimal? rpar_nu_vet_vl_calculados_07 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_08")]
		public decimal? rpar_nu_vet_vl_calculados_08 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_09")]
		public decimal? rpar_nu_vet_vl_calculados_09 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_10")]
		public decimal? rpar_nu_vet_vl_calculados_10 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_11")]
		public decimal? rpar_nu_vet_vl_calculados_11 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_12")]
		public decimal? rpar_nu_vet_vl_calculados_12 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_13")]
		public decimal? rpar_nu_vet_vl_calculados_13 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_14")]
		public decimal? rpar_nu_vet_vl_calculados_14 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_15")]
		public decimal? rpar_nu_vet_vl_calculados_15 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_16")]
		public decimal? rpar_nu_vet_vl_calculados_16 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_17")]
		public decimal? rpar_nu_vet_vl_calculados_17 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_18")]
		public decimal? rpar_nu_vet_vl_calculados_18 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_19")]
		public decimal? rpar_nu_vet_vl_calculados_19 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_20")]
		public decimal? rpar_nu_vet_vl_calculados_20 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_21")]
		public decimal? rpar_nu_vet_vl_calculados_21 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_22")]
		public decimal? rpar_nu_vet_vl_calculados_22 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_23")]
		public decimal? rpar_nu_vet_vl_calculados_23 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_24")]
		public decimal? rpar_nu_vet_vl_calculados_24 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_25")]
		public decimal? rpar_nu_vet_vl_calculados_25 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_26")]
		public decimal? rpar_nu_vet_vl_calculados_26 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_27")]
		public decimal? rpar_nu_vet_vl_calculados_27 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_28")]
		public decimal? rpar_nu_vet_vl_calculados_28 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_29")]
		public decimal? rpar_nu_vet_vl_calculados_29 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_30")]
		public decimal? rpar_nu_vet_vl_calculados_30 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_31")]
		public decimal? rpar_nu_vet_vl_calculados_31 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_32")]
		public decimal? rpar_nu_vet_vl_calculados_32 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_33")]
		public decimal? rpar_nu_vet_vl_calculados_33 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_34")]
		public decimal? rpar_nu_vet_vl_calculados_34 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_35")]
		public decimal? rpar_nu_vet_vl_calculados_35 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_36")]
		public decimal? rpar_nu_vet_vl_calculados_36 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_37")]
		public decimal? rpar_nu_vet_vl_calculados_37 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_38")]
		public decimal? rpar_nu_vet_vl_calculados_38 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_39")]
		public decimal? rpar_nu_vet_vl_calculados_39 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_40")]
		public decimal? rpar_nu_vet_vl_calculados_40 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_41")]
		public decimal? rpar_nu_vet_vl_calculados_41 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_42")]
		public decimal? rpar_nu_vet_vl_calculados_42 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_43")]
		public decimal? rpar_nu_vet_vl_calculados_43 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_44")]
		public decimal? rpar_nu_vet_vl_calculados_44 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_45")]
		public decimal? rpar_nu_vet_vl_calculados_45 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_46")]
		public decimal? rpar_nu_vet_vl_calculados_46 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_47")]
		public decimal? rpar_nu_vet_vl_calculados_47 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_48")]
		public decimal? rpar_nu_vet_vl_calculados_48 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_49")]
		public decimal? rpar_nu_vet_vl_calculados_49 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_50")]
		public decimal? rpar_nu_vet_vl_calculados_50 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_51")]
		public decimal? rpar_nu_vet_vl_calculados_51 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_52")]
		public decimal? rpar_nu_vet_vl_calculados_52 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_53")]
		public decimal? rpar_nu_vet_vl_calculados_53 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_54")]
		public decimal? rpar_nu_vet_vl_calculados_54 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_55")]
		public decimal? rpar_nu_vet_vl_calculados_55 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_56")]
		public decimal? rpar_nu_vet_vl_calculados_56 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_57")]
		public decimal? rpar_nu_vet_vl_calculados_57 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_58")]
		public decimal? rpar_nu_vet_vl_calculados_58 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_59")]
		public decimal? rpar_nu_vet_vl_calculados_59 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_60")]
		public decimal? rpar_nu_vet_vl_calculados_60 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_61")]
		public decimal? rpar_nu_vet_vl_calculados_61 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_62")]
		public decimal? rpar_nu_vet_vl_calculados_62 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_63")]
		public decimal? rpar_nu_vet_vl_calculados_63 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_64")]
		public decimal? rpar_nu_vet_vl_calculados_64 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_65")]
		public decimal? rpar_nu_vet_vl_calculados_65 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_66")]
		public decimal? rpar_nu_vet_vl_calculados_66 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_67")]
		public decimal? rpar_nu_vet_vl_calculados_67 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_68")]
		public decimal? rpar_nu_vet_vl_calculados_68 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_69")]
		public decimal? rpar_nu_vet_vl_calculados_69 { get; set; }

		[JsonProperty("rpar_nu_vet_vl_calculados_70")]
		public decimal? rpar_nu_vet_vl_calculados_70 { get; set; }

		[JsonProperty("oRetidoSubstituidoOrigemCalc")]
		public List<ImpostoRetidoSubstituidoOrigemCalc> oRetidoSubstituidoOrigemCalc { get; set; }

		public ImpostoRetorno()
		{
			oRetidoSubstituidoOrigemCalc = new List<ImpostoRetidoSubstituidoOrigemCalc>();
		}
	}

	public class ImpostoRetidoSubstituidoOrigemCalc
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("cdFornCompra")]
		public int? cdFornCompra { get; set; }

		[JsonProperty("nuNFCompra")]
		public int? nuNFCompra { get; set; }

		[JsonProperty("nfReciID")]
		public int? nfReciID { get; set; }

		[JsonProperty("prodCustoHistID")]
		public int? prodCustoHistID { get; set; }

		[JsonProperty("qtdeEstAtendida")]
		public decimal? qtdeEstAtendida { get; set; }

		[JsonProperty("baseSTRetido")]
		public decimal? baseSTRetido { get; set; }

		[JsonProperty("valorSTRetido")]
		public decimal? valorSTRetido { get; set; }

		[JsonProperty("valorICMSSubstituido")]
		public decimal? valorICMSSubstituido { get; set; }

		[JsonProperty("aliquotaSTRetido")]
		public decimal? aliquotaSTRetido { get; set; }
	}

	public class ImpostosCalcula_VendaService
	{
		public class ParametrosRoot
		{
			[JsonProperty("")]
			public List<ImpostoParametros> parametro { get; set; }
		}

		private readonly HttpClient _httpClient;

		public ImpostosCalcula_VendaService()
		{
			_httpClient = new HttpClient();
		}

		public List<ImpostoRetorno> ConsultarImpostoCalcula(ImpostoParametros impostoCalcula, string WebServiceUrl)
		{
			try
			{
				return ConsultarImpostoCalculaAsync(impostoCalcula, WebServiceUrl);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<ImpostoRetorno> ConsultarImpostoCalculaAsync(ImpostoParametros impostoCalcula, string WebServiceUrl)
		{
			try
			{
				if (!string.IsNullOrEmpty(WebServiceUrl))
				{
					WEBSERVICE_URL = WebServiceUrl;
				}
				string servidorBancoDados = ConfigHelper.getServidorBancoDados();
				string nomeBancoDados = ConfigHelper.getNomeBancoDados();
				string userBancoDados = ConfigHelper.getUserBancoDados();
				string pswBancoDados = ConfigHelper.getPswBancoDados();
				ImpostoParametros[] value = new ImpostoParametros[1] { impostoCalcula };
				string content = JsonConvert.SerializeObject(value, Formatting.Indented);
				WinHttpHandler handler = new WinHttpHandler();
				HttpClient httpClient = new HttpClient(handler);
				httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
				httpClient.DefaultRequestHeaders.Add("Server", servidorBancoDados);
				httpClient.DefaultRequestHeaders.Add("Database", nomeBancoDados);
				httpClient.DefaultRequestHeaders.Add("User", userBancoDados);
				httpClient.DefaultRequestHeaders.Add("Password", pswBancoDados);
				HttpRequestMessage request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(WEBSERVICE_URL),
					Content = new StringContent(content, Encoding.UTF8, "application/json")
				};
				HttpResponseMessage result = httpClient.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter()
					.GetResult();
				string result2 = result.Content.ReadAsStringAsync().Result;
				return JsonConvert.DeserializeObject<List<ImpostoRetorno>>(result2);
			}
			catch (WebException ex)
			{
				throw ex;
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}
	}

	private static readonly string portaImpostoApi = ConfigHelper.getAppConfig("portaImpostoApi");

	public static string WEBSERVICE_URL = "http://localhost:" + portaImpostoApi + "/api/imposto";
}
