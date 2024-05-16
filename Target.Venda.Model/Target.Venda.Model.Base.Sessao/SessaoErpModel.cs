using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Model.Base.Sessao;

public class SessaoErpModel : SessaoBase
{
	public UsuarioMO USUARIO { get; set; }

	public EmpresaMO EMPRESA { get; set; }

	public ConfiguracaoVO PAR_CFG { get; set; }

	public ConfiguracaoTelaVO PARAMETROS_TELA { get; set; }

	public string PROGRAMA_ORIGEM { get; set; }

	public SessaoDbTempMO SESSAO_DB_TEMP { get; set; }

	public TargetServicosMO TargetServicos { get; set; }
}
