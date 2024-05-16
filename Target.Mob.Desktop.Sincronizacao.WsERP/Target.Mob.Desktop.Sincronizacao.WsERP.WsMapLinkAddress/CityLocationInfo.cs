using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CityLocationInfo", Namespace = "http://webservices.maplink2.com.br")]
public class CityLocationInfo : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private int recordCountField;

	private int pageCountField;

	[OptionalField]
	private CityLocation[] cityLocationField;

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

	[DataMember(IsRequired = true)]
	public int recordCount
	{
		get
		{
			return recordCountField;
		}
		set
		{
			if (!recordCountField.Equals(value))
			{
				recordCountField = value;
				RaisePropertyChanged("recordCount");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 1)]
	public int pageCount
	{
		get
		{
			return pageCountField;
		}
		set
		{
			if (!pageCountField.Equals(value))
			{
				pageCountField = value;
				RaisePropertyChanged("pageCount");
			}
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public CityLocation[] cityLocation
	{
		get
		{
			return cityLocationField;
		}
		set
		{
			if (cityLocationField != value)
			{
				cityLocationField = value;
				RaisePropertyChanged("cityLocation");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
