using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Configuration;
using Target.Venda.DataAccess.EntityMapping;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.DataAccess.Context;

public class ERPContext : DbContext
{
	public DbSet<AcaoComercialMO> AcaoComercial { get; set; }

	public DbSet<AcaoComercialProdutoMO> AcaoComercialProduto { get; set; }

	public DbSet<AcaoComercialProdutoPrecoMO> AcaoComercialProdutoPreco { get; set; }

	public DbSet<AcaoComercialPromocaoMO> AcaoComercialPromocao { get; set; }

	public DbSet<CalendarioMO> Calendario { get; set; }

	public DbSet<CfopMO> Cfop { get; set; }

	public DbSet<ClienteEmpresaFormaPagamentoMO> ClienteEmpresaFormaPagamento { get; set; }

	public DbSet<ClienteEmpresaMO> ClienteEmpresa { get; set; }

	public DbSet<ClienteMO> Cliente { get; set; }

	public DbSet<ClienteDiaVencimentoMO> ClienteDiaVencimento { get; set; }

	public DbSet<ClientePromocaoMO> ClientePromocao { get; set; }

	public DbSet<ConsultaProdutoMO> ConsultaProduto { get; set; }

	public DbSet<DescontoProdutoMO> DescontoProduto { get; set; }

	public DbSet<EmpresaMO> Empresa { get; set; }

	public DbSet<EnderecoClienteMO> EnderecoCliente { get; set; }

	public DbSet<EnderecoPedidoEletronicoMO> EnderecoPedidoEletronico { get; set; }

	public DbSet<EnderecoPedidoMO> EnderecoPedido { get; set; }

	public DbSet<EquipeMO> Equipe { get; set; }

	public DbSet<EstadoMO> Estado { get; set; }

	public DbSet<EventoAcaoComercialMO> EventoAcaoComercial { get; set; }

	public DbSet<EventoCancelPedidoMO> EventoCancelPedido { get; set; }

	public DbSet<EventoErpVendaMO> EventoErpVenda { get; set; }

	public DbSet<EventoLancamentoVerbaMO> EventoLancamentoVerba { get; set; }

	public DbSet<EventoLogMO> EventoLog { get; set; }

	public DbSet<EventoLogTrocaMO> EventoLogTroca { get; set; }

	public DbSet<EventoMO> Evento { get; set; }

	public DbSet<EstoqueMO> Estoque { get; set; }

	public DbSet<EventoPedidoEletronicoAbertoMO> EventoPedidoEletronicoAberto { get; set; }

	public DbSet<EventoPedidoEletronicoMO> EventoPedidoEletronico { get; set; }

	public DbSet<FaltaProdutoMO> FaltaProduto { get; set; }

	public DbSet<FormaPagamentoPromocaoMO> FormaPagamentoPromocao { get; set; }

	public DbSet<FreteMO> Frete { get; set; }

	public DbSet<IcmsProdutoMO> IcmsProduto { get; set; }

	public DbSet<IntPedidoLiberaProdutoMO> IntPedidoLiberaProduto { get; set; }

	public DbSet<ItemPedidoCompMO> ItemPedidoComp { get; set; }

	public DbSet<ItemPedidoEletronicoMO> ItemPedidoEletronico { get; set; }

	public DbSet<ItemPedidoLocalMO> ItemPedidoLocal { get; set; }

	public DbSet<ItemPedidoMO> ItemPedido { get; set; }

	public DbSet<KitPromocaoPagamentoMO> KitPromocaoPagamento { get; set; }

	public DbSet<LancamentoVerbaMO> LancamentoVerba { get; set; }

	public DbSet<LinhaTextoMO> LinhaTexto { get; set; }

	public DbSet<LocalFaturamentoMO> LocalFaturamento { get; set; }

	public DbSet<LocalMO> Local { get; set; }

	public DbSet<MotivoLancamentoVerbaMO> MotivoLancamentoVerba { get; set; }

	public DbSet<ObservacaoPedidoEletronicoMO> ObservacaoPedidoEletronico { get; set; }

	public DbSet<ObservacaoPedidoMO> ObservacaoPedido { get; set; }

	public DbSet<ParametroConfiguracaoMO> ParametroConfiguracao { get; set; }

	public DbSet<ParametroTelaDetalheMO> ParametrosTelaDetalhes { get; set; }

	public DbSet<ParcelaPedidoMO> ParcelaPedido { get; set; }

