using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class PromocaoParcelasBLL : EntidadeBaseBLL<PromocaoParcelasMO>
{
	protected override EntidadeBaseDAL<PromocaoParcelasMO> GetInstanceDAL()
	{
		return new PromocaoParcelasDAL();
	}

	public List<PromocaoParcelasMO> ObterPromocaoParcelaPelaSeqPromocao(int seqPromocao)
	{
		return (BaseDAL as PromocaoParcelasDAL).ObterPeloExemplo(new PromocaoParcelasMO
		{
			SEQ_PROMOCAO = seqPromocao
		});
	}
}
