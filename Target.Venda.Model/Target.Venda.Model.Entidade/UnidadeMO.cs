using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("unidade")]
public class UnidadeMO : EntidadeBaseMO
{
	[Key]
	[Column("unidade")]
	public string UNIDADE { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("enfardavel")]
	public bool? ENFARDAVEL { get; set; }

	[Column("num_lock")]
	public short NUM_LOCK { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("qtde_decimais_nf")]
	public short QTDE_DECIMAIS_NF { get; set; }

	[Column("cd_unidade_ean")]
	public string CD_UNIDADE_EAN { get; set; }

	[Column("codigo_mercador")]
	public string CODIGO_MERCADOR { get; set; }
}
