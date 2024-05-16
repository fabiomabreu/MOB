using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Dao;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public static class VersaoDAL
{
	private static VersaoERPVO _versaoERPAtual;

	private static VersaoERPVO _versaoERPMinima;

	public static VersaoERPVO VERSAO_ERP_ATUAL
	{
		get
		{
			if (_versaoERPAtual == null)
			{
				_versaoERPAtual = ObterVersaoERP();
			}
			return _versaoERPAtual;
		}
	}

	public static VersaoERPVO VERSAO_MINIMA
	{
		get
		{
			if (_versaoERPMinima == null)
			{
				ObterVersaoERPMinima();
			}
			return _versaoERPMinima;
		}
	}

	private static VersaoERPVO ObterVersaoERP()
	{
		string cmdText = "select top 1 cast(substring(nu_versao,0, CHARINDEX('.', nu_versao))  as int) MAJOR, \r\n\t\t\t                             cast(substring(nu_versao,CHARINDEX('.', nu_versao) + 1, LEN(nu_versao))  as int) MINOR,\r\n\t\t\t                             cast(nu_release  as int) BUILD, \r\n\t\t\t                             cast(nu_patch  as int) REVISION\r\n                        from versao_erp a\r\n                        order by a.seq desc";
		VersaoERPVO versaoERPVO = new VersaoERPVO();
		using (SqlDataReader sqlDataReader = SqlServerHelper.executeReader(cmdText))
		{
			while (sqlDataReader.Read())
			{
				versaoERPVO.MAJOR = sqlDataReader.GetInt32(0);
				versaoERPVO.MINOR = sqlDataReader.GetInt32(1);
				versaoERPVO.BUILD = sqlDataReader.GetInt32(2);
				versaoERPVO.REVISION = sqlDataReader.GetInt32(3);
			}
		}
		return versaoERPVO;
	}

	private static void ObterVersaoERPMinima()
	{
		string appConfig = ConfigHelper.getAppConfig("VersaoMinimaERP");
		List<string> list = appConfig.Split('.').ToList();
		_versaoERPMinima = new VersaoERPVO();
		_versaoERPMinima.MAJOR = list[0].ToInt();
		_versaoERPMinima.MINOR = list[1].ToInt();
		_versaoERPMinima.BUILD = list[2].ToInt();
		_versaoERPMinima.REVISION = list[3].ToInt();
	}

	public static bool VersaoAtualMaiorMinima()
	{
		string versaoatual = $"{VERSAO_ERP_ATUAL.MAJOR:0000}" + $"{VERSAO_ERP_ATUAL.MINOR:0000}" + $"{VERSAO_ERP_ATUAL.BUILD:0000}" + $"{VERSAO_ERP_ATUAL.REVISION:0000}";
		string versaominima = $"{VERSAO_MINIMA.MAJOR:0000}" + $"{VERSAO_MINIMA.MINOR:0000}" + $"{VERSAO_MINIMA.BUILD:0000}" + $"{VERSAO_MINIMA.REVISION:0000}";
		return ComparaVersao(versaoatual, versaominima);
	}

	public static bool ReleaseAtualMaiorMinima()
	{
		string versaoatual = $"{VERSAO_ERP_ATUAL.MAJOR:0000}" + $"{VERSAO_ERP_ATUAL.MINOR:0000}";
		string versaominima = $"{VERSAO_MINIMA.MAJOR:0000}" + $"{VERSAO_MINIMA.MINOR:0000}";
		return ComparaVersao(versaoatual, versaominima);
	}

	private static bool ComparaVersao(string versaoatual, string versaominima)
	{
		if (Convert.ToInt64(versaoatual) == Convert.ToInt64(versaominima) || Convert.ToInt64(versaoatual) > Convert.ToInt64(versaominima))
		{
			return true;
		}
		return false;
	}
}
