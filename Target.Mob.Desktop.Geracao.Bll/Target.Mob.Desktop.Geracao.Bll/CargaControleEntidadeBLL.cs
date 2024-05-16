using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class CargaControleEntidadeBLL
{
	private string _connStringTargetERP;

	private CargaControleEntidadeTO _entidade;

	private CargaTemplateSqlTO _templateEntidade;

	private CargaTemplateSqlTO _templateEntidadeRestricao;

	public CargaControleEntidadeBLL(string connStringTargetERP, CargaControleEntidadeTO e, List<CargaTemplateSqlTO> templates)
	{
		_connStringTargetERP = connStringTargetERP;
		_entidade = e;
		_templateEntidade = templates.Where((CargaTemplateSqlTO x) => x.nomeTemplateSql.ToUpper() == "ProcedureEntidade".ToUpper()).First();
		_templateEntidadeRestricao = templates.Where((CargaTemplateSqlTO x) => x.nomeTemplateSql.ToUpper() == "ProcedureEntidadeRestricao".ToUpper()).First();
	}

	public static List<CargaControleEntidadeTO> Select(string connStringTargetERP)
	{
		return CargaControleEntidadeDAL.Select(connStringTargetERP);
	}

	internal void Gera_MultiThread(object eventosAtivos)
	{
		try
		{
			_gera();
		}
		catch (Exception ex)
		{
			GeraDadosBLL.Erro = true;
			GeraDadosBLL.ErroMsg = $"<Entidade: {_entidade.entidadeNome}> <Erro: {ex.ToString()}>";
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
			GeraDadosBLL.ErroMsg = $"<Entidade: {_entidade.entidadeNome}> <Erro: {ex.ToString()}>";
		}
	}

	private void _gera()
	{
		string sqlProcName = GetSqlProcName(_entidade.entidadeTipoRestricao);
		new CargaControleEntidadeDAL(_connStringTargetERP).ExecSqlProc(sqlProcName);
		if (_entidade.entidadeTipoRestricao)
		{
			sqlProcName = GetSqlProcName(entidadeTipoRestricao: false);
			new CargaControleEntidadeDAL(_connStringTargetERP).ExecSqlProc(sqlProcName);
		}
	}

	private string GetSqlProcName(bool entidadeTipoRestricao)
	{
		byte[] array = (entidadeTipoRestricao ? _templateEntidadeRestricao.rowid : _templateEntidade.rowid);
		return string.Format("tgtmob_uspCargaTransformaAuto{0}_{1}_{2}_{3}_{4}", entidadeTipoRestricao ? "_r" : "", _entidade.entidadeNome, _entidade.idCargaControleEntidade, BitConverter.ToString(_entidade.rowid, 0, 8).Replace("-", ""), BitConverter.ToString(array, 0, 8).Replace("-", ""));
	}
}
