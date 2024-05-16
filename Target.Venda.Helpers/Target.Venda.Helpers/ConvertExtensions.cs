using System;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Helpers;

public static class ConvertExtensions
{
	public static DateTime ToDateTime(this string obj_data)
	{
		return ConvertHelper.ToDateTime(obj_data);
	}

	public static DateTime ToDateTime(this object obj_data)
	{
		return ConvertHelper.ToDateTime(obj_data);
	}

	public static string ToString(this byte[] bytes)
	{
		return ConvertHelper.ToString(bytes);
	}

	public static string ToString(this object valor)
	{
		return ConvertHelper.ToString(valor);
	}

	public static int ToInt(this string valor)
	{
		return ConvertHelper.ToInt(valor);
	}

	public static int ToInt(this object valor)
	{
		return ConvertHelper.ToInt(valor);
	}

	public static short ToShort(this object valor)
	{
		return ConvertHelper.ToShort(valor);
	}

	public static short ToShort(this string valor)
	{
		return ConvertHelper.ToShort(valor);
	}

	public static double ToDouble(this string valor)
	{
		return ConvertHelper.ToDouble(valor);
	}

	public static double ToDouble(this object valor)
	{
		return ConvertHelper.ToDouble(valor);
	}

	public static decimal ToDecimal(this string valor)
	{
		return ConvertHelper.ToDecimal(valor);
	}

	public static decimal ToDecimal(this object valor)
	{
		return ConvertHelper.ToDecimal(valor);
	}

	public static long ToLong(this string valor)
	{
		return ConvertHelper.ToLong(valor);
	}

	public static long ToLong(this object valor)
	{
		return ConvertHelper.ToLong(valor);
	}

	public static bool ToBool(this object valor)
	{
		return ConvertHelper.ToBool(valor);
	}

	public static bool ToBool(this byte valor)
	{
		return ConvertHelper.ToBool(valor);
	}

	public static bool ToBool(this BoolEnum? valor)
	{
		return ConvertHelper.ToBool(valor);
	}

	public static bool ToBool(this BoolEnum valor)
	{
		return ConvertHelper.ToBool(valor);
	}

	public static long ToASCII(this string valor)
	{
		return ConvertHelper.ToASCII(valor);
	}
}
