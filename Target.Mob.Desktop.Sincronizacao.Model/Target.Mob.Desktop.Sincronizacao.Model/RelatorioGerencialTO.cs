using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class RelatorioGerencialTO
{
	private int? _IDRelatorioGerencial;

	private int? _IDVendedor;

	private string _NomeArquivo;

	private byte[] _ArquivoRelatorio;

	private DateTime? _DtRecebimento;

	private DateTime? _DtImportacao;

	private string _linkArquivo;

	private string _CodigoVendedor;

	public int? IDRelatorioGerencial
	{
		get
		{
			return _IDRelatorioGerencial;
		}
		set
		{
			_IDRelatorioGerencial = value;
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

	public string NomeArquivo
	{
		get
		{
			return _NomeArquivo;
		}
		set
		{
			_NomeArquivo = value;
		}
	}

	public byte[] ArquivoRelatorio
	{
		get
		{
			return _ArquivoRelatorio;
		}
		set
		{
			_ArquivoRelatorio = value;
		}
	}

	public DateTime? DtRecebimento
	{
		get
		{
			return _DtRecebimento;
		}
		set
		{
			_DtRecebimento = value;
		}
	}

	public DateTime? DtImportacao
	{
		get
		{
			return _DtImportacao;
		}
		set
		{
			_DtImportacao = value;
		}
	}

	public string Link
	{
		get
		{
			return _linkArquivo;
		}
		set
		{
			_linkArquivo = value;
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

	public RelatorioGerencialTO()
	{
	}

	public RelatorioGerencialTO(int? iDRelatorioGerencial, int? idVendedor, string nomeArquivo, byte[] arquivoRelatorio, DateTime? dtRecebimento, DateTime? dtImportacao, string codigoVendedor)
	{
		_IDRelatorioGerencial = iDRelatorioGerencial;
		_IDVendedor = idVendedor;
		_NomeArquivo = nomeArquivo;
		_ArquivoRelatorio = arquivoRelatorio;
		_DtRecebimento = dtRecebimento;
		_DtImportacao = dtImportacao;
		_CodigoVendedor = codigoVendedor;
	}
}
