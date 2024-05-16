using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoServicoDAL
{
	private const string INSERT = "uspConfiguracaoServicoInsert";

	private const string UPDATE = "uspConfiguracaoServicoUpdate";

	private const string SELECT = "uspConfiguracaoServicoSelect";

	private const string EXISTS = "uspConfiguracaoServicoExists";

	private const string DELETE = "uspConfiguracaoServicoDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoServicoInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdServico", instance.IdServico);
		sqlCommand.Parameters.AddWithValue("@Dia", instance.Dia);
		sqlCommand.Parameters.AddWithValue("@HorarioInicio", instance.HorarioInicio);
		sqlCommand.Parameters.AddWithValue("@HorarioTermino", instance.HorarioTermino);
		sqlCommand.Parameters.AddWithValue("@Intervalo", instance.Intervalo);
		sqlCommand.Parameters.AddWithValue("@Alterado", instance.Alterado);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoServicoUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdServico", instance.IdServico);
		sqlCommand.Parameters.AddWithValue("@Dia", instance.Dia);
		sqlCommand.Parameters.AddWithValue("@HorarioInicio", instance.HorarioInicio);
		sqlCommand.Parameters.AddWithValue("@HorarioTermino", instance.HorarioTermino);
		sqlCommand.Parameters.AddWithValue("@Intervalo", instance.Intervalo);
		sqlCommand.Parameters.AddWithValue("@Alterado", instance.Alterado);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoServicoTO> Select(SqlConnection connection, ConfiguracaoServicoTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoServicoSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdServico", instance.IdServico);
		sqlCommand.Parameters.AddWithValue("@Dia", instance.Dia);
		sqlCommand.Parameters.AddWithValue("@HorarioInicio", instance.HorarioInicio);
		sqlCommand.Parameters.AddWithValue("@HorarioTermino", instance.HorarioTermino);
		sqlCommand.Parameters.AddWithValue("@Intervalo", instance.Intervalo);
		sqlCommand.Parameters.AddWithValue("@Alterado", instance.Alterado);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoServicoExists", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoServicoDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdServico", instance.IdServico);
		sqlCommand.ExecuteNonQuery();
	}

	public static bool Alterado(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoServicoExists", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdServico", instance.IdServico);
		sqlCommand.Parameters.AddWithValue("@Dia", instance.Dia);
		sqlCommand.Parameters.AddWithValue("@HorarioInicio", instance.HorarioInicio);
		sqlCommand.Parameters.AddWithValue("@HorarioTermino", instance.HorarioTermino);
		sqlCommand.Parameters.AddWithValue("@Intervalo", instance.Intervalo);
		sqlCommand.Parameters.AddWithValue("@Alterado", instance.Alterado);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) <= 0;
	}

	private static List<ConfiguracaoServicoTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoServicoTO> list = new List<ConfiguracaoServicoTO>();
		while (dr.Read())
		{
			ConfiguracaoServicoTO configuracaoServicoTO = new ConfiguracaoServicoTO();
			configuracaoServicoTO.Id = GetDataReader.GetInt32(dr, "Id");
			configuracaoServicoTO.IdServico = GetDataReader.GetNullableInt32(dr, "IdServico");
			configuracaoServicoTO.Dia = GetDataReader.GetNullableInt16(dr, "Dia");
			configuracaoServicoTO.HorarioInicio = GetDataReader.GetString(dr, "HorarioInicio");
			configuracaoServicoTO.HorarioTermino = GetDataReader.GetString(dr, "HorarioTermino");
			configuracaoServicoTO.Intervalo = GetDataReader.GetNullableInt32(dr, "Intervalo");
			configuracaoServicoTO.Alterado = GetDataReader.GetNullableBoolean(dr, "Alterado");
			list.Add(configuracaoServicoTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
