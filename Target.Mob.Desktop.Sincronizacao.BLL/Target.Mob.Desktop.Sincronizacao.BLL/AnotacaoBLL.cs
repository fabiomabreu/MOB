using System;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class AnotacaoBLL
{
	public static void Merge(DbConnection connTargetErp, AnotacaoTO anotat)
	{
		if (!anotat.CodigoAnotacao.HasValue)
		{
			AnotacaoDAL.Insert(connTargetErp, anotat);
			return;
		}
		AnotacaoTO anotacaoTO = new AnotacaoTO();
		anotacaoTO.CodigoAnotacao = anotat.CodigoAnotacao;
		AnotacaoTO[] array = AnotacaoDAL.Select(connTargetErp, anotacaoTO);
		if (array != null && array.Count() == 1)
		{
			AnotacaoDAL.Update(connTargetErp, anotat);
			return;
		}
		throw new Exception("ANOTACAO não encontrada " + anotat.CodigoAnotacao);
	}
}
