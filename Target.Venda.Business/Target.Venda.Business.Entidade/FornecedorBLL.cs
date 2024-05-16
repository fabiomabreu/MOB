using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class FornecedorBLL : EntidadeBaseBLL<FornecedorMO>
{
	protected override EntidadeBaseDAL<FornecedorMO> GetInstanceDAL()
	{
		return new FornecedorDAL();
	}

	public FornecedorMO ObterFornecedorPeloCodigo(int? codigoFornecedor)
	{
		if (!codigoFornecedor.HasValue)
		{
			return null;
		}
		FornecedorMO exampleInstance = new FornecedorMO
		{
			CODIGO_FORNECEDOR = codigoFornecedor.Value
		};
		return ObterUnicoPeloExemplo(exampleInstance, "ENDERECOS");
	}
}
