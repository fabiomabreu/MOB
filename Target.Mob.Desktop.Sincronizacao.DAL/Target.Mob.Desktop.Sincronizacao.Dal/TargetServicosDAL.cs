using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class TargetServicosDAL
{
	private const string SELECT = "uspTargetServicosSelect";

	public static TargetServicosTO Select(DbConnection connection, int IdServico)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdServico", IdServico);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTargetServicosSelect"));
	}

	private static TargetServicosTO CreateInstances(BasicRS rs)
	{
		TargetServicosTO targetServicosTO = null;
		using (rs)
		{
			while (rs.MoveNext())
			{
				targetServicosTO = new TargetServicosTO();
				targetServicosTO.IdServico = rs.GetInteger("TargetServicosID");
				targetServicosTO.Descricao = rs.GetString("DescricaoServico");
				targetServicosTO.Endereco = rs.GetString("EnderecoServidor");
				targetServicosTO.Hostname = rs.GetString("HostnameServidor");
				targetServicosTO.Porta = rs.GetInteger("PortaAPI");
			}
			return targetServicosTO;
		}
	}
}
