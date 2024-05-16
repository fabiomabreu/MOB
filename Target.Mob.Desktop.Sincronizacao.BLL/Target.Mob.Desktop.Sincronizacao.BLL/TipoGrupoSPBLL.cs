using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class TipoGrupoSPBLL
{
	public static void Merge(DbConnection connection, TipoGrupoSPTO instance)
	{
		if (instance.ListaCadastroSPTO != null)
		{
			foreach (CadastroSPTO item in instance.ListaCadastroSPTO)
			{
				CadastroSPTO cadastroSPTO = new CadastroSPTO();
				cadastroSPTO.IDCadastroSP = item.IDCadastroSP;
				cadastroSPTO.Descricao = item.Descricao;
				cadastroSPTO.Texto = item.Texto;
				cadastroSPTO.Ativo = item.Ativo;
				cadastroSPTO.Automatica = item.Automatica;
				if (CadastroSPBLL.Exists(connection, instance.IDCadastroSP.Value))
				{
					CadastroSPBLL.Update(connection, cadastroSPTO);
				}
				else
				{
					CadastroSPBLL.Insert(connection, cadastroSPTO);
				}
			}
		}
		if (instance.ListTipoGrupoTO != null)
		{
			foreach (TipoGrupoTO item2 in instance.ListTipoGrupoTO)
			{
				TipoGrupoTO tipoGrupoTO = new TipoGrupoTO();
				tipoGrupoTO.IdTipoGrupo = item2.IdTipoGrupo;
				tipoGrupoTO.Descricao = item2.Descricao;
				tipoGrupoTO.Ativo = item2.Ativo;
				if (TipoGrupoBLL.Exists(connection, instance.IDTipoGrupo.Value))
				{
					TipoGrupoBLL.Update(connection, tipoGrupoTO);
				}
				else
				{
					TipoGrupoBLL.Insert(connection, tipoGrupoTO);
				}
			}
		}
		if (instance != null)
		{
			TipoGrupoSPTO tipoGrupoSPTO = new TipoGrupoSPTO();
			tipoGrupoSPTO.IDCadastroSP = instance.IDCadastroSP.Value;
			tipoGrupoSPTO.IDTipoGrupo = instance.IDTipoGrupo.Value;
			if (!Exists(connection, tipoGrupoSPTO))
			{
				Insert(connection, tipoGrupoSPTO);
			}
		}
		if (instance.ListaVendedorTO == null)
		{
			return;
		}
		foreach (VendedorRelatorioTO item3 in instance.ListaVendedorTO)
		{
			VendedorRelatorioTO vendedorRelatorioTO = new VendedorRelatorioTO();
			vendedorRelatorioTO.IdVendedor = item3.IdVendedor;
			vendedorRelatorioTO.CodigoVendedor = item3.CodigoVendedor;
			if (VendedorRelatoBLL.Exists(connection, vendedorRelatorioTO))
			{
				VendedorRelatorioTO[] array = VendedorRelatoBLL.Select(connection, vendedorRelatorioTO);
				foreach (VendedorRelatorioTO vendedorRelatorioTO2 in array)
				{
					vendedorRelatorioTO.IdVendedor = vendedorRelatorioTO2.IdVendedor;
					vendedorRelatorioTO.CodigoVendedor = vendedorRelatorioTO2.CodigoVendedor;
					vendedorRelatorioTO.Nome = vendedorRelatorioTO2.Nome;
					vendedorRelatorioTO.IdConfiguracaoVendedor = vendedorRelatorioTO2.IdConfiguracaoVendedor;
					vendedorRelatorioTO.Major = vendedorRelatorioTO2.Major;
					vendedorRelatorioTO.Minor = vendedorRelatorioTO2.Minor;
					vendedorRelatorioTO.Build = vendedorRelatorioTO2.Build;
					vendedorRelatorioTO.Revision = vendedorRelatorioTO2.Revision;
					vendedorRelatorioTO.ForcaCargaCompleta = vendedorRelatorioTO2.ForcaCargaCompleta;
					vendedorRelatorioTO.Ativo = vendedorRelatorioTO2.Ativo;
					vendedorRelatorioTO.IDTipoGrupo = item3.IDTipoGrupo;
					VendedorRelatoBLL.Update(connection, vendedorRelatorioTO);
				}
			}
		}
	}

	public static void LimparTipoGrupo(DbConnection connection)
	{
		VendedorRelatorioTO vendedorRelatorioTO = new VendedorRelatorioTO();
		VendedorRelatorioTO[] array = VendedorRelatoBLL.SelectTipoGrupo(connection, vendedorRelatorioTO);
		if (array == null)
		{
			return;
		}
		VendedorRelatorioTO[] array2 = array;
		foreach (VendedorRelatorioTO vendedorRelatorioTO2 in array2)
		{
			vendedorRelatorioTO.IdVendedor = vendedorRelatorioTO2.IdVendedor;
			vendedorRelatorioTO.CodigoVendedor = vendedorRelatorioTO2.CodigoVendedor;
			vendedorRelatorioTO.Nome = vendedorRelatorioTO2.Nome;
			vendedorRelatorioTO.IdConfiguracaoVendedor = vendedorRelatorioTO2.IdConfiguracaoVendedor;
			vendedorRelatorioTO.Major = vendedorRelatorioTO2.Major;
			vendedorRelatorioTO.Minor = vendedorRelatorioTO2.Minor;
			vendedorRelatorioTO.Build = vendedorRelatorioTO2.Build;
			vendedorRelatorioTO.Revision = vendedorRelatorioTO2.Revision;
			vendedorRelatorioTO.ForcaCargaCompleta = vendedorRelatorioTO2.ForcaCargaCompleta;
			vendedorRelatorioTO.Ativo = vendedorRelatorioTO2.Ativo;
			vendedorRelatorioTO.IDTipoGrupo = null;
			VendedorRelatoBLL.Update(connection, vendedorRelatorioTO);
		}
		TipoGrupoSPTO tipoGrupoSPTO = new TipoGrupoSPTO();
		TipoGrupoSPTO[] array3 = Select(connection, tipoGrupoSPTO);
		if (array3 != null)
		{
			TipoGrupoSPTO[] array4 = array3;
			foreach (TipoGrupoSPTO tipoGrupoSPTO2 in array4)
			{
				tipoGrupoSPTO.IDTipoGrupoSP = tipoGrupoSPTO2.IDTipoGrupoSP.Value;
				Delete(connection, tipoGrupoSPTO);
			}
		}
	}

	public static TipoGrupoSPTO[] Select(DbConnection connection, TipoGrupoSPTO tipoGrupoSPTO)
	{
		TipoGrupoSPTO[] array = TipoGrupoSPDAL.Select(connection, tipoGrupoSPTO);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, TipoGrupoSPTO IDTipoGrupoSP)
	{
		TipoGrupoSPDAL.Insert(connection, IDTipoGrupoSP);
	}

	internal static void Update(DbConnection connection, TipoGrupoSPTO IDTipoGrupoSP)
	{
		TipoGrupoSPDAL.Update(connection, IDTipoGrupoSP);
	}

	public static bool Exists(DbConnection connection, TipoGrupoSPTO IDTipoGrupoSP)
	{
		return TipoGrupoSPDAL.Exists(connection, IDTipoGrupoSP);
	}

	internal static void Delete(DbConnection connection, TipoGrupoSPTO IdTipoGrupoSP)
	{
		TipoGrupoSPDAL.Delete(connection, IdTipoGrupoSP);
	}
}
