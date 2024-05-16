using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("local")]
public class LocalMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_local", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_LOCAL { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("central")]
	public bool? CENTRAL { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("wms_sem_assoc_prod")]
	public BoolEnum? WMS_SEM_ASSOCIACAO_PROD { get; set; }

	[Column("inventario")]
	public BoolEnum? INVENTARIO { get; set; }

	[Column("bloquear_devolucao")]
	public BoolEnum? BLOQUEAR_DEVOLUCAO { get; set; }

	[Column("cd_local_invent")]
	public string CODIGO_LOCAL_INVENTARIO { get; set; }

	[Column("nao_permite_avaria")]
	public bool? NAO_PERMITE_AVARIA { get; set; }

	[Column("PropPosseProdID")]
	public int PROPRIEDADE_POSSE_PRODUTO_ID { get; set; }

	[Column("CdFornPropPosse")]
	public int? CODIGO_FORNECEDOR_PROPRIEDADE_POSSE { get; set; }
}
