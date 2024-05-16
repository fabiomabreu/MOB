namespace Target.Venda.Model.Visao;

public class ConfiguracaoTelaTransferenciaEstoqueVO
{
	public bool REALIZA_TRANSFERENCIA_APOS_FATURAMENTO { get; set; }

	public bool PERMITE_TRANSF_ESPECIAL_PARA_VENDAS_NORMAIS_E_VICE_VERSA { get; set; }

	public bool MANTEM_PRODUTOS_COM_A_UNIDADE_DIGITADA_NO_PEDIDO_DE_VENDA { get; set; }
}
