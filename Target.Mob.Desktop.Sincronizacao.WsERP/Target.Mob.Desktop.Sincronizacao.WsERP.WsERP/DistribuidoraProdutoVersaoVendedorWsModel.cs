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
public class DistribuidoraProdutoVersaoVendedorWsModel : INotifyPropertyChanged
{
	private int? iDDistribuidoraProdutoVersaoVendedorField;

	private int? iDDistribuidoraProdutoVersaoField;

	private int? iDDistribuidoraField;

	private int? iDVendedorField;

	private string produtoField;

	private string descricaoProdutoVersaoField;

	private string nomeField;

	private string versaoAndroidField;

	private int? majorField;

	private int? minorField;

	private int? iDProdutoField;

	private string codigoVendedorField;

	private bool? utilizaSincronizacaoViaAPIField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDDistribuidoraProdutoVersaoVendedor
	{
		get
		{
			return iDDistribuidoraProdutoVersaoVendedorField;
		}
		set
		{
			iDDistribuidoraProdutoVersaoVendedorField = value;
			RaisePropertyChanged("IDDistribuidoraProdutoVersaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IDDistribuidoraProdutoVersao
	{
		get
		{
			return iDDistribuidoraProdutoVersaoField;
		}
		set
		{
			iDDistribuidoraProdutoVersaoField = value;
			RaisePropertyChanged("IDDistribuidoraProdutoVersao");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? IDDistribuidora
	{
		get
		{
			return iDDistribuidoraField;
		}
		set
		{
			iDDistribuidoraField = value;
			RaisePropertyChanged("IDDistribuidora");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
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

	[XmlElement(Order = 4)]
	public string Produto
	{
		get
		{
			return produtoField;
		}
		set
		{
			produtoField = value;
			RaisePropertyChanged("Produto");
		}
	}

	[XmlElement(Order = 5)]
	public string DescricaoProdutoVersao
	{
		get
		{
			return descricaoProdutoVersaoField;
		}
		set
		{
			descricaoProdutoVersaoField = value;
			RaisePropertyChanged("DescricaoProdutoVersao");
		}
	}

	[XmlElement(Order = 6)]
	public string Nome
	{
		get
		{
			return nomeField;
		}
		set
		{
			nomeField = value;
			RaisePropertyChanged("Nome");
		}
	}

	[XmlElement(Order = 7)]
	public string VersaoAndroid
	{
		get
		{
			return versaoAndroidField;
		}
		set
		{
			versaoAndroidField = value;
			RaisePropertyChanged("VersaoAndroid");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public int? Major
	{
		get
		{
			return majorField;
		}
		set
		{
			majorField = value;
			RaisePropertyChanged("Major");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public int? Minor
	{
		get
		{
			return minorField;
		}
		set
		{
			minorField = value;
			RaisePropertyChanged("Minor");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public int? IDProduto
	{
		get
		{
			return iDProdutoField;
		}
		set
		{
			iDProdutoField = value;
			RaisePropertyChanged("IDProduto");
		}
	}

	[XmlElement(Order = 11)]
	public string CodigoVendedor
	{
		get
		{
			return codigoVendedorField;
		}
		set
		{
			codigoVendedorField = value;
			RaisePropertyChanged("CodigoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public bool? UtilizaSincronizacaoViaAPI
	{
		get
		{
			return utilizaSincronizacaoViaAPIField;
		}
		set
		{
			utilizaSincronizacaoViaAPIField = value;
			RaisePropertyChanged("UtilizaSincronizacaoViaAPI");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
