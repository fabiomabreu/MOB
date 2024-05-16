using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class SessaoDbTempBLL : EntidadeBaseBLL<SessaoDbTempMO>
{
	protected override EntidadeBaseDAL<SessaoDbTempMO> GetInstanceDAL()
	{
		return new SessaoDbTempDAL();
	}

	public SessaoDbTempMO GerarSessaoDbTemp(UsuarioMO usuario)
	{
		SessaoDbTempMO sessaoDbTempMO = new SessaoDbTempMO();
		sessaoDbTempMO.CODIGO_USUARIO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
		sessaoDbTempMO.DATA_CRIACAO = SessaoErpManager.CURRENT.DATA_CRIACAO_SESSAO;
		SessaoDbTempDAL sessaoDbTempDAL = BaseDAL as SessaoDbTempDAL;
		int num = sessaoDbTempDAL.GerarSequencial("seq_tbl_temp_pedv");
		sessaoDbTempMO.NOME_TABELA_TEMPORARIA = $"##{ConfigHelper.getNomeBancoDados()}_pedv_{num}";
		sessaoDbTempDAL.CriarTabelaTemporaria(sessaoDbTempMO.NOME_TABELA_TEMPORARIA);
		InserirDados(sessaoDbTempMO);
		return sessaoDbTempMO;
	}

	private void InserirDados(SessaoDbTempMO sessaoPedido)
	{
		(BaseDAL as SessaoDbTempDAL).InserirDados(sessaoPedido.NOME_TABELA_TEMPORARIA, sessaoPedido.CODIGO_USUARIO, sessaoPedido.DATA_CRIACAO);
	}

	public SessaoDbTempMO ObterSessaoPedido(string nomeTabelaTemporaria)
	{
		return (BaseDAL as SessaoDbTempDAL).ObterSessaoPedidoPeloNomeTabelaTemp(nomeTabelaTemporaria);
	}

	public void EncerrarSessaoDbTemp(SessaoDbTempMO sessaoDbTemp)
	{
		(BaseDAL as SessaoDbTempDAL).EncerrarSessaoDbTemp(sessaoDbTemp);
	}
}
