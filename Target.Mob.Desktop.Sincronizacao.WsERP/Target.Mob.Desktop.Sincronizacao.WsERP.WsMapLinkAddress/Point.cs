using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "Point", Namespace = "http://webservices.maplink2.com.br")]
public class Point : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private double xField;

	private double yField;

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
	public double x
	{
		get
		{
			return xField;
		}
		set
		{
			if (!xField.Equals(value))
			{
				xField = value;
				RaisePropertyChanged("x");
			}
		}
	}

	[DataMember(IsRequired = true)]
	public double y
	{
		get
		{
			return yField;
		}
		set
		{
			if (!yField.Equals(value))
			{
				yField = value;
				RaisePropertyChanged("y");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
