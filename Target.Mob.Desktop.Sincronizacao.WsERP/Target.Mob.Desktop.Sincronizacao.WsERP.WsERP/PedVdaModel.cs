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
public class PedVdaModel : PedVdaWsModel
{
	private DateTime? dtRecebimentoField;

	private DateTime? dtImportacaoField;

	private bool? duplicadoField;

	private int? idConexaoField;

	private bool? emailEnviarField;

	private int? emailEnviadoField;

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
	public bool? Duplicado
	{
		get
		{
			return duplicadoField;
		}
		set
		{
			duplicadoField = value;
			RaisePropertyChanged("Duplicado");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
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

	[XmlElement(IsNullable = true, Order = 4)]
	public bool? EmailEnviar
	{
		get
		{
			return emailEnviarField;
		}
		set
		{
			emailEnviarField = value;
			RaisePropertyChanged("EmailEnviar");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public int? EmailEnviado
	{
		get
		{
			return emailEnviadoField;
		}
		set
		{
			emailEnviadoField = value;
			RaisePropertyChanged("EmailEnviado");
		}
	}
}
