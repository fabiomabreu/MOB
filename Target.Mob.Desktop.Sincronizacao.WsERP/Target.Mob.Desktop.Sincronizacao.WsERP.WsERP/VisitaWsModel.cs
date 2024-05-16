using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(VisitaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class VisitaWsModel : INotifyPropertyChanged
{
	private int? codigoVisitaField;

	private DateTime? dataHoraVisitaField;

	private string tipoFrequenciaVisitaField;

	private int? codigoClienteField;

	private string textoField;

	private int? iDVendedorField;

	private bool? clienteBDMovimentoField;

	private string cnpjCpfClienteField;

	private string tipoOperacaoField;

	private int? seqVisitaField;

	private string codigoPaisField;

	private int? codigoClienteProspeccaoField;

	private int? codigoFrequenciaVisitaField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? CodigoVisita
	{
		get
		{
			return codigoVisitaField;
		}
		set
		{
			codigoVisitaField = value;
			RaisePropertyChanged("CodigoVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public DateTime? DataHoraVisita
	{
		get
		{
			return dataHoraVisitaField;
		}
		set
		{
			dataHoraVisitaField = value;
			RaisePropertyChanged("DataHoraVisita");
		}
	}

	[XmlElement(Order = 2)]
	public string TipoFrequenciaVisita
	{
		get
		{
			return tipoFrequenciaVisitaField;
		}
		set
		{
			tipoFrequenciaVisitaField = value;
			RaisePropertyChanged("TipoFrequenciaVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
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

	[XmlElement(Order = 4)]
	public string Texto
	{
		get
		{
			return textoField;
		}
		set
		{
			textoField = value;
			RaisePropertyChanged("Texto");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
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

	[XmlElement(IsNullable = true, Order = 6)]
	public bool? ClienteBDMovimento
	{
		get
		{
			return clienteBDMovimentoField;
		}
		set
		{
			clienteBDMovimentoField = value;
			RaisePropertyChanged("ClienteBDMovimento");
		}
	}

	[XmlElement(Order = 7)]
	public string CnpjCpfCliente
	{
		get
		{
			return cnpjCpfClienteField;
		}
		set
		{
			cnpjCpfClienteField = value;
			RaisePropertyChanged("CnpjCpfCliente");
		}
	}

	[XmlElement(Order = 8)]
	public string TipoOperacao
	{
		get
		{
			return tipoOperacaoField;
		}
		set
		{
			tipoOperacaoField = value;
			RaisePropertyChanged("TipoOperacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public int? SeqVisita
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

	[XmlElement(Order = 10)]
	public string CodigoPais
	{
		get
		{
			return codigoPaisField;
		}
		set
		{
			codigoPaisField = value;
			RaisePropertyChanged("CodigoPais");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public int? CodigoClienteProspeccao
	{
		get
		{
			return codigoClienteProspeccaoField;
		}
		set
		{
			codigoClienteProspeccaoField = value;
			RaisePropertyChanged("CodigoClienteProspeccao");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public int? CodigoFrequenciaVisita
	{
		get
		{
			return codigoFrequenciaVisitaField;
		}
		set
		{
			codigoFrequenciaVisitaField = value;
			RaisePropertyChanged("CodigoFrequenciaVisita");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
