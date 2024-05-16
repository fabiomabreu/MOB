using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class RetornoWsTOOfBoolean : INotifyPropertyChanged
{
	private LogErroWsTO eXCECAOField;

	private bool rETORNO_WSField;

	private UnetTO uNETField;

	private int iD_DISTRIBUIDORAField;

	private string nOMEField;

	[XmlElement(Order = 0)]
	public LogErroWsTO EXCECAO
	{
		get
		{
			return eXCECAOField;
		}
		set
		{
			eXCECAOField = value;
			RaisePropertyChanged("EXCECAO");
		}
	}

	[XmlElement(Order = 1)]
	public bool RETORNO_WS
	{
		get
		{
			return rETORNO_WSField;
		}
		set
		{
			rETORNO_WSField = value;
			RaisePropertyChanged("RETORNO_WS");
		}
	}

	[XmlElement(Order = 2)]
	public UnetTO UNET
	{
		get
		{
			return uNETField;
		}
		set
		{
			uNETField = value;
			RaisePropertyChanged("UNET");
		}
	}

	[XmlElement(Order = 3)]
	public int ID_DISTRIBUIDORA
	{
		get
		{
			return iD_DISTRIBUIDORAField;
		}
		set
		{
			iD_DISTRIBUIDORAField = value;
			RaisePropertyChanged("ID_DISTRIBUIDORA");
		}
	}

	[XmlElement(Order = 4)]
	public string NOME
	{
		get
		{
			return nOMEField;
		}
		set
		{
			nOMEField = value;
			RaisePropertyChanged("NOME");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
