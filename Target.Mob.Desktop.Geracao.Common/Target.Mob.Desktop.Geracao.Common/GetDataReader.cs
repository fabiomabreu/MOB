using System;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Geracao.Common;

public static class GetDataReader
{
	public static byte GetNullableByte(SqlDataReader dr, string columnName)
	{
		return dr.GetByte(dr.GetOrdinal(columnName));
	}

	public static byte GetNullableByte(SqlDataReader dr, int colIndex)
	{
		return dr.GetByte(colIndex);
	}

	public static int GetInt32(SqlDataReader dr, string columnName)
	{
		return GetInt32(dr, dr.GetOrdinal(columnName));
	}

	public static int GetInt32(SqlDataReader dr, int colIndex)
	{
		return dr.GetInt32(colIndex);
	}

	public static long GetInt64(SqlDataReader dr, string columnName)
	{
		return GetInt64(dr, dr.GetOrdinal(columnName));
	}

	public static long GetInt64(SqlDataReader dr, int colIndex)
	{
		return dr.GetInt64(colIndex);
	}

	public static int? GetNullableInt32(SqlDataReader dr, string columnName)
	{
		return GetNullableInt32(dr, dr.GetOrdinal(columnName));
	}

	public static int? GetNullableInt32(SqlDataReader dr, int colIndex)
	{
		if (!dr.IsDBNull(colIndex))
		{
			return dr.GetInt32(colIndex);
		}
		return null;
	}

	public static string GetString(SqlDataReader dr, string columnName)
	{
		return GetString(dr, dr.GetOrdinal(columnName));
	}

	public static string GetString(SqlDataReader dr, int colIndex)
	{
		if (!dr.IsDBNull(colIndex))
		{
			return dr.GetString(colIndex);
		}
		return null;
	}

	public static DateTime GetDateTime(SqlDataReader dr, string columnName)
	{
		return GetDateTime(dr, dr.GetOrdinal(columnName));
	}

	public static DateTime GetDateTime(SqlDataReader dr, int colIndex)
	{
		return dr.GetDateTime(colIndex);
	}

	public static DateTime? GetNullableDateTime(SqlDataReader dr, string columnName)
	{
		return GetNullableDateTime(dr, dr.GetOrdinal(columnName));
	}

	public static DateTime? GetNullableDateTime(SqlDataReader dr, int colIndex)
	{
		if (!dr.IsDBNull(colIndex))
		{
			return dr.GetDateTime(colIndex);
		}
		return null;
	}

	public static byte[] GetByteArray(SqlDataReader dr, string columnName)
	{
		return GetByteArray(dr, dr.GetOrdinal(columnName));
	}

	public static byte[] GetByteArray(SqlDataReader dr, int colIndex)
	{
		if (!dr.IsDBNull(colIndex))
		{
			return (byte[])dr.GetValue(colIndex);
		}
		return null;
	}

	public static bool GetBoolean(SqlDataReader dr, string columnName)
	{
		return GetBoolean(dr, dr.GetOrdinal(columnName));
	}

	public static bool GetBoolean(SqlDataReader dr, int colIndex)
	{
		return dr.GetBoolean(colIndex);
	}

	public static bool? GetNullableBoolean(SqlDataReader dr, string columnName)
	{
		return GetNullableBoolean(dr, dr.GetOrdinal(columnName));
	}

	public static bool? GetNullableBoolean(SqlDataReader dr, int colIndex)
	{
		if (!dr.IsDBNull(colIndex))
		{
			return dr.GetBoolean(colIndex);
		}
		return null;
	}

	public static decimal? GetNullableDecimal(SqlDataReader dr, string columnName)
	{
		return GetNullableDecimal(dr, dr.GetOrdinal(columnName));
	}

	public static decimal? GetNullableDecimal(SqlDataReader dr, int colIndex)
	{
		if (!dr.IsDBNull(colIndex))
		{
			return dr.GetDecimal(colIndex);
		}
		return null;
	}

	public static decimal GetDecimal(SqlDataReader dr, string columnName)
	{
		return GetDecimal(dr, dr.GetOrdinal(columnName));
	}

	public static decimal GetDecimal(SqlDataReader dr, int colIndex)
	{
		return dr.GetDecimal(colIndex);
	}
}
