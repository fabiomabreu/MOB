using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("troca")]
public class TrocaMO : EntidadeBaseMO
{
	[Column("seq_troca")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_TROCA { get; set; }

	[Column("dt_cad")]
	public DateTime DATA_CADASTRO { get; set; }

	[Column("cd_vend")]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("cd_clien")]
	public int CODIGO_CLIENTE { get; set; }

	[Column("cd_motcanc")]
	public string CODIGO_MOTIVO_CANCELAMENTO { get; set; }

	[Column("prod_localiza")]
	public string PRODUTO_LOCALIZA { get; set; }

	[Column("cd_emp_estoque")]
	public int? CODIGO_EMPRESA_ESTOQUE { get; set; }

	[Column("cd_local_estoque")]
	public string CODIGO_LOCAL_ESTOQUE { get; set; }

	[Column("cd_emp_pedido")]
	public int? CODIGO_EMPRESA_PEDIDO { get; set; }

	[Column("nu_ped_pedido")]
	public int? NUMERO_PEDIDO { get; set; }

	[Column("vl_total")]
	public decimal VALOR_TOTAL { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("tp_abatimento")]
	public string TIPO_ABATIMENTO { get; set; }

	[Column("tp_envio")]
	public string TIPO_ENVIO { get; set; }

	[Column("vl_total_recebido")]
	public decimal VALOR_TOTAL_RECEBIDO { get; set; }

	[Column("cd_emp")]
	public int CODIGO_EMPRESA { get; set; }

	[Column("referencia")]
	public string REFERENCIA { get; set; }

	[Column("cd_troca_palm")]
	public string CODIGO_TROCA_PALM { get; set; }

	[Column("dt_cad_palm")]
	public DateTime? DATA_CADASTRO_PALM { get; set; }

	[Column("cd_tabela")]
	public string CODIGO_TABELA { get; set; }

	[Column("seq_email")]
	public int? SEQ_EMAIL { get; set; }

	[Column("Indenizacao")]
	public bool INDENIZACAO { get; set; }
}
