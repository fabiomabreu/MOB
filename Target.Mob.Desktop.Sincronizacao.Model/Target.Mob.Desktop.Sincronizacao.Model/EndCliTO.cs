using System;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class EndCliTO : ICloneable
{
	private int _CdClien;

	private string _TpEnd;

	private string _TpEndString;

	private string _Endereco;

	private string _Bairro;

	private string _Municipio;

	private int _Cep;

	private string _CepString;

	private string _Estado;

	private string _LocGuia;

	private string _LocalCob;

	private string _PontoCardealLat;

	private int? _GrauLat;

	private int? _MinLat;

	private int? _SegLat;

	private string _PontoCardealLon;

	private int? _GrauLon;

	private int? _MinLon;

	private int? _SegLon;

	private int? _CdCepMunic;

	private string _Logradouro;

	private string _Numero;

	private string _Complemento;

	private string _CdPais;

	private decimal? _Longitude;

	private decimal? _Latitude;

	private int? _CodigoProvedorCoordenada;

	private string _Distrito;

	private string _TipoOperacao;

	private string _IncMobLogradouro;

	private string _IncMobNumero;

	private string _IncMobComplemento;

	private int? _FonteCoordenadaID;

	private int? _OrigemCoordenadaID;

	private string _CodigoPostal;

	public string IncMobComplemento
	{
		get
		{
			return _IncMobComplemento;
		}
		set
		{
			_IncMobComplemento = value;
		}
	}

	public string IncMobNumero
	{
		get
		{
			return _IncMobNumero;
		}
		set
		{
			_IncMobNumero = value;
		}
	}

	public string IncMobLogradouro
	{
		get
		{
			return _IncMobLogradouro;
		}
		set
		{
			_IncMobLogradouro = value;
		}
	}

	public int CdClien
	{
		get
		{
			return _CdClien;
		}
		set
		{
			_CdClien = value;
		}
	}

	public TipoEndereco TpEnd
	{
		get
		{
			return _TpEnd switch
			{
				"CO" => TipoEndereco.Cobranca, 
				"EN" => TipoEndereco.Entrega, 
				"FA" => TipoEndereco.Faturamento, 
				_ => TipoEndereco.Faturamento, 
			};
		}
		set
		{
			switch (value)
			{
			case TipoEndereco.Cobranca:
				_TpEnd = "CO";
				break;
			case TipoEndereco.Entrega:
				_TpEnd = "EN";
				break;
			case TipoEndereco.Faturamento:
				_TpEnd = "FA";
				break;
			default:
				_TpEnd = "FA";
				break;
			}
		}
	}

	public string TpEndString
	{
		get
		{
			return _TpEndString;
		}
		set
		{
			_TpEndString = value;
		}
	}

	public string Endereco
	{
		get
		{
			return _Endereco;
		}
		set
		{
			_Endereco = value;
		}
	}

	public string Bairro
	{
		get
		{
			return _Bairro;
		}
		set
		{
			_Bairro = value;
		}
	}

	public string Municipio
	{
		get
		{
			return _Municipio;
		}
		set
		{
			_Municipio = value;
		}
	}

	public int Cep
	{
		get
		{
			return _Cep;
		}
		set
		{
			_Cep = value;
		}
	}

	public string CepString
	{
		get
		{
			return _CepString;
		}
		set
		{
			_CepString = value;
		}
	}

	public string Estado
	{
		get
		{
			return _Estado;
		}
		set
		{
			_Estado = value;
		}
	}

	public string LocGuia
	{
		get
		{
			return _LocGuia;
		}
		set
		{
			_LocGuia = value;
		}
	}

	public string LocalCob
	{
		get
		{
			return _LocalCob;
		}
		set
		{
			_LocalCob = value;
		}
	}

	public PontosCardeais PontoCardealLat
	{
		get
		{
			string pontoCardealLat = _PontoCardealLat;
			if (!(pontoCardealLat == "N"))
			{
				if (pontoCardealLat == "S")
				{
					return PontosCardeais.Sul;
				}
				return PontosCardeais.Norte;
			}
			return PontosCardeais.Norte;
		}
		set
		{
			switch (value)
			{
			case PontosCardeais.Norte:
				_PontoCardealLat = "N";
				break;
			case PontosCardeais.Sul:
				_PontoCardealLat = "S";
				break;
			default:
				_PontoCardealLat = "N";
				break;
			}
		}
	}

	public int? GrauLat
	{
		get
		{
			return _GrauLat;
		}
		set
		{
			_GrauLat = value;
		}
	}

	public int? MinLat
	{
		get
		{
			return _MinLat;
		}
		set
		{
			_MinLat = value;
		}
	}

	public int? SegLat
	{
		get
		{
			return _SegLat;
		}
		set
		{
			_SegLat = value;
		}
	}

	public PontosCardeais PontoCardealLon
	{
		get
		{
			string pontoCardealLon = _PontoCardealLon;
			if (!(pontoCardealLon == "E"))
			{
				if (pontoCardealLon == "W")
				{
					return PontosCardeais.Oeste;
				}
				return PontosCardeais.Leste;
			}
			return PontosCardeais.Leste;
		}
		set
		{
			switch (value)
			{
			case PontosCardeais.Leste:
				_PontoCardealLon = "E";
				break;
			case PontosCardeais.Oeste:
				_PontoCardealLon = "W";
				break;
			default:
				_PontoCardealLat = "E";
				break;
			}
		}
	}

	public int? GrauLon
	{
		get
		{
			return _GrauLon;
		}
		set
		{
			_GrauLon = value;
		}
	}

	public int? MinLon
	{
		get
		{
			return _MinLon;
		}
		set
		{
			_MinLon = value;
		}
	}

	public int? SegLon
	{
		get
		{
			return _SegLon;
		}
		set
		{
			_SegLon = value;
		}
	}

	public int? CdCepMunic
	{
		get
		{
			return _CdCepMunic;
		}
		set
		{
			_CdCepMunic = value;
		}
	}

	public string Logradouro
	{
		get
		{
			return _Logradouro;
		}
		set
		{
			_Logradouro = value;
		}
	}

	public string Numero
	{
		get
		{
			return _Numero;
		}
		set
		{
			_Numero = value;
		}
	}

	public string Complemento
	{
		get
		{
			return _Complemento;
		}
		set
		{
			_Complemento = value;
		}
	}

	public string CdPais
	{
		get
		{
			return _CdPais;
		}
		set
		{
			_CdPais = value;
		}
	}

	public decimal? Longitude
	{
		get
		{
			return _Longitude;
		}
		set
		{
			_Longitude = value;
		}
	}

	public decimal? Latitude
	{
		get
		{
			return _Latitude;
		}
		set
		{
			_Latitude = value;
		}
	}

	public int? CodigoProvedorCoordenada
	{
		get
		{
			return _CodigoProvedorCoordenada;
		}
		set
		{
			_CodigoProvedorCoordenada = value;
		}
	}

	public string Distrito
	{
		get
		{
			return _Distrito;
		}
		set
		{
			_Distrito = value;
		}
	}

	public string TipoOperacao
	{
		get
		{
			return _TipoOperacao;
		}
		set
		{
			_TipoOperacao = value;
		}
	}

	public int? OrigemCoordenadaID
	{
		get
		{
			return _OrigemCoordenadaID;
		}
		set
		{
			_OrigemCoordenadaID = value;
		}
	}

	public int? FonteCoordenadaID
	{
		get
		{
			return _FonteCoordenadaID;
		}
		set
		{
			_FonteCoordenadaID = value;
		}
	}

	public string CodigoPostal
	{
		get
		{
			return _CodigoPostal;
		}
		set
		{
			_CodigoPostal = value;
		}
	}

	public void AtribuiTpEnd(string TpEnd)
	{
		this.TpEnd = TpEnd switch
		{
			"CO" => TipoEndereco.Cobranca, 
			"EN" => TipoEndereco.Entrega, 
			"FA" => TipoEndereco.Faturamento, 
			_ => TipoEndereco.Faturamento, 
		};
	}

	public string RetornaTpEnd()
	{
		return _TpEnd;
	}

	public string RetornaPontoCardealLat()
	{
		return _PontoCardealLat;
	}

	public string RetornaPontoCardealLon()
	{
		return _PontoCardealLon;
	}

	public EndCliTO()
	{
	}

	public EndCliTO(TipoEndereco TpEnd)
	{
		this.TpEnd = TpEnd;
	}

	public object Clone()
	{
		return MemberwiseClone();
	}
}
