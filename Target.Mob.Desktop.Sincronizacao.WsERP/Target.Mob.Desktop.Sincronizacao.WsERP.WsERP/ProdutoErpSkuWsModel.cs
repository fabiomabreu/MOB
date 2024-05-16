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
public class ProdutoErpSkuWsModel : INotifyPropertyChanged
{
	private ProdutoErpWsModel produtoErpField;

	private string unidadeField;

	private int? seqField;

	private string tpCdBarraUnField;

	private string cdBarraUnField;

	private bool? ativoField;

	private byte[] rowIdField;

	[XmlElement(Order = 0)]
	public ProdutoErpWsModel ProdutoErp
	{
		get
		{
			return produtoErpField;
		}
		set
		{
			produtoErpField = value;
			RaisePropertyChanged("ProdutoErp");
		}
	}

	[XmlElement(Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
	public int? Seq
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

	[XmlElement(Order = 3)]
	public string TpCdBarraUn
	{
		get
		{
			return tpCdBarraUnField;
		}
		set
		{
			tpCdBarraUnField = value;
			RaisePropertyChanged("TpCdBarraUn");
		}
	}

	[XmlElement(Order = 4)]
	public string CdBarraUn
	{
		get
		{
			return cdBarraUnField;
		}
		set
		{
			cdBarraUnField = value;
			RaisePropertyChanged("CdBarraUn");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
