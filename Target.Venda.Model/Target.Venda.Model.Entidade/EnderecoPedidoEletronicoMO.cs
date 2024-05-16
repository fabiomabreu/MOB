using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("end_ped_ele")]
public class EnderecoPedidoEletronicoMO : EntidadeBaseMO
{
	[Column("cd_emp_ele", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA_ELETRONICO { get; set; }

	[Column("nu_ped_ele", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	[Column("seq_ped", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public decimal SEQ_PEDIDO { get; set; }

	[Column("seq", Order = 4)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public short SEQ { get; set; }

	[Column("tp_end_ped")]
	public string TIPO_ENDERECO { get; set; }

	[Column("endereco")]
	public string ENDERECO { get; set; }

	[Column("cep")]
	public int CEP { get; set; }

	[Column("cd_cep_munic")]
	public int? CODIGO_CEP_MUNICIPIO { get; set; }

	[Column("logradouro")]
	public string LOGRADOURO { get; set; }

	[Column("numero")]
	public string NUMERO { get; set; }

	[Column("complemento")]
	public string COMPLEMENTO { get; set; }

	[Column("bairro")]
	public string BAIRRO { get; set; }

	[Column("distrito")]
	public string DISTRITO { get; set; }

	[Column("municipio")]
	public string MUNICIPIO { get; set; }

	[Column("estado")]
	public string ESTADO { get; set; }

	[Column("cd_pais")]
	public string CODIGO_PAIS { get; set; }

	[Column("loc_guia")]
	public string LOCALIZACAO_GUIA { get; set; }

	[ForeignKey("CODIGO_EMPRESA_ELETRONICO, NUMERO_PEDIDO_ELETRONICO,SEQ_PEDIDO")]
	public PedidoEletronicoMO PEDVDAELETO { get; set; }
}
