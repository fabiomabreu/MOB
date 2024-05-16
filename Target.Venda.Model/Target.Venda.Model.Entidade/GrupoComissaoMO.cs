using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("grp_comis")]
public class GrupoComissaoMO : EntidadeBaseMO
{
	[Column("cd_grp_comis")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_GRUPO_COMISSAO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("ativo")]
	public BoolEnum ATIVO { get; set; }

	[Column("perc_comis")]
	public decimal PERCENTUAL_COMISSAO { get; set; }

	[Column("sigla")]
	public string SIGLA { get; set; }
}
