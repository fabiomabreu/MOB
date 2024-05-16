using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "Extent", Namespace = "http://webservices.maplink2.com.br")]
public class Extent : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private double XMinField;

	private double YMinField;

	private double XMaxField;

	private double YMaxField;

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
	public double XMin
	{
		get
		{
			return XMinField;
		}
		set
		{
			if (!XMinField.Equals(value))
			{
				XMinField = value;
				RaisePropertyChanged("XMin");
			}
		}
	}

	[DataMember(IsRequired = true)]
	public double YMin
	{
		get
		{
			return YMinField;
		}
		set
		{
			if (!YMinField.Equals(value))
			{
				YMinField = value;
				RaisePropertyChanged("YMin");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 2)]
	public double XMax
	{
		get
		{
			return XMaxField;
		}
		set
		{
			if (!XMaxField.Equals(value))
			{
				XMaxField = value;
				RaisePropertyChanged("XMax");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 3)]
	public double YMax
	{
		get
		{
			return YMaxField;
		}
		set
		{
			if (!YMaxField.Equals(value))
			{
				YMaxField = value;
				RaisePropertyChanged("YMax");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
