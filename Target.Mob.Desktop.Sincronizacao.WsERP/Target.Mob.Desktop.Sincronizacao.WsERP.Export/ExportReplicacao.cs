using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using fastJSON;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

internal class ExportReplicacao
{
	private string StringConnTargetMob;

	private string NomeServidorOrigemReplicacao;

	private string NomeDbOrigemReplicacao;

	private string CnpjEmpresa;

	private BasicHttpBinding BindingBasicHttp;

	private EndpointAddress RemoteAddress;

	public ExportReplicacao(string stringConnTargetMob, string cnpjEmpresa, string nomeServidorOrigemReplicacao, string nomeDbOrigemReplicacao, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		StringConnTargetMob = stringConnTargetMob;
		CnpjEmpresa = cnpjEmpresa;
		NomeServidorOrigemReplicacao = nomeServidorOrigemReplicacao;
		NomeDbOrigemReplicacao = nomeDbOrigemReplicacao;
		BindingBasicHttp = bindingBasicHttp;
		RemoteAddress = remoteAddress;
	}

	public void Exportar()
	{
		using DbConnection dbConnection = new DbConnection(StringConnTargetMob);
		try
		{
			dbConnection.Open();
			VerificarAtualizacoes(dbConnection);
			ReplicacaoTabelaTO[] array = ReplicacaoTabelaBLL.Select(dbConnection, null, null, true, true, null);
			foreach (ReplicacaoTabelaTO replicacaoTabelaTO in array)
			{
				string tabela = replicacaoTabelaTO.Tabela;
				string tabela2 = tabela + "_Log";
				string tabelaOrigem = tabela.Replace("Replicacao_Tabela_", "");
				int value = replicacaoTabelaTO.QtdeRegistrosPacote.Value;
				DataTable dataTable = ReplicacaoBLL.DadosReplicar(dbConnection, tabela2, value);
				if (dataTable == null || dataTable.Rows.Count == 0)
				{
					ReplicacaoBLL.ReplicarDadosTabelaLog(dbConnection, NomeServidorOrigemReplicacao, NomeDbOrigemReplicacao, tabelaOrigem, tabela, replicacaoTabelaTO.CondicaoSelecao);
					dataTable = ReplicacaoBLL.DadosReplicar(dbConnection, tabela2, value);
				}
				int num = ReplicacaoBLL.TotalRegistros(dbConnection, tabela2);
				int num2 = num / value;
				int num3 = num;
				ReplicacaoTabelaColunaTO[] dadosColunas = ReplicacaoTabelaColunaBLL.Select(dbConnection, replicacaoTabelaTO.IdReplicacaoTabela, null, replicar: true, null);
				for (int j = 0; j <= num2; j++)
				{
					if (dataTable.Rows.Count > 0)
					{
						int idControleTabelaLog = 0;
						num3 = ((dataTable.Rows.Count <= value) ? dataTable.Rows.Count : value);
						string dadosTabela = PrepararPacoteEnvio(dataTable, dadosColunas, num3, out idControleTabelaLog);
						RetornoWsModelOfBoolean retornoWsModelOfBoolean = EnviarPacote(tabela, dadosTabela);
						if (!retornoWsModelOfBoolean.RetornoWs)
						{
							throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
						}
						ReplicacaoBLL.ReplicarDadosTabela(dbConnection, tabela, idControleTabelaLog);
						if (num2 > 0)
						{
							dataTable = ReplicacaoBLL.DadosReplicar(dbConnection, tabela2, value);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
			throw ex;
		}
		finally
		{
			dbConnection.Close();
		}
	}

	private string PrepararPacoteEnvio(DataTable dt, ReplicacaoTabelaColunaTO[] dadosColunas, int contador, out int idControleTabelaLog)
	{
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		idControleTabelaLog = 0;
		for (int i = 0; i < contador; i++)
		{
			dictionary = new Dictionary<string, object>();
			for (int j = 0; j < dt.Columns.Count; j++)
			{
				object obj = dt.Rows[i][j].ToString();
				string nomeColuna = dt.Columns[j].ColumnName;
				if (obj.ToString() == "Null")
				{
					obj = null;
				}
				if (dadosColunas.Where((ReplicacaoTabelaColunaTO dc) => dc.Coluna == nomeColuna).FirstOrDefault() == null && nomeColuna != "IdControleTabelaLog" && nomeColuna != "Replicado" && nomeColuna != "TpOperacao")
				{
					obj = null;
				}
				if (dt.Columns[j].DataType.Name == "SqlBinary")
				{
					string value = ByteToHexString(((SqlBinary)dt.Rows[i][j]).Value);
					dictionary.Add(nomeColuna, value);
				}
				else
				{
					dictionary.Add(nomeColuna, obj);
				}
			}
			list.Add(dictionary);
			idControleTabelaLog = ((SqlInt32)dt.Rows[i]["IdControleTabelaLog"]).Value;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(JSON.Instance.ToJSON(list));
		return Compress(stringBuilder.ToString());
	}

	private RetornoWsModelOfBoolean EnviarPacote(string tabela, string dadosTabela)
	{
		Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
		validationSoapHeader.Token = Seguranca.GeraTokenERP(CnpjEmpresa, DateTime.Now);
		return new WsErpSoapClient(BindingBasicHttp, RemoteAddress).WsERP_Replicacao_Set(validationSoapHeader, CnpjEmpresa, Seguranca.getHostName(), tabela, "", dadosTabela);
	}

	private void VerificarAtualizacoes(DbConnection connTargetMob)
	{
		string[] array = new string[3] { "ReplicacaoTabela", "ReplicacaoTabelaColuna", "ReplicacaoTabelaScript" };
		string[] array2 = new string[3] { "IdReplicacaoTabela", "IdReplicacaoTabelaColuna", "IdReplicacaoTabelaScript" };
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			byte[] rowId = ReplicacaoBLL.SelectRowId(connTargetMob, text);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(CnpjEmpresa, DateTime.Now);
			RetornoWsModelOfString retornoWsModelOfString = new WsErpSoapClient(BindingBasicHttp, RemoteAddress).WsERP_Replicacao_Get(validationSoapHeader, CnpjEmpresa, Seguranca.getHostName(), text, "", rowId);
			if (string.IsNullOrEmpty(retornoWsModelOfString.RetornoWs))
			{
				continue;
			}
			DataTable dataTable = PreencherTabela(connTargetMob, text, retornoWsModelOfString.RetornoWs);
			DataTable dataTable2 = ReplicacaoBLL.Dados(connTargetMob, text);
			string text2 = array2[i];
			for (int j = 0; j < dataTable.Rows.Count; j++)
			{
				dataTable2.DefaultView.RowFilter = text2 + "=" + dataTable.Rows[j][text2];
				if (dataTable2.DefaultView.Count > 0)
				{
					dataTable2.Rows.Remove(dataTable2.DefaultView[0].Row);
				}
				dataTable2.ImportRow(dataTable.Rows[j]);
				if (text == "ReplicacaoTabelaScript")
				{
					ReplicacaoBLL.ExecutarScript(connTargetMob, dataTable.Rows[j]["ScriptTabela"].ToString());
					ReplicacaoBLL.ExecutarScript(connTargetMob, dataTable.Rows[j]["ScriptTabelaLog"].ToString());
				}
			}
			ReplicacaoBLL.SalvarTabela(connTargetMob, dataTable2);
		}
	}

	private static DataTable PreencherTabela(DbConnection connTargetMob, string tabela, string dados)
	{
		DataTable dataTable = new DataTable();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(Decompress(dados));
		object[] array = (object[])JSON.Instance.ToObject(stringBuilder.ToString());
		if (array.Length != 0)
		{
			DataTable dataTable2 = ReplicacaoBLL.InfoTabela(connTargetMob, tabela);
			dataTable = ReplicacaoBLL.EstruturaTabela(connTargetMob, tabela);
			dataTable.Rows.Clear();
			object[] array2 = array;
			foreach (object obj in array2)
			{
				DataRow dataRow = dataTable.NewRow();
				foreach (KeyValuePair<string, object> item in (Dictionary<string, object>)obj)
				{
					if (dataTable.Columns.Contains(item.Key))
					{
						if (item.Value != null)
						{
							dataTable2.DefaultView.RowFilter = "Coluna='" + item.Key + "'";
							string tipoCampo = dataTable2.DefaultView[0]["TipoDado"].ToString();
							dataRow[item.Key] = ValidarTipoCampoSQL(tipoCampo, item.Value);
						}
						else
						{
							dataRow[item.Key] = DBNull.Value;
						}
					}
				}
				dataTable.Rows.Add(dataRow);
			}
		}
		return dataTable;
	}

	private static string ByteToHexString(byte[] array)
	{
		char[] array2 = "0123456789ABCDEF".ToCharArray();
		if (array == null || array.Length < 1)
		{
			return string.Empty;
		}
		char[] array3 = new char[array.Length << 1];
		for (int i = 0; i < array.Length; i++)
		{
			byte b = array[i];
			array3[i << 1] = array2[b >> 4];
			array3[(i << 1) | 1] = array2[b & 0xF];
		}
		return new string(array3);
	}

	private static byte[] FromHexString(string hex)
	{
		return (from x in Enumerable.Range(0, hex.Length / 2)
			select byte.Parse(hex.Substring(2 * x, 2), NumberStyles.HexNumber)).ToArray();
	}

	private static string Compress(string text)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		MemoryStream memoryStream = new MemoryStream();
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
		{
			gZipStream.Write(bytes, 0, bytes.Length);
		}
		memoryStream.Position = 0L;
		new MemoryStream();
		byte[] array = new byte[memoryStream.Length];
		memoryStream.Read(array, 0, array.Length);
		byte[] array2 = new byte[array.Length + 4];
		Buffer.BlockCopy(array, 0, array2, 4, array.Length);
		Buffer.BlockCopy(BitConverter.GetBytes(bytes.Length), 0, array2, 0, 4);
		return Convert.ToBase64String(array2);
	}

	private static string Decompress(string compressedText)
	{
		byte[] array = Convert.FromBase64String(compressedText);
		using MemoryStream memoryStream = new MemoryStream();
		int num = BitConverter.ToInt32(array, 0);
		memoryStream.Write(array, 4, array.Length - 4);
		byte[] array2 = new byte[num];
		memoryStream.Position = 0L;
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
		{
			gZipStream.Read(array2, 0, array2.Length);
		}
		return Encoding.UTF8.GetString(array2);
	}

	private static object ValidarTipoCampoSQL(string tipoCampo, object valor)
	{
		object result = null;
		switch (tipoCampo.ToLower())
		{
		case "ntext":
		case "nchar":
		case "char":
		case "varchar":
			result = TryParse<string>(valor.ToString());
			break;
		case "tinyint":
		case "smallint":
			result = TryParse<short>(valor.ToString());
			break;
		case "int":
			result = TryParse<int>(valor.ToString());
			break;
		case "bigint":
			result = TryParse<long>(valor.ToString());
			break;
		case "image":
		case "binary":
		case "timestamp":
		case "varbinary":
		case "rowversion":
			result = TryParse<byte[]>(valor.ToString());
			break;
		case "bit":
			result = TryParse<bool>(valor.ToString());
			break;
		case "date":
		case "datetime":
		case "datetime2":
		case "smalldatetime":
			if (valor.ToString().ToLower() != "null")
			{
				result = TryParse<DateTime>(valor.ToString());
			}
			break;
		case "datetimeoffset":
			if (valor.ToString().ToLower() != "null")
			{
				result = TryParse<DateTimeOffset>(valor.ToString());
			}
			break;
		case "money":
		case "decimal":
		case "numeric":
		case "smallmoney":
			result = TryParse<decimal>(valor.ToString());
			break;
		case "float":
			result = TryParse<double>(valor.ToString());
			break;
		case "real":
			result = TryParse<float>(valor.ToString());
			break;
		}
		return result;
	}

	private static T TryParse<T>(string valor)
	{
		CultureInfo culture = new CultureInfo("pt-BR");
		T result;
		try
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
			if (typeof(T) == typeof(byte[]))
			{
				return (T)Convert.ChangeType(FromHexString(valor), typeof(T));
			}
			return (T)converter.ConvertFromString(null, culture, valor);
		}
		catch
		{
			result = default(T);
		}
		return result;
	}
}
