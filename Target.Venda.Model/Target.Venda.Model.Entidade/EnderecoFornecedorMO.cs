using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Target.Venda.Model.Entidade;

[Table("end_for")]
public class EnderecoFornecedorMO
{
	[Column("cd_forn", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_FORNECEDOR { get; set; }

	[Column("tp_end", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
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

	[ForeignKey("CODIGO_FORNECEDOR")]
	public FornecedorMO FORNECEDOR { get; set; }
}
