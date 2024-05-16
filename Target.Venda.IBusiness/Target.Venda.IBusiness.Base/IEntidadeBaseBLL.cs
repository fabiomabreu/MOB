using System.Collections.Generic;
using Target.Venda.Model.Base;

namespace Target.Venda.IBusiness.Base;

public interface IEntidadeBaseBLL<T> where T : EntidadeBaseMO, new()
{
	void Salvar(T objeto);

	List<T> ObterPeloExemplo(T exampleInstance);

	List<T> ObterPeloExemplo(T exampleInstance, params string[] INCLUDES);

	T ObterUnicoPeloExemplo(T exampleInstance);

	T ObterUnicoPeloExemplo(T exampleInstance, params string[] INCLUDES);

	T ObterPeloID(params object[] ids);
}
