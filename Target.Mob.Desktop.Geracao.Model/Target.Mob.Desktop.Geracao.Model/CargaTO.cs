using System;
using Target.Mob.Desktop.Geracao.Enum;

namespace Target.Mob.Desktop.Geracao.Model;

public class CargaTO
{
	private int? _Id;

	private DateTime? _DataGeracao;

	private int? _IdVendedor;

	private int? _IdVersaoCarga;

	private int? _IdGeracao;

	private TipoCargaTR? _TipoCarga;

	private byte[] _ArquivoCarga;

	private bool? _Transmitido;

	private DateTime? _DataTransmitido;

	private GeracaoTO _Geracao;

	public int? Id
	{
		get
		{
			return _Id;
		}
		set
		{
			_Id = value;
		}
	}

	public DateTime? DataGeracao
	{
		get
		{
			return _DataGeracao;
		}
		set
		{
			_DataGeracao = value;
		}
	}

	public int? IdVendedor
	{
		get
		{
			return _IdVendedor;
		}
		set
		{
			_IdVendedor = value;
		}
	}

	public int? IdVersaoCarga
	{
		get
		{
			return _IdVersaoCarga;
		}
		set
		{
			_IdVersaoCarga = value;
		}
	}

	public int? IdGeracao
	{
		get
		{
			return _IdGeracao;
		}
		set
		{
			_IdGeracao = value;
		}
	}

	public TipoCargaTR? TipoCarga
	{
		get
		{
			return _TipoCarga;
		}
		set
		{
			_TipoCarga = value;
		}
	}

	public byte[] ArquivoCarga
	{
		get
		{
			return _ArquivoCarga;
		}
		set
		{
			_ArquivoCarga = value;
		}
	}

	public bool? Transmitido
	{
		get
		{
			return _Transmitido;
		}
		set
		{
			_Transmitido = value;
		}
	}

	public DateTime? DataTransmitido
	{
		get
		{
			return _DataTransmitido;
		}
		set
		{
			_DataTransmitido = value;
		}
	}

	public GeracaoTO Geracao
	{
		get
		{
			return _Geracao;
		}
		set
		{
			_Geracao = value;
		}
	}
}
