using System;
using System.Text;
using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Base.Delegate;

namespace Target.Venda.Business.Base;

public abstract class FluxoBaseBLL : IFluxoBaseBLL
{
	protected StringBuilder LogEventosProcesso = new StringBuilder();

	public event RetornoMensagensHandler EventRetornoMensagem;

	public void RetornaMensagemAviso(string mensagem)
	{
		mensagem = DateTime.Now.ToString() + ": " + mensagem;
		LogEventosProcesso.AppendLine(mensagem);
		if (this.EventRetornoMensagem != null)
		{
			this.EventRetornoMensagem(mensagem);
		}
	}
}
