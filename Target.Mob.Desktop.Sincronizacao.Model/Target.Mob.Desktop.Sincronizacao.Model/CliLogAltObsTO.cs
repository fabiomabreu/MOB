using System;
using System.Collections.Generic;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CliLogAltObsTO
{
	private int _CdClien;

	private int _CdTexto;

	private string _TipoObs;

	private LinTxtLogTO[] _oLinTxtLog;

	public int CdClien
	{
		get
		{
			return _CdClien;
		}
		set
		{
			_CdClien = value;
		}
	}

	public int CdTexto
	{
		get
		{
			return _CdTexto;
		}
		set
		{
			_CdTexto = value;
		}
	}

	public TipoObsCliLog TipoObs
	{
		get
		{
			return _TipoObs switch
			{
				"EQUIFAX" => TipoObsCliLog.Equifax, 
				"EXPEDICAO" => TipoObsCliLog.Expedicao, 
				"NF" => TipoObsCliLog.NF, 
				"CREDITO" => TipoObsCliLog.Credito, 
				"ALERTA" => TipoObsCliLog.Alerta, 
				"GERAL" => TipoObsCliLog.Geral, 
				_ => TipoObsCliLog.Geral, 
			};
		}
		set
		{
			switch (value)
			{
			case TipoObsCliLog.Equifax:
				_TipoObs = "EQUIFAX";
				break;
			case TipoObsCliLog.Expedicao:
				_TipoObs = "EXPEDICAO";
				break;
			case TipoObsCliLog.NF:
				_TipoObs = "NF";
				break;
			case TipoObsCliLog.Credito:
				_TipoObs = "CREDITO";
				break;
			case TipoObsCliLog.Alerta:
				_TipoObs = "ALERTA";
				break;
			case TipoObsCliLog.Geral:
				_TipoObs = "GERAL";
				break;
			default:
				_TipoObs = "GERAL";
				break;
			}
		}
	}

	public LinTxtLogTO[] oLinTxtLog
	{
		get
		{
			return _oLinTxtLog;
		}
		set
		{
			_oLinTxtLog = value;
		}
	}

	public string RetornaTipoObs()
	{
		return _TipoObs;
	}

	public void GeraTextoLog(string texto, int cdTextoOrig, string cdUsrImport, DateTime dataImport)
	{
		int i = 0;
		int num = 1;
		int num2;
		for (; i < texto.Length; i += num2)
		{
			num2 = ((texto.Length - i < 60) ? (texto.Length - i) : 60);
			LinTxtLogTO linTxtLogTO = new LinTxtLogTO();
			linTxtLogTO.NumLin = num;
			linTxtLogTO.Texto = texto.Substring(i, num2);
			linTxtLogTO.CdUsuario = cdUsrImport;
			linTxtLogTO.Data = dataImport;
			IncluiLinTxtLog(linTxtLogTO);
			num++;
		}
	}

	internal void IncluiLinTxtLog(LinTxtLogTO LinTxtLog)
	{
		List<LinTxtLogTO> list = ((oLinTxtLog != null) ? oLinTxtLog.ToList() : new List<LinTxtLogTO>());
		list.Add(LinTxtLog);
		oLinTxtLog = list.ToArray();
	}
}
