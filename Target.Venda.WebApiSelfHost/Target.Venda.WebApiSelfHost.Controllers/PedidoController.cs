using System;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Target.Venda.IBusiness.Factory;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;
using Target.Venda.WebApiSelfHost.Models;

namespace Target.Venda.WebApiSelfHost.Controllers;

public class PedidoController : ApiController
{
	[HttpPost]
	[Route("api/Pedido/Liberar")]
	public RetornoLiberacaoPedidoModel LiberarPedido([FromBody] JObject jsonRequest)
	{
		RetornoLiberacaoPedidoModel retornoLiberacaoPedidoModel = new RetornoLiberacaoPedidoModel();
		try
		{
			ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle = JsonConvert.DeserializeObject<ParametrosLiberarPedidoEletronicoVO>(jsonRequest.ToString());
			ILiberarPedidoEletronicoBLL liberarPedidoEletronicoBLL = BusinessFactory.GetLiberarPedidoEletronicoBLL();
			RetornoLiberarPedidoEletronicoVO retornoLiberarPedidoEletronicoVO = liberarPedidoEletronicoBLL.Executar(parametroLiberarPedidoEle);
			retornoLiberacaoPedidoModel.RESULTADO_PROCESSO = (int)retornoLiberarPedidoEletronicoVO.RESULTADO_PROCESSO;
			retornoLiberacaoPedidoModel.MENSAGEM_VALIDACAO = retornoLiberarPedidoEletronicoVO.MENSAGEM_VALIDACAO;
			if (retornoLiberarPedidoEletronicoVO.RESULTADO_PROCESSO == ResultadoProcessoEnum.SUCESSO)
			{
				retornoLiberacaoPedidoModel.LOG_PROCESSO = "Pedido de venda: " + retornoLiberarPedidoEletronicoVO.PEDIDO_VENDA.NUMERO_PEDIDO + " \r\n Resultado: " + retornoLiberarPedidoEletronicoVO.RESULTADO_PROCESSO.ToString() + " \r\n Erro: NULL \r\n Horario: " + DateTime.Now.ToString();
			}
			else
			{
				retornoLiberacaoPedidoModel.LOG_PROCESSO = "Pedido de venda: NULL \r\n Resultado: " + retornoLiberarPedidoEletronicoVO.RESULTADO_PROCESSO.ToString() + " \r\n " + retornoLiberarPedidoEletronicoVO.MENSAGEM_VALIDACAO + " \r\n Horário: " + DateTime.Now.ToString();
			}
		}
		catch (Exception ex)
		{
			retornoLiberacaoPedidoModel.RESULTADO_PROCESSO = 2;
			retornoLiberacaoPedidoModel.MENSAGEM_VALIDACAO = ex.Message;
		}
		return retornoLiberacaoPedidoModel;
	}

	[HttpPost]
	[Route("api/Pedido/Cancelar")]
	public RetornoCancelamentoPedidoModel CancelarPedido([FromBody] JObject jsonRequest)
	{
		RetornoCancelamentoPedidoModel retornoCancelamentoPedidoModel = new RetornoCancelamentoPedidoModel();
		try
		{
			ParametrosCancelarPedidoVO parametroCancelarPedidoVenda = JsonConvert.DeserializeObject<ParametrosCancelarPedidoVO>(jsonRequest.ToString());
			ICancelarPedidoVendaBLL cancelarPedidoVendaBLL = BusinessFactory.GetCancelarPedidoVendaBLL();
			RetornoCancelarPedidoVendaVO retornoCancelarPedidoVendaVO = cancelarPedidoVendaBLL.Executar(parametroCancelarPedidoVenda);
			retornoCancelamentoPedidoModel.RESULTADO_PROCESSO = (int)retornoCancelarPedidoVendaVO.RESULTADO_PROCESSO;
			retornoCancelamentoPedidoModel.MENSAGEM_VALIDACAO = retornoCancelarPedidoVendaVO.MENSAGEM_VALIDACAO;
			if (retornoCancelarPedidoVendaVO.RESULTADO_PROCESSO == ResultadoProcessoEnum.SUCESSO)
			{
				retornoCancelamentoPedidoModel.LOG_PROCESSO = "Resultado: " + retornoCancelarPedidoVendaVO.RESULTADO_PROCESSO.ToString() + " \r\n Erro: NULL \r\n Horario: " + DateTime.Now.ToString();
			}
			else
			{
				retornoCancelamentoPedidoModel.LOG_PROCESSO = "Resultado: " + retornoCancelarPedidoVendaVO.RESULTADO_PROCESSO.ToString() + " \r\n " + retornoCancelarPedidoVendaVO.MENSAGEM_VALIDACAO + " \r\n Horário: " + DateTime.Now.ToString();
			}
		}
		catch (Exception ex)
		{
			retornoCancelamentoPedidoModel.RESULTADO_PROCESSO = 2;
			retornoCancelamentoPedidoModel.MENSAGEM_VALIDACAO = ex.Message;
		}
		return retornoCancelamentoPedidoModel;
	}
}
