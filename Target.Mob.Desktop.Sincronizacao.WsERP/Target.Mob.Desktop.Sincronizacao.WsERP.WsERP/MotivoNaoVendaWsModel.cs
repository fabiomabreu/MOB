using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(MotivoNaoVendaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class MotivoNaoVendaWsModel : INotifyPropertyChanged
{
	private int? iDMotivoNaoVendaField;

	private int? codigoMotivoNaoVendaField;

	private string codigoMotivoField;

	private DateTime? dataHoraField;

	private bool? comVisitaField;

	private int? codigoEmpresaField;

	private int? numeroPedVdaField;

	private int? codigoProdutoField;

	private string observacaoField;

	private int? iDVendedorField;

	private int? codigoClienteField;

	private bool? clienteBDMovimentoField;

	private string cnpjCpfClienteField;

	private string codigoPaisField;

	private string[] contatoVisitaField;

	private int? codigoClienteProspeccaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDMotivoNaoVenda
	{
		get
		{
			return iDMotivoNaoVendaField;
		}
		set
		{
			iDMotivoNaoVendaField = value;
			RaisePropertyChanged("IDMotivoNaoVenda");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? CodigoMotivoNaoVenda
	{
		get
		{
			return codigoMotivoNaoVendaField;
		}
		set
		{
			codigoMotivoNaoVendaField = value;
			RaisePropertyChanged("CodigoMotivoNaoVenda");
		}
	}

	[XmlElement(Order = 2)]
	public string CodigoMotivo
	{
		get
		{
			return codigoMotivoField;
		}
		set
		{
			codigoMotivoField = value;
			RaisePropertyChanged("CodigoMotivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? DataHora
	{
		get
		{
			return dataHoraField;
		}
		set
		{
			dataHoraField = value;
			RaisePropertyChanged("DataHora");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public bool? ComVisita
	{
		get
		{
			return comVisitaField;
		}
		set
		{
			comVisitaField = value;
			RaisePropertyChanged("ComVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public int? CodigoEmpresa
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

	[XmlElement(IsNullable = true, Order = 6)]
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

	[XmlElement(IsNullable = true, Order = 7)]
	public int? CodigoProduto
	{
		get
		{
			return codigoProdutoField;
		}
		set
		{
			codigoProdutoField = value;
			RaisePropertyChanged("CodigoProduto");
		}
	}

	[XmlElement(Order = 8)]
	public string Observacao
	{
		get
		{
			return observacaoField;
		}
		set
		{
			observacaoField = value;
			RaisePropertyChanged("Observacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
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

	[XmlElement(IsNullable = true, Order = 10)]
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

	[XmlElement(IsNullable = true, Order = 11)]
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

	[XmlElement(Order = 12)]
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

	[XmlElement(Order = 13)]
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

	[XmlArray(Order = 14)]
	public string[] ContatoVisita
	{
		get
		{
			return contatoVisitaField;
		}
		set
		{
			contatoVisitaField = value;
			RaisePropertyChanged("ContatoVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
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
