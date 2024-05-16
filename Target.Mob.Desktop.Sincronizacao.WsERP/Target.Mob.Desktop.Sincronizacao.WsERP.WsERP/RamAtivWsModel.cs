using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(RamAtivModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class RamAtivWsModel : INotifyPropertyChanged
{
	private string codigoField;

	private string descricaoField;

	private bool? ativoField;

	private short? qtdeCheckOutField;

	private int? ramAtivIdField;

	private byte[] rowIdField;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
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

	[XmlElement(IsNullable = true, Order = 3)]
	public short? QtdeCheckOut
	{
		get
		{
			return qtdeCheckOutField;
		}
		set
		{
			qtdeCheckOutField = value;
			RaisePropertyChanged("QtdeCheckOut");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public int? RamAtivId
	{
		get
		{
			return ramAtivIdField;
		}
		set
		{
			ramAtivIdField = value;
			RaisePropertyChanged("RamAtivId");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 5)]
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
