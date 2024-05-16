using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("ContratoOperadoraCartaoCredito")]
public class ContratoOperadoraCartaoCreditoMO : EntidadeBaseMO
{
	[Column("ContratoOperadoraCartaoCreditoID", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CONTRATO_ID { get; set; }

	[Column("Codigo")]
	public string CODIGO { get; set; }

	[Column("Filiacao")]
	public string FILIACAO { get; set; }

	[Column("CtaCorID")]
	public int CONTA_CORRENTE_ID { get; set; }

	[Column("CdEmp")]
	public int CODIGO_EMPRESA { get; set; }

	[Column("Ativo")]
	public bool ATIVO { get; set; }

	[Column("PercTaxaContrato")]
	public decimal PERC_TAXA_CONTRATO { get; set; }

	[Column("RateioTaxaItensPedido")]
	public bool? RATEIO_TAXA_ITENS_PEDIDO { get; set; }
}
