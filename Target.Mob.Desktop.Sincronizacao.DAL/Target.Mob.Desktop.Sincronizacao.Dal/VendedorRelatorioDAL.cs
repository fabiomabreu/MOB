using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class VendedorRelatorioDAL
{
	private const string SELECT = "uspVendedorSel";

	private const string SELECTTIPOGRUPO = "uspVendedorSelTipoGrupo";

	private const string EXISTS = "uspVendedorSel";

	private const string UPDATE = "uspVendedorUpd";

	public static void Update(DbConnection connection, VendedorRelatorioTO value)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", value.IdVendedor);
		connection.AddParameters("@CodigoVendedor", value.CodigoVendedor);
		connection.AddParameters("@Nome", value.Nome);
		connection.AddParameters("@IdConfiguracaoVendedor", value.IdConfiguracaoVendedor);
		connection.AddParameters("@Major", value.Major);
		connection.AddParameters("@Minor", value.Minor);
		connection.AddParameters("@Build", value.Build);
		connection.AddParameters("@Revision", value.Revision);
		connection.AddParameters("@ForcaCargaCompleta", value.ForcaCargaCompleta);
		connection.AddParameters("@Ativo", value.Ativo);
		connection.AddParameters("@IDTipoGrupo", value.IDTipoGrupo);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspVendedorUpd");
	}

	public static VendedorRelatorioTO[] Select(DbConnection connection, VendedorRelatorioTO value)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", value.IdVendedor);
		connection.AddParameters("@CodigoVendedor", value.CodigoVendedor);
		connection.AddParameters("@Nome", value.Nome);
		connection.AddParameters("@IdConfiguracaoVendedor", value.IdConfiguracaoVendedor);
		connection.AddParameters("@Major", value.Major);
		connection.AddParameters("@Minor", value.Minor);
		connection.AddParameters("@Build", value.Build);
		connection.AddParameters("@Revision", value.Revision);
		connection.AddParameters("@ForcaCargaCompleta", value.ForcaCargaCompleta);
		connection.AddParameters("@Ativo", value.Ativo);
		connection.AddParameters("@IDTipoGrupo", value.IDTipoGrupo);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspVendedorSel"));
	}

	public static VendedorRelatorioTO[] SelectTipoGrupo(DbConnection connection, VendedorRelatorioTO value)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", value.IdVendedor);
		connection.AddParameters("@CodigoVendedor", value.CodigoVendedor);
		connection.AddParameters("@Nome", value.Nome);
		connection.AddParameters("@IdConfiguracaoVendedor", value.IdConfiguracaoVendedor);
		connection.AddParameters("@Major", value.Major);
		connection.AddParameters("@Minor", value.Minor);
		connection.AddParameters("@Build", value.Build);
		connection.AddParameters("@Revision", value.Revision);
		connection.AddParameters("@ForcaCargaCompleta", value.ForcaCargaCompleta);
		connection.AddParameters("@Ativo", value.Ativo);
		connection.AddParameters("@IDTipoGrupo", value.IDTipoGrupo);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspVendedorSelTipoGrupo"));
	}

	public static bool Exists(DbConnection connection, VendedorRelatorioTO value)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", value.IdVendedor);
		connection.AddParameters("@CodigoVendedor", value.CodigoVendedor);
		connection.AddParameters("@Nome", value.Nome);
		connection.AddParameters("@IdConfiguracaoVendedor", value.IdConfiguracaoVendedor);
		connection.AddParameters("@Major", value.Major);
		connection.AddParameters("@Minor", value.Minor);
		connection.AddParameters("@Build", value.Build);
		connection.AddParameters("@Revision", value.Revision);
		connection.AddParameters("@ForcaCargaCompleta", value.ForcaCargaCompleta);
		connection.AddParameters("@Ativo", value.Ativo);
		connection.AddParameters("@IDTipoGrupo", value.IDTipoGrupo);
		return connection.ExecuteScalar(CommandType.StoredProcedure, "uspVendedorSel") != null;
	}

	private static VendedorRelatorioTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				VendedorRelatorioTO vendedorRelatorioTO = new VendedorRelatorioTO();
				vendedorRelatorioTO.IdVendedor = rs.GetInteger("Id");
				vendedorRelatorioTO.CodigoVendedor = rs.GetString("CodigoVendedor");
				vendedorRelatorioTO.Nome = rs.GetString("nome");
				vendedorRelatorioTO.IdConfiguracaoVendedor = rs.GetNullableInteger("IdConfiguracaoVendedor");
				vendedorRelatorioTO.Major = rs.GetNullableInteger("Major");
				vendedorRelatorioTO.Minor = rs.GetNullableInteger("Minor");
				vendedorRelatorioTO.Build = rs.GetNullableInteger("Build");
				vendedorRelatorioTO.Revision = rs.GetNullableInteger("Revision");
				vendedorRelatorioTO.ForcaCargaCompleta = rs.GetNullableBoolean("ForcaCargaCompleta");
				vendedorRelatorioTO.Ativo = rs.GetNullableBoolean("Ativo");
				vendedorRelatorioTO.IDTipoGrupo = rs.GetNullableInteger("IDTipoGrupo");
				arrayList.Add(vendedorRelatorioTO);
			}
		}
		return (VendedorRelatorioTO[])arrayList.ToArray(typeof(VendedorRelatorioTO));
	}
}
