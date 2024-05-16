using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorClienteNovoFormPgtoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorClienteNovoFormPgtoWsModel : INotifyPropertyChanged
{
	private int? idConfiguracaoVendedorClienteNovoFormPgtoField;

	private int? idConfiguracaoVendedorField;

	private string codigoFormPagtoField;

	private bool? padraoField;

	private FormaPagamentoWsModel formaPagamentoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IdConfiguracaoVendedorClienteNovoFormPgto
	{
		get
		{
			return idConfiguracaoVendedorClienteNovoFormPgtoField;
		}
		set
		{
			idConfiguracaoVendedorClienteNovoFormPgtoField = value;
			RaisePropertyChanged("IdConfiguracaoVendedorClienteNovoFormPgto");
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

	[XmlElement(Order = 2)]
	public string CodigoFormPagto
	{
		get
		{
			return codigoFormPagtoField;
		}
		set
		{
			codigoFormPagtoField = value;
			RaisePropertyChanged("CodigoFormPagto");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public bool? Padrao
	{
		get
		{
			return padraoField;
		}
		set
		{
			padraoField = value;
			RaisePropertyChanged("Padrao");
		}
	}

	[XmlElement(Order = 4)]
	public FormaPagamentoWsModel FormaPagamento
	{
		get
		{
			return formaPagamentoField;
		}
		set
		{
			formaPagamentoField = value;
			RaisePropertyChanged("FormaPagamento");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
