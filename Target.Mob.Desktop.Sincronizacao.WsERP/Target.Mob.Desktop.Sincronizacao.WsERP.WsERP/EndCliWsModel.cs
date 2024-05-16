using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(EndCliModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class EndCliWsModel : INotifyPropertyChanged
{
	private int? iDEndCliField;

	private string logradouroField;

	private string numeroField;

	private string complementoField;

	private string bairroField;

	private string municipioField;

	private string cepField;

	private string codigoEstadoField;

	private string tipoEnderecoField;

	private int? codigoClienteField;

	private decimal? latitudeField;

	private decimal? longitudeField;

	private int? codigoProvedorCoordenadaField;

	private string distritoField;

	private string tipoOperacaoField;

	private string paisField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDEndCli
	{
		get
		{
			return iDEndCliField;
		}
		set
		{
			iDEndCliField = value;
			RaisePropertyChanged("IDEndCli");
		}
	}

	[XmlElement(Order = 1)]
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

	[XmlElement(Order = 2)]
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

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
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

	[XmlElement(Order = 5)]
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

	[XmlElement(Order = 6)]
	public string Cep
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

	[XmlElement(Order = 7)]
	public string CodigoEstado
	{
		get
		{
			return codigoEstadoField;
		}
		set
		{
			codigoEstadoField = value;
			RaisePropertyChanged("CodigoEstado");
		}
	}

	[XmlElement(Order = 8)]
	public string TipoEndereco
	{
		get
		{
			return tipoEnderecoField;
		}
		set
		{
			tipoEnderecoField = value;
			RaisePropertyChanged("TipoEndereco");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public int? CodigoCliente
	{
		get
		{
			return codigoClienteField;
		}
		set
		{
			codigoClienteField = value;
			RaisePropertyChanged("CodigoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
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

	[XmlElement(IsNullable = true, Order = 11)]
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

	[XmlElement(IsNullable = true, Order = 12)]
	public int? CodigoProvedorCoordenada
	{
		get
		{
			return codigoProvedorCoordenadaField;
		}
		set
		{
			codigoProvedorCoordenadaField = value;
			RaisePropertyChanged("CodigoProvedorCoordenada");
		}
	}

	[XmlElement(Order = 13)]
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

	[XmlElement(Order = 14)]
	public string TipoOperacao
	{
		get
		{
			return tipoOperacaoField;
		}
		set
		{
			tipoOperacaoField = value;
			RaisePropertyChanged("TipoOperacao");
		}
	}

	[XmlElement(Order = 15)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
