using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class TargetERPSoapClient : ClientBase<TargetERPSoap>, TargetERPSoap
{
	public TargetERPSoapClient()
	{
	}

	public TargetERPSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public TargetERPSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public TargetERPSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public TargetERPSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public bool EnviarQuantidadeLicencasMatriz(EnviarQuantidadeLicencasMatrizTO[] parametro, string token)
	{
		return base.Channel.EnviarQuantidadeLicencasMatriz(parametro, token);
	}

	public RetornoWsTOOfBoolean EnviarDadosProdutoPainel(ValidationRequestTO VALIDACAO_REQUEST, EnviarProdutoPainelTO parametro)
	{
		return base.Channel.EnviarDadosProdutoPainel(VALIDACAO_REQUEST, parametro);
	}

	public RetornoWsTOOfBoolean ReplicacaoSet(ValidationRequestTO VALIDACAO, string tabela, string versao, string dadosReplicacao)
	{
		return base.Channel.ReplicacaoSet(VALIDACAO, tabela, versao, dadosReplicacao);
	}

	public RetornoWsTOOfString ReplicacaoGet(ValidationRequestTO VALIDACAO, string tabela, string rowId)
	{
		return base.Channel.ReplicacaoGet(VALIDACAO, tabela, rowId);
	}

	public RetornoWsTOOfString ReplicacaoVerificarDadosExistentes(ValidationRequestTO VALIDACAO, string tabela, string rowId)
	{
		return base.Channel.ReplicacaoVerificarDadosExistentes(VALIDACAO, tabela, rowId);
	}

	public RetornoWsTOOfString GerarLogErro(ValidationRequestTO VALIDACAO, string tabela, string descricao_erro)
	{
		return base.Channel.GerarLogErro(VALIDACAO, tabela, descricao_erro);
	}

	public RetornoWsTOOfBoolean ReplicacaoHorarioPermitido(ValidationRequestTO VALIDACAO)
	{
		return base.Channel.ReplicacaoHorarioPermitido(VALIDACAO);
	}

	public RetornoWsTOOfProdutoVersaoTO VerificaVersaoLiberadaRetaguarda(ValidationRequestTO VALIDACAO, VersaoTO VERSAO_ATUAL, VersaoTO VERSAO_ULTIMO_DOWNLOAD)
	{
		return base.Channel.VerificaVersaoLiberadaRetaguarda(VALIDACAO, VERSAO_ATUAL, VERSAO_ULTIMO_DOWNLOAD);
	}

	public RetornoWsTOOfProdutoVersaoTO DownloadVersaoRetaguarda(ValidationRequestTO VALIDACAO, VersaoTO VERSAO_PARA_DOWNLOAD, VersaoTO VERSAO_ULTIMO_DOWNLOAD)
	{
		return base.Channel.DownloadVersaoRetaguarda(VALIDACAO, VERSAO_PARA_DOWNLOAD, VERSAO_ULTIMO_DOWNLOAD);
	}

	public RetornoWsTOOfBoolean VerificaAtualizacaoAutomatica(ValidationRequestTO VALIDACAO, VersaoTO VERSAO_ULTIMO_DOWNLOAD)
	{
		return base.Channel.VerificaAtualizacaoAutomatica(VALIDACAO, VERSAO_ULTIMO_DOWNLOAD);
	}

	public RetornoWsTOOfBoolean AtualizarStatusProdutoPainel(ValidationRequestTO VALIDACAO, StatusInstalacao STATUS, ProcessoAtualizacaoTO PROCESSO_ATUALIZACAO)
	{
		return base.Channel.AtualizarStatusProdutoPainel(VALIDACAO, STATUS, PROCESSO_ATUALIZACAO);
	}

	public RetornoWsTOOfString GetMaxRowid(ValidationRequestTO VALIDACAO, string tabela)
	{
		return base.Channel.GetMaxRowid(VALIDACAO, tabela);
	}

	public RetornoWsTOOfString SetListaIndicadores(ValidationRequestTO VALIDACAO, TGTIndicadorMesAnoTO[] indicadores)
	{
		return base.Channel.SetListaIndicadores(VALIDACAO, indicadores);
	}

	public RetornoWsTOOfString SetListaIndicadoresFabric(ValidationRequestTO VALIDACAO, TGTIndicadorMesAnoFabricTO[] indicadores)
	{
		return base.Channel.SetListaIndicadoresFabric(VALIDACAO, indicadores);
	}
}
