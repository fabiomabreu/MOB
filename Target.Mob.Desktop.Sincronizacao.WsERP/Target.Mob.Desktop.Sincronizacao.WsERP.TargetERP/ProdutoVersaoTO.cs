using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class ProdutoVersaoTO : BaseTO
{
	private int idProdutoVersaoField;

	private string descricaoField;

	private bool ativoField;

	private byte[] arquivoField;

	private int idProdutoField;

	private ProdutoTO fK_IdProdutoField;

	private int majorField;

	private int minorField;

	private int buildField;

	private int revisionField;

	private string extensaoField;

	private string nomeArquivoFinalField;

	[XmlElement(Order = 0)]
	public int IdProdutoVersao
	{
		get
		{
			return idProdutoVersaoField;
		}
		set
		{
			idProdutoVersaoField = value;
			RaisePropertyChanged("IdProdutoVersao");
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

	[XmlElement(Order = 2)]
	public bool Ativo
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

	[XmlElement(Order = 4)]
	public int IdProduto
	{
		get
		{
			return idProdutoField;
		}
		set
		{
			idProdutoField = value;
			RaisePropertyChanged("IdProduto");
		}
	}

	[XmlElement(Order = 5)]
	public ProdutoTO FK_IdProduto
	{
		get
		{
			return fK_IdProdutoField;
		}
		set
		{
			fK_IdProdutoField = value;
			RaisePropertyChanged("FK_IdProduto");
		}
	}

	[XmlElement(Order = 6)]
	public int Major
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

	[XmlElement(Order = 7)]
	public int Minor
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

	[XmlElement(Order = 8)]
	public int Build
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

	[XmlElement(Order = 9)]
	public int Revision
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

	[XmlElement(Order = 10)]
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

	[XmlElement(Order = 11)]
	public string NomeArquivoFinal
	{
		get
		{
			return nomeArquivoFinalField;
		}
		set
		{
			nomeArquivoFinalField = value;
			RaisePropertyChanged("NomeArquivoFinal");
		}
	}
}
