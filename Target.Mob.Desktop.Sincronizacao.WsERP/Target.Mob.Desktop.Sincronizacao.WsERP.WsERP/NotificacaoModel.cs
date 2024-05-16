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
public class NotificacaoModel : NotificacaoWsModel
{
	private int idNotificacaoField;

	private VendedorModel vendedorField;

	private int? automaticoField;

	private DateTime? dtRecebimentoField;

	[XmlElement(Order = 0)]
	public int IdNotificacao
	{
		get
		{
			return idNotificacaoField;
		}
		set
		{
			idNotificacaoField = value;
			RaisePropertyChanged("IdNotificacao");
		}
	}

	[XmlElement(Order = 1)]
	public VendedorModel Vendedor
	{
		get
		{
			return vendedorField;
		}
		set
		{
			vendedorField = value;
			RaisePropertyChanged("Vendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? Automatico
	{
		get
		{
			return automaticoField;
		}
		set
		{
			automaticoField = value;
			RaisePropertyChanged("Automatico");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
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
}
