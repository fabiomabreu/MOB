using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[XmlInclude(typeof(EnviarProdutoPainelTO))]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class VersaoTO : INotifyPropertyChanged
{
	private int mAJORField;

	private int mINORField;

	private int bUILDField;

	private int rEVISIONField;

	[XmlElement(Order = 0)]
	public int MAJOR
	{
		get
		{
			return mAJORField;
		}
		set
		{
			mAJORField = value;
			RaisePropertyChanged("MAJOR");
		}
	}

	[XmlElement(Order = 1)]
	public int MINOR
	{
		get
		{
			return mINORField;
		}
		set
		{
			mINORField = value;
			RaisePropertyChanged("MINOR");
		}
	}

	[XmlElement(Order = 2)]
	public int BUILD
	{
		get
		{
			return bUILDField;
		}
		set
		{
			bUILDField = value;
			RaisePropertyChanged("BUILD");
		}
	}

	[XmlElement(Order = 3)]
	public int REVISION
	{
		get
		{
			return rEVISIONField;
		}
		set
		{
			rEVISIONField = value;
			RaisePropertyChanged("REVISION");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
