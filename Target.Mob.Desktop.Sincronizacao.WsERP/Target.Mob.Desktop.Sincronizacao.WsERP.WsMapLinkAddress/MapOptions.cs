using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "MapOptions", Namespace = "http://webservices.maplink2.com.br")]
public class MapOptions : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private bool scaleBarField;

	private MapSize mapSizeField;

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
	public bool scaleBar
	{
		get
		{
			return scaleBarField;
		}
		set
		{
			if (!scaleBarField.Equals(value))
			{
				scaleBarField = value;
				RaisePropertyChanged("scaleBar");
			}
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
	public MapSize mapSize
	{
		get
		{
			return mapSizeField;
		}
		set
		{
			if (mapSizeField != value)
			{
				mapSizeField = value;
				RaisePropertyChanged("mapSize");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
