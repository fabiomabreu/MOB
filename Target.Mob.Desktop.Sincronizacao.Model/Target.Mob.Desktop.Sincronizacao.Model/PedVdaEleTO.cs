using System;
using System.Collections.Generic;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class PedVdaEleTO
{
	private int _CdEmpEle;

	private int _NuPedEle;

	private decimal _SeqPed;

	private string _NuPedCli;

	private int? _CdEmp;

	private int? _NuPed;

	private string _CdVend;

	private int? _CdClien;

	private decimal? _PerDescFin;

	private decimal? _VlDescFin;

	private decimal? _NuDiasDescFin;

	private string _TpEstab;

	private string _TpPed;

	private DateTime? _DtPed;

	private string _CdTabela;

	private int? _SeqProm;

	private string _Formpgto;

	private decimal? _VlFrete;

	private decimal? _ValorTot;

	private string _TpMidia;

	private string _TpEntrega;

	private int? _CdForn;

	private string _TpFrete;

	private DateTime? _DtEntrega;

	private string _Situacao;

	private int? _PromPadrCli;

	private DateTime? _DtPrevFatu;

	private decimal? _PercDescGeral;

	private decimal? _VlDescGeral;

	private string _OrigemPedido;

	private string _NuPedPalm;

	private int? _SemEstoque;

	private int? _NuNf;

	private int? _NuNfEmpFat;

	private string _DescCfop;

	private string _DescNatOper;

	private int? _ImpViaSp;

	private string _TpImpSp;

	private int? _NfCanc;

	private string _CdIntPedEle;

	private string _CardCredNumero;

	private string _CardCredProprietario;

	private string _CardCredTipo;

	private string _CardCredComplemento;

	private string _CardCredDtExpiracaoMes;

	private string _CardCredDtExpiracaoAno;

	private string _CardCredCpfProprietario;

	private string _CdIntpededi;

	private int? _IdOrderVertis;

	private int? _VertisPedFinalizado;

	private int? _MantemVlFretePedvEle;

	private int? _MantemVlDescGerPedvEle;

	private int? _PedidoDireto;

	private bool? _PropostaVda;

	private bool? _PendEleLiberaAuto;

	private string _NomeEntrega;

	private bool? _LiberacaoAutomatica;

	private int? _AtendimentoEnviado;

	private ItPedvEleTO[] _oItPedvEle;

	private ObsPedEleTO[] _oObsPedEle;

	private PedVdaEleTextoGravacaoTO[] _oPedVdaEleTextoGravacao;

	private PedVdaEleDuplicTO[] _oPedVdaEleDuplic;

	private TrocaTO _oTrocaPedvEle;

	private int? _SeqTroca;

	private int? _CodigoEntregaOutroCliente;

	private int? _cdClienFatura;

	private int? _cdClienPagamento;

	private int? _cdClienAtacadista;

	public int? cdComoRealizouVenda { get; set; }

	public string TextoComoRealizouVenda { get; set; }

	public int? CodigoEntregaOutroCliente
	{
		get
		{
			return _CodigoEntregaOutroCliente;
		}
		set
		{
			_CodigoEntregaOutroCliente = value;
		}
	}

	public int? cdClienFatura
	{
		get
		{
			return _cdClienFatura;
		}
		set
		{
			_cdClienFatura = value;
		}
	}

	public int? cdClienPagamento
	{
		get
		{
			return _cdClienPagamento;
		}
		set
		{
			_cdClienPagamento = value;
		}
	}

	public int? cdClienAtacadista
	{
		get
		{
			return _cdClienAtacadista;
		}
		set
		{
			_cdClienAtacadista = value;
		}
	}

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

	public int NuPedEle
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

	public string NuPedCli
	{
		get
		{
			return _NuPedCli;
		}
		set
		{
			_NuPedCli = value;
		}
	}

	public int? CdEmp
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

	public int? NuPed
	{
		get
		{
			return _NuPed;
		}
		set
		{
			_NuPed = value;
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

	public int? CdClien
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

	public decimal? PerDescFin
	{
		get
		{
			return _PerDescFin;
		}
		set
		{
			_PerDescFin = value;
		}
	}

	public decimal? VlDescFin
	{
		get
		{
			return _VlDescFin;
		}
		set
		{
			_VlDescFin = value;
		}
	}

	public decimal? NuDiasDescFin
	{
		get
		{
			return _NuDiasDescFin;
		}
		set
		{
			_NuDiasDescFin = value;
		}
	}

	public TipoEstabelecimento TpEstab
	{
		get
		{
			string tpEstab = _TpEstab;
			if (!(tpEstab == "CO"))
			{
				if (tpEstab == "RE")
				{
					return TipoEstabelecimento.Residencial;
				}
				return TipoEstabelecimento.Comercial;
			}
			return TipoEstabelecimento.Comercial;
		}
		set
		{
			switch (value)
			{
			case TipoEstabelecimento.Comercial:
				_TpEstab = "CO";
				break;
			case TipoEstabelecimento.Residencial:
				_TpEstab = "RE";
				break;
			default:
				_TpEstab = "CO";
				break;
			}
		}
	}

	public string TpPed
	{
		get
		{
			return _TpPed;
		}
		set
		{
			_TpPed = value;
		}
	}

	public DateTime? DtPed
	{
		get
		{
			return _DtPed;
		}
		set
		{
			_DtPed = value;
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

	public int? SeqProm
	{
		get
		{
			return _SeqProm;
		}
		set
		{
			_SeqProm = value;
		}
	}

	public string Formpgto
	{
		get
		{
			return _Formpgto;
		}
		set
		{
			_Formpgto = value;
		}
	}

	public decimal? VlFrete
	{
		get
		{
			return _VlFrete;
		}
		set
		{
			_VlFrete = value;
		}
	}

	public decimal? ValorTot
	{
		get
		{
			return _ValorTot;
		}
		set
		{
			_ValorTot = value;
		}
	}

	public string TpMidia
	{
		get
		{
			return _TpMidia;
		}
		set
		{
			_TpMidia = value;
		}
	}

	public TipoEntrega TpEntrega
	{
		get
		{
			return _TpEntrega switch
			{
				"EN" => TipoEntrega.Entrega, 
				"RE" => TipoEntrega.Retira, 
				"TR" => TipoEntrega.Transportadora, 
				_ => TipoEntrega.Entrega, 
			};
		}
		set
		{
			switch (value)
			{
			case TipoEntrega.Entrega:
				_TpEntrega = "EN";
				break;
			case TipoEntrega.Retira:
				_TpEntrega = "RE";
				break;
			case TipoEntrega.Transportadora:
				_TpEntrega = "TR";
				break;
			default:
				_TpEntrega = "EN";
				break;
			}
		}
	}

	public int? CdForn
	{
		get
		{
			return _CdForn;
		}
		set
		{
			_CdForn = value;
		}
	}

	public TipoFrete TpFrete
	{
		get
		{
			string tpFrete = _TpFrete;
			if (!(tpFrete == "C"))
			{
				if (tpFrete == "F")
				{
					return TipoFrete.FOB;
				}
				return TipoFrete.CIF;
			}
			return TipoFrete.CIF;
		}
		set
		{
			switch (value)
			{
			case TipoFrete.CIF:
				_TpFrete = "C";
				break;
			case TipoFrete.FOB:
				_TpFrete = "F";
				break;
			default:
				_TpFrete = "C";
				break;
			}
		}
	}

	public DateTime? DtEntrega
	{
		get
		{
			return _DtEntrega;
		}
		set
		{
			_DtEntrega = value;
		}
	}

	public SituacaoPedido Situacao
	{
		get
		{
			string situacao = _Situacao;
			if (!(situacao == "AB"))
			{
				if (situacao == "CA")
				{
					return SituacaoPedido.Cancelado;
				}
				return SituacaoPedido.EmAberto;
			}
			return SituacaoPedido.EmAberto;
		}
		set
		{
			switch (value)
			{
			case SituacaoPedido.EmAberto:
				_Situacao = "AB";
				break;
			case SituacaoPedido.Cancelado:
				_Situacao = "CA";
				break;
			default:
				_Situacao = "AB";
				break;
			}
		}
	}

	public int? PromPadrCli
	{
		get
		{
			return _PromPadrCli;
		}
		set
		{
			_PromPadrCli = value;
		}
	}

	public DateTime? DtPrevFatu
	{
		get
		{
			return _DtPrevFatu;
		}
		set
		{
			_DtPrevFatu = value;
		}
	}

	public decimal? PercDescGeral
	{
		get
		{
			return _PercDescGeral;
		}
		set
		{
			_PercDescGeral = value;
		}
	}

	public decimal? VlDescGeral
	{
		get
		{
			return _VlDescGeral;
		}
		set
		{
			_VlDescGeral = value;
		}
	}

	public OrigemPedido OrigPedido
	{
		get
		{
			return _OrigemPedido switch
			{
				"E" => OrigemPedido.EDI, 
				"P" => OrigemPedido.Palmtop, 
				"T" => OrigemPedido.Digitacao, 
				"F" => OrigemPedido.FrenteDeCaixa, 
				"V" => OrigemPedido.ECommerce, 
				"D" => OrigemPedido.PedidoEletronico, 
				_ => OrigemPedido.Digitacao, 
			};
		}
		set
		{
			switch (value)
			{
			case OrigemPedido.EDI:
				_OrigemPedido = "E";
				break;
			case OrigemPedido.Palmtop:
				_OrigemPedido = "P";
				break;
			case OrigemPedido.Digitacao:
				_OrigemPedido = "T";
				break;
			case OrigemPedido.FrenteDeCaixa:
				_OrigemPedido = "F";
				break;
			case OrigemPedido.ECommerce:
				_OrigemPedido = "V";
				break;
			case OrigemPedido.PedidoEletronico:
				_OrigemPedido = "D";
				break;
			default:
				_OrigemPedido = "DP";
				break;
			}
		}
	}

	public string NuPedPalm
	{
		get
		{
			return _NuPedPalm;
		}
		set
		{
			_NuPedPalm = value;
		}
	}

	public int? SemEstoque
	{
		get
		{
			return _SemEstoque;
		}
		set
		{
			_SemEstoque = value;
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

	public int? NuNfEmpFat
	{
		get
		{
			return _NuNfEmpFat;
		}
		set
		{
			_NuNfEmpFat = value;
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

	public string DescNatOper
	{
		get
		{
			return _DescNatOper;
		}
		set
		{
			_DescNatOper = value;
		}
	}

	public int? ImpViaSp
	{
		get
		{
			return _ImpViaSp;
		}
		set
		{
			_ImpViaSp = value;
		}
	}

	public string TpImpSp
	{
		get
		{
			return _TpImpSp;
		}
		set
		{
			_TpImpSp = value;
		}
	}

	public int? NfCanc
	{
		get
		{
			return _NfCanc;
		}
		set
		{
			_NfCanc = value;
		}
	}

	public string CdIntPedEle
	{
		get
		{
			return _CdIntPedEle;
		}
		set
		{
			_CdIntPedEle = value;
		}
	}

	public string CardCredNumero
	{
		get
		{
			return _CardCredNumero;
		}
		set
		{
			_CardCredNumero = value;
		}
	}

	public string CardCredProprietario
	{
		get
		{
			return _CardCredProprietario;
		}
		set
		{
			_CardCredProprietario = value;
		}
	}

	public string CardCredTipo
	{
		get
		{
			return _CardCredTipo;
		}
		set
		{
			_CardCredTipo = value;
		}
	}

	public string CardCredComplemento
	{
		get
		{
			return _CardCredComplemento;
		}
		set
		{
			_CardCredComplemento = value;
		}
	}

	public string CardCredDtExpiracaoMes
	{
		get
		{
			return _CardCredDtExpiracaoMes;
		}
		set
		{
			_CardCredDtExpiracaoMes = value;
		}
	}

	public string CardCredDtExpiracaoAno
	{
		get
		{
			return _CardCredDtExpiracaoAno;
		}
		set
		{
			_CardCredDtExpiracaoAno = value;
		}
	}

	public string CardCredCpfProprietario
	{
		get
		{
			return _CardCredCpfProprietario;
		}
		set
		{
			_CardCredCpfProprietario = value;
		}
	}

	public string CdIntpededi
	{
		get
		{
			return _CdIntpededi;
		}
		set
		{
			_CdIntpededi = value;
		}
	}

	public int? IdOrderVertis
	{
		get
		{
			return _IdOrderVertis;
		}
		set
		{
			_IdOrderVertis = value;
		}
	}

	public int? VertisPedFinalizado
	{
		get
		{
			return _VertisPedFinalizado;
		}
		set
		{
			_VertisPedFinalizado = value;
		}
	}

	public int? MantemVlFretePedvEle
	{
		get
		{
			return _MantemVlFretePedvEle;
		}
		set
		{
			_MantemVlFretePedvEle = value;
		}
	}

	public int? MantemVlDescGerPedvEle
	{
		get
		{
			return _MantemVlDescGerPedvEle;
		}
		set
		{
			_MantemVlDescGerPedvEle = value;
		}
	}

	public int? PedidoDireto
	{
		get
		{
			return _PedidoDireto;
		}
		set
		{
			_PedidoDireto = value;
		}
	}

	public bool? PropostaVda
	{
		get
		{
			return _PropostaVda;
		}
		set
		{
			_PropostaVda = value;
		}
	}

	public bool? PendEleLiberaAuto
	{
		get
		{
			return _PendEleLiberaAuto;
		}
		set
		{
			_PendEleLiberaAuto = value;
		}
	}

	public string NomeEntrega
	{
		get
		{
			return _NomeEntrega;
		}
		set
		{
			_NomeEntrega = value;
		}
	}

	public bool? LiberacaoAutomatica
	{
		get
		{
			return _LiberacaoAutomatica;
		}
		set
		{
			_LiberacaoAutomatica = value;
		}
	}

	public int? AtendimentoEnviado
	{
		get
		{
			return _AtendimentoEnviado;
		}
		set
		{
			_AtendimentoEnviado = value;
		}
	}

	public ItPedvEleTO[] oItPedvEle
	{
		get
		{
			return _oItPedvEle;
		}
		set
		{
			_oItPedvEle = value;
		}
	}

	public ObsPedEleTO[] oObsPedEle
	{
		get
		{
			return _oObsPedEle;
		}
		set
		{
			_oObsPedEle = value;
		}
	}

	public PedVdaEleTextoGravacaoTO[] oPedVdaEleTextoGravacao
	{
		get
		{
			return _oPedVdaEleTextoGravacao;
		}
		set
		{
			_oPedVdaEleTextoGravacao = value;
		}
	}

	public PedVdaEleDuplicTO[] oPedVdaEleDuplic
	{
		get
		{
			return _oPedVdaEleDuplic;
		}
		set
		{
			_oPedVdaEleDuplic = value;
		}
	}

	public TrocaTO oTrocaPedvEle
	{
		get
		{
			return _oTrocaPedvEle;
		}
		set
		{
			_oTrocaPedvEle = value;
		}
	}

	public int? SeqTroca
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

	public string RetornaTpEstab()
	{
		return _TpEstab;
	}

	public void AtribuiTpEntrega(string TpEntrega)
	{
		this.TpEntrega = TpEntrega switch
		{
			"EN" => TipoEntrega.Entrega, 
			"RE" => TipoEntrega.Retira, 
			"TR" => TipoEntrega.Transportadora, 
			_ => TipoEntrega.Entrega, 
		};
	}

	public string RetornaTpEntrega()
	{
		return _TpEntrega;
	}

	public void AtribuiTpFrete(string TpFrete)
	{
		TipoFrete tpFrete = ((TpFrete == "C") ? TipoFrete.CIF : ((!(TpFrete == "F")) ? TipoFrete.CIF : TipoFrete.FOB));
		this.TpFrete = tpFrete;
	}

	public string RetornaTpFrete()
	{
		return _TpFrete;
	}

	public string RetornaSituacao()
	{
		return _Situacao;
	}

	public void AtribuiSituacao(string Situacao)
	{
		SituacaoPedido situacao = ((Situacao == "AB") ? SituacaoPedido.EmAberto : ((!(Situacao == "CA")) ? SituacaoPedido.EmAberto : SituacaoPedido.Cancelado));
		this.Situacao = situacao;
	}

	public string RetornaOrigemPedido()
	{
		return _OrigemPedido;
	}

	public void AtribuiOrigPedido(string origemPedido)
	{
		OrigPedido = origemPedido switch
		{
			"E" => OrigemPedido.EDI, 
			"P" => OrigemPedido.Palmtop, 
			"T" => OrigemPedido.Digitacao, 
			"F" => OrigemPedido.FrenteDeCaixa, 
			"V" => OrigemPedido.ECommerce, 
			_ => OrigemPedido.PedidoEletronico, 
		};
	}

	public PedVdaEleTO()
	{
	}

	public PedVdaEleTO(int CdEmpEle)
	{
		this.CdEmpEle = CdEmpEle;
	}

	public void IncluiItPedvEle(ItPedvEleTO ItPedvEle)
	{
		List<ItPedvEleTO> list = ((oItPedvEle != null) ? oItPedvEle.ToList() : new List<ItPedvEleTO>());
		list.Add(ItPedvEle);
		oItPedvEle = list.ToArray();
	}

	public void IncluiObsPedEle(ObsPedEleTO ObsPedEle)
	{
		List<ObsPedEleTO> list = ((oObsPedEle != null) ? oObsPedEle.ToList() : new List<ObsPedEleTO>());
		list.Add(ObsPedEle);
		oObsPedEle = list.ToArray();
	}

	public void IncluiPedVdaEleDuplic(PedVdaEleDuplicTO PedVdaEleDuplic)
	{
		List<PedVdaEleDuplicTO> list = ((oPedVdaEleDuplic != null) ? oPedVdaEleDuplic.ToList() : new List<PedVdaEleDuplicTO>());
		list.Add(PedVdaEleDuplic);
		oPedVdaEleDuplic = list.ToArray();
	}

	public PedVdaEleTO Clone()
	{
		return (PedVdaEleTO)MemberwiseClone();
	}
}
