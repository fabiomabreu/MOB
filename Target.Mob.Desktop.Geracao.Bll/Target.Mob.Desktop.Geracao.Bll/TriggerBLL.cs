using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class TriggerBLL
{
	private string _connStringTargetERP;

	private string _tabela;

	private CargaTemplateSqlTO _template;

	public TriggerBLL(string connStringTargetERP, string tabela, List<CargaTemplateSqlTO> templates)
	{
		_connStringTargetERP = connStringTargetERP;
		_tabela = tabela;
		_template = templates.Where((CargaTemplateSqlTO x) => x.nomeTemplateSql.ToUpper() == "Trigger".ToUpper()).First();
	}

	internal static List<string> Select(List<CargaControleEntidadeTO> entidades)
	{
		List<string> list = new List<string>();
		foreach (CargaControleEntidadeTO item in entidades.Where((CargaControleEntidadeTO x) => x.commandSqlTabelasUtilizadas.Trim() != "").ToList())
		{
			List<string> second = item.commandSqlTabelasUtilizadas.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			list = list.Union(second).ToList();
			if (item.entidadeTipoRestricao)
			{
				list.Add($"tgtmob_Carga_{item.entidadeNome}");
			}
		}
		return list.Select((string r) => r).Distinct().ToList();
	}

	public void Gera_MultiThread(object eventosAtivos)
	{
		try
		{
			_gera();
		}
		catch (Exception ex)
		{
			GeraDadosBLL.Erro = true;
			GeraDadosBLL.ErroMsg = ex.ToString();
		}
		finally
		{
			((CountdownEvent)eventosAtivos).Signal();
		}
	}

	public void Gera_SingleThread()
	{
		try
		{
			_gera();
		}
		catch (Exception ex)
		{
			GeraDadosBLL.Erro = true;
			GeraDadosBLL.ErroMsg = ex.ToString();
		}
	}

	private void _gera()
	{
		string sqlCmd = GetSqlCmd();
		new TriggerDAL(_connStringTargetERP).Exec(sqlCmd);
	}

	private string GetSqlCmd()
	{
		return _template.scriptTemplateSql.Replace("{tabela}", _tabela).Replace("{rowidTemplate}", BitConverter.ToString(_template.rowid, 0, 8).Replace("-", ""));
	}
}
