using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CrossStreetLocation", Namespace = "http://webservices.maplink2.com.br")]
public class CrossStreetLocation : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private City cityField;

	private Point pointField;

	[OptionalField]
	private string crossStreetField;

	[OptionalField]
	private string districtField;

	[OptionalField]
	private string streetField;

	[OptionalField]
	private string zipField;

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

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string crossStreet
	{
		get
		{
			return crossStreetField;
		}
		set
		{
			if ((object)crossStreetField != value)
			{
				crossStreetField = value;
				RaisePropertyChanged("crossStreet");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 3)]
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

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string street
	{
		get
		{
			return streetField;
		}
		set
		{
			if ((object)streetField != value)
			{
				streetField = value;
				RaisePropertyChanged("street");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string zip
	{
		get
		{
			return zipField;
		}
		set
		{
			if ((object)zipField != value)
			{
				zipField = value;
				RaisePropertyChanged("zip");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
