using System;
using System.Collections.Generic;
using System.Reflection;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.IBusiness.IModulo;

namespace Target.Venda.IBusiness.Factory;

public static class BusinessFactory
{
	private static string _ASSEMBLY = "Target.Venda.Business";

	private static Dictionary<string, Assembly> _Assembly = new Dictionary<string, Assembly>();

	private static string _fluxoNamespace = "Fluxo";

	private static string _processoNamespace = "Modulo";

	private static T GetInstance<T>(string nameSpace, string className)
	{
		string className2 = nameSpace + "." + className;
		Type type = GetType(className2);
		if (type == null)
		{
			return default(T);
		}
		return (T)Activator.CreateInstance(type);
	}

	private static Type GetType(string className)
	{
		string name = _ASSEMBLY + "." + className;
		Assembly assembly = GetAssembly();
		return assembly.GetType(name);
	}

	private static Assembly GetAssembly()
	{
		if (_Assembly.ContainsKey(_ASSEMBLY))
		{
			return _Assembly[_ASSEMBLY];
		}
		Assembly assembly = Assembly.Load(_ASSEMBLY);
		_Assembly[_ASSEMBLY] = assembly;
		return assembly;
	}

	public static ILiberarPedidoEletronicoBLL GetLiberarPedidoEletronicoBLL()
	{
		return GetInstance<ILiberarPedidoEletronicoBLL>(_fluxoNamespace, "LiberarPedidoEletronicoBLL");
	}

	public static ILiberarMultiplosPedidosEletronicosBLL GetLiberarMultiplosPedidosEletronicosBLL()
	{
		return GetInstance<ILiberarMultiplosPedidosEletronicosBLL>(_fluxoNamespace, "LiberarMultiplosPedidosEletronicosBLL");
	}

	public static ICancelarPedidoVendaBLL GetCancelarPedidoVendaBLL()
	{
		return GetInstance<ICancelarPedidoVendaBLL>(_fluxoNamespace, "CancelarPedidoVendaBLL");
	}

	public static IModuloEstoqueBLL GetEstoqueBLL()
	{
		return GetInstance<IModuloEstoqueBLL>(_processoNamespace, "ModuloEstoqueBLL");
	}

	public static IModuloLogisticaBLL GetLogisticaBLL()
	{
		return GetInstance<IModuloLogisticaBLL>(_processoNamespace, "ModuloLogisticaBLL");
	}

	public static IModuloComercialBLL GetComercialBLL()
	{
		return GetInstance<IModuloComercialBLL>(_processoNamespace, "ModuloComercialBLL");
	}

	public static IModuloFiscalBLL GetFiscalBLL()
	{
		return GetInstance<IModuloFiscalBLL>(_processoNamespace, "ModuloFiscalBLL");
	}

	public static IModuloFinanceiroBLL GetFinanceiroBLL()
	{
		return GetInstance<IModuloFinanceiroBLL>(_processoNamespace, "ModuloFinanceiroBLL");
	}

	public static IModuloPrecoBLL GetPrecoBLL()
	{
		return GetInstance<IModuloPrecoBLL>(_processoNamespace, "ModuloPrecoBLL");
	}

	public static IModuloSistemaBLL GetSistemaBLL()
	{
		return GetInstance<IModuloSistemaBLL>(_processoNamespace, "ModuloSistemaBLL");
	}

	public static IModuloVendaBLL GetVendaBLL()
	{
		return GetInstance<IModuloVendaBLL>(_processoNamespace, "ModuloVendaBLL");
	}

	public static IModuloProdutoBLL GetProdutoBLL()
	{
		return GetInstance<IModuloProdutoBLL>(_processoNamespace, "ModuloProdutoBLL");
	}

	public static IModuloClienteBLL GetClienteBLL()
	{
		return GetInstance<IModuloClienteBLL>(_processoNamespace, "ModuloClienteBLL");
	}

	public static IModuloVendedorBLL GetVendedorBLL()
	{
		return GetInstance<IModuloVendedorBLL>(_processoNamespace, "ModuloVendedorBLL");
	}

	public static IModuloContabilBLL GetContabilBLL()
	{
		return GetInstance<IModuloContabilBLL>(_processoNamespace, "ModuloContabilBLL");
	}
}
