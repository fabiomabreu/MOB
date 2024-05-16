using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("ev_erpv")]
public class EventoErpVendaMO : EntidadeBaseMO
{
	[Column("seq_evento")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_EVENTO { get; set; }

	[Column("cd_emp")]
	public int? CODIGO_EMPRESA { get; set; }

	[Column("nu_ped")]
	public int NUMERO_PEDIDO { get; set; }

	[Column("seq_it_pedv")]
	public short? SEQ_ITEM_PEDIDO { get; set; }

	[Column("seq_erro")]
	public short? SEQ_ERRO { get; set; }

	[Column("cd_fila")]
	public string CODIGO_FILA { get; set; }
}
