using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "AddressLocation", Namespace = "http://webservices.maplink2.com.br")]
public class AddressLocation : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private string keyField;

	private Address addressField;

	[OptionalField]
	private string zipLField;

	[OptionalField]
	private string zipRField;

	private bool carAccessField;

	[OptionalField]
	private string dataSourceField;

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
	public string key
	{
		get
		{
			return keyField;
		}
		set
		{
			if ((object)keyField != value)
			{
				keyField = value;
				RaisePropertyChanged("key");
			}
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
	public Address address
	{
		get
		{
			return addressField;
		}
		set
		{
			if (addressField != value)
			{
				addressField = value;
				RaisePropertyChanged("address");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string zipL
	{
		get
		{
			return zipLField;
		}
		set
		{
			if ((object)zipLField != value)
			{
				zipLField = value;
				RaisePropertyChanged("zipL");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string zipR
	{
		get
		{
			return zipRField;
		}
		set
		{
			if ((object)zipRField != value)
			{
				zipRField = value;
				RaisePropertyChanged("zipR");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 4)]
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

	[DataMember(EmitDefaultValue = false, Order = 5)]
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

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 6)]
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
