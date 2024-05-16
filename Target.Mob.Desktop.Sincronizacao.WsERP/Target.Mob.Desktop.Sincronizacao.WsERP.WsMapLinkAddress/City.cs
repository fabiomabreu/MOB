using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "City", Namespace = "http://webservices.maplink2.com.br")]
public class City : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private string nameField;

	[OptionalField]
	private string stateField;

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

	[DataMember(EmitDefaultValue = false)]
	public string state
	{
		get
		{
			return stateField;
		}
		set
		{
			if ((object)stateField != value)
			{
				stateField = value;
				RaisePropertyChanged("state");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
