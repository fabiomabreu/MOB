using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class TrocaDAL
{
	private const string INSERT = "uspTrocaInsert";

	private const string UPDATE = "uspTrocaUpdate";

	private const string DELETE = "uspTrocaDelete";

	private const string SELECT = "uspTrocaSelect";

	private const string EXISTS = "uspTrocaExists";

	private const string COUNT = "uspTrocaCount";

	public static void Insert(DbConnection connection, TrocaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@dt_cad", instance.DtCad);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_tabela", instance.CdTabela);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_motcanc", instance.CdMotcanc);
		connection.AddParameters("@prod_localiza", instance.RetornaProdLocaliza());
		connection.AddParameters("@cd_emp_estoque", instance.CdEmpEstoque);
		connection.AddParameters("@cd_local_estoque", instance.CdLocalEstoque);
		connection.AddParameters("@cd_emp_pedido", instance.CdEmpPedido);
		connection.AddParameters("@nu_ped_pedido", instance.NuPedPedido);
		connection.AddParameters("@vl_total", instance.VlTotal);
		connection.AddParameters("@situacao", instance.Situacao);
		connection.AddParameters("@tp_abatimento", instance.RetornaTpAbatimento());
		connection.AddParameters("@tp_envio", instance.RetornaTpEnvio());
		connection.AddParameters("@vl_total_recebido", instance.VlTotalRecebido);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@referencia", instance.Referencia);
		connection.AddParameters("@cd_troca_palm", instance.CdTrocaPalm);
		connection.AddParameters("@dt_cad_palm", instance.DtCadPalm);
		if (instance.Indenizacao.HasValue && instance.Indenizacao.Value)
		{
			instance.Indenizacao = true;
		}
		else
		{
			instance.Indenizacao = false;
		}
		connection.AddParameters("@indenizacao", instance.Indenizacao);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspTrocaInsert");
		instance.SeqTroca = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, TrocaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", instance.SeqTroca);
		connection.AddParameters("@dt_cad", instance.DtCad);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_tabela", instance.CdTabela);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_motcanc", instance.CdMotcanc);
		connection.AddParameters("@prod_localiza", instance.RetornaProdLocaliza());
		connection.AddParameters("@cd_emp_estoque", instance.CdEmpEstoque);
		connection.AddParameters("@cd_local_estoque", instance.CdLocalEstoque);
		connection.AddParameters("@cd_emp_pedido", instance.CdEmpPedido);
		connection.AddParameters("@nu_ped_pedido", instance.NuPedPedido);
		connection.AddParameters("@vl_total", instance.VlTotal);
		connection.AddParameters("@situacao", instance.Situacao);
		connection.AddParameters("@tp_abatimento", instance.RetornaTpAbatimento());
		connection.AddParameters("@tp_envio", instance.RetornaTpEnvio());
		connection.AddParameters("@vl_total_recebido", instance.VlTotalRecebido);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@referencia", instance.Referencia);
		connection.AddParameters("@cd_troca_palm", instance.CdTrocaPalm);
		connection.AddParameters("@dt_cad_palm", instance.DtCadPalm);
		connection.AddParameters("@indenizacao", instance.Indenizacao);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTrocaUpdate");
	}

	public static void Delete(DbConnection connection, TrocaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", instance.SeqTroca);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTrocaDelete");
	}

	public static TrocaTO[] Select(DbConnection connection, int? SeqTroca)
	{
		return Select(connection, SeqTroca, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static TrocaTO[] Select(DbConnection connection, int? SeqTroca, DateTime? DtCad, string CdVend, string CdTabela, int? CdClien, string CdMotcanc, string ProdLocaliza, int? CdEmpEstoque, string CdLocalEstoque, int? CdEmpPedido, int? NuPedPedido, decimal? VlTotal, string Situacao, string TpAbatimento, string TpEnvio, decimal? VlTotalRecebido, int? CdEmp, string Referencia, string CdTrocaPalm, DateTime? DtCadPalm)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", SeqTroca);
		connection.AddParameters("@dt_cad", DtCad);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_motcanc", CdMotcanc);
		connection.AddParameters("@prod_localiza", ProdLocaliza);
		connection.AddParameters("@cd_emp_estoque", CdEmpEstoque);
		connection.AddParameters("@cd_local_estoque", CdLocalEstoque);
		connection.AddParameters("@cd_emp_pedido", CdEmpPedido);
		connection.AddParameters("@nu_ped_pedido", NuPedPedido);
		connection.AddParameters("@vl_total", VlTotal);
		connection.AddParameters("@situacao", Situacao);
		connection.AddParameters("@tp_abatimento", TpAbatimento);
		connection.AddParameters("@tp_envio", TpEnvio);
		connection.AddParameters("@vl_total_recebido", VlTotalRecebido);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@referencia", Referencia);
		connection.AddParameters("@cd_troca_palm", CdTrocaPalm);
		connection.AddParameters("@dt_cad_palm", DtCadPalm);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTrocaSelect"));
	}

	public static bool Exists(DbConnection connection, int? SeqTroca, DateTime? DtCad, string CdVend, string CdTabela, int? CdClien, string CdMotcanc, string ProdLocaliza, int? CdEmpEstoque, string CdLocalEstoque, int? CdEmpPedido, int? NuPedPedido, decimal? VlTotal, string Situacao, string TpAbatimento, string TpEnvio, decimal? VlTotalRecebido, int? CdEmp, string Referencia, string CdTrocaPalm, DateTime? DtCadPalm, bool Indenizacao)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_troca", SeqTroca);
		connection.AddParameters("@dt_cad", DtCad);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_motcanc", CdMotcanc);
		connection.AddParameters("@prod_localiza", ProdLocaliza);
		connection.AddParameters("@cd_emp_estoque", CdEmpEstoque);
		connection.AddParameters("@cd_local_estoque", CdLocalEstoque);
		connection.AddParameters("@cd_emp_pedido", CdEmpPedido);
		connection.AddParameters("@nu_ped_pedido", NuPedPedido);
		connection.AddParameters("@vl_total", VlTotal);
		connection.AddParameters("@situacao", Situacao);
		connection.AddParameters("@tp_abatimento", TpAbatimento);
		connection.AddParameters("@tp_envio", TpEnvio);
		connection.AddParameters("@vl_total_recebido", VlTotalRecebido);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@referencia", Referencia);
		connection.AddParameters("@cd_troca_palm", CdTrocaPalm);
		connection.AddParameters("@dt_cad_palm", DtCadPalm);
		connection.AddParameters("@indenizacao", Indenizacao);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspTrocaExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	public static int Count(DbConnection connection, int CdEmpEle, string CdVend, int CdClien, DateTime DtCadPalm, string CdTrocaPalm)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmpEle);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_cad_palm", DtCadPalm);
		connection.AddParameters("@cd_troca_palm", CdTrocaPalm);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, "uspTrocaCount"));
	}

	private static TrocaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TrocaTO trocaTO = new TrocaTO();
				trocaTO.SeqTroca = rs.GetInteger("seq_troca");
				trocaTO.DtCad = rs.GetDateTime("dt_cad");
				trocaTO.CdVend = rs.GetString("cd_vend");
				trocaTO.CdTabela = rs.GetString("cd_tabela");
				trocaTO.CdClien = rs.GetInteger("cd_clien");
				trocaTO.CdMotcanc = rs.GetString("cd_motcanc");
				switch (rs.GetString("prod_localiza"))
				{
				case "C":
					trocaTO.ProdLocaliza = LocalProdutoTroca.Cliente;
					break;
				case "E":
					trocaTO.ProdLocaliza = LocalProdutoTroca.Empresa;
					break;
				case "V":
					trocaTO.ProdLocaliza = LocalProdutoTroca.Vendedor;
					break;
				default:
					trocaTO.ProdLocaliza = LocalProdutoTroca.Cliente;
					break;
				}
				trocaTO.CdEmpEstoque = rs.GetNullableInteger("cd_emp_estoque");
				trocaTO.CdLocalEstoque = rs.GetString("cd_local_estoque");
				trocaTO.CdEmpPedido = rs.GetNullableInteger("cd_emp_pedido");
				trocaTO.NuPedPedido = rs.GetNullableInteger("nu_ped_pedido");
				trocaTO.VlTotal = rs.GetDecimal("vl_total");
				trocaTO.Situacao = rs.GetString("situacao");
				switch (rs.GetString("tp_abatimento"))
				{
				case "PN":
					trocaTO.TpAbatimento = TipoAbatTroca.ProximaNota;
					break;
				case "PT":
					trocaTO.TpAbatimento = TipoAbatTroca.ProximoTitulo;
					break;
				case "TA":
					trocaTO.TpAbatimento = TipoAbatTroca.TitulosPendentes;
					break;
				default:
					trocaTO.TpAbatimento = TipoAbatTroca.ProximaNota;
					break;
				}
				string @string = rs.GetString("tp_envio");
				if (!(@string == "PF"))
				{
					if (@string == "PA")
					{
						trocaTO.TpEnvio = TipoEnvioTroca.PedidoEmAberto;
					}
					else
					{
						trocaTO.TpEnvio = TipoEnvioTroca.ProximoPedido;
					}
				}
				else
				{
					trocaTO.TpEnvio = TipoEnvioTroca.ProximoPedido;
				}
				trocaTO.VlTotalRecebido = rs.GetDecimal("vl_total_recebido");
				trocaTO.CdEmp = rs.GetInteger("cd_emp");
				trocaTO.Referencia = rs.GetString("referencia");
				trocaTO.CdTrocaPalm = rs.GetString("cd_troca_palm");
				trocaTO.DtCadPalm = rs.GetNullableDateTime("dt_cad_palm");
				trocaTO.Indenizacao = rs.GetNullableBoolean("indenizacao");
				arrayList.Add(trocaTO);
			}
		}
		return (TrocaTO[])arrayList.ToArray(typeof(TrocaTO));
	}
}
