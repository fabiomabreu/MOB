namespace Target.Venda.Business.Texto;

public static class MensagemString
{
	public const string CAMPO_PEDIDO_ELETRONICO_NAO_INFORMADO = "{0} do pedido eletrônico não informado.";

	public const string ENDERECO_DESATUALIZADO = "O Endereço: {0}, está desatualizado. Os campos Logradouro, Número e País devem estar preenchidos.";

	public const string PARAMETRO_MARGEM_BRUTA_INVALIDA = "Parâmetros de exibição de margem cadastrados de maneira inválida. Solicite a alteração da configuração do sistema.";

	public const string DOCUMENTOS_INVALIDOS = "Existem documentos associados ao segmento do cliente que precisam ser inclusos no cadastro do cliente.";

	public const string VENDEDOR_INATIVO = "O vendedor: {0}, está inativo.";

	public const string PARAMETRO_LIBERAR_PEDIDO_ELETRONICO_NULL = "O parametros necessarios para a liberaração do pedido eletronico não foram informados";

	public const string KIT_ITEM_NAO_ASSOCIADO_PROMOCAO = "Promoção do Produto: {0}, não está associada a Condição de Pagamento.";

	public const string FORMA_PAGAMENTO_NAO_PERMITIDA = "Forma de Pagamento: {0}, não permitida para {1}.";

	public const string DESCONTO_GERAL_INVALIDO = "Não é permitido o Desconto Geral negativo em pedidos NF-e.";

	public const string SITUACAO_CREDITO = "O Cliente: {0}, sem Situação de Crédito cadastrada.";

	public const string CLIENTE_OUTRA_ENTREGA = "Outro Cliente de Entrega não foi definido, ou está inativo.";

	public const string TRANSPORTADORA_NAO_INFORMADA = "Código da Transportadora deve ser informado para o Tipo de Entrega \"TR\".";

	public const string CFOP_INVALIDO = "Não foi possível definir um código fiscal de operação (CFOP) válida.";

	public const string EXISTE_PROMOCAO_ITEM_ESTOQUE_INSUFICIENTE = "Existe uma promoção nesse item e o estoque é insuficiente.";

	public const string PRECO_PRODUTO_NAO_ENCONTRADO = "Preço do produto não encontrado";

	public const string PEDIDO_CANCELADO_SEM_ITENS = "O pedido foi cancelado pois todos os itens estão sem estoque.";

	public const string CORTE_ITENS_NAO_REALIZADO = "O processo de Corte de Itens do Pedido Eletrônico não foi executado com sucesso.";

	public const string PRODUTO_NAO_ASSOCIOADO_COND_PAGTO = "O produto: {0}, não está associado à condição de pagamento {1}. Faça esta associação ou desassocie e associe novamente caso já exista a associação.";

	public const string ERRO_MONTAR_ITENS_PEDIDO_ELETRONICO = "Ocorreu um erro ao montar os itens do Pedido Eletrônico.";

	public const string TIPO_PEDIDO_INVENTARIO = "O Tipo Pedido informado é do tipo Inventario. Ped. Ele: {0}";

	public const string CORTE_ITENS_ELETRONICO = "Foram cortados {0} produtos do Pedido Eletrônico: {1}";

	public const string TIPO_PEDIDO_NAO_SUPORTADO = "O Tipo de Pedido: {0}, não é suportado pela Interface.";

	public const string VENDEDOR_SEM_EQUIPE = "O vendedor: {0}, está sem Equipe Associada.";

	public const string VENDA_FORA_PAIS = "Não é permitido venda para cliente cujo país seja diferente de Brasil.";

	public const string CLIENTE_PROVISORIO = "O cliente {0} - {1} está com situação provisorio.";

	public const string PESSOA_JURIDICA_INVALIDA = "Para este Tipo de Pedido, o cliente: {0}, deve ser Pessoa Jurídica com CNPJ válido.";

	public const string PARAMETRO_CONFIGURACAO_NAO_SUPORTADO = "O Parametro de Configuração: {0}, não é suportado pela interface.";

	public const string TIPO_PEDIDO_SUFRAMA = "O Tipo de Pedido é Suframa e o Cliente não tem suframa.";

	public const string DESCONTO_MAIOR_MAXIMO_PERMITIDO_PRODUTO = "Desconto maior que o maximo permitido para o produto";

