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
public class MonitRetagCPUWsModel : INotifyPropertyChanged
{
	private MonitRetagWsModel monitRetagField;

	private string processoField;

	private int utilizacaoCPUField;

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
	public string Processo
	{
		get
		{
			return processoField;
		}
		set
		{
			processoField = value;
			RaisePropertyChanged("Processo");
		}
	}

	[XmlElement(Order = 2)]
	public int UtilizacaoCPU
	{
		get
		{
			return utilizacaoCPUField;
		}
		set
		{
			utilizacaoCPUField = value;
			RaisePropertyChanged("UtilizacaoCPU");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
