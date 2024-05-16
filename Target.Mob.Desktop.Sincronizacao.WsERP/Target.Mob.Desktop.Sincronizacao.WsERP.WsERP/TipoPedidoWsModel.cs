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
public class TipoPedidoWsModel : INotifyPropertyChanged
{
	private int? iDTipoPedidoField;

	private string codigoField;

	private string descricaoField;

	private bool? ativoField;

	private bool? bonificacaoField;

	private bool? estatComField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDTipoPedido
	{
		get
		{
			return iDTipoPedidoField;
		}
		set
		{
			iDTipoPedidoField = value;
			RaisePropertyChanged("IDTipoPedido");
		}
	}

	[XmlElement(Order = 1)]
	public string Codigo
	{
		get
		{
			return codigoField;
		}
		set
		{
			codigoField = value;
			RaisePropertyChanged("Codigo");
		}
	}

	[XmlElement(Order = 2)]
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

	[XmlElement(IsNullable = true, Order = 3)]
	public bool? Ativo
	{
		get
		{
			return ativoField;
		}
		set
		{
			ativoField = value;
			RaisePropertyChanged("Ativo");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public bool? Bonificacao
	{
		get
		{
			return bonificacaoField;
		}
		set
		{
			bonificacaoField = value;
			RaisePropertyChanged("Bonificacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public bool? EstatCom
	{
		get
		{
			return estatComField;
		}
		set
		{
			estatComField = value;
			RaisePropertyChanged("EstatCom");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 6)]
	public byte[] RowId
	{
		get
		{
			return rowIdField;
		}
		set
		{
			rowIdField = value;
			RaisePropertyChanged("RowId");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
