using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(RelatorioGerencialModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class RelatorioGerencialWsModel : INotifyPropertyChanged
{
	private int? iDRelatorioGerencialField;

	private int? iDVendedorField;

	private string nomeArquivoField;

	private byte[] arquivoRelatorioField;

	private DateTime? dtRecebimentoField;

	private DateTime? dtImportacaoField;

	private string codigoVendedorField;

	private string linkField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDRelatorioGerencial
	{
		get
		{
			return iDRelatorioGerencialField;
		}
		set
		{
			iDRelatorioGerencialField = value;
			RaisePropertyChanged("IDRelatorioGerencial");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
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

	[XmlElement(Order = 2)]
	public string NomeArquivo
	{
		get
		{
			return nomeArquivoField;
		}
		set
		{
			nomeArquivoField = value;
			RaisePropertyChanged("NomeArquivo");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 3)]
	public byte[] ArquivoRelatorio
	{
		get
		{
			return arquivoRelatorioField;
		}
		set
		{
			arquivoRelatorioField = value;
			RaisePropertyChanged("ArquivoRelatorio");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public DateTime? DtRecebimento
	{
		get
		{
			return dtRecebimentoField;
		}
		set
		{
			dtRecebimentoField = value;
			RaisePropertyChanged("DtRecebimento");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public DateTime? DtImportacao
	{
		get
		{
			return dtImportacaoField;
		}
		set
		{
			dtImportacaoField = value;
			RaisePropertyChanged("DtImportacao");
		}
	}

	[XmlElement(Order = 6)]
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

	[XmlElement(Order = 7)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
