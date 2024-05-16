using System.Collections.Generic;

namespace Target.Venda.Model.Visao;

public class ParcelaPrazoDiferenciadoVO
{
	public decimal VALOR_TOTAL_PRAZO_PADRAO { get; set; }

	public decimal VALOR_TOTAL_PRAZO_DIFERENCIADO { get; set; }

	public List<ParcelaPrazoDiferenciadoItemVO> VALORES { get; set; }
}
