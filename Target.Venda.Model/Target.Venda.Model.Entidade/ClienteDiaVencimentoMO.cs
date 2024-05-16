using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("ClienteDiaVencimento")]
public class ClienteDiaVencimentoMO : EntidadeBaseMO
{
	[Column("ClienteDiaVencimentoID", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CLIENTE_DIA_VENCIMENTO_ID { get; set; }

	[Column("CdClien", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_CLIENTE { get; set; }

	[Column("DiaVencimento")]
	public int DIA_VENCIMENTO { get; set; }

	[ForeignKey("CODIGO_CLIENTE")]
	public ClienteMO CLIENTE { get; set; }
}
