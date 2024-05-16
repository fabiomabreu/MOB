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
public class DistribuidoraProdutoVersaoWsModel : INotifyPropertyChanged
{
	private int? iDDistribuidoraProdutoVersaoField;

	private int? iDDistribuidoraField;

	private int? iDProdutoVersaoField;

	private string produtoField;

	private string descricaoProdutoVersaoField;

	private string nomeField;

	private DistribuidoraProdutoVersaoVendedorWsModel[] distribuidoraProdutoVersaoVendedorWsField;

	[XmlElement(IsNullable = true, Order = 0)]
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

	[XmlElement(IsNullable = true, Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
	public int? IDProdutoVersao
	{
		get
		{
			return iDProdutoVersaoField;
		}
		set
		{
			iDProdutoVersaoField = value;
			RaisePropertyChanged("IDProdutoVersao");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
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

	[XmlArray(Order = 6)]
	public DistribuidoraProdutoVersaoVendedorWsModel[] DistribuidoraProdutoVersaoVendedorWs
	{
		get
		{
			return distribuidoraProdutoVersaoVendedorWsField;
		}
		set
		{
			distribuidoraProdutoVersaoVendedorWsField = value;
			RaisePropertyChanged("DistribuidoraProdutoVersaoVendedorWs");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
