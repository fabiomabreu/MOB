using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("tped_outros_locais_est")]
public class TipoPedidoOutrosLocaisMO : EntidadeBaseMO
{
	[Column("tp_ped", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_TIPO_PEDIDO { get; set; }

	[Column("cd_emp", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_local", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_LOCAL { get; set; }

	[Column("ordem")]
	public short? ORDEM { get; set; }
}
