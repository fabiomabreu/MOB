using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Modulo;

public class ModuloContabilBLL : ModuloBaseBLL, IModuloContabilBLL, IModuloBaseBLL
{
	public void ValidarParametrosMargemBruta()
	{
		MyException ex = new MyException();
		ConfiguracaoTelaVendaVO vENDA = ConfigERP.PARAMETROS_TELA.VENDA;
		int num = 0;
		if (vENDA.EXIBIR_COLUNA_PERC_MG_BRUTA_REPOSICAO)
		{
			num++;
		}
		if (vENDA.EXIBIR_COLUNA_PERC_MG_BRUTA_ULT_ENTR)
		{
			num++;
		}
		if (vENDA.EXIBIR_COLUNA_PERC_MG_BRUTA_MED_POND)
		{
			num++;
		}
		int num2 = 0;
		if (vENDA.EXIBIR_COLUNA_VALOR_MG_BRUTA_REPOSICAO)
		{
			num2++;
		}
		if (vENDA.EXIBIR_COLUNA_VALOR_MG_BRUTA_ULT_ENTR)
		{
			num2++;
		}
		if (vENDA.EXIBIR_COLUNA_VALOR_MG_BRUTA_MED_POND)
		{
			num2++;
		}
		if (num > 1 || num2 > 1)
		{
			ex.AddErro("Parâmetros de exibição de margem cadastrados de maneira inválida. Solicite a alteração da configuração do sistema.");
		}
		ex.ThrowException();
	}
}
