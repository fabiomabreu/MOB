using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Helpers;

public static class CalculadorImpostoERP
{
	private static string _stringConnection = ConfigHelper.getStringConnection();

	private static bool boo_global_utiliza_sit_trib_esp_tp_ped = false;

	private static string str_global_sigla_clien = "";

	private static bool boo_global_subst_trib_maior_valor = false;

	private static bool UtilizouSubstTribAdicItem = false;

	private static bool stAdicItem = false;

	private static bool stAdicItemExcecao = false;

	private static int seq_trib_cli = 0;

	public static ImpostosPedidoVendaResponse CalcularImpostoPedidoVenda(ImpostoPedidoVendaRequest parametro, ClienteMO CLIENTE_PEDIDO, TipoPedidoVO TIPO_PEDIDO, ConfiguracaoVO PAR_CFG, bool UtilizaApiImposto, string WebServiceUrl)
	{
		List<decimal> listaValores = CalcularImpostosPedidoVenda(parametro.CODIGO_EMPRESA, parametro.TIPO_PEDIDO, parametro.CODIGO_PRODUTO, parametro.PRECO_TABELA, parametro.PERCENTUAL_DESCONTO, parametro.UF, parametro.CODIGO_CLIENTE, parametro.QUANTIDADE_UNIDADE_PEDIDA, parametro.QUANTIDADE_UNIDADE_ESTOQUE, parametro.VALOR_UNITARIO_VENDA, parametro.VALOR_FRETE_ITEM, parametro.VALOR_DESCONTO_GERAL, parametro.BONIFICADO, CLIENTE_PEDIDO, TIPO_PEDIDO, PAR_CFG, UtilizaApiImposto, WebServiceUrl);
		return MapearListaImpostosParaObjeto(listaValores);
	}

	private static ImpostosPedidoVendaResponse MapearListaImpostosParaObjeto(List<decimal> listaValores)
	{
		ImpostosPedidoVendaResponse impostosPedidoVendaResponse = new ImpostosPedidoVendaResponse();
		impostosPedidoVendaResponse.BASE_CALCULO_ICMS = listaValores[0];
		impostosPedidoVendaResponse.VALOR_ICMS = listaValores[1];
		impostosPedidoVendaResponse.BASE_CALCULO_IPI = listaValores[2];
		impostosPedidoVendaResponse.VALOR_IPI = listaValores[3];
		impostosPedidoVendaResponse.BASE_CALCULO_SUBST_TRIB = listaValores[4];
		impostosPedidoVendaResponse.VALOR_SUBST_TRIB = listaValores[5];
		impostosPedidoVendaResponse.VALOR_PIS = listaValores[6];
		impostosPedidoVendaResponse.VALOR_COFINS = listaValores[7];
		impostosPedidoVendaResponse.BASE_CALCULO_RESSARCIMENTO_ICMS = listaValores[8];
		impostosPedidoVendaResponse.VALOR_RESSARCIMENTO_ICMS = listaValores[9];
		impostosPedidoVendaResponse.BASE_CALCULO_REPASSE_SUBST_TRIB = listaValores[10];
		impostosPedidoVendaResponse.VALOR_REPASSE_SUBST_TRIB = listaValores[11];
		impostosPedidoVendaResponse.BASE_CALCULO_RESTRICAO_SUBST_TRIB = listaValores[12];
		impostosPedidoVendaResponse.VALOR_RESTITUICAO_SUBST_TRIB = listaValores[13];
		impostosPedidoVendaResponse.ALIQUOTA_ICMS = listaValores[14];
		impostosPedidoVendaResponse.ALIQUOTA_IPI = listaValores[15];
		impostosPedidoVendaResponse.MARGEM_SUBST_TRIB = listaValores[16];
		impostosPedidoVendaResponse.PERCENTUAL_REDUCAO_BASE_SUBST_TRIB = listaValores[17];
		impostosPedidoVendaResponse.MODALIDADE_ICMS = listaValores[18];
		impostosPedidoVendaResponse.MODALIDADE_ICMS_SUBST_TRIB = listaValores[19];
		impostosPedidoVendaResponse.VALOR_ADICIONAL_NF = listaValores[20];
		impostosPedidoVendaResponse.ALIQUOTA_CREDITO_ICMS_SIMPLES_NACIONAL = listaValores[21];
		impostosPedidoVendaResponse.PERCENTUAL_REDUCAO_BASE_CALCULO = listaValores[22];
		impostosPedidoVendaResponse.ALIQUOTA_ICMS_CALCULO_ST_ICMS_PROPRIO = listaValores[23];
		impostosPedidoVendaResponse.VALOR_IMPOSTO_IMPORTACAO = listaValores[24];
		impostosPedidoVendaResponse.VALOR_SISCOMEX = listaValores[25];
		impostosPedidoVendaResponse.CODIGO_TRIBUTACAO_CLIENTE = listaValores[26];
		impostosPedidoVendaResponse.ALIQUOTA_ICMS_ST = listaValores[27];
		impostosPedidoVendaResponse.VALOR_ICMS_DESONERADO = listaValores[41];
		return impostosPedidoVendaResponse;
	}

	private static List<decimal> CalcularImpostosPedidoVenda(int CdEmp, string TpPed, int codigoProduto, decimal precoTabela, decimal percDesc, string UF, int? CD_CLIENTE_BASE, decimal qtdePedida, decimal qtdeEstoque, decimal valor_liquido, decimal vl_frete_item, decimal vl_desc_geral, bool bonificado, ClienteMO CLIENTE_PEDIDO, TipoPedidoVO TIPO_PEDIDO, ConfiguracaoVO PAR_CFG, bool UtilizaApiImposto, string WebServiceUrl)
	{
		List<decimal> rpar_nu_vet_calculados = new List<decimal>();
		string par_str_msg_erro = "";
		using (SqlConnection sqlConnection = new SqlConnection(_stringConnection))
		{
			sqlConnection.Open();
			InicializaParametros(CdEmp, TpPed, codigoProduto, precoTabela, percDesc, ref rpar_nu_vet_calculados, sqlConnection, ref par_str_msg_erro, UF, CD_CLIENTE_BASE, qtdePedida, qtdeEstoque, valor_liquido, vl_frete_item, vl_desc_geral, bonificado, CLIENTE_PEDIDO, TIPO_PEDIDO, PAR_CFG, UtilizaApiImposto, WebServiceUrl);
			sqlConnection.Close();
		}
		return rpar_nu_vet_calculados;
	}

