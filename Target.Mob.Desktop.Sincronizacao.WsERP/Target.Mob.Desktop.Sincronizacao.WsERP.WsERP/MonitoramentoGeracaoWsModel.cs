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
public class MonitoramentoGeracaoWsModel : INotifyPropertyChanged
{
	private int idMonitoramentoGeracaoField;

	private DateTime? dataInicioField;

	private DateTime? dataFimField;

	private int? qtdeVendedoresField;

	private string statusField;

	private byte[] rowIdField;

	[XmlElement(Order = 0)]
	public int IdMonitoramentoGeracao
	{
		get
		{
			return idMonitoramentoGeracaoField;
		}
		set
		{
			idMonitoramentoGeracaoField = value;
			RaisePropertyChanged("IdMonitoramentoGeracao");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public DateTime? DataInicio
	{
		get
		{
			return dataInicioField;
		}
		set
		{
			dataInicioField = value;
			RaisePropertyChanged("DataInicio");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public DateTime? DataFim
	{
		get
		{
			return dataFimField;
		}
		set
		{
			dataFimField = value;
			RaisePropertyChanged("DataFim");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public int? QtdeVendedores
	{
		get
		{
			return qtdeVendedoresField;
		}
		set
		{
			qtdeVendedoresField = value;
			RaisePropertyChanged("QtdeVendedores");
		}
	}

	[XmlElement(Order = 4)]
	public string Status
	{
		get
		{
			return statusField;
		}
		set
		{
			statusField = value;
			RaisePropertyChanged("Status");
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
