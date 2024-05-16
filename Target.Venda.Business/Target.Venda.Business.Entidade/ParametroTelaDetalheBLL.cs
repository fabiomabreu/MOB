using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class ParametroTelaDetalheBLL : EntidadeBaseBLL<ParametroTelaDetalheMO>
{
	protected override EntidadeBaseDAL<ParametroTelaDetalheMO> GetInstanceDAL()
	{
		return new ParametroTelaDetalheDAL();
	}

	public List<ParametroTelaDetalheMO> ObterParametrosTelaAtivos()
	{
		return base.ObterPeloExemplo(new ParametroTelaDetalheMO
		{
			ATIVO = true
		});
	}

	public ConfiguracaoTelaVendaVO ObterParametroTelaVendas()
	{
		return (BaseDAL as ParametroTelaDetalheDAL).ObterParametroTelaVendas();
	}

	public ConfiguracaoTelaClienteVO ObterParametroTelaCliente()
	{
		return (BaseDAL as ParametroTelaDetalheDAL).ObterParametroTelaCliente();
	}

	public ConfiguracaoTelaEmissaoNotaVO ObterParametroTelaEmissaoNota()
	{
		return (BaseDAL as ParametroTelaDetalheDAL).ObterParametroTelaEmissaoNota();
	}

	public ConfiguracaoTelaTransferenciaEstoqueVO ObterParametroTelaTransferenciaEstoque()
	{
		return (BaseDAL as ParametroTelaDetalheDAL).ObterParametroTelaTransferenciaEstoque();
	}
}
