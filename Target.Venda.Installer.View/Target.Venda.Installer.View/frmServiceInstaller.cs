using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using Target.Venda.Installer.View.Common;

namespace Target.Venda.Installer.View;

public class frmServiceInstaller : Form
{
	private string msgRestricaoUsuario;

	private IContainer components = null;

	private TabPage tabFinish;

	private CheckBox ckbServiceInstallAutoStart;

	private Button btnFinishDone;

	private Label lblFinishSuccess;

	private Panel pnlEndTop;

	private PictureBox pbxFinishImage;

	private Label lblFinishSubtitle;

	private Label lblFinishTitle;

	private TabPage tabAppUpdate;

	private Button btnAppUpdatePrevious;

	private ListBox lstAppUpdateOutput;

	private Panel pnlTargetScriptExecuteTop;

	private PictureBox pbxAppUpdateImage;

	private Label lblAppUpdateSubtitle;

	private Label lblAppUpdateTitle;

	private Button btnAppUpdateRun;

	private Button btnAppUpdateNext;

	private TabPage tabConfigUserService;

	private Button btnVoltarUsuario;

	private Button btnAvancarUsuarioServico;

	private RadioButton radConfigUtilizarUsuarioSenha;

	private RadioButton radConfigUtilizaLocalSystem;

	private TextBox txtServiceInstallPassword;

	private TextBox txtServiceInstallUserName;

	private Label lblServiceInstallPassword;

	private Label lblServiceInstallUserName;

	private Panel panel2;

	private PictureBox pbxServiceInstallImage;

	private Label label2;

	private Label label8;

	private TabPage tabConfigDbErp;

	private TextBox txtConfigDbErpDbName;

	private TextBox txtConfigDbErpPassword;

	private TextBox txtConfigDbErpUserName;

	private TextBox txtConfigDbErpSource;

	private Panel pnlTargetErpTop;

	private PictureBox pbxConfigDbErpImage;

	private Label lblConfigDbErpSubtitle;

	private Label lblConfigDbErpTitle;

	private Label lblConfigDbErpDbName;

	private Label lblConfigDbErpPassword;

	private Label lblConfigDbErpUserName;

	private RadioButton radConfigDbErpSqlServerAuthentication;

	private RadioButton radConfigDbErpWindowsAuthentication;

	private Label lblConfigDbErpAuthentication;

	private Label lblConfigDbErpSource;

	private Button btnConfigDbErpNext;

	private TabControl tbcWizard;

	private TextBox txtConfigPort;

	private Label label1;

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
			CommonInstaller.Load(INSTALACAO_SILENCIOSA: false);
			CommonInstaller.MENSAGENS += WriteOutput;
			PreencherCamposAbaERP();
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
		if (tbcWizard.SelectedTab != tabFinish)
		{
			DialogResult dialogResult = MessageBox.Show("Deseja mesmo fechar o instalador? Isso poderá causar problemas na instalação atual!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (dialogResult == DialogResult.No)
			{
				e.Cancel = true;
			}
		}
	}

	private void PreencherCamposAbaERP()
	{
		radConfigDbErpSqlServerAuthentication.Checked = true;
		txtConfigDbErpUserName.Enabled = true;
		txtConfigDbErpPassword.Enabled = true;
		SqlConnectionStringBuilder sqlConnectionStringBuilder = CommonInstaller.CONEXOES["ERP"];
		txtConfigDbErpSource.Text = sqlConnectionStringBuilder.DataSource;
		txtConfigDbErpUserName.Text = sqlConnectionStringBuilder.UserID;
		txtConfigDbErpDbName.Text = sqlConnectionStringBuilder.InitialCatalog;
		txtConfigDbErpPassword.Text = sqlConnectionStringBuilder.Password;
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
		bool flag = CommonInstaller.ValidarAlterarStringConexao("ERP", txtConfigDbErpSource.Text, txtConfigDbErpDbName.Text, txtConfigDbErpUserName.Text, txtConfigDbErpPassword.Text, radConfigDbErpWindowsAuthentication.Checked);
		if (!flag)
		{
			CommonInstaller.ExibirMensagem("Não foi possível estabelecer uma conexão! Verifique os dados fornecidos e a conectividade da rede.", "Erro de Conexão", MessageBoxIcon.Asterisk);
			btnConfigDbErpNext.Enabled = true;
			Cursor = Cursors.Default;
		}
		else
		{
			if (!ValidaPortaComunicacao())
			{
				return;
			}
			if (flag)
			{
				Util.TabShow(tbcWizard, tabConfigUserService);
				if (Util.VerificarDistribuidoraTeste(CommonInstaller.CONEXOES["ERP"].ConnectionString))
				{
					CommonInstaller.CONFIGURACOES_SERVICO["EnvioVersao"] = "false";
				}
				else
				{
					CommonInstaller.CONFIGURACOES_SERVICO["EnvioVersao"] = "true";
				}
				ValidarUsuario();
			}
			btnConfigDbErpNext.Enabled = true;
			Cursor = Cursors.Default;
		}
	}

