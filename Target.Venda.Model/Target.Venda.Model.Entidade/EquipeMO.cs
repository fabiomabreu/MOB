using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("equipe")]
public class EquipeMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_equipe", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_EQUIPE { get; set; }

	[Column("EquipeId")]
	public int ID_EQUIPE { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("cd_vend_sup")]
	public string CODIGO_VENDEDOR_SUPERVISOR { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("cd_gerencia")]
	public string CODIGO_GERENCIA { get; set; }
}
