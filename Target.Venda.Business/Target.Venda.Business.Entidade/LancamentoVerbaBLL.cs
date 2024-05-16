using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class LancamentoVerbaBLL : EntidadeBaseBLL<LancamentoVerbaMO>
{
	protected override EntidadeBaseDAL<LancamentoVerbaMO> GetInstanceDAL()
	{
		return new LancamentoVerbaDAL();
	}

	public void InserirVerbaLancamento(PedidoVendaMO pedidoVenda, LancamentoVerbaMO lancamentoVerbaMO, UsuarioMO usuario)
	{
		(BaseDAL as LancamentoVerbaDAL).InserirVerbaLancamento(pedidoVenda, lancamentoVerbaMO, usuario);
	}

	public void EfetivaVerba(PedidoVendaMO pedidoVenda)
	{
		if (!pedidoVenda.TIPO_PEDIDO.GERA_VERBA)
		{
			return;
		}
		decimal? num = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_VERBA) + pedidoVenda.ITENS.Sum(delegate(ItemPedidoMO x)
		{
			decimal? pERCDESCCAMPANHA = x.PERCDESCCAMPANHA;
			return (((pERCDESCCAMPANHA.GetValueOrDefault() == default(decimal)) & pERCDESCCAMPANHA.HasValue) || !x.PERCDESCCAMPANHA.HasValue) ? x.VALOR_VERBA_FABRICANTE_ADIC : new decimal?(default(decimal));
		});
		if (ConfigERP.PAR_CFG.LANC_CRED_VERBA == "LQTR")
		{
			decimal? num2 = num;
			if ((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue)
			{
				return;
			}
		}
		if (ConfigERP.PAR_CFG.LANC_CRED_VERBA == "FTPD")
		{
			decimal? num2 = num;
			if ((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue)
			{
				return;
			}
		}
		EfetivarVerbaVendedor(pedidoVenda, num);
		EfetivaVerbaEmpresa(pedidoVenda, num);
		EfetivaVerbaEquipe(pedidoVenda, num);
	}

	private void EfetivaVerbaEquipe(PedidoVendaMO pedidoVenda, decimal? valorTotalVerba)
	{
		decimal? num = valorTotalVerba;
		if (!((num.GetValueOrDefault() > default(decimal)) & num.HasValue))
		{
			return;
		}
		decimal num2 = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_VERBA_EQUIPE.ToDecimal());
		if (num2 > 0m)
		{
			EquipeMO equipeMO = new EquipeMO();
			equipeMO = pedidoVenda.VENDEDOR.EQUIPE;
			LancamentoVerbaMO lancamentoVerbaMO = new LancamentoVerbaMO();
			lancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA = "LANPEDCR";
			lancamentoVerbaMO.CODIGO_VENDEDOR = (string.IsNullOrEmpty(equipeMO.CODIGO_VENDEDOR_SUPERVISOR) ? pedidoVenda.CODIGO_VENDEDOR : equipeMO.CODIGO_VENDEDOR_SUPERVISOR);
			lancamentoVerbaMO.TIPO_VERBA = "C";
			if (ConfigERP.PAR_CFG.VERBA_TP_LANC == "VE")
			{
				lancamentoVerbaMO.TIPO_VERBA = "V";
			}
			lancamentoVerbaMO.CODIGO_CLIENTE = pedidoVenda.CODIGO_CLIENTE;
			lancamentoVerbaMO.VALOR = num2;
			InserirVerbaLancamento(pedidoVenda, lancamentoVerbaMO, LoginERP.USUARIO_LOGADO);
		}
	}

	private void EfetivaVerbaEmpresa(PedidoVendaMO pedidoVenda, decimal? valorTotalVerba)
	{
		decimal? num = valorTotalVerba;
		if (!((num.GetValueOrDefault() > default(decimal)) & num.HasValue))
		{
			return;
		}
		decimal? num2 = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_VERBA_EMPRESA);
		num = num2;
		if ((num.GetValueOrDefault() > default(decimal)) & num.HasValue)
		{
			LancamentoVerbaMO lancamentoVerbaMO = new LancamentoVerbaMO();
			lancamentoVerbaMO.CODIGO_VENDEDOR = "VERBAE" + pedidoVenda.CODIGO_EMPRESA;
			lancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA = "LANPEDCR";
			lancamentoVerbaMO.CODIGO_CLIENTE = pedidoVenda.CODIGO_CLIENTE;
			lancamentoVerbaMO.TIPO_VERBA = "C";
			if (ConfigERP.PAR_CFG.VERBA_TP_LANC == "VE")
			{
				lancamentoVerbaMO.TIPO_VERBA = "V";
			}
			lancamentoVerbaMO.VALOR = num2.ToDecimal();
			LancamentoVerbaDAL lancamentoVerbaDAL = BaseDAL as LancamentoVerbaDAL;
			lancamentoVerbaDAL.InserirVerbaLancamento(pedidoVenda, lancamentoVerbaMO, LoginERP.USUARIO_LOGADO);
		}
	}

	private void EfetivarVerbaVendedor(PedidoVendaMO pedidoVenda, decimal? valorTotalVerba)
	{
		decimal? num = valorTotalVerba;
		if ((num.GetValueOrDefault() == default(decimal)) & num.HasValue)
		{
			return;
		}
		MotivoLancamentoVerbaMO motivoLancamentoVerbaMO = new MotivoLancamentoVerbaMO();
		motivoLancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA = "LANPEDDB";
		num = valorTotalVerba;
		if ((num.GetValueOrDefault() > default(decimal)) & num.HasValue)
		{
			motivoLancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA = "LANPEDCR";
		}
		LancamentoVerbaMO lancamentoVerbaMO = new LancamentoVerbaMO();
		lancamentoVerbaMO.CODIGO_VENDEDOR = pedidoVenda.CODIGO_VENDEDOR;
		decimal? num2 = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_VERBA_FABRICANTE_ADIC);
		num = valorTotalVerba;
		if ((num.GetValueOrDefault() > default(decimal)) & num.HasValue)
		{
			num = num2;
			if (((num.GetValueOrDefault() > default(decimal)) & num.HasValue) && ConfigERP.PAR_CFG.CRED_VERBA_FABR_NEG_IND == "EMP")
			{
				lancamentoVerbaMO.CODIGO_VENDEDOR = "VERBAE" + pedidoVenda.CODIGO_EMPRESA;
			}
		}
		lancamentoVerbaMO.TIPO_VERBA = "C";
		if (ConfigERP.PAR_CFG.VERBA_TP_LANC == "VE")
		{
			lancamentoVerbaMO.TIPO_VERBA = "V";
		}
		lancamentoVerbaMO.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		lancamentoVerbaMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		lancamentoVerbaMO.VALOR = valorTotalVerba.ToDecimal();
		lancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA = motivoLancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA;
		LancamentoVerbaDAL lancamentoVerbaDAL = BaseDAL as LancamentoVerbaDAL;
		lancamentoVerbaDAL.InserirVerbaLancamento(pedidoVenda, lancamentoVerbaMO, LoginERP.USUARIO_LOGADO);
	}

	public void CancelarVerba(PedidoVendaMO pedidoVenda)
	{
		(BaseDAL as LancamentoVerbaDAL).CancelarVerba(pedidoVenda, LoginERP.USUARIO_LOGADO);
	}
}
