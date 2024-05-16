using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.EntityMapping;

public class PedidoVendaMap : BaseMap<PedidoVendaMO>
{
	public PedidoVendaMap()
	{
		if (VersaoDAL.ReleaseAtualMaiorMinima())
		{
			Property((PedidoVendaMO x) => x.DESCRICAO_VAN).HasColumnName("DescricaoVan");
		}
		else
		{
			Ignore((PedidoVendaMO x) => x.DESCRICAO_VAN);
		}
		if (VersaoDAL.VERSAO_ERP_ATUAL.MAJOR > 11 || VersaoDAL.VERSAO_ERP_ATUAL.MINOR > 2 || VersaoDAL.VERSAO_ERP_ATUAL.BUILD >= 14)
		{
			Property((PedidoVendaMO x) => x.SEQ_TRIB_REG_EMP).HasColumnName("SeqTribRegEmp");
		}
		else
		{
			Ignore((PedidoVendaMO x) => x.SEQ_TRIB_REG_EMP);
		}
	}
}
