using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorOrdenacaoGondolaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorOrdenacaoGondolaWsModel : INotifyPropertyChanged
{
	private int idConfiguracaoVendedorOrdenacaoGondolaField;

	private int? idConfiguracaoVendedorField;

	private int? seqField;

	private string colunaOrdenacaoField;

	private string tipoOrdenacaoField;

	[XmlElement(Order = 0)]
	public int IdConfiguracaoVendedorOrdenacaoGondola
	{
		get
		{
			return idConfiguracaoVendedorOrdenacaoGondolaField;
		}
		set
		{
			idConfiguracaoVendedorOrdenacaoGondolaField = value;
			RaisePropertyChanged("IdConfiguracaoVendedorOrdenacaoGondola");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IdConfiguracaoVendedor
	{
		get
		{
			return idConfiguracaoVendedorField;
		}
		set
		{
			idConfiguracaoVendedorField = value;
			RaisePropertyChanged("IdConfiguracaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? Seq
	{
		get
		{
			return seqField;
		}
		set
		{
			seqField = value;
			RaisePropertyChanged("Seq");
		}
	}

	[XmlElement(Order = 3)]
	public string ColunaOrdenacao
	{
		get
		{
			return colunaOrdenacaoField;
		}
		set
		{
			colunaOrdenacaoField = value;
			RaisePropertyChanged("ColunaOrdenacao");
		}
	}

	[XmlElement(Order = 4)]
	public string TipoOrdenacao
	{
		get
		{
			return tipoOrdenacaoField;
		}
		set
		{
			tipoOrdenacaoField = value;
			RaisePropertyChanged("TipoOrdenacao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
