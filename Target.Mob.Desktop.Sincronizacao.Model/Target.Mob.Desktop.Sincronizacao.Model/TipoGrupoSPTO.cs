using System.Collections.Generic;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TipoGrupoSPTO
{
	private int? _IDTipoGrupoSP;

	private int? _IDTipoGrupo;

	private int? _IDCadastroSP;

	private TipoGrupoTO _tipoGrupo;

	private CadastroSPTO _cadastroSP;

	private VendedorRelatorioTO _vendedorRelatorio;

	private List<TipoGrupoTO> _ListaTipoGrupoTO = new List<TipoGrupoTO>();

	private List<CadastroSPTO> _ListaCadastroSPTO = new List<CadastroSPTO>();

	private List<VendedorRelatorioTO> _ListaVendedorTO = new List<VendedorRelatorioTO>();

	public int? IDTipoGrupoSP
	{
		get
		{
			return _IDTipoGrupoSP;
		}
		set
		{
			_IDTipoGrupoSP = value;
		}
	}

	public int? IDTipoGrupo
	{
		get
		{
			return _IDTipoGrupo;
		}
		set
		{
			_IDTipoGrupo = value;
		}
	}

	public int? IDCadastroSP
	{
		get
		{
			return _IDCadastroSP;
		}
		set
		{
			_IDCadastroSP = value;
		}
	}

	public TipoGrupoTO TipoGrupo
	{
		get
		{
			return _tipoGrupo;
		}
		set
		{
			_tipoGrupo = value;
		}
	}

	public CadastroSPTO CadastroSP
	{
		get
		{
			return _cadastroSP;
		}
		set
		{
			_cadastroSP = value;
		}
	}

	public List<TipoGrupoTO> ListTipoGrupoTO
	{
		get
		{
			return _ListaTipoGrupoTO;
		}
		set
		{
			_ListaTipoGrupoTO = value;
		}
	}

	public List<CadastroSPTO> ListaCadastroSPTO
	{
		get
		{
			return _ListaCadastroSPTO;
		}
		set
		{
			_ListaCadastroSPTO = value;
		}
	}

	public List<VendedorRelatorioTO> ListaVendedorTO
	{
		get
		{
			return _ListaVendedorTO;
		}
		set
		{
			_ListaVendedorTO = value;
		}
	}

	public TipoGrupoSPTO()
	{
	}

	public TipoGrupoSPTO(int? iDTipoGrupoSP, int? iDTipoGrupo, int? iDCadastroSP, List<TipoGrupoTO> listaTipoGrupoTO, List<CadastroSPTO> listaCadastroSPTO, List<VendedorRelatorioTO> listaVendedorRelatorioTO)
	{
		_IDTipoGrupoSP = iDTipoGrupoSP;
		_IDTipoGrupo = iDTipoGrupo;
		_IDCadastroSP = iDCadastroSP;
		_ListaTipoGrupoTO = listaTipoGrupoTO;
		_ListaCadastroSPTO = listaCadastroSPTO;
		_ListaCadastroSPTO = listaCadastroSPTO;
		_ListaVendedorTO = listaVendedorRelatorioTO;
	}
}
