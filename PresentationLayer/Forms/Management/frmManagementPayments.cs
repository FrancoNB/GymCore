using BusinessLayer.Cache;
using BusinessLayer.Models;
using BusinessLayer.Services;
using BusinessLayer.Services.Payments;
using BusinessLayer.Services.SubscriptionsStrategy;
using BusinessLayer.ValueObjects;
using PresentationLayer.Forms.Lists;
using PresentationLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms.Management
{
    public partial class frmManagementPayments : Form, ISubscriber<ClientsModel>, ISubscriber<PaymentsModel>
    {
        private static frmManagementPayments instance;

        private static readonly object _lock = new object();
        public static frmManagementPayments GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmManagementPayments();
                }
            }

            return instance;
        }

        private string Operation;

        private readonly PaymentsModel paymentsWorkingModel;
        private Service<PaymentsModel> paymentService;

        private IEnumerable<ClientsModel> clientsList;
        private IEnumerable<PaymentsModel> paymentsList;

        private frmManagementPayments()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            paymentsWorkingModel = new PaymentsModel();
            paymentService = new Service<PaymentsModel>();
        }

        private void ClearData()
        {
            txtTicketCode.Clear();
            txtAmount.Clear();
            cbxPaymentMethod.SelectedItem = null;
            txtObservations.Clear();
        }

        private void ClearClientData()
        {
            dgvPaymentsClientList.Rows.Clear();

            txtClientMail.Clear();
            txtClientObservations.Clear();
            txtClientPhone.Clear();
            txtClientResidence.Clear();
        }

        private void SetControlsDefaultState()
        {
            txtClient.Clear();

            ClearData();

            ControlsUtilities.DisableContainerControls(pnlData);
            ControlsUtilities.DisableContainerControls(pnlList);

            txtClient.Enabled = true;

            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            txtClient.Select();
        }

        private void SetControlsClientEnterState()
        {
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            ControlsUtilities.EnabledContainerControls(pnlList);
            ControlsUtilities.DisableContainerControls(pnlData);

            txtClient.Enabled = true;

            ClearData();
        }

        private void SetControlsClientEmptyState()
        {
            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            ControlsUtilities.DisableContainerControls(pnlList);
            ControlsUtilities.DisableContainerControls(pnlData);

            txtClient.Enabled = true;
        }

        private void SetControlsActiveState()
        {
            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnClose.Enabled = false;
            btnCancel.Enabled = true;

            ControlsUtilities.DisableContainerControls(pnlList);

            cbxPaymentMethod.Enabled = true;
            txtAmount.Enabled = true;
            txtObservations.Enabled = true;

            txtClient.Enabled = false;

            cbxPaymentMethod.Select();
        }

        private void ClearSelectionDgv()
        {
            ClearData();

            dgvPaymentsClientList.CurrentCell = null;
            dgvPaymentsClientList.ClearSelection();
        }

        private void LoadDgvPaymentsClientListList()
        {
            dgvPaymentsClientList.Rows.Clear();

            if (paymentsWorkingModel.IdClients > 0)
            {
                var paymentsClientsList = paymentsList.ToList().FindAll(payment => payment.IdClients == paymentsWorkingModel.IdClients);

                foreach (PaymentsModel payment in paymentsClientsList)
                {
                    dgvPaymentsClientList.Rows.Add(payment.IdPayments, payment.DateString, payment.PaymentMethodString, string.Format("$ {0:#,##0.00}", payment.Amount));
                }
            }

            ClearSelectionDgv();
        }

        private void frmManagementPayments_Load(object sender, EventArgs e)
        {
            cbxPaymentMethod.Items.Clear();
            cbxPaymentMethod.Items.Add("Efectivo");
            cbxPaymentMethod.Items.Add("Tarjeta de Credito");
            cbxPaymentMethod.Items.Add("Tarjeta de Debito");
            cbxPaymentMethod.Items.Add("Cheque");
            cbxPaymentMethod.Items.Add("Otro");

            dgvPaymentsClientList.Columns.Clear();
            dgvPaymentsClientList.Columns.Add("idPayment", "ID PAGO");
            dgvPaymentsClientList.Columns.Add("Date", "FECHA");
            dgvPaymentsClientList.Columns.Add("PaymentMethod", "METODO DE PAGO");
            dgvPaymentsClientList.Columns.Add("Amount", "MONTO");

            dgvPaymentsClientList.Columns["idPayment"].Visible = false;

            dgvPaymentsClientList.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPaymentsClientList.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvPaymentsClientList.Columns["Date"].Width = 100;
            dgvPaymentsClientList.Columns["Amount"].Width = 120;

            dgvPaymentsClientList.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPaymentsClientList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ClientsCache.GetInstance().Attach(this);
            PaymentsCache.GetInstance().Attach(this);

            SetControlsDefaultState();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            paymentsWorkingModel.Amount = FormatUtilities.NumbersOnly(txtAmount.Text);
        }

        private void txtAmount_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Text = string.Format("$ {0:#,##0.00}", FormatUtilities.NumbersOnly(txtAmount.Text));
            }
        }

        private void txtObservations_TextChanged(object sender, EventArgs e)
        {
            paymentsWorkingModel.Observations = txtObservations.Text;
        }

        private void cbxPaymentMethod_TextChanged(object sender, EventArgs e)
        {
            paymentsWorkingModel.PaymentMethodString = cbxPaymentMethod.Text;
        }

        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            var selectedClient = clientsList.ToList().Find(client => txtClient.Text == client.Name + " " + client.Surname + " [" + client.IdClients.ToString() + "]");

            if (selectedClient != null)
            {
                txtClientObservations.Text = selectedClient.Observations;
                txtClientResidence.Text = selectedClient.Locality + " - " + selectedClient.Address;
                txtClientPhone.Text = selectedClient.Phone;
                txtClientMail.Text = selectedClient.Mail;

                paymentsWorkingModel.IdClients = selectedClient.IdClients;

                LoadDgvPaymentsClientListList();

                SetControlsClientEnterState();
            }
            else
            {
                paymentsWorkingModel.IdClients = 0;

                ClearClientData();
                SetControlsClientEmptyState();
            }
        }

        private void txtClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (string.IsNullOrWhiteSpace(txtClient.Text))
                {
                    frmClientsList.GetInstance().ShowDialog(this);

                    var selectedClient = frmClientsList.GetInstance().SelectedClient;

                    if (selectedClient != null)
                    {
                        txtClient.Text = selectedClient.Name + " " + selectedClient.Surname + " [" + selectedClient.IdClients + "]";
                    }

                    txtClient.SelectionStart = 0;
                    txtClient.SelectionLength = txtClient.TextLength;

                    e.Handled = true;
                }
            }
        }

        private void dgvPaymentsClientList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectedPayment = paymentsList.ToList().Find(payment => payment.IdPayments == Convert.ToInt32(dgvPaymentsClientList.CurrentRow.Cells["idPayment"].Value));

                paymentsWorkingModel.IdPayments = selectedPayment.IdPayments;
                paymentsWorkingModel.IdCurrentAccounts = selectedPayment.IdCurrentAccounts;
                paymentsWorkingModel.TicketCode = selectedPayment.TicketCode;

                txtTicketCode.Text = selectedPayment.TicketCode.Value;
                cbxPaymentMethod.Text = selectedPayment.PaymentMethodString;
                txtAmount.Text = string.Format("$ {0:#,##0.00}", selectedPayment.Amount);
                txtObservations.Text = selectedPayment.Observations;

                btnUpdate.Select();
            }
            else
            {
                ClearSelectionDgv();
            }
        }

        private void dgvPaymentsClientList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvPaymentsClientList.HitTest(e.X, e.Y).Equals(DataGridView.HitTestInfo.Nowhere))
                {
                    ClearSelectionDgv();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            paymentService.SetStrategy(new PaymentsInsertService());
            Operation = "New";

            SetControlsActiveState();
            ClearSelectionDgv();

            paymentsWorkingModel.TicketCode = Tickets.Create("PAG", paymentsWorkingModel.IdClients);

            txtTicketCode.Text = paymentsWorkingModel.TicketCode.Value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPaymentsClientList.CurrentCell != null)
            {
                paymentService.SetStrategy(new PaymentsUpdateService());
                Operation = "Update";

                SetControlsActiveState();
            }
            else
            {
                MessageBox.Show("Debes seleccionar el pago que deseas modificar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPaymentsClientList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Eliminar pago ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (confirm == DialogResult.OK)
                {
                    paymentService.SetStrategy(new PaymentsDeleteService());

                    LoadNotification.Show("Eliminando pago...");

                    var acctionResult = await paymentService.SaveChanges(paymentsWorkingModel);

                    LoadNotification.Hide();

                    if (acctionResult.Result)
                    {
                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Select();
                    }
                    else
                    {
                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar el pago que deseas eliminar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string footMsg;
            DialogResult confirm;

            if (Operation == "New")
            {
                confirm = MessageBox.Show("Guardar pago ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Guardando pago...";
            }
            else if (Operation == "Update")
            {
                confirm = MessageBox.Show("Modificar pago ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Modificando pago...";
            }
            else
            {
                MessageBox.Show("No se establecio la operacion a realizar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (confirm == DialogResult.OK)
            {
                LoadNotification.Show(footMsg);

                var acctionResult = await paymentService.SaveChanges(paymentsWorkingModel);

                LoadNotification.Hide();

                if (!acctionResult.Result)
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    cbxPaymentMethod.Select();
                }
                else
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetControlsClientEnterState();
                    btnNew.Select();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControlsClientEnterState();

            txtClient.Enabled = true;
            txtClient.Select();
            txtClient.SelectionStart = 0;
            txtClient.SelectionLength = txtClient.TextLength;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClientsCache.GetInstance().Detach(this);
            PaymentsCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<ClientsModel> resource)
        {
            clientsList = resource;

            txtClient.AutoCompleteCustomSource.Clear();

            foreach (ClientsModel client in clientsList)
            {
                txtClient.AutoCompleteCustomSource.Add(client.Name + " " + client.Surname + " [" + client.IdClients.ToString() + "]");
            }
        }

        public void Update(IEnumerable<PaymentsModel> resource)
        {
            paymentsList = resource;

            LoadDgvPaymentsClientListList();
        }
    }
}
