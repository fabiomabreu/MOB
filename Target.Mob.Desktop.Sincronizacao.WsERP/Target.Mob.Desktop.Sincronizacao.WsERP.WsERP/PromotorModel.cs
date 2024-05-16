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
public class PromotorModel : PromotorWsModel
{
	private bool? permiteEnviarArquivoSuporteField;

	[XmlElement(IsNullable = true, Order = 0)]
	public bool? PermiteEnviarArquivoSuporte
	{
		get
		{
			return permiteEnviarArquivoSuporteField;
		}
		set
		{
			permiteEnviarArquivoSuporteField = value;
			RaisePropertyChanged("PermiteEnviarArquivoSuporte");
		}
	}
}
