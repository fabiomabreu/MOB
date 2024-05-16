using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class OrigemPedidoVendaBLL : EntidadeBaseBLL<OrigemPedidoVendaMO>
{
	protected override EntidadeBaseDAL<OrigemPedidoVendaMO> GetInstanceDAL()
	{
		return new OrigemPedidoVendaDAL();
	}

	public List<OrigemPedidoVendaVO> ObterOrigemPedidoVendaLista()
	{
		return (BaseDAL as OrigemPedidoVendaDAL).ObterOrigemPedidoVendaLista();
	}
}
