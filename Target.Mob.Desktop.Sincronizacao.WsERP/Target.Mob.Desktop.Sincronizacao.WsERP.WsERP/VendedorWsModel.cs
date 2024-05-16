using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(VendedorModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class VendedorWsModel : INotifyPropertyChanged
{
	private int? iDVendedorField;

	private string nomeField;

	private int? iDProdutoVersaoField;

	private string codigoVendedorField;

	private int? iDDispositivoMovelField;

	private bool? ativoField;

	private int? iDConfiguracaoVendedorField;

	private bool? permiteEnviarArquivoSuporteField;

	private ProdutoVersaoWsModel produtoVersaoATUALField;

	private ProdutoVersaoWsModel produtoVersaoCARGAField;

	private bool? permitePrimeiroDownloadField;

	private DateTime? dataDownloadField;

	private bool? utilizaPocketField;

	private int? iDTipoGrupoField;

	private byte[] rowIdField;

	private bool? utilizaTabField;

	private string cdEquipeField;

	private string logradouroField;

	private string numeroField;

	private string complementoField;

	private string bairroField;

	private string municResField;

	private int? cepResField;

	private string estResField;

	private string paisField;

	private byte[] rowIdPainelField;

	private int? codigoEmpresaField;

	private bool? utilizaGPSField;

	private bool? enviaRotaLogGPSField;

	private int? raioAgrupamentoGPSField;

	private decimal? latitudeField;

	private decimal? longitudeField;

	private string cPFField;

	private bool? utilizaSincronizacaoViaAPIField;

	[XmlElement(IsNullable = true, Order = 0)]
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

	[XmlElement(Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 4)]
	public int? IDDispositivoMovel
	{
		get
		{
			return iDDispositivoMovelField;
		}
		set
		{
			iDDispositivoMovelField = value;
			RaisePropertyChanged("IDDispositivoMovel");
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

	[XmlElement(IsNullable = true, Order = 6)]
	public int? IDConfiguracaoVendedor
	{
		get
		{
			return iDConfiguracaoVendedorField;
		}
		set
		{
			iDConfiguracaoVendedorField = value;
			RaisePropertyChanged("IDConfiguracaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public bool? PermiteEnviarArquivoSuporte
	{
		get
		{
			return permiteEnviarArquivoSuporteField;
		}
		set
		{
			permiteEnviarArquivoSuporteField = value;
			RaisePropertyChanged("PermiteEnviarArquivoSuporte");
		}
	}

	[XmlElement(Order = 8)]
	public ProdutoVersaoWsModel ProdutoVersaoATUAL
	{
		get
		{
			return produtoVersaoATUALField;
		}
		set
		{
			produtoVersaoATUALField = value;
			RaisePropertyChanged("ProdutoVersaoATUAL");
		}
	}

	[XmlElement(Order = 9)]
	public ProdutoVersaoWsModel ProdutoVersaoCARGA
	{
		get
		{
			return produtoVersaoCARGAField;
		}
		set
		{
			produtoVersaoCARGAField = value;
			RaisePropertyChanged("ProdutoVersaoCARGA");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public bool? PermitePrimeiroDownload
	{
		get
		{
			return permitePrimeiroDownloadField;
		}
		set
		{
			permitePrimeiroDownloadField = value;
			RaisePropertyChanged("PermitePrimeiroDownload");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public DateTime? DataDownload
	{
		get
		{
			return dataDownloadField;
		}
		set
		{
			dataDownloadField = value;
			RaisePropertyChanged("DataDownload");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public bool? UtilizaPocket
	{
		get
		{
			return utilizaPocketField;
		}
		set
		{
			utilizaPocketField = value;
			RaisePropertyChanged("UtilizaPocket");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public int? IDTipoGrupo
	{
		get
		{
			return iDTipoGrupoField;
		}
		set
		{
			iDTipoGrupoField = value;
			RaisePropertyChanged("IDTipoGrupo");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 14)]
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

	[XmlElement(IsNullable = true, Order = 15)]
	public bool? UtilizaTab
	{
		get
		{
			return utilizaTabField;
		}
		set
		{
			utilizaTabField = value;
			RaisePropertyChanged("UtilizaTab");
		}
	}

	[XmlElement(Order = 16)]
	public string CdEquipe
	{
		get
		{
			return cdEquipeField;
		}
		set
		{
			cdEquipeField = value;
			RaisePropertyChanged("CdEquipe");
		}
	}

	[XmlElement(Order = 17)]
	public string Logradouro
	{
		get
		{
			return logradouroField;
		}
		set
		{
			logradouroField = value;
			RaisePropertyChanged("Logradouro");
		}
	}

	[XmlElement(Order = 18)]
	public string Numero
	{
		get
		{
			return numeroField;
		}
		set
		{
			numeroField = value;
			RaisePropertyChanged("Numero");
		}
	}

	[XmlElement(Order = 19)]
	public string Complemento
	{
		get
		{
			return complementoField;
		}
		set
		{
			complementoField = value;
			RaisePropertyChanged("Complemento");
		}
	}

	[XmlElement(Order = 20)]
	public string Bairro
	{
		get
		{
			return bairroField;
		}
		set
		{
			bairroField = value;
			RaisePropertyChanged("Bairro");
		}
	}

	[XmlElement(Order = 21)]
	public string MunicRes
	{
		get
		{
			return municResField;
		}
		set
		{
			municResField = value;
			RaisePropertyChanged("MunicRes");
		}
	}

	[XmlElement(IsNullable = true, Order = 22)]
	public int? CepRes
	{
		get
		{
			return cepResField;
		}
		set
		{
			cepResField = value;
			RaisePropertyChanged("CepRes");
		}
	}

	[XmlElement(Order = 23)]
	public string EstRes
	{
		get
		{
			return estResField;
		}
		set
		{
			estResField = value;
			RaisePropertyChanged("EstRes");
		}
	}

	[XmlElement(Order = 24)]
	public string Pais
	{
		get
		{
			return paisField;
		}
		set
		{
			paisField = value;
			RaisePropertyChanged("Pais");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 25)]
	public byte[] RowIdPainel
	{
		get
		{
			return rowIdPainelField;
		}
		set
		{
			rowIdPainelField = value;
			RaisePropertyChanged("RowIdPainel");
		}
	}

	[XmlElement(IsNullable = true, Order = 26)]
	public int? CodigoEmpresa
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

	[XmlElement(IsNullable = true, Order = 27)]
	public bool? UtilizaGPS
	{
		get
		{
			return utilizaGPSField;
		}
		set
		{
			utilizaGPSField = value;
			RaisePropertyChanged("UtilizaGPS");
		}
	}

	[XmlElement(IsNullable = true, Order = 28)]
	public bool? EnviaRotaLogGPS
	{
		get
		{
			return enviaRotaLogGPSField;
		}
		set
		{
			enviaRotaLogGPSField = value;
			RaisePropertyChanged("EnviaRotaLogGPS");
		}
	}

	[XmlElement(IsNullable = true, Order = 29)]
	public int? RaioAgrupamentoGPS
	{
		get
		{
			return raioAgrupamentoGPSField;
		}
		set
		{
			raioAgrupamentoGPSField = value;
			RaisePropertyChanged("RaioAgrupamentoGPS");
		}
	}

	[XmlElement(IsNullable = true, Order = 30)]
	public decimal? Latitude
	{
		get
		{
			return latitudeField;
		}
		set
		{
			latitudeField = value;
			RaisePropertyChanged("Latitude");
		}
	}

	[XmlElement(IsNullable = true, Order = 31)]
	public decimal? Longitude
	{
		get
		{
			return longitudeField;
		}
		set
		{
			longitudeField = value;
			RaisePropertyChanged("Longitude");
		}
	}

	[XmlElement(Order = 32)]
	public string CPF
	{
		get
		{
			return cPFField;
		}
		set
		{
			cPFField = value;
			RaisePropertyChanged("CPF");
		}
	}

	[XmlElement(IsNullable = true, Order = 33)]
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
