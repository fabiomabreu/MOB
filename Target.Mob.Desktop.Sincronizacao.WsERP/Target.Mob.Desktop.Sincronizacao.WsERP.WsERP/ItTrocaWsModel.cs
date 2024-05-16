using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ItTrocaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ItTrocaWsModel : INotifyPropertyChanged
{
	private int? codigoIttrocaField;

	private short? seqField;

	private int? codigoProdutoField;

	private decimal? qtdeUnidEstoqueField;

	private decimal? precoTabelaUnidEstoqueField;

	private decimal? valorIndenizacaoField;

	private decimal? percIndenizacaoField;

	private int? iDTrocaField;

	private string unidadeField;

	private string indiceRelacaoProdutoField;

	private float? fatorField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? CodigoIttroca
	{
		get
		{
			return codigoIttrocaField;
		}
		set
		{
			codigoIttrocaField = value;
			RaisePropertyChanged("CodigoIttroca");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
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
	public decimal? QtdeUnidEstoque
	{
		get
		{
			return qtdeUnidEstoqueField;
		}
		set
		{
			qtdeUnidEstoqueField = value;
			RaisePropertyChanged("QtdeUnidEstoque");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
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

	[XmlElement(IsNullable = true, Order = 5)]
	public decimal? ValorIndenizacao
	{
		get
		{
			return valorIndenizacaoField;
		}
		set
		{
			valorIndenizacaoField = value;
			RaisePropertyChanged("ValorIndenizacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public decimal? PercIndenizacao
	{
		get
		{
			return percIndenizacaoField;
		}
		set
		{
			percIndenizacaoField = value;
			RaisePropertyChanged("PercIndenizacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public int? IDTroca
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

	[XmlElement(Order = 8)]
	public string Unidade
	{
		get
		{
			return unidadeField;
		}
		set
		{
			unidadeField = value;
			RaisePropertyChanged("Unidade");
		}
	}

	[XmlElement(Order = 9)]
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

	[XmlElement(IsNullable = true, Order = 10)]
	public float? Fator
	{
		get
		{
			return fatorField;
		}
		set
		{
			fatorField = value;
			RaisePropertyChanged("Fator");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
