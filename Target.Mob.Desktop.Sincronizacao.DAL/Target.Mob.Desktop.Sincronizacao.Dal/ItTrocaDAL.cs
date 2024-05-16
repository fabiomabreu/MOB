using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ItTrocaDAL
{
	private const string INSERT = "uspItTrocaInsert";

	private const string UPDATE = "uspItTrocaUpdate";

	private const string DELETE = "uspItTrocaDelete";

	private const string SELECT = "uspItTrocaSelect";

	private const string EXISTS = "uspItTrocaExists";

	public static void Insert(DbConnection connection, ItTrocaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", instance.SeqTroca);
		connection.AddParameters("@seq_it_troca", instance.SeqItTroca);
		connection.AddParameters("@cd_prod", instance.CdProd);
		connection.AddParameters("@qtde", instance.Qtde);
		connection.AddParameters("@vl_cheio", instance.VlCheio);
		connection.AddParameters("@perc_indeniz", instance.PercIndeniz);
		connection.AddParameters("@vl_unit", instance.VlUnit);
		connection.AddParameters("@nu_nf", instance.NuNf);
		connection.AddParameters("@qtde_receb", instance.QtdeReceb);
		connection.AddParameters("@vl_unit_receb", instance.VlUnitReceb);
		connection.AddParameters("@unid_vda", instance.UnidVda);
		connection.AddParameters("@fator_estoque", instance.FatorEstoque);
		connection.AddParameters("@ind_relacao", instance.RetornaIndRelacao());
		connection.AddParameters("@qtde_vda", instance.QtdeVda);
		connection.AddParameters("@qtde_receb_vda", instance.QtdeRecebVda);
		connection.AddParameters("@seq_lote", instance.SeqLote);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspItTrocaInsert");
	}

	public static void Update(DbConnection connection, ItTrocaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", instance.SeqTroca);
		connection.AddParameters("@seq_it_troca", instance.SeqItTroca);
		connection.AddParameters("@cd_prod", instance.CdProd);
		connection.AddParameters("@qtde", instance.Qtde);
		connection.AddParameters("@vl_cheio", instance.VlCheio);
		connection.AddParameters("@perc_indeniz", instance.PercIndeniz);
		connection.AddParameters("@vl_unit", instance.VlUnit);
		connection.AddParameters("@nu_nf", instance.NuNf);
		connection.AddParameters("@qtde_receb", instance.QtdeReceb);
		connection.AddParameters("@vl_unit_receb", instance.VlUnitReceb);
		connection.AddParameters("@unid_vda", instance.UnidVda);
		connection.AddParameters("@fator_estoque", instance.FatorEstoque);
		connection.AddParameters("@ind_relacao", instance.RetornaIndRelacao());
		connection.AddParameters("@qtde_vda", instance.QtdeVda);
		connection.AddParameters("@qtde_receb_vda", instance.QtdeRecebVda);
		connection.AddParameters("@seq_lote", instance.SeqLote);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspItTrocaUpdate");
	}

	public static void Delete(DbConnection connection, ItTrocaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", instance.SeqTroca);
		connection.AddParameters("@seq_it_troca", instance.SeqItTroca);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspItTrocaDelete");
	}

	public static ItTrocaTO[] Select(DbConnection connection, int? SeqTroca)
	{
		return Select(connection, SeqTroca, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static ItTrocaTO[] Select(DbConnection connection, int? SeqTroca, decimal? SeqItTroca)
	{
		return Select(connection, SeqTroca, SeqItTroca, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static ItTrocaTO[] Select(DbConnection connection, int? SeqTroca, decimal? SeqItTroca, int? CdProd, decimal? Qtde, decimal? VlCheio, decimal? PercIndeniz, decimal? VlUnit, int? NuNf, decimal? QtdeReceb, decimal? VlUnitReceb, string UnidVda, double? FatorEstoque, string IndRelacao, decimal? QtdeVda, decimal? QtdeRecebVda, decimal? SeqLote)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", SeqTroca);
		connection.AddParameters("@seq_it_troca", SeqItTroca);
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@qtde", Qtde);
		connection.AddParameters("@vl_cheio", VlCheio);
		connection.AddParameters("@perc_indeniz", PercIndeniz);
		connection.AddParameters("@vl_unit", VlUnit);
		connection.AddParameters("@nu_nf", NuNf);
		connection.AddParameters("@qtde_receb", QtdeReceb);
		connection.AddParameters("@vl_unit_receb", VlUnitReceb);
		connection.AddParameters("@unid_vda", UnidVda);
		connection.AddParameters("@fator_estoque", FatorEstoque);
		connection.AddParameters("@ind_relacao", IndRelacao);
		connection.AddParameters("@qtde_vda", QtdeVda);
		connection.AddParameters("@qtde_receb_vda", QtdeRecebVda);
		connection.AddParameters("@seq_lote", SeqLote);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspItTrocaSelect"));
	}

	public static bool Exists(DbConnection connection, int? SeqTroca, decimal? SeqItTroca, int? CdProd, decimal? Qtde, decimal? VlCheio, decimal? PercIndeniz, decimal? VlUnit, int? NuNf, decimal? QtdeReceb, decimal? VlUnitReceb, string UnidVda, double? FatorEstoque, string IndRelacao, decimal? QtdeVda, decimal? QtdeRecebVda, decimal? SeqLote)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", SeqTroca);
		connection.AddParameters("@seq_it_troca", SeqItTroca);
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@qtde", Qtde);
		connection.AddParameters("@vl_cheio", VlCheio);
		connection.AddParameters("@perc_indeniz", PercIndeniz);
		connection.AddParameters("@vl_unit", VlUnit);
		connection.AddParameters("@nu_nf", NuNf);
		connection.AddParameters("@qtde_receb", QtdeReceb);
		connection.AddParameters("@vl_unit_receb", VlUnitReceb);
		connection.AddParameters("@unid_vda", UnidVda);
		connection.AddParameters("@fator_estoque", FatorEstoque);
		connection.AddParameters("@ind_relacao", IndRelacao);
		connection.AddParameters("@qtde_vda", QtdeVda);
		connection.AddParameters("@qtde_receb_vda", QtdeRecebVda);
		connection.AddParameters("@seq_lote", SeqLote);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspItTrocaExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static ItTrocaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ItTrocaTO itTrocaTO = new ItTrocaTO();
				itTrocaTO.SeqTroca = rs.GetInteger("seq_troca");
				itTrocaTO.SeqItTroca = rs.GetDecimal("seq_it_troca");
				itTrocaTO.CdProd = rs.GetInteger("cd_prod");
				itTrocaTO.Qtde = rs.GetDecimal("qtde");
				itTrocaTO.VlCheio = rs.GetDecimal("vl_cheio");
				itTrocaTO.PercIndeniz = rs.GetDecimal("perc_indeniz");
				itTrocaTO.VlUnit = rs.GetDecimal("vl_unit");
				itTrocaTO.NuNf = rs.GetNullableInteger("nu_nf");
				itTrocaTO.QtdeReceb = rs.GetNullableDecimal("qtde_receb");
				itTrocaTO.VlUnitReceb = rs.GetNullableDecimal("vl_unit_receb");
				itTrocaTO.UnidVda = rs.GetString("unid_vda");
				itTrocaTO.FatorEstoque = rs.GetDouble("fator_estoque");
				string @string = rs.GetString("ind_relacao");
				if (!(@string == "MAIOR"))
				{
					if (@string == "MENOR")
					{
						itTrocaTO.IndRelacao = IndiceRelacao.Menor;
					}
					else
					{
						itTrocaTO.IndRelacao = IndiceRelacao.Maior;
					}
				}
				else
				{
					itTrocaTO.IndRelacao = IndiceRelacao.Maior;
				}
				itTrocaTO.QtdeVda = rs.GetDecimal("qtde_vda");
				itTrocaTO.QtdeRecebVda = rs.GetNullableDecimal("qtde_receb_vda");
				itTrocaTO.SeqLote = rs.GetNullableDecimal("seq_lote");
				arrayList.Add(itTrocaTO);
			}
		}
		return (ItTrocaTO[])arrayList.ToArray(typeof(ItTrocaTO));
	}
}
