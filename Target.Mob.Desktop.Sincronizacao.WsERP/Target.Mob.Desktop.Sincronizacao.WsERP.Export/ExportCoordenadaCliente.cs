using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Web.Script.Serialization;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

internal class ExportCoordenadaCliente
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	public ExportCoordenadaCliente(string stringConnTargetErp, string cnpjEmpresa)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_CnpjEmpresa = cnpjEmpresa;
	}

	public void Exportar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		try
		{
			dbConnection.Open();
			EndCliTO[] array = EndCliBLL.SelecionarCoordenadas(dbConnection);
			if (array != null && array.Length != 0)
			{
				EndCliTO[] array2 = array;
				foreach (EndCliTO endereco in array2)
				{
					List<decimal> list = ObterCoordenadas(dbConnection, endereco);
					if (list == null)
					{
						list = new List<decimal>();
						list.Add(0m);
						list.Add(0m);
					}
					if (list != null && list.Count == 2)
					{
						AtualizarCadastroEndereco(dbConnection, endereco, list[0], list[1]);
					}
				}
			}
			dbConnection.Close();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
		}
	}

	public List<decimal> ObterCoordenadas(DbConnection connTargetErp, EndCliTO endereco)
	{
		List<decimal> list = new List<decimal>();
		object value = "";
		object value2 = "";
		string value3 = "";
		string value4 = "";
		try
		{
			string address = $"https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/findAddressCandidates?Address={endereco.Endereco}&City={endereco.Municipio}&Region={RetornarEstadoPorCodigo(connTargetErp, endereco.CdPais, endereco.Estado)}&Postal={endereco.CepString}&sourceCountry={endereco.CdPais}&outFields=geometry&forStorage=false&f=pjson";
			using (WebClient webClient = new WebClient())
			{
				string text = webClient.DownloadString(address);
				if (text != null)
				{
					if (((Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(text)).TryGetValue("candidates", out var value5) && ((Dictionary<string, object>)((object[])value5)[0]).TryGetValue("location", out var value6))
					{
						Dictionary<string, object> obj = (Dictionary<string, object>)value6;
						obj.TryGetValue("y", out value);
						obj.TryGetValue("x", out value2);
					}
					value3 = value.ToString();
					value4 = value2.ToString();
				}
			}
			if (string.IsNullOrEmpty(value3) || string.IsNullOrEmpty(value4))
			{
				return null;
			}
			list.Add(Convert.ToDecimal(value3));
			list.Add(Convert.ToDecimal(value4));
		}
		catch (Exception)
		{
			list = null;
		}
		return list;
	}

	private void AtualizarCadastroEndereco(DbConnection connTargetErp, EndCliTO endereco, decimal latitude, decimal longitude)
	{
		try
		{
			if (endereco.CdClien == 0)
			{
				throw new Exception("Codigo do Cliente não informado!");
			}
			if (string.IsNullOrEmpty(endereco.TpEnd.ToString()))
			{
				throw new Exception("Tipo de Endereço não informado!");
			}
			EndCliBLL.AtualizarEndereco(connTargetErp, endereco, latitude, longitude);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private string RetornarEstadoPorCodigo(DbConnection connTargetErp, string CdPais, string CdEstado)
	{
		connTargetErp.ClearParameters();
		string commandText = "\r\n                            SELECT \r\n                                e.Descricao\r\n                            FROM \r\n                                estado e\r\n                            JOIN pais p \r\n                                ON e.cd_pais = p.cd_pais\r\n                            WHERE \r\n                                p.cd_pais = @CdPais\r\n                            AND e.estado = @CdEstado";
		connTargetErp.AddParameters("CdPais", CdPais);
		connTargetErp.AddParameters("CdEstado", CdEstado);
		object obj = connTargetErp.ExecuteScalar(CommandType.Text, commandText);
		if (obj == null)
		{
			return "";
		}
		return obj.ToString();
	}
}
