using Target.Venda.Model.Enum;

namespace Target.Venda.Model.Visao;

public class RetornoCancelarPedidoVendaVO
{
	public ResultadoProcessoEnum RESULTADO_PROCESSO { get; set; }

	public string MENSAGEM_VALIDACAO { get; set; }

	public string LOG_PROCESSO { get; set; }
}
