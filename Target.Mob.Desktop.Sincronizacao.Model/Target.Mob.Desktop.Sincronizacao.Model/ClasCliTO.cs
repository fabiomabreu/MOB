using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ClasCliTO
{
	private int _CdEmp;

	private int _CdClien;

	private string _CdClasse;

	private string _Classe;

	public int CdEmp
	{
		get
		{
			return _CdEmp;
		}
		set
		{
			_CdEmp = value;
		}
	}

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

	public string CdClasse
	{
		get
		{
			return _CdClasse;
		}
		set
		{
			_CdClasse = value;
		}
	}

	public ClasseCliente Classe
	{
		get
		{
			return _Classe switch
			{
				"A" => ClasseCliente.ClasseA, 
				"B" => ClasseCliente.ClasseB, 
				"C" => ClasseCliente.ClasseC, 
				"N" => ClasseCliente.ClasseN, 
				_ => ClasseCliente.ClasseN, 
			};
		}
		set
		{
			switch (value)
			{
			case ClasseCliente.ClasseA:
				_Classe = "A";
				break;
			case ClasseCliente.ClasseB:
				_Classe = "B";
				break;
			case ClasseCliente.ClasseC:
				_Classe = "C";
				break;
			case ClasseCliente.ClasseN:
				_Classe = "N";
				break;
			default:
				_Classe = "N";
				break;
			}
		}
	}

	public string RetornaClasse()
	{
		return _Classe;
	}

	public ClasCliTO()
	{
	}

	public ClasCliTO(int CdEmp, string CdClasse, ClasseCliente Classe)
	{
		this.CdEmp = CdEmp;
		this.CdClasse = CdClasse;
		this.Classe = Classe;
	}
}
