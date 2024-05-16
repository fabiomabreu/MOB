using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(DistribuidoraEDIModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class DistribuidoraEDIWsModel : INotifyPropertyChanged
{
	private int? majorField;

	private int? minorField;

	private int? buildField;

	private int? revisionField;

	private DateTime? dataAtualizacaoField;

	private EDIHabilitadosWsModel[] eDIHabilitadosWsField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? Major
	{
		get
		{
			return majorField;
		}
		set
		{
			majorField = value;
			RaisePropertyChanged("Major");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? Minor
	{
		get
		{
			return minorField;
		}
		set
		{
			minorField = value;
			RaisePropertyChanged("Minor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? Build
	{
		get
		{
			return buildField;
		}
		set
		{
			buildField = value;
			RaisePropertyChanged("Build");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public int? Revision
	{
		get
		{
			return revisionField;
		}
		set
		{
			revisionField = value;
			RaisePropertyChanged("Revision");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public DateTime? DataAtualizacao
	{
		get
		{
			return dataAtualizacaoField;
		}
		set
		{
			dataAtualizacaoField = value;
			RaisePropertyChanged("DataAtualizacao");
		}
	}

	[XmlArray(Order = 5)]
	public EDIHabilitadosWsModel[] EDIHabilitadosWs
	{
		get
		{
			return eDIHabilitadosWsField;
		}
		set
		{
			eDIHabilitadosWsField = value;
			RaisePropertyChanged("EDIHabilitadosWs");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
