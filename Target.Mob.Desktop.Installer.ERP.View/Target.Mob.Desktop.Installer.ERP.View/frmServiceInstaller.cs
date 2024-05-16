using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Target.Mob.Desktop.Installer.ERP.View.Common;

namespace Target.Mob.Desktop.Installer.ERP.View;

public class frmServiceInstaller : Form
{
	private string msgRestricaoUsuario;

	private IContainer components;

	private TabControl tbcWizard;

	private TabPage tabConfigDbErp;

	private TabPage tabConfigDbMob;

	private TabPage tabAppUpdate;

	private Button btnConfigDbErpNext;

	private Button btnConfigDbMobPrevious;

	private Button btnConfigDbMobNext;

	private Button btnAppUpdateNext;

	private TextBox txtConfigDbErpDbName;

	private TextBox txtConfigDbErpPassword;

	private TextBox txtConfigDbErpUserName;

	private TextBox txtConfigDbErpSource;

	private Label lblConfigDbErpDbName;

	private Label lblConfigDbErpPassword;

	private Label lblConfigDbErpUserName;

	private RadioButton radConfigDbErpSqlServerAuthentication;

	private RadioButton radConfigDbErpWindowsAuthentication;

	private Label lblConfigDbErpAuthentication;

	private Label lblConfigDbErpSource;

	private TextBox txtConfigDbMobDbName;

	private TextBox txtConfigDbMobPassword;

	private TextBox txtConfigDbMobUserName;

	private TextBox txtConfigDbMobDataSource;

	private Label lblConfigDbMobDbName;

	private Label lblConfigDbMobPassword;

	private Label lblConfigDbMobUserName;

	private RadioButton radConfigDbMobSqlServerAuthentication;

	private RadioButton radConfigDbMobWindowsAuthentication;

	private Label lblConfigDbMobAuthentication;

	private Label lblConfigDbMobDataSource;

	private Button btnAppUpdateRun;

	private Panel pnlTargetErpTop;

	private Label lblConfigDbErpSubtitle;

	private Label lblConfigDbErpTitle;

	private PictureBox pbxConfigDbErpImage;

	private Panel pnlTargetMobTop;

	private Label lblConfigDbMobSubtitle;

	private Label lblConfigDbMobTitle;

	private PictureBox pbxConfigDbMobImage;

	private Panel pnlTargetScriptExecuteTop;

	private Label lblAppUpdateSubtitle;

	private Label lblAppUpdateTitle;

	private PictureBox pbxAppUpdateImage;

	private ListBox lstAppUpdateOutput;

	private TextBox txtConfigDbErpOdbcName;

	private Label lblConfigDbErpOdbcName;

	private TabPage tabFinish;

	private Panel pnlEndTop;

	private Label lblFinishSubtitle;

	private Label lblFinishTitle;

	private PictureBox pbxFinishImage;

	private Button btnFinishDone;

	private Label lblFinishSuccess;

	private TabPage tabServiceInstall;

	private Button btnServiceInstallNext;

	private Panel panel2;

	private Label lblServiceInstallSubtitle;

	private Label lblServiceInstallTitle;

	private PictureBox pbxServiceInstallImage;

	private Button btnAppUpdatePrevious;

	private TextBox NomeLinkedServer;

	private CheckBox usarLinkedServer;

	private RadioButton radConfigUtilizarUsuarioSenha;

	private RadioButton radConfigUtilizaLocalSystem;

	private TextBox txtServiceInstallPassword;

	private TextBox txtServiceInstallUserName;

	private Label lblServiceInstallPassword;

	private Label lblServiceInstallUserName;

	private CheckBox ckbServiceInstallAutoStart;

	private Button btnVoltarUsuario;

	private CheckBox checkBoxCloud;

	public frmServiceInstaller()
	{
		InitializeComponent();
		InitializeComponentCustom();
	}

	private void InitializeComponentCustom()
	{
		try
		{
			tbcWizard.Left = -3;
			tbcWizard.Width = base.Width + 3;
			tbcWizard.Alignment = TabAlignment.Bottom;
			tbcWizard.Height = base.Height;
			base.Height -= 25;
			CommonInstaller.Load();
			CommonInstaller.MENSAGENS += WriteOutput;
			PreencherCamposAbaERP();
			PreencherCamposAbaMob();
			PreencherCamposAbaUsuario();
			BringToFront();
			Update();
		}
		catch (Exception)
		{
			CommonInstaller.ExibirMensagem("Problema ao Carregar as configurações", "Atenção", MessageBoxIcon.Hand);
		}
	}

