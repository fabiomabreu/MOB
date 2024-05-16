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
public class UnetTO : BaseTO
{
	private int idField;

	private string dESCRICAOField;

	private string eMAILField;

	private string eMAIL_EQUIPEField;

	[XmlElement(Order = 0)]
	public int ID
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
			RaisePropertyChanged("ID");
		}
	}

	[XmlElement(Order = 1)]
	public string DESCRICAO
	{
		get
		{
			return dESCRICAOField;
		}
		set
		{
			dESCRICAOField = value;
			RaisePropertyChanged("DESCRICAO");
		}
	}

	[XmlElement(Order = 2)]
	public string EMAIL
	{
		get
		{
			return eMAILField;
		}
		set
		{
			eMAILField = value;
			RaisePropertyChanged("EMAIL");
		}
	}

	[XmlElement(Order = 3)]
	public string EMAIL_EQUIPE
	{
		get
		{
			return eMAIL_EQUIPEField;
		}
		set
		{
			eMAIL_EQUIPEField = value;
			RaisePropertyChanged("EMAIL_EQUIPE");
		}
	}
}
