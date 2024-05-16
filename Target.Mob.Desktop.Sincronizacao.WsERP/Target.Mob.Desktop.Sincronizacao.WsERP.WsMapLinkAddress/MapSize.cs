using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "MapSize", Namespace = "http://webservices.maplink2.com.br")]
public class MapSize : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private int widthField;

	private int heightField;

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
	public int width
	{
		get
		{
			return widthField;
		}
		set
		{
			if (!widthField.Equals(value))
			{
				widthField = value;
				RaisePropertyChanged("width");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 1)]
	public int height
	{
		get
		{
			return heightField;
		}
		set
		{
			if (!heightField.Equals(value))
			{
				heightField = value;
				RaisePropertyChanged("height");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
