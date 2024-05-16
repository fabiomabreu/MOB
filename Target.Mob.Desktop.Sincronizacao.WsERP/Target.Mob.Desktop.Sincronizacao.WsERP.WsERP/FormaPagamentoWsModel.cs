using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(FormaPagamentoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class FormaPagamentoWsModel : INotifyPropertyChanged
{
	private int? iDFormaPagamentoField;

	private string codigoField;

	private string descricaoField;

	private bool? ativoField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDFormaPagamento
	{
		get
		{
			return iDFormaPagamentoField;
		}
		set
		{
			iDFormaPagamentoField = value;
			RaisePropertyChanged("IDFormaPagamento");
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

	[XmlElement(DataType = "base64Binary", Order = 4)]
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
