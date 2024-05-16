using System.Collections.Generic;
using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloEstoqueBLL : IModuloBaseBLL
{
	void GerarItensLocaisEstoquePedido(PedidoVendaMO pedidoVenda);

	void TratarUnidadeProduto(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda);

	void TratarMaiorUnidadeVariavelProduto(PedidoVendaMO pedidoVenda);

	void ValidarUnidade(PedidoVendaMO pedidoVenda);

	void ValidarPapelCortado(PedidoVendaMO pedidoVenda);

	void TratarQuantidadeItemPedido(PedidoVendaMO pedidoVenda);

	void ValidarQuantidadeItensPedido(PedidoVendaMO pedidoVenda);

	void ValidarQuantidadeLoteAutomatico(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico);

	void GerarItPedvLogReservarLote(PedidoVendaMO pedidoVenda, bool VsControl746221);

	void EfetivarReservaEstoque(PedidoVendaMO pedidoVenda);

	void RegistrarReservaEstoque(PedidoVendaMO pedidoVenda);

	void CarregarFaltasProdutos(PedidoVendaMO pedidoVenda);

	void RegistrarFaltasEstoque(PedidoVendaMO pedidoVenda, List<ItemPedidoMO> itens);

	void AtualizarHorarioReservaEstoque();
}
