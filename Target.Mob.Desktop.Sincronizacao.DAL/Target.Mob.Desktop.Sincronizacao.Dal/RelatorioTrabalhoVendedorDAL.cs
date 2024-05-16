using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class RelatorioTrabalhoVendedorDAL
{
	private const string SELECT_MAX_ROWID = "uspRelatorioTrabalhoVendedorMaxRowId";

	private const string EXISTS = "uspRelatorioTrabalhoVendedorExists";

	private const string DELETE = "uspRelatorioTrabalhoVendedorDelete";

	private const string SELECT = "uspRelatorioTrabalhoVendedorSelect";

	private const string INSERT = "uspRelatorioTrabalhoVendedorInsert";

	private static RelatorioTrabalhoVendedorTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				RelatorioTrabalhoVendedorTO relatorioTrabalhoVendedorTO = new RelatorioTrabalhoVendedorTO();
				relatorioTrabalhoVendedorTO.IdRelatorioTrabalhoVendedor = rs.GetInteger("IdRelatorioTrabalhoVendedor");
				relatorioTrabalhoVendedorTO.Data = rs.GetDateTime("Data");
				relatorioTrabalhoVendedorTO.IdVendedor = rs.GetInteger("IdVendedor");
				relatorioTrabalhoVendedorTO.CodigoVendedor = rs.GetString("CodigoVendedor");
				relatorioTrabalhoVendedorTO.Nome = rs.GetString("Nome");
				relatorioTrabalhoVendedorTO.QtdeVisitasRoteiroProgramadas = rs.GetNullableInteger("QtdeVisitasRoteiroProgramadas");
				relatorioTrabalhoVendedorTO.QtdeVisitasRoteiroRealizadas = rs.GetNullableInteger("QtdeVisitasRoteiroRealizadas");
				relatorioTrabalhoVendedorTO.QtdeVisitasForaRoteiro = rs.GetNullableInteger("QtdeVisitasForaRoteiro");
				relatorioTrabalhoVendedorTO.QtdePedidos = rs.GetNullableInteger("QtdePedidos");
				relatorioTrabalhoVendedorTO.QtdePedidosRoteiro = rs.GetNullableInteger("QtdePedidosRoteiro");
				relatorioTrabalhoVendedorTO.QtdePedidosRoteiroCliente = rs.GetNullableInteger("QtdePedidosRoteiroCliente");
				relatorioTrabalhoVendedorTO.QtdePedidosForaRoteiro = rs.GetNullableInteger("QtdePedidosForaRoteiro");
				relatorioTrabalhoVendedorTO.QtdePedidosForaRoteiroCliente = rs.GetNullableInteger("QtdePedidosForaRoteiroCliente");
				relatorioTrabalhoVendedorTO.KmRodado = rs.GetNullableDecimal("KmRodado");
				relatorioTrabalhoVendedorTO.DataInicioTrabalho = rs.GetNullableDateTime("DataInicioTrabalho");
				relatorioTrabalhoVendedorTO.DataFimTrabalho = rs.GetNullableDateTime("DataFimTrabalho");
				relatorioTrabalhoVendedorTO.TempoImprodutivo = rs.GetNullableInteger("TempoImprodutivo");
				relatorioTrabalhoVendedorTO.TempoCliente = rs.GetNullableInteger("TempoCliente");
				relatorioTrabalhoVendedorTO.TempoClienteRota = rs.GetNullableInteger("TempoClienteRota");
				relatorioTrabalhoVendedorTO.TempoClienteFora = rs.GetNullableInteger("TempoClienteFora");
				relatorioTrabalhoVendedorTO.TempoAlmoco = rs.GetNullableInteger("TempoAlmoco");
				relatorioTrabalhoVendedorTO.TempoTotal = rs.GetNullableInteger("TempoTotal");
				relatorioTrabalhoVendedorTO.DataInicioAlmoco = rs.GetNullableDateTime("DataInicioAlmoco");
				relatorioTrabalhoVendedorTO.DataFimAlmoco = rs.GetNullableDateTime("DataFimAlmoco");
				relatorioTrabalhoVendedorTO.KmRodadoTotal = rs.GetNullableDecimal("KmRodadoTotal");
				relatorioTrabalhoVendedorTO.KmAjudaCusto = rs.GetNullableDecimal("KmAjudaCusto");
				relatorioTrabalhoVendedorTO.KmPrevistoInicio = rs.GetNullableDecimal("KmPrevistoInicio");
				relatorioTrabalhoVendedorTO.KmPrevistoFim = rs.GetNullableDecimal("KmPrevistoFim");
				relatorioTrabalhoVendedorTO.KmPrevistoRoteiro = rs.GetNullableDecimal("KmPrevistoRoteiro");
				relatorioTrabalhoVendedorTO.RowId = rs.GetArrayByte("RowId");
				relatorioTrabalhoVendedorTO.KmAjudaCustoDescricao = rs.GetString("KmAjudaCustoDescricao");
				arrayList.Add(relatorioTrabalhoVendedorTO);
			}
		}
		return (RelatorioTrabalhoVendedorTO[])arrayList.ToArray(typeof(RelatorioTrabalhoVendedorTO));
	}

	public static byte[] selectMaxRowId(DbConnection connTargetErp)
	{
		byte[] result = null;
		connTargetErp.ClearParameters();
		object obj = connTargetErp.ExecuteScalar(CommandType.StoredProcedure, "uspRelatorioTrabalhoVendedorMaxRowId");
		if (obj != null && obj.ToString() != "")
		{
			result = (byte[])obj;
		}
		return result;
	}

	public static RelatorioTrabalhoVendedorTO[] Select(DbConnection connTargetErp, RelatorioTrabalhoVendedorTO rtv)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdRelatorioTrabalhoVendedor", rtv.IdRelatorioTrabalhoVendedor);
		connTargetErp.AddParameters("@Data", rtv.Data);
		connTargetErp.AddParameters("@IdVendedor", rtv.IdVendedor);
		connTargetErp.AddParameters("@CodigoVendedor", rtv.CodigoVendedor);
		connTargetErp.AddParameters("@Nome", rtv.Nome);
		connTargetErp.AddParameters("@QtdeVisitasRoteiroProgramadas", rtv.QtdeVisitasRoteiroProgramadas);
		connTargetErp.AddParameters("@QtdeVisitasRoteiroRealizadas", rtv.QtdeVisitasRoteiroRealizadas);
		connTargetErp.AddParameters("@QtdeVisitasForaRoteiro", rtv.QtdeVisitasForaRoteiro);
		connTargetErp.AddParameters("@QtdePedidos", rtv.QtdePedidos);
		connTargetErp.AddParameters("@QtdePedidosRoteiro", rtv.QtdePedidosRoteiro);
		connTargetErp.AddParameters("@QtdePedidosRoteiroCliente", rtv.QtdePedidosRoteiroCliente);
		connTargetErp.AddParameters("@QtdePedidosForaRoteiro", rtv.QtdePedidosForaRoteiro);
		connTargetErp.AddParameters("@QtdePedidosForaRoteiroCliente", rtv.QtdePedidosForaRoteiroCliente);
		connTargetErp.AddParameters("@KmRodado", rtv.KmRodado);
		connTargetErp.AddParameters("@DataInicioTrabalho", rtv.DataInicioTrabalho);
		connTargetErp.AddParameters("@DataFimTrabalho", rtv.DataFimTrabalho);
		connTargetErp.AddParameters("@TempoImprodutivo", rtv.TempoImprodutivo);
		connTargetErp.AddParameters("@TempoCliente", rtv.TempoCliente);
		connTargetErp.AddParameters("@TempoClienteRota", rtv.TempoClienteRota);
		connTargetErp.AddParameters("@TempoClienteFora", rtv.TempoClienteFora);
		connTargetErp.AddParameters("@TempoAlmoco", rtv.TempoAlmoco);
		connTargetErp.AddParameters("@TempoTotal", rtv.TempoTotal);
		connTargetErp.AddParameters("@DataInicioAlmoco", rtv.DataInicioAlmoco);
		connTargetErp.AddParameters("@DataFimAlmoco", rtv.DataFimAlmoco);
		connTargetErp.AddParameters("@KmRodadoTotal", rtv.KmRodadoTotal);
		connTargetErp.AddParameters("@KmAjudaCusto", rtv.KmAjudaCusto);
		connTargetErp.AddParameters("@KmPrevistoInicio", rtv.KmPrevistoInicio);
		connTargetErp.AddParameters("@KmPrevistoFim", rtv.KmPrevistoFim);
		connTargetErp.AddParameters("@KmPrevistoRoteiro", rtv.KmPrevistoRoteiro);
		connTargetErp.AddParameters("@RowId", rtv.RowId);
		connTargetErp.AddParameters("@KmAjudaCustoDescricao", rtv.KmAjudaCustoDescricao);
		using BasicRS rs = connTargetErp.ExecuteReaderRS(CommandType.StoredProcedure, "uspRelatorioTrabalhoVendedorSelect");
		return CreateInstances(rs);
	}

	public static void Delete(DbConnection connTargetErp, RelatorioTrabalhoVendedorTO rtv)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdRelatorioTrabalhoVendedor", rtv.IdRelatorioTrabalhoVendedor);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspRelatorioTrabalhoVendedorDelete");
	}

	public static void Insert(DbConnection connTargetErp, RelatorioTrabalhoVendedorTO rtv)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdRelatorioTrabalhoVendedor", rtv.IdRelatorioTrabalhoVendedor);
		connTargetErp.AddParameters("@Data", rtv.Data);
		connTargetErp.AddParameters("@IdVendedor", rtv.IdVendedor);
		connTargetErp.AddParameters("@CodigoVendedor", rtv.CodigoVendedor);
		connTargetErp.AddParameters("@Nome", rtv.Nome);
		connTargetErp.AddParameters("@QtdeVisitasRoteiroProgramadas", rtv.QtdeVisitasRoteiroProgramadas);
		connTargetErp.AddParameters("@QtdeVisitasRoteiroRealizadas", rtv.QtdeVisitasRoteiroRealizadas);
		connTargetErp.AddParameters("@QtdeVisitasForaRoteiro", rtv.QtdeVisitasForaRoteiro);
		connTargetErp.AddParameters("@QtdePedidos", rtv.QtdePedidos);
		connTargetErp.AddParameters("@QtdePedidosRoteiro", rtv.QtdePedidosRoteiro);
		connTargetErp.AddParameters("@QtdePedidosRoteiroCliente", rtv.QtdePedidosRoteiroCliente);
		connTargetErp.AddParameters("@QtdePedidosForaRoteiro", rtv.QtdePedidosForaRoteiro);
		connTargetErp.AddParameters("@QtdePedidosForaRoteiroCliente", rtv.QtdePedidosForaRoteiroCliente);
		connTargetErp.AddParameters("@KmRodado", rtv.KmRodado);
		connTargetErp.AddParameters("@DataInicioTrabalho", rtv.DataInicioTrabalho);
		connTargetErp.AddParameters("@DataFimTrabalho", rtv.DataFimTrabalho);
		connTargetErp.AddParameters("@TempoImprodutivo", rtv.TempoImprodutivo);
		connTargetErp.AddParameters("@TempoCliente", rtv.TempoCliente);
		connTargetErp.AddParameters("@TempoClienteRota", rtv.TempoClienteRota);
		connTargetErp.AddParameters("@TempoClienteFora", rtv.TempoClienteFora);
		connTargetErp.AddParameters("@TempoAlmoco", rtv.TempoAlmoco);
		connTargetErp.AddParameters("@TempoTotal", rtv.TempoTotal);
		connTargetErp.AddParameters("@DataInicioAlmoco", rtv.DataInicioAlmoco);
		connTargetErp.AddParameters("@DataFimAlmoco", rtv.DataFimAlmoco);
		connTargetErp.AddParameters("@KmRodadoTotal", rtv.KmRodadoTotal);
		connTargetErp.AddParameters("@KmAjudaCusto", rtv.KmAjudaCusto);
		connTargetErp.AddParameters("@KmPrevistoInicio", rtv.KmPrevistoInicio);
		connTargetErp.AddParameters("@KmPrevistoFim", rtv.KmPrevistoFim);
		connTargetErp.AddParameters("@KmPrevistoRoteiro", rtv.KmPrevistoRoteiro);
		connTargetErp.AddParameters("@RowId", rtv.RowId);
		connTargetErp.AddParameters("@KmAjudaCustoDescricao", rtv.KmAjudaCustoDescricao);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspRelatorioTrabalhoVendedorInsert");
	}
}
