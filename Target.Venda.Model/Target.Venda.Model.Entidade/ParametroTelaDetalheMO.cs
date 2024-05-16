using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("pcfg_tela_det")]
public class ParametroTelaDetalheMO : EntidadeBaseMO
{
	[Column("cd_tela", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_TELA { get; set; }

	[Column("seq", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("ativo")]
	public bool ATIVO { get; set; }

	[Column("versao")]
	public string VERSAO { get; set; }
}
