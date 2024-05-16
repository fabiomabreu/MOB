using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("end_ped")]
public class EnderecoPedidoMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("nu_ped", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO { get; set; }

	[Column("seq", Order = 3)]
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

	[Column("localizacao")]
	public string LOCALIZACAO { get; set; }

	[Column("loc_guia")]
	public string LOCALIZACAO_GUIA { get; set; }

	[ForeignKey("CODIGO_EMPRESA, NUMERO_PEDIDO")]
	public PedidoVendaMO PEDIDO { get; set; }
}
