using System;

namespace Target.Mob.Desktop.Api.Model;

public class EstatisticaResumoGeralTO
{
	public DateTime DataUltimaAtualizacao { get; set; }

	public int DuracaoUltimaAtualizacaoEmSegundos { get; set; }

	public int MaiorDuracaoDoDiaEmSegundos { get; set; }

	public int MenorDuracaoDoDiaEmSegundos { get; set; }

	public int MediaDuracaoDoDiaEmSegundos { get; set; }

	public int QtdeDeAtualizacoesNoDia { get; set; }

	public DateTime DataAtual { get; set; }

	public string VersaoRetaguardaUltimaAtualizacao { get; set; }
}
