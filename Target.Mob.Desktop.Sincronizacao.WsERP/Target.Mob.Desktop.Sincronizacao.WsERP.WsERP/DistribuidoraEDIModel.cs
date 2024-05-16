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
public class DistribuidoraEDIModel : DistribuidoraEDIWsModel
{
	private int idDistribuidoraEDIField;

	private int idDistribuidoraField;

	[XmlElement(Order = 0)]
	public int IdDistribuidoraEDI
	{
		get
		{
			return idDistribuidoraEDIField;
		}
		set
		{
			idDistribuidoraEDIField = value;
			RaisePropertyChanged("IdDistribuidoraEDI");
		}
	}

	[XmlElement(Order = 1)]
	public int IdDistribuidora
	{
		get
		{
			return idDistribuidoraField;
		}
		set
		{
			idDistribuidoraField = value;
			RaisePropertyChanged("IdDistribuidora");
		}
	}
}
