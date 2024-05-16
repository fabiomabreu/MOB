using System;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class RegiaoBLL : EntidadeBaseBLL<RegiaoMO>
{
	protected override EntidadeBaseDAL<RegiaoMO> GetInstanceDAL()
	{
		return new RegiaoDAL();
	}

	public FreteVO ObterConfiguracaoFreteRegiao(PedidoVendaMO pedidoVenda)
	{
		string text = pedidoVenda.ENDERECOS.Find((EnderecoPedidoMO x) => x.TIPO_ENDERECO == "EN").CEP.ToString().PadLeft(8, '0');
		int num = Convert.ToInt32(text.Substring(0, ConfigERP.PAR_CFG.QTDE_DEF_REGIAO));
		RegiaoBLL regiaoBLL = new RegiaoBLL();
		RegiaoMO regiaoMO = regiaoBLL.ObterPeloID(num);
		if (regiaoMO == null || !regiaoMO.ATIVO)
		{
			return null;
		}
		FreteVO freteVO = new FreteVO();
		freteVO.ISENCAO_VALOR_MINIMO_PEDIDO = regiaoMO.VALOR_VENDA_MINIMA.ToDecimal();
		freteVO.ISENCAO = regiaoMO.ISENCAO.ToBool();
		freteVO.TIPO_COBRANCA_FRETE = regiaoMO.TIPO_COBRANCA_FRETE;
		freteVO.PERCENTUAL_FRETE = regiaoMO.PERCENTUAL_FRETE.ToDecimal();
		freteVO.VALOR_FRETE_UNIDADE = regiaoMO.VALOR_FRETE_UNIDADE.ToDecimal();
		freteVO.VALOR_TAXA_FIXA = regiaoMO.VALOR_TAXA_FIXA.ToDecimal();
		freteVO.VALOR_FRETE_MINIMO = regiaoMO.VALOR_FRETE_MINIMO.ToDecimal();
		freteVO.CALCULAR_FRETE_CIF = regiaoMO.CALCULO_FRETE_CIF.ToBool();
		freteVO.CALCULAR_FRETE_FOB = regiaoMO.CALCULO_FRETE_FOB.ToBool();
		freteVO.CALCULO_FRETE_APARTIR = regiaoMO.CALCULO_FRETE_APARTIR.ToDecimal();
		return freteVO;
	}
}
