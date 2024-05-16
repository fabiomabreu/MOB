using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Geracao.Common;

namespace Target.Mob.Desktop.Api.DAL;

public class NotaFiscalDAL
{
	private const string SELECT = "tgtmob_uspIndenizacaoNotaFiscalSelect";

	public static List<NotaFiscalTO> Select(string stringConnTargetErp, string codigoVendedor, int codigoCliente, int codigoProduto, int codigoEmpresa, int? numeroNotaFiscal, DateTime? dataValidade, DateTime? dataNotaInicial, DateTime? dataNotaFinal)
	{
		List<NotaFiscalTO> result = new List<NotaFiscalTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoNotaFiscalSelect", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.CommandTimeout = 300;
			sqlCommand.Parameters.AddWithValue("@CodigoVendedor", codigoVendedor);
			sqlCommand.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
			sqlCommand.Parameters.AddWithValue("@CodigoProduto", codigoProduto);
			sqlCommand.Parameters.AddWithValue("@CodigoEmpresa", codigoEmpresa);
			sqlCommand.Parameters.AddWithValue("@NumeroNotaFiscal", numeroNotaFiscal);
			sqlCommand.Parameters.AddWithValue("@DataValidade", dataValidade);
			sqlCommand.Parameters.AddWithValue("@DataNotaInicial", dataNotaInicial);
			sqlCommand.Parameters.AddWithValue("@DataNotaFinal", dataNotaFinal);
			using SqlDataReader dr = sqlCommand.ExecuteReader();
			result = CreateInstance(dr);
		}
		sqlConnection.Close();
		return result;
	}

	private static List<NotaFiscalTO> CreateInstance(SqlDataReader dr)
	{
		List<NotaFiscalTO> list = new List<NotaFiscalTO>();
		while (dr.Read())
		{
			NotaFiscalTO notaFiscalTO = new NotaFiscalTO();
			notaFiscalTO.NumNotaFiscal = GetDataReader.GetInt32(dr, "numNotaFiscal");
			notaFiscalTO.NumNotaFiscalFat = GetDataReader.GetInt32(dr, "numNotaFiscalFat");
			notaFiscalTO.NumPedido = GetDataReader.GetInt32(dr, "numPedido");
			notaFiscalTO.DataEmissaoNF = GetDataReader.GetDateTime(dr, "dataEmissaoNF");
			notaFiscalTO.CodEmpresa = GetDataReader.GetInt32(dr, "codEmpresa");
			notaFiscalTO.NomeEmpresa = GetDataReader.GetString(dr, "nomeEmpresa");
			notaFiscalTO.ItNotaId = GetDataReader.GetInt32(dr, "itNotaId");
			notaFiscalTO.ItNotaLoteId = GetDataReader.GetNullableInt32(dr, "itNotaLoteId");
			notaFiscalTO.Lote = GetDataReader.GetString(dr, "lote");
			notaFiscalTO.CodProduto = GetDataReader.GetInt32(dr, "codProduto");
			notaFiscalTO.DataValidProd = GetDataReader.GetNullableDateTime(dr, "dataValidProd");
			notaFiscalTO.QtdeVendida = GetDataReader.GetDecimal(dr, "qtdeVendida");
			notaFiscalTO.PrecoUnit = GetDataReader.GetDecimal(dr, "precoUnit");
			notaFiscalTO.ValorTotal = GetDataReader.GetDecimal(dr, "valorTotal");
			notaFiscalTO.UnidEstoque = GetDataReader.GetString(dr, "unidEstoque");
			notaFiscalTO.UnidVendida = GetDataReader.GetString(dr, "unidVendida");
			notaFiscalTO.FatorUnidVenda = GetDataReader.GetDecimal(dr, "fatorEstoqueUnidVda");
			notaFiscalTO.IndiceRelacaoUnidVda = GetDataReader.GetString(dr, "indiceRelacaoUnidVda");
			notaFiscalTO.QtdeRestante = GetDataReader.GetDecimal(dr, "qtdeRestante");
			list.Add(notaFiscalTO);
		}
		return list;
	}
}
