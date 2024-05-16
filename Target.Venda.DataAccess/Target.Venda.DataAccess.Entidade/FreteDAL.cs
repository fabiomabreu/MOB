using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class FreteDAL : EntidadeBaseDAL<FreteMO>
{
	protected override Expression<Func<FreteMO, bool>> GetWhere(Expression<Func<FreteMO, bool>> whereClause, FreteMO exemplo)
	{
		throw new NotImplementedException();
	}

	public FreteVO ObterConfiguracaoFretePeloCep(int codigoFornecedor, int cep)
	{
		try
		{
			string select = "  SELECT SEQ_FRETE,\r\n                                            CASE WHEN tpcob_cubagem = 1\r\n                                                THEN ISNULL( tpcob_cubagem_vl_frete, 0 )\r\n                                                WHEN tpcob_pesagem = 1\r\n                                                THEN ISNULL( tpcob_pesagem_vl_frete, 0 )\r\n                                                ELSE 0\r\n                                           END VALOR_FRETE_UNIDADE,\r\n                                           vl_frete_min as VALOR_FRETE_MINIMO,\r\n                                           calc_frete_cif as CALCULAR_FRETE_CIF,\r\n                                           calc_frete_fob as CALCULAR_FRETE_FOB,\r\n\r\n                                            tpcob_melhor_calculo MELHOR_CALCULO,\r\n\r\n\t\t                                    tpcob_cubagem TIPO_COBRANCA_CUBAGEM,\r\n\t\t                                    tpcob_cubagem_vl_frete TIPO_COBRANCA_CUBAGEM_VALOR,\r\n\r\n\t\t                                    tpcob_pesagem TIPO_COBRANCA_PESAGEM,\r\n\t\t                                    tpcob_pesagem_vl_frete TIPO_COBRANCA_PESAGEM_VALOR,\r\n\r\n\t\t                                    tpcob_percentual TIPO_COBRANCA_PERCENTUAL,\r\n\t\t                                    tpcob_percentual_frete TIPO_COBRANCA_PERCENTUAL_VALOR,\r\n\r\n\t\t                                    tpcob_fx_valor TIPO_COBRANCA_FIXO_VALOR,\r\n\t\t                                    tpcob_fx_peso TIPO_COBRANCA_FIXO_PESO,\r\n\r\n                                            \r\n                                            isencao ISENCAO,\r\n\t\t                                    isencao_vl_ped_min ISENCAO_VALOR_MINIMO_PEDIDO\r\n\r\n                                    FROM  frete\r\n                                    WHERE ativo = 1\r\n                                    AND cd_forn = {0}\r\n                                    AND {1} BETWEEN cep_de AND cep_ate ";
			return ExecutarScalarSQL<FreteVO>(select, new object[2] { codigoFornecedor, cep });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public decimal? ObterValorFretePeloFatorPeso(int seqFrete, decimal pesoTotal)
	{
		try
		{
			string select = "SELECT peso_vl_frete\r\n\t\t\t\t                 FROM frete_tpcob_fx_peso\r\n\t\t\t\t                 WHERE seq_frete = {0}\r\n\t\t\t\t                 AND {1} BETWEEN peso_inicial AND peso_final ";
			return ExecutarScalarSQL<decimal?>(select, new object[2] { seqFrete, pesoTotal });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public decimal? ObterValorFretePeloFatorValor(int seqFrete, decimal valorTotal)
	{
		try
		{
			string select = "  SELECT \r\n\t                                    CASE WHEN f.isencao = 1 AND {1} >= f.isencao_vl_ped_min\r\n\t\t                                    THEN 0 \r\n\t                                    ELSE \r\n\t\t\t                                (SELECT valor_vl_frete\r\n\t\t\t\t                                FROM frete_tpcob_fx_valor\r\n\t\t\t\t                               WHERE  seq_frete = f.seq_frete\r\n\t\t\t\t                                    AND {1} BETWEEN valor_inicial AND valor_final) \r\n\t                                    END\r\n\r\n                                     FROM FRETE f\r\n                                     WHERE f.seq_frete ={0} ";
			return ExecutarScalarSQL<decimal?>(select, new object[2] { seqFrete, valorTotal });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}
}
