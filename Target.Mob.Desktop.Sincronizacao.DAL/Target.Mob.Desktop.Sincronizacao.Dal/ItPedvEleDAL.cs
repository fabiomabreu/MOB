using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ItPedvEleDAL
{
	private const string INSERT = "uspItPedvEleInsert";

	private const string UPDATE = "uspItPedvEleUpdate";

	private const string DELETE = "uspItPedvEleDelete";

	private const string SELECT = "uspItPedvEleSelect";

	private const string EXISTS = "uspItPedvEleExists";

	public static void Insert(DbConnection connection, ItPedvEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@cd_prod", instance.CdProd);
		connection.AddParameters("@unid_ped", instance.UnidPed);
		connection.AddParameters("@qtde", instance.Qtde);
		connection.AddParameters("@fator_est_ped", instance.FatorEstPed);
		connection.AddParameters("@qtde_unid_ped", instance.QtdeUnidPed);
		connection.AddParameters("@ind_relacao", instance.RetornaIndRelacao());
		connection.AddParameters("@vl_unit_ped", instance.VlUnitPed);
		connection.AddParameters("@preco_unit", instance.PrecoUnit);
		connection.AddParameters("@aliq_ipi", instance.AliqIpi);
		connection.AddParameters("@vl_ipi", instance.VlIpi);
		connection.AddParameters("@desc_apl", instance.DescApl);
		connection.AddParameters("@vl_verba", instance.VlVerba);
		connection.AddParameters("@seq_kit", instance.SeqKit);
		connection.AddParameters("@bonificado", instance.Bonificado);
		connection.AddParameters("@cd_sit_trib", instance.CdSitTrib);
		connection.AddParameters("@desc_cfop", instance.DescCfop);
		connection.AddParameters("@incide_icm", instance.IncideIcm);
		connection.AddParameters("@aliq_icm", instance.AliqIcm);
		connection.AddParameters("@perc_red_baseicm", instance.PercRedBaseicm);
		connection.AddParameters("@vl_base_icm", instance.VlBaseIcm);
		connection.AddParameters("@vl_icm", instance.VlIcm);
		connection.AddParameters("@vl_base_icm_subst", instance.VlBaseIcmSubst);
		connection.AddParameters("@vl_icm_subst", instance.VlIcmSubst);
		connection.AddParameters("@desc01", instance.Desc01);
		connection.AddParameters("@desc02", instance.Desc02);
		connection.AddParameters("@seq_grade_desc", instance.SeqGradeDesc);
		connection.AddParameters("@seq_grade_desc_it", instance.SeqGradeDescIt);
		connection.AddParameters("@desc_grd_bon", instance.DescGrdBon);
		connection.AddParameters("@desc_grd_com", instance.DescGrdCom);
		connection.AddParameters("@desc_grd_fin", instance.DescGrdFin);
		connection.AddParameters("@SeqProm", instance.CodigoCondPgto);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspItPedvEleInsert");
	}

	public static void Update(DbConnection connection, ItPedvEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@cd_prod", instance.CdProd);
		connection.AddParameters("@unid_ped", instance.UnidPed);
		connection.AddParameters("@qtde", instance.Qtde);
		connection.AddParameters("@fator_est_ped", instance.FatorEstPed);
		connection.AddParameters("@qtde_unid_ped", instance.QtdeUnidPed);
		connection.AddParameters("@ind_relacao", instance.RetornaIndRelacao());
		connection.AddParameters("@vl_unit_ped", instance.VlUnitPed);
		connection.AddParameters("@preco_unit", instance.PrecoUnit);
		connection.AddParameters("@aliq_ipi", instance.AliqIpi);
		connection.AddParameters("@vl_ipi", instance.VlIpi);
		connection.AddParameters("@desc_apl", instance.DescApl);
		connection.AddParameters("@vl_verba", instance.VlVerba);
		connection.AddParameters("@seq_kit", instance.SeqKit);
		connection.AddParameters("@bonificado", instance.Bonificado);
		connection.AddParameters("@cd_sit_trib", instance.CdSitTrib);
		connection.AddParameters("@desc_cfop", instance.DescCfop);
		connection.AddParameters("@incide_icm", instance.IncideIcm);
		connection.AddParameters("@aliq_icm", instance.AliqIcm);
		connection.AddParameters("@perc_red_baseicm", instance.PercRedBaseicm);
		connection.AddParameters("@vl_base_icm", instance.VlBaseIcm);
		connection.AddParameters("@vl_icm", instance.VlIcm);
		connection.AddParameters("@vl_base_icm_subst", instance.VlBaseIcmSubst);
		connection.AddParameters("@vl_icm_subst", instance.VlIcmSubst);
		connection.AddParameters("@desc01", instance.Desc01);
		connection.AddParameters("@desc02", instance.Desc02);
		connection.AddParameters("@seq_grade_desc", instance.SeqGradeDesc);
		connection.AddParameters("@seq_grade_desc_it", instance.SeqGradeDescIt);
		connection.AddParameters("@desc_grd_bon", instance.DescGrdBon);
		connection.AddParameters("@desc_grd_com", instance.DescGrdCom);
		connection.AddParameters("@desc_grd_fin", instance.DescGrdFin);
		connection.AddParameters("@SeqProm", instance.CodigoCondPgto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspItPedvEleUpdate");
	}

	public static void Delete(DbConnection connection, ItPedvEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspItPedvEleDelete");
	}

	public static ItPedvEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		return Select(connection, CdEmpEle, NuPedEle, SeqPed, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static ItPedvEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, decimal? Seq)
	{
		return Select(connection, CdEmpEle, NuPedEle, SeqPed, Seq, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static ItPedvEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, decimal? Seq, int? CdProd, string UnidPed, decimal? Qtde, decimal? FatorEstPed, decimal? QtdeUnidPed, string IndRelacao, decimal? VlUnitPed, decimal? PrecoUnit, decimal? AliqIpi, decimal? VlIpi, decimal? DescApl, decimal? VlVerba, int? SeqKit, int? Bonificado, string CdSitTrib, string DescCfop, int? IncideIcm, decimal? AliqIcm, decimal? PercRedBaseicm, decimal? VlBaseIcm, decimal? VlIcm, decimal? VlBaseIcmSubst, decimal? VlIcmSubst, decimal? Desc01, decimal? Desc02, int? SeqGradeDesc, int? SeqGradeDescIt, decimal? DescGrdBon, decimal? DescGrdCom, decimal? DescGrdFin)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@unid_ped", UnidPed);
		connection.AddParameters("@qtde", Qtde);
		connection.AddParameters("@fator_est_ped", FatorEstPed);
		connection.AddParameters("@qtde_unid_ped", QtdeUnidPed);
		connection.AddParameters("@ind_relacao", IndRelacao);
		connection.AddParameters("@vl_unit_ped", VlUnitPed);
		connection.AddParameters("@preco_unit", PrecoUnit);
		connection.AddParameters("@aliq_ipi", AliqIpi);
		connection.AddParameters("@vl_ipi", VlIpi);
		connection.AddParameters("@desc_apl", DescApl);
		connection.AddParameters("@vl_verba", VlVerba);
		connection.AddParameters("@seq_kit", SeqKit);
		connection.AddParameters("@bonificado", Bonificado);
		connection.AddParameters("@cd_sit_trib", CdSitTrib);
		connection.AddParameters("@desc_cfop", DescCfop);
		connection.AddParameters("@incide_icm", IncideIcm);
		connection.AddParameters("@aliq_icm", AliqIcm);
		connection.AddParameters("@perc_red_baseicm", PercRedBaseicm);
		connection.AddParameters("@vl_base_icm", VlBaseIcm);
		connection.AddParameters("@vl_icm", VlIcm);
		connection.AddParameters("@vl_base_icm_subst", VlBaseIcmSubst);
		connection.AddParameters("@vl_icm_subst", VlIcmSubst);
		connection.AddParameters("@desc01", Desc01);
		connection.AddParameters("@desc02", Desc02);
		connection.AddParameters("@seq_grade_desc", SeqGradeDesc);
		connection.AddParameters("@seq_grade_desc_it", SeqGradeDescIt);
		connection.AddParameters("@desc_grd_bon", DescGrdBon);
		connection.AddParameters("@desc_grd_com", DescGrdCom);
		connection.AddParameters("@desc_grd_fin", DescGrdFin);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspItPedvEleSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdEmpEle, decimal? NuPedEle, decimal? SeqPed, decimal? Seq, int? CdProd, string UnidPed, decimal? Qtde, decimal? FatorEstPed, decimal? QtdeUnidPed, string IndRelacao, decimal? VlUnitPed, decimal? PrecoUnit, decimal? AliqIpi, decimal? VlIpi, decimal? DescApl, decimal? VlVerba, int? SeqKit, int? Bonificado, string CdSitTrib, string DescCfop, int? IncideIcm, decimal? AliqIcm, decimal? PercRedBaseicm, decimal? VlBaseIcm, decimal? VlIcm, decimal? VlBaseIcmSubst, decimal? VlIcmSubst, decimal? Desc01, decimal? Desc02, int? SeqGradeDesc, int? SeqGradeDescIt, decimal? DescGrdBon, decimal? DescGrdCom, decimal? DescGrdFin)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@unid_ped", UnidPed);
		connection.AddParameters("@qtde", Qtde);
		connection.AddParameters("@fator_est_ped", FatorEstPed);
		connection.AddParameters("@qtde_unid_ped", QtdeUnidPed);
		connection.AddParameters("@ind_relacao", IndRelacao);
		connection.AddParameters("@vl_unit_ped", VlUnitPed);
		connection.AddParameters("@preco_unit", PrecoUnit);
		connection.AddParameters("@aliq_ipi", AliqIpi);
		connection.AddParameters("@vl_ipi", VlIpi);
		connection.AddParameters("@desc_apl", DescApl);
		connection.AddParameters("@vl_verba", VlVerba);
		connection.AddParameters("@seq_kit", SeqKit);
		connection.AddParameters("@bonificado", Bonificado);
		connection.AddParameters("@cd_sit_trib", CdSitTrib);
		connection.AddParameters("@desc_cfop", DescCfop);
		connection.AddParameters("@incide_icm", IncideIcm);
		connection.AddParameters("@aliq_icm", AliqIcm);
		connection.AddParameters("@perc_red_baseicm", PercRedBaseicm);
		connection.AddParameters("@vl_base_icm", VlBaseIcm);
		connection.AddParameters("@vl_icm", VlIcm);
		connection.AddParameters("@vl_base_icm_subst", VlBaseIcmSubst);
		connection.AddParameters("@vl_icm_subst", VlIcmSubst);
		connection.AddParameters("@desc01", Desc01);
		connection.AddParameters("@desc02", Desc02);
		connection.AddParameters("@seq_grade_desc", SeqGradeDesc);
		connection.AddParameters("@seq_grade_desc_it", SeqGradeDescIt);
		connection.AddParameters("@desc_grd_bon", DescGrdBon);
		connection.AddParameters("@desc_grd_com", DescGrdCom);
		connection.AddParameters("@desc_grd_fin", DescGrdFin);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspItPedvEleExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static ItPedvEleTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ItPedvEleTO itPedvEleTO = new ItPedvEleTO();
				itPedvEleTO.CdEmpEle = rs.GetInteger("cd_emp_ele");
				itPedvEleTO.NuPedEle = rs.GetDecimal("nu_ped_ele");
				itPedvEleTO.SeqPed = rs.GetDecimal("seq_ped");
				itPedvEleTO.Seq = rs.GetDecimal("seq");
				itPedvEleTO.CdProd = rs.GetInteger("cd_prod");
				itPedvEleTO.UnidPed = rs.GetString("unid_ped");
				itPedvEleTO.Qtde = rs.GetDecimal("qtde");
				itPedvEleTO.FatorEstPed = rs.GetNullableDouble("fator_est_ped");
				itPedvEleTO.QtdeUnidPed = rs.GetNullableDecimal("qtde_unid_ped");
				string @string = rs.GetString("ind_relacao");
				if (!(@string == "MAIOR"))
				{
					if (@string == "MENOR")
					{
						itPedvEleTO.IndRelacao = IndiceRelacao.Menor;
					}
					else
					{
						itPedvEleTO.IndRelacao = IndiceRelacao.Maior;
					}
				}
				else
				{
					itPedvEleTO.IndRelacao = IndiceRelacao.Maior;
				}
				itPedvEleTO.VlUnitPed = rs.GetNullableDecimal("vl_unit_ped");
				itPedvEleTO.PrecoUnit = rs.GetDecimal("preco_unit");
				itPedvEleTO.AliqIpi = rs.GetNullableDecimal("aliq_ipi");
				itPedvEleTO.VlIpi = rs.GetNullableDecimal("vl_ipi");
				itPedvEleTO.DescApl = rs.GetNullableDecimal("desc_apl");
				itPedvEleTO.VlVerba = rs.GetNullableDecimal("vl_verba");
				itPedvEleTO.SeqKit = rs.GetNullableInteger("seq_kit");
				itPedvEleTO.Bonificado = rs.GetNullableInteger("bonificado");
				itPedvEleTO.CdSitTrib = rs.GetString("cd_sit_trib");
				itPedvEleTO.DescCfop = rs.GetString("desc_cfop");
				itPedvEleTO.IncideIcm = rs.GetNullableInteger("incide_icm");
				itPedvEleTO.AliqIcm = rs.GetNullableDecimal("aliq_icm");
				itPedvEleTO.PercRedBaseicm = rs.GetNullableDecimal("perc_red_baseicm");
				itPedvEleTO.VlBaseIcm = rs.GetNullableDecimal("vl_base_icm");
				itPedvEleTO.VlIcm = rs.GetNullableDecimal("vl_icm");
				itPedvEleTO.VlBaseIcmSubst = rs.GetNullableDecimal("vl_base_icm_subst");
				itPedvEleTO.VlIcmSubst = rs.GetNullableDecimal("vl_icm_subst");
				itPedvEleTO.Desc01 = rs.GetNullableDecimal("desc01");
				itPedvEleTO.Desc02 = rs.GetNullableDecimal("desc02");
				itPedvEleTO.SeqGradeDesc = rs.GetNullableInteger("seq_grade_desc");
				itPedvEleTO.SeqGradeDescIt = rs.GetNullableInteger("seq_grade_desc_it");
				itPedvEleTO.DescGrdBon = rs.GetNullableDecimal("desc_grd_bon");
				itPedvEleTO.DescGrdCom = rs.GetNullableDecimal("desc_grd_com");
				itPedvEleTO.DescGrdFin = rs.GetNullableDecimal("desc_grd_fin");
				itPedvEleTO.CodigoCondPgto = rs.GetNullableInteger("SeqProm");
				arrayList.Add(itPedvEleTO);
			}
		}
		return (ItPedvEleTO[])arrayList.ToArray(typeof(ItPedvEleTO));
	}
}
