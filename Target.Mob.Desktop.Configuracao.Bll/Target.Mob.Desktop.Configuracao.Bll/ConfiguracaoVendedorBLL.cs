using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorBLL
{
	public static void Merge(SqlTransaction transaction, ConfiguracaoVendedorTO instance)
	{
		if (Exists(transaction, instance.Id))
		{
			Update(transaction, instance);
		}
		else
		{
			Insert(transaction, instance);
		}
		ConfiguracaoVendedorClienteNovoFormPgtoTO configuracaoVendedorClienteNovoFormPgtoTO = new ConfiguracaoVendedorClienteNovoFormPgtoTO();
		configuracaoVendedorClienteNovoFormPgtoTO.IdConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorClienteNovoFormPgtoBLL.Delete(transaction, configuracaoVendedorClienteNovoFormPgtoTO);
		if (instance.ClienteNovoFormPgto != null)
		{
			foreach (ConfiguracaoVendedorClienteNovoFormPgtoTO item in instance.ClienteNovoFormPgto)
			{
				if (ConfiguracaoVendedorClienteNovoFormPgtoBLL.Exists(transaction, item))
				{
					ConfiguracaoVendedorClienteNovoFormPgtoBLL.Update(transaction, item);
				}
				else
				{
					ConfiguracaoVendedorClienteNovoFormPgtoBLL.Insert(transaction, item);
				}
			}
		}
		ConfiguracaoVendedorEstoqueTO configuracaoVendedorEstoqueTO = new ConfiguracaoVendedorEstoqueTO();
		configuracaoVendedorEstoqueTO.IdConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorEstoqueBLL.Delete(transaction, configuracaoVendedorEstoqueTO);
		if (instance.ConfiguracaoVendedorEstoque != null)
		{
			foreach (ConfiguracaoVendedorEstoqueTO item2 in instance.ConfiguracaoVendedorEstoque)
			{
				ConfiguracaoVendedorEstoqueBLL.Insert(transaction, item2);
			}
		}
		ConfiguracaoVendedorVisitaDiasSemanaTO configuracaoVendedorVisitaDiasSemanaTO = new ConfiguracaoVendedorVisitaDiasSemanaTO();
		configuracaoVendedorVisitaDiasSemanaTO.IdConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorVisitaDiasSemanaBLL.Delete(transaction, configuracaoVendedorVisitaDiasSemanaTO);
		if (instance.ConfiguracaoVendedorVisitaDiasSemana != null)
		{
			foreach (ConfiguracaoVendedorVisitaDiasSemanaTO item3 in instance.ConfiguracaoVendedorVisitaDiasSemana)
			{
				ConfiguracaoVendedorVisitaDiasSemanaBLL.Insert(transaction, item3);
			}
		}
		ConfiguracaoVendedorVisitaFrequenciaTO configuracaoVendedorVisitaFrequenciaTO = new ConfiguracaoVendedorVisitaFrequenciaTO();
		configuracaoVendedorVisitaFrequenciaTO.IdConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorVisitaFrequenciaBLL.Delete(transaction, configuracaoVendedorVisitaFrequenciaTO);
		if (instance.ConfiguracaoVendedorVisitaFrequencia != null)
		{
			foreach (ConfiguracaoVendedorVisitaFrequenciaTO configuracaoVendedorVisitaFrequencium in instance.ConfiguracaoVendedorVisitaFrequencia)
			{
				ConfiguracaoVendedorVisitaFrequenciaBLL.Insert(transaction, configuracaoVendedorVisitaFrequencium);
			}
		}
		ConfiguracaoVendedorTipoNotificacaoTO configuracaoVendedorTipoNotificacaoTO = new ConfiguracaoVendedorTipoNotificacaoTO();
		configuracaoVendedorTipoNotificacaoTO.IDConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorTipoNotificacaoBLL.Delete(transaction, configuracaoVendedorTipoNotificacaoTO);
		if (instance.ConfiguracaoVendedorVisitaFrequencia != null)
		{
			foreach (ConfiguracaoVendedorTipoNotificacaoTO item4 in instance.ConfiguracaoVendedorTipoNotificacao)
			{
				ConfiguracaoVendedorTipoNotificacaoBLL.Insert(transaction, item4);
			}
		}
		ConfiguracaoVendedorCoordenadaDiasSemanaTO configuracaoVendedorCoordenadaDiasSemanaTO = new ConfiguracaoVendedorCoordenadaDiasSemanaTO();
		configuracaoVendedorCoordenadaDiasSemanaTO.IdConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorCoordenadaDiasSemanaBLL.Delete(transaction, configuracaoVendedorCoordenadaDiasSemanaTO);
		if (instance.ConfiguracaoVendedorCoordenadaDiasSemana != null)
		{
			foreach (ConfiguracaoVendedorCoordenadaDiasSemanaTO item5 in instance.ConfiguracaoVendedorCoordenadaDiasSemana)
			{
				ConfiguracaoVendedorCoordenadaDiasSemanaBLL.Insert(transaction, item5);
			}
		}
		ConfiguracaoVendedorOrdenacaoGondolaTO configuracaoVendedorOrdenacaoGondolaTO = new ConfiguracaoVendedorOrdenacaoGondolaTO();
		configuracaoVendedorOrdenacaoGondolaTO.IdConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorOrdenacaoGondolaBLL.Delete(transaction, configuracaoVendedorOrdenacaoGondolaTO);
		if (instance.ConfiguracaoVendedorOrdenacaoGondola != null)
		{
			foreach (ConfiguracaoVendedorOrdenacaoGondolaTO item6 in instance.ConfiguracaoVendedorOrdenacaoGondola)
			{
				ConfiguracaoVendedorOrdenacaoGondolaBLL.Insert(transaction, item6);
			}
		}
		ConfiguracaoVendedorPaisTO configuracaoVendedorPaisTO = new ConfiguracaoVendedorPaisTO();
		configuracaoVendedorPaisTO.IDConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorPaisBLL.Delete(transaction, configuracaoVendedorPaisTO);
		if (instance.ConfiguracaoVendedorPais != null)
		{
			foreach (ConfiguracaoVendedorPaisTO configuracaoVendedorPai in instance.ConfiguracaoVendedorPais)
			{
				ConfiguracaoVendedorPaisBLL.Insert(transaction, configuracaoVendedorPai);
			}
		}
		ConfiguracaoVendedorInadimplenciaFormPgtoTO configuracaoVendedorInadimplenciaFormPgtoTO = new ConfiguracaoVendedorInadimplenciaFormPgtoTO();
		configuracaoVendedorInadimplenciaFormPgtoTO.IdConfiguracaoVendedor = instance.Id;
		ConfiguracaoVendedorInadimplenciaFormPgtoBLL.Delete(transaction, configuracaoVendedorInadimplenciaFormPgtoTO);
		if (instance.ConfiguracaoVendedorInadimplenciaFormPgto == null)
		{
			return;
		}
		foreach (ConfiguracaoVendedorInadimplenciaFormPgtoTO item7 in instance.ConfiguracaoVendedorInadimplenciaFormPgto)
		{
			ConfiguracaoVendedorInadimplenciaFormPgtoBLL.Insert(transaction, item7);
		}
	}

	public static List<ConfiguracaoVendedorTO> Select(SqlConnection connection, ConfiguracaoVendedorTO instance)
	{
		List<ConfiguracaoVendedorTO> list = ConfiguracaoVendedorDAL.Select(connection, instance);
		if (list != null)
		{
			foreach (ConfiguracaoVendedorTO item in list)
			{
				VendedorTO vendedorTO = new VendedorTO();
				vendedorTO.IdConfiguracaoVendedor = item.Id;
				item.Vendedor = VendedorBLL.Select(connection, vendedorTO);
			}
			foreach (ConfiguracaoVendedorTO item2 in list)
			{
				ConfiguracaoVendedorEstoqueTO configuracaoVendedorEstoqueTO = new ConfiguracaoVendedorEstoqueTO();
				configuracaoVendedorEstoqueTO.IdConfiguracaoVendedor = item2.Id;
				item2.ConfiguracaoVendedorEstoque = ConfiguracaoVendedorEstoqueBLL.Select(connection, configuracaoVendedorEstoqueTO);
			}
			foreach (ConfiguracaoVendedorTO item3 in list)
			{
				ConfiguracaoVendedorVisitaDiasSemanaTO configuracaoVendedorVisitaDiasSemanaTO = new ConfiguracaoVendedorVisitaDiasSemanaTO();
				configuracaoVendedorVisitaDiasSemanaTO.IdConfiguracaoVendedor = item3.Id;
				item3.ConfiguracaoVendedorVisitaDiasSemana = ConfiguracaoVendedorVisitaDiasSemanaBLL.Select(connection, configuracaoVendedorVisitaDiasSemanaTO);
			}
			foreach (ConfiguracaoVendedorTO item4 in list)
			{
				ConfiguracaoVendedorVisitaFrequenciaTO configuracaoVendedorVisitaFrequenciaTO = new ConfiguracaoVendedorVisitaFrequenciaTO();
				configuracaoVendedorVisitaFrequenciaTO.IdConfiguracaoVendedor = item4.Id;
				item4.ConfiguracaoVendedorVisitaFrequencia = ConfiguracaoVendedorVisitaFrequenciaBLL.Select(connection, configuracaoVendedorVisitaFrequenciaTO);
			}
			foreach (ConfiguracaoVendedorTO item5 in list)
			{
				ConfiguracaoVendedorCoordenadaDiasSemanaTO configuracaoVendedorCoordenadaDiasSemanaTO = new ConfiguracaoVendedorCoordenadaDiasSemanaTO();
				configuracaoVendedorCoordenadaDiasSemanaTO.IdConfiguracaoVendedor = item5.Id;
				item5.ConfiguracaoVendedorCoordenadaDiasSemana = ConfiguracaoVendedorCoordenadaDiasSemanaBLL.Select(connection, configuracaoVendedorCoordenadaDiasSemanaTO);
			}
			foreach (ConfiguracaoVendedorTO item6 in list)
			{
				ConfiguracaoVendedorPaisTO configuracaoVendedorPaisTO = new ConfiguracaoVendedorPaisTO();
				configuracaoVendedorPaisTO.IDConfiguracaoVendedor = item6.Id;
				item6.ConfiguracaoVendedorPais = ConfiguracaoVendedorPaisBLL.Select(connection, configuracaoVendedorPaisTO);
			}
		}
		return list;
	}

	public static ConfiguracaoVendedorTO Select(SqlConnection conexao, int id)
	{
		ConfiguracaoVendedorTO result = null;
		ConfiguracaoVendedorTO configuracaoVendedorTO = new ConfiguracaoVendedorTO();
		configuracaoVendedorTO.Id = id;
		List<ConfiguracaoVendedorTO> list = Select(conexao, configuracaoVendedorTO);
		if (list.Count > 0)
		{
			result = list[0];
		}
		return result;
	}

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorTO instance)
	{
		ConfiguracaoVendedorDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorTO instance)
	{
		ConfiguracaoVendedorDAL.Update(transaction, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ConfiguracaoVendedorDAL.Exists(transaction, id);
	}

	public static byte[] selectMaxRowId(DbConnection conexao)
	{
		return ConfiguracaoVendedorDAL.selectMaxRowId(conexao);
	}
}
