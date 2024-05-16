using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class AcaoComercialProdutoPrecoBLL : EntidadeBaseBLL<AcaoComercialProdutoPrecoMO>
{
	protected override EntidadeBaseDAL<AcaoComercialProdutoPrecoMO> GetInstanceDAL()
	{
		return new AcaoComercialProdutoPrecoDAL();
	}

	public List<string> ObterTabelasAcaoComercialProduto(AcaoComercialEncerradaVO acaoComercial)
	{
		return (BaseDAL as AcaoComercialProdutoPrecoDAL).ObterTabelasAcaoComercialProduto(acaoComercial);
	}

	public AcaoComercialProdutoPrecoVO ObterAcaoComercialProdutoPrecoPelaTabela(AcaoComercialEncerradaVO acaoComercial, string codigoTabela)
	{
		return (BaseDAL as AcaoComercialProdutoPrecoDAL).ObterAcaoComercialProdutoPrecoPelaTabela(acaoComercial, codigoTabela);
	}
}