	private void frmServiceInstaller_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (tbcWizard.SelectedTab != tabFinish && MessageBox.Show("Deseja mesmo fechar o instalador? Isso poderá causar problemas na instalação atual!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
		{
			e.Cancel = true;
		}
	}

	private void PreencherCamposAbaERP()
	{
		radConfigDbErpSqlServerAuthentication.Checked = true;
		txtConfigDbErpUserName.Enabled = true;
		txtConfigDbErpPassword.Enabled = true;
		SqlConnectionStringBuilder sqlConnectionStringBuilder = CommonInstaller.CONEXOES["ConexaoTargetErp"];
		txtConfigDbErpSource.Text = sqlConnectionStringBuilder.DataSource;
		txtConfigDbErpUserName.Text = sqlConnectionStringBuilder.UserID;
		txtConfigDbErpDbName.Text = sqlConnectionStringBuilder.InitialCatalog;
		txtConfigDbErpPassword.Text = sqlConnectionStringBuilder.Password;
		txtConfigDbErpOdbcName.Text = CommonInstaller.CONFIGURACOES_SERVICO["LiberaAutoConnOdbc"];
		if (!string.IsNullOrEmpty(sqlConnectionStringBuilder.UserID))
		{
			radConfigDbErpSqlServerAuthentication.Checked = true;
		}
		else
		{
			radConfigDbErpWindowsAuthentication.Checked = true;
		}
	}

	private void btnConfigDbErpNext_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		btnConfigDbErpNext.Enabled = false;
		bool flag = CommonInstaller.ValidarAlterarStringConexao("ConexaoTargetErp", txtConfigDbErpSource.Text, txtConfigDbErpDbName.Text, txtConfigDbErpUserName.Text, txtConfigDbErpPassword.Text, radConfigDbErpWindowsAuthentication.Checked, bancoERP: true);
		if (!flag)
		{
			CommonInstaller.ExibirMensagem("Não foi possível estabelecer uma conexão! Verifique os dados fornecidos e a conectividade da rede.", "Erro de Conexão", MessageBoxIcon.Asterisk);
			btnConfigDbErpNext.Enabled = true;
			Cursor = Cursors.Default;
			return;
		}
		if (flag && !ValidarVersaoERP())
		{
			string text = "Versão ERP Minima Absoluta: " + CommonInstaller.CONFIGURACOES_SERVICO["VersaoERPMinimaAbsoluta"] + ".\n\n";
			if (msgRestricaoUsuario == null)
			{
				GeraMsgRestricaoUsuario();
			}
			CommonInstaller.ExibirMensagem("Versão do ERP incompatível com esta retaguarda.\nSolicite suporte técnico.\n\n " + text + msgRestricaoUsuario, "Versão ERP", MessageBoxIcon.Hand);
			flag = false;
		}
		string stringConnection = Util.BuildOdbcConnection(txtConfigDbErpOdbcName.Text, Util.GetDefaultPassword(CommonInstaller.CONEXOES["ConexaoTargetErp"].ToString()));
		if (flag && !Util.OdbcConnectionTest(stringConnection))
		{
			MessageBox.Show("Não foi possível estabelecer uma conexão com a entrada ODBC! Verifique os dados fornecidos e a conectividade da rede.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			flag = false;
		}
		if (flag && !Util.OdbcConnectionValidate(stringConnection, txtConfigDbErpDbName.Text))
		{
			MessageBox.Show("O nome do banco de dados informado não corresponde ao banco de dados configurado na entrada Odbc.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			flag = false;
		}
		if (flag)
		{
			Util.TabShow(tbcWizard, tabConfigDbMob);
			CommonInstaller.CONFIGURACOES_SERVICO["LiberaAutoConnOdbc"] = txtConfigDbErpOdbcName.Text;
		}
		btnConfigDbErpNext.Enabled = true;
		Cursor = Cursors.Default;
	}

	private void radConfigDbErpWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
	{
		txtConfigDbErpUserName.Text = string.Empty;
		txtConfigDbErpPassword.Text = string.Empty;
		txtConfigDbErpUserName.Enabled = false;
		txtConfigDbErpPassword.Enabled = false;
	}

	private void radConfigDbErpSqlServerAuthentication_CheckedChanged(object sender, EventArgs e)
	{
		txtConfigDbErpUserName.Enabled = true;
		txtConfigDbErpPassword.Enabled = true;
	}

	private void PreencherCamposAbaMob()
	{
		radConfigDbMobSqlServerAuthentication.Checked = true;
		txtConfigDbMobUserName.Enabled = true;
		txtConfigDbMobPassword.Enabled = true;
		SqlConnectionStringBuilder sqlConnectionStringBuilder = CommonInstaller.CONEXOES["ConexaoTargetMob"];
		txtConfigDbMobDataSource.Text = sqlConnectionStringBuilder.DataSource;
		txtConfigDbMobUserName.Text = sqlConnectionStringBuilder.UserID;
		txtConfigDbMobDbName.Text = sqlConnectionStringBuilder.InitialCatalog;
		txtConfigDbMobPassword.Text = sqlConnectionStringBuilder.Password;
		if (!string.IsNullOrEmpty(sqlConnectionStringBuilder.UserID))
		{
			radConfigDbErpSqlServerAuthentication.Checked = true;
		}
		else
		{
			radConfigDbErpWindowsAuthentication.Checked = true;
		}
		NomeLinkedServer.Text = CommonInstaller.CONFIGURACOES_SERVICO["NomeServidorOrigemReplicacao"];
		if (!string.IsNullOrEmpty(NomeLinkedServer.Text))
		{
			usarLinkedServer.Checked = true;
			usarLinkedServer_CheckedChanged(null, null);
		}
	}

	private void btnConfigDbMobPrevious_Click(object sender, EventArgs e)
	{
		Util.TabShow(tbcWizard, tabConfigDbErp);
	}

	private void btnConfigDbMobNext_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		btnConfigDbMobNext.Enabled = false;
		btnConfigDbMobPrevious.Enabled = false;
		bool flag = CommonInstaller.ValidarAlterarStringConexao("ConexaoTargetMob", txtConfigDbMobDataSource.Text, txtConfigDbMobDbName.Text, txtConfigDbMobUserName.Text, txtConfigDbMobPassword.Text, radConfigDbMobWindowsAuthentication.Checked, bancoERP: false);
		if (!flag)
		{
			CommonInstaller.ExibirMensagem("O Banco de dados informado não existe e será criado automaticamente durante o processo de instalação.", "Atenção", MessageBoxIcon.Asterisk);
			flag = true;
		}
		string stringConnection = Util.BuildStringConnection(txtConfigDbMobDataSource.Text, "master", txtConfigDbMobUserName.Text, txtConfigDbMobPassword.Text, CommonInstaller.CONEXOES["ConexaoTargetMob"].MaxPoolSize, radConfigDbMobWindowsAuthentication.Checked, CommonInstaller.CONEXOES["ConexaoTargetMob"].ApplicationName);
		if (usarLinkedServer.Checked && !Util.LinkedServerExists(stringConnection, NomeLinkedServer.Text))
		{
			CommonInstaller.ExibirMensagem("Não foi possível estabelecer uma conexão Linked Server! Verifique os dados fornecidos e a conectividade da rede.", "Erro de Conexão Linked Server", MessageBoxIcon.Hand);
			flag = false;
		}
		if (flag)
		{
			Util.TabShow(tbcWizard, tabServiceInstall);
		}
		string value = ((!string.IsNullOrEmpty(NomeLinkedServer.Text)) ? ("[" + NomeLinkedServer.Text.Replace("[", "").Replace("]", "") + "]") : string.Empty);
		CommonInstaller.CONFIGURACOES_SERVICO["NomeServidorOrigemReplicacao"] = value;
		btnConfigDbMobPrevious.Enabled = true;
		btnConfigDbMobNext.Enabled = true;
		Cursor = Cursors.Default;
	}

	private void usarLinkedServer_CheckedChanged(object sender, EventArgs e)
	{
		NomeLinkedServer.Enabled = usarLinkedServer.Checked;
		if (NomeLinkedServer.Enabled && string.IsNullOrEmpty(NomeLinkedServer.Text))
		{
			NomeLinkedServer.Text = txtConfigDbErpSource.Text;
		}
		else
		{
			NomeLinkedServer.Text = string.Empty;
		}
	}

	private void radConfigDbMobWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
	{
		txtConfigDbMobUserName.Text = string.Empty;
		txtConfigDbMobPassword.Text = string.Empty;
		txtConfigDbMobUserName.Enabled = false;
		txtConfigDbMobPassword.Enabled = false;
	}

	private void radConfigDbMobSqlServerAuthentication_CheckedChanged(object sender, EventArgs e)
	{
		txtConfigDbMobUserName.Enabled = true;
		txtConfigDbMobPassword.Enabled = true;
	}

	private void PreencherCamposAbaUsuario()
	{
		radConfigUtilizaLocalSystem.Checked = true;
		txtServiceInstallUserName.Enabled = false;
		txtServiceInstallPassword.Enabled = false;
		if (CommonInstaller.CONFIGURACOES_SERVICO.ContainsKey("UsuarioServico") && !string.IsNullOrEmpty(CommonInstaller.CONFIGURACOES_SERVICO["UsuarioServico"]))
		{
			radConfigUtilizarUsuarioSenha.Checked = true;
			txtServiceInstallUserName.Enabled = true;
			txtServiceInstallPassword.Enabled = true;
			txtServiceInstallUserName.Text = CommonInstaller.CONFIGURACOES_SERVICO["UsuarioServico"];
			txtServiceInstallPassword.Text = CommonInstaller.CONFIGURACOES_SERVICO["PassServico"];
		}
	}

	private void btnAvancarUsuarioServico_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		if ((!string.IsNullOrEmpty(txtServiceInstallUserName.Text) || !string.IsNullOrEmpty(txtServiceInstallPassword.Text)) && MessageBox.Show("Por padrão, os campos de usuário e senha dos serviços devem ficar em branco. Deseja limpar campos ?", "Serviço", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
		{
			txtServiceInstallUserName.Text = "";
			txtServiceInstallPassword.Text = "";
		}
		Cursor = Cursors.WaitCursor;
		CommonInstaller.CONFIGURACOES_SERVICO["UsuarioServico"] = "";
		CommonInstaller.CONFIGURACOES_SERVICO["PassServico"] = "";
		if (!string.IsNullOrEmpty(txtServiceInstallUserName.Text) || !string.IsNullOrEmpty(txtServiceInstallPassword.Text))
		{
			CommonInstaller.CONFIGURACOES_SERVICO["UsuarioServico"] = txtServiceInstallUserName.Text;
			CommonInstaller.CONFIGURACOES_SERVICO["PassServico"] = txtServiceInstallPassword.Text;
		}
		Util.TabShow(tbcWizard, tabAppUpdate);
		btnAppUpdateRun_Click(null, null);
		Cursor = Cursors.Default;
	}

	private void btnVoltarUsuario_Click(object sender, EventArgs e)
	{
		Util.TabShow(tbcWizard, tabConfigDbMob);
	}

	private void radConfigUtilizarUsuarioSenha_CheckedChanged(object sender, EventArgs e)
	{
		txtServiceInstallUserName.Enabled = true;
		txtServiceInstallPassword.Enabled = true;
	}

	private void radConfigUtilizaLocalSystem_CheckedChanged(object sender, EventArgs e)
	{
		txtServiceInstallUserName.Enabled = false;
		txtServiceInstallPassword.Enabled = false;
		txtServiceInstallUserName.Clear();
		txtServiceInstallPassword.Clear();
	}

	private void btnAppUpdateRun_Click(object sender, EventArgs e)
	{
		new Thread(Install).Start();
	}

	private void WriteOutput(string message)
	{
		lstAppUpdateOutput.Invoke((MethodInvoker)delegate
		{
			lstAppUpdateOutput.Items.Add(message);
		});
		lstAppUpdateOutput.Invoke((MethodInvoker)delegate
		{
			lstAppUpdateOutput.SelectedIndex = lstAppUpdateOutput.Items.Count - 1;
		});
		lstAppUpdateOutput.Invoke((MethodInvoker)delegate
		{
			lstAppUpdateOutput.SelectedIndex = -1;
		});
	}

	private void Install()
	{
		try
		{
			Invoke((MethodInvoker)delegate
			{
				Cursor = Cursors.WaitCursor;
			});
			btnAppUpdateRun.Invoke((MethodInvoker)delegate
			{
				btnAppUpdateRun.Enabled = false;
			});
			btnAppUpdatePrevious.Invoke((MethodInvoker)delegate
			{
				btnAppUpdatePrevious.Enabled = false;
			});
			btnAppUpdateNext.Invoke((MethodInvoker)delegate
			{
				btnAppUpdateNext.Enabled = false;
			});
			lstAppUpdateOutput.Invoke((MethodInvoker)delegate
			{
				lstAppUpdateOutput.Items.Clear();
			});
			CommonInstaller.Install(checkBoxCloud.Checked);
			Invoke((MethodInvoker)delegate
			{
				Cursor = Cursors.Default;
			});
			btnAppUpdateNext.Invoke((MethodInvoker)delegate
			{
				btnAppUpdateNext.Enabled = true;
			});
		}
		catch (Exception ex)
		{
			CommonInstaller.ExibirMensagem(ex.Message, "Erro na Atualização", MessageBoxIcon.Hand);
			Invoke((MethodInvoker)delegate
			{
				Cursor = Cursors.Default;
			});
			btnAppUpdateRun.Invoke((MethodInvoker)delegate
			{
				btnAppUpdateRun.Enabled = true;
			});
			btnAppUpdatePrevious.Invoke((MethodInvoker)delegate
			{
				btnAppUpdatePrevious.Enabled = true;
			});
		}
	}

	private void btnAppUpdatePrevious_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		btnAppUpdateRun.Enabled = false;
		btnAppUpdatePrevious.Enabled = false;
		Util.TabShow(tbcWizard, tabServiceInstall);
		btnAppUpdatePrevious.Enabled = true;
		btnAppUpdateRun.Enabled = true;
		lstAppUpdateOutput.Items.Clear();
		Cursor = Cursors.Default;
	}

	private void btnAppUpdateNext_Click(object sender, EventArgs e)
	{
		btnAppUpdateNext.Enabled = false;
		Util.TabShow(tbcWizard, tabFinish);
	}

	private void btnFinishDone_Click(object sender, EventArgs e)
	{
		try
		{
			if (ckbServiceInstallAutoStart.Checked)
			{
				CommonInstaller.IniciarServicos();
			}
		}
		catch (Exception)
		{
			btnFinishDone.Enabled = true;
			CommonInstaller.ExibirMensagem("Não foi possível iniciar os serviços.", "Erro ao iniciar serviços", MessageBoxIcon.Asterisk);
		}
		Cursor = Cursors.Default;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void GeraMsgRestricaoUsuario()
	{
		string[] array = CommonInstaller.CONFIGURACOES_SERVICO["ValidaVersaoERP"].Split('|');
		foreach (string text in array)
		{
			string[] array2 = text.Split(';');
			_ = array2[0];
			_ = array2[1];
			_ = array2[2];
			msgRestricaoUsuario += ((msgRestricaoUsuario == null) ? ("- " + text.Replace(';', '.')) : ("\n- " + text.Replace(';', '.')));
		}
		if (msgRestricaoUsuario != null)
		{
			msgRestricaoUsuario = "Restrições Release/Patch:\n " + msgRestricaoUsuario;
		}
	}

	private bool ValidarVersaoERP()
	{
		string text = "0";
		string text2 = "0";
		string text3 = "0";
		string text4 = "0";
		string text5 = "0";
		bool result = true;
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(CommonInstaller.CONEXOES["ConexaoTargetErp"].ToString());
			sqlConnection.Open();
			SqlDataReader sqlDataReader = new SqlCommand("SELECT TOP 1 replicate('0',5-len(nu_versao)) +nu_versao nu_versao, replicate('0',2-len(nu_release)) +cast(nu_release as varchar) nu_release, replicate('0',2-len(nu_patch)) +cast(nu_patch as varchar) nu_patch FROM versao_erp order by seq desc")
			{
				Connection = sqlConnection
			}.ExecuteReader();
			while (sqlDataReader.Read())
			{
				text = sqlDataReader["nu_versao"].ToString();
				text2 = sqlDataReader["nu_release"].ToString();
				text3 = sqlDataReader["nu_patch"].ToString();
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
			return false;
		}
		if (text.CompareTo("0" + CommonInstaller.CONFIGURACOES_SERVICO["VersaoERPMinimaAbsoluta"]) < 0)
		{
			result = false;
		}
		else
		{
			string[] array = CommonInstaller.CONFIGURACOES_SERVICO["ValidaVersaoERP"].Split('|');
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(';');
				string obj = ((array2[0].Length == 4) ? ("0" + array2[0]) : array2[0]);
				text4 = ((array2[1].Length == 1) ? ("0" + array2[1]) : array2[1]);
				text5 = ((array2[2].Length == 1) ? ("0" + array2[2]) : array2[2]);
				if (obj.CompareTo(text) == 0)
				{
					if (text2.CompareTo(text4) < 0)
					{
						result = false;
					}
					if (text2.CompareTo(text4) == 0 && text3.CompareTo(text5) < 0)
					{
						result = false;
					}
					break;
				}
			}
		}
		return result;
	}

	private void checkBoxCloud_CheckedChanged(object sender, EventArgs e)
	{
		txtConfigDbMobDbName.Enabled = checkBoxCloud.Checked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Target.Mob.Desktop.Installer.ERP.View.frmServiceInstaller));
		this.tbcWizard = new System.Windows.Forms.TabControl();
		this.tabConfigDbErp = new System.Windows.Forms.TabPage();
		this.txtConfigDbErpOdbcName = new System.Windows.Forms.TextBox();
		this.lblConfigDbErpOdbcName = new System.Windows.Forms.Label();
		this.pnlTargetErpTop = new System.Windows.Forms.Panel();
		this.lblConfigDbErpSubtitle = new System.Windows.Forms.Label();
		this.lblConfigDbErpTitle = new System.Windows.Forms.Label();
		this.pbxConfigDbErpImage = new System.Windows.Forms.PictureBox();
		this.txtConfigDbErpDbName = new System.Windows.Forms.TextBox();
		this.txtConfigDbErpPassword = new System.Windows.Forms.TextBox();
		this.txtConfigDbErpUserName = new System.Windows.Forms.TextBox();
		this.txtConfigDbErpSource = new System.Windows.Forms.TextBox();
		this.lblConfigDbErpDbName = new System.Windows.Forms.Label();
		this.lblConfigDbErpPassword = new System.Windows.Forms.Label();
		this.lblConfigDbErpUserName = new System.Windows.Forms.Label();
		this.radConfigDbErpSqlServerAuthentication = new System.Windows.Forms.RadioButton();
		this.radConfigDbErpWindowsAuthentication = new System.Windows.Forms.RadioButton();
		this.lblConfigDbErpAuthentication = new System.Windows.Forms.Label();
		this.lblConfigDbErpSource = new System.Windows.Forms.Label();
		this.btnConfigDbErpNext = new System.Windows.Forms.Button();
		this.tabConfigDbMob = new System.Windows.Forms.TabPage();
		this.checkBoxCloud = new System.Windows.Forms.CheckBox();
		this.usarLinkedServer = new System.Windows.Forms.CheckBox();
		this.NomeLinkedServer = new System.Windows.Forms.TextBox();
		this.pnlTargetMobTop = new System.Windows.Forms.Panel();
		this.lblConfigDbMobSubtitle = new System.Windows.Forms.Label();
		this.lblConfigDbMobTitle = new System.Windows.Forms.Label();
		this.pbxConfigDbMobImage = new System.Windows.Forms.PictureBox();
		this.txtConfigDbMobDbName = new System.Windows.Forms.TextBox();
		this.txtConfigDbMobPassword = new System.Windows.Forms.TextBox();
		this.txtConfigDbMobUserName = new System.Windows.Forms.TextBox();
		this.txtConfigDbMobDataSource = new System.Windows.Forms.TextBox();
		this.lblConfigDbMobDbName = new System.Windows.Forms.Label();
		this.lblConfigDbMobPassword = new System.Windows.Forms.Label();
		this.lblConfigDbMobUserName = new System.Windows.Forms.Label();
		this.radConfigDbMobSqlServerAuthentication = new System.Windows.Forms.RadioButton();
		this.radConfigDbMobWindowsAuthentication = new System.Windows.Forms.RadioButton();
		this.lblConfigDbMobAuthentication = new System.Windows.Forms.Label();
		this.lblConfigDbMobDataSource = new System.Windows.Forms.Label();
		this.btnConfigDbMobPrevious = new System.Windows.Forms.Button();
		this.btnConfigDbMobNext = new System.Windows.Forms.Button();
		this.tabServiceInstall = new System.Windows.Forms.TabPage();
		this.btnVoltarUsuario = new System.Windows.Forms.Button();
		this.radConfigUtilizarUsuarioSenha = new System.Windows.Forms.RadioButton();
		this.radConfigUtilizaLocalSystem = new System.Windows.Forms.RadioButton();
		this.txtServiceInstallPassword = new System.Windows.Forms.TextBox();
		this.txtServiceInstallUserName = new System.Windows.Forms.TextBox();
		this.lblServiceInstallPassword = new System.Windows.Forms.Label();
		this.lblServiceInstallUserName = new System.Windows.Forms.Label();
		this.btnServiceInstallNext = new System.Windows.Forms.Button();
		this.panel2 = new System.Windows.Forms.Panel();
		this.lblServiceInstallSubtitle = new System.Windows.Forms.Label();
		this.lblServiceInstallTitle = new System.Windows.Forms.Label();
		this.pbxServiceInstallImage = new System.Windows.Forms.PictureBox();
		this.tabAppUpdate = new System.Windows.Forms.TabPage();
		this.btnAppUpdatePrevious = new System.Windows.Forms.Button();
		this.lstAppUpdateOutput = new System.Windows.Forms.ListBox();
		this.pnlTargetScriptExecuteTop = new System.Windows.Forms.Panel();
		this.lblAppUpdateSubtitle = new System.Windows.Forms.Label();
		this.lblAppUpdateTitle = new System.Windows.Forms.Label();
		this.pbxAppUpdateImage = new System.Windows.Forms.PictureBox();
		this.btnAppUpdateRun = new System.Windows.Forms.Button();
		this.btnAppUpdateNext = new System.Windows.Forms.Button();
		this.tabFinish = new System.Windows.Forms.TabPage();
		this.ckbServiceInstallAutoStart = new System.Windows.Forms.CheckBox();
		this.btnFinishDone = new System.Windows.Forms.Button();
		this.lblFinishSuccess = new System.Windows.Forms.Label();
		this.pnlEndTop = new System.Windows.Forms.Panel();
		this.lblFinishSubtitle = new System.Windows.Forms.Label();
		this.lblFinishTitle = new System.Windows.Forms.Label();
		this.pbxFinishImage = new System.Windows.Forms.PictureBox();
		this.tbcWizard.SuspendLayout();
		this.tabConfigDbErp.SuspendLayout();
		this.pnlTargetErpTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxConfigDbErpImage).BeginInit();
		this.tabConfigDbMob.SuspendLayout();
		this.pnlTargetMobTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxConfigDbMobImage).BeginInit();
		this.tabServiceInstall.SuspendLayout();
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxServiceInstallImage).BeginInit();
		this.tabAppUpdate.SuspendLayout();
		this.pnlTargetScriptExecuteTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxAppUpdateImage).BeginInit();
		this.tabFinish.SuspendLayout();
		this.pnlEndTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxFinishImage).BeginInit();
		base.SuspendLayout();
		this.tbcWizard.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		this.tbcWizard.Controls.Add(this.tabConfigDbErp);
		this.tbcWizard.Controls.Add(this.tabConfigDbMob);
		this.tbcWizard.Controls.Add(this.tabServiceInstall);
		this.tbcWizard.Controls.Add(this.tabAppUpdate);
		this.tbcWizard.Controls.Add(this.tabFinish);
		this.tbcWizard.Location = new System.Drawing.Point(-6, -9);
		this.tbcWizard.Name = "tbcWizard";
		this.tbcWizard.SelectedIndex = 0;
		this.tbcWizard.Size = new System.Drawing.Size(513, 414);
		this.tbcWizard.TabIndex = 1;
		this.tabConfigDbErp.BackColor = System.Drawing.SystemColors.Control;
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpOdbcName);
		this.tabConfigDbErp.Controls.Add(this.lblConfigDbErpOdbcName);
		this.tabConfigDbErp.Controls.Add(this.pnlTargetErpTop);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpDbName);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpPassword);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpUserName);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpSource);
		this.tabConfigDbErp.Controls.Add(this.lblConfigDbErpDbName);
		this.tabConfigDbErp.Controls.Add(this.lblConfigDbErpPassword);
		this.tabConfigDbErp.Controls.Add(this.lblConfigDbErpUserName);
		this.tabConfigDbErp.Controls.Add(this.radConfigDbErpSqlServerAuthentication);
		this.tabConfigDbErp.Controls.Add(this.radConfigDbErpWindowsAuthentication);
		this.tabConfigDbErp.Controls.Add(this.lblConfigDbErpAuthentication);
		this.tabConfigDbErp.Controls.Add(this.lblConfigDbErpSource);
		this.tabConfigDbErp.Controls.Add(this.btnConfigDbErpNext);
		this.tabConfigDbErp.Location = new System.Drawing.Point(4, 4);
		this.tabConfigDbErp.Name = "tabConfigDbErp";
		this.tabConfigDbErp.Padding = new System.Windows.Forms.Padding(3);
		this.tabConfigDbErp.Size = new System.Drawing.Size(505, 388);
		this.tabConfigDbErp.TabIndex = 0;
		this.tabConfigDbErp.Text = "tabConfigDbErp";
		this.txtConfigDbErpOdbcName.Location = new System.Drawing.Point(198, 316);
		this.txtConfigDbErpOdbcName.Name = "txtConfigDbErpOdbcName";
		this.txtConfigDbErpOdbcName.Size = new System.Drawing.Size(204, 20);
		this.txtConfigDbErpOdbcName.TabIndex = 12;
		this.txtConfigDbErpOdbcName.Text = "MOINHO";
		this.lblConfigDbErpOdbcName.AutoSize = true;
		this.lblConfigDbErpOdbcName.Location = new System.Drawing.Point(47, 319);
		this.lblConfigDbErpOdbcName.Name = "lblConfigDbErpOdbcName";
		this.lblConfigDbErpOdbcName.Size = new System.Drawing.Size(131, 13);
		this.lblConfigDbErpOdbcName.TabIndex = 11;
		this.lblConfigDbErpOdbcName.Text = "4. Nome da entrada odbc:";
		this.pnlTargetErpTop.BackColor = System.Drawing.Color.White;
		this.pnlTargetErpTop.Controls.Add(this.lblConfigDbErpSubtitle);
		this.pnlTargetErpTop.Controls.Add(this.lblConfigDbErpTitle);
		this.pnlTargetErpTop.Controls.Add(this.pbxConfigDbErpImage);
		this.pnlTargetErpTop.Location = new System.Drawing.Point(0, 4);
		this.pnlTargetErpTop.Name = "pnlTargetErpTop";
		this.pnlTargetErpTop.Size = new System.Drawing.Size(504, 70);
		this.pnlTargetErpTop.TabIndex = 14;
		this.lblConfigDbErpSubtitle.AutoSize = true;
		this.lblConfigDbErpSubtitle.Location = new System.Drawing.Point(19, 41);
		this.lblConfigDbErpSubtitle.Name = "lblConfigDbErpSubtitle";
		this.lblConfigDbErpSubtitle.Size = new System.Drawing.Size(334, 13);
		this.lblConfigDbErpSubtitle.TabIndex = 3;
		this.lblConfigDbErpSubtitle.Text = "Insira as informações de conexão do banco de dados do Target ERP";
		this.lblConfigDbErpTitle.AutoSize = true;
		this.lblConfigDbErpTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblConfigDbErpTitle.Location = new System.Drawing.Point(10, 11);
		this.lblConfigDbErpTitle.Name = "lblConfigDbErpTitle";
		this.lblConfigDbErpTitle.Size = new System.Drawing.Size(193, 17);
		this.lblConfigDbErpTitle.TabIndex = 2;
		this.lblConfigDbErpTitle.Text = "Configuração Target ERP";
		this.pbxConfigDbErpImage.Image = (System.Drawing.Image)resources.GetObject("pbxConfigDbErpImage.Image");
		this.pbxConfigDbErpImage.Location = new System.Drawing.Point(427, 6);
		this.pbxConfigDbErpImage.Name = "pbxConfigDbErpImage";
		this.pbxConfigDbErpImage.Size = new System.Drawing.Size(67, 61);
		this.pbxConfigDbErpImage.TabIndex = 1;
		this.pbxConfigDbErpImage.TabStop = false;
		this.txtConfigDbErpDbName.Location = new System.Drawing.Point(198, 280);
		this.txtConfigDbErpDbName.Name = "txtConfigDbErpDbName";
		this.txtConfigDbErpDbName.Size = new System.Drawing.Size(204, 20);
		this.txtConfigDbErpDbName.TabIndex = 10;
		this.txtConfigDbErpDbName.Text = "MOINHO";
		this.txtConfigDbErpPassword.Location = new System.Drawing.Point(193, 243);
		this.txtConfigDbErpPassword.Name = "txtConfigDbErpPassword";
		this.txtConfigDbErpPassword.PasswordChar = '*';
		this.txtConfigDbErpPassword.Size = new System.Drawing.Size(209, 20);
		this.txtConfigDbErpPassword.TabIndex = 8;
		this.txtConfigDbErpUserName.Location = new System.Drawing.Point(193, 219);
		this.txtConfigDbErpUserName.Name = "txtConfigDbErpUserName";
		this.txtConfigDbErpUserName.Size = new System.Drawing.Size(209, 20);
		this.txtConfigDbErpUserName.TabIndex = 6;
		this.txtConfigDbErpSource.Location = new System.Drawing.Point(158, 95);
		this.txtConfigDbErpSource.Name = "txtConfigDbErpSource";
		this.txtConfigDbErpSource.Size = new System.Drawing.Size(291, 20);
		this.txtConfigDbErpSource.TabIndex = 1;
		this.txtConfigDbErpSource.Text = "(local)";
		this.lblConfigDbErpDbName.AutoSize = true;
		this.lblConfigDbErpDbName.Location = new System.Drawing.Point(47, 283);
		this.lblConfigDbErpDbName.Name = "lblConfigDbErpDbName";
		this.lblConfigDbErpDbName.Size = new System.Drawing.Size(145, 13);
		this.lblConfigDbErpDbName.TabIndex = 9;
		this.lblConfigDbErpDbName.Text = "3. Nome do banco de dados:";
		this.lblConfigDbErpPassword.AutoSize = true;
		this.lblConfigDbErpPassword.Location = new System.Drawing.Point(146, 243);
		this.lblConfigDbErpPassword.Name = "lblConfigDbErpPassword";
		this.lblConfigDbErpPassword.Size = new System.Drawing.Size(41, 13);
		this.lblConfigDbErpPassword.TabIndex = 7;
		this.lblConfigDbErpPassword.Text = "Senha:";
		this.lblConfigDbErpUserName.AutoSize = true;
		this.lblConfigDbErpUserName.Location = new System.Drawing.Point(95, 222);
		this.lblConfigDbErpUserName.Name = "lblConfigDbErpUserName";
		this.lblConfigDbErpUserName.Size = new System.Drawing.Size(92, 13);
		this.lblConfigDbErpUserName.TabIndex = 5;
		this.lblConfigDbErpUserName.Text = "Nome de Usuário:";
		this.radConfigDbErpSqlServerAuthentication.AutoSize = true;
		this.radConfigDbErpSqlServerAuthentication.Location = new System.Drawing.Point(69, 193);
		this.radConfigDbErpSqlServerAuthentication.Name = "radConfigDbErpSqlServerAuthentication";
		this.radConfigDbErpSqlServerAuthentication.Size = new System.Drawing.Size(221, 17);
		this.radConfigDbErpSqlServerAuthentication.TabIndex = 4;
		this.radConfigDbErpSqlServerAuthentication.TabStop = true;
		this.radConfigDbErpSqlServerAuthentication.Text = "Usar a seguinte senha e nome de usuário";
		this.radConfigDbErpSqlServerAuthentication.UseVisualStyleBackColor = true;
		this.radConfigDbErpSqlServerAuthentication.CheckedChanged += new System.EventHandler(radConfigDbErpSqlServerAuthentication_CheckedChanged);
		this.radConfigDbErpWindowsAuthentication.AutoSize = true;
		this.radConfigDbErpWindowsAuthentication.Location = new System.Drawing.Point(69, 170);
		this.radConfigDbErpWindowsAuthentication.Name = "radConfigDbErpWindowsAuthentication";
		this.radConfigDbErpWindowsAuthentication.Size = new System.Drawing.Size(171, 17);
		this.radConfigDbErpWindowsAuthentication.TabIndex = 3;
		this.radConfigDbErpWindowsAuthentication.TabStop = true;
		this.radConfigDbErpWindowsAuthentication.Text = "Usar autenticação do windows";
		this.radConfigDbErpWindowsAuthentication.UseVisualStyleBackColor = true;
		this.radConfigDbErpWindowsAuthentication.CheckedChanged += new System.EventHandler(radConfigDbErpWindowsAuthentication_CheckedChanged);
		this.lblConfigDbErpAuthentication.AutoSize = true;
		this.lblConfigDbErpAuthentication.Location = new System.Drawing.Point(47, 150);
		this.lblConfigDbErpAuthentication.Name = "lblConfigDbErpAuthentication";
		this.lblConfigDbErpAuthentication.Size = new System.Drawing.Size(118, 13);
		this.lblConfigDbErpAuthentication.TabIndex = 2;
		this.lblConfigDbErpAuthentication.Text = "2. Credenciais de logon";
		this.lblConfigDbErpSource.AutoSize = true;
		this.lblConfigDbErpSource.Location = new System.Drawing.Point(47, 98);
		this.lblConfigDbErpSource.Name = "lblConfigDbErpSource";
		this.lblConfigDbErpSource.Size = new System.Drawing.Size(105, 13);
		this.lblConfigDbErpSource.TabIndex = 0;
		this.lblConfigDbErpSource.Text = "1. Nome do servidor:";
		this.btnConfigDbErpNext.Location = new System.Drawing.Point(405, 346);
		this.btnConfigDbErpNext.Name = "btnConfigDbErpNext";
		this.btnConfigDbErpNext.Size = new System.Drawing.Size(75, 23);
		this.btnConfigDbErpNext.TabIndex = 13;
		this.btnConfigDbErpNext.Text = "&Avançar";
		this.btnConfigDbErpNext.UseVisualStyleBackColor = true;
		this.btnConfigDbErpNext.Click += new System.EventHandler(btnConfigDbErpNext_Click);
		this.tabConfigDbMob.BackColor = System.Drawing.SystemColors.Control;
		this.tabConfigDbMob.Controls.Add(this.checkBoxCloud);
		this.tabConfigDbMob.Controls.Add(this.usarLinkedServer);
		this.tabConfigDbMob.Controls.Add(this.NomeLinkedServer);
		this.tabConfigDbMob.Controls.Add(this.pnlTargetMobTop);
		this.tabConfigDbMob.Controls.Add(this.txtConfigDbMobDbName);
		this.tabConfigDbMob.Controls.Add(this.txtConfigDbMobPassword);
		this.tabConfigDbMob.Controls.Add(this.txtConfigDbMobUserName);
		this.tabConfigDbMob.Controls.Add(this.txtConfigDbMobDataSource);
		this.tabConfigDbMob.Controls.Add(this.lblConfigDbMobDbName);
		this.tabConfigDbMob.Controls.Add(this.lblConfigDbMobPassword);
		this.tabConfigDbMob.Controls.Add(this.lblConfigDbMobUserName);
		this.tabConfigDbMob.Controls.Add(this.radConfigDbMobSqlServerAuthentication);
		this.tabConfigDbMob.Controls.Add(this.radConfigDbMobWindowsAuthentication);
		this.tabConfigDbMob.Controls.Add(this.lblConfigDbMobAuthentication);
		this.tabConfigDbMob.Controls.Add(this.lblConfigDbMobDataSource);
		this.tabConfigDbMob.Controls.Add(this.btnConfigDbMobPrevious);
		this.tabConfigDbMob.Controls.Add(this.btnConfigDbMobNext);
		this.tabConfigDbMob.Location = new System.Drawing.Point(4, 4);
		this.tabConfigDbMob.Name = "tabConfigDbMob";
		this.tabConfigDbMob.Padding = new System.Windows.Forms.Padding(3);
		this.tabConfigDbMob.Size = new System.Drawing.Size(505, 388);
		this.tabConfigDbMob.TabIndex = 1;
		this.tabConfigDbMob.Text = "tabConfigDbMob";
		this.checkBoxCloud.AutoSize = true;
		this.checkBoxCloud.Location = new System.Drawing.Point(198, 306);
		this.checkBoxCloud.Name = "checkBoxCloud";
		this.checkBoxCloud.Size = new System.Drawing.Size(94, 17);
		this.checkBoxCloud.TabIndex = 29;
		this.checkBoxCloud.Text = "Cliente Cloud?";
		this.checkBoxCloud.UseVisualStyleBackColor = true;
		this.checkBoxCloud.CheckedChanged += new System.EventHandler(checkBoxCloud_CheckedChanged);
		this.usarLinkedServer.AutoSize = true;
		this.usarLinkedServer.Location = new System.Drawing.Point(36, 121);
		this.usarLinkedServer.Name = "usarLinkedServer";
		this.usarLinkedServer.Size = new System.Drawing.Size(117, 17);
		this.usarLinkedServer.TabIndex = 28;
		this.usarLinkedServer.Text = "Usar Linked Server";
		this.usarLinkedServer.UseVisualStyleBackColor = true;
		this.usarLinkedServer.CheckedChanged += new System.EventHandler(usarLinkedServer_CheckedChanged);
		this.NomeLinkedServer.Enabled = false;
		this.NomeLinkedServer.Location = new System.Drawing.Point(157, 122);
		this.NomeLinkedServer.Name = "NomeLinkedServer";
		this.NomeLinkedServer.Size = new System.Drawing.Size(291, 20);
		this.NomeLinkedServer.TabIndex = 27;
		this.pnlTargetMobTop.BackColor = System.Drawing.Color.White;
		this.pnlTargetMobTop.Controls.Add(this.lblConfigDbMobSubtitle);
		this.pnlTargetMobTop.Controls.Add(this.lblConfigDbMobTitle);
		this.pnlTargetMobTop.Controls.Add(this.pbxConfigDbMobImage);
		this.pnlTargetMobTop.Location = new System.Drawing.Point(0, 4);
		this.pnlTargetMobTop.Name = "pnlTargetMobTop";
		this.pnlTargetMobTop.Size = new System.Drawing.Size(504, 70);
		this.pnlTargetMobTop.TabIndex = 25;
		this.lblConfigDbMobSubtitle.AutoSize = true;
		this.lblConfigDbMobSubtitle.Location = new System.Drawing.Point(19, 41);
		this.lblConfigDbMobSubtitle.Name = "lblConfigDbMobSubtitle";
		this.lblConfigDbMobSubtitle.Size = new System.Drawing.Size(333, 13);
		this.lblConfigDbMobSubtitle.TabIndex = 3;
		this.lblConfigDbMobSubtitle.Text = "Insira as informações de conexão do banco de dados do Target Mob";
		this.lblConfigDbMobTitle.AutoSize = true;
		this.lblConfigDbMobTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblConfigDbMobTitle.Location = new System.Drawing.Point(10, 11);
		this.lblConfigDbMobTitle.Name = "lblConfigDbMobTitle";
		this.lblConfigDbMobTitle.Size = new System.Drawing.Size(192, 17);
		this.lblConfigDbMobTitle.TabIndex = 2;
		this.lblConfigDbMobTitle.Text = "Configuração Target Mob";
		this.pbxConfigDbMobImage.Image = (System.Drawing.Image)resources.GetObject("pbxConfigDbMobImage.Image");
		this.pbxConfigDbMobImage.Location = new System.Drawing.Point(427, 6);
		this.pbxConfigDbMobImage.Name = "pbxConfigDbMobImage";
		this.pbxConfigDbMobImage.Size = new System.Drawing.Size(67, 61);
		this.pbxConfigDbMobImage.TabIndex = 1;
		this.pbxConfigDbMobImage.TabStop = false;
		this.txtConfigDbMobDbName.Enabled = false;
		this.txtConfigDbMobDbName.Location = new System.Drawing.Point(198, 280);
		this.txtConfigDbMobDbName.Name = "txtConfigDbMobDbName";
		this.txtConfigDbMobDbName.Size = new System.Drawing.Size(204, 20);
		this.txtConfigDbMobDbName.TabIndex = 10;
		this.txtConfigDbMobDbName.Text = "TargetMob";
		this.txtConfigDbMobPassword.Location = new System.Drawing.Point(193, 243);
		this.txtConfigDbMobPassword.Name = "txtConfigDbMobPassword";
		this.txtConfigDbMobPassword.PasswordChar = '*';
		this.txtConfigDbMobPassword.Size = new System.Drawing.Size(209, 20);
		this.txtConfigDbMobPassword.TabIndex = 8;
		this.txtConfigDbMobUserName.Location = new System.Drawing.Point(193, 219);
		this.txtConfigDbMobUserName.Name = "txtConfigDbMobUserName";
		this.txtConfigDbMobUserName.Size = new System.Drawing.Size(209, 20);
		this.txtConfigDbMobUserName.TabIndex = 6;
		this.txtConfigDbMobDataSource.Location = new System.Drawing.Point(158, 95);
		this.txtConfigDbMobDataSource.Name = "txtConfigDbMobDataSource";
		this.txtConfigDbMobDataSource.Size = new System.Drawing.Size(291, 20);
		this.txtConfigDbMobDataSource.TabIndex = 1;
		this.txtConfigDbMobDataSource.Text = "(local)";
		this.lblConfigDbMobDbName.AutoSize = true;
		this.lblConfigDbMobDbName.Location = new System.Drawing.Point(47, 283);
		this.lblConfigDbMobDbName.Name = "lblConfigDbMobDbName";
		this.lblConfigDbMobDbName.Size = new System.Drawing.Size(145, 13);
		this.lblConfigDbMobDbName.TabIndex = 9;
		this.lblConfigDbMobDbName.Text = "3. Nome do banco de dados:";
		this.lblConfigDbMobPassword.AutoSize = true;
		this.lblConfigDbMobPassword.Location = new System.Drawing.Point(146, 243);
		this.lblConfigDbMobPassword.Name = "lblConfigDbMobPassword";
		this.lblConfigDbMobPassword.Size = new System.Drawing.Size(41, 13);
		this.lblConfigDbMobPassword.TabIndex = 7;
		this.lblConfigDbMobPassword.Text = "Senha:";
		this.lblConfigDbMobUserName.AutoSize = true;
		this.lblConfigDbMobUserName.Location = new System.Drawing.Point(95, 222);
		this.lblConfigDbMobUserName.Name = "lblConfigDbMobUserName";
		this.lblConfigDbMobUserName.Size = new System.Drawing.Size(92, 13);
		this.lblConfigDbMobUserName.TabIndex = 5;
		this.lblConfigDbMobUserName.Text = "Nome de Usuário:";
		this.radConfigDbMobSqlServerAuthentication.AutoSize = true;
		this.radConfigDbMobSqlServerAuthentication.Location = new System.Drawing.Point(69, 193);
		this.radConfigDbMobSqlServerAuthentication.Name = "radConfigDbMobSqlServerAuthentication";
		this.radConfigDbMobSqlServerAuthentication.Size = new System.Drawing.Size(221, 17);
		this.radConfigDbMobSqlServerAuthentication.TabIndex = 4;
		this.radConfigDbMobSqlServerAuthentication.TabStop = true;
		this.radConfigDbMobSqlServerAuthentication.Text = "Usar a seguinte senha e nome de usuário";
		this.radConfigDbMobSqlServerAuthentication.UseVisualStyleBackColor = true;
		this.radConfigDbMobSqlServerAuthentication.CheckedChanged += new System.EventHandler(radConfigDbMobSqlServerAuthentication_CheckedChanged);
		this.radConfigDbMobWindowsAuthentication.AutoSize = true;
		this.radConfigDbMobWindowsAuthentication.Location = new System.Drawing.Point(69, 170);
		this.radConfigDbMobWindowsAuthentication.Name = "radConfigDbMobWindowsAuthentication";
		this.radConfigDbMobWindowsAuthentication.Size = new System.Drawing.Size(171, 17);
		this.radConfigDbMobWindowsAuthentication.TabIndex = 3;
		this.radConfigDbMobWindowsAuthentication.TabStop = true;
		this.radConfigDbMobWindowsAuthentication.Text = "Usar autenticação do windows";
		this.radConfigDbMobWindowsAuthentication.UseVisualStyleBackColor = true;
		this.radConfigDbMobWindowsAuthentication.CheckedChanged += new System.EventHandler(radConfigDbMobWindowsAuthentication_CheckedChanged);
		this.lblConfigDbMobAuthentication.AutoSize = true;
		this.lblConfigDbMobAuthentication.Location = new System.Drawing.Point(47, 150);
		this.lblConfigDbMobAuthentication.Name = "lblConfigDbMobAuthentication";
		this.lblConfigDbMobAuthentication.Size = new System.Drawing.Size(118, 13);
		this.lblConfigDbMobAuthentication.TabIndex = 2;
		this.lblConfigDbMobAuthentication.Text = "2. Credenciais de logon";
		this.lblConfigDbMobDataSource.AutoSize = true;
		this.lblConfigDbMobDataSource.Location = new System.Drawing.Point(47, 98);
		this.lblConfigDbMobDataSource.Name = "lblConfigDbMobDataSource";
		this.lblConfigDbMobDataSource.Size = new System.Drawing.Size(105, 13);
		this.lblConfigDbMobDataSource.TabIndex = 0;
		this.lblConfigDbMobDataSource.Text = "1. Nome do servidor:";
		this.btnConfigDbMobPrevious.Location = new System.Drawing.Point(327, 346);
		this.btnConfigDbMobPrevious.Name = "btnConfigDbMobPrevious";
		this.btnConfigDbMobPrevious.Size = new System.Drawing.Size(75, 23);
		this.btnConfigDbMobPrevious.TabIndex = 11;
		this.btnConfigDbMobPrevious.Text = "&Voltar";
		this.btnConfigDbMobPrevious.UseVisualStyleBackColor = true;
		this.btnConfigDbMobPrevious.Click += new System.EventHandler(btnConfigDbMobPrevious_Click);
		this.btnConfigDbMobNext.Location = new System.Drawing.Point(405, 346);
		this.btnConfigDbMobNext.Name = "btnConfigDbMobNext";
		this.btnConfigDbMobNext.Size = new System.Drawing.Size(75, 23);
		this.btnConfigDbMobNext.TabIndex = 12;
		this.btnConfigDbMobNext.Text = "&Avançar";
		this.btnConfigDbMobNext.UseVisualStyleBackColor = true;
		this.btnConfigDbMobNext.Click += new System.EventHandler(btnConfigDbMobNext_Click);
		this.tabServiceInstall.BackColor = System.Drawing.SystemColors.Control;
		this.tabServiceInstall.Controls.Add(this.btnVoltarUsuario);
		this.tabServiceInstall.Controls.Add(this.radConfigUtilizarUsuarioSenha);
		this.tabServiceInstall.Controls.Add(this.radConfigUtilizaLocalSystem);
		this.tabServiceInstall.Controls.Add(this.txtServiceInstallPassword);
		this.tabServiceInstall.Controls.Add(this.txtServiceInstallUserName);
		this.tabServiceInstall.Controls.Add(this.lblServiceInstallPassword);
		this.tabServiceInstall.Controls.Add(this.lblServiceInstallUserName);
		this.tabServiceInstall.Controls.Add(this.btnServiceInstallNext);
		this.tabServiceInstall.Controls.Add(this.panel2);
		this.tabServiceInstall.Location = new System.Drawing.Point(4, 4);
		this.tabServiceInstall.Name = "tabServiceInstall";
		this.tabServiceInstall.Size = new System.Drawing.Size(505, 388);
		this.tabServiceInstall.TabIndex = 5;
		this.tabServiceInstall.Text = "tabServiceInstall";
		this.btnVoltarUsuario.Location = new System.Drawing.Point(324, 346);
		this.btnVoltarUsuario.Name = "btnVoltarUsuario";
		this.btnVoltarUsuario.Size = new System.Drawing.Size(75, 23);
		this.btnVoltarUsuario.TabIndex = 38;
		this.btnVoltarUsuario.Text = "&Voltar";
		this.btnVoltarUsuario.UseVisualStyleBackColor = true;
		this.btnVoltarUsuario.Click += new System.EventHandler(btnVoltarUsuario_Click);
		this.radConfigUtilizarUsuarioSenha.AutoSize = true;
		this.radConfigUtilizarUsuarioSenha.Location = new System.Drawing.Point(123, 148);
		this.radConfigUtilizarUsuarioSenha.Name = "radConfigUtilizarUsuarioSenha";
		this.radConfigUtilizarUsuarioSenha.Size = new System.Drawing.Size(289, 17);
		this.radConfigUtilizarUsuarioSenha.TabIndex = 33;
		this.radConfigUtilizarUsuarioSenha.Text = "Usar a seguinte senha e nome de usuário (AVANÇADO)";
		this.radConfigUtilizarUsuarioSenha.UseVisualStyleBackColor = true;
		this.radConfigUtilizaLocalSystem.AutoSize = true;
		this.radConfigUtilizaLocalSystem.Checked = true;
		this.radConfigUtilizaLocalSystem.Location = new System.Drawing.Point(123, 125);
		this.radConfigUtilizaLocalSystem.Name = "radConfigUtilizaLocalSystem";
		this.radConfigUtilizaLocalSystem.Size = new System.Drawing.Size(216, 17);
		this.radConfigUtilizaLocalSystem.TabIndex = 32;
		this.radConfigUtilizaLocalSystem.TabStop = true;
		this.radConfigUtilizaLocalSystem.Text = "Utilizar Local System (RECOMENDADO)";
		this.radConfigUtilizaLocalSystem.UseVisualStyleBackColor = true;
		this.txtServiceInstallPassword.Enabled = false;
		this.txtServiceInstallPassword.Location = new System.Drawing.Point(195, 201);
		this.txtServiceInstallPassword.Name = "txtServiceInstallPassword";
		this.txtServiceInstallPassword.PasswordChar = '*';
		this.txtServiceInstallPassword.Size = new System.Drawing.Size(209, 20);
		this.txtServiceInstallPassword.TabIndex = 35;
		this.txtServiceInstallUserName.Enabled = false;
		this.txtServiceInstallUserName.Location = new System.Drawing.Point(195, 177);
		this.txtServiceInstallUserName.Name = "txtServiceInstallUserName";
		this.txtServiceInstallUserName.Size = new System.Drawing.Size(209, 20);
		this.txtServiceInstallUserName.TabIndex = 34;
		this.lblServiceInstallPassword.AutoSize = true;
		this.lblServiceInstallPassword.Location = new System.Drawing.Point(148, 201);
		this.lblServiceInstallPassword.Name = "lblServiceInstallPassword";
		this.lblServiceInstallPassword.Size = new System.Drawing.Size(41, 13);
		this.lblServiceInstallPassword.TabIndex = 37;
		this.lblServiceInstallPassword.Text = "Senha:";
		this.lblServiceInstallUserName.AutoSize = true;
		this.lblServiceInstallUserName.Location = new System.Drawing.Point(97, 180);
		this.lblServiceInstallUserName.Name = "lblServiceInstallUserName";
		this.lblServiceInstallUserName.Size = new System.Drawing.Size(92, 13);
		this.lblServiceInstallUserName.TabIndex = 36;
		this.lblServiceInstallUserName.Text = "Nome de Usuário:";
		this.btnServiceInstallNext.Location = new System.Drawing.Point(405, 346);
		this.btnServiceInstallNext.Name = "btnServiceInstallNext";
		this.btnServiceInstallNext.Size = new System.Drawing.Size(75, 23);
		this.btnServiceInstallNext.TabIndex = 5;
		this.btnServiceInstallNext.Text = "&Avançar";
		this.btnServiceInstallNext.UseVisualStyleBackColor = true;
		this.btnServiceInstallNext.Click += new System.EventHandler(btnAvancarUsuarioServico_Click);
		this.panel2.BackColor = System.Drawing.Color.White;
		this.panel2.Controls.Add(this.lblServiceInstallSubtitle);
		this.panel2.Controls.Add(this.lblServiceInstallTitle);
		this.panel2.Controls.Add(this.pbxServiceInstallImage);
		this.panel2.Location = new System.Drawing.Point(0, 4);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(504, 70);
		this.panel2.TabIndex = 27;
		this.lblServiceInstallSubtitle.AutoSize = true;
		this.lblServiceInstallSubtitle.Location = new System.Drawing.Point(19, 41);
		this.lblServiceInstallSubtitle.Name = "lblServiceInstallSubtitle";
		this.lblServiceInstallSubtitle.Size = new System.Drawing.Size(316, 13);
		this.lblServiceInstallSubtitle.TabIndex = 3;
		this.lblServiceInstallSubtitle.Text = "Insira as credenciais que serão utilizadas na execução do serviço";
		this.lblServiceInstallTitle.AutoSize = true;
		this.lblServiceInstallTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblServiceInstallTitle.Location = new System.Drawing.Point(10, 11);
		this.lblServiceInstallTitle.Name = "lblServiceInstallTitle";
		this.lblServiceInstallTitle.Size = new System.Drawing.Size(164, 17);
		this.lblServiceInstallTitle.TabIndex = 2;
		this.lblServiceInstallTitle.Text = "Instalação do Serviço";
		this.pbxServiceInstallImage.Image = (System.Drawing.Image)resources.GetObject("pbxServiceInstallImage.Image");
		this.pbxServiceInstallImage.Location = new System.Drawing.Point(427, 6);
		this.pbxServiceInstallImage.Name = "pbxServiceInstallImage";
		this.pbxServiceInstallImage.Size = new System.Drawing.Size(67, 61);
		this.pbxServiceInstallImage.TabIndex = 1;
		this.pbxServiceInstallImage.TabStop = false;
		this.tabAppUpdate.BackColor = System.Drawing.SystemColors.Control;
		this.tabAppUpdate.Controls.Add(this.btnAppUpdatePrevious);
		this.tabAppUpdate.Controls.Add(this.lstAppUpdateOutput);
		this.tabAppUpdate.Controls.Add(this.pnlTargetScriptExecuteTop);
		this.tabAppUpdate.Controls.Add(this.btnAppUpdateRun);
		this.tabAppUpdate.Controls.Add(this.btnAppUpdateNext);
		this.tabAppUpdate.Location = new System.Drawing.Point(4, 4);
		this.tabAppUpdate.Name = "tabAppUpdate";
		this.tabAppUpdate.Size = new System.Drawing.Size(505, 388);
		this.tabAppUpdate.TabIndex = 2;
		this.tabAppUpdate.Text = "tabAppUpdate";
		this.btnAppUpdatePrevious.Location = new System.Drawing.Point(327, 346);
		this.btnAppUpdatePrevious.Name = "btnAppUpdatePrevious";
		this.btnAppUpdatePrevious.Size = new System.Drawing.Size(75, 23);
		this.btnAppUpdatePrevious.TabIndex = 2;
		this.btnAppUpdatePrevious.Text = "&Voltar";
		this.btnAppUpdatePrevious.UseVisualStyleBackColor = true;
		this.btnAppUpdatePrevious.Click += new System.EventHandler(btnAppUpdatePrevious_Click);
		this.lstAppUpdateOutput.FormattingEnabled = true;
		this.lstAppUpdateOutput.Location = new System.Drawing.Point(14, 80);
		this.lstAppUpdateOutput.Name = "lstAppUpdateOutput";
		this.lstAppUpdateOutput.Size = new System.Drawing.Size(475, 251);
		this.lstAppUpdateOutput.TabIndex = 0;
		this.pnlTargetScriptExecuteTop.BackColor = System.Drawing.Color.White;
		this.pnlTargetScriptExecuteTop.Controls.Add(this.lblAppUpdateSubtitle);
		this.pnlTargetScriptExecuteTop.Controls.Add(this.lblAppUpdateTitle);
		this.pnlTargetScriptExecuteTop.Controls.Add(this.pbxAppUpdateImage);
		this.pnlTargetScriptExecuteTop.Location = new System.Drawing.Point(0, 4);
		this.pnlTargetScriptExecuteTop.Name = "pnlTargetScriptExecuteTop";
		this.pnlTargetScriptExecuteTop.Size = new System.Drawing.Size(504, 70);
		this.pnlTargetScriptExecuteTop.TabIndex = 26;
		this.lblAppUpdateSubtitle.AutoSize = true;
		this.lblAppUpdateSubtitle.Location = new System.Drawing.Point(19, 41);
		this.lblAppUpdateSubtitle.Name = "lblAppUpdateSubtitle";
		this.lblAppUpdateSubtitle.Size = new System.Drawing.Size(278, 13);
		this.lblAppUpdateSubtitle.TabIndex = 3;
		this.lblAppUpdateSubtitle.Text = "Clique em executar para iniciar o processo de atualização";
		this.lblAppUpdateTitle.AutoSize = true;
		this.lblAppUpdateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAppUpdateTitle.Location = new System.Drawing.Point(10, 11);
		this.lblAppUpdateTitle.Name = "lblAppUpdateTitle";
		this.lblAppUpdateTitle.Size = new System.Drawing.Size(243, 17);
		this.lblAppUpdateTitle.TabIndex = 2;
		this.lblAppUpdateTitle.Text = "Atualização das bases de dados";
		this.pbxAppUpdateImage.Image = (System.Drawing.Image)resources.GetObject("pbxAppUpdateImage.Image");
		this.pbxAppUpdateImage.Location = new System.Drawing.Point(427, 6);
		this.pbxAppUpdateImage.Name = "pbxAppUpdateImage";
		this.pbxAppUpdateImage.Size = new System.Drawing.Size(67, 61);
		this.pbxAppUpdateImage.TabIndex = 1;
		this.pbxAppUpdateImage.TabStop = false;
		this.btnAppUpdateRun.Location = new System.Drawing.Point(13, 346);
		this.btnAppUpdateRun.Name = "btnAppUpdateRun";
		this.btnAppUpdateRun.Size = new System.Drawing.Size(75, 23);
		this.btnAppUpdateRun.TabIndex = 1;
		this.btnAppUpdateRun.Text = "&Executar";
		this.btnAppUpdateRun.UseVisualStyleBackColor = true;
		this.btnAppUpdateRun.Click += new System.EventHandler(btnAppUpdateRun_Click);
		this.btnAppUpdateNext.Enabled = false;
		this.btnAppUpdateNext.Location = new System.Drawing.Point(405, 346);
		this.btnAppUpdateNext.Name = "btnAppUpdateNext";
		this.btnAppUpdateNext.Size = new System.Drawing.Size(75, 23);
		this.btnAppUpdateNext.TabIndex = 3;
		this.btnAppUpdateNext.Text = "&Avançar";
		this.btnAppUpdateNext.UseVisualStyleBackColor = true;
		this.btnAppUpdateNext.Click += new System.EventHandler(btnAppUpdateNext_Click);
		this.tabFinish.BackColor = System.Drawing.SystemColors.Control;
		this.tabFinish.Controls.Add(this.ckbServiceInstallAutoStart);
		this.tabFinish.Controls.Add(this.btnFinishDone);
		this.tabFinish.Controls.Add(this.lblFinishSuccess);
		this.tabFinish.Controls.Add(this.pnlEndTop);
		this.tabFinish.Location = new System.Drawing.Point(4, 4);
		this.tabFinish.Name = "tabFinish";
		this.tabFinish.Size = new System.Drawing.Size(505, 388);
		this.tabFinish.TabIndex = 3;
		this.tabFinish.Text = "tabFinish";
		this.ckbServiceInstallAutoStart.AutoSize = true;
		this.ckbServiceInstallAutoStart.Checked = true;
		this.ckbServiceInstallAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
		this.ckbServiceInstallAutoStart.Location = new System.Drawing.Point(158, 207);
		this.ckbServiceInstallAutoStart.Name = "ckbServiceInstallAutoStart";
		this.ckbServiceInstallAutoStart.Size = new System.Drawing.Size(188, 17);
		this.ckbServiceInstallAutoStart.TabIndex = 17;
		this.ckbServiceInstallAutoStart.Text = "Iniciar serviço no fim da instalação";
		this.ckbServiceInstallAutoStart.UseVisualStyleBackColor = true;
		this.btnFinishDone.Location = new System.Drawing.Point(405, 346);
		this.btnFinishDone.Name = "btnFinishDone";
		this.btnFinishDone.Size = new System.Drawing.Size(75, 23);
		this.btnFinishDone.TabIndex = 1;
		this.btnFinishDone.Text = "&Concluir";
		this.btnFinishDone.UseVisualStyleBackColor = true;
		this.btnFinishDone.Click += new System.EventHandler(btnFinishDone_Click);
		this.lblFinishSuccess.AutoSize = true;
		this.lblFinishSuccess.Location = new System.Drawing.Point(124, 165);
		this.lblFinishSuccess.Name = "lblFinishSuccess";
		this.lblFinishSuccess.Size = new System.Drawing.Size(236, 13);
		this.lblFinishSuccess.TabIndex = 0;
		this.lblFinishSuccess.Text = "Processo de instalação concluído com sucesso!";
		this.pnlEndTop.BackColor = System.Drawing.Color.White;
		this.pnlEndTop.Controls.Add(this.lblFinishSubtitle);
		this.pnlEndTop.Controls.Add(this.lblFinishTitle);
		this.pnlEndTop.Controls.Add(this.pbxFinishImage);
		this.pnlEndTop.Location = new System.Drawing.Point(0, 4);
		this.pnlEndTop.Name = "pnlEndTop";
		this.pnlEndTop.Size = new System.Drawing.Size(504, 70);
		this.pnlEndTop.TabIndex = 15;
		this.lblFinishSubtitle.AutoSize = true;
		this.lblFinishSubtitle.Location = new System.Drawing.Point(19, 41);
		this.lblFinishSubtitle.Name = "lblFinishSubtitle";
		this.lblFinishSubtitle.Size = new System.Drawing.Size(172, 13);
		this.lblFinishSubtitle.TabIndex = 3;
		this.lblFinishSubtitle.Text = "Instalação concluída com sucesso";
		this.lblFinishTitle.AutoSize = true;
		this.lblFinishTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblFinishTitle.Location = new System.Drawing.Point(10, 11);
		this.lblFinishTitle.Name = "lblFinishTitle";
		this.lblFinishTitle.Size = new System.Drawing.Size(151, 17);
		this.lblFinishTitle.TabIndex = 2;
		this.lblFinishTitle.Text = "Processo Concluído";
		this.pbxFinishImage.Image = (System.Drawing.Image)resources.GetObject("pbxFinishImage.Image");
		this.pbxFinishImage.Location = new System.Drawing.Point(427, 6);
		this.pbxFinishImage.Name = "pbxFinishImage";
		this.pbxFinishImage.Size = new System.Drawing.Size(67, 61);
		this.pbxFinishImage.TabIndex = 1;
		this.pbxFinishImage.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(499, 403);
		base.Controls.Add(this.tbcWizard);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmServiceInstaller";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Instalação/Atualização Target Mob";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmServiceInstaller_FormClosing);
		this.tbcWizard.ResumeLayout(false);
		this.tabConfigDbErp.ResumeLayout(false);
		this.tabConfigDbErp.PerformLayout();
		this.pnlTargetErpTop.ResumeLayout(false);
		this.pnlTargetErpTop.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxConfigDbErpImage).EndInit();
		this.tabConfigDbMob.ResumeLayout(false);
		this.tabConfigDbMob.PerformLayout();
		this.pnlTargetMobTop.ResumeLayout(false);
		this.pnlTargetMobTop.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxConfigDbMobImage).EndInit();
		this.tabServiceInstall.ResumeLayout(false);
		this.tabServiceInstall.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxServiceInstallImage).EndInit();
		this.tabAppUpdate.ResumeLayout(false);
		this.pnlTargetScriptExecuteTop.ResumeLayout(false);
		this.pnlTargetScriptExecuteTop.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxAppUpdateImage).EndInit();
		this.tabFinish.ResumeLayout(false);
		this.tabFinish.PerformLayout();
		this.pnlEndTop.ResumeLayout(false);
		this.pnlEndTop.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxFinishImage).EndInit();
		base.ResumeLayout(false);
	}
}
