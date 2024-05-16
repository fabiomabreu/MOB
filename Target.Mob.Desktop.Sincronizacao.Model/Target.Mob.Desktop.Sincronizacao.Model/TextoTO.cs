using System.Collections.Generic;
using System.Linq;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TextoTO
{
	private int _CdTexto;

	private LinTxtTO[] _oLinTxt;

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

	public LinTxtTO[] oLinTxt
	{
		get
		{
			return _oLinTxt;
		}
		set
		{
			_oLinTxt = value;
		}
	}

	public void GeraTexto(string texto)
	{
		int i = 0;
		int num = 1;
		int num2;
		for (texto = texto.Replace("\n", "\r\n"); i < texto.Length; i += num2)
		{
			num2 = ((texto.Length - i < 60) ? (texto.Length - i) : 60);
			LinTxtTO linTxtTO = new LinTxtTO();
			linTxtTO.NumLin = num;
			linTxtTO.Texto = texto.Substring(i, num2);
			IncluiLinTxt(linTxtTO);
			num++;
		}
	}

	internal void IncluiLinTxt(LinTxtTO LinTxt)
	{
		List<LinTxtTO> list = ((oLinTxt != null) ? oLinTxt.ToList() : new List<LinTxtTO>());
		list.Add(LinTxt);
		oLinTxt = list.ToArray();
	}
}