	public const string DESCONTO_PERMITIDO_ITEM_EXTRAPOLADO = "Desconto permitido para o item foi extrapolado";

	public const string PEDIDO_COM_VALOR_ZERADO = "Pedido com valor zerado";

	public const string VALOR_TOTAL_PEDIDO_DIFERENTE_SOMA_PARCELAS = "Valor total do pedido é diferente da soma das parcelas";

	public const string NAO_PERMITIDO_TIPO_PAPEL_CORTADO_COM_NAO_CORTADO = "Não é permitido conter itens do tipo papel cortado com não cortado";

	public const string QUANTIDADE_INVALIDA_ZERO = "Quantidade invalida (zero)";

	public const string PRODUTO_DEVE_SER_VENDIDO_MULTIPLO_UNIDADE = "O produto {0}-{1} só pode ser vendido de {2} em {2} unidades";

	public const string VALOR_TROCAS_MAIOR_VALOR_TOTAL_PEDIDO = "Valor de trocas maior que o valor total do pedido";

	public const string EXISTE_PRODUTOS_NAO_LIBERADOS_FISCAL = "Existem produtos não liberados pela area fiscal";

	public const string GRADE_DESCONTO_NAO_SUPORTADA_PELA_INTERFACE = "Grade de desconto não suportada pela interface";

	public const string DESCONTO_ITEM_ALEM_LIMITES_PERMITIDOS = "Desconto alem dos limites permitidos";

	public const string UNIDADE_VENDA_IGUAL_PEDIDA_FATORES_DIFERENTES = "Unidade de venda igual a pedida com fatores diferentes";

	public const string UNIDADE_VENDA_INATIVA = "Unidade de venda invativa";

	public const string UNIDADE_NAO_EH_DE_VENDA = "Unidade não é uma unidade de venda";

	public const string EXISTEM_PRODUTOS_COM_VALOR_ZERADO = "Os produtos a seguir estão sem preço de venda e não são produtos bonificados: {0}";

	public const string ASSUNTO_EMAIL_ITEM_ACAO_COMERCIAL_ENCERRADA = "Item de ação comercial encerrado";

	public const string ASSUNTO_EMAIL_ACAO_COMERCIAL_ENCERRADA = "Ação comercial encerrado";

	public const string MENSAGEM_EMAIL_ITEM_ACAO_COMERCIAL_ENCERRADA = "O produto {0} - {1}, na ação comercial {2} - {3}, foi encerrado pelo motivo {4}";

	public const string MOTIVO_ENCERRAMENTO_ACAO_COMERCIAL_FALTA_ESTOQUE = "Falta de estoque do produto";

	public const string MOTIVO_ENCERRAMENTO_ACAO_COMERCIAL_QTDE_LIMITE = "Quantidade limite de venda atingida";

	public const string MOTIVO_ENCERRAMENTO_ACAO_COMERCIAL_VALOR_LIMITE = "Valor limite de venda atingido";

	public const string MENSAGEM_EMAIL_ACAO_COMERCIAL_ENCERRADA = "A ação comercial {0} - {1}, foi encerrada pelo motivo {2}";

	public const string SESSAO_ERP_NAO_INICIALIZADA = "Sessão do usuario não inicializada";

	public const string SESSAO_ERP_JA_INICIALIZADA = "Sessão do usuario já inicializada";

	public const string NAO_ENCONTRADO_REGISTRO_PELO_ID = "Não encontrado registro da entidade {0} pelo Id: {1}";

	public const string NAO_ENCONTRADO_REGISTRO_PELOS_FILTROS = "Não encontrado registro da entidade {0} pelo(s) filtro(s): {1}";

	public const string CAMPO_PEDIDO_ELETRONICO_INVALIDO = "{0} Inválido";

	public const string PEDIDO_ELETRONICO_NAO_ENCONTRADO = "Não foi possivel encontrar pedido eletronico pelos filtros. {0}";

	public const string CHAVE_PEDIDO_ELETRONICO = "Empresa: {0}, Numero: {1}, Seq: {2}";

	public const string DESCONTO_INVALIDO_PARA_PRODUTO = "Desconto inválido para o produto: {0}";

