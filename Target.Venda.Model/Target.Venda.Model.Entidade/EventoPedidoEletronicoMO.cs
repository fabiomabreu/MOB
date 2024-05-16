using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evento_pdel")]
public class EventoPedidoEletronicoMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_EVENTO { get; set; }

	[Column("cd_emp_ele")]
	public int CODIGO_EMPRESA_ELETRONICO { get; set; }

	[Column("nu_ped_ele")]
	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	[Column("seq_ped")]
	public decimal SEQ_PEDIDO { get; set; }

	[Column("cd_usr_ger")]
	public string CODIGO_USUARIO_GERACAO { get; set; }

	[Column("dt_criacao")]
	public DateTime DATA_CRIACAO { get; set; }

	[Column("cd_usr_enc")]
	public string CODIGO_USUARIO_ENCERRAMENTO { get; set; }

	[Column("dt_encer")]
	public DateTime? DATA_ENCERRAMENTO { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[ForeignKey("CODIGO_EMPRESA_ELETRONICO, NUMERO_PEDIDO_ELETRONICO,SEQ_PEDIDO")]
	public PedidoEletronicoMO PEDVDAELETO { get; set; }

	public EventoPedidoEletronicoAbertoMO EVENTO_PEDIDO_ELETRONICO_AB { get; set; }
}
