using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(PromotorModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class PromotorWsModel : INotifyPropertyChanged
{
	private string cdPromotorField;

	private string cnpjCpfField;

	private string inscricaoField;

	private string nomeField;

	private string enderecoField;

	private string bairroField;

	private string municipioField;

	private string estadoField;

	private int? cepField;

	private string tpPessoaField;

	private bool? ativoField;

	private int? cdCepMunicipioField;

	private string logradouroField;

	private string numeroField;

	private string complementoField;

	private string cdPaisField;

	private string distritoField;

	private byte[] rowIdField;

	private int? promotorIdField;

	private string nomeGuerraField;

	private int? equipePromotorIdField;

	private decimal? latitudeField;

	private decimal? longitudeField;

	private string emailField;

	private byte? montagemRotVisitaIdField;

	private bool? utilizaPocketField;

	private ContPromotorWsModel[] listContPromotorWsModelField;

	private TelPromotorWsModel[] listTelPromotorWsModelField;

	private int? idConfiguracaoPromotorField;

	private int? iDProdutoVersaoField;

	[XmlElement(Order = 0)]
	public string CdPromotor
	{
		get
		{
			return cdPromotorField;
		}
		set
		{
			cdPromotorField = value;
			RaisePropertyChanged("CdPromotor");
		}
	}

	[XmlElement(Order = 1)]
	public string CnpjCpf
	{
		get
		{
			return cnpjCpfField;
		}
		set
		{
			cnpjCpfField = value;
			RaisePropertyChanged("CnpjCpf");
		}
	}

	[XmlElement(Order = 2)]
	public string Inscricao
	{
		get
		{
			return inscricaoField;
		}
		set
		{
			inscricaoField = value;
			RaisePropertyChanged("Inscricao");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
	public string Endereco
	{
		get
		{
			return enderecoField;
		}
		set
		{
			enderecoField = value;
			RaisePropertyChanged("Endereco");
		}
	}

	[XmlElement(Order = 5)]
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

	[XmlElement(Order = 6)]
	public string Municipio
	{
		get
		{
			return municipioField;
		}
		set
		{
			municipioField = value;
			RaisePropertyChanged("Municipio");
		}
	}

	[XmlElement(Order = 7)]
	public string Estado
	{
		get
		{
			return estadoField;
		}
		set
		{
			estadoField = value;
			RaisePropertyChanged("Estado");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public int? Cep
	{
		get
		{
			return cepField;
		}
		set
		{
			cepField = value;
			RaisePropertyChanged("Cep");
		}
	}

	[XmlElement(Order = 9)]
	public string TpPessoa
	{
		get
		{
			return tpPessoaField;
		}
		set
		{
			tpPessoaField = value;
			RaisePropertyChanged("TpPessoa");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
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

	[XmlElement(IsNullable = true, Order = 11)]
	public int? CdCepMunicipio
	{
		get
		{
			return cdCepMunicipioField;
		}
		set
		{
			cdCepMunicipioField = value;
			RaisePropertyChanged("CdCepMunicipio");
		}
	}

	[XmlElement(Order = 12)]
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

	[XmlElement(Order = 13)]
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

	[XmlElement(Order = 14)]
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

	[XmlElement(Order = 15)]
	public string CdPais
	{
		get
		{
			return cdPaisField;
		}
		set
		{
			cdPaisField = value;
			RaisePropertyChanged("CdPais");
		}
	}

	[XmlElement(Order = 16)]
	public string Distrito
	{
		get
		{
			return distritoField;
		}
		set
		{
			distritoField = value;
			RaisePropertyChanged("Distrito");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 17)]
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

	[XmlElement(IsNullable = true, Order = 18)]
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

	[XmlElement(Order = 19)]
	public string NomeGuerra
	{
		get
		{
			return nomeGuerraField;
		}
		set
		{
			nomeGuerraField = value;
			RaisePropertyChanged("NomeGuerra");
		}
	}

	[XmlElement(IsNullable = true, Order = 20)]
	public int? EquipePromotorId
	{
		get
		{
			return equipePromotorIdField;
		}
		set
		{
			equipePromotorIdField = value;
			RaisePropertyChanged("EquipePromotorId");
		}
	}

	[XmlElement(IsNullable = true, Order = 21)]
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

	[XmlElement(IsNullable = true, Order = 22)]
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

	[XmlElement(Order = 23)]
	public string Email
	{
		get
		{
			return emailField;
		}
		set
		{
			emailField = value;
			RaisePropertyChanged("Email");
		}
	}

	[XmlElement(IsNullable = true, Order = 24)]
	public byte? MontagemRotVisitaId
	{
		get
		{
			return montagemRotVisitaIdField;
		}
		set
		{
			montagemRotVisitaIdField = value;
			RaisePropertyChanged("MontagemRotVisitaId");
		}
	}

	[XmlElement(IsNullable = true, Order = 25)]
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

	[XmlArray(Order = 26)]
	public ContPromotorWsModel[] ListContPromotorWsModel
	{
		get
		{
			return listContPromotorWsModelField;
		}
		set
		{
			listContPromotorWsModelField = value;
			RaisePropertyChanged("ListContPromotorWsModel");
		}
	}

	[XmlArray(Order = 27)]
	public TelPromotorWsModel[] ListTelPromotorWsModel
	{
		get
		{
			return listTelPromotorWsModelField;
		}
		set
		{
			listTelPromotorWsModelField = value;
			RaisePropertyChanged("ListTelPromotorWsModel");
		}
	}

	[XmlElement(IsNullable = true, Order = 28)]
	public int? IdConfiguracaoPromotor
	{
		get
		{
			return idConfiguracaoPromotorField;
		}
		set
		{
			idConfiguracaoPromotorField = value;
			RaisePropertyChanged("IdConfiguracaoPromotor");
		}
	}

	[XmlElement(IsNullable = true, Order = 29)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
