using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class FreteBLL : EntidadeBaseBLL<FreteMO>
{
	protected override EntidadeBaseDAL<FreteMO> GetInstanceDAL()
	{
		return new FreteDAL();
	}

	public FreteVO ObterConfiguracaoFrete(PedidoVendaMO pedidoVenda)
	{
		int cEP = pedidoVenda.ENDERECOS.Find((EnderecoPedidoMO x) => x.TIPO_ENDERECO == "EN").CEP;
		return (BaseDAL as FreteDAL).ObterConfiguracaoFretePeloCep(pedidoVenda.CODIGO_FORNECEDOR.ToInt(), cEP);
	}

	public decimal ObterValorFretePeloFatorValor(FreteVO configFrete, decimal valorTotal)
	{
		decimal? num = (BaseDAL as FreteDAL).ObterValorFretePeloFatorValor(configFrete.SEQ_FRETE, valorTotal);
		if (!num.HasValue)
		{
			MyException ex = new MyException("Não existe frete cadastrado nessa faixa de valor.");
			ex.ThrowException();
		}
		return num.ToDecimal();
	}

	public decimal ObterValorFretePeloFatorPeso(FreteVO configFrete, decimal pesoTotal)
	{
		decimal? num = (BaseDAL as FreteDAL).ObterValorFretePeloFatorPeso(configFrete.SEQ_FRETE, pesoTotal);
		if (!num.HasValue)
		{
			MyException ex = new MyException("Não existe frete cadastrado nessa faixa de CEP para essa transportadora na Faixa de Peso informada.");
			ex.ThrowException();
		}
		return num.ToDecimal();
	}
}
