using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ClienteModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ClienteWsModel : INotifyPropertyChanged
{
	private int codigoClienteField;

	private string razaoSocialField;

	private string nomeFantasiaField;

	private DateTime? dtUltimaCompraField;

	private string codigoStCredField;

	private bool? permiteAlterarTabPreField;

	private int? codigoTransportadoraField;

	private decimal? percDescontoField;

	private bool? produtoControladoField;

	private DateTime? dtPrazoProdutoControladoField;

	private string codigoRamAtivField;

	private string statusAnvisaField;

	private string statusAlvaraField;

	private string codigoTpPedField;

	private string emailField;

	private string webSiteField;

	private string tipoPessoaField;

	private string cnpjCpfField;

	private string tipoInscricaoField;

	private string inscricaoField;

	private DateTime? dtVencAlvaraField;

	private DateTime? dtVencAnvisaField;

	private string tipoFreteField;

	private string textoGeralField;

	private string textoAlertaField;

	private bool? permiteAlterarTpPedField;

	private string codigoGrupoCliField;

	private decimal? totalLimiteCreditoField;

	private int iDVendedorField;

	private EndCliWsModel[] endCliWsField;

	private ContCliWsModel[] contCliWsField;

	private TelCliWsModel[] telCliWsField;

	private ClientePermCompWsModel[] clientePermCompWsField;

	private int? qtdeCheckoutField;

	private string tipoOperacaoField;

	private string textoExpedicaoField;

	private string ibanField;

	private int? codigoClienteProspeccaoField;

	private int? codigoTributacaoField;

	private DateTime? dtFundacaoField;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 1)]
	public string RazaoSocial
	{
		get
		{
			return razaoSocialField;
		}
		set
		{
			razaoSocialField = value;
			RaisePropertyChanged("RazaoSocial");
		}
	}

	[XmlElement(Order = 2)]
	public string NomeFantasia
	{
		get
		{
			return nomeFantasiaField;
		}
		set
		{
			nomeFantasiaField = value;
			RaisePropertyChanged("NomeFantasia");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? DtUltimaCompra
	{
		get
		{
			return dtUltimaCompraField;
		}
		set
		{
			dtUltimaCompraField = value;
			RaisePropertyChanged("DtUltimaCompra");
		}
	}

	[XmlElement(Order = 4)]
	public string CodigoStCred
	{
		get
		{
			return codigoStCredField;
		}
		set
		{
			codigoStCredField = value;
			RaisePropertyChanged("CodigoStCred");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public bool? PermiteAlterarTabPre
	{
		get
		{
			return permiteAlterarTabPreField;
		}
		set
		{
			permiteAlterarTabPreField = value;
			RaisePropertyChanged("PermiteAlterarTabPre");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public int? CodigoTransportadora
	{
		get
		{
			return codigoTransportadoraField;
		}
		set
		{
			codigoTransportadoraField = value;
			RaisePropertyChanged("CodigoTransportadora");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public decimal? PercDesconto
	{
		get
		{
			return percDescontoField;
		}
		set
		{
			percDescontoField = value;
			RaisePropertyChanged("PercDesconto");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public bool? ProdutoControlado
	{
		get
		{
			return produtoControladoField;
		}
		set
		{
			produtoControladoField = value;
			RaisePropertyChanged("ProdutoControlado");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public DateTime? DtPrazoProdutoControlado
	{
		get
		{
			return dtPrazoProdutoControladoField;
		}
		set
		{
			dtPrazoProdutoControladoField = value;
			RaisePropertyChanged("DtPrazoProdutoControlado");
		}
	}

	[XmlElement(Order = 10)]
	public string CodigoRamAtiv
	{
		get
		{
			return codigoRamAtivField;
		}
		set
		{
			codigoRamAtivField = value;
			RaisePropertyChanged("CodigoRamAtiv");
		}
	}

	[XmlElement(Order = 11)]
	public string StatusAnvisa
	{
		get
		{
			return statusAnvisaField;
		}
		set
		{
			statusAnvisaField = value;
			RaisePropertyChanged("StatusAnvisa");
		}
	}

	[XmlElement(Order = 12)]
	public string StatusAlvara
	{
		get
		{
			return statusAlvaraField;
		}
		set
		{
			statusAlvaraField = value;
			RaisePropertyChanged("StatusAlvara");
		}
	}

	[XmlElement(Order = 13)]
	public string CodigoTpPed
	{
		get
		{
			return codigoTpPedField;
		}
		set
		{
			codigoTpPedField = value;
			RaisePropertyChanged("CodigoTpPed");
		}
	}

	[XmlElement(Order = 14)]
	public string Email
	{
		get
		{
			return emailField;
		}
		set
		{
			emailField = value;
			RaisePropertyChanged("Email");
		}
	}

	[XmlElement(Order = 15)]
	public string WebSite
	{
		get
		{
			return webSiteField;
		}
		set
		{
			webSiteField = value;
			RaisePropertyChanged("WebSite");
		}
	}

	[XmlElement(Order = 16)]
	public string TipoPessoa
	{
		get
		{
			return tipoPessoaField;
		}
		set
		{
			tipoPessoaField = value;
			RaisePropertyChanged("TipoPessoa");
		}
	}

	[XmlElement(Order = 17)]
	public string CnpjCpf
	{
		get
		{
			return cnpjCpfField;
		}
		set
		{
			cnpjCpfField = value;
			RaisePropertyChanged("CnpjCpf");
		}
	}

	[XmlElement(Order = 18)]
	public string TipoInscricao
	{
		get
		{
			return tipoInscricaoField;
		}
		set
		{
			tipoInscricaoField = value;
			RaisePropertyChanged("TipoInscricao");
		}
	}

	[XmlElement(Order = 19)]
	public string Inscricao
	{
		get
		{
			return inscricaoField;
		}
		set
		{
			inscricaoField = value;
			RaisePropertyChanged("Inscricao");
		}
	}

	[XmlElement(IsNullable = true, Order = 20)]
	public DateTime? DtVencAlvara
	{
		get
		{
			return dtVencAlvaraField;
		}
		set
		{
			dtVencAlvaraField = value;
			RaisePropertyChanged("DtVencAlvara");
		}
	}

	[XmlElement(IsNullable = true, Order = 21)]
	public DateTime? DtVencAnvisa
	{
		get
		{
			return dtVencAnvisaField;
		}
		set
		{
			dtVencAnvisaField = value;
			RaisePropertyChanged("DtVencAnvisa");
		}
	}

	[XmlElement(Order = 22)]
	public string TipoFrete
	{
		get
		{
			return tipoFreteField;
		}
		set
		{
			tipoFreteField = value;
			RaisePropertyChanged("TipoFrete");
		}
	}

	[XmlElement(Order = 23)]
	public string TextoGeral
	{
		get
		{
			return textoGeralField;
		}
		set
		{
			textoGeralField = value;
			RaisePropertyChanged("TextoGeral");
		}
	}

	[XmlElement(Order = 24)]
	public string TextoAlerta
	{
		get
		{
			return textoAlertaField;
		}
		set
		{
			textoAlertaField = value;
			RaisePropertyChanged("TextoAlerta");
		}
	}

	[XmlElement(IsNullable = true, Order = 25)]
	public bool? PermiteAlterarTpPed
	{
		get
		{
			return permiteAlterarTpPedField;
		}
		set
		{
			permiteAlterarTpPedField = value;
			RaisePropertyChanged("PermiteAlterarTpPed");
		}
	}

	[XmlElement(Order = 26)]
	public string CodigoGrupoCli
	{
		get
		{
			return codigoGrupoCliField;
		}
		set
		{
			codigoGrupoCliField = value;
			RaisePropertyChanged("CodigoGrupoCli");
		}
	}

	[XmlElement(IsNullable = true, Order = 27)]
	public decimal? TotalLimiteCredito
	{
		get
		{
			return totalLimiteCreditoField;
		}
		set
		{
			totalLimiteCreditoField = value;
			RaisePropertyChanged("TotalLimiteCredito");
		}
	}

	[XmlElement(Order = 28)]
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

	[XmlArray(Order = 29)]
	public EndCliWsModel[] EndCliWs
	{
		get
		{
			return endCliWsField;
		}
		set
		{
			endCliWsField = value;
			RaisePropertyChanged("EndCliWs");
		}
	}

	[XmlArray(Order = 30)]
	public ContCliWsModel[] ContCliWs
	{
		get
		{
			return contCliWsField;
		}
		set
		{
			contCliWsField = value;
			RaisePropertyChanged("ContCliWs");
		}
	}

	[XmlArray(Order = 31)]
	public TelCliWsModel[] TelCliWs
	{
		get
		{
			return telCliWsField;
		}
		set
		{
			telCliWsField = value;
			RaisePropertyChanged("TelCliWs");
		}
	}

	[XmlArray(Order = 32)]
	public ClientePermCompWsModel[] ClientePermCompWs
	{
		get
		{
			return clientePermCompWsField;
		}
		set
		{
			clientePermCompWsField = value;
			RaisePropertyChanged("ClientePermCompWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 33)]
	public int? QtdeCheckout
	{
		get
		{
			return qtdeCheckoutField;
		}
		set
		{
			qtdeCheckoutField = value;
			RaisePropertyChanged("QtdeCheckout");
		}
	}

	[XmlElement(Order = 34)]
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

	[XmlElement(Order = 35)]
	public string TextoExpedicao
	{
		get
		{
			return textoExpedicaoField;
		}
		set
		{
			textoExpedicaoField = value;
			RaisePropertyChanged("TextoExpedicao");
		}
	}

	[XmlElement(Order = 36)]
	public string Iban
	{
		get
		{
			return ibanField;
		}
		set
		{
			ibanField = value;
			RaisePropertyChanged("Iban");
		}
	}

	[XmlElement(IsNullable = true, Order = 37)]
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

	[XmlElement(IsNullable = true, Order = 38)]
	public int? CodigoTributacao
	{
		get
		{
			return codigoTributacaoField;
		}
		set
		{
			codigoTributacaoField = value;
			RaisePropertyChanged("CodigoTributacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 39)]
	public DateTime? DtFundacao
	{
		get
		{
			return dtFundacaoField;
		}
		set
		{
			dtFundacaoField = value;
			RaisePropertyChanged("DtFundacao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
