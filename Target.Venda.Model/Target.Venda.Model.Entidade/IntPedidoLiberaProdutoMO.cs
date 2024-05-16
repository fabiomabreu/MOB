using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("int_pdv_lib_prod")]
public class IntPedidoLiberaProdutoMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_prod", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_PRODUTO { get; set; }

	[Column("tp_inc")]
	public BoolEnum? TIPO_INCLUIR { get; set; }

	[Column("tp_alt")]
	public BoolEnum? TIPO_ALTERAR { get; set; }

	[Column("tp_pre")]
	public BoolEnum? TIPO_PRE { get; set; }

	[Column("etiqueta")]
	public BoolEnum? ETIQUETA { get; set; }
}
