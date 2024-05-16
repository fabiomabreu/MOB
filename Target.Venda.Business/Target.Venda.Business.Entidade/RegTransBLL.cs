using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class RegTransBLL : EntidadeBaseBLL<RegTransMO>
{
	protected override EntidadeBaseDAL<RegTransMO> GetInstanceDAL()
	{
		return new RegTransDAL();
	}

	public RegTransMO ObterRegTransPeloCep(int codigoFornecedor, int cep)
	{
		return (BaseDAL as RegTransDAL).ObterRegTransPeloCep(codigoFornecedor, cep);
	}

	public FreteVO ObterConfiguracaoFreteRegTrans(PedidoVendaMO pedidoVenda)
	{
		int cEP = pedidoVenda.ENDERECOS.Find((EnderecoPedidoMO x) => x.TIPO_ENDERECO == "EN").CEP;
		RegTransBLL regTransBLL = new RegTransBLL();
		RegTransMO regTransMO = regTransBLL.ObterRegTransPeloCep(pedidoVenda.CODIGO_FORNECEDOR.ToInt(), cEP);
		if (regTransMO == null)
		{
			return null;
		}
		FreteVO freteVO = new FreteVO();
		freteVO.ISENCAO_VALOR_MINIMO_PEDIDO = regTransMO.VALOR_VENDA_MINIMO;
		freteVO.ISENCAO = regTransMO.ISENCAO.ToBool();
		freteVO.TIPO_COBRANCA_FRETE = regTransMO.TIPO_COBRANCA_FRETE;
		freteVO.PERCENTUAL_FRETE = regTransMO.PERCENTUAL_FRETE.ToDecimal();
		freteVO.VALOR_FRETE_UNIDADE = regTransMO.VALOR_FRETE_UNIDADE.ToDecimal();
		freteVO.VALOR_TAXA_FIXA = regTransMO.VALOR_TAXA_FIXA.ToDecimal();
		freteVO.VALOR_FRETE_MINIMO = regTransMO.VALOR_FRETE_MINIMO.ToDecimal();
		freteVO.CALCULAR_FRETE_CIF = regTransMO.CALCULO_FRETE_CIF.ToBool();
		freteVO.CALCULAR_FRETE_FOB = regTransMO.CALCULO_FRETE_FOB.ToBool();
		freteVO.SEQ_FRETE = regTransMO.SEQ_FRETE;
		freteVO.SEQ_REG = regTransMO.SEQ_REG;
		return freteVO;
	}

	public decimal ObterValorFretePeloRegTransPeso(FreteVO configFrete, PedidoVendaMO pedidoVenda, decimal pesoTotal)
	{
		decimal? num = (BaseDAL as RegTransDAL).ObterValorFretePeloRegTransPeso(configFrete.SEQ_REG, pedidoVenda.CODIGO_FORNECEDOR.ToInt(), pesoTotal);
		if (!num.HasValue)
		{
			MyException ex = new MyException("Não existe valor de frete cadastrado para a transportadora no cep e peso desejado.");
			ex.ThrowException();
		}
		return num.ToDecimal();
	}
}
