using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Target.Venda.Business.Entidade;
using Target.Venda.Helpers.Log;
using Target.Venda.IBusiness.Factory;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Venda.View;

public class FrmVendas : Form
{
	private ILiberarPedidoEletronicoBLL Liberar;

	private IContainer components = null;

	private GroupBox grpFiltros;

	private TextBox txtCodCliente;

	private Label lblCliente;

	private TextBox txtNroPedidoEle;

	private Label lblNroPedidoEle;

	private Button btnLimpar;

	private Button btnBuscar;

	private DataGridView dgvPedidoEletronicos;

	private CheckBox chkLiberaAuto;

	private Label lblEmpresa;

	private ComboBox cbxEmrpesas;

	private MaskedTextBox txtHoraFim;

	private Label label1;

	private MaskedTextBox txtHoraInicio;

	private Label lblInicio;

	private GroupBox groupBox1;

	private Label lblmsgProcessando;

	private ProgressBar pbPedidos;

	private Label lblQtdePedidosSelecionados;

	private Label lblQtdePedidos;

	private Label lblTotalPedidos;

	private Button btnLiberarMultiThread;

	private Button btnLiberar;

	private Label lblPercProcessado;

	private DataGridViewTextBoxColumn TIPO_INTEGRACAO;

	private DataGridViewTextBoxColumn NU_PED_ELE;

	private DataGridViewTextBoxColumn CD_EMP_ELE;

	private DataGridViewTextBoxColumn SEQ_PED_ELE;

	private DataGridViewTextBoxColumn DATA_PEDIDO;

	private DataGridViewTextBoxColumn CODIGO_CLIENTE;

	private DataGridViewTextBoxColumn NOME_CLIENTE;

	private DataGridViewTextBoxColumn VALOR_TOTAL;

	private DataGridViewTextBoxColumn VALOR_TOTAL_COM_DESCONTO;

	private DataGridViewTextBoxColumn TOTAL_ITENS;

	private DataGridViewTextBoxColumn STATUS;

	private DataGridViewTextBoxColumn OBS;

	private Label label2;

	private DataGridView dgvOrigemPedido;

	private DataGridViewTextBoxColumn colOrigemPedido;

	private DataGridViewTextBoxColumn colDescricao;

	private DataGridViewCheckBoxColumn colExibe;

	private CheckBox chkTimerLibera;

	private Timer tmrLiberaAuto;

	public FrmVendas()
	{
		InitializeComponent();
		PreencheCombos();
		CarregaTabelaOrigemPedido();
	}

	private void PreencheCombos()
	{
		EmpresaBLL empresaBLL = new EmpresaBLL();
		List<EmpresaMO> dataSource = empresaBLL.ObterPeloExemplo(new EmpresaMO());
		cbxEmrpesas.DataSource = dataSource;
		cbxEmrpesas.DisplayMember = "NOME_FANTASIA";
		cbxEmrpesas.ValueMember = "CODIGO_EMPRESA";
		cbxEmrpesas.SelectedIndex = 0;
	}

	private void CarregaTabelaOrigemPedido()
	{
		OrigemPedidoVendaBLL origemPedidoVendaBLL = new OrigemPedidoVendaBLL();
		List<OrigemPedidoVendaVO> list = origemPedidoVendaBLL.ObterOrigemPedidoVendaLista();
		foreach (OrigemPedidoVendaVO item in list)
		{
			dgvOrigemPedido.Rows.Add(item.ORIGEM_PEDIDO, item.DESCRICAO, item.LISTA_PEDIDO_PENDENTE);
		}
	}

	private void LimparTela()
	{
		txtCodCliente.Clear();
		txtNroPedidoEle.Clear();
		dgvPedidoEletronicos.Rows.Clear();
		lblQtdePedidos.Text = "0";
		chkLiberaAuto.Checked = false;
		LimparStatus();
	}

	private void LimparStatus()
	{
		txtHoraInicio.Clear();
		txtHoraFim.Clear();
		lblmsgProcessando.Text = "0";
		lblQtdePedidosSelecionados.Text = "0";
		pbPedidos.Value = 0;
		lblPercProcessado.Text = "0 %";
		lblmsgProcessando.Text = "";
	}

