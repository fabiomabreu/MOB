using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(PedVdaAtendimentoMensagemModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class PedVdaAtendimentoMensagemWsModel : INotifyPropertyChanged
{
	private int iDPedVdaAtendimentoMensagemField;

	private string codigoSetorMsgField;

	private int? iDPedVdaAtendimentoField;

	private string textoField;

	[XmlElement(Order = 0)]
	public int IDPedVdaAtendimentoMensagem
	{
		get
		{
			return iDPedVdaAtendimentoMensagemField;
		}
		set
		{
			iDPedVdaAtendimentoMensagemField = value;
			RaisePropertyChanged("IDPedVdaAtendimentoMensagem");
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
	public int? IDPedVdaAtendimento
	{
		get
		{
			return iDPedVdaAtendimentoField;
		}
		set
		{
			iDPedVdaAtendimentoField = value;
			RaisePropertyChanged("IDPedVdaAtendimento");
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
