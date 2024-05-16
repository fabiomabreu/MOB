using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class RelatorioGerencialDAL
{
	private const string INSERT = "uspRelatorioGerencialIns";

	private const string UPDATE = "uspRelatorioGerencialUpd";

	private const string DELETE = "uspRelatorioGerencialDel";

	private const string SELECT = "uspRelatorioGerencialSel";

	private const string SELECTARQ = "uspRelatorioGerencialSelArq";

	private const string EXISTS = "uspRelatorioGerencialExists";

	public static void Insert(DbConnection connection, RelatorioGerencialTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDVendedor", instance.IDVendedor);
		connection.AddParameters("@NomeArquivo", instance.NomeArquivo);
		connection.AddParameters("@ArquivoRelatorio", instance.ArquivoRelatorio);
		connection.AddParameters("@DtRecebimento", instance.DtRecebimento);
		connection.AddParameters("@DtImportacao", instance.DtImportacao);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspRelatorioGerencialIns");
	}

	public static void Update(DbConnection connection, RelatorioGerencialTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDRelatorioGerencial", instance.IDRelatorioGerencial);
		connection.AddParameters("@IDVendedor", instance.IDVendedor);
		connection.AddParameters("@NomeArquivo", instance.NomeArquivo);
		connection.AddParameters("@ArquivoRelatorio", instance.ArquivoRelatorio);
		connection.AddParameters("@DtRecebimento", instance.DtRecebimento);
		connection.AddParameters("@DtImportacao", instance.DtImportacao);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspRelatorioGerencialUpd");
	}

	public static void Delete(DbConnection connection, RelatorioGerencialTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDRelatorioGerencial", instance.IDRelatorioGerencial);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspRelatorioGerencialDel");
	}

	public static RelatorioGerencialTO[] Select_Sem_Arquivo(DbConnection connection, RelatorioGerencialTO values)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDVendedor", values.IDVendedor);
		connection.AddParameters("@NomeArquivo", values.NomeArquivo);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspRelatorioGerencialExists"));
	}

	public static RelatorioGerencialTO[] Select(DbConnection connection, RelatorioGerencialTO values)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDRelatorioGerencial", values.IDRelatorioGerencial);
		connection.AddParameters("@IDVendedor", values.IDVendedor);
		connection.AddParameters("@NomeArquivo", values.NomeArquivo);
		connection.AddParameters("@DtRecebimento", values.DtRecebimento);
		connection.AddParameters("@DtImportacao", values.DtImportacao);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspRelatorioGerencialSel"));
	}

	public static RelatorioGerencialTO[] Select_Arquivo(DbConnection connection, RelatorioGerencialTO values)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDRelatorioGerencial", values.IDRelatorioGerencial);
		connection.AddParameters("@IDVendedor", values.IDVendedor);
		connection.AddParameters("@NomeArquivo", values.NomeArquivo);
		connection.AddParameters("@DtRecebimento", values.DtRecebimento);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspRelatorioGerencialSelArq"));
	}

	public static bool Exists(DbConnection connection, RelatorioGerencialTO values)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDVendedor", values.IDVendedor);
		connection.AddParameters("@NomeArquivo", values.NomeArquivo);
		return connection.ExecuteScalar(CommandType.StoredProcedure, "uspRelatorioGerencialExists") != null;
	}

	private static RelatorioGerencialTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				RelatorioGerencialTO relatorioGerencialTO = new RelatorioGerencialTO();
				relatorioGerencialTO.IDRelatorioGerencial = rs.GetInteger("IDRelatorioGerencial");
				relatorioGerencialTO.IDVendedor = rs.GetInteger("IDVendedor");
				relatorioGerencialTO.NomeArquivo = rs.GetString("NomeArquivo");
				relatorioGerencialTO.ArquivoRelatorio = rs.GetArrayByte("ArquivoRelatorio");
				relatorioGerencialTO.DtRecebimento = rs.GetNullableDateTime("DtRecebimento");
				relatorioGerencialTO.DtImportacao = rs.GetNullableDateTime("DtImportacao");
				arrayList.Add(relatorioGerencialTO);
			}
		}
		return (RelatorioGerencialTO[])arrayList.ToArray(typeof(RelatorioGerencialTO));
	}
}
