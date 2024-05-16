using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class RelatorioPreDefinidoBLL
{
	public static DataTable Select(DbConnection connection, CadastroSPTO cadastroTO, string CodigoVendedor)
	{
		new DataTable();
		return RelatorioPreDefinidoDAL.Select(connection, cadastroTO, CodigoVendedor);
	}

	public static void Select_Carga(DbConnection connectionTargetERP, string nomeBd, string linkedServer, DbConnection connectionTargetMob)
	{
		RelatorioPreDefinidoDAL.Select_Carga(connectionTargetERP, nomeBd, linkedServer, connectionTargetMob);
	}
}
