using System.CodeDom.Compiler;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "TargetERP.TargetERPSoap")]
public interface TargetERPSoap
{
	[OperationContract(Action = "http://tempuri.org/EnviarQuantidadeLicencasMatriz", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	bool EnviarQuantidadeLicencasMatriz(EnviarQuantidadeLicencasMatrizTO[] parametro, string token);

	[OperationContract(Action = "http://tempuri.org/EnviarDadosProdutoPainel", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfBoolean EnviarDadosProdutoPainel(ValidationRequestTO VALIDACAO_REQUEST, EnviarProdutoPainelTO parametro);

	[OperationContract(Action = "http://tempuri.org/ReplicacaoSet", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfBoolean ReplicacaoSet(ValidationRequestTO VALIDACAO, string tabela, string versao, string dadosReplicacao);

	[OperationContract(Action = "http://tempuri.org/ReplicacaoGet", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfString ReplicacaoGet(ValidationRequestTO VALIDACAO, string tabela, string rowId);

	[OperationContract(Action = "http://tempuri.org/ReplicacaoVerificarDadosExistentes", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfString ReplicacaoVerificarDadosExistentes(ValidationRequestTO VALIDACAO, string tabela, string rowId);

	[OperationContract(Action = "http://tempuri.org/GerarLogErro", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfString GerarLogErro(ValidationRequestTO VALIDACAO, string tabela, string descricao_erro);

	[OperationContract(Action = "http://tempuri.org/ReplicacaoHorarioPermitido", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfBoolean ReplicacaoHorarioPermitido(ValidationRequestTO VALIDACAO);

	[OperationContract(Action = "http://tempuri.org/VerificaVersaoLiberadaRetaguarda", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfProdutoVersaoTO VerificaVersaoLiberadaRetaguarda(ValidationRequestTO VALIDACAO, VersaoTO VERSAO_ATUAL, VersaoTO VERSAO_ULTIMO_DOWNLOAD);

	[OperationContract(Action = "http://tempuri.org/DownloadVersaoRetaguarda", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfProdutoVersaoTO DownloadVersaoRetaguarda(ValidationRequestTO VALIDACAO, VersaoTO VERSAO_PARA_DOWNLOAD, VersaoTO VERSAO_ULTIMO_DOWNLOAD);

	[OperationContract(Action = "http://tempuri.org/VerificaAtualizacaoAutomatica", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfBoolean VerificaAtualizacaoAutomatica(ValidationRequestTO VALIDACAO, VersaoTO VERSAO_ULTIMO_DOWNLOAD);

	[OperationContract(Action = "http://tempuri.org/AtualizarStatusProdutoPainel", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfBoolean AtualizarStatusProdutoPainel(ValidationRequestTO VALIDACAO, StatusInstalacao STATUS, ProcessoAtualizacaoTO PROCESSO_ATUALIZACAO);

	[OperationContract(Action = "http://tempuri.org/GetMaxRowid", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfString GetMaxRowid(ValidationRequestTO VALIDACAO, string tabela);

	[OperationContract(Action = "http://tempuri.org/SetListaIndicadores", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfString SetListaIndicadores(ValidationRequestTO VALIDACAO, TGTIndicadorMesAnoTO[] indicadores);

	[OperationContract(Action = "http://tempuri.org/SetListaIndicadoresFabric", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[ServiceKnownType(typeof(BaseTO))]
	RetornoWsTOOfString SetListaIndicadoresFabric(ValidationRequestTO VALIDACAO, TGTIndicadorMesAnoFabricTO[] indicadores);
}
