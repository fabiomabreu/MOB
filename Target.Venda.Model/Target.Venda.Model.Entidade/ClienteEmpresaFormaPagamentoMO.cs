using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("cli_emp_formpgto")]
public class ClienteEmpresaFormaPagamentoMO : EntidadeBaseMO
{
	[Column("cd_clien", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_CLIENTE { get; set; }

	[Column("cd_emp", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMRPESA { get; set; }

	[Column("formpgto", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string FORMA_PAGAMENTO { get; set; }

	[Column("principal")]
	public BoolEnum? PRINCIPAL { get; set; }

	[ForeignKey("CODIGO_CLIENTE")]
	public ClienteMO CLIENTE_EMPRESA { get; set; }
}
