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
public class ServicoModel : ServicoWsModel
{
	private int? frequenciaPadraoField;

	private string descricaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? FrequenciaPadrao
	{
		get
		{
			return frequenciaPadraoField;
		}
		set
		{
			frequenciaPadraoField = value;
			RaisePropertyChanged("FrequenciaPadrao");
		}
	}

	[XmlElement(Order = 1)]
	public string Descricao
	{
		get
		{
			return descricaoField;
		}
		set
		{
			descricaoField = value;
			RaisePropertyChanged("Descricao");
		}
	}
}
