using System;
using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Base.Delegate;

namespace Target.Venda.Business.Base;

public abstract class ModuloBaseBLL : IModuloBaseBLL
{
	public event RetornoMensagensHandler EventRetornoMensagem;

	public ModuloBaseBLL()
	{
	}

	public void RetornaMensagemAviso(string mensagem)
	{
		if (this.EventRetornoMensagem != null)
		{
			this.EventRetornoMensagem(DateTime.Now.ToString() + ": " + mensagem);
		}
	}
}
