using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(TrocaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class TrocaWsModel : INotifyPropertyChanged
{
	private int iDTrocaField;

	private int codigoTrocaPocketField;

	private DateTime dtTrocaField;

	private int codigoEmpresaField;

	private string codigoTabPreField;

	private string localArmazenamentoTrocaField;

	private decimal valorRecebidoField;

	private int? notaFiscalField;

	private string statusTrocaField;

	private int codigoClienteField;

	private int iDVendedorField;

	private ItTrocaWsModel[] itTrocaWsField;

	private bool? clienteBDMovimentoField;

	private string cnpjCpfClienteField;

	private string codigoMotivoTrocaField;

	private bool? indenizacaoField;

	private int? numeroPedVdaField;

	private int? idPedVdaField;

	private string codigoPaisField;

	private int? codigoClienteProspeccaoField;

	[XmlElement(Order = 0)]
	public int IDTroca
	{
		get
		{
			return iDTrocaField;
		}
		set
		{
			iDTrocaField = value;
			RaisePropertyChanged("IDTroca");
		}
	}

	[XmlElement(Order = 1)]
	public int CodigoTrocaPocket
	{
		get
		{
			return codigoTrocaPocketField;
		}
		set
		{
			codigoTrocaPocketField = value;
			RaisePropertyChanged("CodigoTrocaPocket");
		}
	}

	[XmlElement(Order = 2)]
	public DateTime DtTroca
	{
		get
		{
			return dtTrocaField;
		}
		set
		{
			dtTrocaField = value;
			RaisePropertyChanged("DtTroca");
		}
	}

	[XmlElement(Order = 3)]
	public int CodigoEmpresa
	{
		get
		{
			return codigoEmpresaField;
		}
		set
		{
			codigoEmpresaField = value;
			RaisePropertyChanged("CodigoEmpresa");
		}
	}

	[XmlElement(Order = 4)]
	public string CodigoTabPre
	{
		get
		{
			return codigoTabPreField;
		}
		set
		{
			codigoTabPreField = value;
			RaisePropertyChanged("CodigoTabPre");
		}
	}

	[XmlElement(Order = 5)]
	public string LocalArmazenamentoTroca
	{
		get
		{
			return localArmazenamentoTrocaField;
		}
		set
		{
			localArmazenamentoTrocaField = value;
			RaisePropertyChanged("LocalArmazenamentoTroca");
		}
	}

	[XmlElement(Order = 6)]
	public decimal ValorRecebido
	{
		get
		{
			return valorRecebidoField;
		}
		set
		{
			valorRecebidoField = value;
			RaisePropertyChanged("ValorRecebido");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public int? NotaFiscal
	{
		get
		{
			return notaFiscalField;
		}
		set
		{
			notaFiscalField = value;
			RaisePropertyChanged("NotaFiscal");
		}
	}

	[XmlElement(Order = 8)]
	public string StatusTroca
	{
		get
		{
			return statusTrocaField;
		}
		set
		{
			statusTrocaField = value;
			RaisePropertyChanged("StatusTroca");
		}
	}

	[XmlElement(Order = 9)]
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

	[XmlElement(Order = 10)]
	public int IDVendedor
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

	[XmlArray(Order = 11)]
	public ItTrocaWsModel[] ItTrocaWs
	{
		get
		{
			return itTrocaWsField;
		}
		set
		{
			itTrocaWsField = value;
			RaisePropertyChanged("ItTrocaWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
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

	[XmlElement(Order = 13)]
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

	[XmlElement(Order = 14)]
	public string CodigoMotivoTroca
	{
		get
		{
			return codigoMotivoTrocaField;
		}
		set
		{
			codigoMotivoTrocaField = value;
			RaisePropertyChanged("CodigoMotivoTroca");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public bool? Indenizacao
	{
		get
		{
			return indenizacaoField;
		}
		set
		{
			indenizacaoField = value;
			RaisePropertyChanged("Indenizacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public int? NumeroPedVda
	{
		get
		{
			return numeroPedVdaField;
		}
		set
		{
			numeroPedVdaField = value;
			RaisePropertyChanged("NumeroPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public int? IdPedVda
	{
		get
		{
			return idPedVdaField;
		}
		set
		{
			idPedVdaField = value;
			RaisePropertyChanged("IdPedVda");
		}
	}

	[XmlElement(Order = 18)]
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

	[XmlElement(IsNullable = true, Order = 19)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