	public DbSet<PedidoEletronicoMO> PedidoEletronico { get; set; }

	public DbSet<PedidoVendaMO> PedidoVenda { get; set; }

	public DbSet<PrecoMO> Preco { get; set; }

	public DbSet<ProdutoCustoMO> ProdutoCusto { get; set; }

	public DbSet<ProdutoDescontoPrazoMO> ProdutoDescontoPrazo { get; set; }

	public DbSet<ProdutoMO> Produto { get; set; }

	public DbSet<PromocaoMO> Promocao { get; set; }

	public DbSet<PromocaoParcelasMO> PromocaoParcelas { get; set; }

	public DbSet<RamoAtividadeTipoDocumentoMO> RamoAtividadeTipoDocumento { get; set; }

	public DbSet<RegiaoMO> Regiao { get; set; }

	public DbSet<RegTransMO> RegTrans { get; set; }

	public DbSet<RotaPrdfMO> RotaPrdf { get; set; }

	public DbSet<SiglaSeparacaoMO> SiglaSeparacao { get; set; }

	public DbSet<TextoMO> Texto { get; set; }

	public DbSet<TipoPedidoCfopMO> TipoPedidoCfop { get; set; }

	public DbSet<TipoPedidoMO> TipoPedido { get; set; }

	public DbSet<TipoPedidoLocalMO> TipoPedidoLocal { get; set; }

	public DbSet<TipoPedidoOutrosLocaisMO> TipoPedidoOutrosLocais { get; set; }

	public DbSet<TributacaoClienteMO> TributacaoCliente { get; set; }

	public DbSet<TrocaMO> Troca { get; set; }

	public DbSet<UnidadeProdutoMO> UnidadeProduto { get; set; }

	public DbSet<UsuarioMO> Usuario { get; set; }

	public DbSet<ValorIndiceMO> ValorIndice { get; set; }

	public DbSet<VendedorClienteMO> VendedorCliente { get; set; }

	public DbSet<VendedorMO> Vendedor { get; set; }

	public DbSet<VerbaFabricanteCFGAvisoMO> VerbaFabricanteCFGAviso { get; set; }

	public DbSet<VerbaFabricanteLancamentoMO> VerbaFabricanteLancamento { get; set; }

	public DbSet<VerbaFabricanteTipoLancamentoMO> VerbaFabricanteTipoLancamento { get; set; }

	public DbSet<GrupoComissaoMO> GrupoComissao { get; set; }

	public DbSet<TabelaPrecoMO> TabelaPreco { get; set; }

	public DbSet<PromocaoEmpresaMO> PromocaoEmp { get; set; }

	public DbSet<KitPromocaoMO> KitPromocao { get; set; }

	public DbSet<UnidadeMO> Unidade { get; set; }

	public DbSet<FornecedorMO> Fornecedor { get; set; }

	public DbSet<EnderecoFornecedorMO> EnderecoFornecedor { get; set; }

	public DbSet<LogDesempenhoMO> LogDesempenho { get; set; }

	public DbSet<EventoAlteracaoPrecoMO> EventoAlteracaoPreco { get; set; }

	public DbSet<ContratoOperadoraCartaoCreditoMO> ContratoOperadoraCartaoCredito { get; set; }

	public DbSet<TargetServicosMO> TargetServicos { get; set; }

	public ERPContext(string connectionStrings)
		: base(connectionStrings)
	{
		IniciarContext();
	}

	public ERPContext()
		: base(ConfigHelper.getStringConnection())
	{
		IniciarContext();
	}

	private void IniciarContext()
	{
		base.Configuration.LazyLoadingEnabled = true;
		base.Configuration.ProxyCreationEnabled = false;
		base.Configuration.AutoDetectChangesEnabled = false;
		base.Configuration.ValidateOnSaveEnabled = false;
		((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 0;
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		DecimalPrecision.ConfigureModelBuilder(modelBuilder);
		modelBuilder.Configurations.Add(new PedidoEletronicoMap());
		modelBuilder.Configurations.Add(new PedidoVendaMap());
		modelBuilder.Configurations.Add(new PromocaoMap());
		modelBuilder.Configurations.Add(new FaltaProdutoMap());
		modelBuilder.Properties<BoolEnum>().Configure(delegate(ConventionPrimitivePropertyConfiguration b)
		{
			b.HasColumnType("tinyint");
		});
	}
}
