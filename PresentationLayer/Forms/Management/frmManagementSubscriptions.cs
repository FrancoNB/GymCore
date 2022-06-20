using BusinessLayer.Cache;
using BusinessLayer.Models;
using BusinessLayer.Services;
using BusinessLayer.Services.SubscriptionsStrategy;
using BusinessLayer.ValueObjects;
using PresentationLayer.Forms.Lists;
using PresentationLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Management
{
    public partial class frmManagementSubscriptions : Form, ISubscriber<PackagesModel>, ISubscriber<ClientsModel>, ISubscriber<SubscriptionsModel>
    {
        private static frmManagementSubscriptions instance;

        private static readonly object _lock = new object();
        public static frmManagementSubscriptions GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmManagementSubscriptions();
                }
            }

            return instance;
        }

        private readonly SubscriptionsModel subscriptionWorkingModel;
        private readonly Service<SubscriptionsModel> subscriptionsService;

        private IEnumerable<SubscriptionsModel> subscriptionsList;

        private IEnumerable<ClientsModel> clientsList;
        private IEnumerable<PackagesModel> packagesList;

        private frmManagementSubscriptions()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            subscriptionWorkingModel = new SubscriptionsModel();
            subscriptionsService = new Service<SubscriptionsModel>();
        }

        private void ClearClientData()
        {
            dgvSubcriptionsClientList.Rows.Clear();

            txtClientMail.Clear();
            txtClientObservations.Clear();
            txtClientPhone.Clear();
            txtClientResidence.Clear();
        }

        private void ClearPackageData()
        {
            txtExpireDate.Clear();
            txtNumberSessions.Clear();
            txtAvailableDays.Clear();
            txtPrice.Clear();
        }
        private void ClearData()
        {
            txtTicketCode.Clear();
            txtPackage.Clear();
            txtExpireDate.Clear();
            txtObservations.Clear();

            dtpStartDate.MaxDate = DateTime.Now;
            dtpStartDate.Value = dtpStartDate.MaxDate;
        }

        private void SetControlsDefaultState()
        {
            txtClient.Clear();

            ClearData();

            ControlsUtilities.DisableContainerControls(pnlData);
            ControlsUtilities.DisableContainerControls(pnlList);

            txtClient.Enabled = true;

            dtpStartDate.Enabled = false;

            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnInvalidate.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            txtClient.Select();
        }

        private void SetControlsClientEnterState()
        {
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnInvalidate.Enabled = true;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            ControlsUtilities.EnabledContainerControls(pnlList);
            ControlsUtilities.DisableContainerControls(pnlData);

            dtpStartDate.Enabled = false;

            txtClient.Enabled = true;

            ClearData();
        }

        private void SetControlsClientEmptyState()
        {
            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnInvalidate.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            ControlsUtilities.DisableContainerControls(pnlList);
            ControlsUtilities.DisableContainerControls(pnlData);

            dtpStartDate.Enabled = false;

            txtClient.Enabled = true;
        }

        private void SetControlsActiveState()
        {
            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnInvalidate.Enabled = false;
            btnSave.Enabled = true;
            btnClose.Enabled = false;
            btnCancel.Enabled = true;

            ControlsUtilities.DisableContainerControls(pnlList);

            txtPackage.Enabled = true;
            txtObservations.Enabled = true;
            dtpStartDate.Enabled = true;

            txtClient.Enabled = false;

            txtPackage.Select();
        }

        private void ClearSelectionDgv()
        {
            ClearData();

            dgvSubcriptionsClientList.CurrentCell = null;
            dgvSubcriptionsClientList.ClearSelection();
        }

        private void LoadDgvSubcriptionsClientList()
        {
            dgvSubcriptionsClientList.Rows.Clear();

            if (subscriptionWorkingModel.IdClients > 0)
            {
                var subscriptionsClientsList = subscriptionsList.ToList().FindAll(subscription => subscription.IdClients == subscriptionWorkingModel.IdClients && subscription.State == SubscriptionsModel.SubscriptionsStates.Active);

                foreach (SubscriptionsModel subscription in subscriptionsClientsList)
                {
                    dgvSubcriptionsClientList.Rows.Add(subscription.IdSubscriptions, subscription.Package + " (" + subscription.AvailableSessions + " / " + subscription.TotalSessions + ")", subscription.StartDateString, subscription.ExpireDateString);
                }
            }

            ClearSelectionDgv();
        }

        private void frmManagementSubscriptions_Load(object sender, EventArgs e)
        {
            dgvSubcriptionsClientList.Columns.Clear();
            dgvSubcriptionsClientList.Columns.Add("idSubscription", "ID SUBSCRIPCION");
            dgvSubcriptionsClientList.Columns.Add("Package", "PAQUETE");
            dgvSubcriptionsClientList.Columns.Add("StartDate", "INICIO");
            dgvSubcriptionsClientList.Columns.Add("ExpireDate", "VENCIMIENTO");

            dgvSubcriptionsClientList.Columns["idSubscription"].Visible = false;

            dgvSubcriptionsClientList.Columns["StartDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSubcriptionsClientList.Columns["ExpireDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvSubcriptionsClientList.Columns["StartDate"].Width = 100;
            dgvSubcriptionsClientList.Columns["ExpireDate"].Width = 100;

            dgvSubcriptionsClientList.Columns["StartDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSubcriptionsClientList.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            ClientsCache.GetInstance().Attach(this);
            PackagesCache.GetInstance().Attach(this);
            SubscriptionsCache.GetInstance().Attach(this);
            
            SetControlsDefaultState();
        }

        private void txtNumberSessions_TextChanged(object sender, EventArgs e)
        {
            subscriptionWorkingModel.TotalSessions = (int)FormatUtilities.NumbersOnly(txtNumberSessions.Text);
        }

        private void txtAvailableDays_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAvailableDays.Text))
                txtExpireDate.Text = dtpStartDate.Value.AddDays(FormatUtilities.NumbersOnly(txtAvailableDays.Text)).ToString("dd/MM/yyyy");
            else
                txtExpireDate.Clear();
        }

        private void txtExpireDate_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtExpireDate.Text))
                subscriptionWorkingModel.ExpireDate = Convert.ToDateTime(txtExpireDate.Text);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            subscriptionWorkingModel.Price = FormatUtilities.NumbersOnly(txtPrice.Text);
        }

        private void txtObservations_TextChanged(object sender, EventArgs e)
        {
            subscriptionWorkingModel.Observations = txtObservations.Text;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            subscriptionWorkingModel.StartDate = dtpStartDate.Value;

            if (!string.IsNullOrWhiteSpace(txtAvailableDays.Text))
            {
                txtExpireDate.Text = dtpStartDate.Value.AddDays(FormatUtilities.NumbersOnly(txtAvailableDays.Text)).ToString("dd/MM/yyyyy");
            }
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

                subscriptionWorkingModel.IdClients = selectedClient.IdClients;

                LoadDgvSubcriptionsClientList();

                SetControlsClientEnterState();
            }
            else
            {
                subscriptionWorkingModel.IdClients = 0;

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

        private void txtPackage_TextChanged(object sender, EventArgs e)
        {
            var selectedPackage = packagesList.ToList().Find(package => txtPackage.Text == package.Name);

            if (selectedPackage != null)
            {
                txtPackage.Text = selectedPackage.Name;
                txtNumberSessions.Text = string.Format("{0:#,##}", selectedPackage.NumberSessions);
                txtAvailableDays.Text = string.Format("{0:#,##}", selectedPackage.AvailableDays);
                txtPrice.Text = string.Format("$ {0:#,##0.00}", selectedPackage.Price);
            }
            else
            {
                ClearPackageData();
            }

            subscriptionWorkingModel.Package = txtPackage.Text;
        }

        private void txtPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (string.IsNullOrWhiteSpace(txtPackage.Text))
                {
                    frmPackagesList.GetInstance().ShowDialog(this);

                    var selectedPackage = frmPackagesList.GetInstance().SelectedPackage;

                    if (selectedPackage != null)
                    {
                        txtPackage.Text = selectedPackage.Name;
                    }

                    txtPackage.SelectionStart = 0;
                    txtPackage.SelectionLength = txtPackage.TextLength;

                    e.Handled = true;
                }
            }
        }

        private void dgvSubcriptionsClientList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectedSubscription = subscriptionsList.ToList().Find(subscription => subscription.IdSubscriptions == Convert.ToInt32(dgvSubcriptionsClientList.CurrentRow.Cells["idSubscription"].Value));

                subscriptionWorkingModel.IdSubscriptions = selectedSubscription.IdSubscriptions;
                subscriptionWorkingModel.IdCurrentAccounts = selectedSubscription.IdCurrentAccounts;
                subscriptionWorkingModel.TicketCode = selectedSubscription.TicketCode;

                txtPackage.Text = selectedSubscription.Package;
                txtTicketCode.Text = selectedSubscription.TicketCode.Value;
                dtpStartDate.Value = selectedSubscription.StartDate;
                txtObservations.Text = selectedSubscription.Observations;

                btnInvalidate.Select();
            }
            else
            {
                ClearSelectionDgv();
            }
        }

        private void dgvSubcriptionsClientList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvSubcriptionsClientList.HitTest(e.X, e.Y).Equals(DataGridView.HitTestInfo.Nowhere))
                {
                    ClearSelectionDgv();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            subscriptionsService.SetStrategy(new SubscriptionsInsertService());

            SetControlsActiveState();
            ClearSelectionDgv();

            subscriptionWorkingModel.TicketCode = Tickets.Create("SUB", subscriptionWorkingModel.IdClients);

            txtTicketCode.Text = subscriptionWorkingModel.TicketCode.Value;
        }

        private async void btnInvalidate_Click(object sender, EventArgs e)
        {
            if (dgvSubcriptionsClientList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Anular subscripcion ? \n\nAdvertencia: anulando una subscripcion el registro de cuenta corriente correspondiente a la misma sigue vigente.", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (confirm == DialogResult.OK)
                {
                    subscriptionsService.SetStrategy(new SubscriptionsInvalidateService());

                    LoadNotification.Show("Anulando subscripcion...");

                    var acctionResult = await subscriptionsService.SaveChanges(subscriptionWorkingModel);

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
                MessageBox.Show("Debes seleccionar la subscripcion que deseas anular... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSubcriptionsClientList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Eliminar subscripcion ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (confirm == DialogResult.OK)
                {
                    subscriptionsService.SetStrategy(new SubscriptionsDeleteService());

                    LoadNotification.Show("Eliminando subscripcion...");

                    var acctionResult = await subscriptionsService.SaveChanges(subscriptionWorkingModel);

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
                MessageBox.Show("Debes seleccionar la subscripcion que deseas eliminar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Guardar subscripcion ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); ;

            if (confirm == DialogResult.OK)
            {
                LoadNotification.Show("Guardando subscripcion...");

                var acctionResult = await subscriptionsService.SaveChanges(subscriptionWorkingModel);

                LoadNotification.Hide();

                if (!acctionResult.Result)
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPackage.Select();
                }
                else
                {
                    MessageBox.Show("Susbscripcion guardada correctamente... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            PackagesCache.GetInstance().Detach(this);
            SubscriptionsCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<PackagesModel> resource)
        {
            packagesList = resource;

            txtPackage.AutoCompleteCustomSource.Clear();

            foreach (PackagesModel package in packagesList)
            {
                txtPackage.AutoCompleteCustomSource.Add(package.Name);
            }
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

        public void Update(IEnumerable<SubscriptionsModel> resource)
        {
            subscriptionsList = resource;

            LoadDgvSubcriptionsClientList();
        }
    }
}
