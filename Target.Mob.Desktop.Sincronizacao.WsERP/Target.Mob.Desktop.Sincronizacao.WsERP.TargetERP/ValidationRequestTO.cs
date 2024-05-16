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
public class ValidationRequestTO : INotifyPropertyChanged
{
	private string tOKENField;

	private string cNPJ_DISTRIBUIDORAField;

	private string hOSTNAMEField;

	private string cHAVE_RETAGUARDAField;

	private int iD_PRODUTO_PAINELField;

	[XmlElement(Order = 0)]
	public string TOKEN
	{
		get
		{
			return tOKENField;
		}
		set
		{
			tOKENField = value;
			RaisePropertyChanged("TOKEN");
		}
	}

	[XmlElement(Order = 1)]
	public string CNPJ_DISTRIBUIDORA
	{
		get
		{
			return cNPJ_DISTRIBUIDORAField;
		}
		set
		{
			cNPJ_DISTRIBUIDORAField = value;
			RaisePropertyChanged("CNPJ_DISTRIBUIDORA");
		}
	}

	[XmlElement(Order = 2)]
	public string HOSTNAME
	{
		get
		{
			return hOSTNAMEField;
		}
		set
		{
			hOSTNAMEField = value;
			RaisePropertyChanged("HOSTNAME");
		}
	}

	[XmlElement(Order = 3)]
	public string CHAVE_RETAGUARDA
	{
		get
		{
			return cHAVE_RETAGUARDAField;
		}
		set
		{
			cHAVE_RETAGUARDAField = value;
			RaisePropertyChanged("CHAVE_RETAGUARDA");
		}
	}

	[XmlElement(Order = 4)]
	public int ID_PRODUTO_PAINEL
	{
		get
		{
			return iD_PRODUTO_PAINELField;
		}
		set
		{
			iD_PRODUTO_PAINELField = value;
			RaisePropertyChanged("ID_PRODUTO_PAINEL");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
