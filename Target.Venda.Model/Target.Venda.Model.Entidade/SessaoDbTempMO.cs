using System;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

public class SessaoDbTempMO : EntidadeBaseMO
{
	public string CODIGO_USUARIO { get; set; }

	public string NOME_TABELA_TEMPORARIA { get; set; }

	public DateTime DATA_CRIACAO { get; set; }
}
