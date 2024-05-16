using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ItPedvModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ItPedvWsModel : INotifyPropertyChanged
{
	private int? iDItPedvField;

	private int? iDPedVdaField;

	private int? codigoProdutoField;

	private decimal? qtdeUnidVendaField;

	private decimal? qtdeBonifUnidVendaField;

	private string indiceRelacaoProdutoField;

	private decimal? fatorUnidVendaField;

	private decimal? precoTabelaUnidEstoqueField;

	private decimal? percDescAplicadoField;

	private decimal? percDesc01Field;

	private decimal? percDesc02Field;

	private decimal? precoLiquidoUnidVendaField;

	private DateTime? dtFaturamentoField;

	private string statusItemPedidoField;

	private string unidVendaField;

	private int? codigoKitPromField;

	private int? notaFiscalField;

	private decimal? percDescBonificacaoField;

	private decimal? percDescComercialField;

	private decimal? percDescFinanceiroField;

	private short? seqField;

	private decimal? verbaVendedorField;

	private decimal? verbaOutrosField;

	private decimal? vlIPIField;

	private decimal? vlSTField;

	private int? codigoCondPgtoField;

	private decimal? percDescAuxQtdeField;

	private decimal? percDescAuxPeGField;

	private decimal? precoBrutoUnidVendaField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDItPedv
	{
		get
		{
			return iDItPedvField;
		}
		set
		{
			iDItPedvField = value;
			RaisePropertyChanged("IDItPedv");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
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

	[XmlElement(IsNullable = true, Order = 3)]
	public decimal? QtdeUnidVenda
	{
		get
		{
			return qtdeUnidVendaField;
		}
		set
		{
			qtdeUnidVendaField = value;
			RaisePropertyChanged("QtdeUnidVenda");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public decimal? QtdeBonifUnidVenda
	{
		get
		{
			return qtdeBonifUnidVendaField;
		}
		set
		{
			qtdeBonifUnidVendaField = value;
			RaisePropertyChanged("QtdeBonifUnidVenda");
		}
	}

	[XmlElement(Order = 5)]
	public string IndiceRelacaoProduto
	{
		get
		{
			return indiceRelacaoProdutoField;
		}
		set
		{
			indiceRelacaoProdutoField = value;
			RaisePropertyChanged("IndiceRelacaoProduto");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public decimal? FatorUnidVenda
	{
		get
		{
			return fatorUnidVendaField;
		}
		set
		{
			fatorUnidVendaField = value;
			RaisePropertyChanged("FatorUnidVenda");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public decimal? PrecoTabelaUnidEstoque
	{
		get
		{
			return precoTabelaUnidEstoqueField;
		}
		set
		{
			precoTabelaUnidEstoqueField = value;
			RaisePropertyChanged("PrecoTabelaUnidEstoque");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public decimal? PercDescAplicado
	{
		get
		{
			return percDescAplicadoField;
		}
		set
		{
			percDescAplicadoField = value;
			RaisePropertyChanged("PercDescAplicado");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public decimal? PercDesc01
	{
		get
		{
			return percDesc01Field;
		}
		set
		{
			percDesc01Field = value;
			RaisePropertyChanged("PercDesc01");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public decimal? PercDesc02
	{
		get
		{
			return percDesc02Field;
		}
		set
		{
			percDesc02Field = value;
			RaisePropertyChanged("PercDesc02");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public decimal? PrecoLiquidoUnidVenda
	{
		get
		{
			return precoLiquidoUnidVendaField;
		}
		set
		{
			precoLiquidoUnidVendaField = value;
			RaisePropertyChanged("PrecoLiquidoUnidVenda");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public DateTime? DtFaturamento
	{
		get
		{
			return dtFaturamentoField;
		}
		set
		{
			dtFaturamentoField = value;
			RaisePropertyChanged("DtFaturamento");
		}
	}

	[XmlElement(Order = 13)]
	public string StatusItemPedido
	{
		get
		{
			return statusItemPedidoField;
		}
		set
		{
			statusItemPedidoField = value;
			RaisePropertyChanged("StatusItemPedido");
		}
	}

	[XmlElement(Order = 14)]
	public string UnidVenda
	{
		get
		{
			return unidVendaField;
		}
		set
		{
			unidVendaField = value;
			RaisePropertyChanged("UnidVenda");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public int? CodigoKitProm
	{
		get
		{
			return codigoKitPromField;
		}
		set
		{
			codigoKitPromField = value;
			RaisePropertyChanged("CodigoKitProm");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
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

	[XmlElement(IsNullable = true, Order = 17)]
	public decimal? PercDescBonificacao
	{
		get
		{
			return percDescBonificacaoField;
		}
		set
		{
			percDescBonificacaoField = value;
			RaisePropertyChanged("PercDescBonificacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 18)]
	public decimal? PercDescComercial
	{
		get
		{
			return percDescComercialField;
		}
		set
		{
			percDescComercialField = value;
			RaisePropertyChanged("PercDescComercial");
		}
	}

	[XmlElement(IsNullable = true, Order = 19)]
	public decimal? PercDescFinanceiro
	{
		get
		{
			return percDescFinanceiroField;
		}
		set
		{
			percDescFinanceiroField = value;
			RaisePropertyChanged("PercDescFinanceiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 20)]
	public short? Seq
	{
		get
		{
			return seqField;
		}
		set
		{
			seqField = value;
			RaisePropertyChanged("Seq");
		}
	}

	[XmlElement(IsNullable = true, Order = 21)]
	public decimal? VerbaVendedor
	{
		get
		{
			return verbaVendedorField;
		}
		set
		{
			verbaVendedorField = value;
			RaisePropertyChanged("VerbaVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 22)]
	public decimal? VerbaOutros
	{
		get
		{
			return verbaOutrosField;
		}
		set
		{
			verbaOutrosField = value;
			RaisePropertyChanged("VerbaOutros");
		}
	}

	[XmlElement(IsNullable = true, Order = 23)]
	public decimal? VlIPI
	{
		get
		{
			return vlIPIField;
		}
		set
		{
			vlIPIField = value;
			RaisePropertyChanged("VlIPI");
		}
	}

	[XmlElement(IsNullable = true, Order = 24)]
	public decimal? VlST
	{
		get
		{
			return vlSTField;
		}
		set
		{
			vlSTField = value;
			RaisePropertyChanged("VlST");
		}
	}

	[XmlElement(IsNullable = true, Order = 25)]
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

	[XmlElement(IsNullable = true, Order = 26)]
	public decimal? PercDescAuxQtde
	{
		get
		{
			return percDescAuxQtdeField;
		}
		set
		{
			percDescAuxQtdeField = value;
			RaisePropertyChanged("PercDescAuxQtde");
		}
	}

	[XmlElement(IsNullable = true, Order = 27)]
	public decimal? PercDescAuxPeG
	{
		get
		{
			return percDescAuxPeGField;
		}
		set
		{
			percDescAuxPeGField = value;
			RaisePropertyChanged("PercDescAuxPeG");
		}
	}

	[XmlElement(IsNullable = true, Order = 28)]
	public decimal? PrecoBrutoUnidVenda
	{
		get
		{
			return precoBrutoUnidVendaField;
		}
		set
		{
			precoBrutoUnidVendaField = value;
			RaisePropertyChanged("PrecoBrutoUnidVenda");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
