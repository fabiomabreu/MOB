using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "AddressOptions", Namespace = "http://webservices.maplink2.com.br")]
public class AddressOptions : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private int matchTypeField;

	private bool usePhoneticField;

	private int searchTypeField;

	private ResultRange resultRangeField;

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
	public int matchType
	{
		get
		{
			return matchTypeField;
		}
		set
		{
			if (!matchTypeField.Equals(value))
			{
				matchTypeField = value;
				RaisePropertyChanged("matchType");
			}
		}
	}

	[DataMember(IsRequired = true)]
	public bool usePhonetic
	{
		get
		{
			return usePhoneticField;
		}
		set
		{
			if (!usePhoneticField.Equals(value))
			{
				usePhoneticField = value;
				RaisePropertyChanged("usePhonetic");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 2)]
	public int searchType
	{
		get
		{
			return searchTypeField;
		}
		set
		{
			if (!searchTypeField.Equals(value))
			{
				searchTypeField = value;
				RaisePropertyChanged("searchType");
			}
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
	public ResultRange resultRange
	{
		get
		{
			return resultRangeField;
		}
		set
		{
			if (resultRangeField != value)
			{
				resultRangeField = value;
				RaisePropertyChanged("resultRange");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
