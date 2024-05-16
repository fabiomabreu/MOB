using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Helpers;

public static class ConfigERP
{
	public static string VERSAO_ERP { get; set; }

	public static ConfiguracaoVO PAR_CFG
	{
		get
		{
			return SessaoErpManager.CURRENT.PAR_CFG;
		}
		set
		{
			SessaoErpManager.CURRENT.PAR_CFG = value;
		}
	}

	public static ConfiguracaoTelaVO PARAMETROS_TELA
	{
		get
		{
			return SessaoErpManager.CURRENT.PARAMETROS_TELA;
		}
		set
		{
			SessaoErpManager.CURRENT.PARAMETROS_TELA = value;
		}
	}
}
