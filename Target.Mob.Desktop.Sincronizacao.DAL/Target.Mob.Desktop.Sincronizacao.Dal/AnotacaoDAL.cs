using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class AnotacaoDAL
{
	private const string SELECT = "uspAnotacoesSelect";

	private const string UPDATE = "uspAnotacoesUpdate";

	private const string INSERT = "uspAnotacoesInsert";

	public static AnotacaoTO[] Select(DbConnection connTargetErp, AnotacaoTO anotacao)
	{
		connTargetErp.ClearParameters();
		setParametros(connTargetErp, anotacao);
		using BasicRS rs = connTargetErp.ExecuteReaderRS(CommandType.StoredProcedure, "uspAnotacoesSelect");
		return CreateInstances(rs);
	}

	public static void Update(DbConnection connTargetErp, AnotacaoTO anotacao)
	{
		connTargetErp.ClearParameters();
		setParametros(connTargetErp, anotacao);
		connTargetErp.AddParameters("@CodigoAnotacao", anotacao.CodigoAnotacao);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspAnotacoesUpdate");
	}

	public static void Insert(DbConnection connTargetErp, AnotacaoTO anotacao)
	{
		connTargetErp.ClearParameters();
		setParametros(connTargetErp, anotacao);
		object obj = connTargetErp.ExecuteScalar(CommandType.StoredProcedure, "uspAnotacoesInsert");
		anotacao.CodigoAnotacao = int.Parse(obj.ToString());
	}

	private static AnotacaoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AnotacaoTO anotacaoTO = new AnotacaoTO();
				anotacaoTO.CodigoAnotacao = rs.GetNullableInteger("CodigoAnotacao");
				anotacaoTO.CodigoCategoriaAnotacao = rs.GetNullableInteger("CodigoCategoriaAnotacao");
				anotacaoTO.CodigoCliente = rs.GetNullableInteger("CodigoCliente");
				anotacaoTO.CodigoVendedor = rs.GetString("CodigoVendedor");
				anotacaoTO.CodigoEmpresa = rs.GetNullableInteger("CodigoEmpresa");
				anotacaoTO.NumeroPedVda = rs.GetNullableInteger("NumeroPedVda");
				anotacaoTO.DataHora = rs.GetNullableDateTime("DataHora");
				anotacaoTO.Texto = rs.GetString("Texto");
				anotacaoTO.DtLembrete = rs.GetNullableDateTime("DtLembrete");
				arrayList.Add(anotacaoTO);
			}
		}
		return (AnotacaoTO[])arrayList.ToArray(typeof(AnotacaoTO));
	}

	private static void setParametros(DbConnection connTargetErp, AnotacaoTO anotacao)
	{
		connTargetErp.AddParameters("@CodigoCategoriaAnotacao", anotacao.CodigoCategoriaAnotacao);
		connTargetErp.AddParameters("@CodigoCliente", anotacao.CodigoCliente);
		connTargetErp.AddParameters("@CodigoVendedor", anotacao.CodigoVendedor);
		connTargetErp.AddParameters("@CodigoEmpresa", anotacao.CodigoEmpresa);
		connTargetErp.AddParameters("@NumeroPedVda", anotacao.NumeroPedVda);
		connTargetErp.AddParameters("@DataHora", anotacao.DataHora);
		connTargetErp.AddParameters("@Texto", anotacao.Texto);
		connTargetErp.AddParameters("@DtLembrete", anotacao.DtLembrete);
	}
}
