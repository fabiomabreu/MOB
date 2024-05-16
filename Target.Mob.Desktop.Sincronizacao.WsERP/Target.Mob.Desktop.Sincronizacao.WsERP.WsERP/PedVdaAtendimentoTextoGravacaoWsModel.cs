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
public class PedVdaAtendimentoTextoGravacaoWsModel : INotifyPropertyChanged
{
	private int? idPedVdaAtendimentoTextoGravacaoField;

	private int idPedVdaAtendimentoField;

	private short nuLinhaField;

	private string textoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? idPedVdaAtendimentoTextoGravacao
	{
		get
		{
			return idPedVdaAtendimentoTextoGravacaoField;
		}
		set
		{
			idPedVdaAtendimentoTextoGravacaoField = value;
			RaisePropertyChanged("idPedVdaAtendimentoTextoGravacao");
		}
	}

	[XmlElement(Order = 1)]
	public int idPedVdaAtendimento
	{
		get
		{
			return idPedVdaAtendimentoField;
		}
		set
		{
			idPedVdaAtendimentoField = value;
			RaisePropertyChanged("idPedVdaAtendimento");
		}
	}

	[XmlElement(Order = 2)]
	public short nuLinha
	{
		get
		{
			return nuLinhaField;
		}
		set
		{
			nuLinhaField = value;
			RaisePropertyChanged("nuLinha");
		}
	}

	[XmlElement(Order = 3)]
	public string texto
	{
		get
		{
			return textoField;
		}
		set
		{
			textoField = value;
			RaisePropertyChanged("texto");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
