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
public class FabricanteWsModel : INotifyPropertyChanged
{
	private int? idField;

	private string cdFabricField;

	private string descricaoField;

	private bool? ativoField;

	private bool? envioPalmTopField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? ID
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
			RaisePropertyChanged("ID");
		}
	}

	[XmlElement(Order = 1)]
	public string CdFabric
	{
		get
		{
			return cdFabricField;
		}
		set
		{
			cdFabricField = value;
			RaisePropertyChanged("CdFabric");
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
	public bool? EnvioPalmTop
	{
		get
		{
			return envioPalmTopField;
		}
		set
		{
			envioPalmTopField = value;
			RaisePropertyChanged("EnvioPalmTop");
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
