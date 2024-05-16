using System;
using System.Linq.Expressions;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class ClienteDAL : EntidadeBaseDAL<ClienteMO>
{
	protected override Expression<Func<ClienteMO, bool>> GetWhere(Expression<Func<ClienteMO, bool>> whereClause, ClienteMO exemplo)
	{
		if (exemplo.CODIGO_CLIENTE > 0)
		{
			whereClause = whereClause.And((ClienteMO x) => x.CODIGO_CLIENTE == exemplo.CODIGO_CLIENTE);
		}
		return whereClause;
	}

	public bool VerificarSeEhPrimeiraCompra(int codigoCliente)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("   SELECT CAST( CASE WHEN COUNT(1) = 0 THEN 1 ELSE 0 END AS BIT) AS CLIENTE_NOVO\r\n                            FROM ped_vda p WITH (NOLOCK)\r\n                            JOIN it_pedv i WITH (NOLOCK)\r\n                            ON p.cd_emp = i.cd_emp AND p.nu_ped = i.nu_ped\r\n                            WHERE p.situacao = 'AB'\r\n                            AND i.situacao = 'FA' ");
		stringBuilder.AppendFormat(" AND p.cd_clien = {0}", codigoCliente);
		return ExecutarScalarSQL<bool>(stringBuilder.ToString(), Array.Empty<object>());
	}

	public bool FaltaAlgumDocumentoParaPermitirVenda(ClienteMO cliente)
	{
		string select = "  SELECT CAST( CASE WHEN COUNT(1) > 0 \r\n\t\t\t                           THEN 1 ELSE 0 END AS BIT)\r\n                                 AS  FALTA_ALGUM_DOCUMENTO\r\n                            FROM cliente cl\r\n                            JOIN RamAtivTpDoc rt on  cl.ram_ativ = rt.RamAtiv\r\n                           WHERE cl.cd_clien = {0}\r\n                             AND rt.CdDoc NOT IN (SELECT CdDoc\r\n\t\t\t\t\t                               FROM ClientePermComp\r\n\t\t\t\t                                  WHERE CdClien = cl.cd_clien)  ";
		return ExecutarScalarSQL<bool>(select, new object[1] { cliente.CODIGO_CLIENTE });
	}

	public bool SituacaoCreditoValido(ClienteMO cliente)
	{
		string select = "SELECT CAST(ISNULL(MAX(1),0) AS BIT)\r\n                        FROM st_cred a\r\n                        WHERE a.st_cred = {0}";
		return ExecutarScalarSQL<bool>(select, new object[1] { cliente.SITUACAO_CREDITO });
	}

	public void AtualizaTransportadora(PedidoVendaMO pedido)
	{
		string comando = " UPDATE cliente\r\n                            SET cd_forn = {0},\r\n                                tp_frete = {1}\r\n                            WHERE cd_clien = {2}";
		ExecutarSqlCommand(comando, pedido.CODIGO_FORNECEDOR, pedido.TIPO_FRETE, pedido.CODIGO_CLIENTE);
	}

	public void AtualizaCondicaoComercialPadrao_Cliente(TipoPedidoVO tipoPedido, ClienteMO cliente)
	{
		string text = "";
		text = ((!tipoPedido.VENDA_ESPECIAL) ? " venda_especial = 0 " : " venda_especial = 1 ");
		if (tipoPedido.GERA_TITULO_RECEBER)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text += ", ";
			}
			text += $"tp_ped = '{tipoPedido.CODIGO_TIPO_PEDIDO}'";
		}
		if (!string.IsNullOrEmpty(text))
		{
			text += " WHERE cd_clien = {0}";
			string comando = "UPDATE cliente set " + text;
			ExecutarSqlCommand(comando, cliente.CODIGO_CLIENTE);
		}
	}

	public void AtualizaCondicaoComercialPadrao_ClienteEmpresa(PedidoVendaMO pedidoVenda)
	{
		string comando = "UPDATE cli_emp\r\n                           SET seq_prom = {0}, \r\n                               cd_tabela = {1}\r\n                           WHERE cd_emp = {2}\r\n                             AND cd_clien = {3} ";
		ExecutarSqlCommand(comando, pedidoVenda.SEQ_PROMOCAO, pedidoVenda.CODIGO_TABELA, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.CODIGO_CLIENTE);
	}

	public void AtualizaCondComercialPadrao_ClienteEmpresaFormaPagamento(PedidoVendaMO pedidoVenda)
	{
		string comando = "DELETE FROM cli_emp_formpgto\r\n                           WHERE cd_emp = {0}\r\n                             AND cd_clien = {1}\r\n                             AND formpgto = {2} ";
		ExecutarSqlCommand(comando, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.CODIGO_CLIENTE, pedidoVenda.FORMA_PAGAMENTO);
		string comando2 = "UPDATE cli_emp_formpgto\r\n                                 SET principal = {0}\r\n                                 WHERE cd_emp = {1}\r\n                                   AND cd_clien = {1} ";
		ExecutarSqlCommand(comando2, 0, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.CODIGO_CLIENTE);
		string comando3 = " INSERT INTO cli_emp_formpgto\r\n                                  ( cd_emp,\r\n                                    cd_clien,\r\n                                    formpgto,\r\n                                    principal\r\n                                  ) \r\n                                  VALUES\r\n                                  (\r\n                                  {0},\r\n                                  {1},\r\n                                  {2},\r\n                                  {3}\r\n                                  ) ";
		ExecutarSqlCommand(comando3, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.CODIGO_CLIENTE, pedidoVenda.FORMA_PAGAMENTO, 1);
	}

	public void AtualizaCondComercialPadrao_ClienteCondicaoPagto(PedidoVendaMO pedidoVenda)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("    SELECT 1 \r\n                                    WHERE NOT EXISTS (  SELECT 1\r\n                                                        FROM clienprm\r\n                                                        WHERE cd_clien = {0}\r\n                                                        AND seq_prom = {1} ) ", pedidoVenda.CODIGO_CLIENTE, pedidoVenda.SEQ_PROMOCAO);
		int value = ExecutarScalarSQL<int>(stringBuilder.ToString(), Array.Empty<object>());
		if (Convert.ToBoolean(value))
		{
			string comando = " INSERT INTO clienprm\r\n                            ( cd_clien,\r\n                              seq_prom )\r\n                             VALUES\r\n                                  (\r\n                                  {0},\r\n                                  {1} \r\n                                  ) ;\r\n                ";
			ExecutarSqlCommand(comando, pedidoVenda.CODIGO_CLIENTE, pedidoVenda.SEQ_PROMOCAO);
		}
	}

	public bool VerificaICMSDiferido(ClienteMO clienteMO)
	{
		string select = " SELECT  CONVERT(BIT,1)\r\n                            FROM  cliente c\r\n                            JOIN tributacao_cli t ON t.seq_trib_cli = c.seq_trib_cli\r\n                                                 AND  t.icms_diferido = 1\r\n                            WHERE  c.cd_clien = {0} ";
		return ExecutarScalarSQL<bool>(select, new object[1] { clienteMO.CODIGO_CLIENTE });
	}

	public decimal BuscaValorLimitePedidoPF(ClienteMO cliente, int codigoEmpresa)
	{
		string select = "SELECT CONVERT(NUMERIC(13,2),ISNULL(vl_lim_ped_pf,0))\r\n                           FROM cli_emp\r\n                           WHERE\r\n                                cd_clien = {0}\r\n                           AND  cd_emp = {1}";
		return ExecutarScalarSQL<decimal>(select, new object[2] { cliente.CODIGO_CLIENTE, codigoEmpresa });
	}

	public decimal BuscaValorPedidosMes(ClienteMO cliente)
	{
		string select = "SELECT\tISNULL( fat.vl_soma, 0 ) + ISNULL( abe.vl_soma, 0 )\r\n\t                       FROM\t(\t\r\n                                    SELECT\tSUM( itp.vl_unit_vda * itp.qtde_unid_vda - ISNULL( itp.vl_desc_geral, 0 ) ) vl_soma\r\n\t\t\t                        FROM\t\r\n                                            ped_vda ped\r\n\t\t\t\t                            JOIN\tit_pedv itp\r\n\t\t\t\t                            ON\tped.cd_emp = itp.cd_emp\r\n\t\t\t\t                            AND\tped.nu_ped = itp.nu_ped\r\n\t\t\t\t                            JOIN\ttp_ped tip\r\n\t\t\t\t                            ON\tped.tp_ped = tip.tp_ped\r\n\t\t\t                        WHERE\t\r\n                                            tip.pedido_pf_x_pj = 1\r\n\t\t\t                        AND     itp.situacao = 'FA'\r\n\t\t\t                        AND\t    ped.cd_clien = {0}\r\n\t\t\t                        AND\t    itp.dt_fatur >= LTRIM(RTRIM(STR(YEAR( GETDATE())))) + '-' + LTRIM(RTRIM(STR(MONTH( GETDATE())))) + '-' + '01'\r\n                                ) fat,\r\n\t\t                        (\t\r\n                                    SELECT\tSUM( itp.vl_unit_vda * ( ISNULL( tip.perc_nota, 1 ) ) * itp.qtde_unid_vda - ISNULL( itp.vl_desc_geral, 0 ) ) vl_soma\r\n\t\t\t                        FROM\t\r\n                                        ped_vda ped\r\n\t\t\t\t                        JOIN\tit_pedv itp\r\n\t\t\t\t                        ON\tped.cd_emp = itp.cd_emp\r\n\t\t\t\t                        AND\tped.nu_ped = itp.nu_ped\r\n\t\t\t\t                        JOIN\ttp_ped tip\r\n\t\t\t\t                        ON\tped.tp_ped = tip.tp_ped\r\n\t\t\t                        WHERE\t\r\n                                            tip.pedido_pf_x_pj = 1\r\n\t\t\t                        AND     itp.situacao = 'AB'\r\n\t\t\t                        AND\t    ped.cd_clien = {0}\r\n\t\t\t                        AND\t    ped.dt_ped >= LTRIM(RTRIM(STR(YEAR( GETDATE())))) + '-' + LTRIM(RTRIM(STR(MONTH( GETDATE())))) + '-' + '01'\r\n                                )  abe";
		return ExecutarScalarSQL<decimal>(select, new object[1] { cliente.CODIGO_CLIENTE });
	}
}
