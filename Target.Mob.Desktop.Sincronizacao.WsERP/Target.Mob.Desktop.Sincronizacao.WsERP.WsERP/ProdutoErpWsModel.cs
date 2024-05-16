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
public class ProdutoErpWsModel : INotifyPropertyChanged
{
	private int? cdProdutoErpField;

	private string cdProdutoFabricField;

	private string descricaoField;

	private string descResumField;

	private bool? ativoField;

	private bool? bloqEnvioPalmTopField;

	private byte[] rowIdField;

	private string cdFabricanteField;

	private string cdLinhaField;

	private FabricanteWsModel fabricanteWsField;

	private LinhaWsModel linhaWsField;

	private string tipoCodigoBarrasField;

	private string codigoBarrasField;

	private string tipoCodigoBarrasCompraField;

	private string codigoBarrasCompraField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? CdProdutoErp
	{
		get
		{
			return cdProdutoErpField;
		}
		set
		{
			cdProdutoErpField = value;
			RaisePropertyChanged("CdProdutoErp");
		}
	}

	[XmlElement(Order = 1)]
	public string CdProdutoFabric
	{
		get
		{
			return cdProdutoFabricField;
		}
		set
		{
			cdProdutoFabricField = value;
			RaisePropertyChanged("CdProdutoFabric");
		}
	}

	[XmlElement(Order = 2)]
	public string Descricao
	{
		get
		{
			return descricaoField;
		}
		set
		{
			descricaoField = value;
			RaisePropertyChanged("Descricao");
		}
	}

	[XmlElement(Order = 3)]
	public string DescResum
	{
		get
		{
			return descResumField;
		}
		set
		{
			descResumField = value;
			RaisePropertyChanged("DescResum");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public bool? Ativo
	{
		get
		{
			return ativoField;
		}
		set
		{
			ativoField = value;
			RaisePropertyChanged("Ativo");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public bool? BloqEnvioPalmTop
	{
		get
		{
			return bloqEnvioPalmTopField;
		}
		set
		{
			bloqEnvioPalmTopField = value;
			RaisePropertyChanged("BloqEnvioPalmTop");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 6)]
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

	[XmlElement(Order = 7)]
	public string CdFabricante
	{
		get
		{
			return cdFabricanteField;
		}
		set
		{
			cdFabricanteField = value;
			RaisePropertyChanged("CdFabricante");
		}
	}

	[XmlElement(Order = 8)]
	public string CdLinha
	{
		get
		{
			return cdLinhaField;
		}
		set
		{
			cdLinhaField = value;
			RaisePropertyChanged("CdLinha");
		}
	}

	[XmlElement(Order = 9)]
	public FabricanteWsModel FabricanteWs
	{
		get
		{
			return fabricanteWsField;
		}
		set
		{
			fabricanteWsField = value;
			RaisePropertyChanged("FabricanteWs");
		}
	}

	[XmlElement(Order = 10)]
	public LinhaWsModel LinhaWs
	{
		get
		{
			return linhaWsField;
		}
		set
		{
			linhaWsField = value;
			RaisePropertyChanged("LinhaWs");
		}
	}

	[XmlElement(Order = 11)]
	public string TipoCodigoBarras
	{
		get
		{
			return tipoCodigoBarrasField;
		}
		set
		{
			tipoCodigoBarrasField = value;
			RaisePropertyChanged("TipoCodigoBarras");
		}
	}

	[XmlElement(Order = 12)]
	public string CodigoBarras
	{
		get
		{
			return codigoBarrasField;
		}
		set
		{
			codigoBarrasField = value;
			RaisePropertyChanged("CodigoBarras");
		}
	}

	[XmlElement(Order = 13)]
	public string TipoCodigoBarrasCompra
	{
		get
		{
			return tipoCodigoBarrasCompraField;
		}
		set
		{
			tipoCodigoBarrasCompraField = value;
			RaisePropertyChanged("TipoCodigoBarrasCompra");
		}
	}

	[XmlElement(Order = 14)]
	public string CodigoBarrasCompra
	{
		get
		{
			return codigoBarrasCompraField;
		}
		set
		{
			codigoBarrasCompraField = value;
			RaisePropertyChanged("CodigoBarrasCompra");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
