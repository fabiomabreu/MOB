using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("cli_emp")]
public class ClienteEmpresaMO : EntidadeBaseMO
{
	[Column("cd_clien", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_CLIENTE { get; set; }

	[Column("cd_emp", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_tabela")]
	public string CODIGO_TABELA { get; set; }

	[Column("seq_prom")]
	public int? SEQ_PROMOCAO { get; set; }

	[Column("nu_banco_ve")]
	public short? NUMERO_BANCO_VE { get; set; }

	[Column("nu_agencia_ve")]
	public string NUMERO_AGENCIA_VE { get; set; }

	[Column("nu_conta_ve")]
	public string NUMERO_CONTA_VE { get; set; }

	[Column("nu_banco_vs")]
	public short? NUMERO_BANCO_VS { get; set; }

	[Column("nu_agencia_vs")]
	public string NUMERO_AGENCIA_VS { get; set; }

	[Column("nu_conta_vs")]
	public string NUMERO_CONTA_VS { get; set; }

	[Column("vl_lim_ped_pf")]
	public decimal? VALOR_LIMITE_PEDIDO_PF { get; set; }

	[Column("prz_medio_max")]
	public short? PRAZO_MEDIO_MAXIMO { get; set; }

	[Column("Utiliza")]
	public bool UTILIZA { get; set; }

	[ForeignKey("CODIGO_CLIENTE")]
	public ClienteMO CLIENTE { get; set; }
}
