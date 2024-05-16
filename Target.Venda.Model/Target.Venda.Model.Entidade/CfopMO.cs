using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("cfop")]
public class CfopMO : EntidadeBaseMO
{
	[Column("cfop")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CFOP { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("tipo")]
	public string TIPO { get; set; }

	[Column("cli_dest")]
	public string CLIENTE_DESTINO { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("cd_operacao")]
	public string CODIGO_OPERACAO { get; set; }

	[Column("bonificado")]
	public BoolEnum? BONIFICADO { get; set; }

	[Column("cfop_dev_posterior")]
	public int? CFOP_DEVOLUCAO_POSTERIOR { get; set; }

	[Column("devolucao")]
	public bool? DEVOLUCAO { get; set; }

	public List<TipoPedidoCfopMO> TIPOS_PEDIDOS { get; set; }
}
