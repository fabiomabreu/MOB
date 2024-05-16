using Target.Venda.IBusiness.Base;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloSistemaBLL : IModuloBaseBLL
{
	void CriarSessaoUsuario(string codigoUsuario, int codigoEmpresa, string nomePrograma);

	void EncerrarSessaoUsuario();

	void ConfigurarStringConexao(string connectionString);
}
