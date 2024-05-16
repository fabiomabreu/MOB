using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(CoordenadaRoteiroVendedorPermanenciaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class CoordenadaRoteiroVendedorPermanenciaWsModel : INotifyPropertyChanged
{
	private int idCoordenadaRoteiroVendedorPermanenciaField;

	private int idVendedorField;

	private string codigoVendedorField;

	private DateTime dataField;

	private int codigoClienteField;

	private double horaInicioField;

	private double horaFimField;

	private int roteiroField;

	private int codigoAcaoField;

	private byte[] rowIdField;

	[XmlElement(Order = 0)]
	public int IdCoordenadaRoteiroVendedorPermanencia
	{
		get
		{
			return idCoordenadaRoteiroVendedorPermanenciaField;
		}
		set
		{
			idCoordenadaRoteiroVendedorPermanenciaField = value;
			RaisePropertyChanged("IdCoordenadaRoteiroVendedorPermanencia");
		}
	}

	[XmlElement(Order = 1)]
	public int IdVendedor
	{
		get
		{
			return idVendedorField;
		}
		set
		{
			idVendedorField = value;
			RaisePropertyChanged("IdVendedor");
		}
	}

	[XmlElement(Order = 2)]
	public string CodigoVendedor
	{
		get
		{
			return codigoVendedorField;
		}
		set
		{
			codigoVendedorField = value;
			RaisePropertyChanged("CodigoVendedor");
		}
	}

	[XmlElement(Order = 3)]
	public DateTime Data
	{
		get
		{
			return dataField;
		}
		set
		{
			dataField = value;
			RaisePropertyChanged("Data");
		}
	}

	[XmlElement(Order = 4)]
	public int CodigoCliente
	{
		get
		{
			return codigoClienteField;
		}
		set
		{
			codigoClienteField = value;
			RaisePropertyChanged("CodigoCliente");
		}
	}

	[XmlElement(Order = 5)]
	public double HoraInicio
	{
		get
		{
			return horaInicioField;
		}
		set
		{
			horaInicioField = value;
			RaisePropertyChanged("HoraInicio");
		}
	}

	[XmlElement(Order = 6)]
	public double HoraFim
	{
		get
		{
			return horaFimField;
		}
		set
		{
			horaFimField = value;
			RaisePropertyChanged("HoraFim");
		}
	}

	[XmlElement(Order = 7)]
	public int Roteiro
	{
		get
		{
			return roteiroField;
		}
		set
		{
			roteiroField = value;
			RaisePropertyChanged("Roteiro");
		}
	}

	[XmlElement(Order = 8)]
	public int CodigoAcao
	{
		get
		{
			return codigoAcaoField;
		}
		set
		{
			codigoAcaoField = value;
			RaisePropertyChanged("CodigoAcao");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 9)]
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
