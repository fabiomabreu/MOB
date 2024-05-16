using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsMapLinkAddress;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "ResultRange", Namespace = "http://webservices.maplink2.com.br")]
public class ResultRange : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	private int pageIndexField;

	private int recordsPerPageField;

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
	public int pageIndex
	{
		get
		{
			return pageIndexField;
		}
		set
		{
			if (!pageIndexField.Equals(value))
			{
				pageIndexField = value;
				RaisePropertyChanged("pageIndex");
			}
		}
	}

	[DataMember(IsRequired = true)]
	public int recordsPerPage
	{
		get
		{
			return recordsPerPageField;
		}
		set
		{
			if (!recordsPerPageField.Equals(value))
			{
				recordsPerPageField = value;
				RaisePropertyChanged("recordsPerPage");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
