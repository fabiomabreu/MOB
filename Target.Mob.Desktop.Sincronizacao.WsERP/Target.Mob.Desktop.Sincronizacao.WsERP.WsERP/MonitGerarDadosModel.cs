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
public class MonitGerarDadosModel : MonitGerarDadosWsModel
{
	private int idMonitGerarDadosField;

	private DateTime dtRecebimentoField;

	[XmlElement(Order = 0)]
	public int IdMonitGerarDados
	{
		get
		{
			return idMonitGerarDadosField;
		}
		set
		{
			idMonitGerarDadosField = value;
			RaisePropertyChanged("IdMonitGerarDados");
		}
	}

	[XmlElement(Order = 1)]
	public DateTime DtRecebimento
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
}
