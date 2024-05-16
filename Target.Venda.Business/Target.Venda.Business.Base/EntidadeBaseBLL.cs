using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Base;
using Target.Venda.Model.Enum;

namespace Target.Venda.Business.Base;

public abstract class EntidadeBaseBLL<T> : IEntidadeBaseBLL<T> where T : EntidadeBaseMO, new()
{
	protected EntidadeBaseDAL<T> BaseDAL;

	public EntidadeBaseBLL()
	{
		BaseDAL = GetInstanceDAL();
	}

	protected abstract EntidadeBaseDAL<T> GetInstanceDAL();

	public virtual void Salvar(T objeto)
	{
		try
		{
			if (objeto == null)
			{
				throw new Exception("Objeto está em branco: " + typeof(T).Name);
			}
			if (objeto.STATUS_ENTIDADE == StatusModelEnum.ADICIONADO)
			{
				Inserir(objeto);
			}
			else if (objeto.STATUS_ENTIDADE == StatusModelEnum.EDITADO)
			{
				Update(objeto);
			}
			else if (objeto.STATUS_ENTIDADE == StatusModelEnum.DELETADO)
			{
				Delete(objeto);
			}
			objeto.STATUS_ENTIDADE = StatusModelEnum.LEITURA;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	protected virtual void Delete(T objeto)
	{
		BaseDAL.Delete(objeto);
	}

	protected virtual void Update(T objeto)
	{
		BaseDAL.Update(objeto);
	}

	protected virtual void Inserir(T objeto)
	{
		BaseDAL.Insert(objeto);
	}

	public virtual List<T> ObterPeloExemplo(T exampleInstance)
	{
		try
		{
			return BaseDAL.ObterPeloExemplo(exampleInstance);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public virtual List<T> ObterPeloExemplo(T exampleInstance, params string[] INCLUDES)
	{
		try
		{
			return BaseDAL.ObterPeloExemplo(exampleInstance, INCLUDES);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public virtual T ObterUnicoPeloExemplo(T exampleInstance)
	{
		try
		{
			return ObterUnicoPeloExemploInternal(exampleInstance);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public virtual T ObterUnicoPeloExemplo(T exampleInstance, params string[] INCLUDES)
	{
		try
		{
			return ObterUnicoPeloExemploInternal(exampleInstance, INCLUDES);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private T ObterUnicoPeloExemploInternal(T exampleInstance, params string[] INCLUDES)
	{
		try
		{
			return BaseDAL.ObterUnicoPeloExemplo(exampleInstance, INCLUDES);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private string ObterMensagemErroRegistroNaoEncontradoPeloExemplo(T exampleInstance)
	{
		string arg = ObterNomeAmigavelPelaClasse();
		StringBuilder stringBuilder = null;
		PropertyInfo[] properties = exampleInstance.GetType().GetProperties();
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			object value = propertyInfo.GetValue(exampleInstance, null);
			object obj = null;
			if (propertyInfo.PropertyType.IsValueType)
			{
				obj = Activator.CreateInstance(propertyInfo.PropertyType);
			}
			bool flag = propertyInfo.PropertyType != typeof(StatusModelEnum);
			bool flag2 = value != null;
			bool flag3 = value != obj;
			if (flag2 && flag3 && flag)
			{
				if (stringBuilder != null)
				{
					stringBuilder.AppendFormat(", {0}: {1}", propertyInfo.Name, value);
					continue;
				}
				stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("{0}: {1}", propertyInfo.Name, value);
			}
		}
		return $"Não encontrado registro da entidade {arg} pelo(s) filtro(s): {stringBuilder.ToString()}";
	}

	public virtual T ObterPeloID(params object[] ids)
	{
		try
		{
			return BaseDAL.ObterPeloID(ids);
		}
		catch (MyException ex)
		{
			throw ex;
		}
		catch (Exception ex2)
		{
			LogHelper.ErroLog(ex2);
			throw ex2;
		}
	}

	private string ObterMensagemErroRegistroNaoEncontradoPeloID(params object[] ids)
	{
		string arg = ObterNomeAmigavelPelaClasse();
		StringBuilder chaveTabela = null;
		ids.ToList().ForEach(delegate(object x)
		{
			if (chaveTabela != null)
			{
				chaveTabela.AppendFormat(", {0}", x);
			}
			else
			{
				chaveTabela = new StringBuilder();
				chaveTabela.AppendFormat("{0}", x);
			}
		});
		return $"Não encontrado registro da entidade {arg} pelo Id: {chaveTabela.ToString()}";
	}

	private static string ObterNomeAmigavelPelaClasse()
	{
		string name = typeof(T).Name;
		return name.Substring(0, name.Length - 2);
	}

	public virtual int GerarSequencial(string nomeTabelaSeq, int? codigoEmpresa = null)
	{
		try
		{
			return BaseDAL.GerarSequencial(nomeTabelaSeq, codigoEmpresa);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
