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
public class TelPromotorWsModel : INotifyPropertyChanged
{
	private int? telPromotorIdField;

	private string cdPromotorField;

	private string tpTelField;

	private int? dddField;

	private long? nuTelField;

	private int? ramalField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? TelPromotorId
	{
		get
		{
			return telPromotorIdField;
		}
		set
		{
			telPromotorIdField = value;
			RaisePropertyChanged("TelPromotorId");
		}
	}

	[XmlElement(Order = 1)]
	public string CdPromotor
	{
		get
		{
			return cdPromotorField;
		}
		set
		{
			cdPromotorField = value;
			RaisePropertyChanged("CdPromotor");
		}
	}

	[XmlElement(Order = 2)]
	public string TpTel
	{
		get
		{
			return tpTelField;
		}
		set
		{
			tpTelField = value;
			RaisePropertyChanged("TpTel");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public int? Ddd
	{
		get
		{
			return dddField;
		}
		set
		{
			dddField = value;
			RaisePropertyChanged("Ddd");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public long? NuTel
	{
		get
		{
			return nuTelField;
		}
		set
		{
			nuTelField = value;
			RaisePropertyChanged("NuTel");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public int? Ramal
	{
		get
		{
			return ramalField;
		}
		set
		{
			ramalField = value;
			RaisePropertyChanged("Ramal");
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
