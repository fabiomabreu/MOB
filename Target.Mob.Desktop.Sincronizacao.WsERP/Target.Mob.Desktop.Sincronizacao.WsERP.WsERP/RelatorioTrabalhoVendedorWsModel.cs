using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(RelatorioTrabalhoVendedorModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class RelatorioTrabalhoVendedorWsModel : INotifyPropertyChanged
{
	private int idRelatorioTrabalhoVendedorField;

	private DateTime dataField;

	private int? iDVendedorField;

	private string codigoVendedorField;

	private string nomeField;

	private int? qtdeVisitasRoteiroProgramadasField;

	private int? qtdeVisitasRoteiroRealizadasField;

	private int? qtdeVisitasForaRoteiroField;

	private int? qtdePedidosField;

	private int? qtdePedidosRoteiroField;

	private int? qtdePedidosRoteiroClienteField;

	private int? qtdePedidosForaRoteiroField;

	private int? qtdePedidosForaRoteiroClienteField;

	private decimal? kmRodadoField;

	private DateTime? dataInicioTrabalhoField;

	private DateTime? dataFimTrabalhoField;

	private int? tempoImprodutivoField;

	private int? tempoClienteField;

	private int? tempoClienteRotaField;

	private int? tempoClienteForaField;

	private int? tempoAlmocoField;

	private int? tempoTotalField;

	private DateTime? dataInicioAlmocoField;

	private DateTime? dataFimAlmocoField;

	private decimal? kmRodadoTotalField;

	private byte[] rowIdField;

	private decimal? kmAjudaCustoField;

	private decimal? kmPrevistoInicioField;

	private decimal? kmPrevistoFimField;

	private decimal? kmPrevistoRoteiroField;

	private string kmAjudaCustoDescricaoField;

	[XmlElement(Order = 0)]
	public int IdRelatorioTrabalhoVendedor
	{
		get
		{
			return idRelatorioTrabalhoVendedorField;
		}
		set
		{
			idRelatorioTrabalhoVendedorField = value;
			RaisePropertyChanged("IdRelatorioTrabalhoVendedor");
		}
	}

	[XmlElement(Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
	public int? IDVendedor
	{
		get
		{
			return iDVendedorField;
		}
		set
		{
			iDVendedorField = value;
			RaisePropertyChanged("IDVendedor");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
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

	[XmlElement(IsNullable = true, Order = 5)]
	public int? QtdeVisitasRoteiroProgramadas
	{
		get
		{
			return qtdeVisitasRoteiroProgramadasField;
		}
		set
		{
			qtdeVisitasRoteiroProgramadasField = value;
			RaisePropertyChanged("QtdeVisitasRoteiroProgramadas");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public int? QtdeVisitasRoteiroRealizadas
	{
		get
		{
			return qtdeVisitasRoteiroRealizadasField;
		}
		set
		{
			qtdeVisitasRoteiroRealizadasField = value;
			RaisePropertyChanged("QtdeVisitasRoteiroRealizadas");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public int? QtdeVisitasForaRoteiro
	{
		get
		{
			return qtdeVisitasForaRoteiroField;
		}
		set
		{
			qtdeVisitasForaRoteiroField = value;
			RaisePropertyChanged("QtdeVisitasForaRoteiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public int? QtdePedidos
	{
		get
		{
			return qtdePedidosField;
		}
		set
		{
			qtdePedidosField = value;
			RaisePropertyChanged("QtdePedidos");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public int? QtdePedidosRoteiro
	{
		get
		{
			return qtdePedidosRoteiroField;
		}
		set
		{
			qtdePedidosRoteiroField = value;
			RaisePropertyChanged("QtdePedidosRoteiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public int? QtdePedidosRoteiroCliente
	{
		get
		{
			return qtdePedidosRoteiroClienteField;
		}
		set
		{
			qtdePedidosRoteiroClienteField = value;
			RaisePropertyChanged("QtdePedidosRoteiroCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public int? QtdePedidosForaRoteiro
	{
		get
		{
			return qtdePedidosForaRoteiroField;
		}
		set
		{
			qtdePedidosForaRoteiroField = value;
			RaisePropertyChanged("QtdePedidosForaRoteiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public int? QtdePedidosForaRoteiroCliente
	{
		get
		{
			return qtdePedidosForaRoteiroClienteField;
		}
		set
		{
			qtdePedidosForaRoteiroClienteField = value;
			RaisePropertyChanged("QtdePedidosForaRoteiroCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public decimal? KmRodado
	{
		get
		{
			return kmRodadoField;
		}
		set
		{
			kmRodadoField = value;
			RaisePropertyChanged("KmRodado");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public DateTime? DataInicioTrabalho
	{
		get
		{
			return dataInicioTrabalhoField;
		}
		set
		{
			dataInicioTrabalhoField = value;
			RaisePropertyChanged("DataInicioTrabalho");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public DateTime? DataFimTrabalho
	{
		get
		{
			return dataFimTrabalhoField;
		}
		set
		{
			dataFimTrabalhoField = value;
			RaisePropertyChanged("DataFimTrabalho");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public int? TempoImprodutivo
	{
		get
		{
			return tempoImprodutivoField;
		}
		set
		{
			tempoImprodutivoField = value;
			RaisePropertyChanged("TempoImprodutivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public int? TempoCliente
	{
		get
		{
			return tempoClienteField;
		}
		set
		{
			tempoClienteField = value;
			RaisePropertyChanged("TempoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 18)]
	public int? TempoClienteRota
	{
		get
		{
			return tempoClienteRotaField;
		}
		set
		{
			tempoClienteRotaField = value;
			RaisePropertyChanged("TempoClienteRota");
		}
	}

	[XmlElement(IsNullable = true, Order = 19)]
	public int? TempoClienteFora
	{
		get
		{
			return tempoClienteForaField;
		}
		set
		{
			tempoClienteForaField = value;
			RaisePropertyChanged("TempoClienteFora");
		}
	}

	[XmlElement(IsNullable = true, Order = 20)]
	public int? TempoAlmoco
	{
		get
		{
			return tempoAlmocoField;
		}
		set
		{
			tempoAlmocoField = value;
			RaisePropertyChanged("TempoAlmoco");
		}
	}

	[XmlElement(IsNullable = true, Order = 21)]
	public int? TempoTotal
	{
		get
		{
			return tempoTotalField;
		}
		set
		{
			tempoTotalField = value;
			RaisePropertyChanged("TempoTotal");
		}
	}

	[XmlElement(IsNullable = true, Order = 22)]
	public DateTime? DataInicioAlmoco
	{
		get
		{
			return dataInicioAlmocoField;
		}
		set
		{
			dataInicioAlmocoField = value;
			RaisePropertyChanged("DataInicioAlmoco");
		}
	}

	[XmlElement(IsNullable = true, Order = 23)]
	public DateTime? DataFimAlmoco
	{
		get
		{
			return dataFimAlmocoField;
		}
		set
		{
			dataFimAlmocoField = value;
			RaisePropertyChanged("DataFimAlmoco");
		}
	}

	[XmlElement(IsNullable = true, Order = 24)]
	public decimal? KmRodadoTotal
	{
		get
		{
			return kmRodadoTotalField;
		}
		set
		{
			kmRodadoTotalField = value;
			RaisePropertyChanged("KmRodadoTotal");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 25)]
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

	[XmlElement(IsNullable = true, Order = 26)]
	public decimal? KmAjudaCusto
	{
		get
		{
			return kmAjudaCustoField;
		}
		set
		{
			kmAjudaCustoField = value;
			RaisePropertyChanged("KmAjudaCusto");
		}
	}

	[XmlElement(IsNullable = true, Order = 27)]
	public decimal? KmPrevistoInicio
	{
		get
		{
			return kmPrevistoInicioField;
		}
		set
		{
			kmPrevistoInicioField = value;
			RaisePropertyChanged("KmPrevistoInicio");
		}
	}

	[XmlElement(IsNullable = true, Order = 28)]
	public decimal? KmPrevistoFim
	{
		get
		{
			return kmPrevistoFimField;
		}
		set
		{
			kmPrevistoFimField = value;
			RaisePropertyChanged("KmPrevistoFim");
		}
	}

	[XmlElement(IsNullable = true, Order = 29)]
	public decimal? KmPrevistoRoteiro
	{
		get
		{
			return kmPrevistoRoteiroField;
		}
		set
		{
			kmPrevistoRoteiroField = value;
			RaisePropertyChanged("KmPrevistoRoteiro");
		}
	}

	[XmlElement(Order = 30)]
	public string KmAjudaCustoDescricao
	{
		get
		{
			return kmAjudaCustoDescricaoField;
		}
		set
		{
			kmAjudaCustoDescricaoField = value;
			RaisePropertyChanged("KmAjudaCustoDescricao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
