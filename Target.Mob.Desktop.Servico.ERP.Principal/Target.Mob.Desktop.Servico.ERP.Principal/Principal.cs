using System.ComponentModel;
using Target.Mob.Desktop.Servico.ERP.Base;

namespace Target.Mob.Desktop.Servico.ERP.Principal;

public class Principal : Target.Mob.Desktop.Servico.ERP.Base.Principal
{
	private IContainer components;

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		components = new Container();
		base.ServiceName = "Principal";
	}
}
