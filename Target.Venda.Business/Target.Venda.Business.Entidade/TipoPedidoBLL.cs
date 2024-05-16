using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class TipoPedidoBLL : EntidadeBaseBLL<TipoPedidoMO>
{
	protected override EntidadeBaseDAL<TipoPedidoMO> GetInstanceDAL()
	{
		return new TipoPedidoDAL();
	}

	public TipoPedidoVO ObterTipoPedidoPeloCodigo(string codigoTipoPedido)
	{
		return (BaseDAL as TipoPedidoDAL).ObterTipoPedidoPeloCodigo(codigoTipoPedido);
	}

	public void ValidarIcmsDiferido(TipoPedidoVO tipoPedido, bool icmsDiferido)
	{
		if (!icmsDiferido && tipoPedido.ICMS_DIFERIDO.ToBool())
		{
			throw new MyException("Tipo de Pedido com ICMS difererido");
		}
	}

	public void CarregarIcmsDiferidoNoPedido(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda.TIPO_PEDIDO.ICMS_DIFERIDO)
		{
			pedidoVenda.ICMS_DIFERIDO = BoolEnum.True;
		}
		else
		{
			pedidoVenda.ICMS_DIFERIDO = BoolEnum.False;
		}
	}

	public bool VerificarTipoPedidoRegistraFaltaProdutos(TipoPedidoVO tipoPedido)
	{
		bool result = false;
		bool flag = tipoPedido.ATUALIZA_ESTOQUE || tipoPedido.ATUALIZA_ESTOQUE_CTB;
		bool flag2 = tipoPedido.TRANSFERENCIA_ESTOQUE && tipoPedido.TRANSFERENCIA_OUTROS_LOCAIS_ESTOQUE;
		if (flag && !flag2 && !tipoPedido.INVENTARIO)
		{
			result = true;
		}
		return result;
	}
}
