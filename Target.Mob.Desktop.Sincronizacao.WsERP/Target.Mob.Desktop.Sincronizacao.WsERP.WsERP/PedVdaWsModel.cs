using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(PedVdaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class PedVdaWsModel : INotifyPropertyChanged
{
	private int? iDPedVdaField;

	private DateTime? dtPedidoField;

	private bool? verificacaoCreditoField;

	private DateTime? dtPrevEntregaField;

	private string codigoFormPgtoField;

	private string codigoTabPreField;

	private DateTime? dtPrevFaturamentoField;

	private int? codigoCondPgtoField;

	private string tipoEntregaField;

	private int? codigoTransportadoraField;

	private string tipoFreteField;

	private string origemPedidoField;

	private string numeroPedidoClienteField;

	private decimal? valorTotalField;

	private decimal? valorDescontoGeralField;

	private decimal? percDescontoGeralField;

	private string statusPedidoField;

	private string codigoTpPedField;

	private bool? propostaField;

	private bool? cotacaoField;

	private int? codigoEmpresaField;

	private int? numeroPedVdaField;

	private int? codigoClienteField;

	private int? iDVendedorField;

	private ItPedvWsModel[] itPedvWsField;

	private PedVdaMensagemWsModel[] pedVdaMensagemWsField;

	private bool? clienteBDMovimentoField;

	private string emailClienteField;

	private string cnpjCpfClienteField;

	private string razaoSocialField;

	private string nomeFantasiaField;

	private string razaoSocialTranspField;

	private string descricacaoCondPgtoField;

	private string logradouroField;

	private string numeroField;

	private string complementoField;

	private string bairroField;

	private string municipioField;

	private string cepField;

	private string estadoField;

	private GondolaWsModel[] gondolaWsField;

	private GondolaTempoOperacaoWsModel[] gondolaTempoOperacaoWsField;

	private TrocaWsModel trocaWsField;

	private int? codigoEntregaOutroClienteField;

	private string codigoPaisField;

	private string[] contatoVisitaField;

	private int? codigoClienteProspeccaoField;

	private int? cdClienFaturaField;

	private int? cdClienPagamentoField;

	private int? cdClienAtacadistaField;

	private PedVdaTextoGravacaoWsModel[] pedVdaTextoGravacaoField;

	private int? codigoComoRealizouVendaField;

	private string textoComoRealizouVendaField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDPedVda
	{
		get
		{
			return iDPedVdaField;
		}
		set
		{
			iDPedVdaField = value;
			RaisePropertyChanged("IDPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public DateTime? DtPedido
	{
		get
		{
			return dtPedidoField;
		}
		set
		{
			dtPedidoField = value;
			RaisePropertyChanged("DtPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public bool? VerificacaoCredito
	{
		get
		{
			return verificacaoCreditoField;
		}
		set
		{
			verificacaoCreditoField = value;
			RaisePropertyChanged("VerificacaoCredito");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? DtPrevEntrega
	{
		get
		{
			return dtPrevEntregaField;
		}
		set
		{
			dtPrevEntregaField = value;
			RaisePropertyChanged("DtPrevEntrega");
		}
	}

	[XmlElement(Order = 4)]
	public string CodigoFormPgto
	{
		get
		{
			return codigoFormPgtoField;
		}
		set
		{
			codigoFormPgtoField = value;
			RaisePropertyChanged("CodigoFormPgto");
		}
	}

	[XmlElement(Order = 5)]
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

	[XmlElement(IsNullable = true, Order = 6)]
	public DateTime? DtPrevFaturamento
	{
		get
		{
			return dtPrevFaturamentoField;
		}
		set
		{
			dtPrevFaturamentoField = value;
			RaisePropertyChanged("DtPrevFaturamento");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public int? CodigoCondPgto
	{
		get
		{
			return codigoCondPgtoField;
		}
		set
		{
			codigoCondPgtoField = value;
			RaisePropertyChanged("CodigoCondPgto");
		}
	}

	[XmlElement(Order = 8)]
	public string TipoEntrega
	{
		get
		{
			return tipoEntregaField;
		}
		set
		{
			tipoEntregaField = value;
			RaisePropertyChanged("TipoEntrega");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
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

	[XmlElement(Order = 10)]
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

	[XmlElement(Order = 11)]
	public string OrigemPedido
	{
		get
		{
			return origemPedidoField;
		}
		set
		{
			origemPedidoField = value;
			RaisePropertyChanged("OrigemPedido");
		}
	}

	[XmlElement(Order = 12)]
	public string NumeroPedidoCliente
	{
		get
		{
			return numeroPedidoClienteField;
		}
		set
		{
			numeroPedidoClienteField = value;
			RaisePropertyChanged("NumeroPedidoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public decimal? ValorTotal
	{
		get
		{
			return valorTotalField;
		}
		set
		{
			valorTotalField = value;
			RaisePropertyChanged("ValorTotal");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public decimal? ValorDescontoGeral
	{
		get
		{
			return valorDescontoGeralField;
		}
		set
		{
			valorDescontoGeralField = value;
			RaisePropertyChanged("ValorDescontoGeral");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public decimal? PercDescontoGeral
	{
		get
		{
			return percDescontoGeralField;
		}
		set
		{
			percDescontoGeralField = value;
			RaisePropertyChanged("PercDescontoGeral");
		}
	}

	[XmlElement(Order = 16)]
	public string StatusPedido
	{
		get
		{
			return statusPedidoField;
		}
		set
		{
			statusPedidoField = value;
			RaisePropertyChanged("StatusPedido");
		}
	}

	[XmlElement(Order = 17)]
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

	[XmlElement(IsNullable = true, Order = 18)]
	public bool? Proposta
	{
		get
		{
			return propostaField;
		}
		set
		{
			propostaField = value;
			RaisePropertyChanged("Proposta");
		}
	}

	[XmlElement(IsNullable = true, Order = 19)]
	public bool? Cotacao
	{
		get
		{
			return cotacaoField;
		}
		set
		{
			cotacaoField = value;
			RaisePropertyChanged("Cotacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 20)]
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

	[XmlElement(IsNullable = true, Order = 21)]
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

	[XmlElement(IsNullable = true, Order = 22)]
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

	[XmlElement(IsNullable = true, Order = 23)]
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

	[XmlArray(Order = 24)]
	public ItPedvWsModel[] ItPedvWs
	{
		get
		{
			return itPedvWsField;
		}
		set
		{
			itPedvWsField = value;
			RaisePropertyChanged("ItPedvWs");
		}
	}

	[XmlArray(Order = 25)]
	public PedVdaMensagemWsModel[] PedVdaMensagemWs
	{
		get
		{
			return pedVdaMensagemWsField;
		}
		set
		{
			pedVdaMensagemWsField = value;
			RaisePropertyChanged("PedVdaMensagemWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 26)]
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

	[XmlElement(Order = 27)]
	public string EmailCliente
	{
		get
		{
			return emailClienteField;
		}
		set
		{
			emailClienteField = value;
			RaisePropertyChanged("EmailCliente");
		}
	}

	[XmlElement(Order = 28)]
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

	[XmlElement(Order = 29)]
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

	[XmlElement(Order = 30)]
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

	[XmlElement(Order = 31)]
	public string RazaoSocialTransp
	{
		get
		{
			return razaoSocialTranspField;
		}
		set
		{
			razaoSocialTranspField = value;
			RaisePropertyChanged("RazaoSocialTransp");
		}
	}

	[XmlElement(Order = 32)]
	public string DescricacaoCondPgto
	{
		get
		{
			return descricacaoCondPgtoField;
		}
		set
		{
			descricacaoCondPgtoField = value;
			RaisePropertyChanged("DescricacaoCondPgto");
		}
	}

	[XmlElement(Order = 33)]
	public string Logradouro
	{
		get
		{
			return logradouroField;
		}
		set
		{
			logradouroField = value;
			RaisePropertyChanged("Logradouro");
		}
	}

	[XmlElement(Order = 34)]
	public string Numero
	{
		get
		{
			return numeroField;
		}
		set
		{
			numeroField = value;
			RaisePropertyChanged("Numero");
		}
	}

	[XmlElement(Order = 35)]
	public string Complemento
	{
		get
		{
			return complementoField;
		}
		set
		{
			complementoField = value;
			RaisePropertyChanged("Complemento");
		}
	}

	[XmlElement(Order = 36)]
	public string Bairro
	{
		get
		{
			return bairroField;
		}
		set
		{
			bairroField = value;
			RaisePropertyChanged("Bairro");
		}
	}

	[XmlElement(Order = 37)]
	public string Municipio
	{
		get
		{
			return municipioField;
		}
		set
		{
			municipioField = value;
			RaisePropertyChanged("Municipio");
		}
	}

	[XmlElement(Order = 38)]
	public string Cep
	{
		get
		{
			return cepField;
		}
		set
		{
			cepField = value;
			RaisePropertyChanged("Cep");
		}
	}

	[XmlElement(Order = 39)]
	public string Estado
	{
		get
		{
			return estadoField;
		}
		set
		{
			estadoField = value;
			RaisePropertyChanged("Estado");
		}
	}

	[XmlArray(Order = 40)]
	public GondolaWsModel[] GondolaWs
	{
		get
		{
			return gondolaWsField;
		}
		set
		{
			gondolaWsField = value;
			RaisePropertyChanged("GondolaWs");
		}
	}

	[XmlArray(Order = 41)]
	public GondolaTempoOperacaoWsModel[] GondolaTempoOperacaoWs
	{
		get
		{
			return gondolaTempoOperacaoWsField;
		}
		set
		{
			gondolaTempoOperacaoWsField = value;
			RaisePropertyChanged("GondolaTempoOperacaoWs");
		}
	}

	[XmlElement(Order = 42)]
	public TrocaWsModel TrocaWs
	{
		get
		{
			return trocaWsField;
		}
		set
		{
			trocaWsField = value;
			RaisePropertyChanged("TrocaWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 43)]
	public int? CodigoEntregaOutroCliente
	{
		get
		{
			return codigoEntregaOutroClienteField;
		}
		set
		{
			codigoEntregaOutroClienteField = value;
			RaisePropertyChanged("CodigoEntregaOutroCliente");
		}
	}

	[XmlElement(Order = 44)]
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

	[XmlArray(Order = 45)]
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

	[XmlElement(IsNullable = true, Order = 46)]
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

	[XmlElement(IsNullable = true, Order = 47)]
	public int? cdClienFatura
	{
		get
		{
			return cdClienFaturaField;
		}
		set
		{
			cdClienFaturaField = value;
			RaisePropertyChanged("cdClienFatura");
		}
	}

	[XmlElement(IsNullable = true, Order = 48)]
	public int? cdClienPagamento
	{
		get
		{
			return cdClienPagamentoField;
		}
		set
		{
			cdClienPagamentoField = value;
			RaisePropertyChanged("cdClienPagamento");
		}
	}

	[XmlElement(IsNullable = true, Order = 49)]
	public int? cdClienAtacadista
	{
		get
		{
			return cdClienAtacadistaField;
		}
		set
		{
			cdClienAtacadistaField = value;
			RaisePropertyChanged("cdClienAtacadista");
		}
	}

	[XmlArray(Order = 50)]
	public PedVdaTextoGravacaoWsModel[] pedVdaTextoGravacao
	{
		get
		{
			return pedVdaTextoGravacaoField;
		}
		set
		{
			pedVdaTextoGravacaoField = value;
			RaisePropertyChanged("pedVdaTextoGravacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 51)]
	public int? CodigoComoRealizouVenda
	{
		get
		{
			return codigoComoRealizouVendaField;
		}
		set
		{
			codigoComoRealizouVendaField = value;
			RaisePropertyChanged("CodigoComoRealizouVenda");
		}
	}

	[XmlElement(Order = 52)]
	public string TextoComoRealizouVenda
	{
		get
		{
			return textoComoRealizouVendaField;
		}
		set
		{
			textoComoRealizouVendaField = value;
			RaisePropertyChanged("TextoComoRealizouVenda");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
