using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ItTrocaTO
{
	private int _SeqTroca;

	private decimal _SeqItTroca;

	private int _CdProd;

	private decimal _Qtde;

	private decimal _VlCheio;

	private decimal _PercIndeniz;

	private decimal _VlUnit;

	private int? _NuNf;

	private decimal? _QtdeReceb;

	private decimal? _VlUnitReceb;

	private string _UnidVda;

	private double _FatorEstoque;

	private string _IndRelacao;

	private decimal _QtdeVda;

	private decimal? _QtdeRecebVda;

	private decimal? _SeqLote;

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

	public decimal SeqItTroca
	{
		get
		{
			return _SeqItTroca;
		}
		set
		{
			_SeqItTroca = value;
		}
	}

	public int CdProd
	{
		get
		{
			return _CdProd;
		}
		set
		{
			_CdProd = value;
		}
	}

	public decimal Qtde
	{
		get
		{
			return _Qtde;
		}
		set
		{
			_Qtde = value;
		}
	}

	public decimal VlCheio
	{
		get
		{
			return _VlCheio;
		}
		set
		{
			_VlCheio = value;
		}
	}

	public decimal PercIndeniz
	{
		get
		{
			return _PercIndeniz;
		}
		set
		{
			_PercIndeniz = value;
		}
	}

	public decimal VlUnit
	{
		get
		{
			return _VlUnit;
		}
		set
		{
			_VlUnit = value;
		}
	}

	public int? NuNf
	{
		get
		{
			return _NuNf;
		}
		set
		{
			_NuNf = value;
		}
	}

	public decimal? QtdeReceb
	{
		get
		{
			return _QtdeReceb;
		}
		set
		{
			_QtdeReceb = value;
		}
	}

	public decimal? VlUnitReceb
	{
		get
		{
			return _VlUnitReceb;
		}
		set
		{
			_VlUnitReceb = value;
		}
	}

	public string UnidVda
	{
		get
		{
			return _UnidVda;
		}
		set
		{
			_UnidVda = value;
		}
	}

	public double FatorEstoque
	{
		get
		{
			return _FatorEstoque;
		}
		set
		{
			_FatorEstoque = value;
		}
	}

	public IndiceRelacao IndRelacao
	{
		get
		{
			string indRelacao = _IndRelacao;
			if (!(indRelacao == "MAIOR"))
			{
				if (indRelacao == "MENOR")
				{
					return IndiceRelacao.Menor;
				}
				return IndiceRelacao.Maior;
			}
			return IndiceRelacao.Maior;
		}
		set
		{
			switch (value)
			{
			case IndiceRelacao.Maior:
				_IndRelacao = "MAIOR";
				break;
			case IndiceRelacao.Menor:
				_IndRelacao = "MENOR";
				break;
			default:
				_IndRelacao = "MAIOR";
				break;
			}
		}
	}

	public decimal QtdeVda
	{
		get
		{
			return _QtdeVda;
		}
		set
		{
			_QtdeVda = value;
		}
	}

	public decimal? QtdeRecebVda
	{
		get
		{
			return _QtdeRecebVda;
		}
		set
		{
			_QtdeRecebVda = value;
		}
	}

	public decimal? SeqLote
	{
		get
		{
			return _SeqLote;
		}
		set
		{
			_SeqLote = value;
		}
	}

	public string RetornaIndRelacao()
	{
		return _IndRelacao;
	}

	public void AtribuiIndRelacao(string IndRelacao)
	{
		IndiceRelacao indRelacao = ((IndRelacao == "MAIOR") ? IndiceRelacao.Maior : ((!(IndRelacao == "MENOR")) ? IndiceRelacao.Maior : IndiceRelacao.Menor));
		this.IndRelacao = indRelacao;
	}
}
