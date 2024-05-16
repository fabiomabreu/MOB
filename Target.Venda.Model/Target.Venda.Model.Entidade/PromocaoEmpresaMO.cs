using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("promocao_emp")]
public class PromocaoEmpresaMO : EntidadeBaseMO
{
	[Column("seq_prom", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_PROMOCAO { get; set; }

	[Column("cd_emp", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("utiliza")]
	public BoolEnum UTILIZA { get; set; }

	[Column("DiasDescFinanc")]
	public short? DIASDESCFINANC { get; set; }

	[Column("PercDescFinAuto")]
	public decimal? PERCDESCFINAUTO { get; set; }

	[ForeignKey("SEQ_PROMOCAO")]
	public PromocaoMO PROMOCAO { get; set; }
}
