using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(GondolaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class GondolaWsModel : INotifyPropertyChanged
{
	private int idGondolaField;

	private int codigoField;

	private int codigoClienteField;

	private int codigoProdutoField;

	private DateTime dataField;

	private int? qtdeEstoqueClienteField;

	private decimal? precoGondolaField;

	private bool transmitidoField;

	private bool excluidoField;

	private bool clienteBDMovimentoField;

	private int? qtdeGiroField;

	private decimal? qtdeVendaMediaField;

	private int? qtdeSugeridaField;

	private int? qtdeSegurancaField;

	private int? qtdeVendidaField;

	private int? qtdeSaldoField;

	private int codigoEmpresaField;

	private int numeroPedidoField;

	private int idPedVdaField;

	private int? idConexaoField;

	private int? idVendedorField;

	private decimal? markupField;

	[XmlElement(Order = 0)]
	public int IdGondola
	{
		get
		{
			return idGondolaField;
		}
		set
		{
			idGondolaField = value;
			RaisePropertyChanged("IdGondola");
		}
	}

	[XmlElement(Order = 1)]
	public int Codigo
	{
		get
		{
			return codigoField;
		}
		set
		{
			codigoField = value;
			RaisePropertyChanged("Codigo");
		}
	}

	[XmlElement(Order = 2)]
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

	[XmlElement(Order = 3)]
	public int CodigoProduto
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

	[XmlElement(Order = 4)]
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

	[XmlElement(IsNullable = true, Order = 5)]
	public int? QtdeEstoqueCliente
	{
		get
		{
			return qtdeEstoqueClienteField;
		}
		set
		{
			qtdeEstoqueClienteField = value;
			RaisePropertyChanged("QtdeEstoqueCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public decimal? PrecoGondola
	{
		get
		{
			return precoGondolaField;
		}
		set
		{
			precoGondolaField = value;
			RaisePropertyChanged("PrecoGondola");
		}
	}

	[XmlElement(Order = 7)]
	public bool Transmitido
	{
		get
		{
			return transmitidoField;
		}
		set
		{
			transmitidoField = value;
			RaisePropertyChanged("Transmitido");
		}
	}

	[XmlElement(Order = 8)]
	public bool Excluido
	{
		get
		{
			return excluidoField;
		}
		set
		{
			excluidoField = value;
			RaisePropertyChanged("Excluido");
		}
	}

	[XmlElement(Order = 9)]
	public bool ClienteBDMovimento
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

	[XmlElement(IsNullable = true, Order = 10)]
	public int? QtdeGiro
	{
		get
		{
			return qtdeGiroField;
		}
		set
		{
			qtdeGiroField = value;
			RaisePropertyChanged("QtdeGiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public decimal? QtdeVendaMedia
	{
		get
		{
			return qtdeVendaMediaField;
		}
		set
		{
			qtdeVendaMediaField = value;
			RaisePropertyChanged("QtdeVendaMedia");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public int? QtdeSugerida
	{
		get
		{
			return qtdeSugeridaField;
		}
		set
		{
			qtdeSugeridaField = value;
			RaisePropertyChanged("QtdeSugerida");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public int? QtdeSeguranca
	{
		get
		{
			return qtdeSegurancaField;
		}
		set
		{
			qtdeSegurancaField = value;
			RaisePropertyChanged("QtdeSeguranca");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public int? QtdeVendida
	{
		get
		{
			return qtdeVendidaField;
		}
		set
		{
			qtdeVendidaField = value;
			RaisePropertyChanged("QtdeVendida");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public int? QtdeSaldo
	{
		get
		{
			return qtdeSaldoField;
		}
		set
		{
			qtdeSaldoField = value;
			RaisePropertyChanged("QtdeSaldo");
		}
	}

	[XmlElement(Order = 16)]
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

	[XmlElement(Order = 17)]
	public int NumeroPedido
	{
		get
		{
			return numeroPedidoField;
		}
		set
		{
			numeroPedidoField = value;
			RaisePropertyChanged("NumeroPedido");
		}
	}

	[XmlElement(Order = 18)]
	public int IdPedVda
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

	[XmlElement(IsNullable = true, Order = 19)]
	public int? IdConexao
	{
		get
		{
			return idConexaoField;
		}
		set
		{
			idConexaoField = value;
			RaisePropertyChanged("IdConexao");
		}
	}

	[XmlElement(IsNullable = true, Order = 20)]
	public int? IdVendedor
	{
		get
		{
			return idVendedorField;
		}
		set
		{
			idVendedorField = value;
			RaisePropertyChanged("IdVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 21)]
	public decimal? Markup
	{
		get
		{
			return markupField;
		}
		set
		{
			markupField = value;
			RaisePropertyChanged("Markup");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
