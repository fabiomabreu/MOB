using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class CategoriaAnotacaoDAL
{
	private const string SELECT_MAX_ROWID = "uspCategoriaAnotacaoMaxRowId";

	private const string SELECT = "uspCategoriaAnotacaoSelect";

	private const string UPDATE = "uspCategoriaAnotacaoUpdate";

	private const string INSERT = "uspCategoriaAnotacaoInsert";

	public static byte[] selectMaxRowId(DbConnection connTargetErp)
	{
		byte[] result = null;
		connTargetErp.ClearParameters();
		object obj = connTargetErp.ExecuteScalar(CommandType.StoredProcedure, "uspCategoriaAnotacaoMaxRowId");
		if (obj != null && obj.ToString() != "")
		{
			result = (byte[])obj;
		}
		return result;
	}

	public static CategoriaAnotacaoTO[] Select(DbConnection connTargetErp, CategoriaAnotacaoTO categAnot)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdCategoriaAnotacao", categAnot.IdCategoriaAnotacao);
		connTargetErp.AddParameters("@Ativo", categAnot.Ativo);
		connTargetErp.AddParameters("@Descricao", categAnot.Descricao);
		connTargetErp.AddParameters("@RowId", categAnot.RowId);
		using BasicRS rs = connTargetErp.ExecuteReaderRS(CommandType.StoredProcedure, "uspCategoriaAnotacaoSelect");
		return CreateInstances(rs);
	}

	public static void Update(DbConnection connTargetErp, CategoriaAnotacaoTO categAnot)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdCategoriaAnotacao", categAnot.IdCategoriaAnotacao);
		connTargetErp.AddParameters("@Ativo", categAnot.Ativo);
		connTargetErp.AddParameters("@Descricao", categAnot.Descricao);
		connTargetErp.AddParameters("@RowId", categAnot.RowId);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspCategoriaAnotacaoUpdate");
	}

	public static void Insert(DbConnection connTargetErp, CategoriaAnotacaoTO categAnot)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@IdCategoriaAnotacao", categAnot.IdCategoriaAnotacao);
		connTargetErp.AddParameters("@Ativo", categAnot.Ativo);
		connTargetErp.AddParameters("@Descricao", categAnot.Descricao);
		connTargetErp.AddParameters("@RowId", categAnot.RowId);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspCategoriaAnotacaoInsert");
	}

	private static CategoriaAnotacaoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CategoriaAnotacaoTO categoriaAnotacaoTO = new CategoriaAnotacaoTO();
				categoriaAnotacaoTO.IdCategoriaAnotacao = rs.GetInteger("IdCategoriaAnotacao");
				categoriaAnotacaoTO.Descricao = rs.GetString("Descricao");
				categoriaAnotacaoTO.Ativo = rs.GetNullableBoolean("Ativo");
				categoriaAnotacaoTO.RowId = rs.GetArrayByte("RowId");
				arrayList.Add(categoriaAnotacaoTO);
			}
		}
		return (CategoriaAnotacaoTO[])arrayList.ToArray(typeof(CategoriaAnotacaoTO));
	}
}
