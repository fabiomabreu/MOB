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
public class RelatorioGerencialModel : RelatorioGerencialWsModel
{
	private int? idConexaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IdConexao
	{
		get
		{
			return idConexaoField;
		}
		set
		{
			idConexaoField = value;
			RaisePropertyChanged("IdConexao");
		}
	}
}