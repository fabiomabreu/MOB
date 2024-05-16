using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Model;

namespace Target.Mob.Desktop.Api.BLL;

public static class ImagemClienteBLL
{
	public static void Insert(string stringConnTargetErp, ImagemClienteTO model)
	{
		ImagemClienteDAL.Insert(stringConnTargetErp, model);
	}
}
