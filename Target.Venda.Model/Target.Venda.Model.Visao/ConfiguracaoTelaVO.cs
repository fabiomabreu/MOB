namespace Target.Venda.Model.Visao;

public class ConfiguracaoTelaVO
{
	public ConfiguracaoTelaVendaVO VENDA { get; set; }

	public ConfiguracaoTelaClienteVO CLIENTE { get; set; }

	public ConfiguracaoTelaEmissaoNotaVO EMISSAO_NOTA_FISCAL { get; set; }

	public ConfiguracaoTelaTransferenciaEstoqueVO TRANSFERENCIA_ESTOQUE { get; set; }
}