	private void BuscarPedidosEletronicos()
	{
		dgvPedidoEletronicos.Rows.Clear();
		PedidoEletronicoMO pedidoEletronicoMO = PreencherFiltrosPedidosEletronicos();
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		List<PedidoEletronicoVO> list = pedidoEletronicoBLL.ObterPedidosParaLiberar(pedidoEletronicoMO);
		if ((list == null || list.Count == 0) && !chkTimerLibera.Checked)
		{
			MessageBox.Show("Não há pedidos a serem liberados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			btnLimpar_Click(null, null);
		}
		else
		{
			PreencherGrid(list);
		}
	}

	private void PreencherGrid(List<PedidoEletronicoVO> listaPedidos)
	{
		lblQtdePedidos.Text = listaPedidos.Count.ToString();
		dgvPedidoEletronicos.Rows.Clear();
		foreach (PedidoEletronicoVO listaPedido in listaPedidos)
		{
			dgvPedidoEletronicos.Rows.Add(listaPedido.TIPO_INTEGRACAO, listaPedido.NUMERO_PEDIDO_ELETRONICO.ToString(), listaPedido.CODIGO_EMPRESA_ELETRONICO.ToString(), "1", listaPedido.DATA_PEDIDO, listaPedido.CODIGO_CLIENTE.ToString(), listaPedido.NOME_CLIENTE.ToString(), listaPedido.VALOR_TOTAL, listaPedido.VALOR_TOTAL_COM_DESCONTO, listaPedido.TOTAL_ITENS, "PENDENTE");
		}
	}

	private PedidoEletronicoMO PreencherFiltrosPedidosEletronicos()
	{
		PedidoEletronicoMO pedidoEletronicoMO = new PedidoEletronicoMO();
		pedidoEletronicoMO.SITUACAO = "AB";
		pedidoEletronicoMO.LIBERACAO_AUTOMATICA = chkLiberaAuto.Checked;
		if (!string.IsNullOrEmpty(txtCodCliente.Text))
		{
			pedidoEletronicoMO.CODIGO_CLIENTE = Convert.ToInt32(txtCodCliente.Text);
		}
		if (!string.IsNullOrEmpty(txtNroPedidoEle.Text))
		{
			pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO = Convert.ToInt32(txtNroPedidoEle.Text);
		}
		if (cbxEmrpesas.SelectedValue != null)
		{
			pedidoEletronicoMO.CODIGO_EMPRESA_ELETRONICO = (int)cbxEmrpesas.SelectedValue;
		}
		List<string> list = new List<string>();
		foreach (DataGridViewRow item in (IEnumerable)dgvOrigemPedido.Rows)
		{
			if (bool.Parse(item.Cells["colExibe"].Value.ToString()))
			{
				list.Add(item.Cells["colOrigemPedido"].Value.ToString());
			}
		}
		pedidoEletronicoMO.ORIGEM_PEDIDO_VENDA_LISTA = list;
		return pedidoEletronicoMO;
	}

	private void TravarLetras(KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	public void IniciarLiberacao(Action acao)
	{
		LimparStatus();
		txtHoraInicio.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
		btnLiberar.Enabled = false;
		btnLiberarMultiThread.Enabled = false;
		List<ParametrosLiberarPedidoEletronicoVO> list = ObterPedidosParaLiberar();
		lblQtdePedidosSelecionados.Text = list.Count.ToString();
		Task task = Task.Factory.StartNew(delegate
		{
			acao();
		});
		task.ContinueWith(delegate
		{
			Invoke((MethodInvoker)delegate
			{
				btnLiberar.Enabled = !chkTimerLibera.Checked;
				btnLiberarMultiThread.Enabled = !chkTimerLibera.Checked;
				txtHoraFim.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
			});
		});
	}

	private void IniciarMultiplasLiberacoes()
	{
		List<ParametrosLiberarPedidoEletronicoVO> pendentes = ObterPedidosParaLiberar();
		IniciarLiberacao(delegate
		{
			LiberarMultiThread(pendentes);
		});
	}

	private void LiberarMultiThread(object Pedidos)
	{
		List<ParametrosLiberarPedidoEletronicoVO> list = (List<ParametrosLiberarPedidoEletronicoVO>)Pedidos;
		ILiberarMultiplosPedidosEletronicosBLL liberarMultiplosPedidosEletronicosBLL = BusinessFactory.GetLiberarMultiplosPedidosEletronicosBLL();
		liberarMultiplosPedidosEletronicosBLL.EventRetornoMensagem += Liberar_EventRetornoMensagem;
		foreach (ParametrosLiberarPedidoEletronicoVO item in list)
		{
			double labelQtdeProcess = list.IndexOf(item) + 1;
			string pkPed = $"{item.CODIGO_EMPRESA_ELETRONICO}.{item.NUMERO_PEDIDO_ELETRONICO}.{item.NUMERO_SEQ_PEDIDO}";
			SetStatusPedido(pkPed, "PROCESSANDO", "");
			SetLabelQtdeProcess(labelQtdeProcess);
		}
		List<RetornoLiberarPedidoEletronicoVO> list2 = liberarMultiplosPedidosEletronicosBLL.ExecutarMultiplosPedidos(list);
		List<RetornoLiberarPedidoEletronicoVO> list3 = list2.FindAll((RetornoLiberarPedidoEletronicoVO x) => x.RESULTADO_PROCESSO != ResultadoProcessoEnum.SUCESSO);
		foreach (RetornoLiberarPedidoEletronicoVO item2 in list2)
		{
			ParametrosLiberarPedidoEletronicoVO pARAMETRO_LIBERACAO = item2.PARAMETRO_LIBERACAO;
			double progressBar = list3.IndexOf(item2) + 1;
			string pkPed2 = $"{pARAMETRO_LIBERACAO.CODIGO_EMPRESA_ELETRONICO}.{pARAMETRO_LIBERACAO.NUMERO_PEDIDO_ELETRONICO}.{pARAMETRO_LIBERACAO.NUMERO_SEQ_PEDIDO}";
			SetStatusPedido(pkPed2, item2.RESULTADO_PROCESSO.ToString(), item2.MENSAGEM_VALIDACAO);
			SetProgressBar(progressBar);
		}
	}

	private List<ParametrosLiberarPedidoEletronicoVO> ObterPedidosParaLiberar()
	{
		List<ParametrosLiberarPedidoEletronicoVO> list = new List<ParametrosLiberarPedidoEletronicoVO>();
		foreach (DataGridViewRow item in (IEnumerable)dgvPedidoEletronicos.Rows)
		{
			if (item.Selected)
			{
				int nUMERO_PEDIDO_ELETRONICO = Convert.ToInt32(item.Cells[1].Value);
				ParametrosLiberarPedidoEletronicoVO parametrosLiberarPedidoEletronicoVO = new ParametrosLiberarPedidoEletronicoVO();
				parametrosLiberarPedidoEletronicoVO.NUMERO_PEDIDO_ELETRONICO = nUMERO_PEDIDO_ELETRONICO;
				parametrosLiberarPedidoEletronicoVO.CODIGO_EMPRESA_ELETRONICO = (int)cbxEmrpesas.SelectedValue;
				parametrosLiberarPedidoEletronicoVO.NUMERO_SEQ_PEDIDO = 1;
				parametrosLiberarPedidoEletronicoVO.CODIGO_USUARIO = "SUPER";
				parametrosLiberarPedidoEletronicoVO.NOME_PROGRAMA = "TARGET VENDAS";
				list.Add(parametrosLiberarPedidoEletronicoVO);
			}
		}
		return list;
	}

	private void IniciarLiberacao(object param)
	{
		try
		{
			List<ParametrosLiberarPedidoEletronicoVO> list = (List<ParametrosLiberarPedidoEletronicoVO>)param;
			Liberar = BusinessFactory.GetLiberarPedidoEletronicoBLL();
			Liberar.EventRetornoMensagem += Liberar_EventRetornoMensagem;
			for (int i = 0; i < list.Count; i++)
			{
				ParametrosLiberarPedidoEletronicoVO parametrosLiberarPedidoEletronicoVO = list[i];
				double num = i + 1;
				string pkPed = $"{parametrosLiberarPedidoEletronicoVO.CODIGO_EMPRESA_ELETRONICO}.{parametrosLiberarPedidoEletronicoVO.NUMERO_PEDIDO_ELETRONICO}.{parametrosLiberarPedidoEletronicoVO.NUMERO_SEQ_PEDIDO}";
				SetStatusPedido(pkPed, "PROCESSANDO", "");
				SetLabelQtdeProcess(num);
				RetornoLiberarPedidoEletronicoVO retornoLiberarPedidoEletronicoVO = ProcessarLiberacao(parametrosLiberarPedidoEletronicoVO);
				SetStatusPedido(pkPed, retornoLiberarPedidoEletronicoVO.RESULTADO_PROCESSO.ToString(), retornoLiberarPedidoEletronicoVO.MENSAGEM_VALIDACAO);
				SetProgressBar(num);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Erro: " + ex.Message);
		}
	}

	private void SetLabelQtdeProcess(double QtdeProcessado)
	{
		Invoke((MethodInvoker)delegate
		{
			lblmsgProcessando.Text = $"Processando: {Convert.ToInt32(QtdeProcessado).ToString()}  de {lblQtdePedidosSelecionados.Text}  pedidos";
		});
	}

	private void SetProgressBar(double QtdeProcessado)
	{
		Invoke((MethodInvoker)delegate
		{
			double num = Convert.ToInt32(lblQtdePedidosSelecionados.Text);
			if (num != 0.0)
			{
				double value = QtdeProcessado / num * 100.0;
				pbPedidos.Value = Convert.ToInt32(value);
				lblPercProcessado.Text = $"{pbPedidos.Value} %";
			}
		});
	}

	private void SetStatusPedido(string pkPed, string status, string obs)
	{
		Invoke((MethodInvoker)delegate
		{
			dgvPedidoEletronicos.ClearSelection();
			dgvPedidoEletronicos.Focus();
			for (int i = 0; i < dgvPedidoEletronicos.Rows.Count; i++)
			{
				DataGridViewRow dataGridViewRow = dgvPedidoEletronicos.Rows[i];
				string value = string.Format("{0}.{1}.{2}", dataGridViewRow.Cells["CD_EMP_ELE"].Value, dataGridViewRow.Cells["NU_PED_ELE"].Value, dataGridViewRow.Cells["SEQ_PED_ELE"].Value);
				if (pkPed.Equals(value))
				{
					dgvPedidoEletronicos.Rows[i].Selected = true;
					dgvPedidoEletronicos.CurrentCell = dgvPedidoEletronicos.Rows[i].Cells[0];
					dataGridViewRow.Cells["STATUS"].Value = status;
					dataGridViewRow.Cells["OBS"].Value = obs;
				}
			}
		});
	}

	private RetornoLiberarPedidoEletronicoVO ProcessarLiberacao(object pedidosParaLiberar)
	{
		try
		{
			return Liberar.Executar((ParametrosLiberarPedidoEletronicoVO)pedidosParaLiberar);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog("Erro ao liberar pedido EfetuarLiberacao(...)", ex);
			throw;
		}
	}

	private void ProcessarMultiplaLiberacoes(object pedidosParaLiberar)
	{
		try
		{
			Liberar.Executar((ParametrosLiberarPedidoEletronicoVO)pedidosParaLiberar);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog("Erro ao liberar pedido EfetuarLiberacao(...)", ex);
		}
	}

	public void Liberar_EventRetornoMensagem(string message)
	{
	}

	private void FrmVendas_Load(object sender, EventArgs e)
	{
		LimparTela();
	}

	private void btnLimpar_Click(object sender, EventArgs e)
	{
		LimparTela();
	}

	private void btnBuscar_Click(object sender, EventArgs e)
	{
		BuscarPedidosEletronicos();
	}

	private void txtNroPedidoEle_KeyPress(object sender, KeyPressEventArgs e)
	{
		TravarLetras(e);
	}

	private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
	{
		TravarLetras(e);
	}

	private void btnLiberar_Click(object sender, EventArgs e)
	{
		List<ParametrosLiberarPedidoEletronicoVO> pendentes = ObterPedidosParaLiberar();
		IniciarLiberacao(delegate
		{
			IniciarLiberacao(pendentes);
		});
	}

	private void btnLiberarMultiThread_Click(object sender, EventArgs e)
	{
		txtHoraInicio.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
		IniciarMultiplasLiberacoes();
	}

	private void chkTimerLibera_CheckedChanged(object sender, EventArgs e)
	{
		cbxEmrpesas.Enabled = !chkTimerLibera.Checked;
		txtNroPedidoEle.Enabled = !chkTimerLibera.Checked;
		txtCodCliente.Enabled = !chkTimerLibera.Checked;
		chkLiberaAuto.Enabled = !chkTimerLibera.Checked;
		dgvOrigemPedido.Enabled = !chkTimerLibera.Checked;
		btnBuscar.Enabled = !chkTimerLibera.Checked;
		btnLimpar.Enabled = !chkTimerLibera.Checked;
		dgvPedidoEletronicos.Enabled = !chkTimerLibera.Checked;
		btnLiberar.Enabled = !chkTimerLibera.Checked;
		btnLiberarMultiThread.Enabled = !chkTimerLibera.Checked;
		tmrLiberaAuto.Enabled = chkTimerLibera.Checked;
	}

	private void tmrLiberaAuto_Tick(object sender, EventArgs e)
	{
		tmrLiberaAuto.Enabled = false;
		lblmsgProcessando.Text = "Buscando...";
		btnBuscar_Click(sender, e);
		if (dgvPedidoEletronicos.Rows.Count > 0)
		{
			dgvPedidoEletronicos.SelectAll();
			btnLiberar_Click(sender, e);
			lblmsgProcessando.Text = "Finalizado";
		}
		lblmsgProcessando.Text = "";
		tmrLiberaAuto.Enabled = true;
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
		this.components = new System.ComponentModel.Container();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Target.Venda.View.FrmVendas));
		this.grpFiltros = new System.Windows.Forms.GroupBox();
		this.chkTimerLibera = new System.Windows.Forms.CheckBox();
		this.label2 = new System.Windows.Forms.Label();
		this.dgvOrigemPedido = new System.Windows.Forms.DataGridView();
		this.colOrigemPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colExibe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.lblEmpresa = new System.Windows.Forms.Label();
		this.cbxEmrpesas = new System.Windows.Forms.ComboBox();
		this.chkLiberaAuto = new System.Windows.Forms.CheckBox();
		this.btnLimpar = new System.Windows.Forms.Button();
		this.btnBuscar = new System.Windows.Forms.Button();
		this.txtCodCliente = new System.Windows.Forms.TextBox();
		this.lblCliente = new System.Windows.Forms.Label();
		this.txtNroPedidoEle = new System.Windows.Forms.TextBox();
		this.lblNroPedidoEle = new System.Windows.Forms.Label();
		this.txtHoraFim = new System.Windows.Forms.MaskedTextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.txtHoraInicio = new System.Windows.Forms.MaskedTextBox();
		this.lblInicio = new System.Windows.Forms.Label();
		this.dgvPedidoEletronicos = new System.Windows.Forms.DataGridView();
		this.TIPO_INTEGRACAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.NU_PED_ELE = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.CD_EMP_ELE = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.SEQ_PED_ELE = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DATA_PEDIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.CODIGO_CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.NOME_CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.VALOR_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.VALOR_TOTAL_COM_DESCONTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.TOTAL_ITENS = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.OBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.lblPercProcessado = new System.Windows.Forms.Label();
		this.pbPedidos = new System.Windows.Forms.ProgressBar();
		this.lblQtdePedidosSelecionados = new System.Windows.Forms.Label();
		this.lblmsgProcessando = new System.Windows.Forms.Label();
		this.lblQtdePedidos = new System.Windows.Forms.Label();
		this.lblTotalPedidos = new System.Windows.Forms.Label();
		this.btnLiberarMultiThread = new System.Windows.Forms.Button();
		this.btnLiberar = new System.Windows.Forms.Button();
		this.tmrLiberaAuto = new System.Windows.Forms.Timer(this.components);
		this.grpFiltros.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgvOrigemPedido).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgvPedidoEletronicos).BeginInit();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.grpFiltros.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.grpFiltros.Controls.Add(this.chkTimerLibera);
		this.grpFiltros.Controls.Add(this.label2);
		this.grpFiltros.Controls.Add(this.dgvOrigemPedido);
		this.grpFiltros.Controls.Add(this.lblEmpresa);
		this.grpFiltros.Controls.Add(this.cbxEmrpesas);
		this.grpFiltros.Controls.Add(this.chkLiberaAuto);
		this.grpFiltros.Controls.Add(this.btnLimpar);
		this.grpFiltros.Controls.Add(this.btnBuscar);
		this.grpFiltros.Controls.Add(this.txtCodCliente);
		this.grpFiltros.Controls.Add(this.lblCliente);
		this.grpFiltros.Controls.Add(this.txtNroPedidoEle);
		this.grpFiltros.Controls.Add(this.lblNroPedidoEle);
		this.grpFiltros.Location = new System.Drawing.Point(12, 12);
		this.grpFiltros.Name = "grpFiltros";
		this.grpFiltros.Size = new System.Drawing.Size(1064, 166);
		this.grpFiltros.TabIndex = 0;
		this.grpFiltros.TabStop = false;
		this.grpFiltros.Text = "Filtros";
		this.chkTimerLibera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.chkTimerLibera.AutoSize = true;
		this.chkTimerLibera.Location = new System.Drawing.Point(945, 143);
		this.chkTimerLibera.Name = "chkTimerLibera";
		this.chkTimerLibera.Size = new System.Drawing.Size(109, 17);
		this.chkTimerLibera.TabIndex = 11;
		this.chkTimerLibera.Text = "Timer Libera Auto";
		this.chkTimerLibera.UseVisualStyleBackColor = true;
		this.chkTimerLibera.CheckedChanged += new System.EventHandler(chkTimerLibera_CheckedChanged);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(340, 15);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(76, 13);
		this.label2.TabIndex = 10;
		this.label2.Text = "Origem Pedido";
		this.dgvOrigemPedido.AllowUserToAddRows = false;
		this.dgvOrigemPedido.AllowUserToDeleteRows = false;
		this.dgvOrigemPedido.AllowUserToResizeColumns = false;
		this.dgvOrigemPedido.AllowUserToResizeRows = false;
		this.dgvOrigemPedido.BackgroundColor = System.Drawing.SystemColors.Window;
		this.dgvOrigemPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvOrigemPedido.Columns.AddRange(this.colOrigemPedido, this.colDescricao, this.colExibe);
		this.dgvOrigemPedido.Location = new System.Drawing.Point(343, 31);
		this.dgvOrigemPedido.MultiSelect = false;
		this.dgvOrigemPedido.Name = "dgvOrigemPedido";
		this.dgvOrigemPedido.RowHeadersVisible = false;
		this.dgvOrigemPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvOrigemPedido.Size = new System.Drawing.Size(282, 131);
		this.dgvOrigemPedido.TabIndex = 9;
		this.colOrigemPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
		this.colOrigemPedido.HeaderText = "Sigla";
		this.colOrigemPedido.Name = "colOrigemPedido";
		this.colOrigemPedido.Width = 55;
		this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.colDescricao.HeaderText = "Descrição";
		this.colDescricao.Name = "colDescricao";
		this.colExibe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
		this.colExibe.HeaderText = "Exibe";
		this.colExibe.Name = "colExibe";
		this.colExibe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.colExibe.Width = 39;
		this.lblEmpresa.AutoSize = true;
		this.lblEmpresa.Location = new System.Drawing.Point(6, 15);
		this.lblEmpresa.Name = "lblEmpresa";
		this.lblEmpresa.Size = new System.Drawing.Size(73, 13);
		this.lblEmpresa.TabIndex = 8;
		this.lblEmpresa.Text = "Cod. Empresa";
		this.cbxEmrpesas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbxEmrpesas.FormattingEnabled = true;
		this.cbxEmrpesas.Location = new System.Drawing.Point(9, 31);
		this.cbxEmrpesas.Name = "cbxEmrpesas";
		this.cbxEmrpesas.Size = new System.Drawing.Size(201, 21);
		this.cbxEmrpesas.TabIndex = 7;
		this.chkLiberaAuto.AutoSize = true;
		this.chkLiberaAuto.Location = new System.Drawing.Point(226, 33);
		this.chkLiberaAuto.Name = "chkLiberaAuto";
		this.chkLiberaAuto.Size = new System.Drawing.Size(111, 17);
		this.chkLiberaAuto.TabIndex = 6;
		this.chkLiberaAuto.Text = "Libera Automático";
		this.chkLiberaAuto.UseVisualStyleBackColor = true;
		this.btnLimpar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnLimpar.Location = new System.Drawing.Point(979, 38);
		this.btnLimpar.Name = "btnLimpar";
		this.btnLimpar.Size = new System.Drawing.Size(75, 23);
		this.btnLimpar.TabIndex = 5;
		this.btnLimpar.Text = "Limpar";
		this.btnLimpar.UseVisualStyleBackColor = true;
		this.btnLimpar.Click += new System.EventHandler(btnLimpar_Click);
		this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnBuscar.Location = new System.Drawing.Point(979, 11);
		this.btnBuscar.Name = "btnBuscar";
		this.btnBuscar.Size = new System.Drawing.Size(75, 23);
		this.btnBuscar.TabIndex = 4;
		this.btnBuscar.Text = "Buscar";
		this.btnBuscar.UseVisualStyleBackColor = true;
		this.btnBuscar.Click += new System.EventHandler(btnBuscar_Click);
		this.txtCodCliente.Location = new System.Drawing.Point(142, 75);
		this.txtCodCliente.Name = "txtCodCliente";
		this.txtCodCliente.Size = new System.Drawing.Size(110, 20);
		this.txtCodCliente.TabIndex = 3;
		this.txtCodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCodCliente_KeyPress);
		this.lblCliente.AutoSize = true;
		this.lblCliente.Location = new System.Drawing.Point(140, 58);
		this.lblCliente.Name = "lblCliente";
		this.lblCliente.Size = new System.Drawing.Size(64, 13);
		this.lblCliente.TabIndex = 2;
		this.lblCliente.Text = "Cod. Cliente";
		this.txtNroPedidoEle.Location = new System.Drawing.Point(9, 76);
		this.txtNroPedidoEle.Name = "txtNroPedidoEle";
		this.txtNroPedidoEle.Size = new System.Drawing.Size(110, 20);
		this.txtNroPedidoEle.TabIndex = 1;
		this.txtNroPedidoEle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNroPedidoEle_KeyPress);
		this.lblNroPedidoEle.AutoSize = true;
		this.lblNroPedidoEle.Location = new System.Drawing.Point(6, 58);
		this.lblNroPedidoEle.Name = "lblNroPedidoEle";
		this.lblNroPedidoEle.Size = new System.Drawing.Size(113, 13);
		this.lblNroPedidoEle.TabIndex = 0;
		this.lblNroPedidoEle.Text = "Nro. Pedido Eletrônico";
		this.txtHoraFim.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.txtHoraFim.Location = new System.Drawing.Point(723, 42);
		this.txtHoraFim.Mask = "00/00/0000 90:00:00";
		this.txtHoraFim.Name = "txtHoraFim";
		this.txtHoraFim.ReadOnly = true;
		this.txtHoraFim.Size = new System.Drawing.Size(116, 20);
		this.txtHoraFim.TabIndex = 10;
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(694, 45);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(26, 13);
		this.label1.TabIndex = 9;
		this.label1.Text = "Fim:";
		this.txtHoraInicio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.txtHoraInicio.Location = new System.Drawing.Point(723, 17);
		this.txtHoraInicio.Mask = "00/00/0000 90:00:00";
		this.txtHoraInicio.Name = "txtHoraInicio";
		this.txtHoraInicio.ReadOnly = true;
		this.txtHoraInicio.Size = new System.Drawing.Size(116, 20);
		this.txtHoraInicio.TabIndex = 8;
		this.lblInicio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.lblInicio.AutoSize = true;
		this.lblInicio.Location = new System.Drawing.Point(685, 20);
		this.lblInicio.Name = "lblInicio";
		this.lblInicio.Size = new System.Drawing.Size(35, 13);
		this.lblInicio.TabIndex = 7;
		this.lblInicio.Text = "Inicio:";
		this.dgvPedidoEletronicos.AllowUserToAddRows = false;
		this.dgvPedidoEletronicos.AllowUserToDeleteRows = false;
		this.dgvPedidoEletronicos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dgvPedidoEletronicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvPedidoEletronicos.Columns.AddRange(this.TIPO_INTEGRACAO, this.NU_PED_ELE, this.CD_EMP_ELE, this.SEQ_PED_ELE, this.DATA_PEDIDO, this.CODIGO_CLIENTE, this.NOME_CLIENTE, this.VALOR_TOTAL, this.VALOR_TOTAL_COM_DESCONTO, this.TOTAL_ITENS, this.STATUS, this.OBS);
		this.dgvPedidoEletronicos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		this.dgvPedidoEletronicos.Location = new System.Drawing.Point(12, 184);
		this.dgvPedidoEletronicos.Name = "dgvPedidoEletronicos";
		this.dgvPedidoEletronicos.RowHeadersVisible = false;
		this.dgvPedidoEletronicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvPedidoEletronicos.Size = new System.Drawing.Size(1064, 302);
		this.dgvPedidoEletronicos.TabIndex = 2;
		this.TIPO_INTEGRACAO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		this.TIPO_INTEGRACAO.HeaderText = "Tipo Integração";
		this.TIPO_INTEGRACAO.Name = "TIPO_INTEGRACAO";
		this.TIPO_INTEGRACAO.ReadOnly = true;
		this.TIPO_INTEGRACAO.Width = 110;
		this.NU_PED_ELE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
		this.NU_PED_ELE.DefaultCellStyle = dataGridViewCellStyle;
		this.NU_PED_ELE.HeaderText = "Nro. Ped. Eletro.";
		this.NU_PED_ELE.Name = "NU_PED_ELE";
		this.NU_PED_ELE.Width = 110;
		this.CD_EMP_ELE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		this.CD_EMP_ELE.HeaderText = "Empresa";
		this.CD_EMP_ELE.Name = "CD_EMP_ELE";
		this.CD_EMP_ELE.Visible = false;
		this.SEQ_PED_ELE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		this.SEQ_PED_ELE.HeaderText = "Seq Ped";
		this.SEQ_PED_ELE.Name = "SEQ_PED_ELE";
		this.SEQ_PED_ELE.Visible = false;
		this.DATA_PEDIDO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle2.Format = "d";
		dataGridViewCellStyle2.NullValue = null;
		this.DATA_PEDIDO.DefaultCellStyle = dataGridViewCellStyle2;
		this.DATA_PEDIDO.HeaderText = "Dt. Pedido";
		this.DATA_PEDIDO.Name = "DATA_PEDIDO";
		this.DATA_PEDIDO.Width = 80;
		this.CODIGO_CLIENTE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
		this.CODIGO_CLIENTE.DefaultCellStyle = dataGridViewCellStyle3;
		this.CODIGO_CLIENTE.HeaderText = "Cód. Cliente";
		this.CODIGO_CLIENTE.Name = "CODIGO_CLIENTE";
		this.CODIGO_CLIENTE.Width = 90;
		this.NOME_CLIENTE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		this.NOME_CLIENTE.HeaderText = "Cliente";
		this.NOME_CLIENTE.Name = "NOME_CLIENTE";
		this.NOME_CLIENTE.Width = 140;
		this.VALOR_TOTAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
		dataGridViewCellStyle4.Format = "C2";
		dataGridViewCellStyle4.NullValue = null;
		this.VALOR_TOTAL.DefaultCellStyle = dataGridViewCellStyle4;
		this.VALOR_TOTAL.HeaderText = "Valor Total";
		this.VALOR_TOTAL.Name = "VALOR_TOTAL";
		this.VALOR_TOTAL.Width = 90;
		this.VALOR_TOTAL_COM_DESCONTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
		dataGridViewCellStyle5.Format = "C2";
		dataGridViewCellStyle5.NullValue = null;
		this.VALOR_TOTAL_COM_DESCONTO.DefaultCellStyle = dataGridViewCellStyle5;
		this.VALOR_TOTAL_COM_DESCONTO.HeaderText = "Valor com Desc.";
		this.VALOR_TOTAL_COM_DESCONTO.Name = "VALOR_TOTAL_COM_DESCONTO";
		this.VALOR_TOTAL_COM_DESCONTO.Width = 110;
		this.TOTAL_ITENS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
		this.TOTAL_ITENS.DefaultCellStyle = dataGridViewCellStyle6;
		this.TOTAL_ITENS.HeaderText = "Total Itens";
		this.TOTAL_ITENS.Name = "TOTAL_ITENS";
		this.TOTAL_ITENS.Width = 80;
		this.STATUS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		this.STATUS.HeaderText = "Status";
		this.STATUS.Name = "STATUS";
		this.STATUS.ReadOnly = true;
		this.OBS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.OBS.HeaderText = "Obs";
		this.OBS.Name = "OBS";
		this.OBS.ReadOnly = true;
		this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox1.Controls.Add(this.lblPercProcessado);
		this.groupBox1.Controls.Add(this.pbPedidos);
		this.groupBox1.Controls.Add(this.lblQtdePedidosSelecionados);
		this.groupBox1.Controls.Add(this.lblmsgProcessando);
		this.groupBox1.Controls.Add(this.txtHoraInicio);
		this.groupBox1.Controls.Add(this.txtHoraFim);
		this.groupBox1.Controls.Add(this.lblInicio);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(10, 492);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(850, 72);
		this.groupBox1.TabIndex = 9;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Status";
		this.lblPercProcessado.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.lblPercProcessado.AutoSize = true;
		this.lblPercProcessado.Location = new System.Drawing.Point(641, 16);
		this.lblPercProcessado.Margin = new System.Windows.Forms.Padding(0);
		this.lblPercProcessado.Name = "lblPercProcessado";
		this.lblPercProcessado.Size = new System.Drawing.Size(24, 13);
		this.lblPercProcessado.TabIndex = 19;
		this.lblPercProcessado.Text = "0 %";
		this.lblPercProcessado.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.pbPedidos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pbPedidos.Location = new System.Drawing.Point(9, 34);
		this.pbPedidos.Name = "pbPedidos";
		this.pbPedidos.Size = new System.Drawing.Size(660, 28);
		this.pbPedidos.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
		this.pbPedidos.TabIndex = 18;
		this.lblQtdePedidosSelecionados.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblQtdePedidosSelecionados.AutoSize = true;
		this.lblQtdePedidosSelecionados.Location = new System.Drawing.Point(180, 17);
		this.lblQtdePedidosSelecionados.Name = "lblQtdePedidosSelecionados";
		this.lblQtdePedidosSelecionados.Size = new System.Drawing.Size(86, 13);
		this.lblQtdePedidosSelecionados.TabIndex = 17;
		this.lblQtdePedidosSelecionados.Text = "_totalPedidosSel";
		this.lblQtdePedidosSelecionados.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.lblQtdePedidosSelecionados.Visible = false;
		this.lblmsgProcessando.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblmsgProcessando.AutoSize = true;
		this.lblmsgProcessando.Location = new System.Drawing.Point(8, 17);
		this.lblmsgProcessando.Name = "lblmsgProcessando";
		this.lblmsgProcessando.Size = new System.Drawing.Size(94, 13);
		this.lblmsgProcessando.TabIndex = 14;
		this.lblmsgProcessando.Text = "_msgProcessando";
		this.lblQtdePedidos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.lblQtdePedidos.AutoSize = true;
		this.lblQtdePedidos.Location = new System.Drawing.Point(1054, 498);
		this.lblQtdePedidos.Name = "lblQtdePedidos";
		this.lblQtdePedidos.Size = new System.Drawing.Size(13, 13);
		this.lblQtdePedidos.TabIndex = 11;
		this.lblQtdePedidos.Text = "0";
		this.lblTotalPedidos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.lblTotalPedidos.AutoSize = true;
		this.lblTotalPedidos.Location = new System.Drawing.Point(975, 498);
		this.lblTotalPedidos.Name = "lblTotalPedidos";
		this.lblTotalPedidos.Size = new System.Drawing.Size(75, 13);
		this.lblTotalPedidos.TabIndex = 10;
		this.lblTotalPedidos.Text = "Total Pedidos:";
		this.btnLiberarMultiThread.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnLiberarMultiThread.Location = new System.Drawing.Point(991, 524);
		this.btnLiberarMultiThread.Name = "btnLiberarMultiThread";
		this.btnLiberarMultiThread.Size = new System.Drawing.Size(84, 35);
		this.btnLiberarMultiThread.TabIndex = 13;
		this.btnLiberarMultiThread.Text = "Liberar MultiThread";
		this.btnLiberarMultiThread.UseVisualStyleBackColor = true;
		this.btnLiberarMultiThread.Click += new System.EventHandler(btnLiberarMultiThread_Click);
		this.btnLiberar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnLiberar.Location = new System.Drawing.Point(906, 525);
		this.btnLiberar.Name = "btnLiberar";
		this.btnLiberar.Size = new System.Drawing.Size(78, 35);
		this.btnLiberar.TabIndex = 12;
		this.btnLiberar.Text = "Liberar";
		this.btnLiberar.UseVisualStyleBackColor = true;
		this.btnLiberar.Click += new System.EventHandler(btnLiberar_Click);
		this.tmrLiberaAuto.Interval = 60000;
		this.tmrLiberaAuto.Tick += new System.EventHandler(tmrLiberaAuto_Tick);
		base.AcceptButton = this.btnBuscar;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1088, 572);
		base.Controls.Add(this.btnLiberarMultiThread);
		base.Controls.Add(this.btnLiberar);
		base.Controls.Add(this.lblQtdePedidos);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.dgvPedidoEletronicos);
		base.Controls.Add(this.lblTotalPedidos);
		base.Controls.Add(this.grpFiltros);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "FrmVendas";
		this.Text = "Target Vendas Eletronicas";
		base.Load += new System.EventHandler(FrmVendas_Load);
		this.grpFiltros.ResumeLayout(false);
		this.grpFiltros.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dgvOrigemPedido).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgvPedidoEletronicos).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
