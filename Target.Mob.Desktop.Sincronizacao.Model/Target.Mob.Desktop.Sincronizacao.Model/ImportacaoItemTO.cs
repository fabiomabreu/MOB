using System;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ImportacaoItemTO
{
	private int _Id;

	private int _IdImportacao;

	private DateTime _DataInicio;

	private EtapaImportacaoItemTR _IdEtapaImportacaoItemTR;

	private string _TabelaBancoDados;

	private DateTime? _DataFim;

	private StatusImportacaoItemTR _IdStatusImportacaoItemTR;

	private ImportacaoLogErroTO[] _oImportacaoLogErro;

	public int Id
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

	public int IdImportacao
	{
		get
		{
			return _IdImportacao;
		}
		set
		{
			_IdImportacao = value;
		}
	}

	public DateTime DataInicio
	{
		get
		{
			return _DataInicio;
		}
		set
		{
			_DataInicio = value;
		}
	}

	public EtapaImportacaoItemTR IdEtapaImportacaoItemTR
	{
		get
		{
			return _IdEtapaImportacaoItemTR;
		}
		set
		{
			_IdEtapaImportacaoItemTR = value;
		}
	}

	public string TabelaBancoDados
	{
		get
		{
			return _TabelaBancoDados;
		}
		set
		{
			_TabelaBancoDados = value;
		}
	}

	public DateTime? DataFim
	{
		get
		{
			return _DataFim;
		}
		set
		{
			_DataFim = value;
		}
	}

	public StatusImportacaoItemTR IdStatusImportacaoItemTR
	{
		get
		{
			return _IdStatusImportacaoItemTR;
		}
		set
		{
			_IdStatusImportacaoItemTR = value;
		}
	}

	public ImportacaoLogErroTO[] oImportacaoLogErro
	{
		get
		{
			return _oImportacaoLogErro;
		}
		set
		{
			_oImportacaoLogErro = value;
		}
	}
}
