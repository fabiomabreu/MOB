using System.Collections.Generic;

namespace Target.Venda.Model.Visao;

public class ResultadoLiberarPedidoErpVO
{
	public bool OCORREU_ERRO
	{
		get
		{
			List<int> list = new List<int>();
			list.Add(-100);
			list.Add(-200);
			list.Add(-300);
			return list.Exists((int x) => x == CODIGO_ERRO);
		}
	}

	public bool CONTEM_DADOS => DADOS_RETORNO != null && !string.IsNullOrEmpty(DADOS_RETORNO.NOME_TABELA_TEMP);

	public int CODIGO_ERRO { get; set; }

	public DadosRetornoLiberacaoPedidoVO DADOS_RETORNO { get; set; }

	public List<ErroErpVO> ERROS { get; set; }
}
