using System;
using System.Collections.Generic;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TrocaTO
{
	private int _SeqTroca;

	private DateTime _DtCad;

	private string _CdVend;

	private string _CdTabela;

	private int _CdClien;

	private string _CdMotcanc;

	private string _ProdLocaliza;

	private int? _CdEmpEstoque;

	private string _CdLocalEstoque;

	private int? _CdEmpPedido;

	private int? _NuPedPedido;

	private decimal _VlTotal;

	private string _Situacao;

	private string _TpAbatimento;

	private string _TpEnvio;

	private decimal _VlTotalRecebido;

	private int _CdEmp;

	private string _Referencia;

	private string _CdTrocaPalm;

	private DateTime? _DtCadPalm;

	private bool? _Indenizacao;

	private ItTrocaTO[] _oItTroca;

	public bool? Indenizacao
	{
		get
		{
			return _Indenizacao;
		}
		set
		{
			_Indenizacao = value;
		}
	}

	public int SeqTroca
	{
		get
		{
			return _SeqTroca;
		}
		set
		{
			_SeqTroca = value;
		}
	}

	public DateTime DtCad
	{
		get
		{
			return _DtCad;
		}
		set
		{
			_DtCad = value;
		}
	}

	public string CdVend
	{
		get
		{
			return _CdVend;
		}
		set
		{
			_CdVend = value;
		}
	}

	public string CdTabela
	{
		get
		{
			return _CdTabela;
		}
		set
		{
			_CdTabela = value;
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

	public string CdMotcanc
	{
		get
		{
			return _CdMotcanc;
		}
		set
		{
			_CdMotcanc = value;
		}
	}

	public LocalProdutoTroca ProdLocaliza
	{
		get
		{
			return _ProdLocaliza switch
			{
				"C" => LocalProdutoTroca.Cliente, 
				"E" => LocalProdutoTroca.Empresa, 
				"V" => LocalProdutoTroca.Vendedor, 
				_ => LocalProdutoTroca.Cliente, 
			};
		}
		set
		{
			switch (value)
			{
			case LocalProdutoTroca.Cliente:
				_ProdLocaliza = "C";
				break;
			case LocalProdutoTroca.Empresa:
				_ProdLocaliza = "E";
				break;
			case LocalProdutoTroca.Vendedor:
				_ProdLocaliza = "V";
				break;
			default:
				_ProdLocaliza = "C";
				break;
			}
		}
	}

	public int? CdEmpEstoque
	{
		get
		{
			return _CdEmpEstoque;
		}
		set
		{
			_CdEmpEstoque = value;
		}
	}

	public string CdLocalEstoque
	{
		get
		{
			return _CdLocalEstoque;
		}
		set
		{
			_CdLocalEstoque = value;
		}
	}

	public int? CdEmpPedido
	{
		get
		{
			return _CdEmpPedido;
		}
		set
		{
			_CdEmpPedido = value;
		}
	}

	public int? NuPedPedido
	{
		get
		{
			return _NuPedPedido;
		}
		set
		{
			_NuPedPedido = value;
		}
	}

	public decimal VlTotal
	{
		get
		{
			return _VlTotal;
		}
		set
		{
			_VlTotal = value;
		}
	}

	public string Situacao
	{
		get
		{
			return _Situacao;
		}
		set
		{
			_Situacao = value;
		}
	}

	public TipoAbatTroca TpAbatimento
	{
		get
		{
			return _TpAbatimento switch
			{
				"PN" => TipoAbatTroca.ProximaNota, 
				"PT" => TipoAbatTroca.ProximoTitulo, 
				"TA" => TipoAbatTroca.TitulosPendentes, 
				_ => TipoAbatTroca.ProximaNota, 
			};
		}
		set
		{
			switch (value)
			{
			case TipoAbatTroca.ProximaNota:
				_TpAbatimento = "PN";
				break;
			case TipoAbatTroca.ProximoTitulo:
				_TpAbatimento = "PT";
				break;
			case TipoAbatTroca.TitulosPendentes:
				_TpAbatimento = "TA";
				break;
			default:
				_TpAbatimento = "PN";
				break;
			}
		}
	}

	public TipoEnvioTroca TpEnvio
	{
		get
		{
			string tpEnvio = _TpEnvio;
			if (!(tpEnvio == "PF"))
			{
				if (tpEnvio == "PA")
				{
					return TipoEnvioTroca.PedidoEmAberto;
				}
				return TipoEnvioTroca.ProximoPedido;
			}
			return TipoEnvioTroca.ProximoPedido;
		}
		set
		{
			switch (value)
			{
			case TipoEnvioTroca.ProximoPedido:
				_TpEnvio = "PF";
				break;
			case TipoEnvioTroca.PedidoEmAberto:
				_TpEnvio = "PA";
				break;
			default:
				_TpEnvio = "PN";
				break;
			}
		}
	}

	public decimal VlTotalRecebido
	{
		get
		{
			return _VlTotalRecebido;
		}
		set
		{
			_VlTotalRecebido = value;
		}
	}

	public int CdEmp
	{
		get
		{
			return _CdEmp;
		}
		set
		{
			_CdEmp = value;
		}
	}

	public string Referencia
	{
		get
		{
			return _Referencia;
		}
		set
		{
			_Referencia = value;
		}
	}

	public string CdTrocaPalm
	{
		get
		{
			return _CdTrocaPalm;
		}
		set
		{
			_CdTrocaPalm = value;
		}
	}

	public DateTime? DtCadPalm
	{
		get
		{
			return _DtCadPalm;
		}
		set
		{
			_DtCadPalm = value;
		}
	}

	public ItTrocaTO[] oItTroca
	{
		get
		{
			return _oItTroca;
		}
		set
		{
			_oItTroca = value;
		}
	}

	public string RetornaProdLocaliza()
	{
		return _ProdLocaliza;
	}

	public void AtribuiProdLocaliza(string ProdLocaliza)
	{
		this.ProdLocaliza = ProdLocaliza switch
		{
			"C" => LocalProdutoTroca.Cliente, 
			"E" => LocalProdutoTroca.Empresa, 
			"V" => LocalProdutoTroca.Vendedor, 
			_ => LocalProdutoTroca.Cliente, 
		};
	}

	public string RetornaTpAbatimento()
	{
		return _TpAbatimento;
	}

	public void AtribuiTpAbatimento(string TpAbatimento)
	{
		this.TpAbatimento = TpAbatimento switch
		{
			"PN" => TipoAbatTroca.ProximaNota, 
			"PT" => TipoAbatTroca.ProximoTitulo, 
			"TA" => TipoAbatTroca.TitulosPendentes, 
			_ => TipoAbatTroca.ProximaNota, 
		};
	}

	public string RetornaTpEnvio()
	{
		return _TpEnvio;
	}

	public void AtribuiTpEnvio(string TpEnvio)
	{
		TipoEnvioTroca tpEnvio = ((TpEnvio == "PF") ? TipoEnvioTroca.ProximoPedido : ((!(TpEnvio == "PA")) ? TipoEnvioTroca.ProximoPedido : TipoEnvioTroca.PedidoEmAberto));
		this.TpEnvio = tpEnvio;
	}

	public void IncluiItTroca(ItTrocaTO ItTroca)
	{
		List<ItTrocaTO> list = ((oItTroca != null) ? oItTroca.ToList() : new List<ItTrocaTO>());
		list.Add(ItTroca);
		oItTroca = list.ToArray();
	}
}
