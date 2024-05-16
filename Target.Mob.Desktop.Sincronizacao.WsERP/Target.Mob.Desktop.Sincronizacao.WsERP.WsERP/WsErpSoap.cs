using System.CodeDom.Compiler;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "Target.WsERP", ConfigurationName = "WsERP.WsErpSoap")]
public interface WsErpSoap
{
	[OperationContract(Action = "Target.WsERP/WsERP_RelatorioGeral_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_RelatorioGeral_SetResponse WsERP_RelatorioGeral_Set(WsERP_RelatorioGeral_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_RelatorioGeral_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_RelatorioGeral_SetarResponse WsERP_RelatorioGeral_Setar(WsERP_RelatorioGeral_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TipoGrupoSP_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TipoGrupoSP_GetResponse WsERP_TipoGrupoSP_Get(WsERP_TipoGrupoSP_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TipoGrupoSP_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TipoGrupoSP_GetV2Response WsERP_TipoGrupoSP_GetV2(WsERP_TipoGrupoSP_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Carga_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Carga_SetResponse WsERP_Carga_Set(WsERP_Carga_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Carga_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Carga_SetarResponse WsERP_Carga_Setar(WsERP_Carga_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pedido_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pedido_GetNewsResponse WsERP_Pedido_GetNews(WsERP_Pedido_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pedido_GetNewsV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pedido_GetNewsV2Response WsERP_Pedido_GetNewsV2(WsERP_Pedido_GetNewsV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pedido_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pedido_GetResponse WsERP_Pedido_Get(WsERP_Pedido_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pedido_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pedido_GetV2Response WsERP_Pedido_GetV2(WsERP_Pedido_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pedido_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pedido_SetImportResponse WsERP_Pedido_SetImport(WsERP_Pedido_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pedido_SetImportar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pedido_SetImportarResponse WsERP_Pedido_SetImportar(WsERP_Pedido_SetImportarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_PedidoAtendimento_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_PedidoAtendimento_SetResponse WsERP_PedidoAtendimento_Set(WsERP_PedidoAtendimento_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_PedidoAtendimento_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_PedidoAtendimento_SetarResponse WsERP_PedidoAtendimento_Setar(WsERP_PedidoAtendimento_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MotivoNaoVenda_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MotivoNaoVenda_GetNewsResponse WsERP_MotivoNaoVenda_GetNews(WsERP_MotivoNaoVenda_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MotivoNaoVenda_GetNewsV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MotivoNaoVenda_GetNewsV2Response WsERP_MotivoNaoVenda_GetNewsV2(WsERP_MotivoNaoVenda_GetNewsV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_MotivoNaoVenda_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MotivoNaoVenda_GetResponse WsERP_MotivoNaoVenda_Get(WsERP_MotivoNaoVenda_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MotivoNaoVenda_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MotivoNaoVenda_GetV2Response WsERP_MotivoNaoVenda_GetV2(WsERP_MotivoNaoVenda_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_MotivoNaoVenda_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MotivoNaoVenda_SetImportResponse WsERP_MotivoNaoVenda_SetImport(WsERP_MotivoNaoVenda_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MotivoNaoVenda_SetImportar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MotivoNaoVenda_SetImportarResponse WsERP_MotivoNaoVenda_SetImportar(WsERP_MotivoNaoVenda_SetImportarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Troca_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Troca_GetNewsResponse WsERP_Troca_GetNews(WsERP_Troca_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Troca_GetNewsV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Troca_GetNewsV2Response WsERP_Troca_GetNewsV2(WsERP_Troca_GetNewsV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Troca_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Troca_GetResponse WsERP_Troca_Get(WsERP_Troca_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Troca_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Troca_GetV2Response WsERP_Troca_GetV2(WsERP_Troca_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Troca_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Troca_SetImportResponse WsERP_Troca_SetImport(WsERP_Troca_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Troca_SetImportar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Troca_SetImportarResponse WsERP_Troca_SetImportar(WsERP_Troca_SetImportarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Cliente_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Cliente_GetNewsResponse WsERP_Cliente_GetNews(WsERP_Cliente_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Cliente_GetNewsV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Cliente_GetNewsV2Response WsERP_Cliente_GetNewsV2(WsERP_Cliente_GetNewsV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Cliente_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Cliente_GetResponse WsERP_Cliente_Get(WsERP_Cliente_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Cliente_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Cliente_GetV2Response WsERP_Cliente_GetV2(WsERP_Cliente_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Cliente_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Cliente_SetImportResponse WsERP_Cliente_SetImport(WsERP_Cliente_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Cliente_SetImportar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Cliente_SetImportarResponse WsERP_Cliente_SetImportar(WsERP_Cliente_SetImportarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Visita_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Visita_GetNewsResponse WsERP_Visita_GetNews(WsERP_Visita_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Visita_GetNewsV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Visita_GetNewsV2Response WsERP_Visita_GetNewsV2(WsERP_Visita_GetNewsV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Visita_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Visita_GetResponse WsERP_Visita_Get(WsERP_Visita_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Visita_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Visita_GetV2Response WsERP_Visita_GetV2(WsERP_Visita_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Visita_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Visita_SetImportResponse WsERP_Visita_SetImport(WsERP_Visita_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Visita_SetImportar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Visita_SetImportarResponse WsERP_Visita_SetImportar(WsERP_Visita_SetImportarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Servicos_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Servicos_GetResponse WsERP_Servicos_Get(WsERP_Servicos_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Servicos_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Servicos_GetV2Response WsERP_Servicos_GetV2(WsERP_Servicos_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Config_Vendedor_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Config_Vendedor_GetResponse WsERP_Config_Vendedor_Get(WsERP_Config_Vendedor_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Config_Vendedor_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Config_Vendedor_GetV2Response WsERP_Config_Vendedor_GetV2(WsERP_Config_Vendedor_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Config_Vendedor_GetV3", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Config_Vendedor_GetV3Response WsERP_Config_Vendedor_GetV3(WsERP_Config_Vendedor_GetV3Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Forca_Carga_Completa", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Forca_Carga_CompletaResponse WsERP_Forca_Carga_Completa(WsERP_Forca_Carga_CompletaRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Forca_Carga_CompletaV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Forca_Carga_CompletaV2Response WsERP_Forca_Carga_CompletaV2(WsERP_Forca_Carga_CompletaV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Vendedor_GetV3", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Vendedor_GetV3Response WsERP_Vendedor_GetV3(WsERP_Vendedor_GetV3Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_LogErro_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_LogErro_SetResponse WsERP_LogErro_Set(WsERP_LogErro_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_LogErro_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_LogErro_SetarResponse WsERP_LogErro_Setar(WsERP_LogErro_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Empresa_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Empresa_SetResponse WsERP_Empresa_Set(WsERP_Empresa_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Empresa_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Empresa_SetarResponse WsERP_Empresa_Setar(WsERP_Empresa_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_LocalEstoque_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_LocalEstoque_SetResponse WsERP_LocalEstoque_Set(WsERP_LocalEstoque_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_LocalEstoque_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_LocalEstoque_SetarResponse WsERP_LocalEstoque_Setar(WsERP_LocalEstoque_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TabelaPreco_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TabelaPreco_SetResponse WsERP_TabelaPreco_Set(WsERP_TabelaPreco_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TabelaPreco_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TabelaPreco_SetarResponse WsERP_TabelaPreco_Setar(WsERP_TabelaPreco_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_FormaPagamento_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_FormaPagamento_SetResponse WsERP_FormaPagamento_Set(WsERP_FormaPagamento_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_FormaPagamento_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_FormaPagamento_SetarResponse WsERP_FormaPagamento_Setar(WsERP_FormaPagamento_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TipoPedido_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TipoPedido_SetResponse WsERP_TipoPedido_Set(WsERP_TipoPedido_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TipoPedido_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TipoPedido_SetarResponse WsERP_TipoPedido_Setar(WsERP_TipoPedido_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TipoCusto_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TipoCusto_SetResponse WsERP_TipoCusto_Set(WsERP_TipoCusto_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TipoCusto_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TipoCusto_SetarResponse WsERP_TipoCusto_Setar(WsERP_TipoCusto_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Vendedor_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Vendedor_SetResponse WsERP_Vendedor_Set(WsERP_Vendedor_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Vendedor_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Vendedor_SetarResponse WsERP_Vendedor_Setar(WsERP_Vendedor_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_ProdutoErp_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_ProdutoErp_SetResponse WsERP_ProdutoErp_Set(WsERP_ProdutoErp_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_ProdutoErp_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_ProdutoErp_SetarResponse WsERP_ProdutoErp_Setar(WsERP_ProdutoErp_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_ProdutoErpSku_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_ProdutoErpSku_SetarResponse WsERP_ProdutoErpSku_Setar(WsERP_ProdutoErpSku_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TGTFatMesAno_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TGTFatMesAno_SetResponse WsERP_TGTFatMesAno_Set(WsERP_TGTFatMesAno_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_TGTFatMesAnoFabric_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_TGTFatMesAnoFabric_SetResponse WsERP_TGTFatMesAnoFabric_Set(WsERP_TGTFatMesAnoFabric_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Fabricante_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Fabricante_SetResponse WsERP_Fabricante_Set(WsERP_Fabricante_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Fabricante_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Fabricante_SetarResponse WsERP_Fabricante_Setar(WsERP_Fabricante_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Linha_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Linha_SetResponse WsERP_Linha_Set(WsERP_Linha_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Linha_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Linha_SetarResponse WsERP_Linha_Setar(WsERP_Linha_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CategoriaProduto_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CategoriaProduto_SetResponse WsERP_CategoriaProduto_Set(WsERP_CategoriaProduto_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CategoriaProduto_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CategoriaProduto_SetarResponse WsERP_CategoriaProduto_Setar(WsERP_CategoriaProduto_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Equipe_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Equipe_SetResponse WsERP_Equipe_Set(WsERP_Equipe_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_AcaVisitas_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_AcaVisitas_SetResponse WsERP_AcaVisitas_Set(WsERP_AcaVisitas_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_ClienteERP_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_ClienteERP_SetResponse WsERP_ClienteERP_Set(WsERP_ClienteERP_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_RowId_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_RowId_GetResponse WsERP_RowId_Get(WsERP_RowId_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_RowId_GetV2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_RowId_GetV2Response WsERP_RowId_GetV2(WsERP_RowId_GetV2Request request);

	[OperationContract(Action = "Target.WsERP/WsERP_Replicacao_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Replicacao_SetResponse WsERP_Replicacao_Set(WsERP_Replicacao_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Replicacao_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Replicacao_SetarResponse WsERP_Replicacao_Setar(WsERP_Replicacao_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Replicacao_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Replicacao_GetResponse WsERP_Replicacao_Get(WsERP_Replicacao_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_FrequenciaVisita_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_FrequenciaVisita_SetResponse WsERP_FrequenciaVisita_Set(WsERP_FrequenciaVisita_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_VersaoRetaguarda_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_VersaoRetaguarda_SetResponse WsERP_VersaoRetaguarda_Set(WsERP_VersaoRetaguarda_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_VersaoRetaguarda_Setar", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_VersaoRetaguarda_SetarResponse WsERP_VersaoRetaguarda_Setar(WsERP_VersaoRetaguarda_SetarRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_VersaoRetaguarda_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_VersaoRetaguarda_GetResponse WsERP_VersaoRetaguarda_Get(WsERP_VersaoRetaguarda_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_VersaoRetaguardaPedEle_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_VersaoRetaguardaPedEle_GetResponse WsERP_VersaoRetaguardaPedEle_Get(WsERP_VersaoRetaguardaPedEle_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_VersaoRetaguardaPedEle_GetPermissao", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_VersaoRetaguardaPedEle_GetPermissaoResponse WsERP_VersaoRetaguardaPedEle_GetPermissao(WsERP_VersaoRetaguardaPedEle_GetPermissaoRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_VersaoRetaguardaPedEle_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_VersaoRetaguardaPedEle_SetResponse WsERP_VersaoRetaguardaPedEle_Set(WsERP_VersaoRetaguardaPedEle_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Notificacao_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Notificacao_GetResponse WsERP_Notificacao_Get(WsERP_Notificacao_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Notificacao_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Notificacao_SetResponse WsERP_Notificacao_Set(WsERP_Notificacao_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CoordenadaCliente_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CoordenadaCliente_GetResponse WsERP_CoordenadaCliente_Get(WsERP_CoordenadaCliente_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CoordenadaCliente_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CoordenadaCliente_SetImportResponse WsERP_CoordenadaCliente_SetImport(WsERP_CoordenadaCliente_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Gondola_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Gondola_GetResponse WsERP_Gondola_Get(WsERP_Gondola_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Gondola_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Gondola_SetImportResponse WsERP_Gondola_SetImport(WsERP_Gondola_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_DistribuidoraEDI_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_DistribuidoraEDI_SetResponse WsERP_DistribuidoraEDI_Set(WsERP_DistribuidoraEDI_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pagamento_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pagamento_GetResponse WsERP_Pagamento_Get(WsERP_Pagamento_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Pagamento_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Pagamento_SetImportResponse WsERP_Pagamento_SetImport(WsERP_Pagamento_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_RelatorioTrabalhoVendedor_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_RelatorioTrabalhoVendedor_GetNewsResponse WsERP_RelatorioTrabalhoVendedor_GetNews(WsERP_RelatorioTrabalhoVendedor_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_RelatorioTrabalhoVendedor_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_RelatorioTrabalhoVendedor_GetResponse WsERP_RelatorioTrabalhoVendedor_Get(WsERP_RelatorioTrabalhoVendedor_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsResponse WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews(WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CoordenadaRoteiroVendedorPermanencia_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CoordenadaRoteiroVendedorPermanencia_GetResponse WsERP_CoordenadaRoteiroVendedorPermanencia_Get(WsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CategoriaAnotacao_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CategoriaAnotacao_GetNewsResponse WsERP_CategoriaAnotacao_GetNews(WsERP_CategoriaAnotacao_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CategoriaAnotacao_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CategoriaAnotacao_GetResponse WsERP_CategoriaAnotacao_Get(WsERP_CategoriaAnotacao_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Anotacao_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Anotacao_GetNewsResponse WsERP_Anotacao_GetNews(WsERP_Anotacao_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Anotacao_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Anotacao_GetResponse WsERP_Anotacao_Get(WsERP_Anotacao_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Anotacao_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Anotacao_SetImportResponse WsERP_Anotacao_SetImport(WsERP_Anotacao_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_ComoRealizouVenda_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_ComoRealizouVenda_SetResponse WsERP_ComoRealizouVenda_Set(WsERP_ComoRealizouVenda_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Promotor_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Promotor_SetResponse WsERP_Promotor_Set(WsERP_Promotor_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_EquipePromotor_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_EquipePromotor_SetResponse WsERP_EquipePromotor_Set(WsERP_EquipePromotor_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_GerenciaPromotor_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_GerenciaPromotor_SetResponse WsERP_GerenciaPromotor_Set(WsERP_GerenciaPromotor_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_Area_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_Area_SetResponse WsERP_Area_Set(WsERP_Area_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_RamAtiv_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_RamAtiv_SetResponse WsERP_RamAtiv_Set(WsERP_RamAtiv_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_GrupoCli_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_GrupoCli_SetResponse WsERP_GrupoCli_Set(WsERP_GrupoCli_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MonitoramentoGeracao_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MonitoramentoGeracao_SetResponse WsERP_MonitoramentoGeracao_Set(WsERP_MonitoramentoGeracao_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MonitoramentoRetaguarda_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MonitoramentoRetaguarda_SetResponse WsERP_MonitoramentoRetaguarda_Set(WsERP_MonitoramentoRetaguarda_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MonitGerarDados_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MonitGerarDados_SetResponse WsERP_MonitGerarDados_Set(WsERP_MonitGerarDados_SetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CoordenadaResidencia_GetNews", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CoordenadaResidencia_GetNewsResponse WsERP_CoordenadaResidencia_GetNews(WsERP_CoordenadaResidencia_GetNewsRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CoordenadaResidencia_Get", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CoordenadaResidencia_GetResponse WsERP_CoordenadaResidencia_Get(WsERP_CoordenadaResidencia_GetRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_CoordenadaResidencia_SetImport", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_CoordenadaResidencia_SetImportResponse WsERP_CoordenadaResidencia_SetImport(WsERP_CoordenadaResidencia_SetImportRequest request);

	[OperationContract(Action = "Target.WsERP/WsERP_MPAgenda_Set", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WsERP_MPAgenda_SetResponse WsERP_MPAgenda_Set(WsERP_MPAgenda_SetRequest request);
}
