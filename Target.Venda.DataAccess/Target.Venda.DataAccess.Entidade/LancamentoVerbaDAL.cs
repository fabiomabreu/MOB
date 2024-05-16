using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class LancamentoVerbaDAL : EntidadeBaseDAL<LancamentoVerbaMO>
{
	protected override Expression<Func<LancamentoVerbaMO, bool>> GetWhere(Expression<Func<LancamentoVerbaMO, bool>> whereClause, LancamentoVerbaMO exemplo)
	{
		throw new NotImplementedException();
	}

	public void InserirVerbaLancamento(PedidoVendaMO pedidoVenda, LancamentoVerbaMO lancamentoVerbaMO, UsuarioMO usuario)
	{
		string select = "SELECT tipo_dc TIPO_DOCUMENTO\r\n                                  FROM motlcverba\r\n                                 WHERE cd_motlcverba = {0} ";
		string text = ExecutarScalarSQL<string>(select, new object[1] { lancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA });
		if (string.IsNullOrEmpty(text))
		{
			throw new Exception("Inconsistência: motivo de lançamento não cadastrado");
		}
		lancamentoVerbaMO.VALOR = Math.Abs(lancamentoVerbaMO.VALOR);
		if (text == "D")
		{
			lancamentoVerbaMO.VALOR *= -1m;
		}
		ParametroConfiguracaoDAL parametroConfiguracaoDAL = new ParametroConfiguracaoDAL();
		if (parametroConfiguracaoDAL.VerificaExistenciaObjeto("uspLcVerbaInserir"))
		{
			try
			{
				string procedure = "uspLcVerbaInserir";
				List<SqlParameter> parameters = new List<SqlParameter>
				{
					new SqlParameter("@CodigoVendedor", lancamentoVerbaMO.CODIGO_VENDEDOR),
					new SqlParameter("@CodigoCliente", pedidoVenda.CODIGO_CLIENTE),
					new SqlParameter("@CodigoMotLcVerba", lancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA),
					new SqlParameter("@Valor", lancamentoVerbaMO.VALOR),
					new SqlParameter("@CodigoEmpresa", pedidoVenda.CODIGO_EMPRESA),
					new SqlParameter("@NumeroPedido", pedidoVenda.NUMERO_PEDIDO),
					new SqlParameter("@Situacao", pedidoVenda.PEDIDO_ELETRONICO.SITUACAO),
					new SqlParameter("@CodigoUsuario", usuario.CODIGO_USUARIO),
					new SqlParameter("@TipoVerba", lancamentoVerbaMO.TIPO_VERBA)
				};
				ExecutarStoredProcedureNonQuery(procedure, parameters, out var returnValue);
				if (returnValue == -100)
				{
					throw new Exception("uspLcVerbaInserir - Erro na execução");
				}
				lancamentoVerbaMO.SEQ_LANCAMENTO_VERBA = returnValue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		else
		{
			string comando = "   INSERT INTO lc_verba\r\n                                    (\r\n                                    dt_lanc,\r\n                                    cd_vend,\r\n                                    cd_clien,\r\n                                    cd_motlcverba,\r\n                                    valor,\r\n                                    cd_emp,\r\n                                    nu_ped,\r\n                                    cd_texto,\r\n                                    situacao,\r\n                                    seq_fech_verba,\r\n                                    CdUsuario,\r\n                                    tp_verba,\r\n                                    nu_tit,\r\n                                    serie,\r\n                                    seq_pgtrec,\r\n                                    compensacao,\r\n                                    SeqEventoDev\r\n                                    )\r\n                                    VALUES\r\n                                    (\r\n                                    {0},\r\n                                    {1},\r\n                                    {2},\r\n                                    {3},\r\n                                    {4},\r\n                                    {5},\r\n                                    {6},\r\n                                    NULL,\r\n                                    {7},\r\n                                    NULL,\r\n                                    {8},\r\n                                    {9},\r\n                                    null,\r\n                                    null,\r\n                                    null,\r\n                                    0,\r\n                                    null );  ";
			ExecutarSqlCommand(comando, DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.DataHora), lancamentoVerbaMO.CODIGO_VENDEDOR, pedidoVenda.CODIGO_CLIENTE, lancamentoVerbaMO.CODIGO_MOTIVO_LANCAMENTO_VERBA, lancamentoVerbaMO.VALOR, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO, pedidoVenda.PEDIDO_ELETRONICO.SITUACAO, usuario.CODIGO_USUARIO, lancamentoVerbaMO.TIPO_VERBA);
			lancamentoVerbaMO.SEQ_LANCAMENTO_VERBA = (int)ExecutarScalarSQL<decimal>(" SELECT IDENT_CURRENT('lc_verba') ", Array.Empty<object>());
		}
		LancarEventoVerba(lancamentoVerbaMO.SEQ_LANCAMENTO_VERBA, usuario, 1);
		if (pedidoVenda.PEDIDO_ELETRONICO.SITUACAO.Equals("CA"))
		{
			LancarEventoVerba(lancamentoVerbaMO.SEQ_LANCAMENTO_VERBA, usuario, 2);
		}
	}

	private void LancarEventoVerba(int SeqLancamentoVerba, UsuarioMO usuario, int tipoOcorrenciaVerba)
	{
		string comando = " INSERT INTO evento_lc_verba\r\n                                                                 (seq_lc_verba,\r\n                                                                  cd_usuario,\r\n                                                                  cd_tp_ocor_lc_verba)\r\n                                                                 VALUES\r\n                                                                 ({0},\r\n                                                                  {1},\r\n                                                                  {2}) ";
		ExecutarSqlCommand(comando, SeqLancamentoVerba, usuario.CODIGO_USUARIO, tipoOcorrenciaVerba);
	}

	public void CancelarVerba(PedidoVendaMO pedidoVenda, UsuarioMO usuario)
	{
		string comando = "update lc_verba\r\n                        set situacao = 'CA'\r\n                        where nu_ped = {0}\r\n                          and cd_emp = {1}";
		ExecutarSqlCommand(comando, pedidoVenda.NUMERO_PEDIDO, pedidoVenda.CODIGO_EMPRESA);
		comando = " INSERT INTO evento_lc_verba\r\n                                        (seq_lc_verba,\r\n                                        cd_usuario,\r\n                                        cd_tp_ocor_lc_verba)\r\n                                       SELECT a.seq_lc_verba, {0}, {1}\r\n                                       FROM lc_verba a\r\n                                       where a.nu_ped = {2}\r\n                                         and a.cd_emp = {3}";
		ExecutarSqlCommand(comando, usuario.CODIGO_USUARIO, 2, pedidoVenda.NUMERO_PEDIDO, pedidoVenda.CODIGO_EMPRESA);
	}
}
