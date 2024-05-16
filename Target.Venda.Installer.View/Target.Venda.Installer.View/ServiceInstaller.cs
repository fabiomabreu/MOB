using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;
using Target.Venda.Installer.View.Common;

namespace Target.Venda.Installer.View;

[RunInstaller(true)]
public class ServiceInstaller : System.Configuration.Install.Installer
{
	public class WindowWrapper : IWin32Window
	{
		private IntPtr _hwnd;

		public IntPtr Handle => _hwnd;

		public WindowWrapper(IntPtr handle)
		{
			_hwnd = handle;
		}
	}

	private IContainer components = null;

	public ServiceInstaller()
	{
		InitializeComponent();
	}

	[SecurityPermission(SecurityAction.Demand)]
	public override void Install(IDictionary stateSaver)
	{
		base.Install(stateSaver);
		string text = "";
		if (base.Context.Parameters.ContainsKey("Par1"))
		{
			text = base.Context.Parameters["Par1"];
			if (!string.IsNullOrEmpty(text) && text.ToUpper() == "IA")
			{
				InstalacaoSilenciosa.Instalar();
				return;
			}
		}
		frmServiceInstaller frmServiceInstaller2 = new frmServiceInstaller();
		Process process = Process.GetProcessesByName("msiexec").FirstOrDefault((Process proc) => !string.IsNullOrEmpty(proc.MainWindowTitle));
		if (process != null)
		{
			frmServiceInstaller2.ShowDialog(new WindowWrapper(process.MainWindowHandle));
		}
		else
		{
			frmServiceInstaller2.ShowDialog();
		}
		DialogResult dialogResult = frmServiceInstaller2.DialogResult;
		frmServiceInstaller2 = null;
	}

	[SecurityPermission(SecurityAction.Demand)]
	public override void Commit(IDictionary savedState)
	{
		base.Commit(savedState);
	}

	[SecurityPermission(SecurityAction.Demand)]
	public override void Rollback(IDictionary savedState)
	{
		base.Rollback(savedState);
	}

	[SecurityPermission(SecurityAction.Demand)]
	protected override void OnAfterUninstall(IDictionary savedState)
	{
		base.OnAfterUninstall(savedState);
	}

	[SecurityPermission(SecurityAction.Demand)]
	public override void Uninstall(IDictionary savedState)
	{
		base.Uninstall(savedState);
		CommonInstaller.DesinstalarAplicacao();
	}

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
	}
}
