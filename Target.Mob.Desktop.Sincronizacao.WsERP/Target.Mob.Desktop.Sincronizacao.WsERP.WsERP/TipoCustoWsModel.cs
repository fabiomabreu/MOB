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
public class TipoCustoWsModel : INotifyPropertyChanged
{
	private int? iDTipoCustoField;

	private string codigoField;

	private string descricaoField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDTipoCusto
	{
		get
		{
			return iDTipoCustoField;
		}
		set
		{
			iDTipoCustoField = value;
			RaisePropertyChanged("IDTipoCusto");
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

	[XmlElement(DataType = "base64Binary", Order = 3)]
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
