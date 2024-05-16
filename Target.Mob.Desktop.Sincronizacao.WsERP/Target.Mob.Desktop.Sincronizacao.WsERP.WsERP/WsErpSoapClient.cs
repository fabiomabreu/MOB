using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class WsErpSoapClient : ClientBase<WsErpSoap>, WsErpSoap
{
	public WsErpSoapClient()
	{
	}

	public WsErpSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public WsErpSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public WsErpSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public WsErpSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_RelatorioGeral_SetResponse WsErpSoap.WsERP_RelatorioGeral_Set(WsERP_RelatorioGeral_SetRequest request)
	{
		return base.Channel.WsERP_RelatorioGeral_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_RelatorioGeral_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, RelatorioGerencialWsModel relatorioGerencialWs)
	{
		WsERP_RelatorioGeral_SetRequest wsERP_RelatorioGeral_SetRequest = new WsERP_RelatorioGeral_SetRequest();
		wsERP_RelatorioGeral_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_RelatorioGeral_SetRequest.cnpj = cnpj;
		wsERP_RelatorioGeral_SetRequest.relatorioGerencialWs = relatorioGerencialWs;
		return ((WsErpSoap)this).WsERP_RelatorioGeral_Set(wsERP_RelatorioGeral_SetRequest).WsERP_RelatorioGeral_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_RelatorioGeral_SetarResponse WsErpSoap.WsERP_RelatorioGeral_Setar(WsERP_RelatorioGeral_SetarRequest request)
	{
		return base.Channel.WsERP_RelatorioGeral_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_RelatorioGeral_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, RelatorioGerencialWsModel relatorioGerencialWs, string hostName)
	{
		WsERP_RelatorioGeral_SetarRequest wsERP_RelatorioGeral_SetarRequest = new WsERP_RelatorioGeral_SetarRequest();
		wsERP_RelatorioGeral_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_RelatorioGeral_SetarRequest.cnpj = cnpj;
		wsERP_RelatorioGeral_SetarRequest.relatorioGerencialWs = relatorioGerencialWs;
		wsERP_RelatorioGeral_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_RelatorioGeral_Setar(wsERP_RelatorioGeral_SetarRequest).WsERP_RelatorioGeral_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TipoGrupoSP_GetResponse WsErpSoap.WsERP_TipoGrupoSP_Get(WsERP_TipoGrupoSP_GetRequest request)
	{
		return base.Channel.WsERP_TipoGrupoSP_Get(request);
	}

	public RetornoWsModelOfListOfTipoGrupoSPWsModel WsERP_TipoGrupoSP_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_TipoGrupoSP_GetRequest wsERP_TipoGrupoSP_GetRequest = new WsERP_TipoGrupoSP_GetRequest();
		wsERP_TipoGrupoSP_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TipoGrupoSP_GetRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_TipoGrupoSP_Get(wsERP_TipoGrupoSP_GetRequest).WsERP_TipoGrupoSP_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TipoGrupoSP_GetV2Response WsErpSoap.WsERP_TipoGrupoSP_GetV2(WsERP_TipoGrupoSP_GetV2Request request)
	{
		return base.Channel.WsERP_TipoGrupoSP_GetV2(request);
	}

	public RetornoWsModelOfListOfTipoGrupoSPWsModel WsERP_TipoGrupoSP_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_TipoGrupoSP_GetV2Request wsERP_TipoGrupoSP_GetV2Request = new WsERP_TipoGrupoSP_GetV2Request();
		wsERP_TipoGrupoSP_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TipoGrupoSP_GetV2Request.cnpj = cnpj;
		wsERP_TipoGrupoSP_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_TipoGrupoSP_GetV2(wsERP_TipoGrupoSP_GetV2Request).WsERP_TipoGrupoSP_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Carga_SetResponse WsErpSoap.WsERP_Carga_Set(WsERP_Carga_SetRequest request)
	{
		return base.Channel.WsERP_Carga_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Carga_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, CargaWsModel cargaWs)
	{
		WsERP_Carga_SetRequest wsERP_Carga_SetRequest = new WsERP_Carga_SetRequest();
		wsERP_Carga_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Carga_SetRequest.cnpj = cnpj;
		wsERP_Carga_SetRequest.cargaWs = cargaWs;
		return ((WsErpSoap)this).WsERP_Carga_Set(wsERP_Carga_SetRequest).WsERP_Carga_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Carga_SetarResponse WsErpSoap.WsERP_Carga_Setar(WsERP_Carga_SetarRequest request)
	{
		return base.Channel.WsERP_Carga_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Carga_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, CargaWsModel cargaWs, string hostName)
	{
		WsERP_Carga_SetarRequest wsERP_Carga_SetarRequest = new WsERP_Carga_SetarRequest();
		wsERP_Carga_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Carga_SetarRequest.cnpj = cnpj;
		wsERP_Carga_SetarRequest.cargaWs = cargaWs;
		wsERP_Carga_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Carga_Setar(wsERP_Carga_SetarRequest).WsERP_Carga_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pedido_GetNewsResponse WsErpSoap.WsERP_Pedido_GetNews(WsERP_Pedido_GetNewsRequest request)
	{
		return base.Channel.WsERP_Pedido_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Pedido_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_Pedido_GetNewsRequest wsERP_Pedido_GetNewsRequest = new WsERP_Pedido_GetNewsRequest();
		wsERP_Pedido_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pedido_GetNewsRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_Pedido_GetNews(wsERP_Pedido_GetNewsRequest).WsERP_Pedido_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pedido_GetNewsV2Response WsErpSoap.WsERP_Pedido_GetNewsV2(WsERP_Pedido_GetNewsV2Request request)
	{
		return base.Channel.WsERP_Pedido_GetNewsV2(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Pedido_GetNewsV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		WsERP_Pedido_GetNewsV2Request wsERP_Pedido_GetNewsV2Request = new WsERP_Pedido_GetNewsV2Request();
		wsERP_Pedido_GetNewsV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pedido_GetNewsV2Request.cnpj = cnpj;
		wsERP_Pedido_GetNewsV2Request.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Pedido_GetNewsV2(wsERP_Pedido_GetNewsV2Request).WsERP_Pedido_GetNewsV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pedido_GetResponse WsErpSoap.WsERP_Pedido_Get(WsERP_Pedido_GetRequest request)
	{
		return base.Channel.WsERP_Pedido_Get(request);
	}

	public RetornoWsModelOfPedVdaWsModel WsERP_Pedido_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int iDPedVda)
	{
		WsERP_Pedido_GetRequest wsERP_Pedido_GetRequest = new WsERP_Pedido_GetRequest();
		wsERP_Pedido_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pedido_GetRequest.cnpj = cnpj;
		wsERP_Pedido_GetRequest.iDPedVda = iDPedVda;
		return ((WsErpSoap)this).WsERP_Pedido_Get(wsERP_Pedido_GetRequest).WsERP_Pedido_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pedido_GetV2Response WsErpSoap.WsERP_Pedido_GetV2(WsERP_Pedido_GetV2Request request)
	{
		return base.Channel.WsERP_Pedido_GetV2(request);
	}

	public RetornoWsModelOfPedVdaWsModel WsERP_Pedido_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, int iDPedVda, string hostname)
	{
		WsERP_Pedido_GetV2Request wsERP_Pedido_GetV2Request = new WsERP_Pedido_GetV2Request();
		wsERP_Pedido_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pedido_GetV2Request.cnpj = cnpj;
		wsERP_Pedido_GetV2Request.iDPedVda = iDPedVda;
		wsERP_Pedido_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Pedido_GetV2(wsERP_Pedido_GetV2Request).WsERP_Pedido_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pedido_SetImportResponse WsErpSoap.WsERP_Pedido_SetImport(WsERP_Pedido_SetImportRequest request)
	{
		return base.Channel.WsERP_Pedido_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_Pedido_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoPedido)
	{
		WsERP_Pedido_SetImportRequest wsERP_Pedido_SetImportRequest = new WsERP_Pedido_SetImportRequest();
		wsERP_Pedido_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pedido_SetImportRequest.cnpj = cnpj;
		wsERP_Pedido_SetImportRequest.codigoPedido = codigoPedido;
		return ((WsErpSoap)this).WsERP_Pedido_SetImport(wsERP_Pedido_SetImportRequest).WsERP_Pedido_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pedido_SetImportarResponse WsErpSoap.WsERP_Pedido_SetImportar(WsERP_Pedido_SetImportarRequest request)
	{
		return base.Channel.WsERP_Pedido_SetImportar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Pedido_SetImportar(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoPedido, string hostName)
	{
		WsERP_Pedido_SetImportarRequest wsERP_Pedido_SetImportarRequest = new WsERP_Pedido_SetImportarRequest();
		wsERP_Pedido_SetImportarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pedido_SetImportarRequest.cnpj = cnpj;
		wsERP_Pedido_SetImportarRequest.codigoPedido = codigoPedido;
		wsERP_Pedido_SetImportarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Pedido_SetImportar(wsERP_Pedido_SetImportarRequest).WsERP_Pedido_SetImportarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_PedidoAtendimento_SetResponse WsErpSoap.WsERP_PedidoAtendimento_Set(WsERP_PedidoAtendimento_SetRequest request)
	{
		return base.Channel.WsERP_PedidoAtendimento_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_PedidoAtendimento_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, PedVdaAtendimentoWsModel pedido)
	{
		WsERP_PedidoAtendimento_SetRequest wsERP_PedidoAtendimento_SetRequest = new WsERP_PedidoAtendimento_SetRequest();
		wsERP_PedidoAtendimento_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_PedidoAtendimento_SetRequest.cnpj = cnpj;
		wsERP_PedidoAtendimento_SetRequest.pedido = pedido;
		return ((WsErpSoap)this).WsERP_PedidoAtendimento_Set(wsERP_PedidoAtendimento_SetRequest).WsERP_PedidoAtendimento_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_PedidoAtendimento_SetarResponse WsErpSoap.WsERP_PedidoAtendimento_Setar(WsERP_PedidoAtendimento_SetarRequest request)
	{
		return base.Channel.WsERP_PedidoAtendimento_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_PedidoAtendimento_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, PedVdaAtendimentoWsModel pedido, string hostName)
	{
		WsERP_PedidoAtendimento_SetarRequest wsERP_PedidoAtendimento_SetarRequest = new WsERP_PedidoAtendimento_SetarRequest();
		wsERP_PedidoAtendimento_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_PedidoAtendimento_SetarRequest.cnpj = cnpj;
		wsERP_PedidoAtendimento_SetarRequest.pedido = pedido;
		wsERP_PedidoAtendimento_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_PedidoAtendimento_Setar(wsERP_PedidoAtendimento_SetarRequest).WsERP_PedidoAtendimento_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MotivoNaoVenda_GetNewsResponse WsErpSoap.WsERP_MotivoNaoVenda_GetNews(WsERP_MotivoNaoVenda_GetNewsRequest request)
	{
		return base.Channel.WsERP_MotivoNaoVenda_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_MotivoNaoVenda_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_MotivoNaoVenda_GetNewsRequest wsERP_MotivoNaoVenda_GetNewsRequest = new WsERP_MotivoNaoVenda_GetNewsRequest();
		wsERP_MotivoNaoVenda_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MotivoNaoVenda_GetNewsRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_MotivoNaoVenda_GetNews(wsERP_MotivoNaoVenda_GetNewsRequest).WsERP_MotivoNaoVenda_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MotivoNaoVenda_GetNewsV2Response WsErpSoap.WsERP_MotivoNaoVenda_GetNewsV2(WsERP_MotivoNaoVenda_GetNewsV2Request request)
	{
		return base.Channel.WsERP_MotivoNaoVenda_GetNewsV2(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_MotivoNaoVenda_GetNewsV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_MotivoNaoVenda_GetNewsV2Request wsERP_MotivoNaoVenda_GetNewsV2Request = new WsERP_MotivoNaoVenda_GetNewsV2Request();
		wsERP_MotivoNaoVenda_GetNewsV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MotivoNaoVenda_GetNewsV2Request.cnpj = cnpj;
		wsERP_MotivoNaoVenda_GetNewsV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_MotivoNaoVenda_GetNewsV2(wsERP_MotivoNaoVenda_GetNewsV2Request).WsERP_MotivoNaoVenda_GetNewsV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MotivoNaoVenda_GetResponse WsErpSoap.WsERP_MotivoNaoVenda_Get(WsERP_MotivoNaoVenda_GetRequest request)
	{
		return base.Channel.WsERP_MotivoNaoVenda_Get(request);
	}

	public RetornoWsModelOfMotivoNaoVendaWsModel WsERP_MotivoNaoVenda_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoMotivoNaoVenda)
	{
		WsERP_MotivoNaoVenda_GetRequest wsERP_MotivoNaoVenda_GetRequest = new WsERP_MotivoNaoVenda_GetRequest();
		wsERP_MotivoNaoVenda_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MotivoNaoVenda_GetRequest.cnpj = cnpj;
		wsERP_MotivoNaoVenda_GetRequest.codigoMotivoNaoVenda = codigoMotivoNaoVenda;
		return ((WsErpSoap)this).WsERP_MotivoNaoVenda_Get(wsERP_MotivoNaoVenda_GetRequest).WsERP_MotivoNaoVenda_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MotivoNaoVenda_GetV2Response WsErpSoap.WsERP_MotivoNaoVenda_GetV2(WsERP_MotivoNaoVenda_GetV2Request request)
	{
		return base.Channel.WsERP_MotivoNaoVenda_GetV2(request);
	}

	public RetornoWsModelOfMotivoNaoVendaWsModel WsERP_MotivoNaoVenda_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoMotivoNaoVenda, string hostname)
	{
		WsERP_MotivoNaoVenda_GetV2Request wsERP_MotivoNaoVenda_GetV2Request = new WsERP_MotivoNaoVenda_GetV2Request();
		wsERP_MotivoNaoVenda_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MotivoNaoVenda_GetV2Request.cnpj = cnpj;
		wsERP_MotivoNaoVenda_GetV2Request.codigoMotivoNaoVenda = codigoMotivoNaoVenda;
		wsERP_MotivoNaoVenda_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_MotivoNaoVenda_GetV2(wsERP_MotivoNaoVenda_GetV2Request).WsERP_MotivoNaoVenda_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MotivoNaoVenda_SetImportResponse WsErpSoap.WsERP_MotivoNaoVenda_SetImport(WsERP_MotivoNaoVenda_SetImportRequest request)
	{
		return base.Channel.WsERP_MotivoNaoVenda_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_MotivoNaoVenda_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoMotivoNaoVenda)
	{
		WsERP_MotivoNaoVenda_SetImportRequest wsERP_MotivoNaoVenda_SetImportRequest = new WsERP_MotivoNaoVenda_SetImportRequest();
		wsERP_MotivoNaoVenda_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MotivoNaoVenda_SetImportRequest.cnpj = cnpj;
		wsERP_MotivoNaoVenda_SetImportRequest.codigoMotivoNaoVenda = codigoMotivoNaoVenda;
		return ((WsErpSoap)this).WsERP_MotivoNaoVenda_SetImport(wsERP_MotivoNaoVenda_SetImportRequest).WsERP_MotivoNaoVenda_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MotivoNaoVenda_SetImportarResponse WsErpSoap.WsERP_MotivoNaoVenda_SetImportar(WsERP_MotivoNaoVenda_SetImportarRequest request)
	{
		return base.Channel.WsERP_MotivoNaoVenda_SetImportar(request);
	}

	public RetornoWsModelOfBoolean WsERP_MotivoNaoVenda_SetImportar(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoMotivoNaoVenda, string hostName)
	{
		WsERP_MotivoNaoVenda_SetImportarRequest wsERP_MotivoNaoVenda_SetImportarRequest = new WsERP_MotivoNaoVenda_SetImportarRequest();
		wsERP_MotivoNaoVenda_SetImportarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MotivoNaoVenda_SetImportarRequest.cnpj = cnpj;
		wsERP_MotivoNaoVenda_SetImportarRequest.codigoMotivoNaoVenda = codigoMotivoNaoVenda;
		wsERP_MotivoNaoVenda_SetImportarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_MotivoNaoVenda_SetImportar(wsERP_MotivoNaoVenda_SetImportarRequest).WsERP_MotivoNaoVenda_SetImportarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Troca_GetNewsResponse WsErpSoap.WsERP_Troca_GetNews(WsERP_Troca_GetNewsRequest request)
	{
		return base.Channel.WsERP_Troca_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Troca_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_Troca_GetNewsRequest wsERP_Troca_GetNewsRequest = new WsERP_Troca_GetNewsRequest();
		wsERP_Troca_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Troca_GetNewsRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_Troca_GetNews(wsERP_Troca_GetNewsRequest).WsERP_Troca_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Troca_GetNewsV2Response WsErpSoap.WsERP_Troca_GetNewsV2(WsERP_Troca_GetNewsV2Request request)
	{
		return base.Channel.WsERP_Troca_GetNewsV2(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Troca_GetNewsV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_Troca_GetNewsV2Request wsERP_Troca_GetNewsV2Request = new WsERP_Troca_GetNewsV2Request();
		wsERP_Troca_GetNewsV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Troca_GetNewsV2Request.cnpj = cnpj;
		wsERP_Troca_GetNewsV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Troca_GetNewsV2(wsERP_Troca_GetNewsV2Request).WsERP_Troca_GetNewsV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Troca_GetResponse WsErpSoap.WsERP_Troca_Get(WsERP_Troca_GetRequest request)
	{
		return base.Channel.WsERP_Troca_Get(request);
	}

	public RetornoWsModelOfTrocaWsModel WsERP_Troca_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoTroca)
	{
		WsERP_Troca_GetRequest wsERP_Troca_GetRequest = new WsERP_Troca_GetRequest();
		wsERP_Troca_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Troca_GetRequest.cnpj = cnpj;
		wsERP_Troca_GetRequest.codigoTroca = codigoTroca;
		return ((WsErpSoap)this).WsERP_Troca_Get(wsERP_Troca_GetRequest).WsERP_Troca_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Troca_GetV2Response WsErpSoap.WsERP_Troca_GetV2(WsERP_Troca_GetV2Request request)
	{
		return base.Channel.WsERP_Troca_GetV2(request);
	}

	public RetornoWsModelOfTrocaWsModel WsERP_Troca_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoTroca, string hostname)
	{
		WsERP_Troca_GetV2Request wsERP_Troca_GetV2Request = new WsERP_Troca_GetV2Request();
		wsERP_Troca_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Troca_GetV2Request.cnpj = cnpj;
		wsERP_Troca_GetV2Request.codigoTroca = codigoTroca;
		wsERP_Troca_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Troca_GetV2(wsERP_Troca_GetV2Request).WsERP_Troca_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Troca_SetImportResponse WsErpSoap.WsERP_Troca_SetImport(WsERP_Troca_SetImportRequest request)
	{
		return base.Channel.WsERP_Troca_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_Troca_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoTroca)
	{
		WsERP_Troca_SetImportRequest wsERP_Troca_SetImportRequest = new WsERP_Troca_SetImportRequest();
		wsERP_Troca_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Troca_SetImportRequest.cnpj = cnpj;
		wsERP_Troca_SetImportRequest.codigoTroca = codigoTroca;
		return ((WsErpSoap)this).WsERP_Troca_SetImport(wsERP_Troca_SetImportRequest).WsERP_Troca_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Troca_SetImportarResponse WsErpSoap.WsERP_Troca_SetImportar(WsERP_Troca_SetImportarRequest request)
	{
		return base.Channel.WsERP_Troca_SetImportar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Troca_SetImportar(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoTroca, string hostName)
	{
		WsERP_Troca_SetImportarRequest wsERP_Troca_SetImportarRequest = new WsERP_Troca_SetImportarRequest();
		wsERP_Troca_SetImportarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Troca_SetImportarRequest.cnpj = cnpj;
		wsERP_Troca_SetImportarRequest.codigoTroca = codigoTroca;
		wsERP_Troca_SetImportarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Troca_SetImportar(wsERP_Troca_SetImportarRequest).WsERP_Troca_SetImportarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Cliente_GetNewsResponse WsErpSoap.WsERP_Cliente_GetNews(WsERP_Cliente_GetNewsRequest request)
	{
		return base.Channel.WsERP_Cliente_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Cliente_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_Cliente_GetNewsRequest wsERP_Cliente_GetNewsRequest = new WsERP_Cliente_GetNewsRequest();
		wsERP_Cliente_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Cliente_GetNewsRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_Cliente_GetNews(wsERP_Cliente_GetNewsRequest).WsERP_Cliente_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Cliente_GetNewsV2Response WsErpSoap.WsERP_Cliente_GetNewsV2(WsERP_Cliente_GetNewsV2Request request)
	{
		return base.Channel.WsERP_Cliente_GetNewsV2(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Cliente_GetNewsV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_Cliente_GetNewsV2Request wsERP_Cliente_GetNewsV2Request = new WsERP_Cliente_GetNewsV2Request();
		wsERP_Cliente_GetNewsV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Cliente_GetNewsV2Request.cnpj = cnpj;
		wsERP_Cliente_GetNewsV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Cliente_GetNewsV2(wsERP_Cliente_GetNewsV2Request).WsERP_Cliente_GetNewsV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Cliente_GetResponse WsErpSoap.WsERP_Cliente_Get(WsERP_Cliente_GetRequest request)
	{
		return base.Channel.WsERP_Cliente_Get(request);
	}

	public RetornoWsModelOfClienteWsModel WsERP_Cliente_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoCliente)
	{
		WsERP_Cliente_GetRequest wsERP_Cliente_GetRequest = new WsERP_Cliente_GetRequest();
		wsERP_Cliente_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Cliente_GetRequest.cnpj = cnpj;
		wsERP_Cliente_GetRequest.codigoCliente = codigoCliente;
		return ((WsErpSoap)this).WsERP_Cliente_Get(wsERP_Cliente_GetRequest).WsERP_Cliente_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Cliente_GetV2Response WsErpSoap.WsERP_Cliente_GetV2(WsERP_Cliente_GetV2Request request)
	{
		return base.Channel.WsERP_Cliente_GetV2(request);
	}

	public RetornoWsModelOfClienteWsModel WsERP_Cliente_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoCliente, string hostname)
	{
		WsERP_Cliente_GetV2Request wsERP_Cliente_GetV2Request = new WsERP_Cliente_GetV2Request();
		wsERP_Cliente_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Cliente_GetV2Request.cnpj = cnpj;
		wsERP_Cliente_GetV2Request.codigoCliente = codigoCliente;
		wsERP_Cliente_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Cliente_GetV2(wsERP_Cliente_GetV2Request).WsERP_Cliente_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Cliente_SetImportResponse WsErpSoap.WsERP_Cliente_SetImport(WsERP_Cliente_SetImportRequest request)
	{
		return base.Channel.WsERP_Cliente_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_Cliente_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoCliente)
	{
		WsERP_Cliente_SetImportRequest wsERP_Cliente_SetImportRequest = new WsERP_Cliente_SetImportRequest();
		wsERP_Cliente_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Cliente_SetImportRequest.cnpj = cnpj;
		wsERP_Cliente_SetImportRequest.codigoCliente = codigoCliente;
		return ((WsErpSoap)this).WsERP_Cliente_SetImport(wsERP_Cliente_SetImportRequest).WsERP_Cliente_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Cliente_SetImportarResponse WsErpSoap.WsERP_Cliente_SetImportar(WsERP_Cliente_SetImportarRequest request)
	{
		return base.Channel.WsERP_Cliente_SetImportar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Cliente_SetImportar(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoCliente, string hostName)
	{
		WsERP_Cliente_SetImportarRequest wsERP_Cliente_SetImportarRequest = new WsERP_Cliente_SetImportarRequest();
		wsERP_Cliente_SetImportarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Cliente_SetImportarRequest.cnpj = cnpj;
		wsERP_Cliente_SetImportarRequest.codigoCliente = codigoCliente;
		wsERP_Cliente_SetImportarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Cliente_SetImportar(wsERP_Cliente_SetImportarRequest).WsERP_Cliente_SetImportarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Visita_GetNewsResponse WsErpSoap.WsERP_Visita_GetNews(WsERP_Visita_GetNewsRequest request)
	{
		return base.Channel.WsERP_Visita_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Visita_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_Visita_GetNewsRequest wsERP_Visita_GetNewsRequest = new WsERP_Visita_GetNewsRequest();
		wsERP_Visita_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Visita_GetNewsRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_Visita_GetNews(wsERP_Visita_GetNewsRequest).WsERP_Visita_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Visita_GetNewsV2Response WsErpSoap.WsERP_Visita_GetNewsV2(WsERP_Visita_GetNewsV2Request request)
	{
		return base.Channel.WsERP_Visita_GetNewsV2(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Visita_GetNewsV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_Visita_GetNewsV2Request wsERP_Visita_GetNewsV2Request = new WsERP_Visita_GetNewsV2Request();
		wsERP_Visita_GetNewsV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Visita_GetNewsV2Request.cnpj = cnpj;
		wsERP_Visita_GetNewsV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Visita_GetNewsV2(wsERP_Visita_GetNewsV2Request).WsERP_Visita_GetNewsV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Visita_GetResponse WsErpSoap.WsERP_Visita_Get(WsERP_Visita_GetRequest request)
	{
		return base.Channel.WsERP_Visita_Get(request);
	}

	public RetornoWsModelOfVisitaWsModel WsERP_Visita_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoVisita)
	{
		WsERP_Visita_GetRequest wsERP_Visita_GetRequest = new WsERP_Visita_GetRequest();
		wsERP_Visita_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Visita_GetRequest.cnpj = cnpj;
		wsERP_Visita_GetRequest.codigoVisita = codigoVisita;
		return ((WsErpSoap)this).WsERP_Visita_Get(wsERP_Visita_GetRequest).WsERP_Visita_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Visita_GetV2Response WsErpSoap.WsERP_Visita_GetV2(WsERP_Visita_GetV2Request request)
	{
		return base.Channel.WsERP_Visita_GetV2(request);
	}

	public RetornoWsModelOfVisitaWsModel WsERP_Visita_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoVisita, string hostname)
	{
		WsERP_Visita_GetV2Request wsERP_Visita_GetV2Request = new WsERP_Visita_GetV2Request();
		wsERP_Visita_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Visita_GetV2Request.cnpj = cnpj;
		wsERP_Visita_GetV2Request.codigoVisita = codigoVisita;
		wsERP_Visita_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Visita_GetV2(wsERP_Visita_GetV2Request).WsERP_Visita_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Visita_SetImportResponse WsErpSoap.WsERP_Visita_SetImport(WsERP_Visita_SetImportRequest request)
	{
		return base.Channel.WsERP_Visita_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_Visita_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoVisita)
	{
		WsERP_Visita_SetImportRequest wsERP_Visita_SetImportRequest = new WsERP_Visita_SetImportRequest();
		wsERP_Visita_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Visita_SetImportRequest.cnpj = cnpj;
		wsERP_Visita_SetImportRequest.codigoVisita = codigoVisita;
		return ((WsErpSoap)this).WsERP_Visita_SetImport(wsERP_Visita_SetImportRequest).WsERP_Visita_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Visita_SetImportarResponse WsErpSoap.WsERP_Visita_SetImportar(WsERP_Visita_SetImportarRequest request)
	{
		return base.Channel.WsERP_Visita_SetImportar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Visita_SetImportar(ValidationSoapHeader ValidationSoapHeader, string cnpj, int codigoVisita, string hostName)
	{
		WsERP_Visita_SetImportarRequest wsERP_Visita_SetImportarRequest = new WsERP_Visita_SetImportarRequest();
		wsERP_Visita_SetImportarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Visita_SetImportarRequest.cnpj = cnpj;
		wsERP_Visita_SetImportarRequest.codigoVisita = codigoVisita;
		wsERP_Visita_SetImportarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Visita_SetImportar(wsERP_Visita_SetImportarRequest).WsERP_Visita_SetImportarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Servicos_GetResponse WsErpSoap.WsERP_Servicos_Get(WsERP_Servicos_GetRequest request)
	{
		return base.Channel.WsERP_Servicos_Get(request);
	}

	public RetornoWsModelOfListOfServicoWsModel WsERP_Servicos_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_Servicos_GetRequest wsERP_Servicos_GetRequest = new WsERP_Servicos_GetRequest();
		wsERP_Servicos_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Servicos_GetRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_Servicos_Get(wsERP_Servicos_GetRequest).WsERP_Servicos_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Servicos_GetV2Response WsErpSoap.WsERP_Servicos_GetV2(WsERP_Servicos_GetV2Request request)
	{
		return base.Channel.WsERP_Servicos_GetV2(request);
	}

	public RetornoWsModelOfListOfServicoWsModel WsERP_Servicos_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_Servicos_GetV2Request wsERP_Servicos_GetV2Request = new WsERP_Servicos_GetV2Request();
		wsERP_Servicos_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Servicos_GetV2Request.cnpj = cnpj;
		wsERP_Servicos_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Servicos_GetV2(wsERP_Servicos_GetV2Request).WsERP_Servicos_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Config_Vendedor_GetResponse WsErpSoap.WsERP_Config_Vendedor_Get(WsERP_Config_Vendedor_GetRequest request)
	{
		return base.Channel.WsERP_Config_Vendedor_Get(request);
	}

	public RetornoWsModelOfListOfConfiguracaoVendedorWsModel WsERP_Config_Vendedor_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_Config_Vendedor_GetRequest wsERP_Config_Vendedor_GetRequest = new WsERP_Config_Vendedor_GetRequest();
		wsERP_Config_Vendedor_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Config_Vendedor_GetRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_Config_Vendedor_Get(wsERP_Config_Vendedor_GetRequest).WsERP_Config_Vendedor_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Config_Vendedor_GetV2Response WsErpSoap.WsERP_Config_Vendedor_GetV2(WsERP_Config_Vendedor_GetV2Request request)
	{
		return base.Channel.WsERP_Config_Vendedor_GetV2(request);
	}

	public RetornoWsModelOfListOfConfiguracaoVendedorWsModel WsERP_Config_Vendedor_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_Config_Vendedor_GetV2Request wsERP_Config_Vendedor_GetV2Request = new WsERP_Config_Vendedor_GetV2Request();
		wsERP_Config_Vendedor_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Config_Vendedor_GetV2Request.cnpj = cnpj;
		wsERP_Config_Vendedor_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Config_Vendedor_GetV2(wsERP_Config_Vendedor_GetV2Request).WsERP_Config_Vendedor_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Config_Vendedor_GetV3Response WsErpSoap.WsERP_Config_Vendedor_GetV3(WsERP_Config_Vendedor_GetV3Request request)
	{
		return base.Channel.WsERP_Config_Vendedor_GetV3(request);
	}

	public RetornoWsModelOfListOfConfiguracaoVendedorWsModel WsERP_Config_Vendedor_GetV3(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname, byte[] rowId)
	{
		WsERP_Config_Vendedor_GetV3Request wsERP_Config_Vendedor_GetV3Request = new WsERP_Config_Vendedor_GetV3Request();
		wsERP_Config_Vendedor_GetV3Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Config_Vendedor_GetV3Request.cnpj = cnpj;
		wsERP_Config_Vendedor_GetV3Request.hostname = hostname;
		wsERP_Config_Vendedor_GetV3Request.rowId = rowId;
		return ((WsErpSoap)this).WsERP_Config_Vendedor_GetV3(wsERP_Config_Vendedor_GetV3Request).WsERP_Config_Vendedor_GetV3Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Forca_Carga_CompletaResponse WsErpSoap.WsERP_Forca_Carga_Completa(WsERP_Forca_Carga_CompletaRequest request)
	{
		return base.Channel.WsERP_Forca_Carga_Completa(request);
	}

	public RetornoWsModelOfListOfVendedorWsModel WsERP_Forca_Carga_Completa(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_Forca_Carga_CompletaRequest wsERP_Forca_Carga_CompletaRequest = new WsERP_Forca_Carga_CompletaRequest();
		wsERP_Forca_Carga_CompletaRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Forca_Carga_CompletaRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_Forca_Carga_Completa(wsERP_Forca_Carga_CompletaRequest).WsERP_Forca_Carga_CompletaResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Forca_Carga_CompletaV2Response WsErpSoap.WsERP_Forca_Carga_CompletaV2(WsERP_Forca_Carga_CompletaV2Request request)
	{
		return base.Channel.WsERP_Forca_Carga_CompletaV2(request);
	}

	public RetornoWsModelOfListOfVendedorWsModel WsERP_Forca_Carga_CompletaV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname)
	{
		WsERP_Forca_Carga_CompletaV2Request wsERP_Forca_Carga_CompletaV2Request = new WsERP_Forca_Carga_CompletaV2Request();
		wsERP_Forca_Carga_CompletaV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Forca_Carga_CompletaV2Request.cnpj = cnpj;
		wsERP_Forca_Carga_CompletaV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_Forca_Carga_CompletaV2(wsERP_Forca_Carga_CompletaV2Request).WsERP_Forca_Carga_CompletaV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Vendedor_GetV3Response WsErpSoap.WsERP_Vendedor_GetV3(WsERP_Vendedor_GetV3Request request)
	{
		return base.Channel.WsERP_Vendedor_GetV3(request);
	}

	public RetornoWsModelOfListOfVendedorWsModel WsERP_Vendedor_GetV3(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostname, byte[] rowIdPainel)
	{
		WsERP_Vendedor_GetV3Request wsERP_Vendedor_GetV3Request = new WsERP_Vendedor_GetV3Request();
		wsERP_Vendedor_GetV3Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Vendedor_GetV3Request.cnpj = cnpj;
		wsERP_Vendedor_GetV3Request.hostname = hostname;
		wsERP_Vendedor_GetV3Request.rowIdPainel = rowIdPainel;
		return ((WsErpSoap)this).WsERP_Vendedor_GetV3(wsERP_Vendedor_GetV3Request).WsERP_Vendedor_GetV3Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_LogErro_SetResponse WsErpSoap.WsERP_LogErro_Set(WsERP_LogErro_SetRequest request)
	{
		return base.Channel.WsERP_LogErro_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_LogErro_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, LogErroWsModel logErroWs)
	{
		WsERP_LogErro_SetRequest wsERP_LogErro_SetRequest = new WsERP_LogErro_SetRequest();
		wsERP_LogErro_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_LogErro_SetRequest.cnpj = cnpj;
		wsERP_LogErro_SetRequest.logErroWs = logErroWs;
		return ((WsErpSoap)this).WsERP_LogErro_Set(wsERP_LogErro_SetRequest).WsERP_LogErro_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_LogErro_SetarResponse WsErpSoap.WsERP_LogErro_Setar(WsERP_LogErro_SetarRequest request)
	{
		return base.Channel.WsERP_LogErro_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_LogErro_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, LogErroWsModel logErroWs, string hostName)
	{
		WsERP_LogErro_SetarRequest wsERP_LogErro_SetarRequest = new WsERP_LogErro_SetarRequest();
		wsERP_LogErro_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_LogErro_SetarRequest.cnpj = cnpj;
		wsERP_LogErro_SetarRequest.logErroWs = logErroWs;
		wsERP_LogErro_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_LogErro_Setar(wsERP_LogErro_SetarRequest).WsERP_LogErro_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Empresa_SetResponse WsErpSoap.WsERP_Empresa_Set(WsERP_Empresa_SetRequest request)
	{
		return base.Channel.WsERP_Empresa_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Empresa_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, EmpresaWsModel[] empresas)
	{
		WsERP_Empresa_SetRequest wsERP_Empresa_SetRequest = new WsERP_Empresa_SetRequest();
		wsERP_Empresa_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Empresa_SetRequest.cnpj = cnpj;
		wsERP_Empresa_SetRequest.empresas = empresas;
		return ((WsErpSoap)this).WsERP_Empresa_Set(wsERP_Empresa_SetRequest).WsERP_Empresa_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Empresa_SetarResponse WsErpSoap.WsERP_Empresa_Setar(WsERP_Empresa_SetarRequest request)
	{
		return base.Channel.WsERP_Empresa_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Empresa_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, EmpresaWsModel[] empresas, string hostName)
	{
		WsERP_Empresa_SetarRequest wsERP_Empresa_SetarRequest = new WsERP_Empresa_SetarRequest();
		wsERP_Empresa_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Empresa_SetarRequest.cnpj = cnpj;
		wsERP_Empresa_SetarRequest.empresas = empresas;
		wsERP_Empresa_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Empresa_Setar(wsERP_Empresa_SetarRequest).WsERP_Empresa_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_LocalEstoque_SetResponse WsErpSoap.WsERP_LocalEstoque_Set(WsERP_LocalEstoque_SetRequest request)
	{
		return base.Channel.WsERP_LocalEstoque_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_LocalEstoque_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, LocalEstoqueWsModel[] locais)
	{
		WsERP_LocalEstoque_SetRequest wsERP_LocalEstoque_SetRequest = new WsERP_LocalEstoque_SetRequest();
		wsERP_LocalEstoque_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_LocalEstoque_SetRequest.cnpj = cnpj;
		wsERP_LocalEstoque_SetRequest.locais = locais;
		return ((WsErpSoap)this).WsERP_LocalEstoque_Set(wsERP_LocalEstoque_SetRequest).WsERP_LocalEstoque_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_LocalEstoque_SetarResponse WsErpSoap.WsERP_LocalEstoque_Setar(WsERP_LocalEstoque_SetarRequest request)
	{
		return base.Channel.WsERP_LocalEstoque_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_LocalEstoque_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, LocalEstoqueWsModel[] locais, string hostName)
	{
		WsERP_LocalEstoque_SetarRequest wsERP_LocalEstoque_SetarRequest = new WsERP_LocalEstoque_SetarRequest();
		wsERP_LocalEstoque_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_LocalEstoque_SetarRequest.cnpj = cnpj;
		wsERP_LocalEstoque_SetarRequest.locais = locais;
		wsERP_LocalEstoque_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_LocalEstoque_Setar(wsERP_LocalEstoque_SetarRequest).WsERP_LocalEstoque_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TabelaPreco_SetResponse WsErpSoap.WsERP_TabelaPreco_Set(WsERP_TabelaPreco_SetRequest request)
	{
		return base.Channel.WsERP_TabelaPreco_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_TabelaPreco_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, TabelaPrecoWsModel[] tabelas)
	{
		WsERP_TabelaPreco_SetRequest wsERP_TabelaPreco_SetRequest = new WsERP_TabelaPreco_SetRequest();
		wsERP_TabelaPreco_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TabelaPreco_SetRequest.cnpj = cnpj;
		wsERP_TabelaPreco_SetRequest.tabelas = tabelas;
		return ((WsErpSoap)this).WsERP_TabelaPreco_Set(wsERP_TabelaPreco_SetRequest).WsERP_TabelaPreco_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TabelaPreco_SetarResponse WsErpSoap.WsERP_TabelaPreco_Setar(WsERP_TabelaPreco_SetarRequest request)
	{
		return base.Channel.WsERP_TabelaPreco_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_TabelaPreco_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, TabelaPrecoWsModel[] tabelas, string hostName)
	{
		WsERP_TabelaPreco_SetarRequest wsERP_TabelaPreco_SetarRequest = new WsERP_TabelaPreco_SetarRequest();
		wsERP_TabelaPreco_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TabelaPreco_SetarRequest.cnpj = cnpj;
		wsERP_TabelaPreco_SetarRequest.tabelas = tabelas;
		wsERP_TabelaPreco_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_TabelaPreco_Setar(wsERP_TabelaPreco_SetarRequest).WsERP_TabelaPreco_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_FormaPagamento_SetResponse WsErpSoap.WsERP_FormaPagamento_Set(WsERP_FormaPagamento_SetRequest request)
	{
		return base.Channel.WsERP_FormaPagamento_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_FormaPagamento_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, FormaPagamentoWsModel[] formasPagamento)
	{
		WsERP_FormaPagamento_SetRequest wsERP_FormaPagamento_SetRequest = new WsERP_FormaPagamento_SetRequest();
		wsERP_FormaPagamento_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_FormaPagamento_SetRequest.cnpj = cnpj;
		wsERP_FormaPagamento_SetRequest.formasPagamento = formasPagamento;
		return ((WsErpSoap)this).WsERP_FormaPagamento_Set(wsERP_FormaPagamento_SetRequest).WsERP_FormaPagamento_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_FormaPagamento_SetarResponse WsErpSoap.WsERP_FormaPagamento_Setar(WsERP_FormaPagamento_SetarRequest request)
	{
		return base.Channel.WsERP_FormaPagamento_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_FormaPagamento_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, FormaPagamentoWsModel[] formasPagamento, string hostName)
	{
		WsERP_FormaPagamento_SetarRequest wsERP_FormaPagamento_SetarRequest = new WsERP_FormaPagamento_SetarRequest();
		wsERP_FormaPagamento_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_FormaPagamento_SetarRequest.cnpj = cnpj;
		wsERP_FormaPagamento_SetarRequest.formasPagamento = formasPagamento;
		wsERP_FormaPagamento_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_FormaPagamento_Setar(wsERP_FormaPagamento_SetarRequest).WsERP_FormaPagamento_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TipoPedido_SetResponse WsErpSoap.WsERP_TipoPedido_Set(WsERP_TipoPedido_SetRequest request)
	{
		return base.Channel.WsERP_TipoPedido_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_TipoPedido_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, TipoPedidoWsModel[] tiposPedido)
	{
		WsERP_TipoPedido_SetRequest wsERP_TipoPedido_SetRequest = new WsERP_TipoPedido_SetRequest();
		wsERP_TipoPedido_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TipoPedido_SetRequest.cnpj = cnpj;
		wsERP_TipoPedido_SetRequest.tiposPedido = tiposPedido;
		return ((WsErpSoap)this).WsERP_TipoPedido_Set(wsERP_TipoPedido_SetRequest).WsERP_TipoPedido_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TipoPedido_SetarResponse WsErpSoap.WsERP_TipoPedido_Setar(WsERP_TipoPedido_SetarRequest request)
	{
		return base.Channel.WsERP_TipoPedido_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_TipoPedido_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, TipoPedidoWsModel[] tiposPedido, string hostName)
	{
		WsERP_TipoPedido_SetarRequest wsERP_TipoPedido_SetarRequest = new WsERP_TipoPedido_SetarRequest();
		wsERP_TipoPedido_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TipoPedido_SetarRequest.cnpj = cnpj;
		wsERP_TipoPedido_SetarRequest.tiposPedido = tiposPedido;
		wsERP_TipoPedido_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_TipoPedido_Setar(wsERP_TipoPedido_SetarRequest).WsERP_TipoPedido_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TipoCusto_SetResponse WsErpSoap.WsERP_TipoCusto_Set(WsERP_TipoCusto_SetRequest request)
	{
		return base.Channel.WsERP_TipoCusto_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_TipoCusto_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, TipoCustoWsModel[] tiposCusto)
	{
		WsERP_TipoCusto_SetRequest wsERP_TipoCusto_SetRequest = new WsERP_TipoCusto_SetRequest();
		wsERP_TipoCusto_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TipoCusto_SetRequest.cnpj = cnpj;
		wsERP_TipoCusto_SetRequest.tiposCusto = tiposCusto;
		return ((WsErpSoap)this).WsERP_TipoCusto_Set(wsERP_TipoCusto_SetRequest).WsERP_TipoCusto_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TipoCusto_SetarResponse WsErpSoap.WsERP_TipoCusto_Setar(WsERP_TipoCusto_SetarRequest request)
	{
		return base.Channel.WsERP_TipoCusto_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_TipoCusto_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, TipoCustoWsModel[] tiposCusto, string hostName)
	{
		WsERP_TipoCusto_SetarRequest wsERP_TipoCusto_SetarRequest = new WsERP_TipoCusto_SetarRequest();
		wsERP_TipoCusto_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TipoCusto_SetarRequest.cnpj = cnpj;
		wsERP_TipoCusto_SetarRequest.tiposCusto = tiposCusto;
		wsERP_TipoCusto_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_TipoCusto_Setar(wsERP_TipoCusto_SetarRequest).WsERP_TipoCusto_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Vendedor_SetResponse WsErpSoap.WsERP_Vendedor_Set(WsERP_Vendedor_SetRequest request)
	{
		return base.Channel.WsERP_Vendedor_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Vendedor_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, VendedorWsModel[] vendedores)
	{
		WsERP_Vendedor_SetRequest wsERP_Vendedor_SetRequest = new WsERP_Vendedor_SetRequest();
		wsERP_Vendedor_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Vendedor_SetRequest.cnpj = cnpj;
		wsERP_Vendedor_SetRequest.vendedores = vendedores;
		return ((WsErpSoap)this).WsERP_Vendedor_Set(wsERP_Vendedor_SetRequest).WsERP_Vendedor_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Vendedor_SetarResponse WsErpSoap.WsERP_Vendedor_Setar(WsERP_Vendedor_SetarRequest request)
	{
		return base.Channel.WsERP_Vendedor_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Vendedor_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, VendedorWsModel[] vendedores, string hostName)
	{
		WsERP_Vendedor_SetarRequest wsERP_Vendedor_SetarRequest = new WsERP_Vendedor_SetarRequest();
		wsERP_Vendedor_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Vendedor_SetarRequest.cnpj = cnpj;
		wsERP_Vendedor_SetarRequest.vendedores = vendedores;
		wsERP_Vendedor_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Vendedor_Setar(wsERP_Vendedor_SetarRequest).WsERP_Vendedor_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_ProdutoErp_SetResponse WsErpSoap.WsERP_ProdutoErp_Set(WsERP_ProdutoErp_SetRequest request)
	{
		return base.Channel.WsERP_ProdutoErp_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_ProdutoErp_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, ProdutoErpWsModel[] produtos)
	{
		WsERP_ProdutoErp_SetRequest wsERP_ProdutoErp_SetRequest = new WsERP_ProdutoErp_SetRequest();
		wsERP_ProdutoErp_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_ProdutoErp_SetRequest.cnpj = cnpj;
		wsERP_ProdutoErp_SetRequest.produtos = produtos;
		return ((WsErpSoap)this).WsERP_ProdutoErp_Set(wsERP_ProdutoErp_SetRequest).WsERP_ProdutoErp_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_ProdutoErp_SetarResponse WsErpSoap.WsERP_ProdutoErp_Setar(WsERP_ProdutoErp_SetarRequest request)
	{
		return base.Channel.WsERP_ProdutoErp_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_ProdutoErp_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, ProdutoErpWsModel[] produtos, string hostName)
	{
		WsERP_ProdutoErp_SetarRequest wsERP_ProdutoErp_SetarRequest = new WsERP_ProdutoErp_SetarRequest();
		wsERP_ProdutoErp_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_ProdutoErp_SetarRequest.cnpj = cnpj;
		wsERP_ProdutoErp_SetarRequest.produtos = produtos;
		wsERP_ProdutoErp_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_ProdutoErp_Setar(wsERP_ProdutoErp_SetarRequest).WsERP_ProdutoErp_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_ProdutoErpSku_SetarResponse WsErpSoap.WsERP_ProdutoErpSku_Setar(WsERP_ProdutoErpSku_SetarRequest request)
	{
		return base.Channel.WsERP_ProdutoErpSku_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_ProdutoErpSku_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, ProdutoErpSkuWsModel[] produtos, string hostName)
	{
		WsERP_ProdutoErpSku_SetarRequest wsERP_ProdutoErpSku_SetarRequest = new WsERP_ProdutoErpSku_SetarRequest();
		wsERP_ProdutoErpSku_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_ProdutoErpSku_SetarRequest.cnpj = cnpj;
		wsERP_ProdutoErpSku_SetarRequest.produtos = produtos;
		wsERP_ProdutoErpSku_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_ProdutoErpSku_Setar(wsERP_ProdutoErpSku_SetarRequest).WsERP_ProdutoErpSku_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TGTFatMesAno_SetResponse WsErpSoap.WsERP_TGTFatMesAno_Set(WsERP_TGTFatMesAno_SetRequest request)
	{
		return base.Channel.WsERP_TGTFatMesAno_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_TGTFatMesAno_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, TGTFatMesAnoWsModel[] listaItens, string hostName)
	{
		WsERP_TGTFatMesAno_SetRequest wsERP_TGTFatMesAno_SetRequest = new WsERP_TGTFatMesAno_SetRequest();
		wsERP_TGTFatMesAno_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TGTFatMesAno_SetRequest.cnpj = cnpj;
		wsERP_TGTFatMesAno_SetRequest.listaItens = listaItens;
		wsERP_TGTFatMesAno_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_TGTFatMesAno_Set(wsERP_TGTFatMesAno_SetRequest).WsERP_TGTFatMesAno_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_TGTFatMesAnoFabric_SetResponse WsErpSoap.WsERP_TGTFatMesAnoFabric_Set(WsERP_TGTFatMesAnoFabric_SetRequest request)
	{
		return base.Channel.WsERP_TGTFatMesAnoFabric_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_TGTFatMesAnoFabric_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, TGTFatMesAnoFabricWsModel[] listaItens, string hostName)
	{
		WsERP_TGTFatMesAnoFabric_SetRequest wsERP_TGTFatMesAnoFabric_SetRequest = new WsERP_TGTFatMesAnoFabric_SetRequest();
		wsERP_TGTFatMesAnoFabric_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_TGTFatMesAnoFabric_SetRequest.cnpj = cnpj;
		wsERP_TGTFatMesAnoFabric_SetRequest.listaItens = listaItens;
		wsERP_TGTFatMesAnoFabric_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_TGTFatMesAnoFabric_Set(wsERP_TGTFatMesAnoFabric_SetRequest).WsERP_TGTFatMesAnoFabric_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Fabricante_SetResponse WsErpSoap.WsERP_Fabricante_Set(WsERP_Fabricante_SetRequest request)
	{
		return base.Channel.WsERP_Fabricante_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Fabricante_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, FabricanteWsModel[] fabricantes)
	{
		WsERP_Fabricante_SetRequest wsERP_Fabricante_SetRequest = new WsERP_Fabricante_SetRequest();
		wsERP_Fabricante_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Fabricante_SetRequest.cnpj = cnpj;
		wsERP_Fabricante_SetRequest.fabricantes = fabricantes;
		return ((WsErpSoap)this).WsERP_Fabricante_Set(wsERP_Fabricante_SetRequest).WsERP_Fabricante_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Fabricante_SetarResponse WsErpSoap.WsERP_Fabricante_Setar(WsERP_Fabricante_SetarRequest request)
	{
		return base.Channel.WsERP_Fabricante_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Fabricante_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, FabricanteWsModel[] fabricantes, string hostName)
	{
		WsERP_Fabricante_SetarRequest wsERP_Fabricante_SetarRequest = new WsERP_Fabricante_SetarRequest();
		wsERP_Fabricante_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Fabricante_SetarRequest.cnpj = cnpj;
		wsERP_Fabricante_SetarRequest.fabricantes = fabricantes;
		wsERP_Fabricante_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Fabricante_Setar(wsERP_Fabricante_SetarRequest).WsERP_Fabricante_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Linha_SetResponse WsErpSoap.WsERP_Linha_Set(WsERP_Linha_SetRequest request)
	{
		return base.Channel.WsERP_Linha_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Linha_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, LinhaWsModel[] linhas)
	{
		WsERP_Linha_SetRequest wsERP_Linha_SetRequest = new WsERP_Linha_SetRequest();
		wsERP_Linha_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Linha_SetRequest.cnpj = cnpj;
		wsERP_Linha_SetRequest.linhas = linhas;
		return ((WsErpSoap)this).WsERP_Linha_Set(wsERP_Linha_SetRequest).WsERP_Linha_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Linha_SetarResponse WsErpSoap.WsERP_Linha_Setar(WsERP_Linha_SetarRequest request)
	{
		return base.Channel.WsERP_Linha_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Linha_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, LinhaWsModel[] linhas, string hostName)
	{
		WsERP_Linha_SetarRequest wsERP_Linha_SetarRequest = new WsERP_Linha_SetarRequest();
		wsERP_Linha_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Linha_SetarRequest.cnpj = cnpj;
		wsERP_Linha_SetarRequest.linhas = linhas;
		wsERP_Linha_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Linha_Setar(wsERP_Linha_SetarRequest).WsERP_Linha_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CategoriaProduto_SetResponse WsErpSoap.WsERP_CategoriaProduto_Set(WsERP_CategoriaProduto_SetRequest request)
	{
		return base.Channel.WsERP_CategoriaProduto_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_CategoriaProduto_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, CategoriaProdutoWsModel[] categorias)
	{
		WsERP_CategoriaProduto_SetRequest wsERP_CategoriaProduto_SetRequest = new WsERP_CategoriaProduto_SetRequest();
		wsERP_CategoriaProduto_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CategoriaProduto_SetRequest.cnpj = cnpj;
		wsERP_CategoriaProduto_SetRequest.categorias = categorias;
		return ((WsErpSoap)this).WsERP_CategoriaProduto_Set(wsERP_CategoriaProduto_SetRequest).WsERP_CategoriaProduto_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CategoriaProduto_SetarResponse WsErpSoap.WsERP_CategoriaProduto_Setar(WsERP_CategoriaProduto_SetarRequest request)
	{
		return base.Channel.WsERP_CategoriaProduto_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_CategoriaProduto_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, CategoriaProdutoWsModel[] categorias, string hostName)
	{
		WsERP_CategoriaProduto_SetarRequest wsERP_CategoriaProduto_SetarRequest = new WsERP_CategoriaProduto_SetarRequest();
		wsERP_CategoriaProduto_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CategoriaProduto_SetarRequest.cnpj = cnpj;
		wsERP_CategoriaProduto_SetarRequest.categorias = categorias;
		wsERP_CategoriaProduto_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_CategoriaProduto_Setar(wsERP_CategoriaProduto_SetarRequest).WsERP_CategoriaProduto_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Equipe_SetResponse WsErpSoap.WsERP_Equipe_Set(WsERP_Equipe_SetRequest request)
	{
		return base.Channel.WsERP_Equipe_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Equipe_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, EquipeWsModel[] listaItens)
	{
		WsERP_Equipe_SetRequest wsERP_Equipe_SetRequest = new WsERP_Equipe_SetRequest();
		wsERP_Equipe_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Equipe_SetRequest.cnpj = cnpj;
		wsERP_Equipe_SetRequest.hostName = hostName;
		wsERP_Equipe_SetRequest.listaItens = listaItens;
		return ((WsErpSoap)this).WsERP_Equipe_Set(wsERP_Equipe_SetRequest).WsERP_Equipe_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_AcaVisitas_SetResponse WsErpSoap.WsERP_AcaVisitas_Set(WsERP_AcaVisitas_SetRequest request)
	{
		return base.Channel.WsERP_AcaVisitas_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_AcaVisitas_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, AcaVisitasWsModel[] listaItens)
	{
		WsERP_AcaVisitas_SetRequest wsERP_AcaVisitas_SetRequest = new WsERP_AcaVisitas_SetRequest();
		wsERP_AcaVisitas_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_AcaVisitas_SetRequest.cnpj = cnpj;
		wsERP_AcaVisitas_SetRequest.hostName = hostName;
		wsERP_AcaVisitas_SetRequest.listaItens = listaItens;
		return ((WsErpSoap)this).WsERP_AcaVisitas_Set(wsERP_AcaVisitas_SetRequest).WsERP_AcaVisitas_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_ClienteERP_SetResponse WsErpSoap.WsERP_ClienteERP_Set(WsERP_ClienteERP_SetRequest request)
	{
		return base.Channel.WsERP_ClienteERP_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_ClienteERP_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, ClienteERPWsModel[] listaItens)
	{
		WsERP_ClienteERP_SetRequest wsERP_ClienteERP_SetRequest = new WsERP_ClienteERP_SetRequest();
		wsERP_ClienteERP_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_ClienteERP_SetRequest.cnpj = cnpj;
		wsERP_ClienteERP_SetRequest.hostName = hostName;
		wsERP_ClienteERP_SetRequest.listaItens = listaItens;
		return ((WsErpSoap)this).WsERP_ClienteERP_Set(wsERP_ClienteERP_SetRequest).WsERP_ClienteERP_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_RowId_GetResponse WsErpSoap.WsERP_RowId_Get(WsERP_RowId_GetRequest request)
	{
		return base.Channel.WsERP_RowId_Get(request);
	}

	public byte[] WsERP_RowId_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, EnumModel modelo)
	{
		WsERP_RowId_GetRequest wsERP_RowId_GetRequest = new WsERP_RowId_GetRequest();
		wsERP_RowId_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_RowId_GetRequest.cnpj = cnpj;
		wsERP_RowId_GetRequest.modelo = modelo;
		return ((WsErpSoap)this).WsERP_RowId_Get(wsERP_RowId_GetRequest).WsERP_RowId_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_RowId_GetV2Response WsErpSoap.WsERP_RowId_GetV2(WsERP_RowId_GetV2Request request)
	{
		return base.Channel.WsERP_RowId_GetV2(request);
	}

	public byte[] WsERP_RowId_GetV2(ValidationSoapHeader ValidationSoapHeader, string cnpj, EnumModel modelo, string hostname)
	{
		WsERP_RowId_GetV2Request wsERP_RowId_GetV2Request = new WsERP_RowId_GetV2Request();
		wsERP_RowId_GetV2Request.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_RowId_GetV2Request.cnpj = cnpj;
		wsERP_RowId_GetV2Request.modelo = modelo;
		wsERP_RowId_GetV2Request.hostname = hostname;
		return ((WsErpSoap)this).WsERP_RowId_GetV2(wsERP_RowId_GetV2Request).WsERP_RowId_GetV2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Replicacao_SetResponse WsErpSoap.WsERP_Replicacao_Set(WsERP_Replicacao_SetRequest request)
	{
		return base.Channel.WsERP_Replicacao_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Replicacao_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, string tabela, string versaoRetaguarda, string dadosReplicacao)
	{
		WsERP_Replicacao_SetRequest wsERP_Replicacao_SetRequest = new WsERP_Replicacao_SetRequest();
		wsERP_Replicacao_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Replicacao_SetRequest.cnpj = cnpj;
		wsERP_Replicacao_SetRequest.hostName = hostName;
		wsERP_Replicacao_SetRequest.tabela = tabela;
		wsERP_Replicacao_SetRequest.versaoRetaguarda = versaoRetaguarda;
		wsERP_Replicacao_SetRequest.dadosReplicacao = dadosReplicacao;
		return ((WsErpSoap)this).WsERP_Replicacao_Set(wsERP_Replicacao_SetRequest).WsERP_Replicacao_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Replicacao_SetarResponse WsErpSoap.WsERP_Replicacao_Setar(WsERP_Replicacao_SetarRequest request)
	{
		return base.Channel.WsERP_Replicacao_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_Replicacao_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, string tabela, string versaoRetaguarda, string dadosReplicacao, int totalLinhas)
	{
		WsERP_Replicacao_SetarRequest wsERP_Replicacao_SetarRequest = new WsERP_Replicacao_SetarRequest();
		wsERP_Replicacao_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Replicacao_SetarRequest.cnpj = cnpj;
		wsERP_Replicacao_SetarRequest.hostName = hostName;
		wsERP_Replicacao_SetarRequest.tabela = tabela;
		wsERP_Replicacao_SetarRequest.versaoRetaguarda = versaoRetaguarda;
		wsERP_Replicacao_SetarRequest.dadosReplicacao = dadosReplicacao;
		wsERP_Replicacao_SetarRequest.totalLinhas = totalLinhas;
		return ((WsErpSoap)this).WsERP_Replicacao_Setar(wsERP_Replicacao_SetarRequest).WsERP_Replicacao_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Replicacao_GetResponse WsErpSoap.WsERP_Replicacao_Get(WsERP_Replicacao_GetRequest request)
	{
		return base.Channel.WsERP_Replicacao_Get(request);
	}

	public RetornoWsModelOfString WsERP_Replicacao_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, string tabela, string versaoRetaguarda, byte[] rowId)
	{
		WsERP_Replicacao_GetRequest wsERP_Replicacao_GetRequest = new WsERP_Replicacao_GetRequest();
		wsERP_Replicacao_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Replicacao_GetRequest.cnpj = cnpj;
		wsERP_Replicacao_GetRequest.hostName = hostName;
		wsERP_Replicacao_GetRequest.tabela = tabela;
		wsERP_Replicacao_GetRequest.versaoRetaguarda = versaoRetaguarda;
		wsERP_Replicacao_GetRequest.rowId = rowId;
		return ((WsErpSoap)this).WsERP_Replicacao_Get(wsERP_Replicacao_GetRequest).WsERP_Replicacao_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_FrequenciaVisita_SetResponse WsErpSoap.WsERP_FrequenciaVisita_Set(WsERP_FrequenciaVisita_SetRequest request)
	{
		return base.Channel.WsERP_FrequenciaVisita_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_FrequenciaVisita_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, FrequenciaVisitaWsModel[] listaItens)
	{
		WsERP_FrequenciaVisita_SetRequest wsERP_FrequenciaVisita_SetRequest = new WsERP_FrequenciaVisita_SetRequest();
		wsERP_FrequenciaVisita_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_FrequenciaVisita_SetRequest.cnpj = cnpj;
		wsERP_FrequenciaVisita_SetRequest.hostName = hostName;
		wsERP_FrequenciaVisita_SetRequest.listaItens = listaItens;
		return ((WsErpSoap)this).WsERP_FrequenciaVisita_Set(wsERP_FrequenciaVisita_SetRequest).WsERP_FrequenciaVisita_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_VersaoRetaguarda_SetResponse WsErpSoap.WsERP_VersaoRetaguarda_Set(WsERP_VersaoRetaguarda_SetRequest request)
	{
		return base.Channel.WsERP_VersaoRetaguarda_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_VersaoRetaguarda_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, int? major, int? minor, int? build, int? revision)
	{
		WsERP_VersaoRetaguarda_SetRequest wsERP_VersaoRetaguarda_SetRequest = new WsERP_VersaoRetaguarda_SetRequest();
		wsERP_VersaoRetaguarda_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_VersaoRetaguarda_SetRequest.cnpj = cnpj;
		wsERP_VersaoRetaguarda_SetRequest.major = major;
		wsERP_VersaoRetaguarda_SetRequest.minor = minor;
		wsERP_VersaoRetaguarda_SetRequest.build = build;
		wsERP_VersaoRetaguarda_SetRequest.revision = revision;
		return ((WsErpSoap)this).WsERP_VersaoRetaguarda_Set(wsERP_VersaoRetaguarda_SetRequest).WsERP_VersaoRetaguarda_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_VersaoRetaguarda_SetarResponse WsErpSoap.WsERP_VersaoRetaguarda_Setar(WsERP_VersaoRetaguarda_SetarRequest request)
	{
		return base.Channel.WsERP_VersaoRetaguarda_Setar(request);
	}

	public RetornoWsModelOfBoolean WsERP_VersaoRetaguarda_Setar(ValidationSoapHeader ValidationSoapHeader, string cnpj, int? major, int? minor, int? build, int? revision, string hostName)
	{
		WsERP_VersaoRetaguarda_SetarRequest wsERP_VersaoRetaguarda_SetarRequest = new WsERP_VersaoRetaguarda_SetarRequest();
		wsERP_VersaoRetaguarda_SetarRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_VersaoRetaguarda_SetarRequest.cnpj = cnpj;
		wsERP_VersaoRetaguarda_SetarRequest.major = major;
		wsERP_VersaoRetaguarda_SetarRequest.minor = minor;
		wsERP_VersaoRetaguarda_SetarRequest.build = build;
		wsERP_VersaoRetaguarda_SetarRequest.revision = revision;
		wsERP_VersaoRetaguarda_SetarRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_VersaoRetaguarda_Setar(wsERP_VersaoRetaguarda_SetarRequest).WsERP_VersaoRetaguarda_SetarResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_VersaoRetaguarda_GetResponse WsErpSoap.WsERP_VersaoRetaguarda_Get(WsERP_VersaoRetaguarda_GetRequest request)
	{
		return base.Channel.WsERP_VersaoRetaguarda_Get(request);
	}

	public RetornoWsModelOfProdutoVersaoWsModel WsERP_VersaoRetaguarda_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int major, int minor, int build, int revision, bool comArquivo, string hostName)
	{
		WsERP_VersaoRetaguarda_GetRequest wsERP_VersaoRetaguarda_GetRequest = new WsERP_VersaoRetaguarda_GetRequest();
		wsERP_VersaoRetaguarda_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_VersaoRetaguarda_GetRequest.cnpj = cnpj;
		wsERP_VersaoRetaguarda_GetRequest.major = major;
		wsERP_VersaoRetaguarda_GetRequest.minor = minor;
		wsERP_VersaoRetaguarda_GetRequest.build = build;
		wsERP_VersaoRetaguarda_GetRequest.revision = revision;
		wsERP_VersaoRetaguarda_GetRequest.comArquivo = comArquivo;
		wsERP_VersaoRetaguarda_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_VersaoRetaguarda_Get(wsERP_VersaoRetaguarda_GetRequest).WsERP_VersaoRetaguarda_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_VersaoRetaguardaPedEle_GetResponse WsErpSoap.WsERP_VersaoRetaguardaPedEle_Get(WsERP_VersaoRetaguardaPedEle_GetRequest request)
	{
		return base.Channel.WsERP_VersaoRetaguardaPedEle_Get(request);
	}

	public RetornoWsModelOfProdutoVersaoWsModel WsERP_VersaoRetaguardaPedEle_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int major, int minor, int build, int revision, bool comArquivo)
	{
		WsERP_VersaoRetaguardaPedEle_GetRequest wsERP_VersaoRetaguardaPedEle_GetRequest = new WsERP_VersaoRetaguardaPedEle_GetRequest();
		wsERP_VersaoRetaguardaPedEle_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_VersaoRetaguardaPedEle_GetRequest.cnpj = cnpj;
		wsERP_VersaoRetaguardaPedEle_GetRequest.major = major;
		wsERP_VersaoRetaguardaPedEle_GetRequest.minor = minor;
		wsERP_VersaoRetaguardaPedEle_GetRequest.build = build;
		wsERP_VersaoRetaguardaPedEle_GetRequest.revision = revision;
		wsERP_VersaoRetaguardaPedEle_GetRequest.comArquivo = comArquivo;
		return ((WsErpSoap)this).WsERP_VersaoRetaguardaPedEle_Get(wsERP_VersaoRetaguardaPedEle_GetRequest).WsERP_VersaoRetaguardaPedEle_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_VersaoRetaguardaPedEle_GetPermissaoResponse WsErpSoap.WsERP_VersaoRetaguardaPedEle_GetPermissao(WsERP_VersaoRetaguardaPedEle_GetPermissaoRequest request)
	{
		return base.Channel.WsERP_VersaoRetaguardaPedEle_GetPermissao(request);
	}

	public RetornoWsModelOfBoolean WsERP_VersaoRetaguardaPedEle_GetPermissao(ValidationSoapHeader ValidationSoapHeader, string cnpj)
	{
		WsERP_VersaoRetaguardaPedEle_GetPermissaoRequest wsERP_VersaoRetaguardaPedEle_GetPermissaoRequest = new WsERP_VersaoRetaguardaPedEle_GetPermissaoRequest();
		wsERP_VersaoRetaguardaPedEle_GetPermissaoRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_VersaoRetaguardaPedEle_GetPermissaoRequest.cnpj = cnpj;
		return ((WsErpSoap)this).WsERP_VersaoRetaguardaPedEle_GetPermissao(wsERP_VersaoRetaguardaPedEle_GetPermissaoRequest).WsERP_VersaoRetaguardaPedEle_GetPermissaoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_VersaoRetaguardaPedEle_SetResponse WsErpSoap.WsERP_VersaoRetaguardaPedEle_Set(WsERP_VersaoRetaguardaPedEle_SetRequest request)
	{
		return base.Channel.WsERP_VersaoRetaguardaPedEle_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_VersaoRetaguardaPedEle_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, int? major, int? minor, int? build, int? revision)
	{
		WsERP_VersaoRetaguardaPedEle_SetRequest wsERP_VersaoRetaguardaPedEle_SetRequest = new WsERP_VersaoRetaguardaPedEle_SetRequest();
		wsERP_VersaoRetaguardaPedEle_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_VersaoRetaguardaPedEle_SetRequest.cnpj = cnpj;
		wsERP_VersaoRetaguardaPedEle_SetRequest.major = major;
		wsERP_VersaoRetaguardaPedEle_SetRequest.minor = minor;
		wsERP_VersaoRetaguardaPedEle_SetRequest.build = build;
		wsERP_VersaoRetaguardaPedEle_SetRequest.revision = revision;
		return ((WsErpSoap)this).WsERP_VersaoRetaguardaPedEle_Set(wsERP_VersaoRetaguardaPedEle_SetRequest).WsERP_VersaoRetaguardaPedEle_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Notificacao_GetResponse WsErpSoap.WsERP_Notificacao_Get(WsERP_Notificacao_GetRequest request)
	{
		return base.Channel.WsERP_Notificacao_Get(request);
	}

	public RetornoWsModelOfInt32 WsERP_Notificacao_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		WsERP_Notificacao_GetRequest wsERP_Notificacao_GetRequest = new WsERP_Notificacao_GetRequest();
		wsERP_Notificacao_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Notificacao_GetRequest.cnpj = cnpj;
		wsERP_Notificacao_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Notificacao_Get(wsERP_Notificacao_GetRequest).WsERP_Notificacao_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Notificacao_SetResponse WsErpSoap.WsERP_Notificacao_Set(WsERP_Notificacao_SetRequest request)
	{
		return base.Channel.WsERP_Notificacao_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Notificacao_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, NotificacaoWsModel[] notificacoes, string hostName)
	{
		WsERP_Notificacao_SetRequest wsERP_Notificacao_SetRequest = new WsERP_Notificacao_SetRequest();
		wsERP_Notificacao_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Notificacao_SetRequest.cnpj = cnpj;
		wsERP_Notificacao_SetRequest.notificacoes = notificacoes;
		wsERP_Notificacao_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Notificacao_Set(wsERP_Notificacao_SetRequest).WsERP_Notificacao_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CoordenadaCliente_GetResponse WsErpSoap.WsERP_CoordenadaCliente_Get(WsERP_CoordenadaCliente_GetRequest request)
	{
		return base.Channel.WsERP_CoordenadaCliente_Get(request);
	}

	public RetornoWsModelOfListOfCoordenadaClienteWsModel WsERP_CoordenadaCliente_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		WsERP_CoordenadaCliente_GetRequest wsERP_CoordenadaCliente_GetRequest = new WsERP_CoordenadaCliente_GetRequest();
		wsERP_CoordenadaCliente_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CoordenadaCliente_GetRequest.cnpj = cnpj;
		wsERP_CoordenadaCliente_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_CoordenadaCliente_Get(wsERP_CoordenadaCliente_GetRequest).WsERP_CoordenadaCliente_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CoordenadaCliente_SetImportResponse WsErpSoap.WsERP_CoordenadaCliente_SetImport(WsERP_CoordenadaCliente_SetImportRequest request)
	{
		return base.Channel.WsERP_CoordenadaCliente_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_CoordenadaCliente_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, int idCoordenadaCliente)
	{
		WsERP_CoordenadaCliente_SetImportRequest wsERP_CoordenadaCliente_SetImportRequest = new WsERP_CoordenadaCliente_SetImportRequest();
		wsERP_CoordenadaCliente_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CoordenadaCliente_SetImportRequest.cnpj = cnpj;
		wsERP_CoordenadaCliente_SetImportRequest.hostName = hostName;
		wsERP_CoordenadaCliente_SetImportRequest.idCoordenadaCliente = idCoordenadaCliente;
		return ((WsErpSoap)this).WsERP_CoordenadaCliente_SetImport(wsERP_CoordenadaCliente_SetImportRequest).WsERP_CoordenadaCliente_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Gondola_GetResponse WsErpSoap.WsERP_Gondola_Get(WsERP_Gondola_GetRequest request)
	{
		return base.Channel.WsERP_Gondola_Get(request);
	}

	public RetornoWsModelOfListOfGondolaWsModel WsERP_Gondola_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		WsERP_Gondola_GetRequest wsERP_Gondola_GetRequest = new WsERP_Gondola_GetRequest();
		wsERP_Gondola_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Gondola_GetRequest.cnpj = cnpj;
		wsERP_Gondola_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Gondola_Get(wsERP_Gondola_GetRequest).WsERP_Gondola_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Gondola_SetImportResponse WsErpSoap.WsERP_Gondola_SetImport(WsERP_Gondola_SetImportRequest request)
	{
		return base.Channel.WsERP_Gondola_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_Gondola_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, int idGondola)
	{
		WsERP_Gondola_SetImportRequest wsERP_Gondola_SetImportRequest = new WsERP_Gondola_SetImportRequest();
		wsERP_Gondola_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Gondola_SetImportRequest.cnpj = cnpj;
		wsERP_Gondola_SetImportRequest.hostName = hostName;
		wsERP_Gondola_SetImportRequest.idGondola = idGondola;
		return ((WsErpSoap)this).WsERP_Gondola_SetImport(wsERP_Gondola_SetImportRequest).WsERP_Gondola_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_DistribuidoraEDI_SetResponse WsErpSoap.WsERP_DistribuidoraEDI_Set(WsERP_DistribuidoraEDI_SetRequest request)
	{
		return base.Channel.WsERP_DistribuidoraEDI_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_DistribuidoraEDI_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, DistribuidoraEDIWsModel distribuidoraEDI)
	{
		WsERP_DistribuidoraEDI_SetRequest wsERP_DistribuidoraEDI_SetRequest = new WsERP_DistribuidoraEDI_SetRequest();
		wsERP_DistribuidoraEDI_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_DistribuidoraEDI_SetRequest.cnpj = cnpj;
		wsERP_DistribuidoraEDI_SetRequest.distribuidoraEDI = distribuidoraEDI;
		return ((WsErpSoap)this).WsERP_DistribuidoraEDI_Set(wsERP_DistribuidoraEDI_SetRequest).WsERP_DistribuidoraEDI_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pagamento_GetResponse WsErpSoap.WsERP_Pagamento_Get(WsERP_Pagamento_GetRequest request)
	{
		return base.Channel.WsERP_Pagamento_Get(request);
	}

	public RetornoWsModelOfListOfPagamentoWsModel WsERP_Pagamento_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		WsERP_Pagamento_GetRequest wsERP_Pagamento_GetRequest = new WsERP_Pagamento_GetRequest();
		wsERP_Pagamento_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pagamento_GetRequest.cnpj = cnpj;
		wsERP_Pagamento_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Pagamento_Get(wsERP_Pagamento_GetRequest).WsERP_Pagamento_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Pagamento_SetImportResponse WsErpSoap.WsERP_Pagamento_SetImport(WsERP_Pagamento_SetImportRequest request)
	{
		return base.Channel.WsERP_Pagamento_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_Pagamento_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, int IdPagamento)
	{
		WsERP_Pagamento_SetImportRequest wsERP_Pagamento_SetImportRequest = new WsERP_Pagamento_SetImportRequest();
		wsERP_Pagamento_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Pagamento_SetImportRequest.cnpj = cnpj;
		wsERP_Pagamento_SetImportRequest.hostName = hostName;
		wsERP_Pagamento_SetImportRequest.IdPagamento = IdPagamento;
		return ((WsErpSoap)this).WsERP_Pagamento_SetImport(wsERP_Pagamento_SetImportRequest).WsERP_Pagamento_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_RelatorioTrabalhoVendedor_GetNewsResponse WsErpSoap.WsERP_RelatorioTrabalhoVendedor_GetNews(WsERP_RelatorioTrabalhoVendedor_GetNewsRequest request)
	{
		return base.Channel.WsERP_RelatorioTrabalhoVendedor_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_RelatorioTrabalhoVendedor_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj, byte[] rowId, string hostName)
	{
		WsERP_RelatorioTrabalhoVendedor_GetNewsRequest wsERP_RelatorioTrabalhoVendedor_GetNewsRequest = new WsERP_RelatorioTrabalhoVendedor_GetNewsRequest();
		wsERP_RelatorioTrabalhoVendedor_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_RelatorioTrabalhoVendedor_GetNewsRequest.cnpj = cnpj;
		wsERP_RelatorioTrabalhoVendedor_GetNewsRequest.rowId = rowId;
		wsERP_RelatorioTrabalhoVendedor_GetNewsRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_RelatorioTrabalhoVendedor_GetNews(wsERP_RelatorioTrabalhoVendedor_GetNewsRequest).WsERP_RelatorioTrabalhoVendedor_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_RelatorioTrabalhoVendedor_GetResponse WsErpSoap.WsERP_RelatorioTrabalhoVendedor_Get(WsERP_RelatorioTrabalhoVendedor_GetRequest request)
	{
		return base.Channel.WsERP_RelatorioTrabalhoVendedor_Get(request);
	}

	public RetornoWsModelOfRelatorioTrabalhoVendedorWsModel WsERP_RelatorioTrabalhoVendedor_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdRelatorioTrabalhoVendedor, string hostName)
	{
		WsERP_RelatorioTrabalhoVendedor_GetRequest wsERP_RelatorioTrabalhoVendedor_GetRequest = new WsERP_RelatorioTrabalhoVendedor_GetRequest();
		wsERP_RelatorioTrabalhoVendedor_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_RelatorioTrabalhoVendedor_GetRequest.cnpj = cnpj;
		wsERP_RelatorioTrabalhoVendedor_GetRequest.IdRelatorioTrabalhoVendedor = IdRelatorioTrabalhoVendedor;
		wsERP_RelatorioTrabalhoVendedor_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_RelatorioTrabalhoVendedor_Get(wsERP_RelatorioTrabalhoVendedor_GetRequest).WsERP_RelatorioTrabalhoVendedor_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsResponse WsErpSoap.WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews(WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest request)
	{
		return base.Channel.WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj, byte[] rowId, string hostName)
	{
		WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest wsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest = new WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest();
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest.cnpj = cnpj;
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest.rowId = rowId;
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_CoordenadaRoteiroVendedorPermanencia_GetNews(wsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsRequest).WsERP_CoordenadaRoteiroVendedorPermanencia_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CoordenadaRoteiroVendedorPermanencia_GetResponse WsErpSoap.WsERP_CoordenadaRoteiroVendedorPermanencia_Get(WsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest request)
	{
		return base.Channel.WsERP_CoordenadaRoteiroVendedorPermanencia_Get(request);
	}

	public RetornoWsModelOfCoordenadaRoteiroVendedorPermanenciaWsModel WsERP_CoordenadaRoteiroVendedorPermanencia_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdCoordenadaRoteiroVendedorPermanencia, string hostName)
	{
		WsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest wsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest = new WsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest();
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest.cnpj = cnpj;
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest.IdCoordenadaRoteiroVendedorPermanencia = IdCoordenadaRoteiroVendedorPermanencia;
		wsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_CoordenadaRoteiroVendedorPermanencia_Get(wsERP_CoordenadaRoteiroVendedorPermanencia_GetRequest).WsERP_CoordenadaRoteiroVendedorPermanencia_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CategoriaAnotacao_GetNewsResponse WsErpSoap.WsERP_CategoriaAnotacao_GetNews(WsERP_CategoriaAnotacao_GetNewsRequest request)
	{
		return base.Channel.WsERP_CategoriaAnotacao_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_CategoriaAnotacao_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj, byte[] rowId, string hostName)
	{
		WsERP_CategoriaAnotacao_GetNewsRequest wsERP_CategoriaAnotacao_GetNewsRequest = new WsERP_CategoriaAnotacao_GetNewsRequest();
		wsERP_CategoriaAnotacao_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CategoriaAnotacao_GetNewsRequest.cnpj = cnpj;
		wsERP_CategoriaAnotacao_GetNewsRequest.rowId = rowId;
		wsERP_CategoriaAnotacao_GetNewsRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_CategoriaAnotacao_GetNews(wsERP_CategoriaAnotacao_GetNewsRequest).WsERP_CategoriaAnotacao_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CategoriaAnotacao_GetResponse WsErpSoap.WsERP_CategoriaAnotacao_Get(WsERP_CategoriaAnotacao_GetRequest request)
	{
		return base.Channel.WsERP_CategoriaAnotacao_Get(request);
	}

	public RetornoWsModelOfCategoriaAnotacaoWsModel WsERP_CategoriaAnotacao_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdCategoriaAnotacao, string hostName)
	{
		WsERP_CategoriaAnotacao_GetRequest wsERP_CategoriaAnotacao_GetRequest = new WsERP_CategoriaAnotacao_GetRequest();
		wsERP_CategoriaAnotacao_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CategoriaAnotacao_GetRequest.cnpj = cnpj;
		wsERP_CategoriaAnotacao_GetRequest.IdCategoriaAnotacao = IdCategoriaAnotacao;
		wsERP_CategoriaAnotacao_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_CategoriaAnotacao_Get(wsERP_CategoriaAnotacao_GetRequest).WsERP_CategoriaAnotacao_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Anotacao_GetNewsResponse WsErpSoap.WsERP_Anotacao_GetNews(WsERP_Anotacao_GetNewsRequest request)
	{
		return base.Channel.WsERP_Anotacao_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_Anotacao_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		WsERP_Anotacao_GetNewsRequest wsERP_Anotacao_GetNewsRequest = new WsERP_Anotacao_GetNewsRequest();
		wsERP_Anotacao_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Anotacao_GetNewsRequest.cnpj = cnpj;
		wsERP_Anotacao_GetNewsRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Anotacao_GetNews(wsERP_Anotacao_GetNewsRequest).WsERP_Anotacao_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Anotacao_GetResponse WsErpSoap.WsERP_Anotacao_Get(WsERP_Anotacao_GetRequest request)
	{
		return base.Channel.WsERP_Anotacao_Get(request);
	}

	public RetornoWsModelOfAnotacaoWsModel WsERP_Anotacao_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdAnotacao, string hostName)
	{
		WsERP_Anotacao_GetRequest wsERP_Anotacao_GetRequest = new WsERP_Anotacao_GetRequest();
		wsERP_Anotacao_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Anotacao_GetRequest.cnpj = cnpj;
		wsERP_Anotacao_GetRequest.IdAnotacao = IdAnotacao;
		wsERP_Anotacao_GetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Anotacao_Get(wsERP_Anotacao_GetRequest).WsERP_Anotacao_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Anotacao_SetImportResponse WsErpSoap.WsERP_Anotacao_SetImport(WsERP_Anotacao_SetImportRequest request)
	{
		return base.Channel.WsERP_Anotacao_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_Anotacao_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, int IdAnotacao, string hostName)
	{
		WsERP_Anotacao_SetImportRequest wsERP_Anotacao_SetImportRequest = new WsERP_Anotacao_SetImportRequest();
		wsERP_Anotacao_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Anotacao_SetImportRequest.cnpj = cnpj;
		wsERP_Anotacao_SetImportRequest.IdAnotacao = IdAnotacao;
		wsERP_Anotacao_SetImportRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Anotacao_SetImport(wsERP_Anotacao_SetImportRequest).WsERP_Anotacao_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_ComoRealizouVenda_SetResponse WsErpSoap.WsERP_ComoRealizouVenda_Set(WsERP_ComoRealizouVenda_SetRequest request)
	{
		return base.Channel.WsERP_ComoRealizouVenda_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_ComoRealizouVenda_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, ComoRealizouVendaWsModel[] comoRealizouVendas, string hostName)
	{
		WsERP_ComoRealizouVenda_SetRequest wsERP_ComoRealizouVenda_SetRequest = new WsERP_ComoRealizouVenda_SetRequest();
		wsERP_ComoRealizouVenda_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_ComoRealizouVenda_SetRequest.cnpj = cnpj;
		wsERP_ComoRealizouVenda_SetRequest.comoRealizouVendas = comoRealizouVendas;
		wsERP_ComoRealizouVenda_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_ComoRealizouVenda_Set(wsERP_ComoRealizouVenda_SetRequest).WsERP_ComoRealizouVenda_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Promotor_SetResponse WsErpSoap.WsERP_Promotor_Set(WsERP_Promotor_SetRequest request)
	{
		return base.Channel.WsERP_Promotor_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Promotor_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, PromotorWsModel[] promotores, string hostName)
	{
		WsERP_Promotor_SetRequest wsERP_Promotor_SetRequest = new WsERP_Promotor_SetRequest();
		wsERP_Promotor_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Promotor_SetRequest.cnpj = cnpj;
		wsERP_Promotor_SetRequest.promotores = promotores;
		wsERP_Promotor_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Promotor_Set(wsERP_Promotor_SetRequest).WsERP_Promotor_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_EquipePromotor_SetResponse WsErpSoap.WsERP_EquipePromotor_Set(WsERP_EquipePromotor_SetRequest request)
	{
		return base.Channel.WsERP_EquipePromotor_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_EquipePromotor_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, EquipePromotorWsModel[] equipePromotor, string hostName)
	{
		WsERP_EquipePromotor_SetRequest wsERP_EquipePromotor_SetRequest = new WsERP_EquipePromotor_SetRequest();
		wsERP_EquipePromotor_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_EquipePromotor_SetRequest.cnpj = cnpj;
		wsERP_EquipePromotor_SetRequest.equipePromotor = equipePromotor;
		wsERP_EquipePromotor_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_EquipePromotor_Set(wsERP_EquipePromotor_SetRequest).WsERP_EquipePromotor_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_GerenciaPromotor_SetResponse WsErpSoap.WsERP_GerenciaPromotor_Set(WsERP_GerenciaPromotor_SetRequest request)
	{
		return base.Channel.WsERP_GerenciaPromotor_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_GerenciaPromotor_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, GerenciaPromotorWsModel[] gerenciaPromotor, string hostName)
	{
		WsERP_GerenciaPromotor_SetRequest wsERP_GerenciaPromotor_SetRequest = new WsERP_GerenciaPromotor_SetRequest();
		wsERP_GerenciaPromotor_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_GerenciaPromotor_SetRequest.cnpj = cnpj;
		wsERP_GerenciaPromotor_SetRequest.gerenciaPromotor = gerenciaPromotor;
		wsERP_GerenciaPromotor_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_GerenciaPromotor_Set(wsERP_GerenciaPromotor_SetRequest).WsERP_GerenciaPromotor_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_Area_SetResponse WsErpSoap.WsERP_Area_Set(WsERP_Area_SetRequest request)
	{
		return base.Channel.WsERP_Area_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_Area_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, AreaWsModel[] area, string hostName)
	{
		WsERP_Area_SetRequest wsERP_Area_SetRequest = new WsERP_Area_SetRequest();
		wsERP_Area_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_Area_SetRequest.cnpj = cnpj;
		wsERP_Area_SetRequest.area = area;
		wsERP_Area_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_Area_Set(wsERP_Area_SetRequest).WsERP_Area_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_RamAtiv_SetResponse WsErpSoap.WsERP_RamAtiv_Set(WsERP_RamAtiv_SetRequest request)
	{
		return base.Channel.WsERP_RamAtiv_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_RamAtiv_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, RamAtivWsModel[] ramAtiv, string hostName)
	{
		WsERP_RamAtiv_SetRequest wsERP_RamAtiv_SetRequest = new WsERP_RamAtiv_SetRequest();
		wsERP_RamAtiv_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_RamAtiv_SetRequest.cnpj = cnpj;
		wsERP_RamAtiv_SetRequest.ramAtiv = ramAtiv;
		wsERP_RamAtiv_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_RamAtiv_Set(wsERP_RamAtiv_SetRequest).WsERP_RamAtiv_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_GrupoCli_SetResponse WsErpSoap.WsERP_GrupoCli_Set(WsERP_GrupoCli_SetRequest request)
	{
		return base.Channel.WsERP_GrupoCli_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_GrupoCli_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, GrupoCliWsModel[] grupoCli, string hostName)
	{
		WsERP_GrupoCli_SetRequest wsERP_GrupoCli_SetRequest = new WsERP_GrupoCli_SetRequest();
		wsERP_GrupoCli_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_GrupoCli_SetRequest.cnpj = cnpj;
		wsERP_GrupoCli_SetRequest.grupoCli = grupoCli;
		wsERP_GrupoCli_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_GrupoCli_Set(wsERP_GrupoCli_SetRequest).WsERP_GrupoCli_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MonitoramentoGeracao_SetResponse WsErpSoap.WsERP_MonitoramentoGeracao_Set(WsERP_MonitoramentoGeracao_SetRequest request)
	{
		return base.Channel.WsERP_MonitoramentoGeracao_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_MonitoramentoGeracao_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, MonitoramentoGeracaoWsModel[] listaItens, string hostName)
	{
		WsERP_MonitoramentoGeracao_SetRequest wsERP_MonitoramentoGeracao_SetRequest = new WsERP_MonitoramentoGeracao_SetRequest();
		wsERP_MonitoramentoGeracao_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MonitoramentoGeracao_SetRequest.cnpj = cnpj;
		wsERP_MonitoramentoGeracao_SetRequest.listaItens = listaItens;
		wsERP_MonitoramentoGeracao_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_MonitoramentoGeracao_Set(wsERP_MonitoramentoGeracao_SetRequest).WsERP_MonitoramentoGeracao_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MonitoramentoRetaguarda_SetResponse WsErpSoap.WsERP_MonitoramentoRetaguarda_Set(WsERP_MonitoramentoRetaguarda_SetRequest request)
	{
		return base.Channel.WsERP_MonitoramentoRetaguarda_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_MonitoramentoRetaguarda_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, MonitRetagWsModel[] listaItens, string hostName)
	{
		WsERP_MonitoramentoRetaguarda_SetRequest wsERP_MonitoramentoRetaguarda_SetRequest = new WsERP_MonitoramentoRetaguarda_SetRequest();
		wsERP_MonitoramentoRetaguarda_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MonitoramentoRetaguarda_SetRequest.cnpj = cnpj;
		wsERP_MonitoramentoRetaguarda_SetRequest.listaItens = listaItens;
		wsERP_MonitoramentoRetaguarda_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_MonitoramentoRetaguarda_Set(wsERP_MonitoramentoRetaguarda_SetRequest).WsERP_MonitoramentoRetaguarda_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MonitGerarDados_SetResponse WsErpSoap.WsERP_MonitGerarDados_Set(WsERP_MonitGerarDados_SetRequest request)
	{
		return base.Channel.WsERP_MonitGerarDados_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_MonitGerarDados_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, MonitGerarDadosWsModel monitGerarDadosWsModel, string hostName)
	{
		WsERP_MonitGerarDados_SetRequest wsERP_MonitGerarDados_SetRequest = new WsERP_MonitGerarDados_SetRequest();
		wsERP_MonitGerarDados_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MonitGerarDados_SetRequest.cnpj = cnpj;
		wsERP_MonitGerarDados_SetRequest.monitGerarDadosWsModel = monitGerarDadosWsModel;
		wsERP_MonitGerarDados_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_MonitGerarDados_Set(wsERP_MonitGerarDados_SetRequest).WsERP_MonitGerarDados_SetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CoordenadaResidencia_GetNewsResponse WsErpSoap.WsERP_CoordenadaResidencia_GetNews(WsERP_CoordenadaResidencia_GetNewsRequest request)
	{
		return base.Channel.WsERP_CoordenadaResidencia_GetNews(request);
	}

	public RetornoWsModelOfListOfInt32 WsERP_CoordenadaResidencia_GetNews(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName)
	{
		WsERP_CoordenadaResidencia_GetNewsRequest wsERP_CoordenadaResidencia_GetNewsRequest = new WsERP_CoordenadaResidencia_GetNewsRequest();
		wsERP_CoordenadaResidencia_GetNewsRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CoordenadaResidencia_GetNewsRequest.cnpj = cnpj;
		wsERP_CoordenadaResidencia_GetNewsRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_CoordenadaResidencia_GetNews(wsERP_CoordenadaResidencia_GetNewsRequest).WsERP_CoordenadaResidencia_GetNewsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CoordenadaResidencia_GetResponse WsErpSoap.WsERP_CoordenadaResidencia_Get(WsERP_CoordenadaResidencia_GetRequest request)
	{
		return base.Channel.WsERP_CoordenadaResidencia_Get(request);
	}

	public RetornoWsModelOfCoordenadaResidenciaWsModel WsERP_CoordenadaResidencia_Get(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, int IdCoordenadaResidencia)
	{
		WsERP_CoordenadaResidencia_GetRequest wsERP_CoordenadaResidencia_GetRequest = new WsERP_CoordenadaResidencia_GetRequest();
		wsERP_CoordenadaResidencia_GetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CoordenadaResidencia_GetRequest.cnpj = cnpj;
		wsERP_CoordenadaResidencia_GetRequest.hostName = hostName;
		wsERP_CoordenadaResidencia_GetRequest.IdCoordenadaResidencia = IdCoordenadaResidencia;
		return ((WsErpSoap)this).WsERP_CoordenadaResidencia_Get(wsERP_CoordenadaResidencia_GetRequest).WsERP_CoordenadaResidencia_GetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_CoordenadaResidencia_SetImportResponse WsErpSoap.WsERP_CoordenadaResidencia_SetImport(WsERP_CoordenadaResidencia_SetImportRequest request)
	{
		return base.Channel.WsERP_CoordenadaResidencia_SetImport(request);
	}

	public RetornoWsModelOfBoolean WsERP_CoordenadaResidencia_SetImport(ValidationSoapHeader ValidationSoapHeader, string cnpj, string hostName, int IdCoordenadaResidencia)
	{
		WsERP_CoordenadaResidencia_SetImportRequest wsERP_CoordenadaResidencia_SetImportRequest = new WsERP_CoordenadaResidencia_SetImportRequest();
		wsERP_CoordenadaResidencia_SetImportRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_CoordenadaResidencia_SetImportRequest.cnpj = cnpj;
		wsERP_CoordenadaResidencia_SetImportRequest.hostName = hostName;
		wsERP_CoordenadaResidencia_SetImportRequest.IdCoordenadaResidencia = IdCoordenadaResidencia;
		return ((WsErpSoap)this).WsERP_CoordenadaResidencia_SetImport(wsERP_CoordenadaResidencia_SetImportRequest).WsERP_CoordenadaResidencia_SetImportResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WsERP_MPAgenda_SetResponse WsErpSoap.WsERP_MPAgenda_Set(WsERP_MPAgenda_SetRequest request)
	{
		return base.Channel.WsERP_MPAgenda_Set(request);
	}

	public RetornoWsModelOfBoolean WsERP_MPAgenda_Set(ValidationSoapHeader ValidationSoapHeader, string cnpj, MPAgendaWsModel[] listaItens, string hostName)
	{
		WsERP_MPAgenda_SetRequest wsERP_MPAgenda_SetRequest = new WsERP_MPAgenda_SetRequest();
		wsERP_MPAgenda_SetRequest.ValidationSoapHeader = ValidationSoapHeader;
		wsERP_MPAgenda_SetRequest.cnpj = cnpj;
		wsERP_MPAgenda_SetRequest.listaItens = listaItens;
		wsERP_MPAgenda_SetRequest.hostName = hostName;
		return ((WsErpSoap)this).WsERP_MPAgenda_Set(wsERP_MPAgenda_SetRequest).WsERP_MPAgenda_SetResult;
	}
}
