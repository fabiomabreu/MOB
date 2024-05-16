using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class TGTFatMesAnoWsModel : INotifyPropertyChanged
{
	private string cnpjField;

	private string siglaClienteField;

	private string empresaField;

	private int anoField;

	private int mesField;

	private decimal? faturamentoField;

	private decimal? mgBrtVlField;

	private decimal? mgBrtPercField;

	private decimal? mgCtbVlField;

	private decimal? mgCtbPercField;

	private int? coberturaField;

	private int? cliAtivoField;

	private int? mixPrdField;

	private int? prdAtivoField;

	private int? mixFabricField;

	private int? fabricAtivoField;

	private int? qtdePedidosField;

	private int? qtdeItensField;

	private int? vendPositField;

	private int? vendAtivoField;

	private int? qtdeRoteirosField;

	private int? qtdeEntregasField;

	private decimal? pesoTotalField;

	private decimal? vlCortePrdField;

	private decimal? vlCorteLogField;

	private decimal? vlDevolucaoField;

	private int? usuarioAtivoField;

	private DateTime? dataField;

	private byte[] rowIdField;

	[XmlElement(Order = 0)]
	public string Cnpj
	{
		get
		{
			return cnpjField;
		}
		set
		{
			cnpjField = value;
			RaisePropertyChanged("Cnpj");
		}
	}

	[XmlElement(Order = 1)]
	public string SiglaCliente
	{
		get
		{
			return siglaClienteField;
		}
		set
		{
			siglaClienteField = value;
			RaisePropertyChanged("SiglaCliente");
		}
	}

	[XmlElement(Order = 2)]
	public string Empresa
	{
		get
		{
			return empresaField;
		}
		set
		{
			empresaField = value;
			RaisePropertyChanged("Empresa");
		}
	}

	[XmlElement(Order = 3)]
	public int Ano
	{
		get
		{
			return anoField;
		}
		set
		{
			anoField = value;
			RaisePropertyChanged("Ano");
		}
	}

	[XmlElement(Order = 4)]
	public int Mes
	{
		get
		{
			return mesField;
		}
		set
		{
			mesField = value;
			RaisePropertyChanged("Mes");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public decimal? Faturamento
	{
		get
		{
			return faturamentoField;
		}
		set
		{
			faturamentoField = value;
			RaisePropertyChanged("Faturamento");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public decimal? MgBrtVl
	{
		get
		{
			return mgBrtVlField;
		}
		set
		{
			mgBrtVlField = value;
			RaisePropertyChanged("MgBrtVl");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public decimal? MgBrtPerc
	{
		get
		{
			return mgBrtPercField;
		}
		set
		{
			mgBrtPercField = value;
			RaisePropertyChanged("MgBrtPerc");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public decimal? MgCtbVl
	{
		get
		{
			return mgCtbVlField;
		}
		set
		{
			mgCtbVlField = value;
			RaisePropertyChanged("MgCtbVl");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public decimal? MgCtbPerc
	{
		get
		{
			return mgCtbPercField;
		}
		set
		{
			mgCtbPercField = value;
			RaisePropertyChanged("MgCtbPerc");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public int? Cobertura
	{
		get
		{
			return coberturaField;
		}
		set
		{
			coberturaField = value;
			RaisePropertyChanged("Cobertura");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public int? CliAtivo
	{
		get
		{
			return cliAtivoField;
		}
		set
		{
			cliAtivoField = value;
			RaisePropertyChanged("CliAtivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public int? MixPrd
	{
		get
		{
			return mixPrdField;
		}
		set
		{
			mixPrdField = value;
			RaisePropertyChanged("MixPrd");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public int? PrdAtivo
	{
		get
		{
			return prdAtivoField;
		}
		set
		{
			prdAtivoField = value;
			RaisePropertyChanged("PrdAtivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public int? MixFabric
	{
		get
		{
			return mixFabricField;
		}
		set
		{
			mixFabricField = value;
			RaisePropertyChanged("MixFabric");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public int? FabricAtivo
	{
		get
		{
			return fabricAtivoField;
		}
		set
		{
			fabricAtivoField = value;
			RaisePropertyChanged("FabricAtivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
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

	[XmlElement(IsNullable = true, Order = 17)]
	public int? QtdeItens
	{
		get
		{
			return qtdeItensField;
		}
		set
		{
			qtdeItensField = value;
			RaisePropertyChanged("QtdeItens");
		}
	}

	[XmlElement(IsNullable = true, Order = 18)]
	public int? VendPosit
	{
		get
		{
			return vendPositField;
		}
		set
		{
			vendPositField = value;
			RaisePropertyChanged("VendPosit");
		}
	}

	[XmlElement(IsNullable = true, Order = 19)]
	public int? VendAtivo
	{
		get
		{
			return vendAtivoField;
		}
		set
		{
			vendAtivoField = value;
			RaisePropertyChanged("VendAtivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 20)]
	public int? QtdeRoteiros
	{
		get
		{
			return qtdeRoteirosField;
		}
		set
		{
			qtdeRoteirosField = value;
			RaisePropertyChanged("QtdeRoteiros");
		}
	}

	[XmlElement(IsNullable = true, Order = 21)]
	public int? QtdeEntregas
	{
		get
		{
			return qtdeEntregasField;
		}
		set
		{
			qtdeEntregasField = value;
			RaisePropertyChanged("QtdeEntregas");
		}
	}

	[XmlElement(IsNullable = true, Order = 22)]
	public decimal? PesoTotal
	{
		get
		{
			return pesoTotalField;
		}
		set
		{
			pesoTotalField = value;
			RaisePropertyChanged("PesoTotal");
		}
	}

	[XmlElement(IsNullable = true, Order = 23)]
	public decimal? VlCortePrd
	{
		get
		{
			return vlCortePrdField;
		}
		set
		{
			vlCortePrdField = value;
			RaisePropertyChanged("VlCortePrd");
		}
	}

	[XmlElement(IsNullable = true, Order = 24)]
	public decimal? VlCorteLog
	{
		get
		{
			return vlCorteLogField;
		}
		set
		{
			vlCorteLogField = value;
			RaisePropertyChanged("VlCorteLog");
		}
	}

	[XmlElement(IsNullable = true, Order = 25)]
	public decimal? VlDevolucao
	{
		get
		{
			return vlDevolucaoField;
		}
		set
		{
			vlDevolucaoField = value;
			RaisePropertyChanged("VlDevolucao");
		}
	}

	[XmlElement(IsNullable = true, Order = 26)]
	public int? UsuarioAtivo
	{
		get
		{
			return usuarioAtivoField;
		}
		set
		{
			usuarioAtivoField = value;
			RaisePropertyChanged("UsuarioAtivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 27)]
	public DateTime? Data
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

	[XmlElement(DataType = "base64Binary", Order = 28)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
