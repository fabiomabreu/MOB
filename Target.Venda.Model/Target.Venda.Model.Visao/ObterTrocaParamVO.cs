namespace Target.Venda.Model.Visao;

public class ObterTrocaParamVO
{
	public int CODIGO_EMPRESA { get; set; }

	public int CODIGO_CLIENTE { get; set; }

	public string CODIGO_VENDEDOR { get; set; }

	public bool ASSOCIA_TROCA_SOMENTE_AO_MESMO_VENDEDOR_E_CLIENTE { get; set; }
}
