namespace Target.Mob.Desktop.Sincronizacao.Model;

public class LinTxtTO
{
	private int _CdTexto;

	private int _NumLin;

	private string _Texto;

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

	public int NumLin
	{
		get
		{
			return _NumLin;
		}
		set
		{
			_NumLin = value;
		}
	}

	public string Texto
	{
		get
		{
			return _Texto;
		}
		set
		{
			_Texto = value;
		}
	}
}
