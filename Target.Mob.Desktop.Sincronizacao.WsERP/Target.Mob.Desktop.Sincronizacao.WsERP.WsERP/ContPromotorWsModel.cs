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
public class ContPromotorWsModel : INotifyPropertyChanged
{
	private int contPromotorIdField;

	private string cdPromotorField;

	private string nomeField;

	private string cargoField;

	private byte[] rowIdField;

	[XmlElement(Order = 0)]
	public int ContPromotorId
	{
		get
		{
			return contPromotorIdField;
		}
		set
		{
			contPromotorIdField = value;
			RaisePropertyChanged("ContPromotorId");
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
	public string Nome
	{
		get
		{
			return nomeField;
		}
		set
		{
			nomeField = value;
			RaisePropertyChanged("Nome");
		}
	}

	[XmlElement(Order = 3)]
	public string Cargo
	{
		get
		{
			return cargoField;
		}
		set
		{
			cargoField = value;
			RaisePropertyChanged("Cargo");
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