	private bool ValidaPortaComunicacao()
	{
		bool result = true;
		if (string.IsNullOrEmpty(txtConfigPort.Text) || string.IsNullOrWhiteSpace(txtConfigPort.Text))
		{
			CommonInstaller.ExibirMensagem("Não foi configurada a porta de comunicação da API! Verifique o valor informado.", "Validação", MessageBoxIcon.Asterisk);
			txtConfigPort.Focus();
			btnConfigDbErpNext.Enabled = true;
			Cursor = Cursors.Default;
			result = false;
		}
		else
		{
			try
			{
				Convert.ToInt32(txtConfigPort.Text);
			}
			catch (Exception)
			{
				CommonInstaller.ExibirMensagem("O valor definido para a porta de comunicação é inválido! Utilize apenas caracteres numéricos.", "Validação", MessageBoxIcon.Asterisk);
				txtConfigPort.Focus();
				btnConfigDbErpNext.Enabled = true;
				Cursor = Cursors.Default;
				result = false;
			}
		}
		CommonInstaller.CONFIGURACOES_SERVICO["PortaComunicacaoAPI"] = txtConfigPort.Text;
		return result;
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

	public void ValidarUsuario()
	{
		List<string> list = CommonInstaller.ValidarUsuarioCadastrado();
		if (list.Count == 1)
		{
			CommonInstaller.CONFIGURACOES_SERVICO["UsuarioServico"] = list.First();
			PreencherCamposAbaUsuario();
		}
		else if (list.Count > 1)
		{
			radConfigUtilizarUsuarioSenha.Checked = true;
			txtServiceInstallUserName.Enabled = true;
			txtServiceInstallPassword.Enabled = true;
			string mensagem = "O serviços tem usuários informados, verifique qual usuário deverá ser informado nesta tela.";
			CommonInstaller.ExibirMensagem(mensagem, "Atenção", MessageBoxIcon.Exclamation);
		}
	}

	private void btnAvancarUsuarioServico_Click(object sender, EventArgs e)
	{
		if (radConfigUtilizarUsuarioSenha.Checked && string.IsNullOrEmpty(txtServiceInstallUserName.Text))
		{
			CommonInstaller.ExibirMensagem("Informe um usuário e senha para continuar.", "Atenção", MessageBoxIcon.Exclamation);
			return;
		}
		if (!string.IsNullOrEmpty(txtServiceInstallUserName.Text) && string.IsNullOrEmpty(txtServiceInstallPassword.Text))
		{
			CommonInstaller.ExibirMensagem("Informe uma senha para o usuário", "Atenção", MessageBoxIcon.Exclamation);
			return;
		}
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
		Util.TabShow(tbcWizard, tabConfigDbErp);
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
		Thread thread = new Thread(Install);
		thread.Start();
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
		Pasta pasta = new Pasta();
		string fullPathApplicationDir = CommonInstaller._FullPathApplicationDir;
		string NomeCompartilhamnto = string.Empty;
		string text = string.Empty;
		ManagementBaseObject managementBaseObject = null;
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
			try
			{
				WriteOutput("Verificando configurações do Target Vendas...");
				WriteOutput(string.Empty);
				string text2 = Util.VerificaConfiguracaoServicos(CommonInstaller.CONEXOES["ERP"].ConnectionString);
				if (string.IsNullOrEmpty(text2))
				{
					string enderecoServidor = Util.VerificaEnderecoIpLocal();
					WriteOutput("1ª Instalação detectada...");
					WriteOutput(string.Empty);
					Util.InsereConfiguracaoServicos(CommonInstaller.CONEXOES["ERP"].ConnectionString, enderecoServidor, Convert.ToInt32(txtConfigPort.Text));
					Util.AtualizaVersaoAPI(CommonInstaller.CONEXOES["ERP"].ConnectionString);
					WriteOutput("Configurações do Target Vendas inseridas com sucesso...");
					WriteOutput(string.Empty);
				}
				else if (!string.IsNullOrEmpty(text2) && !text2.Equals(Util.VerificaEnderecoIpLocal()))
				{
					WriteOutput("O Target Vendas não é executado nesta estação, Instalação Cancelada...");
					WriteOutput(string.Empty);
					text = "O Target Vendas não é executado nesta estação, Instalação Cancelada";
					throw new Exception();
				}
			}
			catch (Exception ex)
			{
				WriteOutput("Configurações do Target Vendas não foram inseridas...");
				throw new Exception(ex.Message);
			}
			WriteOutput("Interrompendo Compartilhamento...");
			WriteOutput(string.Empty);
			managementBaseObject = pasta.getPastaCompartilhada(fullPathApplicationDir, out NomeCompartilhamnto);
			CommonInstaller.Install();
			try
			{
				WriteOutput(string.Empty);
				WriteOutput("Criando o Compartilhamento...");
				pasta.CriarPastaCompartilhada(fullPathApplicationDir, NomeCompartilhamnto, managementBaseObject);
				WriteOutput("Compartilhamento Criado com sucesso...");
			}
			catch (Exception)
			{
				WriteOutput("Compartilhamento não foi criado...");
			}
			Invoke((MethodInvoker)delegate
			{
				Cursor = Cursors.Default;
			});
			btnAppUpdateNext.Invoke((MethodInvoker)delegate
			{
				btnAppUpdateNext.Enabled = true;
			});
		}
		catch (Exception ex3)
		{
			CommonInstaller.ExibirMensagem((!string.IsNullOrEmpty(text)) ? text : ex3.Message, "Erro na Atualização", MessageBoxIcon.Hand);
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
		Util.TabShow(tbcWizard, tabConfigUserService);
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
		string text = "0";
		string text2 = "0";
		string text3 = "0";
		string[] array = CommonInstaller.CONFIGURACOES_SERVICO["ValidaVersaoERP"].Split('|');
		string[] array2 = array;
		foreach (string text4 in array2)
		{
			string[] array3 = text4.Split(';');
			text = array3[0];
			text2 = array3[1];
			text3 = array3[2];
			msgRestricaoUsuario += ((msgRestricaoUsuario == null) ? ("- " + text4.Replace(';', '.')) : ("\n- " + text4.Replace(';', '.')));
		}
		if (msgRestricaoUsuario != null)
		{
			msgRestricaoUsuario = "Restrições Release/Patch:\n " + msgRestricaoUsuario;
		}
	}

	private bool ValidarVersaoERP()
	{
		string value = "0";
		string value2 = "0";
		string value3 = "0";
		string text = "0";
		string text2 = "0";
		string text3 = "0";
		bool result = true;
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(CommonInstaller.CONEXOES["ERP"].ToString());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand("select top 1 nu_versao, nu_release, nu_patch from versao_erp order by seq desc");
			sqlCommand.Connection = sqlConnection;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				value = sqlDataReader["nu_versao"].ToString();
				value2 = sqlDataReader["nu_release"].ToString();
				value3 = sqlDataReader["nu_patch"].ToString();
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
			return false;
		}
		if (Convert.ToDouble(value) < Convert.ToDouble(CommonInstaller.CONFIGURACOES_SERVICO["VersaoERPMinimaAbsoluta"]))
		{
			result = false;
		}
		else
		{
			string[] array = CommonInstaller.CONFIGURACOES_SERVICO["ValidaVersaoERP"].Split('|');
			string[] array2 = array;
			foreach (string text4 in array2)
			{
				string[] array3 = text4.Split(';');
				text = array3[0];
				text2 = array3[1];
				text3 = array3[2];
				if (Convert.ToDouble(text) == Convert.ToDouble(value))
				{
					if (Convert.ToDouble(value2) < Convert.ToDouble(text2))
					{
						result = false;
					}
					if (Convert.ToDouble(value2) == Convert.ToDouble(text2) && Convert.ToDouble(value3) < Convert.ToDouble(text3))
					{
						result = false;
					}
					break;
				}
			}
		}
		return result;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Target.Venda.Installer.View.frmServiceInstaller));
		this.tabFinish = new System.Windows.Forms.TabPage();
		this.ckbServiceInstallAutoStart = new System.Windows.Forms.CheckBox();
		this.btnFinishDone = new System.Windows.Forms.Button();
		this.lblFinishSuccess = new System.Windows.Forms.Label();
		this.pnlEndTop = new System.Windows.Forms.Panel();
		this.pbxFinishImage = new System.Windows.Forms.PictureBox();
		this.lblFinishSubtitle = new System.Windows.Forms.Label();
		this.lblFinishTitle = new System.Windows.Forms.Label();
		this.tabAppUpdate = new System.Windows.Forms.TabPage();
		this.btnAppUpdatePrevious = new System.Windows.Forms.Button();
		this.lstAppUpdateOutput = new System.Windows.Forms.ListBox();
		this.pnlTargetScriptExecuteTop = new System.Windows.Forms.Panel();
		this.pbxAppUpdateImage = new System.Windows.Forms.PictureBox();
		this.lblAppUpdateSubtitle = new System.Windows.Forms.Label();
		this.lblAppUpdateTitle = new System.Windows.Forms.Label();
		this.btnAppUpdateRun = new System.Windows.Forms.Button();
		this.btnAppUpdateNext = new System.Windows.Forms.Button();
		this.tabConfigUserService = new System.Windows.Forms.TabPage();
		this.btnVoltarUsuario = new System.Windows.Forms.Button();
		this.btnAvancarUsuarioServico = new System.Windows.Forms.Button();
		this.radConfigUtilizarUsuarioSenha = new System.Windows.Forms.RadioButton();
		this.radConfigUtilizaLocalSystem = new System.Windows.Forms.RadioButton();
		this.txtServiceInstallPassword = new System.Windows.Forms.TextBox();
		this.txtServiceInstallUserName = new System.Windows.Forms.TextBox();
		this.lblServiceInstallPassword = new System.Windows.Forms.Label();
		this.lblServiceInstallUserName = new System.Windows.Forms.Label();
		this.panel2 = new System.Windows.Forms.Panel();
		this.pbxServiceInstallImage = new System.Windows.Forms.PictureBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.tabConfigDbErp = new System.Windows.Forms.TabPage();
		this.txtConfigPort = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.txtConfigDbErpDbName = new System.Windows.Forms.TextBox();
		this.txtConfigDbErpPassword = new System.Windows.Forms.TextBox();
		this.txtConfigDbErpUserName = new System.Windows.Forms.TextBox();
		this.txtConfigDbErpSource = new System.Windows.Forms.TextBox();
		this.pnlTargetErpTop = new System.Windows.Forms.Panel();
		this.pbxConfigDbErpImage = new System.Windows.Forms.PictureBox();
		this.lblConfigDbErpSubtitle = new System.Windows.Forms.Label();
		this.lblConfigDbErpTitle = new System.Windows.Forms.Label();
		this.lblConfigDbErpDbName = new System.Windows.Forms.Label();
		this.lblConfigDbErpPassword = new System.Windows.Forms.Label();
		this.lblConfigDbErpUserName = new System.Windows.Forms.Label();
		this.radConfigDbErpSqlServerAuthentication = new System.Windows.Forms.RadioButton();
		this.radConfigDbErpWindowsAuthentication = new System.Windows.Forms.RadioButton();
		this.lblConfigDbErpAuthentication = new System.Windows.Forms.Label();
		this.lblConfigDbErpSource = new System.Windows.Forms.Label();
		this.btnConfigDbErpNext = new System.Windows.Forms.Button();
		this.tbcWizard = new System.Windows.Forms.TabControl();
		this.tabFinish.SuspendLayout();
		this.pnlEndTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxFinishImage).BeginInit();
		this.tabAppUpdate.SuspendLayout();
		this.pnlTargetScriptExecuteTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxAppUpdateImage).BeginInit();
		this.tabConfigUserService.SuspendLayout();
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxServiceInstallImage).BeginInit();
		this.tabConfigDbErp.SuspendLayout();
		this.pnlTargetErpTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxConfigDbErpImage).BeginInit();
		this.tbcWizard.SuspendLayout();
		base.SuspendLayout();
		this.tabFinish.BackColor = System.Drawing.SystemColors.Control;
		this.tabFinish.Controls.Add(this.ckbServiceInstallAutoStart);
		this.tabFinish.Controls.Add(this.btnFinishDone);
		this.tabFinish.Controls.Add(this.lblFinishSuccess);
		this.tabFinish.Controls.Add(this.pnlEndTop);
		this.tabFinish.Location = new System.Drawing.Point(4, 4);
		this.tabFinish.Name = "tabFinish";
		this.tabFinish.Size = new System.Drawing.Size(505, 379);
		this.tabFinish.TabIndex = 3;
		this.tabFinish.Text = "tabFinish";
		this.ckbServiceInstallAutoStart.AutoSize = true;
		this.ckbServiceInstallAutoStart.Checked = true;
		this.ckbServiceInstallAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
		this.ckbServiceInstallAutoStart.Location = new System.Drawing.Point(144, 255);
		this.ckbServiceInstallAutoStart.Name = "ckbServiceInstallAutoStart";
		this.ckbServiceInstallAutoStart.Size = new System.Drawing.Size(188, 17);
		this.ckbServiceInstallAutoStart.TabIndex = 16;
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
		this.pnlEndTop.Controls.Add(this.pbxFinishImage);
		this.pnlEndTop.Controls.Add(this.lblFinishSubtitle);
		this.pnlEndTop.Controls.Add(this.lblFinishTitle);
		this.pnlEndTop.Location = new System.Drawing.Point(0, 4);
		this.pnlEndTop.Name = "pnlEndTop";
		this.pnlEndTop.Size = new System.Drawing.Size(504, 70);
		this.pnlEndTop.TabIndex = 15;
		this.pbxFinishImage.Image = (System.Drawing.Image)resources.GetObject("pbxFinishImage.Image");
		this.pbxFinishImage.Location = new System.Drawing.Point(422, 3);
		this.pbxFinishImage.Name = "pbxFinishImage";
		this.pbxFinishImage.Size = new System.Drawing.Size(67, 61);
		this.pbxFinishImage.TabIndex = 4;
		this.pbxFinishImage.TabStop = false;
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
		this.tabAppUpdate.BackColor = System.Drawing.SystemColors.Control;
		this.tabAppUpdate.Controls.Add(this.btnAppUpdatePrevious);
		this.tabAppUpdate.Controls.Add(this.lstAppUpdateOutput);
		this.tabAppUpdate.Controls.Add(this.pnlTargetScriptExecuteTop);
		this.tabAppUpdate.Controls.Add(this.btnAppUpdateRun);
		this.tabAppUpdate.Controls.Add(this.btnAppUpdateNext);
		this.tabAppUpdate.Location = new System.Drawing.Point(4, 4);
		this.tabAppUpdate.Name = "tabAppUpdate";
		this.tabAppUpdate.Size = new System.Drawing.Size(505, 379);
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
		this.pnlTargetScriptExecuteTop.Controls.Add(this.pbxAppUpdateImage);
		this.pnlTargetScriptExecuteTop.Controls.Add(this.lblAppUpdateSubtitle);
		this.pnlTargetScriptExecuteTop.Controls.Add(this.lblAppUpdateTitle);
		this.pnlTargetScriptExecuteTop.Location = new System.Drawing.Point(0, 4);
		this.pnlTargetScriptExecuteTop.Name = "pnlTargetScriptExecuteTop";
		this.pnlTargetScriptExecuteTop.Size = new System.Drawing.Size(504, 70);
		this.pnlTargetScriptExecuteTop.TabIndex = 26;
		this.pbxAppUpdateImage.Image = (System.Drawing.Image)resources.GetObject("pbxAppUpdateImage.Image");
		this.pbxAppUpdateImage.Location = new System.Drawing.Point(422, 3);
		this.pbxAppUpdateImage.Name = "pbxAppUpdateImage";
		this.pbxAppUpdateImage.Size = new System.Drawing.Size(67, 61);
		this.pbxAppUpdateImage.TabIndex = 4;
		this.pbxAppUpdateImage.TabStop = false;
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
		this.lblAppUpdateTitle.Size = new System.Drawing.Size(181, 17);
		this.lblAppUpdateTitle.TabIndex = 2;
		this.lblAppUpdateTitle.Text = "Atualização a Aplicação";
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
		this.tabConfigUserService.BackColor = System.Drawing.SystemColors.Control;
		this.tabConfigUserService.Controls.Add(this.btnVoltarUsuario);
		this.tabConfigUserService.Controls.Add(this.btnAvancarUsuarioServico);
		this.tabConfigUserService.Controls.Add(this.radConfigUtilizarUsuarioSenha);
		this.tabConfigUserService.Controls.Add(this.radConfigUtilizaLocalSystem);
		this.tabConfigUserService.Controls.Add(this.txtServiceInstallPassword);
		this.tabConfigUserService.Controls.Add(this.txtServiceInstallUserName);
		this.tabConfigUserService.Controls.Add(this.lblServiceInstallPassword);
		this.tabConfigUserService.Controls.Add(this.lblServiceInstallUserName);
		this.tabConfigUserService.Controls.Add(this.panel2);
		this.tabConfigUserService.Location = new System.Drawing.Point(4, 4);
		this.tabConfigUserService.Name = "tabConfigUserService";
		this.tabConfigUserService.Padding = new System.Windows.Forms.Padding(3);
		this.tabConfigUserService.Size = new System.Drawing.Size(505, 379);
		this.tabConfigUserService.TabIndex = 5;
		this.tabConfigUserService.Text = "tabConfigUserService";
		this.btnVoltarUsuario.Location = new System.Drawing.Point(333, 326);
		this.btnVoltarUsuario.Name = "btnVoltarUsuario";
		this.btnVoltarUsuario.Size = new System.Drawing.Size(75, 23);
		this.btnVoltarUsuario.TabIndex = 34;
		this.btnVoltarUsuario.Text = "&Voltar";
		this.btnVoltarUsuario.UseVisualStyleBackColor = true;
		this.btnVoltarUsuario.Click += new System.EventHandler(btnVoltarUsuario_Click);
		this.btnAvancarUsuarioServico.Location = new System.Drawing.Point(414, 326);
		this.btnAvancarUsuarioServico.Name = "btnAvancarUsuarioServico";
		this.btnAvancarUsuarioServico.Size = new System.Drawing.Size(75, 23);
		this.btnAvancarUsuarioServico.TabIndex = 33;
		this.btnAvancarUsuarioServico.Text = "&Avançar";
		this.btnAvancarUsuarioServico.UseVisualStyleBackColor = true;
		this.btnAvancarUsuarioServico.Click += new System.EventHandler(btnAvancarUsuarioServico_Click);
		this.radConfigUtilizarUsuarioSenha.AutoSize = true;
		this.radConfigUtilizarUsuarioSenha.Location = new System.Drawing.Point(113, 140);
		this.radConfigUtilizarUsuarioSenha.Name = "radConfigUtilizarUsuarioSenha";
		this.radConfigUtilizarUsuarioSenha.Size = new System.Drawing.Size(289, 17);
		this.radConfigUtilizarUsuarioSenha.TabIndex = 1;
		this.radConfigUtilizarUsuarioSenha.Text = "Usar a seguinte senha e nome de usuário (AVANÇADO)";
		this.radConfigUtilizarUsuarioSenha.UseVisualStyleBackColor = true;
		this.radConfigUtilizarUsuarioSenha.CheckedChanged += new System.EventHandler(radConfigUtilizarUsuarioSenha_CheckedChanged);
		this.radConfigUtilizaLocalSystem.AutoSize = true;
		this.radConfigUtilizaLocalSystem.Checked = true;
		this.radConfigUtilizaLocalSystem.Location = new System.Drawing.Point(113, 117);
		this.radConfigUtilizaLocalSystem.Name = "radConfigUtilizaLocalSystem";
		this.radConfigUtilizaLocalSystem.Size = new System.Drawing.Size(216, 17);
		this.radConfigUtilizaLocalSystem.TabIndex = 0;
		this.radConfigUtilizaLocalSystem.TabStop = true;
		this.radConfigUtilizaLocalSystem.Text = "Utilizar Local System (RECOMENDADO)";
		this.radConfigUtilizaLocalSystem.UseVisualStyleBackColor = true;
		this.radConfigUtilizaLocalSystem.CheckedChanged += new System.EventHandler(radConfigUtilizaLocalSystem_CheckedChanged);
		this.txtServiceInstallPassword.Enabled = false;
		this.txtServiceInstallPassword.Location = new System.Drawing.Point(185, 193);
		this.txtServiceInstallPassword.Name = "txtServiceInstallPassword";
		this.txtServiceInstallPassword.PasswordChar = '*';
		this.txtServiceInstallPassword.Size = new System.Drawing.Size(209, 20);
		this.txtServiceInstallPassword.TabIndex = 3;
		this.txtServiceInstallUserName.Enabled = false;
		this.txtServiceInstallUserName.Location = new System.Drawing.Point(185, 169);
		this.txtServiceInstallUserName.Name = "txtServiceInstallUserName";
		this.txtServiceInstallUserName.Size = new System.Drawing.Size(209, 20);
		this.txtServiceInstallUserName.TabIndex = 2;
		this.lblServiceInstallPassword.AutoSize = true;
		this.lblServiceInstallPassword.Location = new System.Drawing.Point(138, 193);
		this.lblServiceInstallPassword.Name = "lblServiceInstallPassword";
		this.lblServiceInstallPassword.Size = new System.Drawing.Size(41, 13);
		this.lblServiceInstallPassword.TabIndex = 31;
		this.lblServiceInstallPassword.Text = "Senha:";
		this.lblServiceInstallUserName.AutoSize = true;
		this.lblServiceInstallUserName.Location = new System.Drawing.Point(87, 172);
		this.lblServiceInstallUserName.Name = "lblServiceInstallUserName";
		this.lblServiceInstallUserName.Size = new System.Drawing.Size(92, 13);
		this.lblServiceInstallUserName.TabIndex = 29;
		this.lblServiceInstallUserName.Text = "Nome de Usuário:";
		this.panel2.BackColor = System.Drawing.Color.White;
		this.panel2.Controls.Add(this.pbxServiceInstallImage);
		this.panel2.Controls.Add(this.label2);
		this.panel2.Controls.Add(this.label8);
		this.panel2.Location = new System.Drawing.Point(0, 4);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(504, 70);
		this.panel2.TabIndex = 28;
		this.pbxServiceInstallImage.Image = (System.Drawing.Image)resources.GetObject("pbxServiceInstallImage.Image");
		this.pbxServiceInstallImage.Location = new System.Drawing.Point(422, 3);
		this.pbxServiceInstallImage.Name = "pbxServiceInstallImage";
		this.pbxServiceInstallImage.Size = new System.Drawing.Size(67, 61);
		this.pbxServiceInstallImage.TabIndex = 35;
		this.pbxServiceInstallImage.TabStop = false;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(19, 41);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(310, 13);
		this.label2.TabIndex = 3;
		this.label2.Text = "Insira as informações dos Usuarios para Instalação dos Serviços";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.Location = new System.Drawing.Point(10, 11);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(286, 17);
		this.label8.TabIndex = 2;
		this.label8.Text = "Configuração do Usuário dos Serviços";
		this.tabConfigDbErp.BackColor = System.Drawing.SystemColors.Control;
		this.tabConfigDbErp.Controls.Add(this.txtConfigPort);
		this.tabConfigDbErp.Controls.Add(this.label1);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpDbName);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpPassword);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpUserName);
		this.tabConfigDbErp.Controls.Add(this.txtConfigDbErpSource);
		this.tabConfigDbErp.Controls.Add(this.pnlTargetErpTop);
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
		this.tabConfigDbErp.Size = new System.Drawing.Size(505, 379);
		this.tabConfigDbErp.TabIndex = 0;
		this.tabConfigDbErp.Text = "tabConfigDbErp";
		this.txtConfigPort.Location = new System.Drawing.Point(198, 288);
		this.txtConfigPort.Name = "txtConfigPort";
		this.txtConfigPort.Size = new System.Drawing.Size(204, 20);
		this.txtConfigPort.TabIndex = 16;
		this.txtConfigPort.Text = "30212";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(44, 291);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(148, 13);
		this.label1.TabIndex = 15;
		this.label1.Text = "4. Porta de Comunicação Api:";
		this.txtConfigDbErpDbName.Location = new System.Drawing.Point(198, 262);
		this.txtConfigDbErpDbName.Name = "txtConfigDbErpDbName";
		this.txtConfigDbErpDbName.Size = new System.Drawing.Size(204, 20);
		this.txtConfigDbErpDbName.TabIndex = 10;
		this.txtConfigDbErpDbName.Text = "MOINHO";
		this.txtConfigDbErpPassword.Location = new System.Drawing.Point(193, 225);
		this.txtConfigDbErpPassword.Name = "txtConfigDbErpPassword";
		this.txtConfigDbErpPassword.PasswordChar = '*';
		this.txtConfigDbErpPassword.Size = new System.Drawing.Size(209, 20);
		this.txtConfigDbErpPassword.TabIndex = 8;
		this.txtConfigDbErpUserName.Location = new System.Drawing.Point(193, 201);
		this.txtConfigDbErpUserName.Name = "txtConfigDbErpUserName";
		this.txtConfigDbErpUserName.Size = new System.Drawing.Size(209, 20);
		this.txtConfigDbErpUserName.TabIndex = 6;
		this.txtConfigDbErpSource.Location = new System.Drawing.Point(158, 95);
		this.txtConfigDbErpSource.Name = "txtConfigDbErpSource";
		this.txtConfigDbErpSource.Size = new System.Drawing.Size(291, 20);
		this.txtConfigDbErpSource.TabIndex = 1;
		this.txtConfigDbErpSource.Text = "(local)";
		this.pnlTargetErpTop.BackColor = System.Drawing.Color.White;
		this.pnlTargetErpTop.Controls.Add(this.pbxConfigDbErpImage);
		this.pnlTargetErpTop.Controls.Add(this.lblConfigDbErpSubtitle);
		this.pnlTargetErpTop.Controls.Add(this.lblConfigDbErpTitle);
		this.pnlTargetErpTop.Location = new System.Drawing.Point(0, 4);
		this.pnlTargetErpTop.Name = "pnlTargetErpTop";
		this.pnlTargetErpTop.Size = new System.Drawing.Size(504, 70);
		this.pnlTargetErpTop.TabIndex = 14;
		this.pbxConfigDbErpImage.Image = (System.Drawing.Image)resources.GetObject("pbxConfigDbErpImage.Image");
		this.pbxConfigDbErpImage.Location = new System.Drawing.Point(422, 3);
		this.pbxConfigDbErpImage.Name = "pbxConfigDbErpImage";
		this.pbxConfigDbErpImage.Size = new System.Drawing.Size(67, 61);
		this.pbxConfigDbErpImage.TabIndex = 4;
		this.pbxConfigDbErpImage.TabStop = false;
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
		this.lblConfigDbErpDbName.AutoSize = true;
		this.lblConfigDbErpDbName.Location = new System.Drawing.Point(47, 265);
		this.lblConfigDbErpDbName.Name = "lblConfigDbErpDbName";
		this.lblConfigDbErpDbName.Size = new System.Drawing.Size(145, 13);
		this.lblConfigDbErpDbName.TabIndex = 9;
		this.lblConfigDbErpDbName.Text = "3. Nome do banco de dados:";
		this.lblConfigDbErpPassword.AutoSize = true;
		this.lblConfigDbErpPassword.Location = new System.Drawing.Point(146, 225);
		this.lblConfigDbErpPassword.Name = "lblConfigDbErpPassword";
		this.lblConfigDbErpPassword.Size = new System.Drawing.Size(41, 13);
		this.lblConfigDbErpPassword.TabIndex = 7;
		this.lblConfigDbErpPassword.Text = "Senha:";
		this.lblConfigDbErpUserName.AutoSize = true;
		this.lblConfigDbErpUserName.Location = new System.Drawing.Point(95, 204);
		this.lblConfigDbErpUserName.Name = "lblConfigDbErpUserName";
		this.lblConfigDbErpUserName.Size = new System.Drawing.Size(92, 13);
		this.lblConfigDbErpUserName.TabIndex = 5;
		this.lblConfigDbErpUserName.Text = "Nome de Usuário:";
		this.radConfigDbErpSqlServerAuthentication.AutoSize = true;
		this.radConfigDbErpSqlServerAuthentication.Location = new System.Drawing.Point(69, 175);
		this.radConfigDbErpSqlServerAuthentication.Name = "radConfigDbErpSqlServerAuthentication";
		this.radConfigDbErpSqlServerAuthentication.Size = new System.Drawing.Size(221, 17);
		this.radConfigDbErpSqlServerAuthentication.TabIndex = 4;
		this.radConfigDbErpSqlServerAuthentication.TabStop = true;
		this.radConfigDbErpSqlServerAuthentication.Text = "Usar a seguinte senha e nome de usuário";
		this.radConfigDbErpSqlServerAuthentication.UseVisualStyleBackColor = true;
		this.radConfigDbErpSqlServerAuthentication.CheckedChanged += new System.EventHandler(radConfigDbErpSqlServerAuthentication_CheckedChanged);
		this.radConfigDbErpWindowsAuthentication.AutoSize = true;
		this.radConfigDbErpWindowsAuthentication.Location = new System.Drawing.Point(69, 152);
		this.radConfigDbErpWindowsAuthentication.Name = "radConfigDbErpWindowsAuthentication";
		this.radConfigDbErpWindowsAuthentication.Size = new System.Drawing.Size(171, 17);
		this.radConfigDbErpWindowsAuthentication.TabIndex = 3;
		this.radConfigDbErpWindowsAuthentication.TabStop = true;
		this.radConfigDbErpWindowsAuthentication.Text = "Usar autenticação do windows";
		this.radConfigDbErpWindowsAuthentication.UseVisualStyleBackColor = true;
		this.radConfigDbErpWindowsAuthentication.CheckedChanged += new System.EventHandler(radConfigDbErpWindowsAuthentication_CheckedChanged);
		this.lblConfigDbErpAuthentication.AutoSize = true;
		this.lblConfigDbErpAuthentication.Location = new System.Drawing.Point(47, 132);
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
		this.btnConfigDbErpNext.Location = new System.Drawing.Point(414, 326);
		this.btnConfigDbErpNext.Name = "btnConfigDbErpNext";
		this.btnConfigDbErpNext.Size = new System.Drawing.Size(75, 23);
		this.btnConfigDbErpNext.TabIndex = 13;
		this.btnConfigDbErpNext.Text = "&Avançar";
		this.btnConfigDbErpNext.UseVisualStyleBackColor = true;
		this.btnConfigDbErpNext.Click += new System.EventHandler(btnConfigDbErpNext_Click);
		this.tbcWizard.Alignment = System.Windows.Forms.TabAlignment.Bottom;
		this.tbcWizard.Controls.Add(this.tabConfigDbErp);
		this.tbcWizard.Controls.Add(this.tabConfigUserService);
		this.tbcWizard.Controls.Add(this.tabAppUpdate);
		this.tbcWizard.Controls.Add(this.tabFinish);
		this.tbcWizard.Location = new System.Drawing.Point(-6, -9);
		this.tbcWizard.Name = "tbcWizard";
		this.tbcWizard.SelectedIndex = 0;
		this.tbcWizard.Size = new System.Drawing.Size(513, 405);
		this.tbcWizard.TabIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(499, 408);
		base.Controls.Add(this.tbcWizard);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmServiceInstaller";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Instalação/Atualização Target Vendas";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmServiceInstaller_FormClosing);
		this.tabFinish.ResumeLayout(false);
		this.tabFinish.PerformLayout();
		this.pnlEndTop.ResumeLayout(false);
		this.pnlEndTop.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxFinishImage).EndInit();
		this.tabAppUpdate.ResumeLayout(false);
		this.pnlTargetScriptExecuteTop.ResumeLayout(false);
		this.pnlTargetScriptExecuteTop.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxAppUpdateImage).EndInit();
		this.tabConfigUserService.ResumeLayout(false);
		this.tabConfigUserService.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxServiceInstallImage).EndInit();
		this.tabConfigDbErp.ResumeLayout(false);
		this.tabConfigDbErp.PerformLayout();
		this.pnlTargetErpTop.ResumeLayout(false);
		this.pnlTargetErpTop.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbxConfigDbErpImage).EndInit();
		this.tbcWizard.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
