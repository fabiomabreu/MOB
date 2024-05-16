using System;
using System.Collections.Generic;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ClienteTO
{
	private int _CdClien;

	private string _TpCliente;

	private string _Nome;

	private string _NomeRes;

	private string _TpPes;

	private string _CgcCpf;

	private string _TpInscr;

	private string _Inscricao;

	private string _RamAtiv;

	private string _StCred;

	private string _Crt;

	private string _CdGrupocli;

	private int? _CdClienCol;

	private string _CdArea;

	private DateTime _DtCad;

	private string _CdVend;

	private DateTime? _DtUltAlt;

	private int? _CdTexto;

	private DateTime? _DtMaiorAcumulo;

	private decimal? _VlMaiorAcumulo;

	private DateTime? _DtMaiorCompra;

	private DateTime? _DtPrimCompra;

	private decimal? _VlMaiorCompra;

	private decimal? _QtdeCompraMes;

	private DateTime? _DtUltCompra;

	private decimal? _VlUltCompra;

	private decimal? _VlLimCred;

	private DateTime? _DtUltContato;

	private string _CdRotPrdf;

	private int? _SeqRotPrdf;

	private string _RotVisita;

	private decimal? _SeqVisita;

	private string _TurmaPlantao;

	private int? _MedAtraso;

	private int? _TotProtestos;

	private int? _CdTextoCred;

	private string _Situacao;

	private int? _NuDiasProtesto;

	private decimal? _Desconto;

	private int? _VendaEspecial;

	private int? _Suframa;

	private string _CdSuframa;

	private int? _Fornec;

	private int? _Estrangeiro;

	private int? _CdTextoAlerta;

	private int? _CdTextoNf;

	private string _WebSite;

	private string _EMail;

	private string _TpFrete;

	private int? _CdForn;

	private int _NumLock;

	private bool _Ativo;

	private string _Ean13;

	private decimal? _PotCompraMes;

	private decimal? _PercComis;

	private string _TpPed;

	private int? _CobraBoleto;

	private int? _CdTextoExpe;

	private int? _AtualizaLimCred;

	private int? _ProdControlado;

	private int _EnviarArqGenexis;

	private int _ClienteNovoGenexis;

	private int _EnviarArqJanssen;

	private int _ClienteNovoJanssen;

	private DateTime? _DtValProdControlado;

	private int _EnviarArqNestle;

	private int? _EnvioSerasa;

	private string _CdGrdescli;

	private string _CdTpFreqVisita;

	private int? _CdEmp;

	private string _Senha;

	private int? _TolerJurosQtdeDias;

	private int? _TolerJurosAteVenc;

	private string _CodClf;

	private int? _AreaLivreComercio;

	private int? _DiasProrrVenc;

	private int _ClienteNovoProceda;

	private int _EnviarArqProceda;

	private int? _NaoFatMaiorUn;

	private int _ClienteNovoNestle;

	private string _CdColigacao;

	private DateTime? _DtUltAltLimCred;

	private DateTime? _DtRecadastramento;

	private string _EstrangeiroNuDoc;

	private int _AtuUltMaiorCompra;

	private int? _EnviaArqMasterfoods;

	private DateTime? _DtPenultCompra;

	private decimal? _VlPenultCompra;

	private int? _EnviadoRedbull;

	private int? _Consumidor;

	private decimal? _PercAceitoPrazoValidade;

	private int? _CobraSeguro;

	private int? _BloqAtuUltMaiorCompra;

	private decimal? _PercDescFinAuto;

	private bool? _EnviarArqPharmadis;

	private bool? _ClienteNovoPharmadis;

	private int? _NcUtilCfgAbatClien;

	private string _NcTpAbatClien;

	private string _CdVendTecnico;

	private int? _CdFornInst;

	private int? _ImpDescGrdCom;

	private string _Cnae;

	private int? _SeqTribCli;

	private bool? _AltTabPrecoAfv;

	private bool? _AltTpPedAfv;

	private bool? _SeqRotPrdfProvisorio;

	private int? _QtdeCheckout;

	private string _TipoOperacao;

	private string _Iban;

	private byte[] _RowId;

	private ContCliTO[] _oContCli;

	private EndCliTO[] _oEndCli;

	private TelCliTO[] _oTelCli;

	private ClientePermCompTO[] _oPermComp;

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

	public byte[] RowId
	{
		get
		{
			return _RowId;
		}
		set
		{
			_RowId = value;
		}
	}

	public TipoCliente TpCliente
	{
		get
		{
			string tpCliente = _TpCliente;
			if (!(tpCliente == "CL"))
			{
				if (tpCliente == "DI")
				{
					return TipoCliente.Distribuidora;
				}
				return TipoCliente.Cliente;
			}
			return TipoCliente.Cliente;
		}
		set
		{
			switch (value)
			{
			case TipoCliente.Cliente:
				_TpCliente = "CL";
				break;
			case TipoCliente.Distribuidora:
				_TpCliente = "DI";
				break;
			default:
				_TpCliente = "CL";
				break;
			}
		}
	}

	public string Nome
	{
		get
		{
			return _Nome;
		}
		set
		{
			_Nome = value;
		}
	}

	public string NomeRes
	{
		get
		{
			return _NomeRes;
		}
		set
		{
			_NomeRes = value;
		}
	}

	public TipoPessoa TpPes
	{
		get
		{
			string tpPes = _TpPes;
			if (!(tpPes == "F"))
			{
				if (tpPes == "J")
				{
					return TipoPessoa.Juridica;
				}
				return TipoPessoa.Juridica;
			}
			return TipoPessoa.Fisica;
		}
		set
		{
			switch (value)
			{
			case TipoPessoa.Fisica:
				_TpPes = "F";
				break;
			case TipoPessoa.Juridica:
				_TpPes = "J";
				break;
			default:
				_TpPes = "J";
				break;
			}
		}
	}

	public string CgcCpf
	{
		get
		{
			return _CgcCpf;
		}
		set
		{
			_CgcCpf = value;
		}
	}

	public TipoInscricao TpInscr
	{
		get
		{
			return _TpInscr switch
			{
				"I" => TipoInscricao.Isento, 
				"E" => TipoInscricao.Estadual, 
				"M" => TipoInscricao.Municipal, 
				_ => TipoInscricao.Isento, 
			};
		}
		set
		{
			switch (value)
			{
			case TipoInscricao.Isento:
				_TpInscr = "I";
				break;
			case TipoInscricao.Estadual:
				_TpInscr = "E";
				break;
			case TipoInscricao.Municipal:
				_TpInscr = "M";
				break;
			default:
				_TpInscr = "I";
				break;
			}
		}
	}

	public string Inscricao
	{
		get
		{
			return _Inscricao;
		}
		set
		{
			_Inscricao = value;
		}
	}

	public string RamAtiv
	{
		get
		{
			return _RamAtiv;
		}
		set
		{
			_RamAtiv = value;
		}
	}

	public string StCred
	{
		get
		{
			return _StCred;
		}
		set
		{
			_StCred = value;
		}
	}

	public string Crt
	{
		get
		{
			return _Crt;
		}
		set
		{
			_Crt = value;
		}
	}

	public string CdGrupocli
	{
		get
		{
			return _CdGrupocli;
		}
		set
		{
			_CdGrupocli = value;
		}
	}

	public int? CdClienCol
	{
		get
		{
			return _CdClienCol;
		}
		set
		{
			_CdClienCol = value;
		}
	}

	public string CdArea
	{
		get
		{
			return _CdArea;
		}
		set
		{
			_CdArea = value;
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

	public DateTime? DtUltAlt
	{
		get
		{
			return _DtUltAlt;
		}
		set
		{
			_DtUltAlt = value;
		}
	}

	public int? CdTexto
	{
		get
		{
			return _CdTexto;
		}
		set
		{
			_CdTexto = value;
		}
	}

	public DateTime? DtMaiorAcumulo
	{
		get
		{
			return _DtMaiorAcumulo;
		}
		set
		{
			_DtMaiorAcumulo = value;
		}
	}

	public decimal? VlMaiorAcumulo
	{
		get
		{
			return _VlMaiorAcumulo;
		}
		set
		{
			_VlMaiorAcumulo = value;
		}
	}

	public DateTime? DtMaiorCompra
	{
		get
		{
			return _DtMaiorCompra;
		}
		set
		{
			_DtMaiorCompra = value;
		}
	}

	public DateTime? DtPrimCompra
	{
		get
		{
			return _DtPrimCompra;
		}
		set
		{
			_DtPrimCompra = value;
		}
	}

	public decimal? VlMaiorCompra
	{
		get
		{
			return _VlMaiorCompra;
		}
		set
		{
			_VlMaiorCompra = value;
		}
	}

	public decimal? QtdeCompraMes
	{
		get
		{
			return _QtdeCompraMes;
		}
		set
		{
			_QtdeCompraMes = value;
		}
	}

	public DateTime? DtUltCompra
	{
		get
		{
			return _DtUltCompra;
		}
		set
		{
			_DtUltCompra = value;
		}
	}

	public decimal? VlUltCompra
	{
		get
		{
			return _VlUltCompra;
		}
		set
		{
			_VlUltCompra = value;
		}
	}

	public decimal? VlLimCred
	{
		get
		{
			return _VlLimCred;
		}
		set
		{
			_VlLimCred = value;
		}
	}

	public DateTime? DtUltContato
	{
		get
		{
			return _DtUltContato;
		}
		set
		{
			_DtUltContato = value;
		}
	}

	public string CdRotPrdf
	{
		get
		{
			return _CdRotPrdf;
		}
		set
		{
			_CdRotPrdf = value;
		}
	}

	public int? SeqRotPrdf
	{
		get
		{
			return _SeqRotPrdf;
		}
		set
		{
			_SeqRotPrdf = value;
		}
	}

	public string RotVisita
	{
		get
		{
			return _RotVisita;
		}
		set
		{
			_RotVisita = value;
		}
	}

	public decimal? SeqVisita
	{
		get
		{
			return _SeqVisita;
		}
		set
		{
			_SeqVisita = value;
		}
	}

	public string TurmaPlantao
	{
		get
		{
			return _TurmaPlantao;
		}
		set
		{
			_TurmaPlantao = value;
		}
	}

	public int? MedAtraso
	{
		get
		{
			return _MedAtraso;
		}
		set
		{
			_MedAtraso = value;
		}
	}

	public int? TotProtestos
	{
		get
		{
			return _TotProtestos;
		}
		set
		{
			_TotProtestos = value;
		}
	}

	public int? CdTextoCred
	{
		get
		{
			return _CdTextoCred;
		}
		set
		{
			_CdTextoCred = value;
		}
	}

	public SituacaoCliente Situacao
	{
		get
		{
			return _Situacao switch
			{
				"PR" => SituacaoCliente.Provisorio, 
				"CO" => SituacaoCliente.Completo, 
				"CP" => SituacaoCliente.Prospeccao, 
				_ => SituacaoCliente.Provisorio, 
			};
		}
		set
		{
			switch (value)
			{
			case SituacaoCliente.Provisorio:
				_Situacao = "PR";
				break;
			case SituacaoCliente.Completo:
				_Situacao = "CO";
				break;
			case SituacaoCliente.Prospeccao:
				_Situacao = "CP";
				break;
			default:
				_Situacao = "PR";
				break;
			}
		}
	}

	public int? NuDiasProtesto
	{
		get
		{
			return _NuDiasProtesto;
		}
		set
		{
			_NuDiasProtesto = value;
		}
	}

	public decimal? Desconto
	{
		get
		{
			return _Desconto;
		}
		set
		{
			_Desconto = value;
		}
	}

	public int? VendaEspecial
	{
		get
		{
			return _VendaEspecial;
		}
		set
		{
			_VendaEspecial = value;
		}
	}

	public int? Suframa
	{
		get
		{
			return _Suframa;
		}
		set
		{
			_Suframa = value;
		}
	}

	public string CdSuframa
	{
		get
		{
			return _CdSuframa;
		}
		set
		{
			_CdSuframa = value;
		}
	}

	public int? Fornec
	{
		get
		{
			return _Fornec;
		}
		set
		{
			_Fornec = value;
		}
	}

	public int? Estrangeiro
	{
		get
		{
			return _Estrangeiro;
		}
		set
		{
			_Estrangeiro = value;
		}
	}

	public int? CdTextoAlerta
	{
		get
		{
			return _CdTextoAlerta;
		}
		set
		{
			_CdTextoAlerta = value;
		}
	}

	public int? CdTextoNf
	{
		get
		{
			return _CdTextoNf;
		}
		set
		{
			_CdTextoNf = value;
		}
	}

	public string WebSite
	{
		get
		{
			return _WebSite;
		}
		set
		{
			_WebSite = value;
		}
	}

	public string EMail
	{
		get
		{
			return _EMail;
		}
		set
		{
			_EMail = value;
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

	public int NumLock
	{
		get
		{
			return _NumLock;
		}
		set
		{
			_NumLock = value;
		}
	}

	public bool Ativo
	{
		get
		{
			return _Ativo;
		}
		set
		{
			_Ativo = value;
		}
	}

	public string Ean13
	{
		get
		{
			return _Ean13;
		}
		set
		{
			_Ean13 = value;
		}
	}

	public decimal? PotCompraMes
	{
		get
		{
			return _PotCompraMes;
		}
		set
		{
			_PotCompraMes = value;
		}
	}

	public decimal? PercComis
	{
		get
		{
			return _PercComis;
		}
		set
		{
			_PercComis = value;
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

	public int? CobraBoleto
	{
		get
		{
			return _CobraBoleto;
		}
		set
		{
			_CobraBoleto = value;
		}
	}

	public int? CdTextoExpe
	{
		get
		{
			return _CdTextoExpe;
		}
		set
		{
			_CdTextoExpe = value;
		}
	}

	public int? AtualizaLimCred
	{
		get
		{
			return _AtualizaLimCred;
		}
		set
		{
			_AtualizaLimCred = value;
		}
	}

	public int? ProdControlado
	{
		get
		{
			return _ProdControlado;
		}
		set
		{
			_ProdControlado = value;
		}
	}

	public int EnviarArqGenexis
	{
		get
		{
			return _EnviarArqGenexis;
		}
		set
		{
			_EnviarArqGenexis = value;
		}
	}

	public int ClienteNovoGenexis
	{
		get
		{
			return _ClienteNovoGenexis;
		}
		set
		{
			_ClienteNovoGenexis = value;
		}
	}

	public int EnviarArqJanssen
	{
		get
		{
			return _EnviarArqJanssen;
		}
		set
		{
			_EnviarArqJanssen = value;
		}
	}

	public int ClienteNovoJanssen
	{
		get
		{
			return _ClienteNovoJanssen;
		}
		set
		{
			_ClienteNovoJanssen = value;
		}
	}

	public DateTime? DtValProdControlado
	{
		get
		{
			return _DtValProdControlado;
		}
		set
		{
			_DtValProdControlado = value;
		}
	}

	public int EnviarArqNestle
	{
		get
		{
			return _EnviarArqNestle;
		}
		set
		{
			_EnviarArqNestle = value;
		}
	}

	public int? EnvioSerasa
	{
		get
		{
			return _EnvioSerasa;
		}
		set
		{
			_EnvioSerasa = value;
		}
	}

	public string CdGrdescli
	{
		get
		{
			return _CdGrdescli;
		}
		set
		{
			_CdGrdescli = value;
		}
	}

	public string CdTpFreqVisita
	{
		get
		{
			return _CdTpFreqVisita;
		}
		set
		{
			_CdTpFreqVisita = value;
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

	public string Senha
	{
		get
		{
			return _Senha;
		}
		set
		{
			_Senha = value;
		}
	}

	public int? TolerJurosQtdeDias
	{
		get
		{
			return _TolerJurosQtdeDias;
		}
		set
		{
			_TolerJurosQtdeDias = value;
		}
	}

	public int? TolerJurosAteVenc
	{
		get
		{
			return _TolerJurosAteVenc;
		}
		set
		{
			_TolerJurosAteVenc = value;
		}
	}

	public string CodClf
	{
		get
		{
			return _CodClf;
		}
		set
		{
			_CodClf = value;
		}
	}

	public int? AreaLivreComercio
	{
		get
		{
			return _AreaLivreComercio;
		}
		set
		{
			_AreaLivreComercio = value;
		}
	}

	public int? DiasProrrVenc
	{
		get
		{
			return _DiasProrrVenc;
		}
		set
		{
			_DiasProrrVenc = value;
		}
	}

	public int ClienteNovoProceda
	{
		get
		{
			return _ClienteNovoProceda;
		}
		set
		{
			_ClienteNovoProceda = value;
		}
	}

	public int EnviarArqProceda
	{
		get
		{
			return _EnviarArqProceda;
		}
		set
		{
			_EnviarArqProceda = value;
		}
	}

	public int? NaoFatMaiorUn
	{
		get
		{
			return _NaoFatMaiorUn;
		}
		set
		{
			_NaoFatMaiorUn = value;
		}
	}

	public int ClienteNovoNestle
	{
		get
		{
			return _ClienteNovoNestle;
		}
		set
		{
			_ClienteNovoNestle = value;
		}
	}

	public string CdColigacao
	{
		get
		{
			return _CdColigacao;
		}
		set
		{
			_CdColigacao = value;
		}
	}

	public DateTime? DtUltAltLimCred
	{
		get
		{
			return _DtUltAltLimCred;
		}
		set
		{
			_DtUltAltLimCred = value;
		}
	}

	public DateTime? DtRecadastramento
	{
		get
		{
			return _DtRecadastramento;
		}
		set
		{
			_DtRecadastramento = value;
		}
	}

	public string EstrangeiroNuDoc
	{
		get
		{
			return _EstrangeiroNuDoc;
		}
		set
		{
			_EstrangeiroNuDoc = value;
		}
	}

	public int AtuUltMaiorCompra
	{
		get
		{
			return _AtuUltMaiorCompra;
		}
		set
		{
			_AtuUltMaiorCompra = value;
		}
	}

	public int? EnviaArqMasterfoods
	{
		get
		{
			return _EnviaArqMasterfoods;
		}
		set
		{
			_EnviaArqMasterfoods = value;
		}
	}

	public DateTime? DtPenultCompra
	{
		get
		{
			return _DtPenultCompra;
		}
		set
		{
			_DtPenultCompra = value;
		}
	}

	public decimal? VlPenultCompra
	{
		get
		{
			return _VlPenultCompra;
		}
		set
		{
			_VlPenultCompra = value;
		}
	}

	public int? EnviadoRedbull
	{
		get
		{
			return _EnviadoRedbull;
		}
		set
		{
			_EnviadoRedbull = value;
		}
	}

	public int? Consumidor
	{
		get
		{
			return _Consumidor;
		}
		set
		{
			_Consumidor = value;
		}
	}

	public decimal? PercAceitoPrazoValidade
	{
		get
		{
			return _PercAceitoPrazoValidade;
		}
		set
		{
			_PercAceitoPrazoValidade = value;
		}
	}

	public int? CobraSeguro
	{
		get
		{
			return _CobraSeguro;
		}
		set
		{
			_CobraSeguro = value;
		}
	}

	public int? BloqAtuUltMaiorCompra
	{
		get
		{
			return _BloqAtuUltMaiorCompra;
		}
		set
		{
			_BloqAtuUltMaiorCompra = value;
		}
	}

	public decimal? PercDescFinAuto
	{
		get
		{
			return _PercDescFinAuto;
		}
		set
		{
			_PercDescFinAuto = value;
		}
	}

	public bool? EnviarArqPharmadis
	{
		get
		{
			return _EnviarArqPharmadis;
		}
		set
		{
			_EnviarArqPharmadis = value;
		}
	}

	public bool? ClienteNovoPharmadis
	{
		get
		{
			return _ClienteNovoPharmadis;
		}
		set
		{
			_ClienteNovoPharmadis = value;
		}
	}

	public int? NcUtilCfgAbatClien
	{
		get
		{
			return _NcUtilCfgAbatClien;
		}
		set
		{
			_NcUtilCfgAbatClien = value;
		}
	}

	public TipoAbatNotaCreditoCliente NcTpAbatClien
	{
		get
		{
			return _NcTpAbatClien switch
			{
				"AF" => TipoAbatNotaCreditoCliente.AutomaticoFaturamento, 
				"CF" => TipoAbatNotaCreditoCliente.Confirmacao, 
				"MA" => TipoAbatNotaCreditoCliente.ManualCtaRec, 
				_ => TipoAbatNotaCreditoCliente.Confirmacao, 
			};
		}
		set
		{
			switch (value)
			{
			case TipoAbatNotaCreditoCliente.AutomaticoFaturamento:
				_NcTpAbatClien = "AF";
				break;
			case TipoAbatNotaCreditoCliente.Confirmacao:
				_NcTpAbatClien = "CF";
				break;
			case TipoAbatNotaCreditoCliente.ManualCtaRec:
				_NcTpAbatClien = "MA";
				break;
			default:
				_NcTpAbatClien = "CF";
				break;
			}
		}
	}

	public string CdVendTecnico
	{
		get
		{
			return _CdVendTecnico;
		}
		set
		{
			_CdVendTecnico = value;
		}
	}

	public int? CdFornInst
	{
		get
		{
			return _CdFornInst;
		}
		set
		{
			_CdFornInst = value;
		}
	}

	public int? ImpDescGrdCom
	{
		get
		{
			return _ImpDescGrdCom;
		}
		set
		{
			_ImpDescGrdCom = value;
		}
	}

	public string Cnae
	{
		get
		{
			return _Cnae;
		}
		set
		{
			_Cnae = value;
		}
	}

	public int? SeqTribCli
	{
		get
		{
			return _SeqTribCli;
		}
		set
		{
			_SeqTribCli = value;
		}
	}

	public bool? AltTabPrecoAfv
	{
		get
		{
			return _AltTabPrecoAfv;
		}
		set
		{
			_AltTabPrecoAfv = value;
		}
	}

	public bool? AltTpPedAfv
	{
		get
		{
			return _AltTpPedAfv;
		}
		set
		{
			_AltTpPedAfv = value;
		}
	}

	public bool? SeqRotPrdfProvisorio
	{
		get
		{
			return _SeqRotPrdfProvisorio;
		}
		set
		{
			_SeqRotPrdfProvisorio = value;
		}
	}

	public ContCliTO[] oContCli
	{
		get
		{
			return _oContCli;
		}
		set
		{
			_oContCli = value;
		}
	}

	public EndCliTO[] oEndCli
	{
		get
		{
			return _oEndCli;
		}
		set
		{
			_oEndCli = value;
		}
	}

	public TelCliTO[] oTelCli
	{
		get
		{
			return _oTelCli;
		}
		set
		{
			_oTelCli = value;
		}
	}

	public ClientePermCompTO[] OPermComp
	{
		get
		{
			return _oPermComp;
		}
		set
		{
			_oPermComp = value;
		}
	}

	public int? QtdeCheckout
	{
		get
		{
			return _QtdeCheckout;
		}
		set
		{
			_QtdeCheckout = value;
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

	public string Iban
	{
		get
		{
			return _Iban;
		}
		set
		{
			_Iban = value;
		}
	}

	public DateTime? DtFundacao { get; set; }

	public string RetornaTpCliente()
	{
		return _TpCliente;
	}

	public void AtribuiTpPes(string TpPes)
	{
		TipoPessoa tpPes = ((TpPes == "F") ? TipoPessoa.Fisica : ((!(TpPes == "J")) ? TipoPessoa.Juridica : TipoPessoa.Juridica));
		this.TpPes = tpPes;
	}

	public string RetornaTpPes()
	{
		return _TpPes;
	}

	public void AtribuiTpInscr(string TpInscr)
	{
		this.TpInscr = TpInscr switch
		{
			"I" => TipoInscricao.Isento, 
			"E" => TipoInscricao.Estadual, 
			"M" => TipoInscricao.Municipal, 
			_ => TipoInscricao.Isento, 
		};
	}

	public string RetornaTpInscr()
	{
		return _TpInscr;
	}

	public string RetornaSituacao()
	{
		return _Situacao;
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

	public string RetornaNcTpAbatClien()
	{
		return _NcTpAbatClien;
	}

	public void IncluiContCli(ContCliTO ContCli)
	{
		List<ContCliTO> list = ((oContCli != null) ? oContCli.ToList() : new List<ContCliTO>());
		list.Add(ContCli);
		oContCli = list.ToArray();
	}

	public void IncluiEndCli(EndCliTO EndCli)
	{
		List<EndCliTO> list = ((oEndCli != null) ? oEndCli.ToList() : new List<EndCliTO>());
		list.Add(EndCli);
		oEndCli = list.ToArray();
	}

	public void IncluiTelCli(TelCliTO TelCli)
	{
		List<TelCliTO> list = ((oTelCli != null) ? oTelCli.ToList() : new List<TelCliTO>());
		list.Add(TelCli);
		oTelCli = list.ToArray();
	}

	public void IncluiPermCompTO(ClientePermCompTO PermComp)
	{
		List<ClientePermCompTO> list = ((OPermComp != null) ? OPermComp.ToList() : new List<ClientePermCompTO>());
		list.Add(PermComp);
		OPermComp = list.ToArray();
	}
}
