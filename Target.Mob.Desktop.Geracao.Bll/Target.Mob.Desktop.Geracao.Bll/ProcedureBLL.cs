using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class ProcedureBLL
{
	private string _connStringTargetERP;

	private CargaControleEntidadeTO _entidade;

	private CargaControleEntidadeTO _entidadeRestricao;

	private CargaTemplateSqlTO _templateEntidade;

	private CargaTemplateSqlTO _templateEntidadeRestricao;

	private CargaTemplateSqlTO _templateTrigger;

	public ProcedureBLL(string connStringTargetERP, CargaControleEntidadeTO entidade, List<CargaTemplateSqlTO> templates)
	{
		_connStringTargetERP = connStringTargetERP;
		_entidade = entidade;
		_templateEntidade = templates.Where((CargaTemplateSqlTO x) => x.nomeTemplateSql.ToUpper() == "ProcedureEntidade".ToUpper()).First();
		_templateEntidadeRestricao = templates.Where((CargaTemplateSqlTO x) => x.nomeTemplateSql.ToUpper() == "ProcedureEntidadeRestricao".ToUpper()).First();
		_templateTrigger = templates.Where((CargaTemplateSqlTO x) => x.nomeTemplateSql.ToUpper() == "Trigger".ToUpper()).First();
		if (_entidade.entidadeTipoRestricao)
		{
			string text = _entidade.tipoSistema.ToUpper();
			_entidadeRestricao = entidade;
			_entidade = new CargaControleEntidadeTO();
			_entidade.idCargaControleEntidade = _entidadeRestricao.idCargaControleEntidade;
			_entidade.entidadeNome = _entidadeRestricao.entidadeNome;
			_entidade.entidadeTipoRestricao = false;
			_entidade.commandSqlOnda = 1;
			_entidade.tipoSistema = entidade.tipoSistema;
			string arg = "";
			if ("SUPERVISOR".Equals(_entidade.tipoSistema.ToUpper()))
			{
				_entidade.commandSqlEntidadeRestricaoNomeSupervisor = "RESTRSUPE_SUPERVISOR";
				arg = string.Format("SELECT e.cd_{0} as Codigo, 1 Major, 0 Minor, 0 Build, 0 Revision FROM {1} e WHERE e.Ativo = 1 and ISNULL(e.cd_vend_sup, SPACE(0) ) != SPACE(0) ", "vend_sup", "EQUIPE");
			}
			else if ("PROMOTOR".Equals(_entidade.tipoSistema.ToUpper()))
			{
				_entidade.commandSqlEntidadeRestricaoNomePromotor = "RESTRPROM_PROMOTOR";
				arg = string.Format("SELECT p.cd_{0} as Codigo, 1 Major, 0 Minor, 0 Build, 0 Revision FROM {0} p WHERE p.Ativo = 1", text);
			}
			else if ("VENDEDOR".Equals(_entidade.tipoSistema.ToUpper()))
			{
				_entidade.commandSqlEntidadeRestricaoNomeVendedor = "RESTRVEND_VENDEDOR";
				arg = string.Format("SELECT v.codigo{0} as Codigo, v.Major, v.Minor, v.Build, v.Revision FROM tgtmob_{0} v WHERE v.Ativo = 1", text);
			}
			else if ("OPME".Equals(_entidade.tipoSistema.ToUpper()))
			{
				_entidade.commandSqlEntidadeRestricaoNomeInventariador = "RESTROPME_INVENTARIADOR";
				arg = $"SELECT CdUsuario as Codigo, 1 Major, 0 Minor, 0 Build, 0 Revision FROM OpmeUsuario";
			}
			_entidade.commandSqlEntidadeRestricaoColumn = "codigo";
			_entidade.commandSqlColumnKey = "codigo";
			_entidade.commandSqlQuery = string.Format("\t\t\r\n                            \r\n\t\t\t\tWITH CTE\r\n\t\t\t\tAS\r\n\t\t\t\t(\r\n\t\t\t\t\t{2}\r\n\t\t\t\t),\r\n\t\t\t\tCTE_DADOS\r\n\t\t\t\tAS\r\n\t\t\t\t(\r\n\t\t\t\t\tSELECT\r\n\t\t\t\t\t\t'{0}'                       AS entidadeNome, \r\n\t\t\t\t\t\tv.codigo                    AS codigo,\r\n\t\t\t\t\t\tISNULL(\r\n\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\t\t\t(\r\n\t\t\t\t\t\t\t\t\t\t\t\tSELECT\tISNULL(a.chave,'')\r\n\t\t\t\t\t\t\t\t\t\t\t\tFROM\ttgtmob_Carga_{0} a\r\n\t\t\t\t\t\t\t\t\t\t\t\tWHERE\ta.codigo = v.codigo\r\n\t\t\t\t\t\t\t\t\t\t\t\tORDER BY a.chave\r\n\t\t\t\t\t\t\t\t\t\t\t\tFOR XML PATH('c')\r\n\t\t\t\t\t\t\t\t\t\t)\r\n\t\t\t\t\t\t\t\t\t\t,'</c>','<c>')\r\n\t\t\t\t\t\t\t\t\t,'<c><c>','|')\r\n\t\t\t\t\t\t\t\t,'<c>','')          \r\n\t\t\t\t\t\t\t,'&amp;','&')\r\n\t\t\t\t\t\t,'')\t\t\t\t\tAS dados,\r\n\t\t\t\t\t\tv.Major                 AS Major, \r\n                        v.Minor                 AS Minor, \r\n                        v.Build                 AS Build, \r\n                        v.Revision              AS Revision\r\n\t\t\t\t\tFROM\t\r\n\t\t\t\t\t\tCTE v\r\n                    WHERE\r\n\t\t\t\t\t\tNOT EXISTS (SELECT 1 FROM tgtmob_Carga_{0} a WHERE a.codigo = '-1')\r\n\t\t\t\t\tGROUP BY\r\n\t\t\t\t\t\tv.codigo, v.Major, v.Minor, v.Build, v.Revision\r\n\r\n                    UNION ALL\r\n\t\t\t\t\t\t\r\n\t\t\t\t\tSELECT\r\n\t\t\t\t\t\t'{0}'                               AS entidadeNome, \r\n\t\t\t\t\t\t'-1'\t\t\t\t\t\t        AS codigo,\r\n\t\t\t\t\t\tISNULL(\r\n\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\t\t\tREPLACE(\r\n\t\t\t\t\t\t\t\t\t\t(\r\n\t\t\t\t\t\t\t\t\t\t\t\tSELECT\tISNULL(a.chave,'')\r\n\t\t\t\t\t\t\t\t\t\t\t\tFROM\ttgtmob_Carga_{0} a\r\n\t\t\t\t\t\t\t\t\t\t\t\tWHERE\ta.codigo = '-1'\r\n\t\t\t\t\t\t\t\t\t\t\t\tORDER BY a.chave\r\n\t\t\t\t\t\t\t\t\t\t\t\tFOR XML PATH('c')\r\n\t\t\t\t\t\t\t\t\t\t)\r\n\t\t\t\t\t\t\t\t\t\t,'</c>','<c>')\r\n\t\t\t\t\t\t\t\t\t,'<c><c>','|')\r\n\t\t\t\t\t\t\t\t,'<c>','')          \r\n\t\t\t\t\t\t\t,'&amp;','&')\r\n\t\t\t\t\t\t,'')\t\t\t\t\tAS dados,\r\n\t\t\t\t\t\tNULL                 AS Major, \r\n                        NULL                 AS Minor, \r\n                        NULL                 AS Build, \r\n                        NULL\t\t\t     AS Revision\r\n                    WHERE\r\n\t\t\t\t\t\tEXISTS (SELECT 1 FROM tgtmob_Carga_{0} a WHERE a.codigo = '-1')\r\n\t\t\t\t)\r\n\r\n                SELECT\r\n\t\t\t\t\tentidadeNome                entidadeNome,\r\n\t\t\t\t\tCodigo                      Codigo,\r\n\t\t\t\t\tdados                       dados\r\n\t\t\t\tINTO\t\r\n\t\t\t\t\t#dados\r\n\t\t\t\tFROM\r\n\t\t\t\t\tCTE_DADOS\r\n\t\t\t\tWHERE\r\n\t\t\t\t\tLEN(dados) > 0 \r\n                    OR \r\n                    '{1}' != 'VENDEDOR'\r\n\t\t\t\t\tOR \r\n\t\t\t\t\t(\r\n\t\t\t\t\t\t(MAJOR >= 4) \r\n\t\t\t\t\t\tOR \r\n\t\t\t\t\t\t(MAJOR = 3 AND MINOR >= 15)\r\n\t\t\t\t\t\tOR\r\n\t\t\t\t\t\t(MAJOR = 3 AND MINOR = 14 AND BUILD >= 1)\r\n\t\t\t\t\t\tOR\r\n\t\t\t\t\t\t(MAJOR = 3 AND MINOR = 14 AND BUILD = 0 AND REVISION >= 9)\r\n\t\t\t\t\t) ", _entidade.entidadeNome, text, arg);
			_entidade.commandSqlTabelasUtilizadas = $"tgtmob_Carga_{_entidade.entidadeNome}";
			_entidade.commandSqlColumnDados = "dados";
			_entidade.ativo = _entidadeRestricao.ativo;
			_entidade.rowid = _entidadeRestricao.rowid;
		}
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
		string sqlCmd = GetSqlCmd(_entidade, _templateEntidade.scriptTemplateSql, _templateEntidade.rowid, _templateTrigger.rowid);
		new ProcedureDAL(_connStringTargetERP).Exec(sqlCmd);
		if (_entidadeRestricao != null)
		{
			sqlCmd = GetSqlCmd(_entidadeRestricao, _templateEntidadeRestricao.scriptTemplateSql, _templateEntidadeRestricao.rowid, _templateTrigger.rowid);
			new ProcedureDAL(_connStringTargetERP).Exec(sqlCmd);
		}
	}

	private string GetSqlCmd(CargaControleEntidadeTO e, string templateSql, byte[] rowidTemplate, byte[] rowidTemplateTrigger)
	{
		return templateSql.Replace("{commandSqlQuery}", e.commandSqlQuery.Replace("'", "''")).Replace("{idCargaControleEntidade}", e.idCargaControleEntidade.ToString()).Replace("{entidadeNome}", e.entidadeNome)
			.Replace("{entidadeTipoRestricao}", e.entidadeTipoRestricao.ToString())
			.Replace("{commandSqlOnda}", e.commandSqlOnda.ToString())
			.Replace("{commandSqlEntidadeRestricaoNomeVendedor}", e.commandSqlEntidadeRestricaoNomeVendedor)
			.Replace("{commandSqlEntidadeRestricaoNomePromotor}", e.commandSqlEntidadeRestricaoNomePromotor)
			.Replace("{commandSqlEntidadeRestricaoNomeSupervisor}", e.commandSqlEntidadeRestricaoNomeSupervisor)
			.Replace("{commandSqlEntidadeRestricaoNomeInventariador}", e.commandSqlEntidadeRestricaoNomeInventariador)
			.Replace("{commandSqlEntidadeRestricaoColumn}", e.commandSqlEntidadeRestricaoColumn)
			.Replace("{commandSqlColumnKey}", e.commandSqlColumnKey)
			.Replace("{commandSqlTabelasUtilizadas}", e.commandSqlTabelasUtilizadas)
			.Replace("{commandSqlColumnDados}", e.commandSqlColumnDados.Replace("'", "''"))
			.Replace("{ativo}", e.ativo.ToString())
			.Replace("{rowidTemplateTrigger}", BitConverter.ToString(rowidTemplateTrigger, 0, 8).Replace("-", ""))
			.Replace("{rowidTemplate}", BitConverter.ToString(rowidTemplate, 0, 8).Replace("-", ""))
			.Replace("{rowid}", BitConverter.ToString(e.rowid, 0, 8).Replace("-", ""))
			.Replace("{tipoSistema}", e.tipoSistema.ToString());
	}
}
