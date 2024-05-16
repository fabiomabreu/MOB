using System;
using System.Linq.Expressions;
using System.Text;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Dao;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class SessaoDbTempDAL : EntidadeBaseDAL<SessaoDbTempMO>
{
	public void CriarTabelaTemporaria(string nomeTabelaTemporaria)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("CREATE TABLE {0} ", nomeTabelaTemporaria);
			stringBuilder.Append("(cd_usuario char(8) NOT NULL, ");
			stringBuilder.Append(" dt_criacao datetime NOT NULL) ");
			DbTempHelper.ExecuteNonQuery(stringBuilder.ToString(), nomeTabelaTemporaria);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void InserirDados(string nomeTabelaTemporaria, string codigoUsuario, DateTime dataCriacao)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("INSERT INTO {0} (cd_usuario, dt_criacao) ", nomeTabelaTemporaria);
			stringBuilder.Append("values({0}, {1})");
			ExecutarSqlCommand(stringBuilder.ToString(), codigoUsuario, dataCriacao);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public bool VerificarExisteTabelaSessao(string tabelaTemporaria)
	{
		string select = $"SELECT cast(isnull(max(1),0) as bit)\r\n                                    FROM tempdb.sys.tables a\r\n                                    where a.name = '{tabelaTemporaria}'";
		return ExecutarScalarSQL<bool>(select, Array.Empty<object>());
	}

	protected override Expression<Func<SessaoDbTempMO, bool>> GetWhere(Expression<Func<SessaoDbTempMO, bool>> whereClause, SessaoDbTempMO exemplo)
	{
		throw new NotImplementedException();
	}

	public SessaoDbTempMO ObterSessaoPedidoPeloNomeTabelaTemp(string nomeTabelaTemporaria)
	{
		SessaoDbTempMO sessaoDbTempMO = new SessaoDbTempMO();
		string select = $"SELECT cd_usuario as CODIGO_USUARIO,\r\n                                                dt_criacao as DATA_CRIACAO\r\n                                           FROM {nomeTabelaTemporaria} ";
		SessaoDbTempMO sessaoDbTempMO2 = ExecutarScalarSQL<SessaoDbTempMO>(select, Array.Empty<object>());
		sessaoDbTempMO2.NOME_TABELA_TEMPORARIA = nomeTabelaTemporaria;
		return sessaoDbTempMO2;
	}

	public void EncerrarSessaoDbTemp(SessaoDbTempMO sessaoDbTemp)
	{
		string nOME_TABELA_TEMPORARIA = sessaoDbTemp.NOME_TABELA_TEMPORARIA;
		if (VerificarExisteTabelaSessao(nOME_TABELA_TEMPORARIA))
		{
			string comando = $" DROP TABLE tempdb.{nOME_TABELA_TEMPORARIA} ";
			ExecutarSqlCommand(comando);
		}
		DbConnectionManager.DisposeConnection(nOME_TABELA_TEMPORARIA);
	}
}
