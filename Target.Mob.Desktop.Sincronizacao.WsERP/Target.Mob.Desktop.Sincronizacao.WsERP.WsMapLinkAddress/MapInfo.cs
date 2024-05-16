using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "MapInfo", Namespace = "http://webservices.maplink2.com.br")]
public class MapInfo : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private string urlField;

	private Extent extentField;

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
	public string url
	{
		get
		{
			return urlField;
		}
		set
		{
			if ((object)urlField != value)
			{
				urlField = value;
				RaisePropertyChanged("url");
			}
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
	public Extent extent
	{
		get
		{
			return extentField;
		}
		set
		{
			if (extentField != value)
			{
				extentField = value;
				RaisePropertyChanged("extent");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
