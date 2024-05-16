using System;

namespace Target.Venda.Model.Visao;

public class AlterarVigenciaVO
{
	public DateTime? DATA_INICIO { get; set; }

	public DateTime? DATA_FIM { get; set; }

	public int SEQ_ACAO_COMERCIAL { get; set; }

	public int SEQ_KIT { get; set; }
}
