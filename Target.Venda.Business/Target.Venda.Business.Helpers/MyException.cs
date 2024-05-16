using System;
using System.Collections.Generic;
using System.Linq;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Base.Delegate;

namespace Target.Venda.Business.Helpers;

[Serializable]
public class MyException : Exception
{
	private List<MenssageException> MENSAGENS;

	public override string Message => ObterMensagem();

	public bool ContemItens => MENSAGENS != null && MENSAGENS.Count > 0;

	public bool ContemErro => MENSAGENS.Exists((MenssageException x) => x.TIPO == TipoExceptionEnum.Erro);

	public bool ContemAviso => MENSAGENS.Exists((MenssageException x) => x.TIPO == TipoExceptionEnum.Aviso);

	public bool ContemInfo => MENSAGENS.Exists((MenssageException x) => x.TIPO == TipoExceptionEnum.Info);

	public List<MenssageException> LISTA_MENSAGENS => ObterListaMensagens();

	private event RetornoMensagensHandler EVENTO_RETORNO_MENSAGEM;

	private void Inicialize()
	{
		if (MENSAGENS == null)
		{
			MENSAGENS = new List<MenssageException>();
		}
	}

	public MyException()
	{
		Inicialize();
	}

	public MyException(string menssage)
	{
		Inicialize();
		AddErro(menssage);
	}

	public MyException(RetornoMensagensHandler evento)
	{
		Inicialize();
		this.EVENTO_RETORNO_MENSAGEM = evento;
	}

	public void Add(string mensagem, TipoExceptionEnum tipo)
	{
		MenssageException ex = new MenssageException();
		ex.MENSAGEM = mensagem;
		ex.TIPO = tipo;
		MENSAGENS.Add(ex);
	}

	public void AddErro(string mensagem, params object[] dados)
	{
		Add(string.Format(mensagem, dados), TipoExceptionEnum.Erro);
	}

	public void AddAviso(string mensagem, params object[] dados)
	{
		Add(string.Format(mensagem, dados), TipoExceptionEnum.Aviso);
	}

	public void AddInfo(string mensagem, params object[] dados)
	{
		Add(string.Format(mensagem, dados), TipoExceptionEnum.Info);
	}

	private string ObterMensagem()
	{
		if (MENSAGENS.Count == 1)
		{
			MenssageException ex = MENSAGENS.First();
			return $"{ex.TIPO.ToString()}: {ex.MENSAGEM}";
		}
		if (MENSAGENS.Count > 1)
		{
			return "Existe mais de uma mensagem de validação. Verifique a lista de mensagens para mais detalhes";
		}
		return "Não existe mensagem de erro";
	}

	private List<MenssageException> ObterListaMensagens()
	{
		return MENSAGENS;
	}

	public void ThrowException()
	{
		if (!ContemItens)
		{
			return;
		}
		List<MenssageException> list = ObterListaMensagens();
		foreach (MenssageException item in list)
		{
			string mENSAGEM = item.MENSAGEM;
			switch (item.TIPO)
			{
			case TipoExceptionEnum.Aviso:
				LogHelper.AvisoLog(mENSAGEM);
				if (this.EVENTO_RETORNO_MENSAGEM != null)
				{
					this.EVENTO_RETORNO_MENSAGEM("Aviso: " + mENSAGEM);
				}
				break;
			case TipoExceptionEnum.Info:
				LogHelper.InfoLog(item.MENSAGEM);
				if (this.EVENTO_RETORNO_MENSAGEM != null)
				{
					this.EVENTO_RETORNO_MENSAGEM(mENSAGEM);
				}
				break;
			}
		}
		if (!ContemErro)
		{
			return;
		}
		throw this;
	}

	public void VerificarObjetoNull(object objetoVerificar, string mensagem = null)
	{
		if (objetoVerificar == null)
		{
			string mensagem2 = $"O objeto está nulo";
			if (!string.IsNullOrEmpty(mensagem))
			{
				AddErro(mensagem);
			}
			else
			{
				AddErro(mensagem2);
			}
			ThrowException();
		}
	}
}
