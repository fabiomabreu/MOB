using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("tpedcfop")]
public class TipoPedidoCfopMO : EntidadeBaseMO
{
	[Column("tp_ped", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string TIPO_PEDIDO { get; set; }

	[Column("cfop", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CFOP { get; set; }

	[Column("desc_cfop")]
	public string DESCRICAO_CFOP { get; set; }

	[Column("desc_ntop")]
	public string DESCRICAO_NTOP { get; set; }

	[Column("cfop_corresp")]
	public int CFOP_CORRESPONDENTE { get; set; }

	[Column("desc_cfop_corresp")]
	public string DESCRICAO_CFOP_CORRESP { get; set; }

	[Column("desc_ntop_corresp")]
	public string DESCRICAO_NTOP_CORRESP { get; set; }

	[Column("codigo_lftpope")]
	public decimal? CODIGO_LFTPOPE { get; set; }

	[Column("cli_inscr_est")]
	public BoolEnum? CLIENTE_INSCRICAO_ESTADUAL { get; set; }

	[Column("cli_inscr_est_nao")]
	public BoolEnum? CLIENTE_INSCRICAO_ESTADUAL_NAO { get; set; }

	[Column("area_livre_comercio")]
	public BoolEnum? AREA_LIVRE_COMERCIO { get; set; }

	[ForeignKey("CFOP")]
	public CfopMO FK_CFOP { get; set; }
}
