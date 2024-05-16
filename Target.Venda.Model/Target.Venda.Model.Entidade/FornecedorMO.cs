using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("fornec")]
public class FornecedorMO : EntidadeBaseMO
{
	[Column("cd_forn")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_FORNECEDOR { get; set; }

	[Column("tp_pes")]
	public string TIPO_PESSOA { get; set; }

	[Column("tp_inscr")]
	public string TIPO_INSCRICAO { get; set; }

	[Column("inscricao")]
	public string INSCRICAO { get; set; }

	public List<EnderecoFornecedorMO> ENDERECOS { get; set; }
}
