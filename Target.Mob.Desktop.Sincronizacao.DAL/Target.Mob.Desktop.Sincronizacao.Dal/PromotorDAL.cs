using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class PromotorDAL
{
	private const string SELECT_BY_ROWID = "uspPromotorSelectRowId";

	private const string SELECT_BY_ID = "uspPromotorSelectById";

	private const string UPDATE_COORDENADA_RESIDENCIA = "tgtmob_CoordenadaResidencia_Update";

	public static List<PromotorTO> Select(DbConnection connection, PromotorTO promotor)
	{
		connection.ClearParameters();
		connection.AddParameters("@RowId", promotor.RowId);
		List<PromotorTO> list = new List<PromotorTO>();
		using BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPromotorSelectRowId");
		while (basicRS.MoveNext())
		{
			list.Add(CreateInstances(basicRS));
		}
		return list;
	}

	private static PromotorTO CreateInstances(BasicRS rs)
	{
		return new PromotorTO
		{
			PromotorId = rs.GetNullableInteger("PromotorId"),
			CdPromotor = rs.GetString("CdPromotor"),
			Cgc = rs.GetString("Cgc"),
			Inscricao = rs.GetString("Inscricao"),
			Nome = rs.GetString("Nome"),
			Endereco = rs.GetString("Endereco"),
			Bairro = rs.GetString("Bairro"),
			Municipio = rs.GetString("Municipio"),
			Estado = rs.GetString("Estado"),
			Cep = rs.GetNullableInteger("Cep"),
			TpPessoa = rs.GetString("TpPessoa"),
			Ativo = rs.GetNullableBoolean("Ativo"),
			CdCepMunicipio = rs.GetInteger("CdCepMunicipio"),
			Logradouro = rs.GetString("Logradouro"),
			Numero = rs.GetString("Numero"),
			Complemento = rs.GetString("Complemento"),
			CdPais = rs.GetString("CdPais"),
			Distrito = rs.GetString("Distrito"),
			NomeGuerra = rs.GetString("NomeGuerra"),
			EquipePromotorId = rs.GetNullableInteger("EquipePromotorId"),
			Latitude = rs.GetNullableDecimal("Latitude"),
			Longitude = rs.GetNullableDecimal("Longitude"),
			Email = rs.GetString("Email"),
			MontagemRotVisitaId = rs.GetNullableByte("MontagemRotVisitaId"),
			UtilizaPocket = rs.GetNullableBoolean("UtilizaPocket"),
			RowId = rs.GetArrayByte("RowId")
		};
	}

	public static PromotorTO SelectById(DbConnection connection, int promotorId)
	{
		connection.ClearParameters();
		connection.AddParameters("@PromotorId", promotorId);
		using (BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPromotorSelectById"))
		{
			if (basicRS.MoveNext())
			{
				return CreateInstances(basicRS);
			}
		}
		return null;
	}

	public static void setCoordenadaResidencia(DbConnection connTargetErp, CoordenadaResidenciaTO cr)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@TipoUsuario", cr.TipoUsuario);
		connTargetErp.AddParameters("@IdUsuario", cr.IdUsuario);
		connTargetErp.AddParameters("@Latitude", cr.Latitude);
		connTargetErp.AddParameters("@Longitude", cr.Longitude);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "tgtmob_CoordenadaResidencia_Update");
	}
}
