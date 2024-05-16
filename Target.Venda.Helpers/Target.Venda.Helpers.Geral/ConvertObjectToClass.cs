using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Target.Venda.Helpers.Geral;

public static class ConvertObjectToClass
{
	public static T Executar<T>(object obj_para_mapear, params string[] excecoes)
	{
		try
		{
			T val = Activator.CreateInstance<T>();
			if (obj_para_mapear == null)
			{
				return val;
			}
			PropertyInfo[] properties = obj_para_mapear.GetType().GetProperties();
			List<PropertyInfo> list = val.GetType().GetProperties().ToList();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo item_mapear in array)
			{
				PropertyInfo propertyInfo = list.Find((PropertyInfo x) => x.Name.Equals(item_mapear.Name) && x.GetSetMethod() != null);
				if (propertyInfo != null)
				{
					object value = item_mapear.GetValue(obj_para_mapear, null);
					if (value != null && (excecoes == null || excecoes.Length == 0 || !excecoes.Contains(item_mapear.Name)))
					{
						ConvertePropriedade(val, propertyInfo, value);
					}
				}
			}
			return val;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private static void ConvertePropriedade<T>(T obj_result, PropertyInfo item_result, object value)
	{
		try
		{
			if (value.GetType().IsValueType || value is string || value is byte[])
			{
				SetaValorPropriedade(item_result, value, obj_result);
			}
			else if (value.GetType().IsClass)
			{
				MethodInfo method = typeof(ConvertObjectToClass).GetMethod("Executar");
				if (value is IList)
				{
					ConverteLista(obj_result, item_result, value, method);
				}
				else
				{
					ConverteClasse(obj_result, item_result, value, method);
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private static void ConverteClasse<T>(T obj_result, PropertyInfo item_result, object value, MethodInfo metodo_executar)
	{
		metodo_executar = metodo_executar.MakeGenericMethod(item_result.PropertyType);
		object valor = metodo_executar.Invoke(null, new object[1] { value });
		SetaValorPropriedade(item_result, valor, obj_result);
	}

	private static void ConverteLista<T>(T obj_result, PropertyInfo item_result, object value, MethodInfo metodo_executar)
	{
		try
		{
			object obj = Activator.CreateInstance(item_result.PropertyType);
			metodo_executar = metodo_executar.MakeGenericMethod(obj.GetType().GetGenericArguments()[0]);
			ICollection collection = value as ICollection;
			foreach (object item in collection)
			{
				object obj2 = metodo_executar.Invoke(null, new object[2] { item, null });
				MethodInfo method = obj.GetType().GetMethod("Add");
				method.Invoke(obj, new object[1] { obj2 });
			}
			SetaValorPropriedade(item_result, obj, obj_result);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private static void SetaValorPropriedade(PropertyInfo propriedade, object valor, object obj_referencia)
	{
		try
		{
			if (valor == null)
			{
				return;
			}
			if (propriedade.PropertyType.Equals(typeof(string)))
			{
				propriedade.SetValue(obj_referencia, ConvertHelper.ToString(valor), null);
			}
			else if (propriedade.PropertyType.Equals(typeof(int)))
			{
				if (ConvertHelper.ToInt(valor) != 0)
				{
					propriedade.SetValue(obj_referencia, ConvertHelper.ToInt(valor), null);
				}
			}
			else if (propriedade.PropertyType.Equals(typeof(short)))
			{
				if (ConvertHelper.ToInt(valor) != 0)
				{
					propriedade.SetValue(obj_referencia, ConvertHelper.ToShort(valor), null);
				}
			}
			else if (propriedade.PropertyType == typeof(long))
			{
				if (ConvertHelper.ToLong(valor) != 0)
				{
					propriedade.SetValue(obj_referencia, ConvertHelper.ToLong(valor), null);
				}
			}
			else if (propriedade.PropertyType == typeof(double))
			{
				if (ConvertHelper.ToDouble(valor) != 0.0)
				{
					propriedade.SetValue(obj_referencia, ConvertHelper.ToDouble(valor), null);
				}
			}
			else if (propriedade.PropertyType == typeof(decimal))
			{
				propriedade.SetValue(obj_referencia, ConvertHelper.ToDecimal(valor), null);
			}
			else if (propriedade.PropertyType == typeof(bool))
			{
				propriedade.SetValue(obj_referencia, ConvertHelper.ToBool(valor), null);
			}
			else if (propriedade.PropertyType == typeof(DateTime))
			{
				DateTime minValue = DateTime.MinValue;
				minValue = ConvertHelper.ToDateTime(valor);
				if (minValue != DateTime.MinValue)
				{
					propriedade.SetValue(obj_referencia, minValue, null);
				}
			}
			else if (propriedade.PropertyType == typeof(Guid) || propriedade.PropertyType == typeof(Guid?))
			{
				Guid guid = ConvertHelper.ToGuid(valor);
				if (guid != Guid.Empty)
				{
					propriedade.SetValue(obj_referencia, guid, null);
				}
			}
			else
			{
				propriedade.SetValue(obj_referencia, valor, null);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
