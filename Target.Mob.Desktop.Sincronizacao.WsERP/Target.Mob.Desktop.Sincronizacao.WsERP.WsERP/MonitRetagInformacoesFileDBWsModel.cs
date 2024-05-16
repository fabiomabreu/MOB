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
public class MonitRetagInformacoesFileDBWsModel : INotifyPropertyChanged
{
	private MonitRetagWsModel monitRetagField;

	private string baseDadosField;

	private string fileNameField;

	private long? currentlyAllocatedSpaceField;

	private long? spaceUsedField;

	private long? availableSpaceField;

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
	public string BaseDados
	{
		get
		{
			return baseDadosField;
		}
		set
		{
			baseDadosField = value;
			RaisePropertyChanged("BaseDados");
		}
	}

	[XmlElement(Order = 2)]
	public string FileName
	{
		get
		{
			return fileNameField;
		}
		set
		{
			fileNameField = value;
			RaisePropertyChanged("FileName");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public long? CurrentlyAllocatedSpace
	{
		get
		{
			return currentlyAllocatedSpaceField;
		}
		set
		{
			currentlyAllocatedSpaceField = value;
			RaisePropertyChanged("CurrentlyAllocatedSpace");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public long? SpaceUsed
	{
		get
		{
			return spaceUsedField;
		}
		set
		{
			spaceUsedField = value;
			RaisePropertyChanged("SpaceUsed");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public long? AvailableSpace
	{
		get
		{
			return availableSpaceField;
		}
		set
		{
			availableSpaceField = value;
			RaisePropertyChanged("AvailableSpace");
		}
	}

	[XmlElement(Order = 6)]
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
