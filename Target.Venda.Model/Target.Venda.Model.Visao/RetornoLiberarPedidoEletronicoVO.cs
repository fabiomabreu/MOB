using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;

namespace Target.Venda.Model.Visao;

public class RetornoLiberarPedidoEletronicoVO
{
	public ResultadoProcessoEnum RESULTADO_PROCESSO { get; set; }

	public ParametrosLiberarPedidoEletronicoVO PARAMETRO_LIBERACAO { get; set; }

	public string MENSAGEM_VALIDACAO { get; set; }

	public string LOG_PROCESSO { get; set; }

	public PedidoVendaMO PEDIDO_VENDA { get; set; }

	public PedidoEletronicoMO PEDIDO_ELETRONICO { get; set; }
}
