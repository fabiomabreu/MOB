using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(PedVdaAtendimentoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class PedVdaAtendimentoWsModel : INotifyPropertyChanged
{
	private int? iDPedVdaAtendimentoField;

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

	private int? codigoClienteField;

	private int? codigoEmpresaField;

	private int? iDVendedorField;

	private ItPedvAtendimentoWsModel[] itPedvAtendimentoWsField;

	private PedVdaAtendimentoMensagemWsModel[] pedVdaAtendimentoMensagemWsField;

	private int? numeroPedVdaPocketField;

	private int? numeroPedVdaAtendimentoField;

	private DateTime? dtPedVdaPocketField;

	private string emailClienteField;

	private string razaoSocialField;

	private string nomeFantasiaField;

	private string cnpjCpfField;

	private string razaoSocialTranspField;

	private string descricacaoCondPgtoField;

	private string logradouroField;

	private string numeroField;

	private string complementoField;

	private string bairroField;

	private string municipioField;

	private int? cepField;

	private string estadoField;

	private int? codigoEntregaOutroClienteField;

	private int? cdClienFaturaField;

	private int? cdClienPagamentoField;

	private int? cdClienAtacadistaField;

	private PedVdaAtendimentoTextoGravacaoWsModel[] pedVdaAtendimentoTextoGravacaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDPedVdaAtendimento
	{
		get
		{
			return iDPedVdaAtendimentoField;
		}
		set
		{
			iDPedVdaAtendimentoField = value;
			RaisePropertyChanged("IDPedVdaAtendimento");
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

	[XmlElement(IsNullable = true, Order = 21)]
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

	[XmlElement(IsNullable = true, Order = 22)]
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

	[XmlArray(Order = 23)]
	public ItPedvAtendimentoWsModel[] ItPedvAtendimentoWs
	{
		get
		{
			return itPedvAtendimentoWsField;
		}
		set
		{
			itPedvAtendimentoWsField = value;
			RaisePropertyChanged("ItPedvAtendimentoWs");
		}
	}

	[XmlArray(Order = 24)]
	public PedVdaAtendimentoMensagemWsModel[] PedVdaAtendimentoMensagemWs
	{
		get
		{
			return pedVdaAtendimentoMensagemWsField;
		}
		set
		{
			pedVdaAtendimentoMensagemWsField = value;
			RaisePropertyChanged("PedVdaAtendimentoMensagemWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 25)]
	public int? NumeroPedVdaPocket
	{
		get
		{
			return numeroPedVdaPocketField;
		}
		set
		{
			numeroPedVdaPocketField = value;
			RaisePropertyChanged("NumeroPedVdaPocket");
		}
	}

	[XmlElement(IsNullable = true, Order = 26)]
	public int? NumeroPedVdaAtendimento
	{
		get
		{
			return numeroPedVdaAtendimentoField;
		}
		set
		{
			numeroPedVdaAtendimentoField = value;
			RaisePropertyChanged("NumeroPedVdaAtendimento");
		}
	}

	[XmlElement(IsNullable = true, Order = 27)]
	public DateTime? DtPedVdaPocket
	{
		get
		{
			return dtPedVdaPocketField;
		}
		set
		{
			dtPedVdaPocketField = value;
			RaisePropertyChanged("DtPedVdaPocket");
		}
	}

	[XmlElement(Order = 28)]
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

	[XmlElement(Order = 32)]
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

	[XmlElement(Order = 33)]
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

	[XmlElement(Order = 34)]
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

	[XmlElement(Order = 35)]
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

	[XmlElement(Order = 36)]
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

	[XmlElement(Order = 37)]
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

	[XmlElement(Order = 38)]
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

	[XmlElement(IsNullable = true, Order = 39)]
	public int? Cep
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

	[XmlElement(Order = 40)]
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

	[XmlElement(IsNullable = true, Order = 41)]
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

	[XmlElement(IsNullable = true, Order = 42)]
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

	[XmlElement(IsNullable = true, Order = 43)]
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

	[XmlElement(IsNullable = true, Order = 44)]
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

	[XmlArray(Order = 45)]
	public PedVdaAtendimentoTextoGravacaoWsModel[] pedVdaAtendimentoTextoGravacao
	{
		get
		{
			return pedVdaAtendimentoTextoGravacaoField;
		}
		set
		{
			pedVdaAtendimentoTextoGravacaoField = value;
			RaisePropertyChanged("pedVdaAtendimentoTextoGravacao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
