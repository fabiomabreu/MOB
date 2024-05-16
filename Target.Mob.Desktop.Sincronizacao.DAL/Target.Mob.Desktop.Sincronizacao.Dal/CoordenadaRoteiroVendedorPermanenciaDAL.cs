using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class CoordenadaRoteiroVendedorPermanenciaDAL
{
	private const string DELETE = "uspCoordenadaRoteiroVendedorPermanenciaDelete";

	private const string SELECT = "uspCoordenadaRoteiroVendedorPermanenciaSelect";

	private const string INSERT = "uspCoordenadaRoteiroVendedorPermanenciaInsert";

	private const string DELETE_BY_DATA_IDVENDEDOR = "uspCoordenadaRoteiroVendedorPermanenciaDeleteDataVendedor";

	private const string SELECT_MAX_ROWID = "uspCoordenadaRoteiroVendedorPermanenciaMaxRowId";

	private static CoordenadaRoteiroVendedorPermanenciaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CoordenadaRoteiroVendedorPermanenciaTO coordenadaRoteiroVendedorPermanenciaTO = new CoordenadaRoteiroVendedorPermanenciaTO();
				coordenadaRoteiroVendedorPermanenciaTO.IdCoordenadaRoteiroVendedorPermanencia = rs.GetInteger("IdCoordenadaRoteiroVendedorPermanencia");
				coordenadaRoteiroVendedorPermanenciaTO.IdVendedor = rs.GetInteger("IdVendedor");
				coordenadaRoteiroVendedorPermanenciaTO.CodigoVendedor = rs.GetString("CodigoVendedor");
				coordenadaRoteiroVendedorPermanenciaTO.Data = rs.GetDateTime("Data");
				coordenadaRoteiroVendedorPermanenciaTO.CodigoCliente = rs.GetInteger("CodigoCliente");
				coordenadaRoteiroVendedorPermanenciaTO.HoraInicio = TimeSpan.FromTicks(rs.GetInteger("HoraInicio"));
				coordenadaRoteiroVendedorPermanenciaTO.HoraFim = TimeSpan.FromTicks(rs.GetInteger("HoraFim"));
				coordenadaRoteiroVendedorPermanenciaTO.Roteiro = rs.GetInteger("Roteiro");
				coordenadaRoteiroVendedorPermanenciaTO.CodigoAcao = rs.GetInteger("CodigoAcao");
				coordenadaRoteiroVendedorPermanenciaTO.RowId = rs.GetArrayByte("RowId");
				arrayList.Add(coordenadaRoteiroVendedorPermanenciaTO);
			}
		}
		return (CoordenadaRoteiroVendedorPermanenciaTO[])arrayList.ToArray(typeof(CoordenadaRoteiroVendedorPermanenciaTO));
	}

	public static byte[] selectMaxRowId(DbConnection connTargetErp)
	{
		byte[] result = null;
		connTargetErp.ClearParameters();
		object obj = connTargetErp.ExecuteScalar(CommandType.StoredProcedure, "uspCoordenadaRoteiroVendedorPermanenciaMaxRowId");
		if (obj != null && obj.ToString() != "")
		{
			result = (byte[])obj;
		}
		return result;
	}

	public static CoordenadaRoteiroVendedorPermanenciaTO[] Select(DbConnection connTargetErp, CoordenadaRoteiroVendedorPermanenciaTO crvp)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdCoordenadaRoteiroVendedorPermanencia", crvp.IdCoordenadaRoteiroVendedorPermanencia);
		connTargetErp.AddParameters("@IdVendedor", crvp.IdVendedor);
		connTargetErp.AddParameters("@CodigoVendedor", crvp.CodigoVendedor);
		connTargetErp.AddParameters("@Data", crvp.Data);
		connTargetErp.AddParameters("@CodigoCliente", crvp.CodigoCliente);
		connTargetErp.AddParameters("@HoraInicio", crvp.HoraInicio);
		connTargetErp.AddParameters("@HoraFim", crvp.HoraFim);
		connTargetErp.AddParameters("@Roteiro", crvp.Roteiro);
		connTargetErp.AddParameters("@CodigoAcao", crvp.CodigoAcao);
		connTargetErp.AddParameters("@RowId", crvp.RowId);
		using BasicRS rs = connTargetErp.ExecuteReaderRS(CommandType.StoredProcedure, "uspCoordenadaRoteiroVendedorPermanenciaSelect");
		return CreateInstances(rs);
	}

	public static void Delete(DbConnection connTargetErp, CoordenadaRoteiroVendedorPermanenciaTO rtv)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdCoordenadaRoteiroVendedorPermanencia", rtv.IdCoordenadaRoteiroVendedorPermanencia);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspCoordenadaRoteiroVendedorPermanenciaDelete");
	}

	public static void Insert(DbConnection connTargetErp, CoordenadaRoteiroVendedorPermanenciaTO crvp)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdCoordenadaRoteiroVendedorPermanencia", crvp.IdCoordenadaRoteiroVendedorPermanencia);
		connTargetErp.AddParameters("@Data", crvp.Data);
		connTargetErp.AddParameters("@IdVendedor", crvp.IdVendedor);
		connTargetErp.AddParameters("@CodigoVendedor", crvp.CodigoVendedor);
		connTargetErp.AddParameters("@CodigoCliente", crvp.CodigoCliente);
		connTargetErp.AddParameters("@HoraInicio", crvp.HoraInicio);
		connTargetErp.AddParameters("@HoraFim", crvp.HoraFim);
		connTargetErp.AddParameters("@Roteiro", crvp.Roteiro);
		connTargetErp.AddParameters("@CodigoAcao", crvp.CodigoAcao);
		connTargetErp.AddParameters("@RowId", crvp.RowId);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspCoordenadaRoteiroVendedorPermanenciaInsert");
	}

	public static void DeleteByIdVendedorEData(DbConnection connTargetErp, CoordenadaRoteiroVendedorPermanenciaTO crvp)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@Data", crvp.Data);
		connTargetErp.AddParameters("@IdVendedor", crvp.IdVendedor);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspCoordenadaRoteiroVendedorPermanenciaDeleteDataVendedor");
	}
}
