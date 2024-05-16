using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("empresa")]
public class EmpresaMO : EntidadeBaseMO
{
	public int cod;

	[Column("cd_emp")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("EmpresaID")]
	public int ID_EMPRESA { get; set; }

	[Column("tipo")]
	public string TIPO { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("raz_soc")]
	public string RAZAO_SOCIAL { get; set; }

	[Column("nome_fant")]
	public string NOME_FANTASIA { get; set; }

	[Column("cgc")]
	public string CNPJ { get; set; }

	[Column("ean13")]
	public string EAN { get; set; }

	[Column("estado")]
	public string ESTADO { get; set; }

	[Column("logradouro")]
	public string LOGRADOURO { get; set; }

	[Column("numero")]
	public string NUMERO { get; set; }

	[Column("cd_pais")]
	public string CODIGO_PAIS { get; set; }

	[Column("inscricao")]
	public string IE { get; set; }

	[Column("seq_tributacao_regime")]
	public byte? SEQ_TRIBUTACAO_REGIME { get; set; }

	public string DESCRICAO_EMPRSA
	{
		get
		{
			if (CODIGO_EMPRESA > 0)
			{
				return CODIGO_EMPRESA + " - " + RAZAO_SOCIAL;
			}
			return RAZAO_SOCIAL;
		}
	}
}
