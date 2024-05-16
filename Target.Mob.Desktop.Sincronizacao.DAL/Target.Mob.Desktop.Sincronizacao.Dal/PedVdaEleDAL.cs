using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class PedVdaEleDAL
{
	private const string INSERT = "uspPedVdaEleInsert";

	private const string UPDATE = "uspPedVdaEleUpdate";

	private const string DELETE = "uspPedVdaEleDelete";

	private const string SELECT = "uspPedVdaEleSelect";

	private const string EXISTS = "uspPedVdaEleExists";

	private const string COUNT = "uspPedVdaEleCount";

	private const string ATDPND = "uspPedVdaEleAtendimentoPendente";

	private const string ATDPNDA = "uspPedVdaEleAtendimentoPendencia";

	private const string ATDSET = "uspPedVdaEleSetAtendimentoEnviado";

	private const string LIBPND = "uspPedVdaEleLiberacaoPendencia";

	public static void Insert(DbConnection connection, PedVdaEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@nu_ped_cli", instance.NuPedCli);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@nu_ped", instance.NuPed);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@per_desc_fin", instance.PerDescFin);
		connection.AddParameters("@vl_desc_fin", instance.VlDescFin);
		connection.AddParameters("@nu_dias_desc_fin", instance.NuDiasDescFin);
		connection.AddParameters("@tp_estab", instance.RetornaTpEstab());
		connection.AddParameters("@tp_ped", instance.TpPed);
		connection.AddParameters("@dt_ped", instance.DtPed);
		connection.AddParameters("@cd_tabela", instance.CdTabela);
		connection.AddParameters("@seq_prom", instance.SeqProm);
		connection.AddParameters("@formpgto", instance.Formpgto);
		connection.AddParameters("@vl_frete", instance.VlFrete);
		connection.AddParameters("@valor_tot", instance.ValorTot);
		connection.AddParameters("@tp_midia", instance.TpMidia);
		connection.AddParameters("@tp_entrega", instance.RetornaTpEntrega());
		connection.AddParameters("@cd_forn", instance.CdForn);
		connection.AddParameters("@tp_frete", instance.RetornaTpFrete());
		connection.AddParameters("@dt_entrega", instance.DtEntrega);
		connection.AddParameters("@situacao", instance.RetornaSituacao());
		connection.AddParameters("@prom_padr_cli", instance.PromPadrCli);
		if (instance.DtPrevFatu.HasValue)
		{
			connection.AddParameters("@dt_prev_fatu", new DateTime(instance.DtPrevFatu.Value.Year, instance.DtPrevFatu.Value.Month, instance.DtPrevFatu.Value.Day));
		}
		else
		{
			connection.AddParameters("@dt_prev_fatu", null);
		}
		connection.AddParameters("@perc_desc_geral", instance.PercDescGeral);
		connection.AddParameters("@vl_desc_geral", instance.VlDescGeral);
		connection.AddParameters("@origem_pedido", instance.RetornaOrigemPedido());
		connection.AddParameters("@nu_ped_palm", instance.NuPedPalm);
		connection.AddParameters("@sem_estoque", instance.SemEstoque);
		connection.AddParameters("@nu_nf", instance.NuNf);
		connection.AddParameters("@nu_nf_emp_fat", instance.NuNfEmpFat);
		connection.AddParameters("@desc_cfop", instance.DescCfop);
		connection.AddParameters("@desc_nat_oper", instance.DescNatOper);
		connection.AddParameters("@imp_via_sp", instance.ImpViaSp);
		connection.AddParameters("@tp_imp_sp", instance.TpImpSp);
		connection.AddParameters("@nf_canc", instance.NfCanc);
		connection.AddParameters("@cd_int_ped_ele", instance.CdIntPedEle);
		connection.AddParameters("@card_cred_numero", instance.CardCredNumero);
		connection.AddParameters("@card_cred_proprietario", instance.CardCredProprietario);
		connection.AddParameters("@card_cred_tipo", instance.CardCredTipo);
		connection.AddParameters("@card_cred_complemento", instance.CardCredComplemento);
		connection.AddParameters("@card_cred_dt_expiracao_mes", instance.CardCredDtExpiracaoMes);
		connection.AddParameters("@card_cred_dt_expiracao_ano", instance.CardCredDtExpiracaoAno);
		connection.AddParameters("@card_cred_cpf_proprietario", instance.CardCredCpfProprietario);
		connection.AddParameters("@cd_intpededi", instance.CdIntpededi);
		connection.AddParameters("@idOrder_Vertis", instance.IdOrderVertis);
		connection.AddParameters("@vertis_ped_finalizado", instance.VertisPedFinalizado);
		connection.AddParameters("@mantem_vl_frete_pedv_ele", instance.MantemVlFretePedvEle);
		connection.AddParameters("@mantem_vl_desc_ger_pedv_ele", instance.MantemVlDescGerPedvEle);
		connection.AddParameters("@pedido_direto", instance.PedidoDireto);
		connection.AddParameters("@proposta_vda", instance.PropostaVda);
		connection.AddParameters("@pend_ele_libera_auto", instance.PendEleLiberaAuto);
		connection.AddParameters("@nome_entrega", instance.NomeEntrega);
		connection.AddParameters("@liberacao_automatica", instance.LiberacaoAutomatica);
		connection.AddParameters("@atendimento_enviado", instance.AtendimentoEnviado);
		connection.AddParameters("@CdClienOutCli", instance.CodigoEntregaOutroCliente);
		connection.AddParameters("@cdClienAtacadista", instance.cdClienAtacadista);
		connection.AddParameters("@cdClienFatura", instance.cdClienFatura);
		connection.AddParameters("@cdClienPagamento", instance.cdClienPagamento);
		connection.AddParameters("@SeqTroca", instance.SeqTroca);
		connection.AddParameters("@cdComoRealizouVenda", instance.cdComoRealizouVenda);
		connection.AddParameters("@TextoComoRealizouVenda", instance.TextoComoRealizouVenda);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspPedVdaEleInsert");
	}

	public static void Update(DbConnection connection, PedVdaEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@nu_ped_cli", instance.NuPedCli);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@nu_ped", instance.NuPed);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@per_desc_fin", instance.PerDescFin);
		connection.AddParameters("@vl_desc_fin", instance.VlDescFin);
		connection.AddParameters("@nu_dias_desc_fin", instance.NuDiasDescFin);
		connection.AddParameters("@tp_estab", instance.RetornaTpEstab());
		connection.AddParameters("@tp_ped", instance.TpPed);
		connection.AddParameters("@dt_ped", instance.DtPed);
		connection.AddParameters("@cd_tabela", instance.CdTabela);
		connection.AddParameters("@seq_prom", instance.SeqProm);
		connection.AddParameters("@formpgto", instance.Formpgto);
		connection.AddParameters("@vl_frete", instance.VlFrete);
		connection.AddParameters("@valor_tot", instance.ValorTot);
		connection.AddParameters("@tp_midia", instance.TpMidia);
		connection.AddParameters("@tp_entrega", instance.RetornaTpEntrega());
		connection.AddParameters("@cd_forn", instance.CdForn);
		connection.AddParameters("@tp_frete", instance.RetornaTpFrete());
		connection.AddParameters("@dt_entrega", instance.DtEntrega);
		connection.AddParameters("@situacao", instance.RetornaSituacao());
		connection.AddParameters("@prom_padr_cli", instance.PromPadrCli);
		connection.AddParameters("@dt_prev_fatu", instance.DtPrevFatu);
		connection.AddParameters("@perc_desc_geral", instance.PercDescGeral);
		connection.AddParameters("@vl_desc_geral", instance.VlDescGeral);
		connection.AddParameters("@origem_pedido", instance.RetornaOrigemPedido());
		connection.AddParameters("@nu_ped_palm", instance.NuPedPalm);
		connection.AddParameters("@sem_estoque", instance.SemEstoque);
		connection.AddParameters("@nu_nf", instance.NuNf);
		connection.AddParameters("@nu_nf_emp_fat", instance.NuNfEmpFat);
		connection.AddParameters("@desc_cfop", instance.DescCfop);
		connection.AddParameters("@desc_nat_oper", instance.DescNatOper);
		connection.AddParameters("@imp_via_sp", instance.ImpViaSp);
		connection.AddParameters("@tp_imp_sp", instance.TpImpSp);
		connection.AddParameters("@nf_canc", instance.NfCanc);
		connection.AddParameters("@cd_int_ped_ele", instance.CdIntPedEle);
		connection.AddParameters("@card_cred_numero", instance.CardCredNumero);
		connection.AddParameters("@card_cred_proprietario", instance.CardCredProprietario);
		connection.AddParameters("@card_cred_tipo", instance.CardCredTipo);
		connection.AddParameters("@card_cred_complemento", instance.CardCredComplemento);
		connection.AddParameters("@card_cred_dt_expiracao_mes", instance.CardCredDtExpiracaoMes);
		connection.AddParameters("@card_cred_dt_expiracao_ano", instance.CardCredDtExpiracaoAno);
		connection.AddParameters("@card_cred_cpf_proprietario", instance.CardCredCpfProprietario);
		connection.AddParameters("@cd_intpededi", instance.CdIntpededi);
		connection.AddParameters("@idOrder_Vertis", instance.IdOrderVertis);
		connection.AddParameters("@vertis_ped_finalizado", instance.VertisPedFinalizado);
		connection.AddParameters("@mantem_vl_frete_pedv_ele", instance.MantemVlFretePedvEle);
		connection.AddParameters("@mantem_vl_desc_ger_pedv_ele", instance.MantemVlDescGerPedvEle);
		connection.AddParameters("@pedido_direto", instance.PedidoDireto);
		connection.AddParameters("@proposta_vda", instance.PropostaVda);
		connection.AddParameters("@pend_ele_libera_auto", instance.PendEleLiberaAuto);
		connection.AddParameters("@nome_entrega", instance.NomeEntrega);
		connection.AddParameters("@liberacao_automatica", instance.LiberacaoAutomatica);
		connection.AddParameters("@atendimento_enviado", instance.AtendimentoEnviado);
		connection.AddParameters("@CdClienOutCli", instance.CodigoEntregaOutroCliente);
		connection.AddParameters("@cdClienAtacadista", instance.cdClienAtacadista);
		connection.AddParameters("@cdClienFatura", instance.cdClienFatura);
		connection.AddParameters("@cdClienPagamento", instance.cdClienPagamento);
		connection.AddParameters("@SeqTroca", instance.SeqTroca);
		connection.AddParameters("@cdComoRealizouVenda", instance.cdComoRealizouVenda);
		connection.AddParameters("@TextoComoRealizouVenda", instance.TextoComoRealizouVenda);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPedVdaEleUpdate");
	}

	public static void Delete(DbConnection connection, PedVdaEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPedVdaEleDelete");
	}

	public static PedVdaEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		return Select(connection, CdEmpEle, NuPedEle, SeqPed, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static PedVdaEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, string NuPedCli, int? CdEmp, int? NuPed, string CdVend, int? CdClien, decimal? PerDescFin, decimal? VlDescFin, decimal? NuDiasDescFin, string TpEstab, string TpPed, DateTime? DtPed, string CdTabela, int? SeqProm, string Formpgto, decimal? VlFrete, decimal? ValorTot, string TpMidia, string TpEntrega, int? CdForn, string TpFrete, DateTime? DtEntrega, string Situacao, int? PromPadrCli, DateTime? DtPrevFatu, decimal? PercDescGeral, decimal? VlDescGeral, string OrigemPedido, string NuPedPalm, int? SemEstoque, int? NuNf, int? NuNfEmpFat, string DescCfop, string DescNatOper, int? ImpViaSp, string TpImpSp, int? NfCanc, string CdIntPedEle, string CardCredNumero, string CardCredProprietario, string CardCredTipo, string CardCredComplemento, string CardCredDtExpiracaoMes, string CardCredDtExpiracaoAno, string CardCredCpfProprietario, string CdIntpededi, int? IdOrderVertis, int? VertisPedFinalizado, int? MantemVlFretePedvEle, int? MantemVlDescGerPedvEle, int? PedidoDireto, bool? PropostaVda, bool? PendEleLiberaAuto, string NomeEntrega, bool? LiberacaoAutomatica, bool? AtendimentoEnviado, int? CodigoEntregaOutroCliente, int? SeqTroca, int? cdClienAtacadista, int? cdClienFatura, int? cdClienPagamento, int? cdComoRealizouVenda, string TextoComoRealizouVenda)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@nu_ped_cli", NuPedCli);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@nu_ped", NuPed);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@per_desc_fin", PerDescFin);
		connection.AddParameters("@vl_desc_fin", VlDescFin);
		connection.AddParameters("@nu_dias_desc_fin", NuDiasDescFin);
		connection.AddParameters("@tp_estab", TpEstab);
		connection.AddParameters("@tp_ped", TpPed);
		connection.AddParameters("@dt_ped", DtPed);
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@seq_prom", SeqProm);
		connection.AddParameters("@formpgto", Formpgto);
		connection.AddParameters("@vl_frete", VlFrete);
		connection.AddParameters("@valor_tot", ValorTot);
		connection.AddParameters("@tp_midia", TpMidia);
		connection.AddParameters("@tp_entrega", TpEntrega);
		connection.AddParameters("@cd_forn", CdForn);
		connection.AddParameters("@tp_frete", TpFrete);
		connection.AddParameters("@dt_entrega", DtEntrega);
		connection.AddParameters("@situacao", Situacao);
		connection.AddParameters("@prom_padr_cli", PromPadrCli);
		connection.AddParameters("@dt_prev_fatu", DtPrevFatu);
		connection.AddParameters("@perc_desc_geral", PercDescGeral);
		connection.AddParameters("@vl_desc_geral", VlDescGeral);
		connection.AddParameters("@origem_pedido", OrigemPedido);
		connection.AddParameters("@nu_ped_palm", NuPedPalm);
		connection.AddParameters("@sem_estoque", SemEstoque);
		connection.AddParameters("@nu_nf", NuNf);
		connection.AddParameters("@nu_nf_emp_fat", NuNfEmpFat);
		connection.AddParameters("@desc_cfop", DescCfop);
		connection.AddParameters("@desc_nat_oper", DescNatOper);
		connection.AddParameters("@imp_via_sp", ImpViaSp);
		connection.AddParameters("@tp_imp_sp", TpImpSp);
		connection.AddParameters("@nf_canc", NfCanc);
		connection.AddParameters("@cd_int_ped_ele", CdIntPedEle);
		connection.AddParameters("@card_cred_numero", CardCredNumero);
		connection.AddParameters("@card_cred_proprietario", CardCredProprietario);
		connection.AddParameters("@card_cred_tipo", CardCredTipo);
		connection.AddParameters("@card_cred_complemento", CardCredComplemento);
		connection.AddParameters("@card_cred_dt_expiracao_mes", CardCredDtExpiracaoMes);
		connection.AddParameters("@card_cred_dt_expiracao_ano", CardCredDtExpiracaoAno);
		connection.AddParameters("@card_cred_cpf_proprietario", CardCredCpfProprietario);
		connection.AddParameters("@cd_intpededi", CdIntpededi);
		connection.AddParameters("@idOrder_Vertis", IdOrderVertis);
		connection.AddParameters("@vertis_ped_finalizado", VertisPedFinalizado);
		connection.AddParameters("@mantem_vl_frete_pedv_ele", MantemVlFretePedvEle);
		connection.AddParameters("@mantem_vl_desc_ger_pedv_ele", MantemVlDescGerPedvEle);
		connection.AddParameters("@pedido_direto", PedidoDireto);
		connection.AddParameters("@proposta_vda", PropostaVda);
		connection.AddParameters("@pend_ele_libera_auto", PendEleLiberaAuto);
		connection.AddParameters("@nome_entrega", NomeEntrega);
		connection.AddParameters("@liberacao_automatica", LiberacaoAutomatica);
		connection.AddParameters("@atendimento_enviado", AtendimentoEnviado);
		connection.AddParameters("@CdClienOutCli", CodigoEntregaOutroCliente);
		connection.AddParameters("@cdClienAtacadista", cdClienAtacadista);
		connection.AddParameters("@cdClienFatura", cdClienFatura);
		connection.AddParameters("@cdClienPagamento", cdClienPagamento);
		connection.AddParameters("@SeqTroca", SeqTroca);
		connection.AddParameters("@cdComoRealizouVenda", cdComoRealizouVenda);
		connection.AddParameters("@TextoComoRealizouVenda", TextoComoRealizouVenda);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, string NuPedCli, int? CdEmp, int? NuPed, string CdVend, int? CdClien, decimal? PerDescFin, decimal? VlDescFin, decimal? NuDiasDescFin, string TpEstab, string TpPed, DateTime? DtPed, string CdTabela, int? SeqProm, string Formpgto, decimal? VlFrete, decimal? ValorTot, string TpMidia, string TpEntrega, int? CdForn, string TpFrete, DateTime? DtEntrega, string Situacao, int? PromPadrCli, DateTime? DtPrevFatu, decimal? PercDescGeral, decimal? VlDescGeral, string OrigemPedido, string NuPedPalm, int? SemEstoque, int? NuNf, int? NuNfEmpFat, string DescCfop, string DescNatOper, int? ImpViaSp, string TpImpSp, int? NfCanc, string CdIntPedEle, string CardCredNumero, string CardCredProprietario, string CardCredTipo, string CardCredComplemento, string CardCredDtExpiracaoMes, string CardCredDtExpiracaoAno, string CardCredCpfProprietario, string CdIntpededi, int? IdOrderVertis, int? VertisPedFinalizado, int? MantemVlFretePedvEle, int? MantemVlDescGerPedvEle, int? PedidoDireto, bool? PropostaVda, bool? PendEleLiberaAuto, string NomeEntrega, bool? LiberacaoAutomatica, bool? AtendimentoEnviado, int? CodigoEntregaOutroCliente, int? SeqTroca, int? cdClienAtacadista, int? cdClienFatura, int? cdClienPagamento, int? cdComoRealizouVenda, string TextoComoRealizouVenda)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@nu_ped_cli", NuPedCli);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@nu_ped", NuPed);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@per_desc_fin", PerDescFin);
		connection.AddParameters("@vl_desc_fin", VlDescFin);
		connection.AddParameters("@nu_dias_desc_fin", NuDiasDescFin);
		connection.AddParameters("@tp_estab", TpEstab);
		connection.AddParameters("@tp_ped", TpPed);
		connection.AddParameters("@dt_ped", DtPed);
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@seq_prom", SeqProm);
		connection.AddParameters("@formpgto", Formpgto);
		connection.AddParameters("@vl_frete", VlFrete);
		connection.AddParameters("@valor_tot", ValorTot);
		connection.AddParameters("@tp_midia", TpMidia);
		connection.AddParameters("@tp_entrega", TpEntrega);
		connection.AddParameters("@cd_forn", CdForn);
		connection.AddParameters("@tp_frete", TpFrete);
		connection.AddParameters("@dt_entrega", DtEntrega);
		connection.AddParameters("@situacao", Situacao);
		connection.AddParameters("@prom_padr_cli", PromPadrCli);
		connection.AddParameters("@dt_prev_fatu", DtPrevFatu);
		connection.AddParameters("@perc_desc_geral", PercDescGeral);
		connection.AddParameters("@vl_desc_geral", VlDescGeral);
		connection.AddParameters("@origem_pedido", OrigemPedido);
		connection.AddParameters("@nu_ped_palm", NuPedPalm);
		connection.AddParameters("@sem_estoque", SemEstoque);
		connection.AddParameters("@nu_nf", NuNf);
		connection.AddParameters("@nu_nf_emp_fat", NuNfEmpFat);
		connection.AddParameters("@desc_cfop", DescCfop);
		connection.AddParameters("@desc_nat_oper", DescNatOper);
		connection.AddParameters("@imp_via_sp", ImpViaSp);
		connection.AddParameters("@tp_imp_sp", TpImpSp);
		connection.AddParameters("@nf_canc", NfCanc);
		connection.AddParameters("@cd_int_ped_ele", CdIntPedEle);
		connection.AddParameters("@card_cred_numero", CardCredNumero);
		connection.AddParameters("@card_cred_proprietario", CardCredProprietario);
		connection.AddParameters("@card_cred_tipo", CardCredTipo);
		connection.AddParameters("@card_cred_complemento", CardCredComplemento);
		connection.AddParameters("@card_cred_dt_expiracao_mes", CardCredDtExpiracaoMes);
		connection.AddParameters("@card_cred_dt_expiracao_ano", CardCredDtExpiracaoAno);
		connection.AddParameters("@card_cred_cpf_proprietario", CardCredCpfProprietario);
		connection.AddParameters("@cd_intpededi", CdIntpededi);
		connection.AddParameters("@idOrder_Vertis", IdOrderVertis);
		connection.AddParameters("@vertis_ped_finalizado", VertisPedFinalizado);
		connection.AddParameters("@mantem_vl_frete_pedv_ele", MantemVlFretePedvEle);
		connection.AddParameters("@mantem_vl_desc_ger_pedv_ele", MantemVlDescGerPedvEle);
		connection.AddParameters("@pedido_direto", PedidoDireto);
		connection.AddParameters("@proposta_vda", PropostaVda);
		connection.AddParameters("@pend_ele_libera_auto", PendEleLiberaAuto);
		connection.AddParameters("@nome_entrega", NomeEntrega);
		connection.AddParameters("@liberacao_automatica", LiberacaoAutomatica);
		connection.AddParameters("@atendimento_enviado", AtendimentoEnviado);
		connection.AddParameters("@CdClienOutCli", CodigoEntregaOutroCliente);
		connection.AddParameters("@cdClienAtacadista", cdClienAtacadista);
		connection.AddParameters("@cdClienFatura", cdClienFatura);
		connection.AddParameters("@cdClienPagamento", cdClienPagamento);
		connection.AddParameters("@SeqTroca", SeqTroca);
		connection.AddParameters("@cdComoRealizouVenda", cdComoRealizouVenda);
		connection.AddParameters("@TextoComoRealizouVenda", TextoComoRealizouVenda);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspPedVdaEleExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	public static int Count(DbConnection connection, int CdEmpEle, string CdVend, int CdClien, DateTime DtPed, string NuPedPalm)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_ped", DtPed);
		connection.AddParameters("@nu_ped_palm", NuPedPalm);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, "uspPedVdaEleCount"));
	}

	private static PedVdaEleTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PedVdaEleTO pedVdaEleTO = new PedVdaEleTO();
				pedVdaEleTO.CdEmpEle = rs.GetInteger("cd_emp_ele");
				pedVdaEleTO.NuPedEle = rs.GetInteger("nu_ped_ele");
				pedVdaEleTO.SeqPed = rs.GetDecimal("seq_ped");
				pedVdaEleTO.NuPedCli = rs.GetString("nu_ped_cli");
				pedVdaEleTO.CdEmp = rs.GetNullableInteger("cd_emp");
				pedVdaEleTO.NuPed = rs.GetNullableInteger("nu_ped");
				pedVdaEleTO.CdVend = rs.GetString("cd_vend");
				pedVdaEleTO.CdClien = rs.GetNullableInteger("cd_clien");
				pedVdaEleTO.PerDescFin = rs.GetNullableDecimal("per_desc_fin");
				pedVdaEleTO.VlDescFin = rs.GetNullableDecimal("vl_desc_fin");
				pedVdaEleTO.NuDiasDescFin = rs.GetNullableDecimal("nu_dias_desc_fin");
				string @string = rs.GetString("tp_estab");
				if (!(@string == "CO"))
				{
					if (@string == "RE")
					{
						pedVdaEleTO.TpEstab = TipoEstabelecimento.Residencial;
					}
					else
					{
						pedVdaEleTO.TpEstab = TipoEstabelecimento.Comercial;
					}
				}
				else
				{
					pedVdaEleTO.TpEstab = TipoEstabelecimento.Comercial;
				}
				pedVdaEleTO.TpPed = rs.GetString("tp_ped");
				pedVdaEleTO.DtPed = rs.GetNullableDateTime("dt_ped");
				pedVdaEleTO.CdTabela = rs.GetString("cd_tabela");
				pedVdaEleTO.SeqProm = rs.GetNullableInteger("seq_prom");
				pedVdaEleTO.Formpgto = rs.GetString("formpgto");
				pedVdaEleTO.VlFrete = rs.GetNullableDecimal("vl_frete");
				pedVdaEleTO.ValorTot = rs.GetNullableDecimal("valor_tot");
				pedVdaEleTO.TpMidia = rs.GetString("tp_midia");
				switch (rs.GetString("tp_entrega"))
				{
				case "EN":
					pedVdaEleTO.TpEntrega = TipoEntrega.Entrega;
					break;
				case "RE":
					pedVdaEleTO.TpEntrega = TipoEntrega.Retira;
					break;
				case "TR":
					pedVdaEleTO.TpEntrega = TipoEntrega.Transportadora;
					break;
				default:
					pedVdaEleTO.TpEntrega = TipoEntrega.Entrega;
					break;
				}
				pedVdaEleTO.CdForn = rs.GetNullableInteger("cd_forn");
				@string = rs.GetString("tp_frete");
				if (!(@string == "C"))
				{
					if (@string == "F")
					{
						pedVdaEleTO.TpFrete = TipoFrete.FOB;
					}
					else
					{
						pedVdaEleTO.TpFrete = TipoFrete.CIF;
					}
				}
				else
				{
					pedVdaEleTO.TpFrete = TipoFrete.CIF;
				}
				pedVdaEleTO.DtEntrega = rs.GetNullableDateTime("dt_entrega");
				@string = rs.GetString("situacao");
				if (!(@string == "AB"))
				{
					if (@string == "CA")
					{
						pedVdaEleTO.Situacao = SituacaoPedido.Cancelado;
					}
					else
					{
						pedVdaEleTO.Situacao = SituacaoPedido.EmAberto;
					}
				}
				else
				{
					pedVdaEleTO.Situacao = SituacaoPedido.EmAberto;
				}
				pedVdaEleTO.PromPadrCli = rs.GetNullableInteger("prom_padr_cli");
				pedVdaEleTO.DtPrevFatu = rs.GetNullableDateTime("dt_prev_fatu");
				pedVdaEleTO.PercDescGeral = rs.GetNullableDecimal("perc_desc_geral");
				pedVdaEleTO.VlDescGeral = rs.GetNullableDecimal("vl_desc_geral");
				switch (rs.GetString("origem_pedido"))
				{
				case "E":
					pedVdaEleTO.OrigPedido = OrigemPedido.EDI;
					break;
				case "P":
					pedVdaEleTO.OrigPedido = OrigemPedido.Palmtop;
					break;
				case "T":
					pedVdaEleTO.OrigPedido = OrigemPedido.Digitacao;
					break;
				case "F":
					pedVdaEleTO.OrigPedido = OrigemPedido.FrenteDeCaixa;
					break;
				case "V":
					pedVdaEleTO.OrigPedido = OrigemPedido.ECommerce;
					break;
				case "D":
					pedVdaEleTO.OrigPedido = OrigemPedido.PedidoEletronico;
					break;
				default:
					pedVdaEleTO.OrigPedido = OrigemPedido.Digitacao;
					break;
				}
				pedVdaEleTO.NuPedPalm = rs.GetString("nu_ped_palm");
				pedVdaEleTO.SemEstoque = rs.GetNullableInteger("sem_estoque");
				pedVdaEleTO.NuNf = rs.GetNullableInteger("nu_nf");
				pedVdaEleTO.NuNfEmpFat = rs.GetNullableInteger("nu_nf_emp_fat");
				pedVdaEleTO.DescCfop = rs.GetString("desc_cfop");
				pedVdaEleTO.DescNatOper = rs.GetString("desc_nat_oper");
				pedVdaEleTO.ImpViaSp = rs.GetNullableInteger("imp_via_sp");
				pedVdaEleTO.TpImpSp = rs.GetString("tp_imp_sp");
				pedVdaEleTO.NfCanc = rs.GetNullableInteger("nf_canc");
				pedVdaEleTO.CdIntPedEle = rs.GetString("cd_int_ped_ele");
				pedVdaEleTO.CardCredNumero = rs.GetString("card_cred_numero");
				pedVdaEleTO.CardCredProprietario = rs.GetString("card_cred_proprietario");
				pedVdaEleTO.CardCredTipo = rs.GetString("card_cred_tipo");
				pedVdaEleTO.CardCredComplemento = rs.GetString("card_cred_complemento");
				pedVdaEleTO.CardCredDtExpiracaoMes = rs.GetString("card_cred_dt_expiracao_mes");
				pedVdaEleTO.CardCredDtExpiracaoAno = rs.GetString("card_cred_dt_expiracao_ano");
				pedVdaEleTO.CardCredCpfProprietario = rs.GetString("card_cred_cpf_proprietario");
				pedVdaEleTO.CdIntpededi = rs.GetString("cd_intpededi");
				pedVdaEleTO.IdOrderVertis = rs.GetNullableInteger("idOrder_Vertis");
				pedVdaEleTO.VertisPedFinalizado = rs.GetNullableInteger("vertis_ped_finalizado");
				pedVdaEleTO.MantemVlFretePedvEle = rs.GetNullableInteger("mantem_vl_frete_pedv_ele");
				pedVdaEleTO.MantemVlDescGerPedvEle = rs.GetNullableInteger("mantem_vl_desc_ger_pedv_ele");
				pedVdaEleTO.PedidoDireto = rs.GetNullableInteger("pedido_direto");
				pedVdaEleTO.PropostaVda = rs.GetNullableBoolean("proposta_vda");
				pedVdaEleTO.PendEleLiberaAuto = rs.GetNullableBoolean("pend_ele_libera_auto");
				pedVdaEleTO.NomeEntrega = rs.GetString("nome_entrega");
				pedVdaEleTO.LiberacaoAutomatica = rs.GetNullableBoolean("liberacao_automatica");
				pedVdaEleTO.AtendimentoEnviado = rs.GetNullableInteger("atendimento_enviado");
				pedVdaEleTO.CodigoEntregaOutroCliente = rs.GetNullableInteger("CdClienOutCli");
				pedVdaEleTO.cdClienAtacadista = rs.GetNullableInteger("cdClienAtacadista");
				pedVdaEleTO.cdClienFatura = rs.GetNullableInteger("cdClienFatura");
				pedVdaEleTO.cdClienPagamento = rs.GetNullableInteger("cdClienPagamento");
				pedVdaEleTO.SeqTroca = rs.GetNullableInteger("SeqTroca");
				pedVdaEleTO.cdComoRealizouVenda = rs.GetNullableInteger("cdComoRealizouVenda");
				pedVdaEleTO.TextoComoRealizouVenda = rs.GetString("TextoComoRealizouVenda");
				arrayList.Add(pedVdaEleTO);
			}
		}
		return (PedVdaEleTO[])arrayList.ToArray(typeof(PedVdaEleTO));
	}

	public static void SetAtendimentoEnviado(DbConnection connection, PedVdaEleTO instance, StatusAtendimentoEnviadoTR statusEnviado)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@status", (int)statusEnviado);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPedVdaEleSetAtendimentoEnviado");
	}

	public static PedVdaEleTO[] AtendimentoPendente(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstancesPendente(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleAtendimentoPendente"));
	}

	public static int LiberacaoPendenciaQtde(DbConnection connection, int tipoLiberacao)
	{
		connection.ClearParameters();
		connection.AddParameters("@tipo_liberacao", tipoLiberacao);
		BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleLiberacaoPendencia");
		if (basicRS.MoveNext())
		{
			int integer = basicRS.GetInteger("Qtde");
			basicRS.CloseRS();
			return integer;
		}
		return 0;
	}

	public static DateTime? LiberacaoPendenciaMaisAntiga(DbConnection connection, int tipoLiberacao)
	{
		connection.ClearParameters();
		connection.AddParameters("@tipo_liberacao", tipoLiberacao);
		BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleLiberacaoPendencia");
		if (basicRS.MoveNext())
		{
			DateTime? nullableDateTime = basicRS.GetNullableDateTime("MaisAntigo");
			basicRS.CloseRS();
			return nullableDateTime;
		}
		return null;
	}

	public static DateTime? AtendimentoPendenciaMaisAntiga(DbConnection connection)
	{
		connection.ClearParameters();
		BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleAtendimentoPendencia");
		if (basicRS.MoveNext())
		{
			DateTime? nullableDateTime = basicRS.GetNullableDateTime("MaisAntigo");
			basicRS.CloseRS();
			return nullableDateTime;
		}
		return null;
	}

	public static int? AtendimentoPendenciaQtd(DbConnection connection)
	{
		connection.ClearParameters();
		BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleAtendimentoPendencia");
		if (basicRS.MoveNext())
		{
			int? nullableInteger = basicRS.GetNullableInteger("Qtde");
			basicRS.CloseRS();
			return nullableInteger;
		}
		return null;
	}

	private static PedVdaEleTO[] CreateInstancesPendente(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PedVdaEleTO pedVdaEleTO = new PedVdaEleTO();
				pedVdaEleTO.CdEmpEle = rs.GetInteger("cd_emp_ele");
				pedVdaEleTO.NuPedEle = rs.GetInteger("nu_ped_ele");
				pedVdaEleTO.SeqPed = rs.GetDecimal("seq_ped");
				arrayList.Add(pedVdaEleTO);
			}
		}
		return (PedVdaEleTO[])arrayList.ToArray(typeof(PedVdaEleTO));
	}
}
