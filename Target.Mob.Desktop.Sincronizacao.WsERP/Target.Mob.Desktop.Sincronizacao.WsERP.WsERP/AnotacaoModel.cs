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
public class AnotacaoModel : AnotacaoWsModel
{
	private DateTime? dtRecebimentoField;

	private DateTime? dtImportacaoField;

	private int? idConexaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public DateTime? DtRecebimento
	{
		get
		{
			return dtRecebimentoField;
		}
		set
		{
			dtRecebimentoField = value;
			RaisePropertyChanged("DtRecebimento");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public DateTime? DtImportacao
	{
		get
		{
			return dtImportacaoField;
		}
		set
		{
			dtImportacaoField = value;
			RaisePropertyChanged("DtImportacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
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
