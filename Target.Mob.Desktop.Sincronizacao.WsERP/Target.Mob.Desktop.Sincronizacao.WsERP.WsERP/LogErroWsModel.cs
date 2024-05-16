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
public class LogErroWsModel : INotifyPropertyChanged
{
	private int iDLogErroField;

	private DateTime dataField;

	private string classeField;

	private string metodoField;

	private string erroField;

	private string origemField;

	[XmlElement(Order = 0)]
	public int IDLogErro
	{
		get
		{
			return iDLogErroField;
		}
		set
		{
			iDLogErroField = value;
			RaisePropertyChanged("IDLogErro");
		}
	}

	[XmlElement(Order = 1)]
	public DateTime Data
	{
		get
		{
			return dataField;
		}
		set
		{
			dataField = value;
			RaisePropertyChanged("Data");
		}
	}

	[XmlElement(Order = 2)]
	public string Classe
	{
		get
		{
			return classeField;
		}
		set
		{
			classeField = value;
			RaisePropertyChanged("Classe");
		}
	}

	[XmlElement(Order = 3)]
	public string Metodo
	{
		get
		{
			return metodoField;
		}
		set
		{
			metodoField = value;
			RaisePropertyChanged("Metodo");
		}
	}

	[XmlElement(Order = 4)]
	public string Erro
	{
		get
		{
			return erroField;
		}
		set
		{
			erroField = value;
			RaisePropertyChanged("Erro");
		}
	}

	[XmlElement(Order = 5)]
	public string Origem
	{
		get
		{
			return origemField;
		}
		set
		{
			origemField = value;
			RaisePropertyChanged("Origem");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
