using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class LogErroWsTO : INotifyPropertyChanged
{
	private string classeField;

	private DateTime dataField;

	private string erroField;

	private int iDLogErroField;

	private string metodoField;

	private string origemField;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
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
