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
public class ProdutoTO : BaseTO
{
	private int idProdutoField;

	private int idProdutoPainelField;

	private string descricaoField;

	private bool ativoField;

	private int codigoSistemaOperacionalField;

	private bool liberarAutomaticoField;

	private ProdutoVersaoTO[] versoesField;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 1)]
	public int IdProdutoPainel
	{
		get
		{
			return idProdutoPainelField;
		}
		set
		{
			idProdutoPainelField = value;
			RaisePropertyChanged("IdProdutoPainel");
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

	[XmlElement(Order = 4)]
	public int CodigoSistemaOperacional
	{
		get
		{
			return codigoSistemaOperacionalField;
		}
		set
		{
			codigoSistemaOperacionalField = value;
			RaisePropertyChanged("CodigoSistemaOperacional");
		}
	}

	[XmlElement(Order = 5)]
	public bool LiberarAutomatico
	{
		get
		{
			return liberarAutomaticoField;
		}
		set
		{
			liberarAutomaticoField = value;
			RaisePropertyChanged("LiberarAutomatico");
		}
	}

	[XmlArray(Order = 6)]
	public ProdutoVersaoTO[] Versoes
	{
		get
		{
			return versoesField;
		}
		set
		{
			versoesField = value;
			RaisePropertyChanged("Versoes");
		}
	}
}
