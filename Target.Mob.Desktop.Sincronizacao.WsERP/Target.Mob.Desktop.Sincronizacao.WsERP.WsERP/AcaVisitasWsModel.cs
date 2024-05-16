using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(AcaVisitasModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class AcaVisitasWsModel : INotifyPropertyChanged
{
	private int seqVisitaField;

	private string codigoVendedorField;

	private int? codigoClienteField;

	private DateTime? dtVisitaField;

	private string hrVisitaField;

	private DateTime? dtUltVisitaField;

	private int? frequenciaVisitaIDField;

	private bool? visitaExcluidaField;

	private string opcoesRotaField;

	private byte[] rowIdField;

	private bool? visitaTelefonicaField;

	[XmlElement(Order = 0)]
	public int SeqVisita
	{
		get
		{
			return seqVisitaField;
		}
		set
		{
			seqVisitaField = value;
			RaisePropertyChanged("SeqVisita");
		}
	}

	[XmlElement(Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
	public int? CodigoCliente
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

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? DtVisita
	{
		get
		{
			return dtVisitaField;
		}
		set
		{
			dtVisitaField = value;
			RaisePropertyChanged("DtVisita");
		}
	}

	[XmlElement(Order = 4)]
	public string HrVisita
	{
		get
		{
			return hrVisitaField;
		}
		set
		{
			hrVisitaField = value;
			RaisePropertyChanged("HrVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public DateTime? DtUltVisita
	{
		get
		{
			return dtUltVisitaField;
		}
		set
		{
			dtUltVisitaField = value;
			RaisePropertyChanged("DtUltVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public int? FrequenciaVisitaID
	{
		get
		{
			return frequenciaVisitaIDField;
		}
		set
		{
			frequenciaVisitaIDField = value;
			RaisePropertyChanged("FrequenciaVisitaID");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public bool? VisitaExcluida
	{
		get
		{
			return visitaExcluidaField;
		}
		set
		{
			visitaExcluidaField = value;
			RaisePropertyChanged("VisitaExcluida");
		}
	}

	[XmlElement(Order = 8)]
	public string OpcoesRota
	{
		get
		{
			return opcoesRotaField;
		}
		set
		{
			opcoesRotaField = value;
			RaisePropertyChanged("OpcoesRota");
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

	[XmlElement(IsNullable = true, Order = 10)]
	public bool? VisitaTelefonica
	{
		get
		{
			return visitaTelefonicaField;
		}
		set
		{
			visitaTelefonicaField = value;
			RaisePropertyChanged("VisitaTelefonica");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
