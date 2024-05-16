using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ItPedvEleTO
{
	private int _CdEmpEle;

	private decimal _NuPedEle;

	private decimal _SeqPed;

	private decimal _Seq;

	private int _CdProd;

	private string _UnidPed;

	private decimal _Qtde;

	private double? _FatorEstPed;

	private decimal? _QtdeUnidPed;

	private string _IndRelacao;

	private decimal? _VlUnitPed;

	private decimal _PrecoUnit;

	private decimal? _AliqIpi;

	private decimal? _VlIpi;

	private decimal? _DescApl;

	private decimal? _VlVerba;

	private int? _SeqKit;

	private int? _Bonificado;

	private string _CdSitTrib;

	private string _DescCfop;

	private int? _IncideIcm;

	private decimal? _AliqIcm;

	private decimal? _PercRedBaseicm;

	private decimal? _VlBaseIcm;

	private decimal? _VlIcm;

	private decimal? _VlBaseIcmSubst;

	private decimal? _VlIcmSubst;

	private decimal? _Desc01;

	private decimal? _Desc02;

	private int? _SeqGradeDesc;

	private int? _SeqGradeDescIt;

	private decimal? _DescGrdBon;

	private decimal? _DescGrdCom;

	private decimal? _DescGrdFin;

	private int? _CodigoCondPgto;

	public int CdEmpEle
	{
		get
		{
			return _CdEmpEle;
		}
		set
		{
			_CdEmpEle = value;
		}
	}

	public decimal NuPedEle
	{
		get
		{
			return _NuPedEle;
		}
		set
		{
			_NuPedEle = value;
		}
	}

	public decimal SeqPed
	{
		get
		{
			return _SeqPed;
		}
		set
		{
			_SeqPed = value;
		}
	}

	public decimal Seq
	{
		get
		{
			return _Seq;
		}
		set
		{
			_Seq = value;
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

	public string UnidPed
	{
		get
		{
			return _UnidPed;
		}
		set
		{
			_UnidPed = value;
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

	public double? FatorEstPed
	{
		get
		{
			return _FatorEstPed;
		}
		set
		{
			_FatorEstPed = value;
		}
	}

	public decimal? QtdeUnidPed
	{
		get
		{
			return _QtdeUnidPed;
		}
		set
		{
			_QtdeUnidPed = value;
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

	public decimal? VlUnitPed
	{
		get
		{
			return _VlUnitPed;
		}
		set
		{
			_VlUnitPed = value;
		}
	}

	public decimal PrecoUnit
	{
		get
		{
			return _PrecoUnit;
		}
		set
		{
			_PrecoUnit = value;
		}
	}

	public decimal? AliqIpi
	{
		get
		{
			return _AliqIpi;
		}
		set
		{
			_AliqIpi = value;
		}
	}

	public decimal? VlIpi
	{
		get
		{
			return _VlIpi;
		}
		set
		{
			_VlIpi = value;
		}
	}

	public decimal? DescApl
	{
		get
		{
			return _DescApl;
		}
		set
		{
			_DescApl = value;
		}
	}

	public decimal? VlVerba
	{
		get
		{
			return _VlVerba;
		}
		set
		{
			_VlVerba = value;
		}
	}

	public int? SeqKit
	{
		get
		{
			return _SeqKit;
		}
		set
		{
			_SeqKit = value;
		}
	}

	public int? Bonificado
	{
		get
		{
			return _Bonificado;
		}
		set
		{
			_Bonificado = value;
		}
	}

	public string CdSitTrib
	{
		get
		{
			return _CdSitTrib;
		}
		set
		{
			_CdSitTrib = value;
		}
	}

	public string DescCfop
	{
		get
		{
			return _DescCfop;
		}
		set
		{
			_DescCfop = value;
		}
	}

	public int? IncideIcm
	{
		get
		{
			return _IncideIcm;
		}
		set
		{
			_IncideIcm = value;
		}
	}

	public decimal? AliqIcm
	{
		get
		{
			return _AliqIcm;
		}
		set
		{
			_AliqIcm = value;
		}
	}

	public decimal? PercRedBaseicm
	{
		get
		{
			return _PercRedBaseicm;
		}
		set
		{
			_PercRedBaseicm = value;
		}
	}

	public decimal? VlBaseIcm
	{
		get
		{
			return _VlBaseIcm;
		}
		set
		{
			_VlBaseIcm = value;
		}
	}

	public decimal? VlIcm
	{
		get
		{
			return _VlIcm;
		}
		set
		{
			_VlIcm = value;
		}
	}

	public decimal? VlBaseIcmSubst
	{
		get
		{
			return _VlBaseIcmSubst;
		}
		set
		{
			_VlBaseIcmSubst = value;
		}
	}

	public decimal? VlIcmSubst
	{
		get
		{
			return _VlIcmSubst;
		}
		set
		{
			_VlIcmSubst = value;
		}
	}

	public decimal? Desc01
	{
		get
		{
			return _Desc01;
		}
		set
		{
			_Desc01 = value;
		}
	}

	public decimal? Desc02
	{
		get
		{
			return _Desc02;
		}
		set
		{
			_Desc02 = value;
		}
	}

	public int? SeqGradeDesc
	{
		get
		{
			return _SeqGradeDesc;
		}
		set
		{
			_SeqGradeDesc = value;
		}
	}

	public int? SeqGradeDescIt
	{
		get
		{
			return _SeqGradeDescIt;
		}
		set
		{
			_SeqGradeDescIt = value;
		}
	}

	public decimal? DescGrdBon
	{
		get
		{
			return _DescGrdBon;
		}
		set
		{
			_DescGrdBon = value;
		}
	}

	public decimal? DescGrdCom
	{
		get
		{
			return _DescGrdCom;
		}
		set
		{
			_DescGrdCom = value;
		}
	}

	public decimal? DescGrdFin
	{
		get
		{
			return _DescGrdFin;
		}
		set
		{
			_DescGrdFin = value;
		}
	}

	public int? CodigoCondPgto
	{
		get
		{
			return _CodigoCondPgto;
		}
		set
		{
			_CodigoCondPgto = value;
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

	public ItPedvEleTO Clone()
	{
		return (ItPedvEleTO)MemberwiseClone();
	}
}
