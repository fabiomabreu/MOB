using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class EndCliDAL
{
	private const string INSERT = "uspEndCliInsert";

	private const string UPDATE = "uspEndCliUpdate";

	private const string DELETE = "uspEndCliDelete";

	private const string SELECT = "uspEndCliSelect";

	private const string EXISTS = "uspEndCliExists";

	public static void Insert(DbConnection connection, EndCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@tp_end", instance.RetornaTpEnd());
		connection.AddParameters("@endereco", instance.Endereco);
		connection.AddParameters("@bairro", instance.Bairro);
		connection.AddParameters("@municipio", instance.Municipio);
		connection.AddParameters("@cep", instance.Cep);
		connection.AddParameters("@estado", instance.Estado);
		connection.AddParameters("@loc_guia", instance.LocGuia);
		connection.AddParameters("@local_cob", instance.LocalCob);
		connection.AddParameters("@ponto_cardeal_lat", instance.RetornaPontoCardealLat());
		connection.AddParameters("@grau_lat", instance.GrauLat);
		connection.AddParameters("@min_lat", instance.MinLat);
		connection.AddParameters("@seg_lat", instance.SegLat);
		connection.AddParameters("@ponto_cardeal_lon", instance.RetornaPontoCardealLon());
		connection.AddParameters("@grau_lon", instance.GrauLon);
		connection.AddParameters("@min_lon", instance.MinLon);
		connection.AddParameters("@seg_lon", instance.SegLon);
		connection.AddParameters("@cd_cep_munic", instance.CdCepMunic);
		connection.AddParameters("@logradouro", instance.Logradouro);
		connection.AddParameters("@numero", instance.Numero);
		connection.AddParameters("@complemento", instance.Complemento);
		connection.AddParameters("@cd_pais", instance.CdPais);
		connection.AddParameters("@latitude", instance.Latitude);
		connection.AddParameters("@longitude", instance.Longitude);
		connection.AddParameters("@CodigoProvedorCoordenada", instance.CodigoProvedorCoordenada);
		connection.AddParameters("@distrito", instance.Distrito);
		connection.AddParameters("@IncMobLogradouro", instance.IncMobLogradouro);
		connection.AddParameters("@IncMobNumero", instance.IncMobNumero);
		connection.AddParameters("@IncMobComplemento", instance.IncMobComplemento);
		connection.AddParameters("@FonteCoordenadaId", instance.FonteCoordenadaID);
		connection.AddParameters("@OrigemCoordenadaId", instance.OrigemCoordenadaID);
		connection.AddParameters("@CodigoPostal", instance.CodigoPostal);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspEndCliInsert");
	}

	public static void Update(DbConnection connection, EndCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@tp_end", instance.RetornaTpEnd());
		connection.AddParameters("@endereco", instance.Endereco);
		connection.AddParameters("@bairro", instance.Bairro);
		connection.AddParameters("@municipio", instance.Municipio);
		connection.AddParameters("@cep", instance.Cep);
		connection.AddParameters("@estado", instance.Estado);
		connection.AddParameters("@loc_guia", instance.LocGuia);
		connection.AddParameters("@local_cob", instance.LocalCob);
		connection.AddParameters("@ponto_cardeal_lat", instance.RetornaPontoCardealLat());
		connection.AddParameters("@grau_lat", instance.GrauLat);
		connection.AddParameters("@min_lat", instance.MinLat);
		connection.AddParameters("@seg_lat", instance.SegLat);
		connection.AddParameters("@ponto_cardeal_lon", instance.RetornaPontoCardealLon());
		connection.AddParameters("@grau_lon", instance.GrauLon);
		connection.AddParameters("@min_lon", instance.MinLon);
		connection.AddParameters("@seg_lon", instance.SegLon);
		connection.AddParameters("@cd_cep_munic", instance.CdCepMunic);
		connection.AddParameters("@logradouro", instance.Logradouro);
		connection.AddParameters("@numero", instance.Numero);
		connection.AddParameters("@complemento", instance.Complemento);
		connection.AddParameters("@cd_pais", instance.CdPais);
		connection.AddParameters("@latitude", instance.Latitude);
		connection.AddParameters("@longitude", instance.Longitude);
		connection.AddParameters("@CodigoProvedorCoordenada", instance.CodigoProvedorCoordenada);
		connection.AddParameters("@distrito", instance.Distrito);
		connection.AddParameters("@FonteCoordenadaId", instance.FonteCoordenadaID);
		connection.AddParameters("@OrigemCoordenadaId", instance.OrigemCoordenadaID);
		connection.AddParameters("@CodigoPostal", instance.CodigoPostal);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspEndCliUpdate");
	}

	public static void Delete(DbConnection connection, EndCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@tp_end", instance.RetornaTpEnd());
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspEndCliDelete");
	}

	public static EndCliTO[] Select(DbConnection connection, int? CdClien)
	{
		return Select(connection, CdClien, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static EndCliTO[] Select(DbConnection connection, int? CdClien, string TpEnd)
	{
		return Select(connection, CdClien, TpEnd, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static EndCliTO[] Select(DbConnection connection, int? CdClien, string TpEnd, string Endereco, string Bairro, string Municipio, int? Cep, string Estado, string LocGuia, string LocalCob, string PontoCardealLat, int? GrauLat, int? MinLat, int? SegLat, string PontoCardealLon, int? GrauLon, int? MinLon, int? SegLon, int? CdCepMunic, string Logradouro, string Numero, string Complemento, string CdPais, decimal? Latitude, decimal? Longitude, int? CodigoProvedorCoordenada, string Distrito, int? FonteCoordenadaID, int? OrigemCoordenadaID, string CodigoPostal)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@tp_end", TpEnd);
		connection.AddParameters("@endereco", Endereco);
		connection.AddParameters("@bairro", Bairro);
		connection.AddParameters("@municipio", Municipio);
		connection.AddParameters("@cep", Cep);
		connection.AddParameters("@estado", Estado);
		connection.AddParameters("@loc_guia", LocGuia);
		connection.AddParameters("@local_cob", LocalCob);
		connection.AddParameters("@ponto_cardeal_lat", PontoCardealLat);
		connection.AddParameters("@grau_lat", GrauLat);
		connection.AddParameters("@min_lat", MinLat);
		connection.AddParameters("@seg_lat", SegLat);
		connection.AddParameters("@ponto_cardeal_lon", PontoCardealLon);
		connection.AddParameters("@grau_lon", GrauLon);
		connection.AddParameters("@min_lon", MinLon);
		connection.AddParameters("@seg_lon", SegLon);
		connection.AddParameters("@cd_cep_munic", CdCepMunic);
		connection.AddParameters("@logradouro", Logradouro);
		connection.AddParameters("@numero", Numero);
		connection.AddParameters("@complemento", Complemento);
		connection.AddParameters("@cd_pais", CdPais);
		connection.AddParameters("@latitude", Latitude);
		connection.AddParameters("@longitude", Longitude);
		connection.AddParameters("@CodigoProvedorCoordenada", CodigoProvedorCoordenada);
		connection.AddParameters("@distrito", Distrito);
		connection.AddParameters("@FonteCoordenadaId", FonteCoordenadaID);
		connection.AddParameters("@OrigemCoordenadaId", OrigemCoordenadaID);
		connection.AddParameters("@CodigoPostal", CodigoPostal);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspEndCliSelect"));
	}

	public static EndCliTO[] SelecionarCoordenadas(DbConnection connection)
	{
		connection.ClearParameters();
		string commandText = "SELECT \r\n                                c.cd_clien,\r\n\t                            e.tp_end,\r\n\t                            e.endereco,\r\n\t                            e.logradouro,\r\n\t                            e.numero,\r\n\t                            e.complemento,\r\n\t                            e.bairro,\r\n\t                            e.municipio,\r\n\t                            e.estado,\r\n\t                            e.distrito,\r\n                                e.cd_pais,\r\n\t                            CASE WHEN CAST(e.cep AS VARCHAR) = '0'\r\n                                    THEN e.codigopostal\r\n                                    ELSE CAST(e.cep AS VARCHAR)\r\n                                END AS cep\r\n                           FROM \r\n                                end_cli e\r\n                                JOIN cliente c\r\n                                    ON e.cd_clien = c.cd_clien\r\n                           WHERE \r\n                                ISNULL(c.ativo,0) = 1\r\n                                AND e.logradouro IS NOT NULL\r\n                                AND e.municipio IS NOT NULL\r\n                                AND e.estado IS NOT NULL\r\n                                AND e.cd_pais IS NOT NULL\r\n                                AND e.tp_end = 'EN'\r\n                                AND e.latitude IS NULL\r\n                                AND e.longitude IS NULL\r\n                            ORDER BY\r\n                                c.cd_clien";
		using BasicRS rs = connection.ExecuteReaderRS(CommandType.Text, commandText);
		return PreencherEndereco(rs);
	}

	public static void AtualizarEndereco(DbConnection connection, EndCliTO endereco, decimal pLatitude, decimal pLongitude)
	{
		connection.ClearParameters();
		string text = pLatitude.ToString().Replace(",", ".");
		string text2 = pLongitude.ToString().Replace(",", ".");
		string commandText = string.Format("update end_cli set latitude = {2}, longitude = {3}, fonteCoordenadaId = 1 where cd_clien = {0} and tp_end = '{1}' ", endereco.CdClien, endereco.TpEndString, text, text2);
		connection.ExecuteNonQuery(CommandType.Text, commandText);
		if (pLatitude != 0m && pLongitude != 0m)
		{
			commandText = "update cliente set tp_pes = tp_pes where cd_clien = " + endereco.CdClien;
			connection.ExecuteNonQuery(CommandType.Text, commandText);
		}
	}

	public static bool Exists(DbConnection connection, int? CdClien, string TpEnd, string Endereco, string Bairro, string Municipio, int? Cep, string Estado, string LocGuia, string LocalCob, string PontoCardealLat, int? GrauLat, int? MinLat, int? SegLat, string PontoCardealLon, int? GrauLon, int? MinLon, int? SegLon, int? CdCepMunic, string Logradouro, string Numero, string Complemento, string CdPais, decimal? Latitude, decimal? Longitude, int? CodigoProvedorCoordenada, string Distrito, int? FonteCoordenadaID, int? OrigemCoordenadaID, string CodigoPostal)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@tp_end", TpEnd);
		connection.AddParameters("@endereco", Endereco);
		connection.AddParameters("@bairro", Bairro);
		connection.AddParameters("@municipio", Municipio);
		connection.AddParameters("@cep", Cep);
		connection.AddParameters("@estado", Estado);
		connection.AddParameters("@loc_guia", LocGuia);
		connection.AddParameters("@local_cob", LocalCob);
		connection.AddParameters("@ponto_cardeal_lat", PontoCardealLat);
		connection.AddParameters("@grau_lat", GrauLat);
		connection.AddParameters("@min_lat", MinLat);
		connection.AddParameters("@seg_lat", SegLat);
		connection.AddParameters("@ponto_cardeal_lon", PontoCardealLon);
		connection.AddParameters("@grau_lon", GrauLon);
		connection.AddParameters("@min_lon", MinLon);
		connection.AddParameters("@seg_lon", SegLon);
		connection.AddParameters("@cd_cep_munic", CdCepMunic);
		connection.AddParameters("@logradouro", Logradouro);
		connection.AddParameters("@numero", Numero);
		connection.AddParameters("@complemento", Complemento);
		connection.AddParameters("@cd_pais", CdPais);
		connection.AddParameters("@latitude", Latitude);
		connection.AddParameters("@longitude", Longitude);
		connection.AddParameters("@CodigoProvedorCoordenada", CodigoProvedorCoordenada);
		connection.AddParameters("@distrito", Distrito);
		connection.AddParameters("@FonteCoordenadaId", FonteCoordenadaID);
		connection.AddParameters("@OrigemCoordenadaId", OrigemCoordenadaID);
		connection.AddParameters("@CodigoPostal", CodigoPostal);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspEndCliExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static EndCliTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				EndCliTO endCliTO = new EndCliTO();
				endCliTO.CdClien = rs.GetInteger("cd_clien");
				switch (rs.GetString("tp_end"))
				{
				case "CO":
					endCliTO.TpEnd = TipoEndereco.Cobranca;
					break;
				case "EN":
					endCliTO.TpEnd = TipoEndereco.Entrega;
					break;
				case "FA":
					endCliTO.TpEnd = TipoEndereco.Faturamento;
					break;
				default:
					endCliTO.TpEnd = TipoEndereco.Faturamento;
					break;
				}
				endCliTO.Endereco = rs.GetString("endereco");
				endCliTO.Bairro = rs.GetString("bairro");
				endCliTO.Municipio = rs.GetString("municipio");
				endCliTO.Cep = rs.GetInteger("cep");
				endCliTO.Estado = rs.GetString("estado");
				endCliTO.LocGuia = rs.GetString("loc_guia");
				endCliTO.LocalCob = rs.GetString("local_cob");
				string @string = rs.GetString("ponto_cardeal_lat");
				if (!(@string == "N"))
				{
					if (@string == "S")
					{
						endCliTO.PontoCardealLat = PontosCardeais.Sul;
					}
					else
					{
						endCliTO.PontoCardealLat = PontosCardeais.Norte;
					}
				}
				else
				{
					endCliTO.PontoCardealLat = PontosCardeais.Norte;
				}
				endCliTO.GrauLat = rs.GetNullableInteger("grau_lat");
				endCliTO.MinLat = rs.GetNullableInteger("min_lat");
				endCliTO.SegLat = rs.GetNullableInteger("seg_lat");
				@string = rs.GetString("ponto_cardeal_lon");
				if (!(@string == "E"))
				{
					if (@string == "W")
					{
						endCliTO.PontoCardealLon = PontosCardeais.Oeste;
					}
					else
					{
						endCliTO.PontoCardealLon = PontosCardeais.Leste;
					}
				}
				else
				{
					endCliTO.PontoCardealLon = PontosCardeais.Leste;
				}
				endCliTO.GrauLon = rs.GetNullableInteger("grau_lon");
				endCliTO.MinLon = rs.GetNullableInteger("min_lon");
				endCliTO.SegLon = rs.GetNullableInteger("seg_lon");
				endCliTO.CdCepMunic = rs.GetNullableInteger("cd_cep_munic");
				endCliTO.Logradouro = rs.GetString("logradouro");
				endCliTO.Numero = rs.GetString("numero");
				endCliTO.Complemento = rs.GetString("complemento");
				endCliTO.CdPais = rs.GetString("cd_pais");
				endCliTO.Latitude = rs.GetDecimal("latitude");
				endCliTO.Longitude = rs.GetDecimal("longitude");
				endCliTO.CodigoProvedorCoordenada = rs.GetNullableInteger("CodigoProvedorCoordenada");
				endCliTO.Distrito = rs.GetString("distrito");
				endCliTO.FonteCoordenadaID = rs.GetNullableInteger("FonteCoordenadaId");
				endCliTO.OrigemCoordenadaID = rs.GetNullableInteger("OrigemCoordenadaId");
				endCliTO.CodigoPostal = rs.GetString("CodigoPostal");
				arrayList.Add(endCliTO);
			}
		}
		return (EndCliTO[])arrayList.ToArray(typeof(EndCliTO));
	}

	private static EndCliTO[] PreencherEndereco(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		while (rs.MoveNext())
		{
			EndCliTO endCliTO = new EndCliTO();
			endCliTO.CdClien = rs.GetInteger("cd_clien");
			endCliTO.TpEndString = rs.GetString("tp_end");
			endCliTO.Endereco = rs.GetString("endereco");
			endCliTO.Bairro = rs.GetString("bairro");
			endCliTO.Municipio = rs.GetString("municipio");
			endCliTO.CepString = rs.GetString("cep");
			endCliTO.Estado = rs.GetString("estado");
			endCliTO.Logradouro = rs.GetString("logradouro");
			endCliTO.Numero = rs.GetString("numero");
			endCliTO.Complemento = rs.GetString("complemento");
			endCliTO.Distrito = rs.GetString("distrito");
			endCliTO.CdPais = rs.GetString("cd_pais");
			arrayList.Add(endCliTO);
		}
		return (EndCliTO[])arrayList.ToArray(typeof(EndCliTO));
	}
}
