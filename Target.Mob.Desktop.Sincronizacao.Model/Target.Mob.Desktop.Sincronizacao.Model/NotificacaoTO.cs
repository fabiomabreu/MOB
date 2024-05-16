using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class NotificacaoTO
{
	private int? _IDNotificacao;

	private int? _IDTipoNotificacao;

	private DateTime? _DataPublicacao;

	private string _Titulo;

	private string _Descricao;

	private DateTime? _DtTransmitido;

	private int? _IDVendedor;

	private string _CodigoVendedor;

	public int? IDNotificacao
	{
		get
		{
			return _IDNotificacao;
		}
		set
		{
			_IDNotificacao = value;
		}
	}

	public int? IDTipoNotificacao
	{
		get
		{
			return _IDTipoNotificacao;
		}
		set
		{
			_IDTipoNotificacao = value;
		}
	}

	public DateTime? DataPublicacao
	{
		get
		{
			return _DataPublicacao;
		}
		set
		{
			_DataPublicacao = value;
		}
	}

	public string Titulo
	{
		get
		{
			return _Titulo;
		}
		set
		{
			_Titulo = value;
		}
	}

	public string Descricao
	{
		get
		{
			return _Descricao;
		}
		set
		{
			_Descricao = value;
		}
	}

	public DateTime? DtTransmitido
	{
		get
		{
			return _DtTransmitido;
		}
		set
		{
			_DtTransmitido = value;
		}
	}

	public int? IDVendedor
	{
		get
		{
			return _IDVendedor;
		}
		set
		{
			_IDVendedor = value;
		}
	}

	public string CodigoVendedor
	{
		get
		{
			return _CodigoVendedor;
		}
		set
		{
			_CodigoVendedor = value;
		}
	}
}
