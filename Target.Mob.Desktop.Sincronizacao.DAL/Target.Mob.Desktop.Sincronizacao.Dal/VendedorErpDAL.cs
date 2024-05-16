using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class VendedorErpDAL
{
	private const string SELECT = "uspVendedorErpSelect";

	private const string UPDATE_COORDENADA_RESIDENCIA = "tgtmob_CoordenadaResidencia_Update";

	public static VendedorErpTO[] Select(DbConnection connection, string CdVend, string Nome, bool? Ativo, bool? UtilizaPalmTop, byte[] RowId, int? CodigoEmpresa)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@nome", Nome);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@utiliza_palm_top", UtilizaPalmTop);
		connection.AddParameters("@rowid", RowId);
		connection.AddParameters("@CodigoEmpresa", CodigoEmpresa);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspVendedorErpSelect"));
	}

	private static VendedorErpTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				VendedorErpTO vendedorErpTO = new VendedorErpTO();
				vendedorErpTO.CdVend = rs.GetString("cd_vend");
				vendedorErpTO.Nome = rs.GetString("nome");
				vendedorErpTO.Ativo = rs.GetNullableBoolean("ativo");
				vendedorErpTO.UtilizaPalmTop = rs.GetNullableBoolean("utiliza_palm_top");
				vendedorErpTO.RowId = rs.GetArrayByte("rowid");
				vendedorErpTO.CdEquipe = rs.GetString("cd_equipe");
				vendedorErpTO.MunicRes = rs.GetString("munic_res");
				vendedorErpTO.EstRes = rs.GetString("est_res");
				vendedorErpTO.CepRes = rs.GetInteger("cep_res");
				vendedorErpTO.Pais = rs.GetString("pais");
				vendedorErpTO.Logradouro = rs.GetString("logradouro");
				vendedorErpTO.Numero = rs.GetString("numero");
				vendedorErpTO.Complemento = rs.GetString("complemento");
				vendedorErpTO.MontagemRotVisitaID = rs.GetByte("MontagemRotVisitaID");
				vendedorErpTO.CodigoEmpresa = rs.GetNullableInteger("CodigoEmpresa");
				vendedorErpTO.Latitude = rs.GetNullableDecimal("Latitude");
				vendedorErpTO.Longitude = rs.GetNullableDecimal("Longitude");
				vendedorErpTO.CGC = rs.GetString("CGC");
				arrayList.Add(vendedorErpTO);
			}
		}
		return (VendedorErpTO[])arrayList.ToArray(typeof(VendedorErpTO));
	}

	public static string getCodigoPaisPorVendedor(DbConnection connTargetErp, string codigoVendedor)
	{
		connTargetErp.ClearParameters();
		string commandText = "\r\n                            SELECT \r\n                                TOP 1 e.cd_pais\r\n                            FROM \r\n                                Vendedor v WITH (NOLOCK)\r\n                            JOIN \r\n                                vend_emp ve WITH (NOLOCK)\r\n                                    ON ve.cd_vend = v.cd_vend\r\n                            JOIN \r\n                                empresa e WITH (NOLOCK)\r\n                                    ON e.cd_emp = ve.cd_emp\r\n                            WHERE \r\n                                v.cd_vend = @CdVend\r\n                            AND ISNULL(e.Ativo, 0) = 1\r\n                            AND ISNULL(ve.Utiliza_Palm_Top, 0) = 1";
		connTargetErp.AddParameters("@CdVend", codigoVendedor);
		object obj = connTargetErp.ExecuteScalar(CommandType.Text, commandText);
		if (obj == null)
		{
			return "";
		}
		return obj.ToString();
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
