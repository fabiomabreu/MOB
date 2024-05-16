using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Target.Venda.Business.Base;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Fluxo;

public class LiberarMultiplosPedidosEletronicosBLL : FluxoBaseBLL, ILiberarMultiplosPedidosEletronicosBLL, IFluxoBaseBLL
{
	private static List<RetornoLiberarPedidoEletronicoVO> _retornosPedidos;

	public List<RetornoLiberarPedidoEletronicoVO> ExecutarMultiplosPedidos(List<ParametrosLiberarPedidoEletronicoVO> listaParametrosLiberarPedidoEle)
	{
		_retornosPedidos = new List<RetornoLiberarPedidoEletronicoVO>();
		if (ConfigHelper.getBoolAppConfig("ReservarEstoqueComCorte"))
		{
			ParallelOptions opcoes = new ParallelOptions();
			opcoes.MaxDegreeOfParallelism = ConfigHelper.getAppConfig("QuantidadeThreadSimultaneo").ToInt();
			if (opcoes.MaxDegreeOfParallelism == 0)
			{
				opcoes.MaxDegreeOfParallelism = 50;
			}
			Task<ParallelLoopResult> task = Task.Factory.StartNew(() => Parallel.ForEach(listaParametrosLiberarPedidoEle, opcoes, delegate(ParametrosLiberarPedidoEletronicoVO x)
			{
				LiberarPedido(x);
			}));
			task.Wait();
		}
		else
		{
			foreach (ParametrosLiberarPedidoEletronicoVO item in listaParametrosLiberarPedidoEle)
			{
				LiberarPedido(item);
			}
		}
		return _retornosPedidos;
	}

	private void LiberarPedido(object paramPedido)
	{
		try
		{
			ParametrosLiberarPedidoEletronicoVO objetoParametroLiberarPedidoEle = (ParametrosLiberarPedidoEletronicoVO)paramPedido;
			LiberarPedidoEletronicoBLL liberarPedidoEletronicoBLL = new LiberarPedidoEletronicoBLL();
			liberarPedidoEletronicoBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
			RetornoLiberarPedidoEletronicoVO item = liberarPedidoEletronicoBLL.Executar(objetoParametroLiberarPedidoEle);
			_retornosPedidos.Add(item);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
		}
	}
}
