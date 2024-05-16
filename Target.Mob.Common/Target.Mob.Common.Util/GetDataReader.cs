using System;
using System.Data.SqlClient;

namespace Target.Mob.Common.Util;

public class GetDataReader
{
	public static int? GetDrNullableInt(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToInt32(Dado);
	}

	public static short? GetDrNullableShort(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToInt16(Dado);
	}

	public static long? GetDrNullableLong(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToInt64(Dado);
	}

	public static float? GetDrNullableFloat(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToSingle(Dado);
	}

	public static decimal? GetDrNullableDecimal(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToDecimal(Dado);
	}

	public static string GetDrString(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToString(Dado);
	}

	public static DateTime? GetDrNullableDateTime(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToDateTime(Dado);
	}

	public static bool? GetDrNullableBool(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToBoolean(Dado);
	}

	public static byte? GetDrNullableByte(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return Convert.ToByte(Dado);
	}

	public static byte[] GetDrByteArray(object Dado)
	{
		if (Dado == DBNull.Value)
		{
			return null;
		}
		return (byte[])Dado;
	}

	public static int GetDrInt(object Dado)
	{
		return Convert.ToInt32(Dado);
	}

	public static short GetDrShort(object Dado)
	{
		return Convert.ToInt16(Dado);
	}

	public static long GetDrLong(object Dado)
	{
		return Convert.ToInt64(Dado);
	}

	public static float GetDrFloat(object Dado)
	{
		return Convert.ToSingle(Dado);
	}

	public static decimal GetDrDecimal(object Dado)
	{
		return Convert.ToDecimal(Dado);
	}

	public static DateTime GetDrDateTime(object Dado)
	{
		return Convert.ToDateTime(Dado);
	}

	public static bool GetDrBool(object Dado)
	{
		return Convert.ToBoolean(Dado);
	}

	public static byte GetDrByte(object Dado)
	{
		return Convert.ToByte(Dado);
	}

	public static int GetInt32(SqlDataReader dr, string columnName)
	{
		return GetInt32(dr, dr.GetOrdinal(columnName));
	}

	public static int GetInt32(SqlDataReader dr, int colIndex)
	{
		return dr.GetInt32(colIndex);
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

	public static short GetShort(SqlDataReader dr, string columnName)
	{
		return GetInt16(dr, dr.GetOrdinal(columnName));
	}

	public static short GetInt16(SqlDataReader dr, int colIndex)
	{
		return dr.GetInt16(colIndex);
	}

	public static short? GetNullableInt16(SqlDataReader dr, string columnName)
	{
		return GetNullableInt16(dr, dr.GetOrdinal(columnName));
	}

	public static short? GetNullableInt16(SqlDataReader dr, int colIndex)
	{
		if (!dr.IsDBNull(colIndex))
		{
			return dr.GetInt16(colIndex);
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

	public static byte? GetNullableByte(SqlDataReader dr, string columnName)
	{
		if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
		{
			return dr.GetByte(dr.GetOrdinal(columnName));
		}
		return null;
	}

	public static byte GetByte(SqlDataReader dr, string columnName)
	{
		return dr.GetByte(dr.GetOrdinal(columnName));
	}
}
