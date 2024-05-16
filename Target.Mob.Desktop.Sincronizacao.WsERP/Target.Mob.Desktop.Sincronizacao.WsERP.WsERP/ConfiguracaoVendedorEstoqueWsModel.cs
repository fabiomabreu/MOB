using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorEstoqueModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorEstoqueWsModel : INotifyPropertyChanged
{
	private int? iDConfiguracaoVendedorEstoqueField;

	private int? iDConfiguracaoVendedorField;

	private int? codigoEmpresaDestinoField;

	private int? iDLocalEstoqueField;

	private LocalEstoqueWsModel localEstoqueModelField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDConfiguracaoVendedorEstoque
	{
		get
		{
			return iDConfiguracaoVendedorEstoqueField;
		}
		set
		{
			iDConfiguracaoVendedorEstoqueField = value;
			RaisePropertyChanged("IDConfiguracaoVendedorEstoque");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IDConfiguracaoVendedor
	{
		get
		{
			return iDConfiguracaoVendedorField;
		}
		set
		{
			iDConfiguracaoVendedorField = value;
			RaisePropertyChanged("IDConfiguracaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? CodigoEmpresaDestino
	{
		get
		{
			return codigoEmpresaDestinoField;
		}
		set
		{
			codigoEmpresaDestinoField = value;
			RaisePropertyChanged("CodigoEmpresaDestino");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public int? IDLocalEstoque
	{
		get
		{
			return iDLocalEstoqueField;
		}
		set
		{
			iDLocalEstoqueField = value;
			RaisePropertyChanged("IDLocalEstoque");
		}
	}

	[XmlElement(Order = 4)]
	public LocalEstoqueWsModel LocalEstoqueModel
	{
		get
		{
			return localEstoqueModelField;
		}
		set
		{
			localEstoqueModelField = value;
			RaisePropertyChanged("LocalEstoqueModel");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
