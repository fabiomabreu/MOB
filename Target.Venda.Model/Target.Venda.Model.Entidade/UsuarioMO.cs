using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("usuario")]
public class UsuarioMO : EntidadeBaseMO
{
	[Column("cd_usuario")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_USUARIO { get; set; }

	[Column("nome")]
	public string NOME { get; set; }

	[Column("senha_usr")]
	public string SENHA_USUARIO { get; set; }

	[Column("dt_cadastr")]
	public DateTime DATA_CADASTRO { get; set; }

	[Column("dt_ult_lin")]
	public DateTime? DATA_ULTIMA_LIN { get; set; }

	[Column("dt_ult_lout")]
	public DateTime? DATA_ULTIMA_LOUT { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("vl_carteira")]
	public decimal? VALOR_CARTEIRA { get; set; }

	[Column("vl_compl")]
	public decimal? VALOR_COMPL { get; set; }

	[Column("vl_real")]
	public decimal? VALOR_REAL { get; set; }

	[Column("e_mail")]
	public string E_MAIL { get; set; }

	[Column("cd_usr_int")]
	public int? CODIGO_USUARIO_INTERNO { get; set; }

	[Column("cd_setor")]
	public string CODIGO_SETOR { get; set; }

	[Column("dt_admissao")]
	public DateTime? DATA_ADMISSAO { get; set; }

	[Column("UsuarioID")]
	public int USUARIO_ID { get; set; }

	[Column("CdBarraUsuario")]
	public string CODIGO_BARRA_USUARIO { get; set; }

	[Column("UtilizaCdBarraInterno")]
	public bool? UTILIZA_CODIGO_BARRA_INTERNO { get; set; }

	[Column("CdBarraInterno")]
	public string CODIGO_BARRA_INTERNO { get; set; }
}
