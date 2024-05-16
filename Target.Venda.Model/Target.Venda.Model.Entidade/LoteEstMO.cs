using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("lote_est")]
public class LoteEstMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_local", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_LOCAL { get; set; }

	[Column("cd_prod", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_PRODUTO { get; set; }

	[Column("seq_lote")]
	public int SEQ_LOTE { get; set; }

	[Column("qtde")]
	public decimal QTDE { get; set; }

	[Column("qtde_pend_pedv")]
	public decimal QTDE_PEND_PEDV { get; set; }

	[NotMapped]
	public DateTime DT_VALIDADE_LOTE { get; set; }
}
