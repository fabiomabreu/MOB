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
public class MonitRetagEspacoLivreUnidadeWsModel : INotifyPropertyChanged
{
	private MonitRetagWsModel monitRetagField;

	private string unidadeField;

	private long? espacoLivreField;

	private string contextoAppServerField;

	[XmlElement(Order = 0)]
	public MonitRetagWsModel MonitRetag
	{
		get
		{
			return monitRetagField;
		}
		set
		{
			monitRetagField = value;
			RaisePropertyChanged("MonitRetag");
		}
	}

	[XmlElement(Order = 1)]
	public string Unidade
	{
		get
		{
			return unidadeField;
		}
		set
		{
			unidadeField = value;
			RaisePropertyChanged("Unidade");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public long? EspacoLivre
	{
		get
		{
			return espacoLivreField;
		}
		set
		{
			espacoLivreField = value;
			RaisePropertyChanged("EspacoLivre");
		}
	}

	[XmlElement(Order = 3)]
	public string ContextoAppServer
	{
		get
		{
			return contextoAppServerField;
		}
		set
		{
			contextoAppServerField = value;
			RaisePropertyChanged("ContextoAppServer");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
