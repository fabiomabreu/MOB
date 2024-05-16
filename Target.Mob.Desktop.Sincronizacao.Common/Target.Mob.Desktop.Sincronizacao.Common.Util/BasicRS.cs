using System;
using System.Data;

namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public class BasicRS : IDisposable, IRecordSet
{
	private IDataReader resultSet;

	private int row;

	private string[] tag;

	private bool tagInUse;

	private int rowCount;

	private string commandText;

	private bool eof;

	public bool EOF => eof;

	public int RowCount
	{
		get
		{
			int result = 0;
			if (resultSet != null)
			{
				result = resultSet.RecordsAffected;
			}
			return result;
		}
	}

	public int QuickRowCount
	{
		get
		{
			if (rowCount == 0)
			{
				rowCount = resultSet.RecordsAffected;
			}
			return rowCount;
		}
	}

	public IDataReader PlatformDataSet
	{
		get
		{
			return resultSet;
		}
		set
		{
			resultSet = value;
		}
	}

	public string CommandText
	{
		get
		{
			return commandText;
		}
		set
		{
			commandText = value;
		}
	}

	public int ColumnsCount => resultSet.FieldCount;

	public BasicRS(IDataReader rs)
	{
		resultSet = rs;
	}

	public void Dispose()
	{
		if (resultSet != null)
		{
			resultSet.Close();
			resultSet.Dispose();
			resultSet = null;
		}
		tag = null;
		rowCount = 0;
	}

	public void CloseRS()
	{
		resultSet.Close();
	}

	public DataTable ToDataTable()
	{
		DataTable schemaTable = resultSet.GetSchemaTable();
		DataTable dataTable = new DataTable();
		if (schemaTable != null)
		{
			for (int i = 0; i < schemaTable.Rows.Count; i++)
			{
				DataColumn dataColumn = new DataColumn();
				if (!dataTable.Columns.Contains(schemaTable.Rows[i]["ColumnName"].ToString()))
				{
					dataColumn.ColumnName = schemaTable.Rows[i]["ColumnName"].ToString();
					dataColumn.Unique = Convert.ToBoolean(schemaTable.Rows[i]["IsUnique"]);
					dataColumn.AllowDBNull = Convert.ToBoolean(schemaTable.Rows[i]["AllowDBNull"]);
					dataColumn.ReadOnly = Convert.ToBoolean(schemaTable.Rows[i]["IsReadOnly"]);
					dataTable.Columns.Add(dataColumn);
				}
			}
			while (resultSet.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				for (int j = 0; j < resultSet.FieldCount; j++)
				{
					dataRow[j] = resultSet.GetValue(j);
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
		return null;
	}

	public string GetTag(int row)
	{
		string result = "";
		if (tagInUse)
		{
			result = tag[row];
		}
		return result;
	}

	public void SetTag(int row, string newValue)
	{
		if (!tagInUse)
		{
			tag = new string[RowCount + 1];
			tagInUse = true;
		}
		tag[row] = newValue;
	}

	public bool IsDBNull(int column)
	{
		return resultSet.IsDBNull(column - 1);
	}

	public bool IsDBNull(string column)
	{
		return IsDBNull(resultSet.GetOrdinal(column) + 1);
	}

	public char GetChar(int column)
	{
		try
		{
			return resultSet.GetChar(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return '\0';
			}
			throw;
		}
	}

	public char GetChar(string column)
	{
		return GetChar(resultSet.GetOrdinal(column) + 1);
	}

	public char? GetNullableChar(int column)
	{
		try
		{
			return resultSet.GetChar(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public char? GetNullableChar(string column)
	{
		return GetNullableChar(resultSet.GetOrdinal(column) + 1);
	}

	public string GetString(int column)
	{
		try
		{
			return resultSet.GetString(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public string GetString(string column)
	{
		return GetString(resultSet.GetOrdinal(column) + 1);
	}

	public int GetInteger(int column)
	{
		try
		{
			return resultSet.GetInt32(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return 0;
			}
			if (resultSet.GetValue(column - 1) is byte)
			{
				return resultSet.GetByte(column - 1);
			}
			if (resultSet.GetValue(column - 1) is short)
			{
				return resultSet.GetInt16(column - 1);
			}
			if (resultSet.GetValue(column - 1) is long)
			{
				return (int)resultSet.GetInt64(column - 1);
			}
			throw;
		}
	}

	public int GetInteger(string column)
	{
		return GetInteger(resultSet.GetOrdinal(column) + 1);
	}

	public int? GetNullableInteger(int column)
	{
		try
		{
			return resultSet.GetInt32(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			if (resultSet.GetValue(column - 1) is byte)
			{
				return resultSet.GetByte(column - 1);
			}
			if (resultSet.GetValue(column - 1) is short)
			{
				return resultSet.GetInt16(column - 1);
			}
			if (resultSet.GetValue(column - 1) is long)
			{
				return (int)resultSet.GetInt64(column - 1);
			}
			throw;
		}
	}

	public int? GetNullableInteger(string column)
	{
		return GetNullableInteger(resultSet.GetOrdinal(column) + 1);
	}

	public long? GetNullableLong(int column)
	{
		try
		{
			return resultSet.GetInt64(column - 1);
		}
		catch (Exception)
		{
			if (GetFieldType(column) == typeof(int))
			{
				return GetNullableInteger(column).Value;
			}
			if (GetFieldType(column) == typeof(byte))
			{
				return GetNullableByte(column).Value;
			}
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public long? GetNullableLong(string column)
	{
		return GetNullableLong(resultSet.GetOrdinal(column) + 1);
	}

	public long GetLong(int column)
	{
		try
		{
			return resultSet.GetInt64(column - 1);
		}
		catch (Exception)
		{
			if (GetFieldType(column) == typeof(int))
			{
				return GetNullableInteger(column).Value;
			}
			if (GetFieldType(column) == typeof(byte))
			{
				return GetNullableByte(column).Value;
			}
			if (resultSet.IsDBNull(column - 1))
			{
				return 0L;
			}
			throw;
		}
	}

	public long GetLong(string column)
	{
		return GetLong(resultSet.GetOrdinal(column) + 1);
	}

	public double? GetNullableDouble(int column)
	{
		try
		{
			return resultSet.GetDouble(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public double? GetNullableDouble(string column)
	{
		return GetNullableDouble(resultSet.GetOrdinal(column) + 1);
	}

	public double GetDouble(int column)
	{
		try
		{
			return resultSet.GetDouble(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return 0.0;
			}
			throw;
		}
	}

	public double GetDouble(string column)
	{
		return GetDouble(resultSet.GetOrdinal(column) + 1);
	}

	public decimal? GetNullableDecimal(string column)
	{
		return GetNullableDecimal(resultSet.GetOrdinal(column) + 1);
	}

	public decimal? GetNullableDecimal(int column)
	{
		try
		{
			return resultSet.GetDecimal(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public decimal GetDecimal(string column)
	{
		return GetDecimal(resultSet.GetOrdinal(column) + 1);
	}

	public decimal GetDecimal(int column)
	{
		try
		{
			return resultSet.GetDecimal(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return 0m;
			}
			throw;
		}
	}

	public short? GetNullableShort(int column)
	{
		try
		{
			return resultSet.GetInt16(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public short? GetNullableShort(string column)
	{
		return GetNullableShort(resultSet.GetOrdinal(column) + 1);
	}

	public short GetShort(int column)
	{
		try
		{
			return resultSet.GetInt16(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return 0;
			}
			throw;
		}
	}

	public short GetShort(string column)
	{
		return GetShort(resultSet.GetOrdinal(column) + 1);
	}

	public DateTime GetDateTime(int column)
	{
		try
		{
			return resultSet.GetDateTime(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return DateTime.MinValue;
			}
			throw;
		}
	}

	public DateTime GetDateTime(string column)
	{
		return GetDateTime(resultSet.GetOrdinal(column) + 1);
	}

	public DateTime? GetNullableDateTime(int column)
	{
		try
		{
			return resultSet.GetDateTime(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public DateTime? GetNullableDateTime(string column)
	{
		return GetNullableDateTime(resultSet.GetOrdinal(column) + 1);
	}

	public Type GetFieldType(int column)
	{
		try
		{
			return resultSet.GetFieldType(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public Type GetFieldType(string column)
	{
		return GetFieldType(resultSet.GetOrdinal(column) + 1);
	}

	public string GetFieldName(int column)
	{
		try
		{
			return resultSet.GetName(column - 1);
		}
		catch (Exception)
		{
			return "UNKNOW";
		}
	}

	public bool? GetNullableBoolean(int column)
	{
		try
		{
			return resultSet.GetBoolean(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public bool? GetNullableBoolean(string column)
	{
		return GetNullableBoolean(resultSet.GetOrdinal(column) + 1);
	}

	public bool GetBoolean(int column)
	{
		try
		{
			return resultSet.GetBoolean(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return false;
			}
			throw;
		}
	}

	public bool GetBoolean(string column)
	{
		return GetBoolean(resultSet.GetOrdinal(column) + 1);
	}

	public byte GetByte(int column)
	{
		try
		{
			return resultSet.GetByte(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return 0;
			}
			throw;
		}
	}

	public byte GetByte(string column)
	{
		return GetByte(resultSet.GetOrdinal(column) + 1);
	}

	public byte? GetNullableByte(int column)
	{
		try
		{
			return resultSet.GetByte(column - 1);
		}
		catch (Exception)
		{
			if (resultSet.IsDBNull(column - 1))
			{
				return null;
			}
			throw;
		}
	}

	public byte? GetNullableByte(string column)
	{
		return GetNullableByte(resultSet.GetOrdinal(column) + 1);
	}

	public byte[] GetArrayByte(int column)
	{
		return (byte[])resultSet.GetValue(column - 1);
	}

	public byte[] GetArrayByte(string column)
	{
		return GetArrayByte(resultSet.GetOrdinal(column) + 1);
	}

	public object GetObject(int column)
	{
		Type fieldType = GetFieldType(column);
		if (fieldType == typeof(DateTime?))
		{
			return GetNullableDateTime(column);
		}
		if (fieldType == typeof(decimal?))
		{
			return GetNullableDecimal(column);
		}
		if (fieldType == typeof(double?))
		{
			return GetNullableDouble(column);
		}
		if (fieldType == typeof(long?))
		{
			return GetNullableLong(column);
		}
		if (fieldType == typeof(short?))
		{
			return GetNullableShort(column);
		}
		if (fieldType == typeof(int?))
		{
			return GetNullableInteger(column);
		}
		if (fieldType == typeof(bool?))
		{
			return GetNullableBoolean(column);
		}
		if (fieldType == typeof(byte?))
		{
			return GetNullableByte(column);
		}
		if (fieldType == typeof(char?))
		{
			return GetNullableChar(column);
		}
		if (fieldType == typeof(int))
		{
			return GetInteger(column);
		}
		if (fieldType == typeof(bool))
		{
			return GetBoolean(column);
		}
		if (fieldType == typeof(byte))
		{
			return GetByte(column);
		}
		if (fieldType == typeof(char))
		{
			return GetChar(column);
		}
		if (fieldType == typeof(DateTime))
		{
			return GetDateTime(column);
		}
		if (fieldType == typeof(decimal))
		{
			return GetDecimal(column);
		}
		if (fieldType == typeof(double))
		{
			return GetDouble(column);
		}
		if (fieldType == typeof(long))
		{
			return GetLong(column);
		}
		if (fieldType == typeof(short))
		{
			return GetShort(column);
		}
		if (fieldType == typeof(string))
		{
			return GetString(column);
		}
		return GetTag(column);
	}

	public object GetObject(string column)
	{
		return GetByte(resultSet.GetOrdinal(column) + 1);
	}

	public bool MoveNext()
	{
		eof = resultSet.Read();
		if (eof)
		{
			row++;
			return true;
		}
		return false;
	}
}