	public const string PRODUTOS_LISTADOS_VENCIDOS_SEM_SALDO_ESTOQUE = "Os produtos listados abaixo estão vencidos ou sem saldo no estoque.";

	public const string AJUSTE_PEDIDO_REALIZANDO_CORTE_OU_ALTERACAO_LOTE = "Por favor ajuste o pedido realizando o corte do produto e/ou alterando o lote para dar continuidade à separação.";

	public const string OPERACAO_CANCELADA = "OPERAÇÃO CANCELADA.";

	public static string ENTER = char.ConvertFromUtf32(10);

	public const string HEAD_PEDIDO_PRODUTO = "Pedido                  Produto";

	public const string EXISTEM_PRODUTOS_VENCIDOS_SEM_SALDO_ESTOQUE = "Existe(m) produtos(s) vencidos ou sem saldo no estoque.";

	public const string AVISO = "AVISO";

	public const string PRODUTOS_LISTADOS_INFORMACAO_INCOMPLETA_GRUPO_CATEGORIA = "O(s) produto(s) listado(s) abaixo está(ão) com informação(ões) incompleta(s) de Grupo de Categoria.";

	public const string NECESSARIO_CADASTRAR_GRUPO_ARMAZENAGEM_ENDERECO_SEPARACAO_PRODUTOS_LISTADOS = "Necessário cadastrar Grupo de Categoria de Armazenagem do(s) Endereço(s) de Separação associado(s) ao(s) seguinte(s) produto(s)";

	public const string HEAD_PEDIDO_PRODUTO_ENDERECO = "Pedido                  Produto                  Endereço";

	public const string EVENTO_PEDIDO_ELETRONICO_NAO_ABERTO = "Evento pedido eletronico não está com situação aberto";

	public const string EXISTE_PRODUTOS_NAO_CONFIG_VENDA_PED_ELE = "Existem produtos não configurados para venda no pedido Eletronico: {0}";

	public const string IDENTIFICACAO_PRODUTO = "Produto: {0} - {1}";

	public const string PRODUTO_SEM_GRUPO_COMISSAO = "Produto está sem grupo de comissão cadastrado";

	public const string TIPO_PEDIDO_SEM_LOCAL_ESTOQUE = "Tipo de pedido está sem local de estoque definido";

	public const string PRODUTO_SEM_PRECO_NA_TABELA_PRECOS = "Produto está sem preço definido na tabela de preços {0}";

	public const string PRODUTO_SEM_VALOR_PARCELAS_DEFINIDO = "Produto está sem valor de parcelas definido. Sugestão: reassociar os produtos a todas as condições de pagamento";

	public const string ICMS_NAO_CADASTRADO_PARA_PRODUTO_ESTADO_ENTREGA = " Não está cadastrado o ICMS do produto para o estado do cliente";

	public const string SITUACAO_TRIBUTARIA_NAO_CADASTRADA_PARA_ESTADO_CLIENTE = "Não está cadastrada a situação tributária ( {0} ) para o estado do cliente";

	public const string TABELA_PRECO_NAO_ASSOCIADA_COM_EMPRESA = "Tabela de preços não associada com a empresa do pedido";

	public static string CONDICAO_PAGAMENTO_NAO_ASSOCIADA_EMPRESA = "Condição de pagamento não associada com a empresa do pedido";

	public const string ENDERECO_CLIENTE_DESATUALIZADO = "O endereço do cliente, está desatualizado. Os campos Logradouro, Número e País devem estar preenchidos";

	public const string ENDERECO_EMPRESA_DESATUALIZADO = "O endereço da empresa, está desatualizado. Os campos Logradouro, Número e País devem estar preenchidos";

	public const string CLIENTE_INVATIVO = "O cliente {0} - {1} está invativo";

	public const string CONDICAO_PAGAMENTO_INATIVA = "A condição de pagamento {0} não está ativa";

	public const string CONDICAO_PAGAMENTO_NAO_UTILIZA = "A condição de pagamento {0} não está marcada para utilização na empresa do Pedido.";

	public const string CONDICAO_PAGAMENTO_NAO_PERMITIDA = "A condição de pagamento {0} não permitida para o cliente {1}.";

	public const string PARAMETRO_CANCELAR_PEDIDO_VENDA_NULL = "O parametros necessarios para o cancelamento do pedido venda não foram informados";

