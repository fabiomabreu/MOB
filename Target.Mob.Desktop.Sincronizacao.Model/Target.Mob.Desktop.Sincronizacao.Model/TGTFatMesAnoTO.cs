using System;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.Model;

[Serializable]
[XmlRoot(ElementName = "tgt_fat_mes_ano")]
public class TGTFatMesAnoTO
{
	private string _cnpj;

	private string _siglaClien;

	private string _empresa;

	private int _ano;

	private int _mes;

	private decimal? _faturamento;

	private decimal? _mgBrtVl;

	private decimal? _mgBrtPerc;

	private decimal? _mgCtbVl;

	private decimal? _mgCtbPerc;

	private int? _cobertura;

	private int? _cliAtivo;

	private int? _mixPrd;

	private int? _prdAtivo;

	private int? _mixFabric;

	private int? _fabricAtivo;

	private int? _qtdePedidos;

	private int? _qtdeItens;

	private int? _vendPosit;

	private int? _vendAtivo;

	private int? _qtdeRoteiros;

	private int? _qtdeEntregas;

	private decimal? _pesoTotal;

	private decimal? _vlCortePrd;

	private decimal? _vlCorteLog;

	private decimal? _vlDevolucao;

	private int? _usuarioAtivo;

	private DateTime? _data;

	private byte[] _rowId;

	[XmlElement(ElementName = "cnpj")]
	public string Cnpj
	{
		get
		{
			return _cnpj;
		}
		set
		{
			_cnpj = value;
		}
	}

	[XmlElement(ElementName = "sigla_clien")]
	public string SiglaClien
	{
		get
		{
			return _siglaClien;
		}
		set
		{
			_siglaClien = value;
		}
	}

	[XmlElement(ElementName = "empresa")]
	public string Empresa
	{
		get
		{
			return _empresa;
		}
		set
		{
			_empresa = value;
		}
	}

	[XmlElement(ElementName = "ano")]
	public int Ano
	{
		get
		{
			return _ano;
		}
		set
		{
			_ano = value;
		}
	}

	[XmlElement(ElementName = "mes")]
	public int Mes
	{
		get
		{
			return _mes;
		}
		set
		{
			_mes = value;
		}
	}

	[XmlElement(ElementName = "faturamento")]
	public decimal? Faturamento
	{
		get
		{
			return _faturamento;
		}
		set
		{
			_faturamento = value;
		}
	}

	[XmlElement(ElementName = "mg_brt_vl")]
	public decimal? MgBrtVl
	{
		get
		{
			return _mgBrtVl;
		}
		set
		{
			_mgBrtVl = value;
		}
	}

	[XmlElement(ElementName = "mg_brt_perc")]
	public decimal? MgBrtPerc
	{
		get
		{
			return _mgBrtPerc;
		}
		set
		{
			_mgBrtPerc = value;
		}
	}

	[XmlElement(ElementName = "mg_ctb_vl")]
	public decimal? MgCtbVl
	{
		get
		{
			return _mgCtbVl;
		}
		set
		{
			_mgCtbVl = value;
		}
	}

	[XmlElement(ElementName = "mg_ctb_perc")]
	public decimal? MgCtbPerc
	{
		get
		{
			return _mgCtbPerc;
		}
		set
		{
			_mgCtbPerc = value;
		}
	}

	[XmlElement(ElementName = "cobertura")]
	public int? Cobertura
	{
		get
		{
			return _cobertura;
		}
		set
		{
			_cobertura = value;
		}
	}

	[XmlElement(ElementName = "cli_ativo")]
	public int? CliAtivo
	{
		get
		{
			return _cliAtivo;
		}
		set
		{
			_cliAtivo = value;
		}
	}

	[XmlElement(ElementName = "mix_prd")]
	public int? MixPrd
	{
		get
		{
			return _mixPrd;
		}
		set
		{
			_mixPrd = value;
		}
	}

	[XmlElement(ElementName = "prd_ativo")]
	public int? PrdAtivo
	{
		get
		{
			return _prdAtivo;
		}
		set
		{
			_prdAtivo = value;
		}
	}

	[XmlElement(ElementName = "mix_fabric")]
	public int? MixFabric
	{
		get
		{
			return _mixFabric;
		}
		set
		{
			_mixFabric = value;
		}
	}

	[XmlElement(ElementName = "fabric_ativo")]
	public int? FabricAtivo
	{
		get
		{
			return _fabricAtivo;
		}
		set
		{
			_fabricAtivo = value;
		}
	}

	[XmlElement(ElementName = "qtde_pedidos")]
	public int? QtdePedidos
	{
		get
		{
			return _qtdePedidos;
		}
		set
		{
			_qtdePedidos = value;
		}
	}

	[XmlElement(ElementName = "qtde_itens")]
	public int? QtdeItens
	{
		get
		{
			return _qtdeItens;
		}
		set
		{
			_qtdeItens = value;
		}
	}

	[XmlElement(ElementName = "vend_posit")]
	public int? VendPosit
	{
		get
		{
			return _vendPosit;
		}
		set
		{
			_vendPosit = value;
		}
	}

	[XmlElement(ElementName = "vend_ativo")]
	public int? VendAtivo
	{
		get
		{
			return _vendAtivo;
		}
		set
		{
			_vendAtivo = value;
		}
	}

	[XmlElement(ElementName = "qtde_roteiros")]
	public int? QtdeRoteiros
	{
		get
		{
			return _qtdeRoteiros;
		}
		set
		{
			_qtdeRoteiros = value;
		}
	}

	[XmlElement(ElementName = "qtde_entregas")]
	public int? QtdeEntregas
	{
		get
		{
			return _qtdeEntregas;
		}
		set
		{
			_qtdeEntregas = value;
		}
	}

	[XmlElement(ElementName = "peso_total")]
	public decimal? PesoTotal
	{
		get
		{
			return _pesoTotal;
		}
		set
		{
			_pesoTotal = value;
		}
	}

	[XmlElement(ElementName = "vl_corte_prd")]
	public decimal? VlCortePrd
	{
		get
		{
			return _vlCortePrd;
		}
		set
		{
			_vlCortePrd = value;
		}
	}

	[XmlElement(ElementName = "vl_corte_log")]
	public decimal? VlCorteLog
	{
		get
		{
			return _vlCorteLog;
		}
		set
		{
			_vlCorteLog = value;
		}
	}

	[XmlElement(ElementName = "vl_devolucao")]
	public decimal? VlDevolucao
	{
		get
		{
			return _vlDevolucao;
		}
		set
		{
			_vlDevolucao = value;
		}
	}

	[XmlElement(ElementName = "usuario_ativo")]
	public int? UsuarioAtivo
	{
		get
		{
			return _usuarioAtivo;
		}
		set
		{
			_usuarioAtivo = value;
		}
	}

	[XmlElement(ElementName = "data")]
	public DateTime? Data
	{
		get
		{
			return _data;
		}
		set
		{
			_data = value;
		}
	}

	[XmlElement(ElementName = "rowid")]
	public byte[] RowId
	{
		get
		{
			return _rowId;
		}
		set
		{
			_rowId = value;
		}
	}
}
