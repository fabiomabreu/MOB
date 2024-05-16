using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Parametro;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class PedidoVendaDAL : EntidadeBaseDAL<PedidoVendaMO>
{
	protected override Expression<Func<PedidoVendaMO, bool>> GetWhere(Expression<Func<PedidoVendaMO, bool>> whereClause, PedidoVendaMO exemplo)
	{
		throw new NotImplementedException();
	}

	public ResultadoLiberarPedidoErpVO ProcessarLiberacaoPedidoErp(ParametrosLiberarPedidoErpVO paramLiberacaoPedidoErp)
	{
		try
		{
			string procedure = "usp_libera_pedido";
			List<SqlParameter> list = new List<SqlParameter>();
			list.Add(new SqlParameter("@par_str_cd_fila_atual", paramLiberacaoPedidoErp.CODIGO_FILA_ATUAL));
			list.Add(new SqlParameter("@par_nu_cd_emp", paramLiberacaoPedidoErp.CODIGO_EMPRESA));
			list.Add(new SqlParameter("@par_nu_ped", paramLiberacaoPedidoErp.NUMERO_PEDIDO));
			list.Add(new SqlParameter("@par_str_cd_usuario", paramLiberacaoPedidoErp.CODIGO_USUARIO));
			list.Add(new SqlParameter("@par_boo_frete", paramLiberacaoPedidoErp.UTILIZA_FRETE));
			int returnValue = -1;
			DbDataReader dataReader = ExecutarStoredProcedureToDataRead(procedure, list, out returnValue);
			DadosRetornoLiberacaoPedidoVO dADOS_RETORNO = BindDadosRetornoLiberacaoPedido(dataReader);
			return new ResultadoLiberarPedidoErpVO
			{
				CODIGO_ERRO = returnValue,
				DADOS_RETORNO = dADOS_RETORNO
			};
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private DadosRetornoLiberacaoPedidoVO BindDadosRetornoLiberacaoPedido(DbDataReader dataReader)
	{
		DadosRetornoLiberacaoPedidoVO dadosRetornoLiberacaoPedidoVO = new DadosRetornoLiberacaoPedidoVO();
		if (dataReader.FieldCount < 6)
		{
			throw new Exception("Ocorreu um problema no retorno da liberação do pedido no ERP");
		}
		while (dataReader.Read())
		{
			dadosRetornoLiberacaoPedidoVO.CODIGO_FILA_LIBERADO = dataReader[0].ToString();
			dadosRetornoLiberacaoPedidoVO.CODIGO_FILA = dataReader[1].ToString();
			dadosRetornoLiberacaoPedidoVO.PEDIDO_TIPO_ENTREGA = dataReader[2].ToString();
			dadosRetornoLiberacaoPedidoVO.NOME_TABELA_TEMP = dataReader[3].ToString();
			dadosRetornoLiberacaoPedidoVO.CODIGO_CLIENTE = dataReader[4].ToInt();
			dadosRetornoLiberacaoPedidoVO.MENSAGEM_ERRO = dataReader[5].ToString();
		}
		dataReader.Close();
		return dadosRetornoLiberacaoPedidoVO;
	}

	public void CancelarPedido(PedidoVendaMO pedidoVenda, TipoPedidoVO tipoPedido)
	{
		try
		{
			string comando = " UPDATE it_pedv    \r\n                                SET situacao = 'CA'  \r\n                                WHERE nu_ped = {0}\r\n                                  AND cd_emp = {1} ";
			ExecutarSqlCommand(comando, pedidoVenda.NUMERO_PEDIDO, pedidoVenda.CODIGO_EMPRESA);
			comando = " UPDATE ped_vda    \r\n                         SET situacao = 'CA'   \r\n                         WHERE nu_ped = {0}\r\n                           AND cd_emp = {1} ";
			ExecutarSqlCommand(comando, pedidoVenda.NUMERO_PEDIDO, pedidoVenda.CODIGO_EMPRESA);
			if (tipoPedido.OUTROS_LOCAIS_ESTOQUE)
			{
				comando = " UPDATE it_pedv_local\r\n                             SET situacao = 'CA'\r\n                             WHERE cd_emp = {0}\r\n                               AND nu_ped = {1} ";
				ExecutarSqlCommand(comando, pedidoVenda.NUMERO_PEDIDO, pedidoVenda.CODIGO_EMPRESA);
			}
			if (tipoPedido.TRANSFERENCIA_ESTOQUE && tipoPedido.TRANSFERENCIA_OUTROS_LOCAIS_ESTOQUE)
			{
				comando = "UPDATE it_pedv_local\r\n                            SET situacao = 'AB',\r\n                                cd_emp_transf = NULL,\r\n                                nu_ped_transf = NULL\r\n                            WHERE cd_emp_transf = {0}\r\n                              AND nu_ped_transf = {1} ";
				ExecutarSqlCommand(comando, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public override void Insert(PedidoVendaMO pedidoVenda)
	{
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			iTEN.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
			iTEN.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
			if (string.IsNullOrEmpty(iTEN.INDICE_RELACAO_VENDA))
			{
				iTEN.INDICE_RELACAO_VENDA = iTEN.INDICE_RELACAO;
			}
			if (!iTEN.PERCENTUAL_DESCONTO_GERAL.HasValue)
			{
				iTEN.PERCENTUAL_DESCONTO_GERAL = default(decimal);
			}
			if (!iTEN.VALOR_DESCONTO_GERAL.HasValue)
			{
				iTEN.VALOR_DESCONTO_GERAL = default(decimal);
			}
			iTEN.ITENS_LOCAIS.ForEach(delegate(ItemPedidoLocalMO x)
			{
				x.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
				x.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
			});
		}
		pedidoVenda.ENDERECOS.ForEach(delegate(EnderecoPedidoMO x)
		{
			x.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
			x.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		});
		pedidoVenda.OBSERVACOES.ForEach(delegate(ObservacaoPedidoMO x)
		{
			x.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
			x.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		});
		pedidoVenda.PARCELAS.ForEach(delegate(ParcelaPedidoMO x)
		{
			x.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
			x.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		});
		base.Insert(pedidoVenda);
	}

	public List<ErroErpVO> ObterErrosLiberacaoPedido(string nomeTabelaTemporaria)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT e.seq_erro as CODIGO, e.DESCRICAO ");
			stringBuilder.AppendFormat("FROM {0} as e ", nomeTabelaTemporaria);
			return ExecutarSelectSQL<ErroErpVO>(stringBuilder.ToString(), Array.Empty<object>());
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool VerificarPedidoGeraNotaFiscal(PedidoVendaMO pedidoVenda)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("\tSELECT\tCAST(CASE WHEN COUNT(1)  > 0 THEN 1 ELSE 0 END AS BIT) AS PEDIDO_GERA_NF\r\n\t\t\t                              FROM\tped_vda pv\r\n\t\t\t\t                          JOIN  tp_ped tp ON\tpv.tp_ped = tp.tp_ped\r\n\t\t\t                             WHERE\tpv.cd_emp = {0}\r\n\t\t\t                               AND\tpv.nu_ped = {1}\r\n\t\t\t                               AND\t(ISNULL( tp.imprime_nf, 0 ) = 1\t\t\r\n\r\n\t\t\t\t                            OR\t( ISNULL( pv.ent_outcli, 0 ) = 1\r\n\t\t\t\t\t                            AND\tEXISTS( SELECT\t1\r\n\t\t\t\t\t\t\t                            FROM\ttp_ped tpsr\r\n\t\t\t\t\t\t\t                            WHERE\ttpsr.tp_ped = tp.tp_ped_sr\r\n\t\t\t\t\t\t\t                            AND\tISNULL( tpsr.imprime_nf, 0 ) = 1 ) )\r\n\r\n\t\t\t\t                            OR\t( ISNULL( tp.quebra_it_bonif, 0 ) = 1\r\n\t\t\t\t\t                            AND\tEXISTS(\tSELECT\tDISTINCT 1\r\n\t\t\t\t\t\t\t                            FROM\ttp_ped tpb,\r\n\t\t\t\t\t\t\t\t                            it_pedv it\r\n\t\t\t\t\t\t\t                            WHERE\ttpb.tp_ped = tp.tp_ped_bonif\r\n\t\t\t\t\t\t\t                            AND\tISNULL( tpb.imprime_nf, 0 ) = 1\r\n\t\t\t\t\t\t\t                            AND\tit.cd_emp = pv.cd_emp\r\n\t\t\t\t\t\t\t                            AND\tit.nu_ped = pv.nu_ped\r\n\t\t\t\t\t\t\t                            AND\tISNULL( it.bonificado, 0 ) = 1 ) )\r\n\t\t\r\n\t\t\t\t                            OR\t( ISNULL( tp.gera_meia_nota, 0 ) = 1\r\n\t\t\t\t\t                            AND\tEXISTS( SELECT\tDISTINCT 1\r\n\t\t\t\t\t\t\t                            FROM\ttp_ped tpc\r\n\t\t\t\t\t\t\t                            WHERE\ttpc.tp_ped = tp.tp_ped_meia_nota\r\n\t\t\t\t\t\t\t                            AND\tISNULL( tpc.imprime_nf, 0 ) = 1 ) )\t)\t", pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO);
			return ExecutarScalarSQL<bool>(stringBuilder.ToString(), Array.Empty<object>());
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void GerarNumeroPedido(PedidoVendaMO pedidoVendaMO, bool gerarNumeroPedidoSemLock)
	{
		pedidoVendaMO.NUMERO_PEDIDO = GerarSequencial("seq_pedv", pedidoVendaMO.CODIGO_EMPRESA);
		if (gerarNumeroPedidoSemLock)
		{
			InserirControleNumeroPedido(pedidoVendaMO.CODIGO_EMPRESA, pedidoVendaMO.NUMERO_PEDIDO);
		}
	}

	public bool ValidarNumeroPedidoVenda(int codigoEmpresa, int numeroPedido)
	{
		try
		{
			string select = " SELECT CAST(COUNT(1) AS BIT)\r\n                                   FROM ped_vda\r\n                                   WHERE cd_emp = {0}\r\n                                   AND nu_ped = {1}\r\n                                   AND situacao = 'AB'";
			return ExecutarScalarSQL<bool>(select, new object[2] { codigoEmpresa, numeroPedido });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public bool ValidarUtilizaNumeroPedidoSemLock()
	{
		try
		{
			string select = " SELECT CAST(COUNT(1) AS BIT)\r\n                                   FROM sys.objects\r\n                                   WHERE object_id = OBJECT_ID('TGTControleNumeroPedido')";
			return ExecutarScalarSQL<bool>(select, Array.Empty<object>());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private void InserirControleNumeroPedido(int codigoEmpresa, int numeroPedido)
	{
		try
		{
			string comando = " INSERT INTO TGTControleNumeroPedido  (   CdEmp,      NuPed   )  VALUES  (   {0},      {1} ) ";
			ExecutarSqlCommand(comando, codigoEmpresa, numeroPedido);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public decimal BuscaValorTotalPedidosMes(SituacaoPedidoEnum situacaoPedido, TipoPessoaEnum tipoPessoa)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("SELECT ISNULL(CONVERT(NUMERIC(13,2),SUM( ( itp.vl_unit_vda * itp.qtde_unid_vda - ISNULL( itp.vl_desc_geral, 0 ) ) * CASE WHEN tip.tp_quebra_meia_nf = 'VL' THEN ISNULL( tip.perc_nota, 1 ) ELSE 1 END )),0)\r\n\t\t\t                      FROM\t\r\n                                        ped_vda ped\r\n\t\t\t\t                        JOIN\tit_pedv itp\r\n\t\t\t\t                        ON\tped.cd_emp = itp.cd_emp\r\n\t\t\t\t                        AND\tped.nu_ped = itp.nu_ped\r\n\t\t\t\t                        JOIN\ttp_ped tip\r\n\t\t\t\t                        ON\tped.tp_ped = tip.tp_ped\r\n\t\t\t\t                        JOIN\tcliente cli\r\n\t\t\t\t                        ON\tped.cd_clien = cli.cd_clien\r\n\t\t\t                      WHERE\t\r\n                                        tip.pedido_pf_x_pj = 1 ");
		switch (situacaoPedido)
		{
		case SituacaoPedidoEnum.FATURADO:
			stringBuilder.AppendLine("AND\titp.situacao = 'FA'\r\n                                    AND\titp.dt_fatur >= LTRIM(RTRIM(STR(YEAR( GetDate())))) + '-' + LTRIM(RTRIM(STR(MONTH( GetDate())))) + '-' + '01'\r\n                                  ");
			break;
		case SituacaoPedidoEnum.ABERTO:
			stringBuilder.AppendLine("AND\titp.situacao = 'AB'\r\n                                    AND\tped.dt_ped >= LTRIM(RTRIM(STR(YEAR( GetDate())))) + '-' + LTRIM(RTRIM(STR(MONTH( GetDate())))) + '-' + '01'\r\n                                  ");
			break;
		}
		switch (tipoPessoa)
		{
		case TipoPessoaEnum.FISICA:
			stringBuilder.AppendLine("AND\tcli.tp_pes = 'F'");
			break;
		case TipoPessoaEnum.JURIDICA:
			stringBuilder.AppendLine("AND\tcli.tp_pes = 'J'");
			break;
		}
		return ExecutarScalarSQL<decimal>(stringBuilder.ToString(), Array.Empty<object>());
	}

	public void VerificaIntermediador(PedidoVendaMO pedidoVenda, string cnpjIntermediador)
	{
		try
		{
			string select = "\r\n                    SELECT \r\n\t\t                IntermediadorID\r\n\t                FROM\r\n\t\t                Intermediador\r\n\t                WHERE\r\n\t\t                CNPJ = {0}  ";
			int? iNTERMEDIADOR_ID = ExecutarScalarSQL<int?>(select, new object[1] { cnpjIntermediador });
			if (!iNTERMEDIADOR_ID.HasValue)
			{
				string comando = "\r\n                        INSERT INTO Intermediador\r\n\t                    (\r\n\t\t                    CdIntermediador,\r\n\t\t                    Nome,\r\n\t\t                    CNPJ,\r\n\t\t                    Provisorio\r\n\t                    )\r\n\t                    VALUES\r\n                        (\r\n\t\t                    {0},\r\n\t\t                    {1},\r\n\t\t                    {2},\r\n\t\t                    {3}     \r\n                        )   ";
				ExecutarSqlCommand(comando, "TEMP", "PROVISORIO " + DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.DataHora).ToString(), cnpjIntermediador, 1);
				iNTERMEDIADOR_ID = (int)ExecutarScalarSQL<decimal>(" SELECT IDENT_CURRENT('Intermediador') ", Array.Empty<object>());
			}
			pedidoVenda.INTERMEDIADOR_ID = iNTERMEDIADOR_ID;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public int BuscaNuPedMax(int codigoEmpresa)
	{
		try
		{
			string select = " \tSELECT\r\n\t\t                                MAX(nu_ped)+1\r\n\t                                FROM\r\n\t\t                                ped_vda with(nolock)\r\n\t                                WHERE\r\n\t\t                                cd_emp = {0}";
			return ExecutarScalarSQL<int>(select, new object[1] { codigoEmpresa });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AjusteNuPedDuplicateKeyPedVda(int codigoEmpresa, int numeroPedido, int numeroPedidoMax)
	{
		try
		{
			string comando = "INSERT INTO\r\n\t                    OC809337_PedVda\r\n\t                    (\r\n\t\t                    CdEmp,\r\n\t\t                    NuPed,\r\n\t\t                    DtPed,\r\n\t\t                    CdUsuario\r\n\t                    )\r\n\t                    VALUES\r\n\t                    (\r\n\t\t                    {0},\r\n\t\t                    {1},\r\n\t\t                    GETDATE(),\r\n\t\t                    'TgtVendas'\r\n\t                    )";
			ExecutarSqlCommand(comando, codigoEmpresa, numeroPedido);
			comando = " \tUPDATE seq_pedv WITH (ROWLOCK)\r\n\t                        SET\r\n\t\t                        numero = {1}\r\n\t                        WHERE\r\n\t\t                        cd_emp = {0}";
			ExecutarSqlCommand(comando, codigoEmpresa, numeroPedidoMax + 1);
			comando = " UPDATE TGTControleNumeroPedido \r\n                         SET\r\n                            NuPed = {2}\r\n                         WHERE\r\n                             CdEmp = {0}\r\n                         AND NuPed = {1}";
			ExecutarSqlCommand(comando, codigoEmpresa, numeroPedido, numeroPedidoMax);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
