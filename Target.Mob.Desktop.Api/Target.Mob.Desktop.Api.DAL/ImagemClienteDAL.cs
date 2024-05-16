using System;
using System.Data;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public static class ImagemClienteDAL
{
	private const string INSERT = "uspImagemClienteInsert";

	public static void Insert(string stringConnTargetErp, ImagemClienteTO model)
	{
		try
		{
			using DbConnection dbConnection = new DbConnection(stringConnTargetErp);
			dbConnection.Open();
			foreach (ArquivoImagemClienteTO arquivo in model.Arquivos)
			{
				dbConnection.ClearParameters();
				dbConnection.AddParameters("@CdVend", model.CodigoVendedor);
				dbConnection.AddParameters("@CdClien", model.CodigoCliente);
				dbConnection.AddParameters("@ClienteNovo", model.ClienteBdMovimento);
				dbConnection.AddParameters("@CnpjCpf", model.CnpjCpf);
				dbConnection.AddParameters("@Erro", model.Erro);
				dbConnection.AddParameters("@Imagem", arquivo.Conteudo);
				dbConnection.AddParameters("@NomeArquivo", arquivo.FileName);
				dbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "uspImagemClienteInsert");
			}
			dbConnection.Close();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
