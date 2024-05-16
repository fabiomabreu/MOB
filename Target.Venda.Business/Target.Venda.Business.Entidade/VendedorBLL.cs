using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class VendedorBLL : EntidadeBaseBLL<VendedorMO>
{
	protected override EntidadeBaseDAL<VendedorMO> GetInstanceDAL()
	{
		return new VendedorDAL();
	}

	public VendedorMO ObterVendedorParaPedidoVenda(string codigoVendedor)
	{
		VendedorMO exampleInstance = new VendedorMO
		{
			CODIGO_VENDEDOR = codigoVendedor
		};
		return ObterUnicoPeloExemplo(exampleInstance, "EQUIPE");
	}
}
