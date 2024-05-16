using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CityLocation", Namespace = "http://webservices.maplink2.com.br")]
public class CityLocation : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private City cityField;

	private Point pointField;

	private bool carAccessField;

	[OptionalField]
	private string zipRangeStartField;

	[OptionalField]
	private string zipRangeEndField;

	private bool capitalField;

	[Browsable(false)]
	public ExtensionDataObject ExtensionData
	{
		get
		{
			return extensionDataField;
		}
		set
		{
			extensionDataField = value;
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false)]
	public City city
	{
		get
		{
			return cityField;
		}
		set
		{
			if (cityField != value)
			{
				cityField = value;
				RaisePropertyChanged("city");
			}
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false)]
	public Point point
	{
		get
		{
			return pointField;
		}
		set
		{
			if (pointField != value)
			{
				pointField = value;
				RaisePropertyChanged("point");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 2)]
	public bool carAccess
	{
		get
		{
			return carAccessField;
		}
		set
		{
			if (!carAccessField.Equals(value))
			{
				carAccessField = value;
				RaisePropertyChanged("carAccess");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string zipRangeStart
	{
		get
		{
			return zipRangeStartField;
		}
		set
		{
			if ((object)zipRangeStartField != value)
			{
				zipRangeStartField = value;
				RaisePropertyChanged("zipRangeStart");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string zipRangeEnd
	{
		get
		{
			return zipRangeEndField;
		}
		set
		{
			if ((object)zipRangeEndField != value)
			{
				zipRangeEndField = value;
				RaisePropertyChanged("zipRangeEnd");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 5)]
	public bool capital
	{
		get
		{
			return capitalField;
		}
		set
		{
			if (!capitalField.Equals(value))
			{
				capitalField = value;
				RaisePropertyChanged("capital");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
