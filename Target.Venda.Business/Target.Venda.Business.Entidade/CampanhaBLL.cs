using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class CampanhaBLL : EntidadeBaseBLL<CampanhaMO>
{
	protected override EntidadeBaseDAL<CampanhaMO> GetInstanceDAL()
	{
		return new CampanhaDAL();
	}

	public int BuscaCampanhaAtiva(PedidoVendaMO pedidoVenda)
	{
		CampanhaDAL campanhaDAL = (CampanhaDAL)BaseDAL;
		return campanhaDAL.BuscaCampanhaAtiva(pedidoVenda);
	}

	public void InsereItPedvCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		CampanhaDAL campanhaDAL = (CampanhaDAL)BaseDAL;
		campanhaDAL.InsereItPedvCampanha(pedidoEletronico, pedidoVenda);
	}

	public void DeletaItPedvCampanha(PedidoEletronicoMO pedidoEletronico)
	{
		CampanhaDAL campanhaDAL = (CampanhaDAL)BaseDAL;
		campanhaDAL.DeletaItPedvCampanha(pedidoEletronico);
	}

	public void AplicaDescontosCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		int? num = (BaseDAL as CampanhaDAL).AplicaDescontosCampanha(pedidoEletronico, pedidoVenda);
		if (num != 0 && num == -100)
		{
			MyException ex = new MyException();
			ex.ThrowException();
		}
	}

	public void CampanhaItPedvDescontosGera(int cdEmp, int nuPed)
	{
		int? num = (BaseDAL as CampanhaDAL).CampanhaItPedvDescontosGera(cdEmp, nuPed);
		if (num != 0 && num == -100)
		{
			MyException ex = new MyException();
			ex.ThrowException();
		}
	}

	public DescontoCampanhaVO VerificarDescontoCampanhaItem(ItemPedidoMO item, PedidoEletronicoMO pedidoEletronico)
	{
		CampanhaDAL campanhaDAL = (CampanhaDAL)BaseDAL;
		return campanhaDAL.VerificarDescontoCampanhaItem(item, pedidoEletronico);
	}

	public void AtualizaItPedvCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		CampanhaDAL campanhaDAL = (CampanhaDAL)BaseDAL;
		campanhaDAL.AtualizaItPedvCampanha(pedidoEletronico, pedidoVenda);
	}
}
