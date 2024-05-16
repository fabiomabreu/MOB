using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ContratoOperadoraCartaoCreditoBLL : EntidadeBaseBLL<ContratoOperadoraCartaoCreditoMO>
{
	protected override EntidadeBaseDAL<ContratoOperadoraCartaoCreditoMO> GetInstanceDAL()
	{
		return new ContratoOperadoraCartaoCreditoDAL();
	}

	public ContratoOperadoraCartaoCreditoMO ObterContratoOperadoraCartaoCredito(int? contratoID)
	{
		if (contratoID > 0)
		{
			return BaseDAL.ObterUnicoPeloExemplo(new ContratoOperadoraCartaoCreditoMO
			{
				CONTRATO_ID = contratoID.Value
			});
		}
		return null;
	}
}