	private static bool InicializaParametros(int par_nu_cd_emp, string par_tp_ped, int par_nu_cd_prod, decimal par_preco_tabela, decimal par_nu_desc, ref List<decimal> rpar_nu_vet_calculados, SqlConnection par_hSql_1, ref string par_str_msg_erro, string UF, int? CD_CLIENTE_BASE, decimal qtdePedida, decimal qtdeEstoque, decimal par_vl_unit, decimal par_vl_frete_item, decimal par_vl_desc_geral, bool par_boo_bonificado, ClienteMO CLIENTE_PEDIDO, TipoPedidoVO TIPO_PEDIDO, ConfiguracaoVO PAR_CFG, bool UtilizaApiImposto, string WebServiceUrl)
	{
		bool par_boo_papel_cortado = false;
		string text = "";
		string text2 = "";
		bool flag = false;
		string text3 = "";
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		string text4 = "";
		string text5 = "";
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		bool flag9 = false;
		bool flag10 = false;
		bool flag11 = false;
		bool flag12 = false;
		string text6 = "";
		bool flag13 = false;
		bool flag14 = false;
		bool flag15 = false;
		bool flag16 = false;
		bool flag17 = false;
		bool flag18 = false;
		bool flag19 = false;
		bool flag20 = false;
		decimal item = default(decimal);
		decimal item2 = default(decimal);
		decimal item3 = default(decimal);
		decimal item4 = default(decimal);
		bool flag21 = false;
		decimal num = default(decimal);
		decimal num2 = default(decimal);
		bool flag22 = false;
		bool flag23 = false;
		string text7 = "";
		List<ImpostoWS.ImpostoRetorno> list = new List<ImpostoWS.ImpostoRetorno>();
		text2 = UF;
		str_global_sigla_clien = PAR_CFG.SIGLA_CLIENTE;
		boo_global_subst_trib_maior_valor = PAR_CFG.SUBST_TRIB_MAIOR_VALOR;
		boo_global_utiliza_sit_trib_esp_tp_ped = PAR_CFG.UTILIZA_SIT_TRIB_ESP_TP_PED;
		flag15 = PAR_CFG.VDA_PF_FE_REDICM;
		text = CLIENTE_PEDIDO.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "FA").ESTADO;
		flag = CLIENTE_PEDIDO.TRIBUTACAO.ISENTO_ICMS_SUBSTITUTO.GetValueOrDefault();
		text3 = CLIENTE_PEDIDO.TIPO_INSCRICAO;
		flag2 = CLIENTE_PEDIDO.TRIBUTACAO.SUBSTITUTO_MARGEM_ESP.GetValueOrDefault();
		flag3 = CLIENTE_PEDIDO.TRIBUTACAO.IPI_BASE_CALCULO_ICMS.GetValueOrDefault();
		flag4 = CLIENTE_PEDIDO.TRIBUTACAO.CALCULA_REPASSE.GetValueOrDefault();
		flag5 = CLIENTE_PEDIDO.TRIBUTACAO.UTILIZA_ALIQUOTA_INTERESTADUAL;
		text4 = CLIENTE_PEDIDO.TRIBUTACAO.CODIGO_TRIBUTACAO_TIPO_SIT_TRIB;
		text5 = CLIENTE_PEDIDO.TRIBUTACAO.CODIGO_TRIBUTACAO_TIPO_RED_ICMS;
		flag6 = CLIENTE_PEDIDO.TRIBUTACAO.UTIL_ALIQUOTA_ST_INTERESTADUAL.GetValueOrDefault();
		flag17 = CLIENTE_PEDIDO.TRIBUTACAO.ST_SEM_CREDITO_ICMS.GetValueOrDefault();
		seq_trib_cli = CLIENTE_PEDIDO.SEQ_TRIBUTACAO_CLIENTE.Value;
		flag21 = CLIENTE_PEDIDO.TRIBUTACAO.UTILIZA_PMC_2.GetValueOrDefault();
		flag22 = CLIENTE_PEDIDO.TRIBUTACAO.INFORMA_IMPOSTOS_NF.GetValueOrDefault();
		text7 = "SELECT BaseStSobreCueID\r\n\t\t\t        FROM  dbo.ufnIcmProd( @par_nu_cd_emp, @par_cd_prod, @par_str_win_estado_empresa, @par_str_win_estado_cliente_atual )\r\n                    ";
		using (SqlCommand sqlCommand = new SqlCommand(text7, par_hSql_1))
		{
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@par_cd_prod", par_nu_cd_prod);
			sqlCommand.Parameters.AddWithValue("@par_str_win_estado_empresa", text2);
			sqlCommand.Parameters.AddWithValue("@par_str_win_estado_cliente_atual", text);
			sqlCommand.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.Read())
			{
				num2 = GetDrValue<int>(sqlDataReader[0]);
			}
		}
		text7 = "\t\tSELECT\r\n                            (   SELECT pc.vl_custo\r\n                                FROM produto_custo (nolock) pc\r\n                                WHERE pc.cd_emp = @par_nu_cd_emp\r\n                                AND pc.cd_prod = @par_nu_cd_prod\r\n                                AND pc.tp_custo = 'CRP' ),\r\n\r\n                            (   SELECT pc.vl_custo\r\n                                FROM produto_custo (nolock) pc\r\n                                WHERE pc.cd_emp = @par_nu_cd_emp\r\n                                AND pc.cd_prod = @par_nu_cd_prod\r\n                                AND pc.tp_custo = 'CMP' ),\r\n\r\n                            (   SELECT pc.vl_custo\r\n                                FROM produto_custo (nolock) pc\r\n                                WHERE pc.cd_emp = @par_nu_cd_emp\r\n                                AND pc.cd_prod = @par_nu_cd_prod\r\n                                AND pc.tp_custo = 'CUE' ),\r\n                             (   SELECT pc.vl_custo_sem_imposto\r\n                                FROM produto_custo (nolock) pc\r\n                                WHERE pc.cd_emp = @par_nu_cd_emp\r\n                                AND pc.cd_prod = @par_nu_cd_prod\r\n                                AND pc.tp_custo = 'CUE' )";
		using (SqlCommand sqlCommand2 = new SqlCommand(text7, par_hSql_1))
		{
			sqlCommand2.Parameters.Clear();
			sqlCommand2.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			sqlCommand2.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			if (sqlDataReader2.Read())
			{
				item = GetDrValue<decimal>(sqlDataReader2[0]);
				item2 = GetDrValue<decimal>(sqlDataReader2[1]);
				item3 = ((!(str_global_sigla_clien == "RMD") && !(num2 != 2m)) ? GetDrValue<decimal>(sqlDataReader2[2]) : GetDrValue<decimal>(sqlDataReader2[3]));
			}
		}
		text7 = "\tSELECT\r\n                            pm.vl_preco,\r\n                            VlPreco2\r\n                        FROM\r\n                            prc_max_prod (nolock) pm\r\n                        WHERE\r\n                            pm.estado = @df_estado_cliente\r\n                        AND pm.cd_prod = @par_nu_cd_prod ";
		using (SqlCommand sqlCommand3 = new SqlCommand(text7, par_hSql_1))
		{
			sqlCommand3.Parameters.Clear();
			sqlCommand3.Parameters.AddWithValue("@df_estado_cliente", text);
			sqlCommand3.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			if (sqlDataReader3.Read())
			{
				item4 = GetDrValue<decimal>(sqlDataReader3[0]);
				num = GetDrValue<decimal>(sqlDataReader3[1]);
			}
		}
		if (flag21 && num > 0m)
		{
			item4 = num;
		}
		flag7 = TIPO_PEDIDO.IMP_ALIQUOTA_ICMS_ISENTOS;
		flag8 = TIPO_PEDIDO.DEVOLUCAO_FORNECEDOR;
		flag9 = TIPO_PEDIDO.IPI_BASE_CALCULO_ICMS;
		flag10 = TIPO_PEDIDO.FRETE_BASE_CALCULO_ICMS;
		flag11 = TIPO_PEDIDO.CALCULA_ICMS_RESSARCIMENTO_BONIFICACAO;
		flag14 = TIPO_PEDIDO.UTILIZA_SITUACAO_TRIBUTACAO_ESP;
		flag16 = TIPO_PEDIDO.CALCULO_IPI_FRETE;
		flag12 = TIPO_PEDIDO.INVENTARIO;
		text6 = TIPO_PEDIDO.INVENTARIO_TIPO_MOVIMENTACAO;
		flag18 = TIPO_PEDIDO.CALCULA_IPI;
		flag19 = TIPO_PEDIDO.CALCULA_ICMS_SUBSTITUTO;
		flag20 = TIPO_PEDIDO.CALCULA_ICMS_RESSARCIMENTO;
		flag23 = TIPO_PEDIDO.CONSUMIDOR_FINAL;
		if (flag12 && text6 == "E")
		{
			flag13 = true;
		}
		if (!flag13 && flag17)
		{
			flag13 = true;
		}
		List<decimal> list2 = new List<decimal>();
		list2.Add(par_vl_unit);
		list2.Add(par_preco_tabela);
		list2.Add(item);
		list2.Add(item2);
		list2.Add(item3);
		list2.Add(item4);
		list2.Add(par_vl_desc_geral);
		list2.Add(0m);
		list2.Add(par_vl_frete_item);
		list2.Add(0m);
		list2.Add(0m);
		list2.Add(0m);
		list2.Add(0m);
		list2.Add(0m);
		list2.Add(0m);
		List<bool> list3 = new List<bool>();
		bool flag24 = par_tp_ped == "VS";
		list3.Add(!flag24);
		list3.Add(!flag24);
		list3.Add(!flag24);
		list3.Add(flag18);
		list3.Add(flag19);
		list3.Add(flag20);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(flag23 || flag22);
		list3.Add(item: false);
		if (flag21 && num > 0m)
		{
			list3.Add(flag21);
		}
		else
		{
			list3.Add(item: false);
		}
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		list3.Add(item: false);
		if (UtilizaApiImposto)
		{
			ImpostoWS.ImpostosCalcula_VendaService impostosCalcula_VendaService = new ImpostoWS.ImpostosCalcula_VendaService();
			ImpostoWS.ImpostoParametros impostoParametros = new ImpostoWS.ImpostoParametros();
			impostoParametros.id = 1;
			impostoParametros.par_nu_cd_emp = par_nu_cd_emp;
			impostoParametros.par_nu_cd_prod = par_nu_cd_prod;
			impostoParametros.par_str_estado_origem = text2;
			impostoParametros.par_str_estado_destino = text;
			impostoParametros.par_str_tp_inscricao = text3;
			impostoParametros.par_boo_isento_subst_trib = flag;
			impostoParametros.par_boo_imp_aliq_icm_isentos = flag7;
			impostoParametros.par_boo_devol_fornec = flag8;
			impostoParametros.par_str_tp_ped = par_tp_ped;
			impostoParametros.par_boo_papel_cortado = par_boo_papel_cortado;
			impostoParametros.par_boo_bonificado = par_boo_bonificado;
			impostoParametros.par_boo_base_icms_com_ipi_cli = flag3;
			impostoParametros.par_boo_base_icms_com_ipi_tped = flag9;
			impostoParametros.par_boo_frete_base_calc_icm = flag10;
			impostoParametros.par_boo_subst_margem_esp = flag2;
			impostoParametros.par_boo_calc_icm_ressarc_bonif = flag11;
			impostoParametros.par_boo_strib_sem_credito_icm = flag13;
			impostoParametros.par_boo_sit_trib_esp_tped = flag14;
			impostoParametros.par_str_trib_tp_sit_trib = text4;
			impostoParametros.par_str_trib_tp_red_icms = text5;
			impostoParametros.par_nu_qtde_unid_valor = qtdePedida;
			impostoParametros.par_nu_qtde_unid_est = qtdeEstoque;
			impostoParametros.par_boo_calc_repasse = flag4;
			impostoParametros.par_boo_util_aliq_interestadual = flag5;
			impostoParametros.par_boo_vda_pf_foraest_redicm = flag15;
			impostoParametros.par_boo_calc_frete_ipi = flag16;
			impostoParametros.par_boo_util_aliq_st_interestadual = flag5;
			impostoParametros.parNuPed = null;
			impostoParametros.parNuSeqItPedv = null;
			impostoParametros.pnuSeqTribCli = seq_trib_cli;
			impostoParametros.str_global_sigla_clien = str_global_sigla_clien;
			impostoParametros.boo_global_subst_trib_maior_valor = boo_global_subst_trib_maior_valor;
			impostoParametros.par_nu_vet_valores_00 = list2[0];
			impostoParametros.par_nu_vet_valores_01 = list2[1];
			impostoParametros.par_nu_vet_valores_04 = list2[4];
			impostoParametros.par_nu_vet_valores_05 = list2[5];
			impostoParametros.par_nu_vet_valores_06 = list2[6];
			impostoParametros.par_nu_vet_valores_07 = list2[7];
			impostoParametros.par_nu_vet_valores_08 = list2[8];
			impostoParametros.par_nu_vet_valores_09 = list2[9];
			impostoParametros.par_nu_vet_valores_10 = list2[10];
			impostoParametros.par_nu_vet_valores_11 = list2[11];
			impostoParametros.par_nu_vet_valores_12 = list2[12];
			impostoParametros.par_nu_vet_valores_14 = null;
			impostoParametros.par_boo_vet_indicadores_calc_00 = list3[0];
			impostoParametros.par_boo_vet_indicadores_calc_01 = list3[1];
			impostoParametros.par_boo_vet_indicadores_calc_02 = list3[2];
			impostoParametros.par_boo_vet_indicadores_calc_03 = list3[3];
			impostoParametros.par_boo_vet_indicadores_calc_04 = list3[4];
			impostoParametros.par_boo_vet_indicadores_calc_05 = list3[5];
			impostoParametros.par_boo_vet_indicadores_calc_06 = list3[6];
			impostoParametros.par_boo_vet_indicadores_calc_07 = list3[7];
			impostoParametros.par_boo_vet_indicadores_calc_08 = list3[8];
			impostoParametros.par_boo_vet_indicadores_calc_09 = list3[9];
			impostoParametros.par_boo_vet_indicadores_calc_10 = list3[10];
			impostoParametros.par_boo_vet_indicadores_calc_11 = list3[11];
			impostoParametros.par_boo_vet_indicadores_calc_12 = list3[12];
			impostoParametros.par_boo_vet_indicadores_calc_13 = list3[13];
			impostoParametros.par_boo_vet_indicadores_calc_14 = list3[14];
			impostoParametros.par_boo_vet_indicadores_calc_15 = list3[15];
			impostoParametros.par_boo_vet_indicadores_calc_16 = list3[16];
			impostoParametros.par_boo_vet_indicadores_calc_17 = list3[17];
			impostoParametros.par_boo_vet_indicadores_calc_18 = list3[18];
			impostoParametros.par_boo_vet_indicadores_calc_19 = list3[19];
			impostoParametros.par_boo_vet_indicadores_calc_50 = false;
			list = impostosCalcula_VendaService.ConsultarImpostoCalcula(impostoParametros, WebServiceUrl);
			rpar_nu_vet_calculados = new List<decimal>
			{
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_00.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_00),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_01.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_01),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_02.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_02),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_03.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_03),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_04.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_04),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_05.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_05),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_06.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_06),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_07.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_07),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_08.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_08),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_09.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_09),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_10.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_10),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_11.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_11),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_12.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_12),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_13.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_13),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_14.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_14),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_15.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_15),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_16.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_16),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_17.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_17),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_18.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_18),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_19.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_19),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_20.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_20),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_21.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_21),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_22.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_22),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_23.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_23),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_24.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_24),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_25.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_25),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_26.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_26),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_27.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_27),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_28.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_28),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_29.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_29),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_30.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_30),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_31.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_31),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_32.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_32),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_33.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_33),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_34.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_34),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_35.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_35),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_36.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_36),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_37.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_37),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_38.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_38),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_39.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_39),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_40.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_40),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_41.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_41),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_42.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_42),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_43.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_43),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_44.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_44),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_45.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_45),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_46.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_46),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_47.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_47),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_48.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_48),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_49.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_49),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_50.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_50),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_51.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_51),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_52.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_52),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_53.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_53),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_54.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_54),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_55.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_55),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_56.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_56),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_57.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_57),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_58.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_58),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_59.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_59),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_60.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_60),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_61.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_61),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_62.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_62),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_63.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_63),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_64.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_64),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_65.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_65),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_66.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_66),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_67.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_67),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_68.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_68),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_69.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_69),
				Convert.ToDecimal((!list[0].rpar_nu_vet_vl_calculados_70.HasValue) ? new decimal?(default(decimal)) : list[0].rpar_nu_vet_vl_calculados_70)
			};
		}
		else if (!Usr_ImpostosCalcula_Venda(par_nu_cd_emp, par_nu_cd_prod, text2, text, list2, list3, text3, flag, flag7, flag8, par_tp_ped, par_boo_papel_cortado, par_boo_bonificado, flag3, flag9, flag10, flag2, flag11, flag13, flag14, text4, text5, qtdePedida, qtdeEstoque, flag4, flag5, flag15, flag16, ref rpar_nu_vet_calculados, flag5, par_hSql_1, ref par_str_msg_erro))
		{
			return false;
		}
		return true;
	}

	private static bool Usr_BuscaDadosParCfgTela(string par_str_cd_tela, ref Dictionary<int, bool> rpar_boo_vt_pcfg_det, SqlConnection par_hSql, ref string rpar_str_msg_erro)
	{
		string cmdText = "  SELECT\r\n                                    seq,        \r\n                                    ativo\r\n                                FROM\r\n                                    pcfg_tela_det (nolock)\r\n                                WHERE   \r\n                                    cd_tela = @par_str_cd_tela  \r\n                                ORDER BY    \r\n                                    seq\t";
		using (SqlCommand sqlCommand = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@par_str_cd_tela", par_str_cd_tela);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				rpar_boo_vt_pcfg_det.Add(sqlDataReader.GetInt32(0), GetDrValue<bool>(sqlDataReader[1]));
			}
		}
		if (rpar_boo_vt_pcfg_det.Count == 0)
		{
			rpar_str_msg_erro = "Não há parâmetros cadastrados para a tela <" + par_str_cd_tela + ">.";
			return false;
		}
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda(int par_nu_cd_emp, int par_nu_cd_prod, string par_str_estado_origem, string par_str_estado_destino, List<decimal> par_nu_vet_valores, List<bool> par_boo_vet_indicadores_calc, string par_str_tp_inscricao, bool par_boo_isento_subst_trib, bool par_boo_imp_aliq_icm_isentos, bool par_boo_devol_fornec, string par_str_tp_ped, bool par_boo_papel_cortado, bool par_boo_bonificado, bool par_boo_base_icms_com_ipi_cli, bool par_boo_base_icms_com_ipi_tped, bool par_boo_base_icms_com_ipi_frete, bool par_boo_subst_margem_esp, bool par_boo_calc_icm_ressarc_bonif, bool par_boo_strib_sem_credito_icm, bool par_boo_sit_trib_esp_tped, string par_str_trib_tp_sit_trib, string par_str_trib_tp_red_icms, decimal par_nu_qtde_unid_valor, decimal par_nu_qtde_unid_est, bool par_boo_calc_repasse, bool par_boo_util_aliq_interestadual, bool par_boo_vda_pf_foraest_redicm, bool par_boo_calc_frete_ipi, ref List<decimal> rpar_nu_vet_vl_calculados, bool par_boo_util_aliq_st_interestadual, SqlConnection par_hSql_1, ref string rpar_str_msg_erro)
	{
		decimal rpar_nu_aliq_ipi_venda = default(decimal);
		decimal rpar_nu_aliq_ipi_venda_p_cortado = default(decimal);
		decimal rpar_nu_aliq_ipi_compra = default(decimal);
		bool rpar_boo_base_ipi_com_desc_geral = false;
		decimal rpar_nu_vl_fixo_ipi_compra = default(decimal);
		bool rpar_boo_pis_cof_antec = false;
		decimal rpar_nu_indice_pis = default(decimal);
		decimal rpar_nu_indice_cofins = default(decimal);
		decimal rpar_nu_vl_base_produto = default(decimal);
		bool flag = false;
		bool rpar_boo_incide_icm = false;
		bool rpar_boo_incide_icm_excecao = false;
		decimal rpar_nu_perc_red_base_calc_icms = default(decimal);
		bool rpar_boo_base_icm_preco_liquido = false;
		bool rpar_boo_base_icm_sem_item_bonif = false;
		bool rpar_boo_base_icm_red_sobre_vl = false;
		bool rpar_boo_icms_sobre_preco_cheio = false;
		bool rpar_boo_ipi_base_icm_cad_cli = false;
		decimal rpar_nu_aliq_icms_subst = default(decimal);
		decimal rpar_nu_aliq_icms_subst_pmc = default(decimal);
		decimal rpar_nu_base_icm_aux_subst = default(decimal);
		bool rpar_boo_incide_icm_subst = false;
		bool rpar_boo_incide_icm_subs_excecao = false;
		bool rpar_boo_calc_subst_trib_prc_ch = false;
		bool rpar_boo_base_icm_s_trib_sem_red = false;
		bool rpar_boo_subst_trib_sobre_cue = false;
		bool rpar_boo_subst_trib_sobre_cue_prod = false;
		string rpar_str_subst_trib_sobre_cue_prod_tp_vl = "";
		bool rpar_boo_prc_max_consum = false;
		bool rpar_boo_calc_subst_trib_pmc = false;
		bool rpar_boo_subst_trib_apenas_ie = false;
		bool rpar_boo_calc_icm_subst_trib_est = false;
		bool flag2 = false;
		decimal rpar_nu_red_subst_trib_pmc = default(decimal);
		decimal rpar_nu_red_subst_trib_pmc_cmp = default(decimal);
		decimal rpar_nu_valor_ipi_frete = default(decimal);
		decimal rpar_nu_aliq_icm_frete = default(decimal);
		string rpar_str_tp_prod = "";
		bool rpar_boo_produzido = false;
		string rpar_str_cd_sit_trib = "";
		string rpar_str_cd_sit_trib_excecao = "";
		string text = "";
		string text2 = "";
		decimal rpar_nu_perc_margem_subs = default(decimal);
		decimal rpar_nu_perc_margem_subs_esp = default(decimal);
		decimal rpar_nu_perc_red_margem_subs = default(decimal);
		decimal rpar_nu_perc_red_margem_subs_esp = default(decimal);
		decimal rpar_nu_desc_gov = default(decimal);
		decimal rpar_nu_vl_icm_aux_subst = default(decimal);
		bool rpar_boo_utiliza_ressarc_icm = false;
		bool rpar_boo_icm_ressarc_preco_cheio = false;
		bool rpar_boo_icm_ressarc_pmc = false;
		decimal rpar_nu_aliq_icm_ressarc = default(decimal);
		decimal rpar_nu_perc_icm_subst_repasse = default(decimal);
		decimal rpar_nu_perc_icm_subst_rest = default(decimal);
		bool rpar_boo_bonif_fora_icm_rest = false;
		bool rpar_boo_subtrai_repasse_baseicm = false;
		bool rpar_boo_base_st_sem_red = false;
		bool rpar_boo_subst_red_base_icm_prop = false;
		decimal rpar_nu_modalidade_base_icms = default(decimal);
		decimal rpar_nu_modalidade_base_icms_st = default(decimal);
		bool rpar_boo_base_icm_st_sem_item_bonif = false;
		bool rpar_boo_preco_cheio_item_bonif = false;
		decimal num = default(decimal);
		decimal rpar_nu_perc_adicional_nf = default(decimal);
		decimal num2 = default(decimal);
		bool rpar_boo_empresa_sn = false;
		decimal rpar_nu_aliq_cred_icms_sn = default(decimal);
		decimal rpar_nu_perc_ii = default(decimal);
		decimal num3 = default(decimal);
		decimal num4 = default(decimal);
		bool rpbooRedBaseIcmStDifIcmNormal = false;
		decimal rparVlIpiCue = default(decimal);
		decimal parNuPercMinST = default(decimal);
		bool rpbooCalculoICMSSTConvenio = false;
		string rpstrTipoValorPreferencialBaseST = "";
		bool rpbooSubtraiICMSBasePisCofins = false;
		rpar_nu_vet_vl_calculados = new List<decimal>();
		for (int i = 0; i < 42; i++)
		{
			rpar_nu_vet_vl_calculados.Add(0m);
		}
		num2 = ((!(str_global_sigla_clien == "NAV") || par_nu_vet_valores[9] == 0m) ? default(decimal) : par_nu_vet_valores[9]);
		if (!Usr_ImpostosCalcula_Venda_Busca_Parametros(ref rpar_boo_base_ipi_com_desc_geral, ref rpar_boo_base_icm_preco_liquido, ref rpar_boo_base_icm_sem_item_bonif, ref rpar_boo_subst_trib_apenas_ie, ref rpar_boo_ipi_base_icm_cad_cli, ref rpar_boo_bonif_fora_icm_rest, ref rpar_boo_subtrai_repasse_baseicm, ref rpar_boo_base_icm_st_sem_item_bonif, ref rpar_boo_preco_cheio_item_bonif, par_hSql_1, ref rpar_str_msg_erro))
		{
			return false;
		}
		decimal rpar_nu_aliq_icms = default(decimal);
		decimal rpar_nu_aliq_icms_calc_subst = default(decimal);
		bool rpbooIPIForaRedBase = false;
		if (!Usr_ImpostosCalcula_Venda_Busca(par_nu_cd_emp, par_nu_cd_prod, par_str_estado_origem, par_str_estado_destino, par_boo_devol_fornec, par_str_tp_ped, par_boo_util_aliq_interestadual, par_str_tp_inscricao, par_boo_sit_trib_esp_tped, par_str_trib_tp_sit_trib, par_str_trib_tp_red_icms, ref rpar_boo_subst_trib_sobre_cue, ref rpar_boo_subst_trib_sobre_cue_prod, ref rpar_str_subst_trib_sobre_cue_prod_tp_vl, ref rpar_boo_prc_max_consum, ref rpar_nu_aliq_ipi_venda, ref rpar_nu_aliq_ipi_venda_p_cortado, ref rpar_boo_pis_cof_antec, ref rpar_nu_vl_fixo_ipi_compra, ref rpar_nu_aliq_ipi_compra, ref rpar_str_tp_prod, ref rpar_nu_vl_base_produto, ref rpar_boo_produzido, ref rpar_nu_indice_pis, ref rpar_nu_indice_cofins, ref rpar_nu_aliq_icms, ref rpar_nu_aliq_icms_calc_subst, ref rpar_nu_perc_red_base_calc_icms, ref rpar_boo_base_icm_red_sobre_vl, ref rpar_str_cd_sit_trib, ref rpar_boo_incide_icm, ref rpar_boo_incide_icm_subst, ref rpar_str_cd_sit_trib_excecao, ref rpar_boo_incide_icm_excecao, ref rpar_boo_incide_icm_subs_excecao, ref rpar_boo_calc_subst_trib_prc_ch, ref rpar_boo_base_icm_s_trib_sem_red, ref rpar_boo_calc_subst_trib_pmc, ref rpar_nu_red_subst_trib_pmc, ref rpar_nu_red_subst_trib_pmc_cmp, ref rpar_nu_aliq_icms_subst_pmc, ref rpar_nu_perc_margem_subs, ref rpar_nu_perc_margem_subs_esp, ref rpar_nu_perc_red_margem_subs, ref rpar_nu_perc_red_margem_subs_esp, ref rpar_nu_desc_gov, ref rpar_nu_aliq_icms_subst, ref rpar_boo_calc_icm_subst_trib_est, ref rpar_nu_aliq_icm_frete, ref rpar_boo_icms_sobre_preco_cheio, ref rpar_boo_utiliza_ressarc_icm, ref rpar_boo_icm_ressarc_preco_cheio, ref rpar_boo_icm_ressarc_pmc, ref rpar_nu_aliq_icm_ressarc, ref rpar_nu_perc_icm_subst_repasse, ref rpar_nu_perc_icm_subst_rest, ref rpar_boo_base_st_sem_red, ref rpar_boo_subst_red_base_icm_prop, ref rpar_nu_modalidade_base_icms, ref rpar_nu_modalidade_base_icms_st, ref rpar_nu_perc_adicional_nf, ref rpar_nu_perc_ii, par_boo_vda_pf_foraest_redicm, par_boo_util_aliq_st_interestadual, ref rpbooRedBaseIcmStDifIcmNormal, ref rparVlIpiCue, ref rpbooIPIForaRedBase, ref parNuPercMinST, ref rpbooCalculoICMSSTConvenio, seq_trib_cli, ref rpstrTipoValorPreferencialBaseST, ref rpbooSubtraiICMSBasePisCofins, par_hSql_1, ref rpar_str_msg_erro))
		{
			return false;
		}
		rpar_nu_vet_vl_calculados[14] = rpar_nu_aliq_icms;
		rpar_nu_vet_vl_calculados[23] = rpar_nu_aliq_icms_calc_subst;
		flag = false;
		if (!rpar_boo_preco_cheio_item_bonif)
		{
			flag = par_boo_bonificado;
		}
		flag2 = ((!rpar_boo_ipi_base_icm_cad_cli) ? par_boo_base_icms_com_ipi_tped : par_boo_base_icms_com_ipi_cli);
		if (par_boo_devol_fornec)
		{
			rpar_nu_red_subst_trib_pmc = rpar_nu_red_subst_trib_pmc_cmp;
		}
		else if (rpar_boo_empresa_sn)
		{
			par_boo_vet_indicadores_calc[3] = false;
		}
		if (par_boo_isento_subst_trib && rpar_str_cd_sit_trib_excecao.Trim() != null)
		{
			rpar_str_cd_sit_trib = rpar_str_cd_sit_trib_excecao;
			rpar_boo_incide_icm = rpar_boo_incide_icm_excecao;
			rpar_boo_incide_icm_subst = rpar_boo_incide_icm_subs_excecao;
			stAdicItem = stAdicItemExcecao;
			text = text2;
		}
		UtilizouSubstTribAdicItem = stAdicItem;
		if (par_boo_subst_margem_esp)
		{
			if (rpar_nu_perc_margem_subs_esp != 0m)
			{
				rpar_nu_perc_margem_subs = rpar_nu_perc_margem_subs_esp;
			}
			if (rpar_nu_perc_red_margem_subs_esp != 0m)
			{
				rpar_nu_perc_red_margem_subs = rpar_nu_perc_red_margem_subs_esp;
			}
		}
		rpar_nu_vet_vl_calculados[16] = rpar_nu_perc_margem_subs * (1m - rpar_nu_perc_red_margem_subs);
		if (!Usr_ImpostosCalcula_Venda_SimplesNacional(par_nu_cd_emp, ref rpar_boo_empresa_sn, ref rpar_nu_aliq_cred_icms_sn, par_hSql_1, ref rpar_str_msg_erro))
		{
			return false;
		}
		if (rpar_boo_empresa_sn)
		{
			par_boo_vet_indicadores_calc[0] = false;
			par_boo_vet_indicadores_calc[1] = false;
			par_boo_vet_indicadores_calc[2] = false;
			rpar_nu_perc_red_base_calc_icms = default(decimal);
			rpar_nu_vet_vl_calculados[21] = rpar_nu_aliq_cred_icms_sn;
			if (par_boo_vet_indicadores_calc[7])
			{
				rpar_nu_vet_vl_calculados[21] = 0m;
			}
		}
		if (!rpar_boo_incide_icm)
		{
			rpar_nu_aliq_icm_frete = default(decimal);
		}
		num = rpar_nu_perc_red_base_calc_icms;
		if (!rpar_boo_base_icm_s_trib_sem_red)
		{
			rpar_nu_vet_vl_calculados[17] = num;
		}
		else
		{
			rpar_nu_vet_vl_calculados[17] = 0m;
		}
		rpar_nu_vet_vl_calculados[18] = rpar_nu_modalidade_base_icms;
		rpar_nu_vet_vl_calculados[19] = rpar_nu_modalidade_base_icms_st;
		if (par_boo_vet_indicadores_calc[6])
		{
			decimal rpar_nu_valor_calculado = rpar_nu_vet_vl_calculados[24];
			Usr_ImpostosCalcula_Venda_II(par_nu_vet_valores[0], par_nu_qtde_unid_valor, par_nu_vet_valores[8], rpar_nu_perc_ii, ref rpar_nu_valor_calculado);
			rpar_nu_vet_vl_calculados[24] = rpar_nu_valor_calculado;
		}
		else
		{
			rpar_nu_vet_vl_calculados[24] = 0m;
		}
		if (par_boo_vet_indicadores_calc[3])
		{
			decimal rpar_nu_base_ipi = rpar_nu_vet_vl_calculados[2];
			decimal rpar_nu_valor_ipi = rpar_nu_vet_vl_calculados[3];
			decimal rpar_nu_aliq_ipi = rpar_nu_vet_vl_calculados[2];
			if (!Usr_ImpostosCalcula_Venda_IPI(par_nu_vet_valores[0], par_nu_vet_valores[6], par_nu_qtde_unid_valor, par_nu_qtde_unid_est, rpar_boo_base_ipi_com_desc_geral, par_boo_devol_fornec, par_boo_papel_cortado, rpar_boo_produzido, rpar_nu_vl_fixo_ipi_compra, rpar_nu_aliq_ipi_compra, rpar_nu_aliq_ipi_venda, rpar_nu_aliq_ipi_venda_p_cortado, par_nu_vet_valores[8], rpar_nu_vet_vl_calculados[24], par_boo_vet_indicadores_calc[6], par_boo_calc_frete_ipi, ref rpar_nu_base_ipi, ref rpar_nu_valor_ipi, ref rpar_nu_aliq_ipi, ref rpar_nu_valor_ipi_frete))
			{
				return false;
			}
			rpar_nu_vet_vl_calculados[2] = rpar_nu_base_ipi;
			rpar_nu_vet_vl_calculados[3] = rpar_nu_valor_ipi;
			rpar_nu_vet_vl_calculados[15] = rpar_nu_aliq_ipi;
		}
		else
		{
			rpar_nu_vet_vl_calculados[2] = 0m;
			rpar_nu_vet_vl_calculados[3] = 0m;
			rpar_nu_vet_vl_calculados[15] = 0m;
			rpar_nu_valor_ipi_frete = default(decimal);
		}
		if (par_boo_vet_indicadores_calc[1])
		{
			num3 = par_nu_vet_valores[0] * par_nu_qtde_unid_valor - par_nu_vet_valores[6];
			if (par_boo_vet_indicadores_calc[6])
			{
				num3 = (1m + rpar_nu_vet_vl_calculados[14] * (rpar_nu_perc_ii + rpar_nu_vet_vl_calculados[15] * (1m + rpar_nu_vet_vl_calculados[14]))) / ((1m - rpar_nu_indice_pis - rpar_nu_indice_cofins) * (1m - rpar_nu_vet_vl_calculados[14])) * num3;
			}
			decimal par_nu_valor_calculado = rpar_nu_vet_vl_calculados[6];
			if (!Usr_ImpostosCalcula_Venda_PisCof(num3, par_nu_qtde_unid_valor, rpar_nu_indice_pis, rpar_boo_pis_cof_antec, ref par_nu_valor_calculado))
			{
				return false;
			}
			rpar_nu_vet_vl_calculados[6] = par_nu_valor_calculado;
		}
		else
		{
			rpar_nu_vet_vl_calculados[6] = 0m;
		}
		if (par_boo_vet_indicadores_calc[2])
		{
			num4 = par_nu_vet_valores[0] * par_nu_qtde_unid_valor - par_nu_vet_valores[6];
			if (par_boo_vet_indicadores_calc[6])
			{
				num4 = (1m + rpar_nu_vet_vl_calculados[14] * (rpar_nu_perc_ii + rpar_nu_vet_vl_calculados[15] * (1m + rpar_nu_vet_vl_calculados[14]))) / ((1m - rpar_nu_indice_pis - rpar_nu_indice_cofins) * (1m - rpar_nu_vet_vl_calculados[14])) * num4;
			}
			decimal par_nu_valor_calculado2 = rpar_nu_vet_vl_calculados[7];
			if (!Usr_ImpostosCalcula_Venda_PisCof(num4, par_nu_qtde_unid_valor, rpar_nu_indice_cofins, rpar_boo_pis_cof_antec, ref par_nu_valor_calculado2))
			{
				return false;
			}
			rpar_nu_vet_vl_calculados[7] = par_nu_valor_calculado2;
		}
		else
		{
			rpar_nu_vet_vl_calculados[7] = 0m;
		}
		if (par_boo_vet_indicadores_calc[0] || par_boo_vet_indicadores_calc[4])
		{
			if (par_boo_vet_indicadores_calc[4])
			{
				decimal rpar_nu_base_icm_repasse = rpar_nu_vet_vl_calculados[10];
				decimal rpar_nu_vl_icm_repasse = rpar_nu_vet_vl_calculados[11];
				if (!Usr_ImpostosCalcula_Venda_Repass(par_boo_calc_repasse, rpar_nu_perc_icm_subst_repasse, par_nu_qtde_unid_valor, par_nu_qtde_unid_est, par_nu_vet_valores[0], par_nu_vet_valores[4], rpar_boo_subst_trib_sobre_cue, rpar_boo_subst_trib_sobre_cue_prod, ref rpar_nu_base_icm_repasse, ref rpar_nu_vl_icm_repasse))
				{
					return false;
				}
				rpar_nu_vet_vl_calculados[10] = rpar_nu_base_icm_repasse;
				rpar_nu_vet_vl_calculados[11] = rpar_nu_vl_icm_repasse;
				decimal rpar_nu_base_icm_subst_rest = rpar_nu_vet_vl_calculados[12];
				decimal rpar_nu_vl_icm_subst_rest = rpar_nu_vet_vl_calculados[13];
				if (!Usr_ImpostosCalcula_Venda_Restit(par_nu_qtde_unid_valor, par_nu_qtde_unid_est, par_nu_vet_valores[1], par_nu_vet_valores[4], rpar_boo_subst_trib_sobre_cue, rpar_boo_subst_trib_sobre_cue_prod, rpar_nu_vet_vl_calculados[11], flag, rpar_nu_perc_icm_subst_rest, rpar_boo_bonif_fora_icm_rest, ref rpar_nu_base_icm_subst_rest, ref rpar_nu_vl_icm_subst_rest))
				{
					return false;
				}
				rpar_nu_vet_vl_calculados[12] = rpar_nu_base_icm_subst_rest;
				rpar_nu_vet_vl_calculados[13] = rpar_nu_vl_icm_subst_rest;
			}
			else
			{
				rpar_nu_vet_vl_calculados[10] = 0m;
				rpar_nu_vet_vl_calculados[11] = 0m;
				rpar_nu_vet_vl_calculados[12] = 0m;
				rpar_nu_vet_vl_calculados[13] = 0m;
			}
			decimal rpar_nu_vl_base_icms = rpar_nu_vet_vl_calculados[0];
			decimal rpar_nu_vl_icms = rpar_nu_vet_vl_calculados[1];
			if (!Usr_ImpostosCalcula_Venda_ICMS(rpar_str_tp_prod, par_str_estado_origem, par_str_estado_destino, rpar_boo_incide_icm, rpar_boo_incide_icm_subst, rpar_boo_subst_trib_sobre_cue, rpar_boo_subst_trib_sobre_cue_prod, rpar_str_subst_trib_sobre_cue_prod_tp_vl, rpar_boo_base_icm_preco_liquido, rpar_boo_subst_trib_sobre_cue, flag2, par_boo_imp_aliq_icm_isentos, par_boo_base_icms_com_ipi_frete, rpar_boo_icms_sobre_preco_cheio, flag, rpar_boo_base_icm_sem_item_bonif, rpar_boo_base_icm_red_sobre_vl, rpar_boo_calc_subst_trib_prc_ch, ref rpar_nu_aliq_icms, ref rpar_nu_aliq_icms_calc_subst, par_nu_qtde_unid_valor, par_nu_qtde_unid_est, par_nu_vet_valores[1], par_nu_vet_valores[0], par_nu_vet_valores[6], par_nu_vet_valores[7], rpar_nu_vet_vl_calculados[3], rpar_nu_vl_base_produto, par_nu_vet_valores[4], rpar_nu_perc_red_base_calc_icms, rpar_nu_valor_ipi_frete, rpar_nu_aliq_icm_frete, par_nu_vet_valores[8], rpar_nu_vet_vl_calculados[11], rpar_boo_subtrai_repasse_baseicm, rpar_boo_base_st_sem_red, (par_nu_vet_valores[1] - par_nu_vet_valores[0]) * par_nu_qtde_unid_valor, rpar_boo_subst_red_base_icm_prop, ref rpar_nu_vl_base_icms, ref rpar_nu_vl_icms, ref rpar_nu_base_icm_aux_subst, ref rpar_nu_vl_icm_aux_subst, num2, 0m, par_boo_vet_indicadores_calc[6], rpar_nu_vet_vl_calculados[24], rpar_nu_vet_vl_calculados[25], rpar_nu_vet_vl_calculados[6], rpar_nu_vet_vl_calculados[7], rpbooIPIForaRedBase, parNuPercMinST))
			{
				return false;
			}
			rpar_nu_vet_vl_calculados[0] = rpar_nu_vl_base_icms;
			rpar_nu_vet_vl_calculados[1] = rpar_nu_vl_icms;
			rpar_nu_vet_vl_calculados[14] = rpar_nu_aliq_icms;
			rpar_nu_vet_vl_calculados[23] = rpar_nu_aliq_icms_calc_subst;
			rpar_nu_vet_vl_calculados[22] = rpar_nu_perc_red_base_calc_icms;
		}
		else
		{
			rpar_nu_vet_vl_calculados[0] = 0m;
			rpar_nu_vet_vl_calculados[14] = 0m;
			rpar_nu_vet_vl_calculados[1] = 0m;
			rpar_nu_vet_vl_calculados[22] = 0m;
			rpar_nu_base_icm_aux_subst = default(decimal);
			rpar_nu_vl_icm_aux_subst = default(decimal);
		}
		if (rpbooSubtraiICMSBasePisCofins && !par_boo_vet_indicadores_calc[6] && rpar_nu_vet_vl_calculados[1] > 0m)
		{
			if (par_boo_vet_indicadores_calc[1])
			{
				num3 = par_nu_vet_valores[0] * par_nu_qtde_unid_valor - par_nu_vet_valores[6];
				if (num3 - rpar_nu_vet_vl_calculados[1] > 0m)
				{
					num3 -= rpar_nu_vet_vl_calculados[1];
				}
				decimal par_nu_valor_calculado3 = rpar_nu_vet_vl_calculados[6];
				if (!Usr_ImpostosCalcula_Venda_PisCof(num3, par_nu_qtde_unid_valor, rpar_nu_indice_pis, rpar_boo_pis_cof_antec, ref par_nu_valor_calculado3))
				{
					return false;
				}
				rpar_nu_vet_vl_calculados[6] = par_nu_valor_calculado3;
			}
			else
			{
				rpar_nu_vet_vl_calculados[6] = 0m;
			}
			if (par_boo_vet_indicadores_calc[2])
			{
				num4 = par_nu_vet_valores[0] * par_nu_qtde_unid_valor - par_nu_vet_valores[6];
				if (num3 - rpar_nu_vet_vl_calculados[1] > 0m)
				{
					num4 -= rpar_nu_vet_vl_calculados[1];
				}
				decimal par_nu_valor_calculado4 = rpar_nu_vet_vl_calculados[7];
				if (!Usr_ImpostosCalcula_Venda_PisCof(num4, par_nu_qtde_unid_valor, rpar_nu_indice_cofins, rpar_boo_pis_cof_antec, ref par_nu_valor_calculado4))
				{
					return false;
				}
				rpar_nu_vet_vl_calculados[7] = par_nu_valor_calculado4;
			}
			else
			{
				rpar_nu_vet_vl_calculados[7] = 0m;
			}
		}
		if (par_boo_vet_indicadores_calc[4])
		{
			decimal rpar_nu_vl_base_icm_subst = rpar_nu_vet_vl_calculados[4];
			decimal rpar_nu_vl_icm_subst = rpar_nu_vet_vl_calculados[5];
			rpar_nu_vet_vl_calculados[27] = rpar_nu_aliq_icms_subst;
			if (!Usr_ImpostosCalcula_Venda_STrib(rpar_str_tp_prod, par_str_tp_inscricao, rpar_str_cd_sit_trib_excecao, rpar_boo_incide_icm_subst, par_boo_isento_subst_trib, rpar_boo_subst_trib_apenas_ie, rpar_boo_calc_icm_subst_trib_est, rpar_boo_calc_subst_trib_prc_ch, rpar_boo_subst_trib_sobre_cue, rpar_boo_subst_trib_sobre_cue_prod, rpar_str_subst_trib_sobre_cue_prod_tp_vl, rpar_boo_base_icm_s_trib_sem_red, rpar_boo_prc_max_consum, rpar_boo_calc_subst_trib_pmc, par_boo_calc_repasse, par_boo_strib_sem_credito_icm, par_nu_vet_valores[1], par_nu_vet_valores[4], par_nu_qtde_unid_valor, par_nu_qtde_unid_est, rpar_nu_aliq_icms_subst, rpar_nu_aliq_icms_subst_pmc, rpar_nu_vet_vl_calculados[1], rpar_nu_vl_icm_aux_subst, rpar_nu_base_icm_aux_subst, rpar_nu_perc_margem_subs, rpar_nu_perc_red_margem_subs, num, par_nu_vet_valores[5], rpar_nu_desc_gov, rpar_nu_red_subst_trib_pmc, ref rpar_nu_vl_base_icm_subst, ref rpar_nu_vl_icm_subst, par_nu_vet_valores[8], rpar_boo_base_icm_st_sem_item_bonif, flag, num2, rpbooRedBaseIcmStDifIcmNormal, rparVlIpiCue, par_boo_vet_indicadores_calc[12], parNuPercMinST, par_boo_vet_indicadores_calc[10], rpbooCalculoICMSSTConvenio, rpstrTipoValorPreferencialBaseST))
			{
				return false;
			}
			rpar_nu_vet_vl_calculados[4] = rpar_nu_vl_base_icm_subst;
			rpar_nu_vet_vl_calculados[5] = rpar_nu_vl_icm_subst;
			if (!par_boo_vet_indicadores_calc[0])
			{
				rpar_nu_vet_vl_calculados[0] = 0m;
				rpar_nu_vet_vl_calculados[14] = 0m;
				rpar_nu_vet_vl_calculados[1] = 0m;
			}
		}
		else
		{
			rpar_nu_vet_vl_calculados[4] = 0m;
			rpar_nu_vet_vl_calculados[5] = 0m;
		}
		if (par_boo_vet_indicadores_calc[5])
		{
			decimal rpar_nu_vl_base_icm_ressarc = rpar_nu_vet_vl_calculados[8];
			decimal rpar_nu_vl_icm_ressarc = rpar_nu_vet_vl_calculados[9];
			if (!Usr_ImpostosCalcula_Venda_Ressar(rpar_boo_utiliza_ressarc_icm, flag, par_boo_calc_icm_ressarc_bonif, rpar_boo_icm_ressarc_preco_cheio, rpar_boo_icm_ressarc_pmc, rpar_boo_subst_trib_sobre_cue, rpar_boo_subst_trib_sobre_cue_prod, par_nu_vet_valores[1], par_nu_vet_valores[0], par_nu_vet_valores[5], rpar_nu_aliq_icm_ressarc, rpar_nu_aliq_icms_subst, rpar_nu_vet_vl_calculados[14], par_nu_vet_valores[4], par_nu_vet_valores[6], par_nu_qtde_unid_valor, par_nu_qtde_unid_est, rpar_nu_perc_margem_subs, rpar_nu_perc_red_margem_subs, rpar_nu_desc_gov, rpar_nu_red_subst_trib_pmc, rpar_str_tp_prod, ref rpar_nu_vl_base_icm_ressarc, ref rpar_nu_vl_icm_ressarc))
			{
				return false;
			}
			rpar_nu_vet_vl_calculados[8] = rpar_nu_vl_base_icm_ressarc;
			rpar_nu_vet_vl_calculados[9] = rpar_nu_vl_icm_ressarc;
		}
		else
		{
			rpar_nu_vet_vl_calculados[8] = 0m;
			rpar_nu_vet_vl_calculados[9] = 0m;
		}
		decimal rpar_nu_vl_adic_nf = rpar_nu_vet_vl_calculados[20];
		if (!Usr_ImpostosCalcula_Venda_Adic_NF(rpar_nu_perc_adicional_nf, par_nu_qtde_unid_valor, par_nu_qtde_unid_est, par_nu_vet_valores[0], par_nu_vet_valores[4], rpar_boo_subst_trib_sobre_cue, rpar_boo_subst_trib_sobre_cue_prod, ref rpar_nu_vl_adic_nf))
		{
			return false;
		}
		rpar_nu_vet_vl_calculados[20] = rpar_nu_vl_adic_nf;
		rpar_nu_vet_vl_calculados[26] = seq_trib_cli;
		rpar_nu_vet_vl_calculados[41] = 0m;
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_Busca(int par_nu_cd_emp, int par_nu_cd_prod, string par_str_estado_origem, string par_str_estado_destino, bool par_boo_devol_fornec, string par_str_tp_ped, bool par_boo_util_aliq_interestadual, string par_str_tp_inscricao, bool par_boo_sit_trib_especial_tped, string par_str_trib_tp_sit_trib, string par_str_trib_tp_red_icms, ref bool rpar_boo_subst_trib_sobre_cue, ref bool rpar_boo_subst_trib_sobre_cue_prod, ref string rpar_str_subst_trib_sobre_cue_prod_tp_vl, ref bool rpar_boo_prc_max_consum, ref decimal rpar_nu_aliq_ipi_venda, ref decimal rpar_nu_aliq_ipi_venda_p_cortado, ref bool rpar_boo_pis_cof_antec, ref decimal rpar_nu_vl_fixo_ipi_compra, ref decimal rpar_nu_aliq_ipi_compra, ref string rpar_str_tp_prod, ref decimal rpar_nu_vl_base_produto, ref bool rpar_boo_produzido, ref decimal rpar_nu_indice_pis, ref decimal rpar_nu_indice_cofins, ref decimal rpar_nu_aliq_icms, ref decimal rpar_nu_aliq_icms_calc_subst, ref decimal rpar_nu_perc_red_base_calc_icms, ref bool rpar_boo_base_icm_red_sobre_vl, ref string rpar_str_cd_sit_trib, ref bool rpar_boo_incide_icm, ref bool rpar_boo_incide_icm_subst, ref string rpar_str_cd_sit_trib_excecao, ref bool rpar_boo_incide_icm_excecao, ref bool rpar_boo_incide_icm_subs_excecao, ref bool rpar_boo_calc_subst_trib_prc_ch, ref bool rpar_boo_base_icm_s_trib_sem_red, ref bool rpar_boo_calc_subst_trib_pmc, ref decimal rpar_nu_red_subst_trib_pmc, ref decimal rpar_nu_red_subst_trib_pmc_cmp, ref decimal rpar_nu_aliq_icms_subst_pmc, ref decimal rpar_nu_perc_margem_subs, ref decimal rpar_nu_perc_margem_subs_esp, ref decimal rpar_nu_perc_red_margem_subs, ref decimal rpar_nu_perc_red_margem_subs_esp, ref decimal rpar_nu_desc_gov, ref decimal rpar_nu_aliq_icms_subst, ref bool rpar_boo_calc_icm_subst_trib_est, ref decimal rpar_nu_aliq_icm_frete, ref bool rpar_boo_icms_sobre_preco_cheio, ref bool rpar_boo_utiliza_ressarc_icm, ref bool rpar_boo_icm_ressarc_preco_cheio, ref bool rpar_boo_icm_ressarc_pmc, ref decimal rpar_nu_aliq_icm_ressarc, ref decimal rpar_nu_perc_icm_subst_repasse, ref decimal rpar_nu_perc_icm_subst_rest, ref bool rpar_boo_base_st_sem_red, ref bool rpar_boo_subst_red_base_icm_prop, ref decimal rpar_nu_modalidade_base_icms, ref decimal rpar_nu_modalidade_base_icms_st, ref decimal rpar_nu_perc_adicional_nf, ref decimal rpar_nu_perc_ii, bool par_boo_vda_pf_foraest_redicm, bool par_boo_util_aliq_st_interestadual, ref bool rpbooRedBaseIcmStDifIcmNormal, ref decimal rparVlIpiCue, ref bool rpbooIPIForaRedBase, ref decimal parNuPercMinST, ref bool rpbooCalculoICMSSTConvenio52, int pnuSeqTribCli, ref string rpstrTipoValorPreferencialBaseST, ref bool rpbooSubtraiICMSBasePisCofins, SqlConnection par_hSql, ref string rpar_str_msg_erro)
	{
		string text = "";
		string value = "";
		if (par_str_estado_origem == par_str_estado_destino)
		{
			value = "ME";
		}
		else if (par_str_estado_origem != par_str_estado_destino)
		{
			value = "OE";
		}
		string text2;
		string text3;
		if (par_boo_devol_fornec)
		{
			if (par_boo_util_aliq_interestadual)
			{
				text2 = par_str_estado_destino;
				text3 = par_str_estado_destino;
			}
			else
			{
				text2 = par_str_estado_destino;
				text3 = par_str_estado_origem;
			}
		}
		else if (par_boo_util_aliq_interestadual)
		{
			text2 = par_str_estado_origem;
			text3 = par_str_estado_origem;
		}
		else
		{
			text2 = par_str_estado_origem;
			text3 = par_str_estado_destino;
		}
		string cmdText = "SELECT\tCalculoICMSSTConvenio52\r\n                            FROM\ttp_ped\r\n                            WHERE\ttp_ped = @par_str_tp_ped\t\t";
		using (SqlCommand sqlCommand = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@par_str_tp_ped", par_str_tp_ped);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.Read())
			{
				rpar_str_msg_erro = $"Não foi possível encontrar o tipo de pedido especificado.\nTipo de pedido: {par_str_tp_ped}";
				return false;
			}
			rpbooCalculoICMSSTConvenio52 = GetDrValue<bool>(sqlDataReader[0]);
		}
		cmdText = "SELECT \r\n\t\t                        TipoValorPreferencialBaseST\r\n                            FROM\t\r\n                                tributacao_cli\r\n                            WHERE\t\r\n                                seq_trib_cli = @pnuSeqTribCli\t";
		using (SqlCommand sqlCommand2 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand2.Parameters.Clear();
			sqlCommand2.Parameters.AddWithValue("@pnuSeqTribCli", pnuSeqTribCli);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			if (!sqlDataReader2.Read())
			{
				rpar_str_msg_erro = $"Não foi possível encontrar o tipo de tributação especificado.\nTipo de tributação: {pnuSeqTribCli}";
				return false;
			}
			rpstrTipoValorPreferencialBaseST = GetDrValue<string>(sqlDataReader2[0]);
		}
		string arg = Usr_ImpostosRetornaCdSitTrib(par_str_trib_tp_sit_trib, par_boo_devol_fornec, par_boo_sit_trib_especial_tped);
		cmdText = "SELECT\t{0}\r\n                        FROM  dbo.ufnIcmProd( @par_nu_cd_emp, @par_nu_cd_prod, @str_estado_de, @str_estado_para )\r\n                        ";
		cmdText = string.Format(cmdText, arg);
		string text4;
		using (SqlCommand sqlCommand3 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand3.Parameters.Clear();
			sqlCommand3.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			sqlCommand3.Parameters.AddWithValue("@str_estado_de", text2);
			sqlCommand3.Parameters.AddWithValue("@str_estado_para", text3);
			sqlCommand3.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			if (!sqlDataReader3.Read())
			{
				rpar_str_msg_erro = $"Não foi possível encontrar o código da situação tributária.\nProduto: {par_nu_cd_prod}. Estado Origem: {par_str_estado_origem}. Estado Destino: {par_str_estado_destino}.";
				return false;
			}
			text4 = GetDrValue<string>(sqlDataReader3[0]);
		}
		cmdText = "\tSELECT pc.calc_subst_custo_cue, pc.prc_max_consum, pc.utiliza_ressarc_icm, pc.UtilizaSubtracaoICMSBasePisCofins\r\n                                FROM\r\n                                    par_cfg pc\r\n                                WHERE cd_emp = @par_nu_cd_emp\t\t\t";
		using (SqlCommand sqlCommand4 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand4.Parameters.Clear();
			sqlCommand4.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
			if (!sqlDataReader4.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <par_cfg> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rpar_boo_subst_trib_sobre_cue = GetDrValue<bool>(sqlDataReader4[0]);
			rpar_boo_prc_max_consum = GetDrValue<bool>(sqlDataReader4[1]);
			rpar_boo_utiliza_ressarc_icm = GetDrValue<bool>(sqlDataReader4[2]);
			bool drValue = GetDrValue<bool>(sqlDataReader4[3]);
		}
		cmdText = "\tSELECT\r\n                                    p.aliq_ipi,\r\n                                    p.aliq_ipi_cortado,\r\n\t\t                            (SELECT CASE WHEN cred_deb = 0\r\n\t\t\t                                THEN 1\r\n\t\t\t                                ELSE 0\r\n\t\t\t                                END\r\n\t\t                            FROM  cst_pis_cofins\r\n\t\t                            WHERE seq_cst_pis_cofins = (SELECT dbo.fn_cst_pis_cofins_sai (p.cd_prod, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                                        @par_nu_cd_emp, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                                        dbo.FunRetornaCFOPSaida ( @par_nu_cd_prod,  \r\n                                                                                                                            @par_str_tp_ped , \r\n                                                                                                                            @strCliDest ,\r\n                                                                                                                            @str_cd_sit_trib ) ,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                                    NULL, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                                    NULL, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                                    0, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t                                    0,\r\n                                                                                                @seq_trib_cli))),\r\n                                    p.vl_ipi_cmp_fixo,\r\n                                    p.perc_ipi_compra,\r\n                                    p.tp_prod,\r\n                                    p.vl_base_produto,\r\n                                    p.produzido,\r\n                                    p.perc_ii\r\n                                FROM\r\n                                    produto p\r\n                                WHERE\r\n                                    p.cd_prod = @par_nu_cd_prod\t\t\t";
		using (SqlCommand sqlCommand5 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand5.Parameters.Clear();
			sqlCommand5.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			sqlCommand5.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			sqlCommand5.Parameters.AddWithValue("@par_str_tp_ped", par_str_tp_ped);
			sqlCommand5.Parameters.AddWithValue("@strCliDest", value);
			sqlCommand5.Parameters.AddWithValue("@str_cd_sit_trib", text4);
			sqlCommand5.Parameters.AddWithValue("@seq_trib_cli", seq_trib_cli);
			SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
			if (!sqlDataReader5.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <produto> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rpar_nu_aliq_ipi_venda = GetDrValue<decimal>(sqlDataReader5[0]);
			rpar_nu_aliq_ipi_venda_p_cortado = GetDrValue<decimal>(sqlDataReader5[1]);
			rpar_boo_pis_cof_antec = GetDrValue<bool>(sqlDataReader5[2]);
			rpar_nu_vl_fixo_ipi_compra = GetDrValue<decimal>(sqlDataReader5[3]);
			rpar_nu_aliq_ipi_compra = GetDrValue<decimal>(sqlDataReader5[4]);
			rpar_str_tp_prod = GetDrValue<string>(sqlDataReader5[5]);
			rpar_nu_vl_base_produto = GetDrValue<decimal>(sqlDataReader5[6]);
			rpar_boo_produzido = GetDrValue<bool>(sqlDataReader5[7]);
			rpar_nu_perc_ii = GetDrValue<decimal>(sqlDataReader5[8]);
		}
		cmdText = " SELECT dbo.fn_aliq_pis(@par_nu_cd_prod,\r\n                                                    @par_nu_cd_emp, \r\n                                                    dbo.FunRetornaCFOPSaida ( @par_nu_cd_prod,  \r\n                                                                              @par_str_tp_ped , \r\n                                                                              @strCliDest ,\r\n                                                                              @str_cd_sit_trib ) ,\r\n                                                    null,    \r\n                                                    null,\r\n                                                    @seq_trib_cli,\r\n                                                    0   ) as nu_aliq_pis_produto_ncm\r\n                                                    ";
		decimal drValue2;
		using (SqlCommand sqlCommand6 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand6.Parameters.Clear();
			sqlCommand6.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			sqlCommand6.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			sqlCommand6.Parameters.AddWithValue("@par_str_tp_ped", par_str_tp_ped);
			sqlCommand6.Parameters.AddWithValue("@strCliDest", value);
			sqlCommand6.Parameters.AddWithValue("@str_cd_sit_trib", text4);
			sqlCommand6.Parameters.AddWithValue("@seq_trib_cli", seq_trib_cli);
			SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
			if (!sqlDataReader6.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <produto - PIS> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			drValue2 = GetDrValue<decimal>(sqlDataReader6[0]);
		}
		rpar_nu_indice_pis = drValue2;
		cmdText = " SELECT\tdbo.fn_aliq_cofins(@par_nu_cd_prod,\r\n                                                        @par_nu_cd_emp, \r\n                                                        dbo.FunRetornaCFOPSaida ( @par_nu_cd_prod,  \r\n                                                                                    @par_str_tp_ped , \r\n                                                                                    @strCliDest ,\r\n                                                                                    @str_cd_sit_trib ) ,\r\n                                                        null,\r\n                                                        null,\r\n                                                        @seq_trib_cli,\r\n                                                        0) as nu_aliq_cofins_produto_ncm\t";
		decimal drValue3;
		using (SqlCommand sqlCommand7 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand7.Parameters.Clear();
			sqlCommand7.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			sqlCommand7.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			sqlCommand7.Parameters.AddWithValue("@par_str_tp_ped", par_str_tp_ped);
			sqlCommand7.Parameters.AddWithValue("@strCliDest", value);
			sqlCommand7.Parameters.AddWithValue("@str_cd_sit_trib", text4);
			sqlCommand7.Parameters.AddWithValue("@seq_trib_cli", seq_trib_cli);
			SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
			if (!sqlDataReader7.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <produto - PIS> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			drValue3 = GetDrValue<decimal>(sqlDataReader7[0]);
		}
		rpar_nu_indice_cofins = drValue3;
		cmdText = "SELECT\r\n\t\t\t                    SubtraiICMSBasePisCofins\r\n                \t\t   FROM\r\n\t\t\t                    tp_ped\r\n\t\t                   WHERE\r\n\t\t\t                    tp_ped = @par_str_tp_ped";
		using (SqlCommand sqlCommand8 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand8.Parameters.Clear();
			sqlCommand8.Parameters.AddWithValue("@par_str_tp_ped", par_str_tp_ped);
			SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
			if (!sqlDataReader8.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <par_cfg> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rpbooSubtraiICMSBasePisCofins = GetDrValue<bool>(sqlDataReader8[0]);
		}
		if (par_boo_devol_fornec && par_str_tp_ped != null && par_str_tp_ped != "")
		{
			cmdText = "SELECT\tcd_sit_trib_corresp\r\n                                FROM\ttped_sit_trib_corresp\r\n                                WHERE\ttp_ped = @par_str_tp_ped\r\n                                AND\t    cd_sit_trib_corresp = @str_cd_sit_trib\t";
			using SqlCommand sqlCommand9 = new SqlCommand(cmdText, par_hSql);
			sqlCommand9.Parameters.Clear();
			sqlCommand9.Parameters.AddWithValue("@par_str_tp_ped", par_str_tp_ped);
			sqlCommand9.Parameters.AddWithValue("@str_cd_sit_trib", text4);
			sqlCommand9.Parameters.AddWithValue("@par_str_tp_ped", par_str_tp_ped);
			sqlCommand9.Parameters.AddWithValue("@strCliDest", value);
			sqlCommand9.Parameters.AddWithValue("@str_cd_sit_trib", text4);
			SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
			if (sqlDataReader9.Read())
			{
				text4 = text;
			}
		}
		string arg2 = Usr_ImpostosRetornaRedBaseICMS(par_str_trib_tp_red_icms, "ic");
		cmdText = "SELECT\r\n                                ic.aliq_icm,\r\n                                COALESCE(ic.aliq_icm_proprio_calc_st, ic.aliq_icm),\r\n                                {0},\r\n                                ic.red_baseicm_vl_calc,\r\n                                '{1}',\r\n                                st.incide_icm,\r\n                        \r\n                                st.incide_icm_subst,\r\n                                st.st_adic_item,\r\n                                ic.cd_sit_trib_excecao,\r\n                                ste.incide_icm,\r\n                                ste.incide_icm_subst,\r\n                        \r\n                                ste.st_adic_item,\r\n                                ic.icm_subst_preco_cheio,\r\n                                ic.base_st_sem_red,\r\n                                ic.subst_trib_prc_max,\r\n                                ic.subst_pmc_red_base,\r\n                        \r\n                                ic.subst_pmc_red_base_comp,\r\n                                ic.aliq_calc_icm_subst,\r\n                                ic.icm_preco_cheio,\r\n                                ic.icm_ressarc_preco_cheio,\r\n                                ic.icm_ressarc_pmc,\r\n                        \r\n                                ic.base_st_sem_red,\r\n                                ISNULL( ic.margem_subst, 0 ),\r\n                                ISNULL( ic.margem_subst_esp, 0 ),\r\n                                ISNULL( ic.red_margem_subst, 0 ),\r\n                                ISNULL( ic.red_margem_subst_esp, 0 ),\r\n                        \r\n                                ISNULL( ic.aplic_subst_custo_cue, 0 ),\r\n                                ISNULL( ic.aplic_subst_custo_cue_tp_vl, 'VDA' ),\r\n                                ic.subst_red_base_icm_prop,\r\n                                ic.cd_modalidade_base_icms,\r\n                                ic.perc_adicional_nf,\r\n\r\n\t\t                        ISNULL( ic.RedBaseSt, 0 ),\r\n                                ISNULL( ic.IPIForaRedBase, 0 ),\r\n                                ISNULL( ic.PorcMinST, 0 ) ";
		cmdText += "FROM\r\n                                        dbo.ufnIcmProd(@par_nu_cd_emp, @par_nu_cd_prod, @str_estado_de, @str_estado_para) ic\r\n                                        JOIN sit_trib(nolock) st\r\n                                            ON st.cd_sit_trib = @str_cd_sit_trib\r\n                                        LEFT OUTER JOIN sit_trib ste\r\n                                            ON ste.cd_sit_trib = ic.cd_sit_trib_excecao\r\n                                    ";
		cmdText = string.Format(cmdText, arg2, text4);
		bool drValue4;
		bool drValue5;
		bool drValue6;
		bool drValue7;
		using (SqlCommand sqlCommand10 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand10.Parameters.Clear();
			sqlCommand10.Parameters.AddWithValue("@str_cd_sit_trib", text4);
			sqlCommand10.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			sqlCommand10.Parameters.AddWithValue("@str_estado_de", text2);
			sqlCommand10.Parameters.AddWithValue("@str_estado_para", text3);
			sqlCommand10.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
			if (!sqlDataReader10.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <icm_prod/sit_trib> - Usr_ImpostosCalcula_Busca";
				return false;
			}
			rpar_nu_aliq_icms = GetDrValue<decimal>(sqlDataReader10[0]);
			rpar_nu_aliq_icms_calc_subst = GetDrValue<decimal>(sqlDataReader10[1]);
			rpar_nu_perc_red_base_calc_icms = GetDrValue<decimal>(sqlDataReader10[2]);
			rpar_boo_base_icm_red_sobre_vl = GetDrValue<bool>(sqlDataReader10[3]);
			rpar_str_cd_sit_trib = GetDrValue<string>(sqlDataReader10[4]);
			rpar_boo_incide_icm = GetDrValue<bool>(sqlDataReader10[5]);
			drValue4 = GetDrValue<bool>(sqlDataReader10[6]);
			drValue5 = GetDrValue<bool>(sqlDataReader10[7]);
			rpar_str_cd_sit_trib_excecao = GetDrValue<string>(sqlDataReader10[8]);
			rpar_boo_incide_icm_excecao = GetDrValue<bool>(sqlDataReader10[9]);
			drValue6 = GetDrValue<bool>(sqlDataReader10[10]);
			drValue7 = GetDrValue<bool>(sqlDataReader10[11]);
			rpar_boo_calc_subst_trib_prc_ch = GetDrValue<bool>(sqlDataReader10[12]);
			rpar_boo_base_icm_s_trib_sem_red = GetDrValue<bool>(sqlDataReader10[13]);
			rpar_boo_calc_subst_trib_pmc = GetDrValue<bool>(sqlDataReader10[14]);
			rpar_nu_red_subst_trib_pmc = GetDrValue<decimal>(sqlDataReader10[15]);
			rpar_nu_red_subst_trib_pmc_cmp = GetDrValue<decimal>(sqlDataReader10[16]);
			rpar_nu_aliq_icms_subst_pmc = GetDrValue<decimal>(sqlDataReader10[17]);
			rpar_boo_icms_sobre_preco_cheio = GetDrValue<bool>(sqlDataReader10[18]);
			rpar_boo_icm_ressarc_preco_cheio = GetDrValue<bool>(sqlDataReader10[19]);
			rpar_boo_icm_ressarc_pmc = GetDrValue<bool>(sqlDataReader10[20]);
			rpar_boo_base_st_sem_red = GetDrValue<bool>(sqlDataReader10[21]);
			rpar_nu_perc_margem_subs = GetDrValue<decimal>(sqlDataReader10[22]);
			rpar_nu_perc_margem_subs_esp = GetDrValue<decimal>(sqlDataReader10[23]);
			rpar_nu_perc_red_margem_subs = GetDrValue<decimal>(sqlDataReader10[24]);
			rpar_nu_perc_red_margem_subs_esp = GetDrValue<decimal>(sqlDataReader10[25]);
			rpar_boo_subst_trib_sobre_cue_prod = GetDrValue<bool>(sqlDataReader10[26]);
			rpar_str_subst_trib_sobre_cue_prod_tp_vl = GetDrValue<string>(sqlDataReader10[27]);
			rpar_boo_subst_red_base_icm_prop = GetDrValue<bool>(sqlDataReader10[28]);
			rpar_nu_modalidade_base_icms = GetDrValue<decimal>(sqlDataReader10[29]);
			rpar_nu_perc_adicional_nf = GetDrValue<decimal>(sqlDataReader10[30]);
			rpbooRedBaseIcmStDifIcmNormal = GetDrValue<bool>(sqlDataReader10[31]);
			rpbooIPIForaRedBase = GetDrValue<bool>(sqlDataReader10[32]);
			parNuPercMinST = GetDrValue<decimal>(sqlDataReader10[33]);
		}
		stAdicItem = drValue5;
		stAdicItemExcecao = drValue7;
		if (drValue4 || drValue5)
		{
			rpar_boo_incide_icm_subst = true;
		}
		else
		{
			rpar_boo_incide_icm_subst = false;
		}
		if (drValue6 || drValue7)
		{
			rpar_boo_incide_icm_subs_excecao = true;
		}
		else
		{
			rpar_boo_incide_icm_subs_excecao = false;
		}
		if (par_str_tp_inscricao != "E")
		{
			cmdText = "SELECT\r\n                                ic.aliq_icm,\r\n                                {0},\r\n                                ic.red_baseicm_vl_calc\r\n                            FROM\r\n                                dbo.ufnIcmProd( @par_nu_cd_emp, @par_nu_cd_prod, @str_estado_de, @str_estado_de ) ic\r\n                            ";
			cmdText = string.Format(cmdText, arg2);
			using (SqlCommand sqlCommand11 = new SqlCommand(cmdText, par_hSql))
			{
				sqlCommand11.Parameters.Clear();
				sqlCommand11.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
				sqlCommand11.Parameters.AddWithValue("@str_estado_de", text2);
				sqlCommand11.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
				SqlDataReader sqlDataReader11 = sqlCommand11.ExecuteReader();
				if (!sqlDataReader11.Read())
				{
					rpar_str_msg_erro = $"Dados de impostos não localizados - Usr_ImpostosCalcula_Busca.\nProduto: {par_nu_cd_prod}. Estado Origem: {text2}. Estado Destino: {text2}.";
					return false;
				}
				rpar_nu_aliq_icms = GetDrValue<decimal>(sqlDataReader11[0]);
				rpar_nu_perc_red_base_calc_icms = GetDrValue<decimal>(sqlDataReader11[1]);
				rpar_boo_base_icm_red_sobre_vl = GetDrValue<bool>(sqlDataReader11[2]);
			}
			if (!par_boo_vda_pf_foraest_redicm && text2 != text3)
			{
				rpar_nu_perc_red_base_calc_icms = default(decimal);
			}
		}
		cmdText = "SELECT\r\n                                desc_gov\r\n                            FROM\r\n                                prc_max_prod (nolock)\r\n                            WHERE\r\n                                estado = @str_estado_para\r\n                            AND\tcd_prod = @par_nu_cd_prod\t";
		using (SqlCommand sqlCommand12 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand12.Parameters.Clear();
			sqlCommand12.Parameters.AddWithValue("@str_estado_para", text3);
			sqlCommand12.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			SqlDataReader sqlDataReader12 = sqlCommand12.ExecuteReader();
			if (sqlDataReader12.Read())
			{
				rpar_nu_desc_gov = GetDrValue<decimal>(sqlDataReader12[0]);
			}
			else
			{
				rpar_nu_desc_gov = default(decimal);
			}
		}
		string arg3 = " i.aliq_calc_icm_subst, ";
		if (par_boo_util_aliq_st_interestadual)
		{
			arg3 = " i.aliq_icm, ";
		}
		cmdText = "SELECT\r\n                            {0}\r\n                            i.aliq_calc_icm_ressarc,\r\n                            i.cd_modalidade_base_icms_st\r\n                        FROM\r\n                            dbo.ufnIcmProd( @par_nu_cd_emp, @par_nu_cd_prod, @str_estado_de, @str_estado_para ) i \r\n                        ";
		cmdText = string.Format(cmdText, arg3);
		using (SqlCommand sqlCommand13 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand13.Parameters.Clear();
			sqlCommand13.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			sqlCommand13.Parameters.AddWithValue("@str_estado_de", text2);
			sqlCommand13.Parameters.AddWithValue("@str_estado_para", text3);
			sqlCommand13.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			SqlDataReader sqlDataReader13 = sqlCommand13.ExecuteReader();
			if (!sqlDataReader13.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <icm_prod - ALIQ SUBST> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rpar_nu_aliq_icms_subst = GetDrValue<decimal>(sqlDataReader13[0]);
			rpar_nu_aliq_icm_ressarc = GetDrValue<decimal>(sqlDataReader13[1]);
			rpar_nu_modalidade_base_icms_st = GetDrValue<decimal>(sqlDataReader13[2]);
		}
		cmdText = "SELECT\r\n                                es.substrib_icms\r\n                            FROM\r\n                                estado (nolock) es\r\n                            WHERE\r\n                                es.estado = @str_estado_para";
		using (SqlCommand sqlCommand14 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand14.Parameters.Clear();
			sqlCommand14.Parameters.AddWithValue("@str_estado_para", text3);
			SqlDataReader sqlDataReader14 = sqlCommand14.ExecuteReader();
			if (!sqlDataReader14.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <estado> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rpar_boo_calc_icm_subst_trib_est = GetDrValue<bool>(sqlDataReader14[0]);
		}
		cmdText = "   SELECT\r\n                                    aliq_icm\r\n                                FROM\r\n                                    icm_est (nolock)\r\n                                WHERE\r\n                                    est_de = @str_estado_de\r\n                                AND\test_para = @str_estado_para\t\t";
		using (SqlCommand sqlCommand15 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand15.Parameters.Clear();
			sqlCommand15.Parameters.AddWithValue("@str_estado_de", text2);
			sqlCommand15.Parameters.AddWithValue("@str_estado_para", text3);
			SqlDataReader sqlDataReader15 = sqlCommand15.ExecuteReader();
			if (!sqlDataReader15.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <icm_est> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rpar_nu_aliq_icm_frete = GetDrValue<decimal>(sqlDataReader15[0]);
		}
		cmdText = "SELECT\t\r\n                            i.aliq_rest_subst_trib,\r\n                            i.aliq_repasse\r\n                        FROM\r\n                            dbo.ufnIcmProd( @par_nu_cd_emp, @par_nu_cd_prod, @str_estado_de, @str_estado_para ) i\t\r\n                        ";
		using (SqlCommand sqlCommand16 = new SqlCommand(cmdText, par_hSql))
		{
			sqlCommand16.Parameters.Clear();
			sqlCommand16.Parameters.AddWithValue("@par_nu_cd_prod", par_nu_cd_prod);
			sqlCommand16.Parameters.AddWithValue("@str_estado_de", text2);
			sqlCommand16.Parameters.AddWithValue("@str_estado_para", text3);
			sqlCommand16.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			SqlDataReader sqlDataReader16 = sqlCommand16.ExecuteReader();
			if (!sqlDataReader16.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <icm_prod - ALIQUOTA DE REPASSE E RESTITUIÇÃO> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rpar_nu_perc_icm_subst_rest = GetDrValue<decimal>(sqlDataReader16[0]);
			rpar_nu_perc_icm_subst_repasse = GetDrValue<decimal>(sqlDataReader16[1]);
		}
		if (str_global_sigla_clien == "RMD")
		{
			cmdText = "\tSELECT\r\n                                        vl_ipi \t                              \r\n                                    FROM\r\n                                        produto_custo (nolock)\r\n                                    WHERE\r\n                                        cd_prod = @par_cd_prod\r\n                                        AND tp_custo = 'CUE'\r\n                                        AND cd_emp = @par_nu_cd_emp\t";
			using SqlCommand sqlCommand17 = new SqlCommand(cmdText, par_hSql);
			sqlCommand17.Parameters.Clear();
			sqlCommand17.Parameters.AddWithValue("@par_cd_prod", par_nu_cd_prod);
			sqlCommand17.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
			SqlDataReader sqlDataReader17 = sqlCommand17.ExecuteReader();
			if (!sqlDataReader17.Read())
			{
				rpar_str_msg_erro = "SqlFetchNext - <produto_custo> - Usr_ImpostosCalcula_Venda_Busca";
				return false;
			}
			rparVlIpiCue = GetDrValue<decimal>(sqlDataReader17[0]);
		}
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_Busca_Parametros(ref bool rpar_boo_base_ipi_com_desc_geral, ref bool rpar_boo_base_icm_preco_liquido, ref bool rpar_boo_base_icm_sem_item_bonif, ref bool rpar_boo_subst_trib_apenas_ie, ref bool rpar_boo_ipi_base_icm_cad_cli, ref bool rpar_boo_bonif_fora_icm_rest, ref bool rpar_boo_subtrai_repasse_baseicm, ref bool rpar_boo_base_icm_st_sem_item_bonif, ref bool rpar_boo_preco_cheio_item_bonif, SqlConnection par_hSql, ref string rpar_str_msg_erro)
	{
		Dictionary<int, bool> rpar_boo_vt_pcfg_det = new Dictionary<int, bool>();
		if (!Usr_BuscaDadosParCfgTela("EMIS_NF", ref rpar_boo_vt_pcfg_det, par_hSql, ref rpar_str_msg_erro))
		{
			rpar_str_msg_erro += " - Usr_ImpostosCalcula_Venda_Busca";
			return false;
		}
		rpar_boo_base_ipi_com_desc_geral = rpar_boo_vt_pcfg_det[7];
		rpar_boo_subtrai_repasse_baseicm = rpar_boo_vt_pcfg_det[13];
		rpar_boo_base_icm_preco_liquido = rpar_boo_vt_pcfg_det[24];
		rpar_boo_base_icm_sem_item_bonif = rpar_boo_vt_pcfg_det[26];
		rpar_boo_subst_trib_apenas_ie = rpar_boo_vt_pcfg_det[38];
		rpar_boo_bonif_fora_icm_rest = rpar_boo_vt_pcfg_det[45];
		rpar_boo_ipi_base_icm_cad_cli = rpar_boo_vt_pcfg_det[46];
		rpar_boo_base_icm_st_sem_item_bonif = rpar_boo_vt_pcfg_det[60];
		rpar_boo_preco_cheio_item_bonif = rpar_boo_vt_pcfg_det[71];
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_PisCof(decimal par_nu_vl_base, decimal par_nu_qtde, decimal par_nu_indice, bool par_boo_pis_cof_antec, ref decimal par_nu_valor_calculado)
	{
		par_nu_valor_calculado = default(decimal);
		if (!par_boo_pis_cof_antec)
		{
			par_nu_valor_calculado = par_nu_vl_base * par_nu_indice;
		}
		return true;
	}

	private static void Usr_ImpostosCalcula_Venda_II(decimal par_nu_preco_venda, decimal par_nu_qtde, decimal par_nu_vl_frete, decimal par_nu_perc_ii, ref decimal rpar_nu_valor_calculado)
	{
		rpar_nu_valor_calculado = (par_nu_preco_venda * par_nu_qtde + par_nu_vl_frete) * par_nu_perc_ii;
	}

	private static bool Usr_ImpostosCalcula_Venda_IPI(decimal par_nu_preco_venda, decimal par_nu_vl_desc_geral, decimal par_nu_qtde, decimal par_nu_qtde_unid_est, bool par_boo_base_ipi_com_desc_geral, bool par_boo_devol_fornec, bool par_boo_papel_cortado, bool par_boo_produzido, decimal par_nu_vl_fixo_ipi_compra, decimal par_nu_aliq_ipi_compra, decimal par_nu_aliq_ipi_venda, decimal par_nu_aliq_ipi_venda_p_cortado, decimal par_nu_vl_frete, decimal par_nu_vl_ii, bool par_boo_oper_importacao, bool par_boo_calc_ipi_frete, ref decimal rpar_nu_base_ipi, ref decimal rpar_nu_valor_ipi, ref decimal rpar_nu_aliq_ipi, ref decimal rpar_nu_valor_ipi_frete)
	{
		rpar_nu_base_ipi = default(decimal);
		rpar_nu_valor_ipi = default(decimal);
		rpar_nu_aliq_ipi = default(decimal);
		rpar_nu_valor_ipi_frete = default(decimal);
		if (!par_boo_calc_ipi_frete)
		{
			par_nu_vl_frete = default(decimal);
		}
		if (par_boo_base_ipi_com_desc_geral)
		{
			rpar_nu_base_ipi = par_nu_preco_venda * par_nu_qtde - par_nu_vl_desc_geral + par_nu_vl_frete;
		}
		else
		{
			rpar_nu_base_ipi = par_nu_preco_venda * par_nu_qtde + par_nu_vl_frete;
		}
		if (par_boo_oper_importacao)
		{
			rpar_nu_base_ipi += par_nu_vl_ii;
		}
		if (par_boo_devol_fornec && par_nu_vl_fixo_ipi_compra > 0m)
		{
			rpar_nu_valor_ipi = par_nu_vl_fixo_ipi_compra * par_nu_qtde_unid_est;
			if (rpar_nu_base_ipi != 0m)
			{
				rpar_nu_aliq_ipi = rpar_nu_valor_ipi / rpar_nu_base_ipi;
			}
		}
		else if (par_boo_devol_fornec && par_nu_aliq_ipi_compra > 0m)
		{
			rpar_nu_valor_ipi = rpar_nu_base_ipi * par_nu_aliq_ipi_compra;
			rpar_nu_aliq_ipi = par_nu_aliq_ipi_compra;
		}
		else if (par_boo_papel_cortado && par_nu_aliq_ipi_venda_p_cortado > 0m)
		{
			rpar_nu_valor_ipi = rpar_nu_base_ipi * par_nu_aliq_ipi_venda_p_cortado;
			rpar_nu_aliq_ipi = par_nu_aliq_ipi_venda_p_cortado;
		}
		else if (par_nu_aliq_ipi_venda > 0m)
		{
			rpar_nu_valor_ipi = rpar_nu_base_ipi * par_nu_aliq_ipi_venda;
			rpar_nu_aliq_ipi = par_nu_aliq_ipi_venda;
		}
		else
		{
			rpar_nu_base_ipi = default(decimal);
			rpar_nu_valor_ipi = default(decimal);
			rpar_nu_aliq_ipi = default(decimal);
		}
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_ICMS(string par_str_tp_prod, string par_str_estado_origem, string par_str_estado_destino, bool par_boo_incide_icm, bool par_boo_incide_icm_subst, bool par_boo_subst_trib_sobre_cue, bool par_boo_subst_trib_sobre_cue_prod, string par_str_subst_trib_sobre_cue_prod_tp_vl, bool par_boo_base_icm_preco_liquido, bool par_boo_calc_subst_custo_cue, bool par_boo_base_icms_com_ipi, bool par_boo_imp_aliq_icm_isentos, bool par_boo_base_icms_com_ipi_frete, bool par_boo_icms_sobre_preco_cheio, bool par_boo_bonificado, bool par_boo_base_icm_sem_item_bonif, bool par_boo_base_icm_red_sobre_vl, bool par_boo_calc_subst_trib_prc_ch, ref decimal rpar_nu_aliq_icms, ref decimal rpar_nu_aliq_icms_calc_subst, decimal par_nu_qtde, decimal par_nu_qtde_est, decimal par_nu_preco_venda_cheio, decimal par_nu_preco_venda_liquido, decimal par_nu_vl_desc_geral, decimal par_nu_vl_desc_troca, decimal par_nu_vl_ipi, decimal par_nu_vl_base_produto_ps, decimal par_nu_vl_custo_cue, decimal par_nu_perc_red_base_calc_icms, decimal par_nu_vl_ipi_frete, decimal par_nu_aliq_icm_frete, decimal par_nu_vl_frete_item, decimal par_nu_vl_repasse, bool par_boo_subtrai_repasse_baseicm, bool par_boo_base_st_sem_red, decimal par_nu_vl_desc, bool par_boo_subst_red_base_icm_prop, ref decimal rpar_nu_vl_base_icms, ref decimal rpar_nu_vl_icms, ref decimal rpar_nu_base_icm_aux_subst, ref decimal rpar_nu_vl_icm_aux_subst, decimal par_nu_vl_boleto, decimal par_nu_vl_desp_aces, bool par_boo_importacao, decimal par_nu_vl_ii, decimal par_nu_vl_siscomex, decimal par_nu_vl_pis, decimal par_nu_vl_cofins, bool parBooIPIForaRedBase, decimal parNuPercMinST)
	{
		rpar_nu_vl_base_icms = default(decimal);
		rpar_nu_vl_icms = default(decimal);
		decimal num = default(decimal);
		rpar_nu_base_icm_aux_subst = default(decimal);
		rpar_nu_vl_icm_aux_subst = default(decimal);
		bool flag = false;
		if (parBooIPIForaRedBase)
		{
			flag = true;
		}
		if (!par_boo_subst_red_base_icm_prop && par_boo_incide_icm_subst)
		{
			par_nu_perc_red_base_calc_icms = default(decimal);
		}
		decimal num2 = (par_boo_base_icms_com_ipi ? par_nu_vl_ipi : 0m);
		decimal num3 = (par_boo_base_icms_com_ipi ? 0m : par_nu_vl_ipi);
		decimal num4 = (par_boo_base_icm_preco_liquido ? par_nu_vl_desc_geral : 0m);
		if (par_str_tp_prod == "PS")
		{
			if (str_global_sigla_clien == "HST" || str_global_sigla_clien == "BRM" || str_global_sigla_clien == "NAV")
			{
				rpar_nu_vl_base_icms = (par_nu_vl_base_produto_ps * par_nu_qtde - par_nu_vl_desc_troca) * 2m + par_nu_vl_frete_item + num2 - par_nu_vl_desc_geral;
			}
			else
			{
				rpar_nu_vl_base_icms = (par_nu_vl_base_produto_ps * par_nu_qtde - par_nu_vl_desc_troca) * 2m + num2 - par_nu_vl_desc_geral;
			}
			if (par_boo_subst_trib_sobre_cue && par_boo_subst_trib_sobre_cue_prod)
			{
				rpar_nu_base_icm_aux_subst = (par_nu_vl_custo_cue * par_nu_qtde_est - par_nu_vl_desc_troca) * 2m + par_nu_vl_ipi - par_nu_vl_desc_geral;
			}
			else
			{
				rpar_nu_base_icm_aux_subst = (par_nu_vl_base_produto_ps * par_nu_qtde - par_nu_vl_desc_troca) * 2m + par_nu_vl_ipi - par_nu_vl_desc_geral;
			}
		}
		else if (par_str_tp_prod == "PR" && par_boo_icms_sobre_preco_cheio)
		{
			if (str_global_sigla_clien == "HST" || str_global_sigla_clien == "BRM" || str_global_sigla_clien == "NAV")
			{
				rpar_nu_vl_base_icms = par_nu_preco_venda_cheio * par_nu_qtde + par_nu_vl_frete_item + num2 - par_nu_vl_desc_troca - num4;
			}
			else
			{
				rpar_nu_vl_base_icms = par_nu_preco_venda_cheio * par_nu_qtde + num2 - par_nu_vl_desc_troca - num4;
			}
			if (par_boo_subst_trib_sobre_cue && par_boo_subst_trib_sobre_cue_prod)
			{
				rpar_nu_base_icm_aux_subst = par_nu_vl_custo_cue * par_nu_qtde_est + par_nu_vl_ipi - par_nu_vl_desc_troca - num4;
			}
			else
			{
				rpar_nu_base_icm_aux_subst = par_nu_preco_venda_cheio * par_nu_qtde + par_nu_vl_ipi - par_nu_vl_desc_troca - num4;
			}
		}
		else if (par_str_tp_prod == "PR")
		{
			if (str_global_sigla_clien == "HST" || str_global_sigla_clien == "BRM" || str_global_sigla_clien == "NAV")
			{
				rpar_nu_vl_base_icms = par_nu_preco_venda_liquido * par_nu_qtde + par_nu_vl_frete_item + num2 - par_nu_vl_desc_troca - par_nu_vl_desc_geral;
			}
			else
			{
				rpar_nu_vl_base_icms = par_nu_preco_venda_liquido * par_nu_qtde + num2 - par_nu_vl_desc_troca - par_nu_vl_desc_geral;
			}
			if (par_boo_subst_trib_sobre_cue && par_boo_subst_trib_sobre_cue_prod)
			{
				rpar_nu_base_icm_aux_subst = par_nu_vl_custo_cue * par_nu_qtde_est + par_nu_vl_ipi - par_nu_vl_desc_troca - num4;
			}
			else if (par_boo_icms_sobre_preco_cheio)
			{
				rpar_nu_base_icm_aux_subst = par_nu_preco_venda_cheio * par_nu_qtde + par_nu_vl_ipi - par_nu_vl_desc_troca - num4;
			}
			else
			{
				rpar_nu_base_icm_aux_subst = par_nu_preco_venda_liquido * par_nu_qtde + par_nu_vl_ipi - par_nu_vl_desc_troca - par_nu_vl_desc_geral;
			}
		}
		else
		{
			rpar_nu_vl_base_icms = default(decimal);
			rpar_nu_base_icm_aux_subst = default(decimal);
		}
		if (par_boo_bonificado && par_boo_base_icm_sem_item_bonif)
		{
			rpar_nu_vl_base_icms = default(decimal);
		}
		if (par_boo_base_icms_com_ipi && par_boo_base_icms_com_ipi_frete)
		{
			rpar_nu_vl_base_icms += par_nu_vl_ipi_frete;
		}
		num = rpar_nu_vl_base_icms * (1m - par_nu_perc_red_base_calc_icms);
		if (!par_boo_base_icm_red_sobre_vl)
		{
			rpar_nu_vl_base_icms *= 1m - par_nu_perc_red_base_calc_icms;
		}
		if (par_boo_importacao)
		{
			rpar_nu_vl_base_icms = (par_nu_preco_venda_liquido * par_nu_qtde + par_nu_vl_ii + par_nu_vl_ipi + par_nu_vl_siscomex + par_nu_vl_pis + par_nu_vl_cofins) / (1m - par_nu_perc_red_base_calc_icms);
		}
		if (par_boo_base_icm_red_sobre_vl)
		{
			rpar_nu_vl_icms = decimal.Round(rpar_nu_vl_base_icms * rpar_nu_aliq_icms, 2, MidpointRounding.AwayFromZero) * (1m - par_nu_perc_red_base_calc_icms);
		}
		else
		{
			rpar_nu_vl_icms = decimal.Round(decimal.Round(rpar_nu_vl_base_icms, 2, MidpointRounding.AwayFromZero) * decimal.Round(rpar_nu_aliq_icms, 4, MidpointRounding.AwayFromZero), 2, MidpointRounding.AwayFromZero);
		}
		if (par_boo_base_icms_com_ipi && par_boo_base_icms_com_ipi_frete)
		{
			rpar_nu_vl_icms += par_nu_vl_ipi_frete * par_nu_aliq_icm_frete;
		}
		if (str_global_sigla_clien == "HST" || str_global_sigla_clien == "BRM" || str_global_sigla_clien == "NAV" || str_global_sigla_clien == "AFD")
		{
			if (par_boo_calc_subst_custo_cue && par_boo_subst_trib_sobre_cue_prod)
			{
				if (par_str_subst_trib_sobre_cue_prod_tp_vl == "VDA")
				{
					rpar_nu_vl_icm_aux_subst = decimal.Round((num + par_nu_vl_frete_item + par_nu_vl_boleto) * rpar_nu_aliq_icms_calc_subst, 2, MidpointRounding.AwayFromZero);
				}
				else if (par_str_subst_trib_sobre_cue_prod_tp_vl == "CST")
				{
					rpar_nu_vl_icm_aux_subst = decimal.Round((rpar_nu_base_icm_aux_subst + par_nu_vl_frete_item + par_nu_vl_boleto) * rpar_nu_aliq_icms_calc_subst, 2, MidpointRounding.AwayFromZero);
				}
			}
			else
			{
				rpar_nu_vl_icm_aux_subst = (rpar_nu_base_icm_aux_subst + par_nu_vl_frete_item + par_nu_vl_boleto - num3) * (rpar_nu_aliq_icms_calc_subst * (1m - par_nu_perc_red_base_calc_icms));
			}
		}
		else if (par_boo_calc_subst_custo_cue && par_boo_subst_trib_sobre_cue_prod)
		{
			if (par_str_subst_trib_sobre_cue_prod_tp_vl == "VDA")
			{
				rpar_nu_vl_icm_aux_subst = Math.Round(num * rpar_nu_aliq_icms_calc_subst, 2, MidpointRounding.AwayFromZero);
			}
			else if (par_str_subst_trib_sobre_cue_prod_tp_vl == "CST")
			{
				rpar_nu_vl_icm_aux_subst = Math.Round(rpar_nu_base_icm_aux_subst * rpar_nu_aliq_icms_calc_subst, 2, MidpointRounding.AwayFromZero);
			}
		}
		else if (par_boo_base_icms_com_ipi && parBooIPIForaRedBase)
		{
			rpar_nu_vl_icm_aux_subst = (rpar_nu_base_icm_aux_subst + par_nu_vl_ipi) * (rpar_nu_aliq_icms_calc_subst * (1m - par_nu_perc_red_base_calc_icms));
		}
		else
		{
			rpar_nu_vl_icm_aux_subst = (rpar_nu_base_icm_aux_subst - par_nu_vl_ipi * (decimal)Convert.ToInt32(!par_boo_base_icms_com_ipi) * (decimal)Convert.ToInt32(!flag)) * (rpar_nu_aliq_icms_calc_subst * (1m - par_nu_perc_red_base_calc_icms));
		}
		if (par_nu_vl_repasse > 0m && par_boo_subtrai_repasse_baseicm && (!par_boo_bonificado || !par_boo_base_icm_sem_item_bonif))
		{
			if (par_boo_icms_sobre_preco_cheio)
			{
				rpar_nu_base_icm_aux_subst -= par_nu_vl_repasse;
				rpar_nu_vl_base_icms -= par_nu_vl_repasse;
			}
			else
			{
				rpar_nu_base_icm_aux_subst = rpar_nu_base_icm_aux_subst - par_nu_vl_repasse + par_nu_vl_desc;
				rpar_nu_vl_base_icms = rpar_nu_vl_base_icms - par_nu_vl_repasse + par_nu_vl_desc;
			}
			rpar_nu_vl_icms = rpar_nu_vl_base_icms * rpar_nu_aliq_icms;
			if (!par_boo_base_st_sem_red)
			{
				rpar_nu_vl_icm_aux_subst = (rpar_nu_base_icm_aux_subst - num3) * (rpar_nu_aliq_icms * (1m - par_nu_perc_red_base_calc_icms));
			}
			else
			{
				rpar_nu_vl_icm_aux_subst = (rpar_nu_base_icm_aux_subst - num3) * rpar_nu_aliq_icms;
			}
		}
		if (!par_boo_incide_icm)
		{
			if (!par_boo_imp_aliq_icm_isentos)
			{
				rpar_nu_aliq_icms = default(decimal);
			}
			rpar_nu_vl_base_icms = default(decimal);
			rpar_nu_vl_icms = default(decimal);
		}
		if (rpar_nu_vl_base_icms < 0m)
		{
			rpar_nu_vl_base_icms = default(decimal);
		}
		if (rpar_nu_vl_icms < 0m)
		{
			rpar_nu_vl_icms = default(decimal);
		}
		if (rpar_nu_base_icm_aux_subst < 0m)
		{
			rpar_nu_base_icm_aux_subst = default(decimal);
		}
		if (rpar_nu_vl_icm_aux_subst < 0m)
		{
			rpar_nu_vl_icm_aux_subst = default(decimal);
		}
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_STrib(string par_str_tp_prod, string par_str_tp_inscricao, string par_str_cd_sit_trib_excecao, bool par_boo_incide_icm_subst, bool par_boo_isento_subst_trib, bool par_boo_subst_trib_apenas_ie, bool par_boo_calc_icm_subst_trib_est, bool par_boo_calc_subst_trib_prc_ch, bool par_boo_subst_trib_sobre_cue, bool par_boo_subst_trib_sobre_cue_prod, string par_str_subst_trib_sobre_cue_prod_tp_vl, bool par_boo_base_icm_s_trib_sem_red, bool par_boo_prc_max_consum, bool par_boo_calc_subst_trib_pmc, bool par_boo_calc_repasse, bool par_boo_strib_sem_credito_icm, decimal par_nu_preco_venda_cheio, decimal par_nu_vl_custo_cue, decimal par_nu_qtde, decimal par_nu_qtde_est, decimal par_nu_aliq_icms_subst, decimal par_nu_aliq_icms_subst_pmc, decimal par_nu_vl_icm, decimal par_nu_vl_icm_aux_subst, decimal par_nu_base_icm_aux_subst, decimal par_nu_perc_margem_subs, decimal par_nu_perc_red_margem_subst, decimal par_nu_perc_red_base_calc_icms, decimal par_nu_preco_max_cons, decimal par_nu_desc_gov, decimal par_nu_red_subst_trib_pmc, ref decimal rpar_nu_vl_base_icm_subst, ref decimal rpar_nu_vl_icm_subst, decimal par_nu_vl_frete_item, bool par_boo_base_icm_st_sem_item_bonif, bool par_boo_bonificado, decimal par_nu_vl_boleto, bool booRedBaseIcmStDifIcmNormal, decimal parNuVlIpiCue, bool parBooUtilizaPrcMax2, decimal parNuPercMinST, bool pbooConsumidorFinal, bool pbooCalculoICMSSTConvenio52, string pstrTipoValorPreferencialBaseST)
	{
		decimal num = default(decimal);
		rpar_nu_vl_base_icm_subst = default(decimal);
		rpar_nu_vl_icm_subst = default(decimal);
		if (str_global_sigla_clien == "RMD")
		{
			if (par_boo_subst_trib_sobre_cue_prod || par_str_subst_trib_sobre_cue_prod_tp_vl == "CST")
			{
				par_nu_base_icm_aux_subst += parNuVlIpiCue * par_nu_qtde_est;
			}
			if (par_nu_red_subst_trib_pmc > 0m)
			{
				par_nu_perc_red_base_calc_icms = par_nu_red_subst_trib_pmc;
			}
		}
		num = (par_boo_base_icm_s_trib_sem_red ? default(decimal) : ((!booRedBaseIcmStDifIcmNormal) ? par_nu_perc_red_base_calc_icms : par_nu_red_subst_trib_pmc));
		if (!(par_boo_incide_icm_subst && (!par_boo_isento_subst_trib || (par_boo_isento_subst_trib && (par_str_cd_sit_trib_excecao != string.Empty || par_str_cd_sit_trib_excecao.Trim() != ""))) && (par_str_tp_inscricao == "E" || (par_str_tp_inscricao != "E" && !par_boo_subst_trib_apenas_ie)) && par_boo_calc_icm_subst_trib_est))
		{
			return true;
		}
		if (pbooCalculoICMSSTConvenio52 && pbooConsumidorFinal)
		{
			par_nu_perc_margem_subs = default(decimal);
		}
		decimal num2 = ((par_str_tp_prod == "PR" || boo_global_subst_trib_maior_valor) ? 1m : ((!(par_str_tp_prod == "PS")) ? default(decimal) : decimal.Parse("0.35")));
		if (par_boo_calc_subst_trib_prc_ch && !par_boo_calc_repasse)
		{
			if (boo_global_subst_trib_maior_valor)
			{
				if (par_nu_vl_custo_cue > par_nu_preco_venda_cheio)
				{
					rpar_nu_vl_base_icm_subst = (par_nu_vl_custo_cue * par_nu_qtde + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m + par_nu_perc_margem_subs) * (1m - par_nu_perc_red_margem_subst) * num2;
				}
				else
				{
					rpar_nu_vl_base_icm_subst = (par_nu_preco_venda_cheio * par_nu_qtde + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m + par_nu_perc_margem_subs) * (1m - par_nu_perc_red_margem_subst) * num2;
				}
			}
			else if (par_boo_subst_trib_sobre_cue && par_boo_subst_trib_sobre_cue_prod)
			{
				if (par_str_subst_trib_sobre_cue_prod_tp_vl == "VDA")
				{
					rpar_nu_vl_base_icm_subst = (par_nu_preco_venda_cheio * par_nu_qtde + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m + par_nu_perc_margem_subs) * (1m - par_nu_perc_red_margem_subst) * num2;
				}
				else if (par_str_subst_trib_sobre_cue_prod_tp_vl == "CST")
				{
					rpar_nu_vl_base_icm_subst = (par_nu_vl_custo_cue * par_nu_qtde_est + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m + par_nu_perc_margem_subs) * (1m - par_nu_perc_red_margem_subst) * num2;
				}
			}
			else
			{
				rpar_nu_vl_base_icm_subst = (par_nu_preco_venda_cheio * par_nu_qtde + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m + par_nu_perc_margem_subs) * (1m - par_nu_perc_red_margem_subst) * num2;
			}
		}
		else if (!par_boo_base_icm_s_trib_sem_red && !boo_global_subst_trib_maior_valor)
		{
			if (booRedBaseIcmStDifIcmNormal)
			{
				rpar_nu_vl_base_icm_subst = (par_nu_base_icm_aux_subst + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m - par_nu_red_subst_trib_pmc) * (1m + par_nu_perc_margem_subs * (1m - par_nu_perc_red_margem_subst)) * num2;
			}
			else
			{
				rpar_nu_vl_base_icm_subst = (par_nu_base_icm_aux_subst + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m - par_nu_perc_red_base_calc_icms) * (1m + par_nu_perc_margem_subs * (1m - par_nu_perc_red_margem_subst)) * num2;
			}
		}
		else
		{
			rpar_nu_vl_base_icm_subst = (par_nu_base_icm_aux_subst + par_nu_vl_frete_item + par_nu_vl_boleto) * (1m + par_nu_perc_margem_subs * (1m - par_nu_perc_red_margem_subst)) * num2;
		}
		if (pbooCalculoICMSSTConvenio52)
		{
			rpar_nu_vl_base_icm_subst = (rpar_nu_vl_base_icm_subst - par_nu_vl_icm_aux_subst) / (1m - par_nu_aliq_icms_subst);
		}
		if (par_boo_strib_sem_credito_icm)
		{
			rpar_nu_vl_icm_subst = rpar_nu_vl_base_icm_subst * par_nu_aliq_icms_subst;
		}
		else
		{
			rpar_nu_vl_icm_subst = rpar_nu_vl_base_icm_subst * par_nu_aliq_icms_subst - par_nu_vl_icm_aux_subst;
		}
		if (par_boo_prc_max_consum && par_boo_calc_subst_trib_pmc && par_nu_preco_max_cons > 0m && !par_boo_isento_subst_trib && (!(pstrTipoValorPreferencialBaseST == "MVA") || !(par_nu_perc_margem_subs > 0m)))
		{
			decimal num3 = ((!parBooUtilizaPrcMax2) ? ((par_nu_preco_max_cons * par_nu_qtde_est + par_nu_vl_frete_item) * (1m - par_nu_desc_gov) * (1m - num)) : (par_nu_preco_max_cons * par_nu_qtde_est + par_nu_vl_frete_item));
			if (num3 < 0m || num3 == 0m)
			{
				num3 = default(decimal);
			}
			if (pbooCalculoICMSSTConvenio52)
			{
				num3 = (num3 - par_nu_vl_icm_aux_subst) / (1m - par_nu_aliq_icms_subst);
			}
			decimal num4 = num3 * par_nu_aliq_icms_subst_pmc - par_nu_vl_icm_aux_subst;
			if (boo_global_subst_trib_maior_valor)
			{
				if (num4 > rpar_nu_vl_icm_subst)
				{
					rpar_nu_vl_base_icm_subst = num3;
					rpar_nu_vl_icm_subst = num4;
				}
			}
			else
			{
				rpar_nu_vl_base_icm_subst = num3;
				rpar_nu_vl_icm_subst = num4;
			}
		}
		if (rpar_nu_vl_icm_subst < 0m || rpar_nu_vl_icm_subst == 0m)
		{
			rpar_nu_vl_icm_subst = default(decimal);
		}
		if (!par_boo_base_icm_st_sem_item_bonif && par_boo_bonificado)
		{
			rpar_nu_vl_base_icm_subst = default(decimal);
			rpar_nu_vl_icm_subst = default(decimal);
		}
		if (parNuPercMinST > 0m && rpar_nu_vl_base_icm_subst != 0m)
		{
			if (rpar_nu_vl_icm_subst == 0m)
			{
				rpar_nu_vl_icm_subst = parNuPercMinST * rpar_nu_vl_base_icm_subst;
			}
			else if (rpar_nu_vl_icm_subst / rpar_nu_vl_base_icm_subst < parNuPercMinST)
			{
				rpar_nu_vl_icm_subst = parNuPercMinST * rpar_nu_vl_base_icm_subst;
			}
		}
		if (stAdicItem && par_nu_qtde_est > 0m)
		{
			rpar_nu_vl_icm_subst = Math.Round(rpar_nu_vl_icm_subst / par_nu_qtde_est, 2, MidpointRounding.AwayFromZero) * par_nu_qtde_est;
		}
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_Ressar(bool par_boo_utiliza_ressarc_icm, bool par_boo_bonificado, bool par_boo_calc_icm_ressarc_bonif, bool par_boo_icm_ressarc_preco_cheio, bool par_boo_icm_ressarc_pmc, bool par_boo_calc_subst_custo_cue, bool par_boo_calc_subst_custo_cue_prod, decimal par_nu_preco_venda_cheio, decimal par_nu_preco_venda_liquido, decimal par_nu_preco_max_cons, decimal par_nu_aliq_icm_ressarc, decimal par_nu_aliq_icm_subs, decimal par_nu_aliq_icm, decimal par_nu_vl_custo_cue, decimal par_nu_vl_desc_geral, decimal par_nu_qtde, decimal par_nu_qtde_est, decimal par_nu_perc_margem_subst, decimal par_nu_perc_red_margem_subst, decimal par_nu_desc_gov, decimal par_nu_subst_pmc_red_base, string par_str_tp_prod, ref decimal rpar_nu_vl_base_icm_ressarc, ref decimal rpar_nu_vl_icm_ressarc)
	{
		rpar_nu_vl_base_icm_ressarc = default(decimal);
		rpar_nu_vl_icm_ressarc = default(decimal);
		if (!par_boo_utiliza_ressarc_icm || !(par_nu_aliq_icm_ressarc != 0m) || !(par_nu_aliq_icm_ressarc != 0m) || (par_boo_bonificado && !par_boo_calc_icm_ressarc_bonif))
		{
			return true;
		}
		decimal num = ((par_str_tp_prod == "PR") ? 1m : ((!(par_str_tp_prod == "PS")) ? default(decimal) : decimal.Parse("0.35")));
		if (par_boo_icm_ressarc_preco_cheio && par_boo_calc_subst_custo_cue && par_boo_calc_subst_custo_cue_prod)
		{
			rpar_nu_vl_base_icm_ressarc = par_nu_vl_custo_cue * par_nu_qtde * (1m + par_nu_perc_margem_subst) * (1m - par_nu_perc_red_margem_subst) * num;
			decimal num2 = ((!(par_nu_preco_venda_cheio != 0m)) ? default(decimal) : (1m - par_nu_preco_venda_liquido / par_nu_preco_venda_cheio));
			rpar_nu_vl_icm_ressarc = rpar_nu_vl_base_icm_ressarc * par_nu_aliq_icm_subs - (par_nu_vl_custo_cue * par_nu_qtde * (1m - num2) - par_nu_vl_desc_geral) * par_nu_aliq_icm_ressarc;
		}
		else if (par_boo_icm_ressarc_preco_cheio && !par_boo_calc_subst_custo_cue)
		{
			rpar_nu_vl_base_icm_ressarc = par_nu_preco_venda_cheio * par_nu_qtde * (1m + par_nu_perc_margem_subst) * (1m - par_nu_perc_red_margem_subst) * num;
			rpar_nu_vl_icm_ressarc = rpar_nu_vl_base_icm_ressarc * par_nu_aliq_icm_subs - (par_nu_preco_venda_liquido * par_nu_qtde - par_nu_vl_desc_geral) * par_nu_aliq_icm_ressarc;
		}
		else if (par_boo_icm_ressarc_pmc)
		{
			if (par_nu_qtde_est != 0m)
			{
				rpar_nu_vl_base_icm_ressarc = par_nu_preco_max_cons * (1m - par_nu_desc_gov) * (1m - par_nu_subst_pmc_red_base) * par_nu_aliq_icm_ressarc;
				rpar_nu_vl_icm_ressarc = rpar_nu_vl_base_icm_ressarc - par_nu_preco_venda_liquido / par_nu_qtde_est * par_nu_aliq_icm;
			}
			else
			{
				rpar_nu_vl_base_icm_ressarc = default(decimal);
				rpar_nu_vl_icm_ressarc = default(decimal);
			}
			rpar_nu_vl_base_icm_ressarc *= par_nu_qtde_est;
			rpar_nu_vl_icm_ressarc *= par_nu_qtde_est;
		}
		else
		{
			rpar_nu_vl_base_icm_ressarc = (par_nu_preco_venda_liquido * par_nu_qtde - par_nu_vl_desc_geral) * (1m + par_nu_perc_margem_subst) * (1m - par_nu_perc_red_margem_subst) * num;
			rpar_nu_vl_icm_ressarc = rpar_nu_vl_base_icm_ressarc * par_nu_aliq_icm_subs - (par_nu_preco_venda_liquido * par_nu_qtde - par_nu_vl_desc_geral) * par_nu_aliq_icm_ressarc;
		}
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_Adic_NF(decimal par_nu_perc_adicional_nf, decimal par_nu_qtde, decimal par_nu_qtde_est, decimal par_nu_vl_venda, decimal par_nu_vl_custo_cue, bool par_boo_calc_subst_custo_cue, bool par_boo_calc_subst_custo_cue_prod, ref decimal rpar_nu_vl_adic_nf)
	{
		rpar_nu_vl_adic_nf = default(decimal);
		if (par_nu_perc_adicional_nf < 0m)
		{
			return true;
		}
		decimal num = ((!(par_boo_calc_subst_custo_cue && par_boo_calc_subst_custo_cue_prod)) ? (par_nu_vl_venda * par_nu_qtde) : (par_nu_vl_custo_cue * par_nu_qtde_est));
		rpar_nu_vl_adic_nf = num * par_nu_perc_adicional_nf;
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_Restit(decimal par_nu_qtde, decimal par_nu_qtde_est, decimal par_nu_preco_cheio, decimal par_nu_vl_custo_cue, bool par_calc_subst_custo_cue, bool par_calc_subst_custo_cue_prod, decimal par_nu_vl_icm_repasse, bool par_boo_bonificado, decimal par_nu_perc_icm_subst_rest, bool par_boo_bonif_fora_icm_rest, ref decimal rpar_nu_base_icm_subst_rest, ref decimal rpar_nu_vl_icm_subst_rest)
	{
		rpar_nu_base_icm_subst_rest = default(decimal);
		rpar_nu_vl_icm_subst_rest = default(decimal);
		if (!(par_nu_perc_icm_subst_rest > 0m) || !(par_nu_vl_icm_repasse == 0m) || (par_boo_bonificado && par_boo_bonif_fora_icm_rest))
		{
			rpar_nu_base_icm_subst_rest = default(decimal);
			rpar_nu_vl_icm_subst_rest = default(decimal);
			return true;
		}
		if (par_calc_subst_custo_cue && par_calc_subst_custo_cue_prod)
		{
			rpar_nu_base_icm_subst_rest = par_nu_vl_custo_cue * par_nu_qtde_est;
		}
		else
		{
			rpar_nu_base_icm_subst_rest = par_nu_preco_cheio * par_nu_qtde;
		}
		rpar_nu_vl_icm_subst_rest = rpar_nu_base_icm_subst_rest * par_nu_perc_icm_subst_rest;
		return true;
	}

	private static bool Usr_ImpostosCalcula_Venda_Repass(bool par_boo_calc_repasse, decimal par_nu_perc_repasse, decimal par_nu_qtde, decimal par_nu_qtde_est, decimal par_nu_vl_venda, decimal par_nu_vl_custo_cue, bool par_boo_calc_subst_custo_cue, bool par_boo_calc_subst_custo_cue_prod, ref decimal rpar_nu_base_icm_repasse, ref decimal rpar_nu_vl_icm_repasse)
	{
		rpar_nu_base_icm_repasse = default(decimal);
		rpar_nu_vl_icm_repasse = default(decimal);
		if (!(par_nu_perc_repasse > 0m && par_boo_calc_repasse))
		{
			return true;
		}
		if (par_boo_calc_subst_custo_cue && par_boo_calc_subst_custo_cue_prod)
		{
			rpar_nu_base_icm_repasse = par_nu_vl_custo_cue * par_nu_qtde_est;
		}
		else
		{
			rpar_nu_base_icm_repasse = par_nu_vl_venda * par_nu_qtde;
		}
		rpar_nu_vl_icm_repasse = rpar_nu_base_icm_repasse * par_nu_perc_repasse;
		return true;
	}

	private static string Usr_ImpostosRetornaCdSitTrib(string par_str_trib_tp_sit_trib, bool par_boo_dev_fornec, bool par_boo_sit_trib_esp_tp_ped)
	{
		if (par_boo_dev_fornec)
		{
			return "cd_sit_trib_compra";
		}
		if (par_str_trib_tp_sit_trib == "PDR")
		{
			return "cd_sit_trib";
		}
		if (par_str_trib_tp_sit_trib == "ESP" && !boo_global_utiliza_sit_trib_esp_tp_ped)
		{
			return "cd_sit_trib_esp";
		}
		if (par_str_trib_tp_sit_trib == "ESP" && boo_global_utiliza_sit_trib_esp_tp_ped && par_boo_sit_trib_esp_tp_ped)
		{
			return "cd_sit_trib_esp";
		}
		if (par_str_trib_tp_sit_trib == "RES")
		{
			return "cd_sit_trib_red_esp";
		}
		if (par_str_trib_tp_sit_trib == "EXC")
		{
			return "cd_sit_trib_excecao";
		}
		return "cd_sit_trib";
	}

	private static string Usr_ImpostosRetornaRedBaseICMS(string par_str_trib_tp_red_icms, string par_str_alias)
	{
		return par_str_trib_tp_red_icms switch
		{
			"PDR" => par_str_alias + ".perc_red_baseicm", 
			"ESP" => par_str_alias + ".perc_red_baseicm_esp", 
			"SRE" => "0.0", 
			_ => par_str_alias + ".perc_red_baseicm", 
		};
	}

	private static bool Usr_ImpostosCalcula_Venda_SimplesNacional(int par_nu_cd_emp, ref bool rpar_boo_empresa_sn, ref decimal rpar_nu_aliq_cred_icms_sn, SqlConnection par_hSql, ref string rpar_str_msg_erro)
	{
		rpar_boo_empresa_sn = false;
		string cmdText = " SELECT\r\n                                        e.icms_simpnac\r\n                                    FROM\r\n                                        empresa e,\r\n                                        tributacao_regime t\r\n                                    WHERE\r\n                                        e.cd_emp = @par_nu_cd_emp\r\n                                    AND e.seq_tributacao_regime = t.seq_tributacao_regime\r\n                                    AND t.simples_nacional = 1\t";
		using SqlCommand sqlCommand = new SqlCommand(cmdText, par_hSql);
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@par_nu_cd_emp", par_nu_cd_emp);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.Read())
		{
			decimal drValue = GetDrValue<decimal>(sqlDataReader[0]);
			rpar_boo_empresa_sn = true;
			rpar_nu_aliq_cred_icms_sn = drValue;
			return true;
		}
		return true;
	}

	private static T GetDrValue<T>(object value) where T : IConvertible
	{
		if (value == null || Convert.IsDBNull(value))
		{
			if (typeof(T) == typeof(string))
			{
				return (T)Convert.ChangeType(string.Empty, typeof(T), CultureInfo.InvariantCulture);
			}
			return default(T);
		}
		return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
	}
}
