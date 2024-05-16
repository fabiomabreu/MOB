using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(PedVdaMensagemModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class PedVdaMensagemWsModel : INotifyPropertyChanged
{
	private int? iDPedVdaMensagemField;

	private string codigoSetorMsgField;

	private int? iDPedVdaField;

	private string textoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDPedVdaMensagem
	{
		get
		{
			return iDPedVdaMensagemField;
		}
		set
		{
			iDPedVdaMensagemField = value;
			RaisePropertyChanged("IDPedVdaMensagem");
		}
	}

	[XmlElement(Order = 1)]
	public string CodigoSetorMsg
	{
		get
		{
			return codigoSetorMsgField;
		}
		set
		{
			codigoSetorMsgField = value;
			RaisePropertyChanged("CodigoSetorMsg");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? IDPedVda
	{
		get
		{
			return iDPedVdaField;
		}
		set
		{
			iDPedVdaField = value;
			RaisePropertyChanged("IDPedVda");
		}
	}

	[XmlElement(Order = 3)]
	public string Texto
	{
		get
		{
			return textoField;
		}
		set
		{
			textoField = value;
			RaisePropertyChanged("Texto");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
