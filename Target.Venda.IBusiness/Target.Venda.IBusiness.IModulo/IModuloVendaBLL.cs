using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloVendaBLL : IModuloBaseBLL
{
	void ValidarParametroLiberarPedido(ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle);

	PedidoEletronicoMO CarregarPedidoEletronico(ParametrosLiberarPedidoEletronicoVO liberarPedidoEle);

	void AtualizarPedidoEletronico(PedidoVendaMO pedidoVenda);

	void CortarItensPedidoEletronico(PedidoVendaMO pedidoVenda);

	void ValidarItensPedidoEletronico(PedidoVendaMO pedidoVenda);

	PedidoVendaMO MontarPedidoVendaPeloPedidoEletronico(PedidoEletronicoMO pedidoEletronico);

	void CarregarItensPedido(PedidoVendaMO pedidoVenda);

	void CarregarDataPedido(PedidoVendaMO pedidoVenda);

	bool ValidarUtilizaNumeroPedidoSemLock();

	void GerarNumeroPedido(PedidoVendaMO pedidoVenda, bool gerarNumeroPedidoSemLock);

	void CancelarPedido(PedidoVendaMO pedidoVenda);

	void SalvarPedidoVenda(PedidoVendaMO pedidoVenda);

	void SalvarProdutosPapelCortado(PedidoVendaMO pedidoVenda);

	void GerarEventoCadastroPedido(PedidoVendaMO pedidoVenda);

	void LiberarPedidoERP(PedidoVendaMO pedidoVenda);

	void VerificarPedidoSemItens(PedidoVendaMO pedidoVenda);

	void ValidarParametroCancelarPedido(ParametrosCancelarPedidoVO parametroCancelarPedidoVenda);

	PedidoVendaMO ObterPedidoVendaPeloID(int codigoEmpresa, int numeroPedido);

	void ValidarTipoPedido(PedidoVendaMO pedidoVenda);

	void ValidarMontagemPedidoVenda(PedidoVendaMO pedidoVenda);

	void ValidarLimiteDeVendasPFxPJ(PedidoVendaMO pedidoVenda);

	void VerificaIntermediador(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronicoMO);

	void GaranteConsistenciaItensDesconto(PedidoVendaMO pedidoVenda);

	void TratamentoLABebidasOC809337(PedidoVendaMO pedidoVenda);
}
