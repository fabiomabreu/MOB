using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using Target.Venda.IBusiness.Factory;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.Model.Visao;

namespace Target.Venda.ConsoleView;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Thread atual: {0}", Thread.CurrentThread.ManagedThreadId);
		Console.WriteLine();
		Parallel.For(0, 6, new ParallelOptions
		{
			MaxDegreeOfParallelism = 2
		}, delegate(int i)
		{
			DataObject dataObject = new DataObject
			{
				Message = "Pedido: " + i,
				Status = i.ToString()
			};
			string value = $"*THREAD: {Thread.CurrentThread.ManagedThreadId}: - {dataObject.Message}";
			Console.WriteLine(value);
			CallContext.LogicalSetData("data", dataObject);
			Process();
		});
		Console.WriteLine("Fim das Threads");
		Console.WriteLine();
		DataObject data = new DataObject
		{
			Message = "STA - Pedido: XXXX"
		};
		CallContext.SetData("data", data);
		Process();
		Console.ReadLine();
	}

	private static void Process()
	{
		DataObject dataObject = CallContext.LogicalGetData("data") as DataObject;
		Thread.Sleep(1000 + Convert.ToInt32(dataObject.Status));
		Console.WriteLine("OBTEVE NA THREAD: {0}: - {1}", Thread.CurrentThread.ManagedThreadId, dataObject.Message);
		dataObject = CallContext.LogicalGetData("data") as DataObject;
		Console.WriteLine("OBTEVE NA THREAD: {0}: - {1}", Thread.CurrentThread.ManagedThreadId, dataObject.Message);
	}

	private static void TestarCancelamentoPedido(string[] args)
	{
		ICancelarPedidoVendaBLL cancelarPedidoVendaBLL = BusinessFactory.GetCancelarPedidoVendaBLL();
		ParametrosCancelarPedidoVO parametrosCancelarPedidoVO = new ParametrosCancelarPedidoVO();
		parametrosCancelarPedidoVO.CODIGO_USUARIO = "SUPER";
		parametrosCancelarPedidoVO.NOME_PROGRAMA = "TARGET EDI";
		parametrosCancelarPedidoVO.CODIGO_EMPRESA = 1;
		parametrosCancelarPedidoVO.NUMERO_PEDIDO = 243609;
		RetornoCancelarPedidoVendaVO retornoCancelarPedidoVendaVO = cancelarPedidoVendaBLL.Executar(parametrosCancelarPedidoVO);
	}

	private static void TestarLiberacaoPedido(string[] args)
	{
		try
		{
			ILiberarPedidoEletronicoBLL liberarPedidoEletronicoBLL = BusinessFactory.GetLiberarPedidoEletronicoBLL();
			liberarPedidoEletronicoBLL.EventRetornoMensagem += Liberar_EventRetornoMensagem;
			ParametrosLiberarPedidoEletronicoVO parametrosLiberarPedidoEletronicoVO = ObterParametrosPeloArgs(args);
			liberarPedidoEletronicoBLL.Executar(parametrosLiberarPedidoEletronicoVO);
			Console.WriteLine($"Pedido Eletronico {parametrosLiberarPedidoEletronicoVO.NUMERO_PEDIDO_ELETRONICO} processado com sucesso!");
			Console.ReadKey();
		}
		catch (Exception ex)
		{
			Console.WriteLine("Erro: " + ex.Message);
			Console.WriteLine("Causa: " + ex.StackTrace);
		}
	}

	private static void Liberar_EventRetornoMensagem(string message)
	{
	}

	private static ParametrosLiberarPedidoEletronicoVO ObterParametrosPeloArgs(string[] args)
	{
		ParametrosLiberarPedidoEletronicoVO parametrosLiberarPedidoEletronicoVO = new ParametrosLiberarPedidoEletronicoVO();
		if (args != null && args.Count() > 0 && args.Count() == 5)
		{
			parametrosLiberarPedidoEletronicoVO.NOME_PROGRAMA = args[0];
			parametrosLiberarPedidoEletronicoVO.CODIGO_USUARIO = args[1];
			parametrosLiberarPedidoEletronicoVO.CODIGO_EMPRESA_ELETRONICO = Convert.ToInt32(args[2]);
			parametrosLiberarPedidoEletronicoVO.NUMERO_PEDIDO_ELETRONICO = Convert.ToInt32(args[3]);
			parametrosLiberarPedidoEletronicoVO.NUMERO_SEQ_PEDIDO = Convert.ToInt32(args[4]);
		}
		else
		{
			parametrosLiberarPedidoEletronicoVO.NUMERO_PEDIDO_ELETRONICO = 1163624;
			parametrosLiberarPedidoEletronicoVO.CODIGO_EMPRESA_ELETRONICO = 1;
			parametrosLiberarPedidoEletronicoVO.NUMERO_SEQ_PEDIDO = 1;
			parametrosLiberarPedidoEletronicoVO.CODIGO_USUARIO = "SUPER";
			parametrosLiberarPedidoEletronicoVO.NOME_PROGRAMA = "Target Venda";
		}
		return parametrosLiberarPedidoEletronicoVO;
	}
}
