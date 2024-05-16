using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(EndCliERPModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class EndCliERPWsModel : INotifyPropertyChanged
{
	private string tipoEnderecoField;

	private string logradouroField;

	private string numeroField;

	private string complementoField;

	private string bairroField;

	private string municipioField;

	private int? cepField;

	private string codigoEstadoField;

	private decimal? latitudeField;

	private decimal? longitudeField;

	private int? codigoProvedorCoordenadaField;

	[XmlElement(Order = 0)]
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

	[XmlElement(IsNullable = true, Order = 6)]
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

	[XmlElement(IsNullable = true, Order = 8)]
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

	[XmlElement(IsNullable = true, Order = 9)]
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

	[XmlElement(IsNullable = true, Order = 10)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
