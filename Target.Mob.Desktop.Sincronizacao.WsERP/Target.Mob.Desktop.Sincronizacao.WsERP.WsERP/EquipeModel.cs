using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class EquipeModel : EquipeWsModel
{
	private int idEquipeField;

	private string descricaoEmpField;

	private string cdEquipeEmpField;

	[XmlElement(Order = 0)]
	public int IdEquipe
	{
		get
		{
			return idEquipeField;
		}
		set
		{
			idEquipeField = value;
			RaisePropertyChanged("IdEquipe");
		}
	}

	[XmlElement(Order = 1)]
	public string DescricaoEmp
	{
		get
		{
			return descricaoEmpField;
		}
		set
		{
			descricaoEmpField = value;
			RaisePropertyChanged("DescricaoEmp");
		}
	}

	[XmlElement(Order = 2)]
	public string CdEquipeEmp
	{
		get
		{
			return cdEquipeEmpField;
		}
		set
		{
			cdEquipeEmpField = value;
			RaisePropertyChanged("CdEquipeEmp");
		}
	}
}
