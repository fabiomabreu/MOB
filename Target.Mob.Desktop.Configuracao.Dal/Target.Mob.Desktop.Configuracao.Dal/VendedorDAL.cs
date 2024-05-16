using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class VendedorDAL
{
	private const string SELECTATIV = "uspVendedorSelectCarga";

	private const string INSERT = "uspVendedorInsert";

	private const string UPDATE = "uspVendedorUpdate";

	private const string SELECT = "uspVendedorSelect";

	private const string EXISTS = "uspVendedorExists";

	private const string FORCCG = "uspVendedorForcaCargaCompleta";

	private const string UPDFLAGCARGA = "uspVendedorUpdateFlagCarga";

	private const string MAXROWID = "uspVendedorSelectMaxRowId";

	public static void Insert(SqlTransaction transaction, VendedorTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@CodigoVendedor", instance.CodigoVendedor);
		sqlCommand.Parameters.AddWithValue("@Nome", instance.Nome);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@Major", instance.Major);
		sqlCommand.Parameters.AddWithValue("@Minor", instance.Minor);
		sqlCommand.Parameters.AddWithValue("@Build", instance.Build);
		sqlCommand.Parameters.AddWithValue("@Revision", instance.Revision);
		sqlCommand.Parameters.AddWithValue("@ForcaCargaCompleta", instance.ForcaCargaCompleta);
		sqlCommand.Parameters.AddWithValue("@Ativo", instance.Ativo);
		sqlCommand.Parameters.AddWithValue("@RowIdPainel", instance.RowIdPainel);
		sqlCommand.Parameters.AddWithValue("@UtilizaSincronizacaoViaApi", instance.UtilizaSincronizacaoViaApi);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, VendedorTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@CodigoVendedor", instance.CodigoVendedor);
		sqlCommand.Parameters.AddWithValue("@Nome", instance.Nome);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@Major", instance.Major);
		sqlCommand.Parameters.AddWithValue("@Minor", instance.Minor);
		sqlCommand.Parameters.AddWithValue("@Build", instance.Build);
		sqlCommand.Parameters.AddWithValue("@Revision", instance.Revision);
		sqlCommand.Parameters.AddWithValue("@ForcaCargaCompleta", instance.ForcaCargaCompleta);
		sqlCommand.Parameters.AddWithValue("@Ativo", instance.Ativo);
		sqlCommand.Parameters.AddWithValue("@RowIdPainel", instance.RowIdPainel);
		sqlCommand.Parameters.AddWithValue("@UtilizaSincronizacaoViaApi", instance.UtilizaSincronizacaoViaApi);
		sqlCommand.ExecuteNonQuery();
	}

	public static void AtualizaFlagCargaCompleta(SqlConnection conexao, int idVendedor, bool valor)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorUpdateFlagCarga", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", idVendedor);
		sqlCommand.Parameters.AddWithValue("@ForcaCargaCompleta", valor);
		sqlCommand.ExecuteNonQuery();
	}

	public static void AtualizaFlagCargaCompleta(SqlConnection conexao, SqlTransaction transaction, int idVendedor, bool valor)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorUpdateFlagCarga", conexao, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", idVendedor);
		sqlCommand.Parameters.AddWithValue("@ForcaCargaCompleta", valor);
		sqlCommand.ExecuteNonQuery();
	}

	public static void ForcaCargaCompleta(SqlConnection connection, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorForcaCargaCompleta", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<VendedorTO> SelectCarga(SqlConnection connection)
	{
		using SqlDataReader dr = SelectDRCarga(connection);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDRCarga(SqlConnection connection)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorSelectCarga", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		return sqlCommand.ExecuteReader();
	}

	public static List<VendedorTO> Select(SqlConnection connection, VendedorTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection connection, VendedorTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@CodigoVendedor", instance.CodigoVendedor);
		sqlCommand.Parameters.AddWithValue("@Nome", instance.Nome);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@Major", instance.Major);
		sqlCommand.Parameters.AddWithValue("@Minor", instance.Minor);
		sqlCommand.Parameters.AddWithValue("@Build", instance.Build);
		sqlCommand.Parameters.AddWithValue("@Revision", instance.Revision);
		sqlCommand.Parameters.AddWithValue("@ForcaCargaCompleta", instance.ForcaCargaCompleta);
		sqlCommand.Parameters.AddWithValue("@Ativo", instance.Ativo);
		sqlCommand.Parameters.AddWithValue("@RowIdPainel", instance.RowIdPainel);
		return sqlCommand.ExecuteReader();
	}

	public static DataTable SelectDT(SqlConnection connection, VendedorTO instance)
	{
		using SqlDataReader reader = SelectDR(connection, instance);
		DataTable dataTable = new DataTable();
		try
		{
			dataTable.Load(reader);
			return dataTable;
		}
		finally
		{
			((IDisposable)dataTable)?.Dispose();
		}
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVendedorExists", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<VendedorTO> CreateInstance(SqlDataReader dr)
	{
		List<VendedorTO> list = new List<VendedorTO>();
		while (dr.Read())
		{
			VendedorTO vendedorTO = new VendedorTO();
			vendedorTO.Id = GetDataReader.GetInt32(dr, "Id");
			vendedorTO.CodigoVendedor = GetDataReader.GetString(dr, "CodigoVendedor");
			vendedorTO.Nome = GetDataReader.GetString(dr, "Nome");
			vendedorTO.IdConfiguracaoVendedor = GetDataReader.GetNullableInt32(dr, "IdConfiguracaoVendedor");
			vendedorTO.Major = GetDataReader.GetNullableInt32(dr, "Major");
			vendedorTO.Minor = GetDataReader.GetNullableInt32(dr, "Minor");
			vendedorTO.Build = GetDataReader.GetNullableInt32(dr, "Build");
			vendedorTO.Revision = GetDataReader.GetNullableInt32(dr, "Revision");
			vendedorTO.ForcaCargaCompleta = GetDataReader.GetNullableBoolean(dr, "ForcaCargaCompleta");
			vendedorTO.Ativo = GetDataReader.GetNullableBoolean(dr, "Ativo");
			vendedorTO.RowIdPainel = GetDataReader.GetByteArray(dr, "RowIdPainel");
			vendedorTO.UtilizaSincronizacaoViaApi = GetDataReader.GetNullableBoolean(dr, "UtilizaSincronizacaoViaApi");
			list.Add(vendedorTO);
		}
		return list;
	}

	public static byte[] selectMaxRowId(DbConnection connection)
	{
		byte[] result = null;
		connection.ClearParameters();
		BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspVendedorSelectMaxRowId");
		if (basicRS.MoveNext() && !basicRS.IsDBNull("RowIdPainel"))
		{
			result = basicRS.GetArrayByte("RowIdPainel");
		}
		basicRS.CloseRS();
		return result;
	}
}
