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
public class ProdutoVersaoModel : ProdutoVersaoWsModel
{
	private string conteudoField;

	private DateTime dataField;

	[XmlElement(Order = 0)]
	public string Conteudo
	{
		get
		{
			return conteudoField;
		}
		set
		{
			conteudoField = value;
			RaisePropertyChanged("Conteudo");
		}
	}

	[XmlElement(Order = 1)]
	public DateTime Data
	{
		get
		{
			return dataField;
		}
		set
		{
			dataField = value;
			RaisePropertyChanged("Data");
		}
	}
}
