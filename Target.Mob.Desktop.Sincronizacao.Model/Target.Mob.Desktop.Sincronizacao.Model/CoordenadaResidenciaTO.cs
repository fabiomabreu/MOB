namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CoordenadaResidenciaTO
{
	public int? IdCoordenadaResidencia { get; set; }

	public int? IdUsuario { get; set; }

	public string TipoUsuario { get; set; }

	public double? Latitude { get; set; }

	public double? Longitude { get; set; }

	public string UsuarioLogado { get; set; }
}
