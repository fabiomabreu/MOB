using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "POILocation", Namespace = "http://webservices.maplink2.com.br")]
public class POILocation : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private string nameField;

	[OptionalField]
	private string districtField;

	private bool carAccessField;

	[OptionalField]
	private string dataSourceField;

	private City cityField;

	private Point pointField;

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

	[DataMember(EmitDefaultValue = false)]
	public string name
	{
		get
		{
			return nameField;
		}
		set
		{
			if ((object)nameField != value)
			{
				nameField = value;
				RaisePropertyChanged("name");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string district
	{
		get
		{
			return districtField;
		}
		set
		{
			if ((object)districtField != value)
			{
				districtField = value;
				RaisePropertyChanged("district");
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
	public string dataSource
	{
		get
		{
			return dataSourceField;
		}
		set
		{
			if ((object)dataSourceField != value)
			{
				dataSourceField = value;
				RaisePropertyChanged("dataSource");
			}
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 4)]
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

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 5)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
