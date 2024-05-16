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
public class RetornoWsModelOfString : INotifyPropertyChanged
{
	private string retornoWsField;

	private LogErroWsModel excecaoField;

	[XmlElement(Order = 0)]
	public string RetornoWs
	{
		get
		{
			return retornoWsField;
		}
		set
		{
			retornoWsField = value;
			RaisePropertyChanged("RetornoWs");
		}
	}

	[XmlElement(Order = 1)]
	public LogErroWsModel Excecao
	{
		get
		{
			return excecaoField;
		}
		set
		{
			excecaoField = value;
			RaisePropertyChanged("Excecao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
