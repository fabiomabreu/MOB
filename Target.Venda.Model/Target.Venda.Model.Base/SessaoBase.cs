using System;

namespace Target.Venda.Model.Base;

public abstract class SessaoBase
{
	public int ID_SESSSAO { get; set; }

	public DateTime DATA_CRIACAO_SESSAO { get; set; }
}
