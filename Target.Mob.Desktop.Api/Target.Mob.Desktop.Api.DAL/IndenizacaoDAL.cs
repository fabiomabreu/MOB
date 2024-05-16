using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class IndenizacaoDAL
{
	private const string INSERT = "tgtmob_uspIndenizacaoInsert";

	private const string INSERT_ITEM = "tgtmob_uspIndenizacaoItemInsert";

	private const string INSERT_IMAGEM = "tgtmob_uspIndenizacaoImagemInsert";

	private const string INSERT_HISTORICO = "tgtmob_uspIndenizacaoHistoricoInsert";

	private const string SELECT_SALDO = "tgtmob_uspIndenizacaoSaldo";

	private const string SELECT = "tgtmob_uspIndenizacaoSelect";

	private const string SELECT_BY_UUID = "tgtmob_uspIndenizacaoSelectByUUID";

	private const string SELECT_BY_ID = "tgtmob_uspIndenizacaoSelectByID";

	private const string SELECT_ITEM = "tgtmob_uspIndenizacaoItemSelect";

	private const string SELECT_HISTORICO = "tgtmob_uspIndenizacaoHistoricoSelect";

	private const string LIBERAR_SUPERVISOR = "tgtsup_uspLiberarIndenizacao";

	public static int Insert(string stringConnTargetErp, IndenizacaoTO model)
	{
		using (SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp))
		{
			sqlConnection.Open();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			try
			{
				SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoInsert", sqlConnection, sqlTransaction);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Clear();
				setParametrosIndenizacao(model, sqlCommand);
				sqlCommand.Parameters.Add("@IndenizacaoID", SqlDbType.Int, 20).Direction = ParameterDirection.Output;
				sqlCommand.ExecuteNonQuery();
				model.IndenizacaoID = (int)sqlCommand.Parameters["@IndenizacaoID"].Value;
				new IndenizacaoItemTO();
				IndenizacaoItemTO[] indenizacaoItem = model.IndenizacaoItem;
				foreach (IndenizacaoItemTO obj in indenizacaoItem)
				{
					obj.IndenizacaoID = model.IndenizacaoID;
					SqlCommand sqlCommand2 = new SqlCommand("tgtmob_uspIndenizacaoItemInsert", sqlConnection, sqlTransaction);
					sqlCommand2.CommandType = CommandType.StoredProcedure;
					sqlCommand2.Parameters.Clear();
					setParametrosIndenizacaoItem(obj, sqlCommand2);
					sqlCommand2.Parameters.Add("@IndenizacaoItemID", SqlDbType.Int, 20).Direction = ParameterDirection.Output;
					sqlCommand2.ExecuteNonQuery();
					obj.IndenizacaoItemID = (int)sqlCommand2.Parameters["@IndenizacaoItemID"].Value;
				}
				IndenizacaoHistoricoTO[] indenizacaoHistorico = model.IndenizacaoHistorico;
				foreach (IndenizacaoHistoricoTO obj2 in indenizacaoHistorico)
				{
					obj2.IndenizacaoID = model.IndenizacaoID;
					SqlCommand sqlCommand3 = new SqlCommand("tgtmob_uspIndenizacaoHistoricoInsert", sqlConnection, sqlTransaction);
					sqlCommand3.CommandType = CommandType.StoredProcedure;
					sqlCommand3.Parameters.Clear();
					setParametrosIndenizacaoHistorico(obj2, sqlCommand3);
					sqlCommand3.Parameters.Add("@IndenizacaoHistoricoID", SqlDbType.Int, 20).Direction = ParameterDirection.Output;
					sqlCommand3.ExecuteNonQuery();
					obj2.IndenizacaoHistoricoID = (int)sqlCommand3.Parameters["@IndenizacaoHistoricoID"].Value;
				}
				sqlTransaction.Commit();
			}
			catch (Exception ex)
			{
				sqlTransaction.Rollback();
				throw ex;
			}
			finally
			{
				sqlConnection.Close();
			}
		}
		return model.IndenizacaoID.Value;
	}

	public static IndenizacaoTO SelectByUUID(string stringConnTargetErp, string UUID)
	{
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoSelectByUUID", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@UUID", UUID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			IndenizacaoTO indenizacaoTO = null;
			while (sqlDataReader.Read())
			{
				indenizacaoTO = CreateInstance(sqlDataReader);
				CarregaIndenizacaoItem(stringConnTargetErp, indenizacaoTO);
				CarregaIndenizacaoHistorico(stringConnTargetErp, indenizacaoTO);
			}
			return indenizacaoTO;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public static IndenizacaoTO SelectByID(string stringConnTargetErp, int indenizacaoID)
	{
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoSelectByID", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@IndenizacaoID", indenizacaoID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			IndenizacaoTO indenizacaoTO = null;
			while (sqlDataReader.Read())
			{
				indenizacaoTO = CreateInstance(sqlDataReader);
				CarregaIndenizacaoItem(stringConnTargetErp, indenizacaoTO);
				CarregaIndenizacaoHistorico(stringConnTargetErp, indenizacaoTO);
			}
			return indenizacaoTO;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public static void InsertImagens(string stringConnTargetErp, IndenizacaoImagemTO model)
	{
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoImagemInsert", sqlConnection, sqlTransaction);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@IndenizacaoID", model.IndenizacaoID);
			sqlCommand.Parameters.AddWithValue("@Nome", model.Nome);
			sqlCommand.Parameters.AddWithValue("@Arquivo", model.Arquivo);
			sqlCommand.Parameters.Add("@IndenizacaoImgemID", SqlDbType.Int, 20).Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			model.IndenizacaoImagemID = (int)sqlCommand.Parameters["@IndenizacaoImgemID"].Value;
			sqlTransaction.Commit();
		}
		catch (Exception ex)
		{
			sqlTransaction.Rollback();
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public static decimal getSaldo(string stringConnTargetErp, int codigoCliente)
	{
		decimal result = default(decimal);
		using (SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp))
		{
			sqlConnection.Open();
			try
			{
				SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoSaldo", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Clear();
				sqlCommand.Parameters.AddWithValue("@CdClien", codigoCliente);
				result = (decimal)sqlCommand.ExecuteScalar();
				return result;
			}
			catch (Exception)
			{
			}
			finally
			{
				sqlConnection.Close();
			}
		}
		return result;
	}

	public static void CarregaIndenizacaoItem(string stringConnTargetErp, IndenizacaoTO indenizacao)
	{
		IndenizacaoItemTO model = new IndenizacaoItemTO(indenizacao.IndenizacaoID.Value);
		List<IndenizacaoItemTO> list = SelectItem(stringConnTargetErp, model);
		indenizacao.IndenizacaoItem = list.ToArray();
	}

	public static void CarregaIndenizacaoHistorico(string stringConnTargetErp, IndenizacaoTO indenizacao)
	{
		IndenizacaoHistoricoTO model = new IndenizacaoHistoricoTO(indenizacao.IndenizacaoID.Value);
		List<IndenizacaoHistoricoTO> list = SelectHistorico(stringConnTargetErp, model);
		indenizacao.IndenizacaoHistorico = list.ToArray();
	}

	public static List<IndenizacaoTO> Select(string stringConnTargetErp, IndenizacaoTO model)
	{
		List<IndenizacaoTO> result = new List<IndenizacaoTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoSelect", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			setParametrosIndenizacao(model, sqlCommand);
			sqlCommand.Parameters.AddWithValue("@IndenizacaoID", model.IndenizacaoID);
			sqlCommand.Parameters.AddWithValue("@ValorCreditoAplicado", model.ValorCreditoAplicado);
			sqlCommand.Parameters.AddWithValue("@ValorCreditoRestante", model.ValorCreditoRestante);
			List<IndenizacaoTO> list = new List<IndenizacaoTO>();
			IndenizacaoTO indenizacaoTO = new IndenizacaoTO();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				indenizacaoTO = CreateInstance(sqlDataReader);
				list.Add(indenizacaoTO);
			}
			foreach (IndenizacaoTO item in list)
			{
				CarregaIndenizacaoItem(stringConnTargetErp, item);
			}
			foreach (IndenizacaoTO item2 in list)
			{
				CarregaIndenizacaoHistorico(stringConnTargetErp, item2);
			}
			return result;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	private static List<IndenizacaoHistoricoTO> SelectHistorico(string stringConnTargetErp, IndenizacaoHistoricoTO model)
	{
		List<IndenizacaoHistoricoTO> list = new List<IndenizacaoHistoricoTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoHistoricoSelect", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			setParametrosIndenizacaoHistorico(model, sqlCommand);
			sqlCommand.Parameters.AddWithValue("@IndenizacaoHistoricoID", model.IndenizacaoHistoricoID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				list.Add(CreateInstanceHistorico(sqlDataReader));
			}
			return list;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public static List<IndenizacaoItemTO> SelectItem(string stringConnTargetErp, IndenizacaoItemTO model)
	{
		List<IndenizacaoItemTO> list = new List<IndenizacaoItemTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndenizacaoItemSelect", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			setParametrosIndenizacaoItem(model, sqlCommand);
			sqlCommand.Parameters.AddWithValue("@IndenizacaoItemID", model.IndenizacaoItemID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				list.Add(CreateInstanceItem(sqlDataReader));
			}
			return list;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	private static IndenizacaoTO CreateInstance(SqlDataReader dr)
	{
		return new IndenizacaoTO
		{
			IndenizacaoID = GetDataReader.GetInt32(dr, "IndenizacaoID"),
			DataInclusao = GetDataReader.GetDateTime(dr, "DataInclusao"),
			CdClien = GetDataReader.GetInt32(dr, "CdClien"),
			CdVend = GetDataReader.GetString(dr, "CdVend"),
			CdEmp = GetDataReader.GetInt32(dr, "CdEmp"),
			IndenizacaoStatusID = GetDataReader.GetByte(dr, "IndenizacaoStatusID"),
			IndenizacaoTipoCreditoID = GetDataReader.GetByte(dr, "IndenizacaoTipoCreditoID"),
			PercIndenizacao = GetDataReader.GetDecimal(dr, "PercIndenizacao"),
			PercProxVenda = GetDataReader.GetNullableDecimal(dr, "PercProxVenda"),
			ValorTotal = GetDataReader.GetDecimal(dr, "ValorTotal"),
			DataNotaFiscalCliente = GetDataReader.GetNullableDateTime(dr, "DataNotaFiscalCliente"),
			NumeroNotaFiscalCliente = GetDataReader.GetNullableInt32(dr, "NumeroNotaFiscalCliente"),
			DataVencimentoBoletoCliente = GetDataReader.GetNullableDateTime(dr, "DataVencimentoBoletoCliente"),
			ValorCreditoAplicado = GetDataReader.GetNullableDecimal(dr, "ValorCreditoAplicado"),
			ValorCreditoRestante = GetDataReader.GetNullableDecimal(dr, "ValorCreditoRestante"),
			UUID = GetDataReader.GetString(dr, "UUID")
		};
	}

	private static IndenizacaoItemTO CreateInstanceItem(SqlDataReader dr)
	{
		return new IndenizacaoItemTO
		{
			IndenizacaoItemID = GetDataReader.GetInt32(dr, "IndenizacaoItemID"),
			IndenizacaoID = GetDataReader.GetInt32(dr, "IndenizacaoID"),
			CdProd = GetDataReader.GetInt32(dr, "CdProd"),
			ItNotaID = GetDataReader.GetInt32(dr, "ItNotaID"),
			ItNotaLoteID = GetDataReader.GetNullableInt32(dr, "ItNotaLoteID"),
			Qtde = GetDataReader.GetNullableDecimal(dr, "Qtde"),
			ValorUnitario = GetDataReader.GetDecimal(dr, "ValorUnitario"),
			UnidVda = GetDataReader.GetString(dr, "UnidVda"),
			QtdeUnidVda = GetDataReader.GetDecimal(dr, "QtdeUnidVda"),
			IndiceRelacaoUnidVda = GetDataReader.GetString(dr, "IndiceRelacaoUnidVda"),
			FatorEstoqueUnidVda = GetDataReader.GetDecimal(dr, "FatorEstoqueUnidVda")
		};
	}

	private static IndenizacaoHistoricoTO CreateInstanceHistorico(SqlDataReader dr)
	{
		return new IndenizacaoHistoricoTO
		{
			IndenizacaoHistoricoID = GetDataReader.GetInt32(dr, "IndenizacaoHistoricoID"),
			IndenizacaoID = GetDataReader.GetInt32(dr, "IndenizacaoID"),
			IndenizacaoStatusID = GetDataReader.GetByte(dr, "IndenizacaoStatusID"),
			CdUsuario = GetDataReader.GetString(dr, "CdUsuario"),
			Data = GetDataReader.GetDateTime(dr, "Data"),
			IndenizacaoMotivoID = GetDataReader.GetNullableInt32(dr, "IndenizacaoMotivoID")
		};
	}

	private static void setParametrosIndenizacaoItem(IndenizacaoItemTO modelItem, SqlCommand cmdItem)
	{
		cmdItem.Parameters.AddWithValue("@IndenizacaoID", modelItem.IndenizacaoID);
		cmdItem.Parameters.AddWithValue("@CdProd", modelItem.CdProd);
		cmdItem.Parameters.AddWithValue("@ItNotaID", modelItem.ItNotaID);
		cmdItem.Parameters.AddWithValue("@ItNotaLoteID", modelItem.ItNotaLoteID);
		cmdItem.Parameters.AddWithValue("@Qtde", modelItem.Qtde);
		cmdItem.Parameters.AddWithValue("@ValorUnitario", modelItem.ValorUnitario);
		cmdItem.Parameters.AddWithValue("@UnidVda", modelItem.UnidVda);
		cmdItem.Parameters.AddWithValue("@QtdeUnidVda", modelItem.QtdeUnidVda);
		cmdItem.Parameters.AddWithValue("@IndiceRelacaoUnidVda", modelItem.IndiceRelacaoUnidVda);
		cmdItem.Parameters.AddWithValue("@FatorEstoqueUnidVda", modelItem.FatorEstoqueUnidVda);
	}

	private static void setParametrosIndenizacaoHistorico(IndenizacaoHistoricoTO indHist, SqlCommand cmditem)
	{
		cmditem.Parameters.AddWithValue("@IndenizacaoID", indHist.IndenizacaoID);
		cmditem.Parameters.AddWithValue("@IndenizacaoStatusID", indHist.IndenizacaoStatusID);
		cmditem.Parameters.AddWithValue("@CdUsuario", indHist.CdUsuario);
		cmditem.Parameters.AddWithValue("@Data", indHist.Data);
		cmditem.Parameters.AddWithValue("@IndenizacaoMotivoID", indHist.IndenizacaoMotivoID);
	}

	private static void setParametrosIndenizacao(IndenizacaoTO model, SqlCommand cmd)
	{
		cmd.Parameters.AddWithValue("@DataInclusao", model.DataInclusao);
		cmd.Parameters.AddWithValue("@CdClien", model.CdClien);
		cmd.Parameters.AddWithValue("@CdVend", model.CdVend);
		cmd.Parameters.AddWithValue("@CdEmp", model.CdEmp);
		cmd.Parameters.AddWithValue("@IndenizacaoStatusID", model.IndenizacaoStatusID);
		cmd.Parameters.AddWithValue("@IndenizacaoTipoCreditoID", model.IndenizacaoTipoCreditoID);
		cmd.Parameters.AddWithValue("@PercIndenizacao", model.PercIndenizacao);
		cmd.Parameters.AddWithValue("@PercProxVenda", model.PercProxVenda);
		cmd.Parameters.AddWithValue("@ValorTotal", model.ValorTotal);
		cmd.Parameters.AddWithValue("@DataNotaFiscalCliente", model.DataNotaFiscalCliente);
		cmd.Parameters.AddWithValue("@NumeroNotaFiscalCliente", model.NumeroNotaFiscalCliente);
		cmd.Parameters.AddWithValue("@DataVencimentoBoletoCliente", model.DataVencimentoBoletoCliente);
		cmd.Parameters.AddWithValue("@UUID", model.UUID);
	}

	internal static int LiberarSupervisor(string conn, string cdSupervisor, int cdEmp, int nuIndenizacao, int status, int? motivoDevolucao)
	{
		using DbConnection dbConnection = new DbConnection(conn);
		dbConnection.Open();
		dbConnection.ClearParameters();
		dbConnection.AddParameters("@CodigoEmpresa", cdEmp);
		dbConnection.AddParameters("@CodigoSupervisor", cdSupervisor);
		dbConnection.AddParameters("@NumeroIndenizacao", nuIndenizacao);
		dbConnection.AddParameters("@Status", status);
		dbConnection.AddParameters("@MotivoDevolucao", motivoDevolucao);
		return int.Parse(dbConnection.ExecuteScalar(CommandType.StoredProcedure, "tgtsup_uspLiberarIndenizacao").ToString());
	}
}
