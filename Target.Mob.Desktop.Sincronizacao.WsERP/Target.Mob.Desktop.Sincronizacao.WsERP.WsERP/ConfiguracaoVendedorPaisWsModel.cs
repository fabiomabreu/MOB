using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorPaisWsModel : INotifyPropertyChanged
{
	private int? iDConfiguracaoVendedorPaisField;

	private int? iDConfiguracaoVendedorField;

	private string codigoPaisField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDConfiguracaoVendedorPais
	{
		get
		{
			return iDConfiguracaoVendedorPaisField;
		}
		set
		{
			iDConfiguracaoVendedorPaisField = value;
			RaisePropertyChanged("IDConfiguracaoVendedorPais");
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

	[XmlElement(Order = 2)]
	public string CodigoPais
	{
		get
		{
			return codigoPaisField;
		}
		set
		{
			codigoPaisField = value;
			RaisePropertyChanged("CodigoPais");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