	public const string PARAMETRO_CANCELAR_PEDIDO_NAO_INFORMADO = "{0} não informado no processo de cancelamento do pedido de venda.";

	public const string CHAVE_PEDIDO_VENDA = "Empresa: {0}, Numero: {1}";

	public const string PEDIDO_VENDA_NAO_ENCONTRADO = "Não foi possivel encontrar pedido de venda pelos filtros. {0}";

	public const string BLOQUEIA_VENDA_PESSOA_FISICA = "Não é permitida venda para Pessoa Física. Cliente: {0}.";

	public const string ENDERECO_ENTREGA_NAO_INFORMADO = "Endereço de Entrega não informado";

	public const string CEP_ENDERECO_ENTREGA_NAO_INFORMADO = "CEP do Endereço de Entrega não informado.";

	public const string BAIRRO_ENDERECO_ENTREGA_NAO_INFORMADO = "Bairro de Entrega não informado.";

	public const string MUNICIPIO_ENDERECO_ENTREGA_NAO_INFORMADO = "Municipio de Entrega não informado.";

	public const string TIPO_ENTREGA_NAO_INFORMADO = "Tipo de Entrega não foi informado";

	public const string TABELA_PRECO_NAO_INFORMADA = "Tabela de preço não informada";

	public const string TIPO_PEDIDO_NAO_SUPORTA_CONTROLADO = "Tipo de pedido não suporta produtos controlados";

	public const string CFOP_NAO_ENCONTRADO = "CFOP não encontrado";

	public const string CFOP_SIMPLES_REMESSA_NAO_INFORMADO = "CFOP simples remessa não informado";

	public const string CFOP_DEFINIDA_PARA_EMISSAO_NF_INVALIDA = "A CFOP definida para a emissão da NF não é válida. ESTADO ORIGEM: {0} ESTADO DESTINO: {1} CFOP:{2}";

	public const string FAIXA_PESO_FRETE_NAO_CADASTRADO = "Não existe frete cadastrado nessa faixa de CEP para essa transportadora na Faixa de Peso informada.";

	public const string FAIXA_VALOR_FRETE_NAO_CADASTRADO = "Não existe frete cadastrado nessa faixa de valor.";

	public const string FAIXA_VALOR_REG_TRANS_NAO_CADASTRADO = "Não existe valor de frete cadastrado para a transportadora no cep e peso desejado.";

	public const string FRETE_TRANSPORTADORA_NAO_CADASTRADO = "Não existe frete cadastrado nessa faixa de CEP para essa transportadora.";

	public const string NAO_EXISTE_ENDERECO_FINAL_WMS = "Endereço final WMS não encontrado para esta empresa e este local de estoque.";

	public const string PRODUTO_NAO_PERTENCE_GRUPO = "O Produto: {0}, não pertence ao mesmo grupo de produto dos demais itens do pedido.";

	public const string LIMITE_COMPRA_CLIENTE_ULTRAPASSADO = "O limite de compra do cliente {0} foi ultrapassado em R${1}.";

	public const string PEDIDO_COM_VALOR_ACIMA_DO_PERMITO_PARA_PF = "O pedido está com o valor de R${0} acima do permitido de {1}% das vendas totais para pessoa física.";

	public const string FORMA_PAGAMENTO_CARTAO_CREDITO_INVALIDO = "Condição de pagamento não está configurada corretamente para pagamento em cartão de crédito ";

	public const string CONTRATO_CARTAO_CREDITO_INVALIDO = "Contrato de cartão de crédito inativo ou não encontrado na condição de pagamento";

	public const string QUANTIDADE_MAXIMA_DE_PARCELAS_ULTRAPASSADA = "A quantidade máxima de parcelas do Contrato de cartão de crédito foi ultrapassada";

	public const string QUANTIDADE_DE_PARCELAS_NAO_INFORMADA = "A quantidade de parcelas do do pedido não foi informada";

	public const string TIPO_PEDIDO_LOTE_AUTO_SEM_QUANTIDADE = "O tipo de pedido possui o parâmetro de Escolha de Lote automática, mas não há quantidade suficiente.";

	public const string QUANTIDADE_DE_PARCELAS_ZERADA = "A quantidade de parcelas do pedido esta zerada";
}
