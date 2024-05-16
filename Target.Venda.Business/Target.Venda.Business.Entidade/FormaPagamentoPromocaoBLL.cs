using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Business.Entidade;

public class FormaPagamentoPromocaoBLL : EntidadeBaseBLL<FormaPagamentoPromocaoMO>
{
	protected override EntidadeBaseDAL<FormaPagamentoPromocaoMO> GetInstanceDAL()
	{
		return new FormaPagamentoPromocaoDAL();
	}

	public void ValidarFormaPagamentoPedido(PedidoVendaMO pedidoVenda)
	{
		MyException ex = new MyException();
		string formaPagamento = pedidoVenda.PEDIDO_ELETRONICO.FORMA_PAGAMENTO;
		if (string.IsNullOrEmpty(formaPagamento))
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Forma de Pagamento");
			ex.ThrowException();
		}
		if (pedidoVenda.TIPO_PEDIDO.VENDA_ESPECIAL.ToBool() && !ConfigERP.PAR_CFG.FORMPGTO_BANCO_TPED_VS && formaPagamento.Equals("DP") && pedidoVenda.TIPO_PEDIDO.GERA_TITULO_RECEBER.ToBool())
		{
			ex.AddErro("Forma de Pagamento: {0}, não permitida para {1}.", formaPagamento, "o Tipo de Pedido Venda Especial.");
		}
		if (!pedidoVenda.PROMOCAO.FORMAS_PAGAMENTO.Exists((FormaPagamentoPromocaoMO x) => x.FORMA_PAGAMENTO == formaPagamento))
		{
			ex.AddErro("Forma de Pagamento: {0}, não permitida para {1}.", formaPagamento, "a Condição de Pagamento");
		}
		if (ConfigERP.PAR_CFG.FORMA_PAGTO_ASSOC_CLIEN)
		{
			List<ClienteEmpresaFormaPagamentoMO> list = pedidoVenda.CLIENTE.FORMAS_PAGAMENTO.FindAll((ClienteEmpresaFormaPagamentoMO x) => x.CODIGO_EMRPESA == pedidoVenda.CODIGO_EMPRESA);
			bool flag = list.Exists((ClienteEmpresaFormaPagamentoMO x) => x.PRINCIPAL == BoolEnum.True);
			if (!(formaPagamento.Equals("DI") && flag) && !list.Exists((ClienteEmpresaFormaPagamentoMO x) => x.FORMA_PAGAMENTO == formaPagamento))
			{
				ex.AddErro("Forma de Pagamento: {0}, não permitida para {1}.", formaPagamento, "o Cliente");
			}
		}
		ex.ThrowException();
	}
}
