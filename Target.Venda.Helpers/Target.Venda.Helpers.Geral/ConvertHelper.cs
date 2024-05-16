using System;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Helpers.Geral;

public class ConvertHelper
{
	public static DateTime ToDateTime(string Data)
	{
		if (DateTime.TryParse(Data, out var _))
		{
			return DateTime.Parse(Data);
		}
		return DateTime.MinValue;
	}

	public static DateTime ToDateTime(object Data)
	{
		DateTime result = DateTime.MinValue;
		if (DateTime.TryParse(Data.ToString(), out result))
		{
			return result;
		}
		return DateTime.MinValue;
	}

	public static string ToString(byte[] bytes)
	{
		Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
		return encoding.GetString(bytes);
	}

	public static string ToString(object valor)
	{
		if (valor == null)
		{
			return "";
		}
		string result = "";
		try
		{
			result = valor.ToString();
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static int ToInt(string valor)
	{
		int result = 0;
		int.TryParse(valor, out result);
		return result;
	}

	public static int ToInt(object valor)
	{
		int result = 0;
		int.TryParse(ToString(valor), out result);
		return result;
	}

	public static short ToShort(string valor)
	{
		short result = 0;
		short.TryParse(valor, out result);
		return result;
	}

	public static short ToShort(object valor)
	{
		short result = 0;
		short.TryParse(ToString(valor), out result);
		return result;
	}

	public static double ToDouble(string valor)
	{
		double result = 0.0;
		double.TryParse(valor, out result);
		return result;
	}

	public static double ToDouble(object valor)
	{
		double result = 0.0;
		double.TryParse(ToString(valor), out result);
		return result;
	}

	public static decimal ToDecimal(string valor)
	{
		decimal result = default(decimal);
		decimal.TryParse(valor, out result);
		return result;
	}

	public static decimal ToDecimal(object valor)
	{
		decimal result = default(decimal);
		decimal.TryParse(ToString(valor), out result);
		return result;
	}

	public static long ToLong(string valor)
	{
		long result = 0L;
		long.TryParse(valor, out result);
		return result;
	}

	public static long ToLong(object valor)
	{
		long result = 0L;
		long.TryParse(ToString(valor), out result);
		return result;
	}

	public static bool ToBool(object valor)
	{
		bool result = false;
		bool.TryParse(ToString(valor), out result);
		return result;
	}

	public static bool ToBool(byte valor)
	{
		return Convert.ToBoolean(valor);
	}

	public static bool ToBool(BoolEnum valor)
	{
		return valor == BoolEnum.True;
	}

	public static bool ToBool(BoolEnum? valor)
	{
		if (!valor.HasValue)
		{
			return false;
		}
		return valor == BoolEnum.True;
	}

	public static long ToASCII(string valor)
	{
		StringBuilder stringBuilder = new StringBuilder();
		byte[] bytes = Encoding.ASCII.GetBytes(valor);
		byte[] array = bytes;
		foreach (byte value in array)
		{
			stringBuilder.Append(value);
		}
		return Convert.ToInt64(stringBuilder.ToString());
	}

	public static Guid ToGuid(object valor)
	{
		Guid result = Guid.Empty;
		Guid.TryParse(ToString(valor), out result);
		return result;
	}

	public static string ToXmlString<T>(T valor)
	{
		return XmlHelper.ObjectToXml(valor);
	}

	public static XmlDocument ToXmlDocument<T>(T valor)
	{
		try
		{
			string xml = XmlHelper.ObjectToXml(valor);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			return xmlDocument;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static T ToObject<T>(string xmlString)
	{
		return XmlHelper.XmlToObject<T>(typeof(T), xmlString);
	}

	public static T ToObject<T>(object obj_para_mapear, params string[] excecoes)
	{
		return ConvertObjectToClass.Executar<T>(obj_para_mapear, excecoes);
	}

	public static dynamic ToDynamicObjetoByStringJson(string json)
	{
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		javaScriptSerializer.RegisterConverters(new JsonConvertDynamic[1]
		{
			new JsonConvertDynamic()
		});
		return javaScriptSerializer.Deserialize(json, typeof(object));
	}
}
