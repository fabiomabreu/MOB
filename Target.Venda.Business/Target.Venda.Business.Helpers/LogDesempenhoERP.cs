using System.Diagnostics;
using System.Runtime.CompilerServices;
using Target.Venda.Business.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Helpers;

public static class LogDesempenhoERP
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int Iniciar(string observacao = null)
	{
		LogDesempenhoBLL logDesempenhoBLL = new LogDesempenhoBLL();
		LogDesempenhoVO logDesempenho = new LogDesempenhoVO
		{
			CODIGO_TELA = "VENDAS (NOVA)",
			OPERACAO = ObterDescricaoOperacao(),
			OBSERVACAO = observacao
		};
		return logDesempenhoBLL.LogDesempenhoInicio(logDesempenho);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string ObterDescricaoOperacao()
	{
		StackTrace stackTrace = new StackTrace();
		StackFrame frame = stackTrace.GetFrame(2);
		string name = frame.GetMethod().DeclaringType.Name;
		string name2 = frame.GetMethod().Name;
		string text = $"{name} - {name2}";
		if (text.Length > 40)
		{
			text = text.Substring(0, 40);
		}
		return text;
	}

	public static void Encerrar(int codigoLogDesempenho)
	{
		LogDesempenhoBLL logDesempenhoBLL = new LogDesempenhoBLL();
		if (codigoLogDesempenho > 0)
		{
			logDesempenhoBLL.LogDesempenhoFim(codigoLogDesempenho);
		}
	}
}
