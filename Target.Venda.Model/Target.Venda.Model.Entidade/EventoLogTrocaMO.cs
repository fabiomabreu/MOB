using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("evlog_troca")]
public class EventoLogTrocaMO : EntidadeBaseMO
{
	[Column("seq_evento_log")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_EVENTO_LOG { get; set; }

	[Column("seq_troca")]
	public int SEQ_TROCA { get; set; }

	[Column("prod_localiza")]
	public string PRODUTO_LOCALIZA { get; set; }

	[Column("cd_emp_estoque")]
	public int? CODIGO_EMPRESA_ESTOQUE { get; set; }

	[Column("cd_local_estoque")]
	public string CODIGO_LOCAL_ESTOQUE { get; set; }
}
