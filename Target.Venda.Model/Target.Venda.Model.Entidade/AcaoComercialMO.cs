using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("acao_comercial")]
public class AcaoComercialMO : EntidadeBaseMO
{
	[Column("seq_acao_comercial")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_ACAO_COMERCIAL { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("cd_fabric")]
	public string CODIGO_FABRICANTE { get; set; }

	[Column("dt_inicio")]
	public DateTime DATA_INICIO { get; set; }

	[Column("dt_fim")]
	public DateTime DATA_FIM { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("tp_acao_comercial")]
	public string TIPO_ACAO_COMERCIAL { get; set; }

	[Column("tp_aplic_valor")]
	public string TIPO_APLICACAO_VALOR { get; set; }

	[Column("valor")]
	public decimal VALOR { get; set; }

	[Column("seq_kit")]
	public int? SEQ_KIT { get; set; }

	[Column("altera_preco_venda")]
	public bool? ALTERA_PRECO_VENDA { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("cd_tabela_simula_margens")]
	public string CODIGO_TABELA_SIMULA_MARGENS { get; set; }

	[Column("tp_custo_simula_margens")]
	public string TIPO_CUSTO_SIMULA_MARGENS { get; set; }

	[Column("altera_preco_tabela")]
	public bool? ALTERA_PRECO_TABELA { get; set; }

	[Column("altera_preco_pos")]
	public bool? ALTERA_PRECO_POS { get; set; }

	public List<AcaoComercialProdutoMO> PRODUTOS { get; set; }

	public List<AcaoComercialProdutoPrecoMO> PRODUTOS_PRECOS { get; set; }

	public List<AcaoComercialPromocaoMO> PROMOCOES { get; set; }
}
