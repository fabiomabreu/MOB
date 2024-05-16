using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ProdutoVersaoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ProdutoVersaoWsModel : INotifyPropertyChanged
{
	private int? iDProdutoVersaoField;

	private string descricaoField;

	private bool? ativoField;

	private byte[] arquivoField;

	private int? iDProdutoField;

	private DistribuidoraProdutoVersaoWsModel[] distribuidoraProdutoVersaoWsField;

	private int? majorField;

	private int? minorField;

	private int? buildField;

	private int? revisionField;

	private int? idVendedorField;

	private int? iDDistribuidoraField;

	private string produtoField;

	private string linkField;

	private string dbNameField;

	private string extensaoField;

	private int? promotorIdField;

	[XmlElement(IsNullable = true, Order = 0)]
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

	[XmlElement(Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
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

	[XmlElement(DataType = "base64Binary", Order = 3)]
	public byte[] Arquivo
	{
		get
		{
			return arquivoField;
		}
		set
		{
			arquivoField = value;
			RaisePropertyChanged("Arquivo");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
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

	[XmlArray(Order = 5)]
	public DistribuidoraProdutoVersaoWsModel[] DistribuidoraProdutoVersaoWs
	{
		get
		{
			return distribuidoraProdutoVersaoWsField;
		}
		set
		{
			distribuidoraProdutoVersaoWsField = value;
			RaisePropertyChanged("DistribuidoraProdutoVersaoWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
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

	[XmlElement(IsNullable = true, Order = 7)]
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

	[XmlElement(IsNullable = true, Order = 8)]
	public int? Build
	{
		get
		{
			return buildField;
		}
		set
		{
			buildField = value;
			RaisePropertyChanged("Build");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public int? Revision
	{
		get
		{
			return revisionField;
		}
		set
		{
			revisionField = value;
			RaisePropertyChanged("Revision");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
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

	[XmlElement(IsNullable = true, Order = 11)]
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

	[XmlElement(Order = 12)]
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

	[XmlElement(Order = 13)]
	public string Link
	{
		get
		{
			return linkField;
		}
		set
		{
			linkField = value;
			RaisePropertyChanged("Link");
		}
	}

	[XmlElement(Order = 14)]
	public string DbName
	{
		get
		{
			return dbNameField;
		}
		set
		{
			dbNameField = value;
			RaisePropertyChanged("DbName");
		}
	}

	[XmlElement(Order = 15)]
	public string Extensao
	{
		get
		{
			return extensaoField;
		}
		set
		{
			extensaoField = value;
			RaisePropertyChanged("Extensao");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public int? PromotorId
	{
		get
		{
			return promotorIdField;
		}
		set
		{
			promotorIdField = value;
			RaisePropertyChanged("PromotorId");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
