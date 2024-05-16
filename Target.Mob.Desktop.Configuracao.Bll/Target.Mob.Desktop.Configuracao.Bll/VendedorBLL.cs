using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class VendedorBLL
{
	public static List<VendedorTO> Select(SqlConnection conexao, VendedorTO instance)
	{
		return VendedorDAL.Select(conexao, instance);
	}

	public static List<VendedorTO> SelectCarga(SqlConnection conexao)
	{
		return VendedorDAL.SelectCarga(conexao);
	}

	public static VendedorTO Select(SqlConnection conexao, int id)
	{
		VendedorTO result = null;
		VendedorTO vendedorTO = new VendedorTO();
		vendedorTO.Id = id;
		List<VendedorTO> list = Select(conexao, vendedorTO);
		if (list.Count > 0)
		{
			result = list[0];
		}
		return result;
	}

	public static VendedorTO Select(SqlConnection conexao, string codigoVendedor)
	{
		VendedorTO result = null;
		VendedorTO vendedorTO = new VendedorTO();
		vendedorTO.CodigoVendedor = codigoVendedor;
		List<VendedorTO> list = Select(conexao, vendedorTO);
		if (list.Count > 0)
		{
			result = list[0];
		}
		return result;
	}

	public static void Update(SqlTransaction transaction, VendedorTO instance)
	{
		VendedorDAL.Update(transaction, instance);
	}

	public static void AtualizaFlagCargaCompleta(SqlConnection conexao, int idVendedor, bool valor)
	{
		VendedorDAL.AtualizaFlagCargaCompleta(conexao, idVendedor, valor);
	}

	public static void AtualizaFlagCargaCompleta(SqlConnection conexao, SqlTransaction transaction, int idVendedor, bool valor)
	{
		VendedorDAL.AtualizaFlagCargaCompleta(conexao, transaction, idVendedor, valor);
	}

	public static void ForcaCargaCompleta(SqlConnection conexao, int? id)
	{
		VendedorDAL.ForcaCargaCompleta(conexao, id);
	}

	public static void Insert(SqlTransaction transaction, VendedorTO instance)
	{
		VendedorDAL.Insert(transaction, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return VendedorDAL.Exists(transaction, id);
	}

	public static void merge(SqlTransaction transaction, VendedorTO instance)
	{
		if (instance != null)
		{
			if (Exists(transaction, instance.Id))
			{
				Update(transaction, instance);
			}
			else
			{
				Insert(transaction, instance);
			}
		}
	}

	public static byte[] selectMaxRowId(DbConnection conexao)
	{
		return VendedorDAL.selectMaxRowId(conexao);
	}
}
