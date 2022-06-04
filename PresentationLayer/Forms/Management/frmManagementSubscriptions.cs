using BusinessLayer.Cache;
using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using Presentation.Forms.Lists;
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
    public partial class frmManagementSubscriptions : Form, ISubscriber<PackagesModel>, ISubscriber<ClientsModel>
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

        private IEnumerable<SubscriptionsModel> subscriptionsList;

        private IEnumerable<ClientsModel> clientsList;
        private IEnumerable<PackagesModel> packagesList;

        private frmManagementSubscriptions()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            subscriptionWorkingModel = new SubscriptionsModel();
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
            txtObservations.Clear();

            dtpStartDate.MaxDate = DateTime.Now;
            dtpStartDate.Value = dtpStartDate.MaxDate;
        }

        private void SetControlsDefaultState()
        {
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

            dtpStartDate.Enabled = true;

            txtPackage.Select();
        }

        private void ClearSelectionDgv()
        {
            ClearData();

            dgvSubcriptionsClientList.CurrentCell = null;
            dgvSubcriptionsClientList.ClearSelection();
        }

        private void frmManagementSubscriptions_Load(object sender, EventArgs e)
        {

            ClientsCache.GetInstance().Attach(this);
            PackagesCache.GetInstance().Attach(this);
            
            SetControlsDefaultState();
        }

        private void txtNumberSessions_TextChanged(object sender, EventArgs e)
        {
            subscriptionWorkingModel.TotalSessions = (int)FormatUtilities.NumbersOnly(txtNumberSessions.Text);
        }

        private void txtAvailableDays_TextChanged(object sender, EventArgs e)
        {
            txtExpireDate.Text = dtpStartDate.Value.AddDays(FormatUtilities.NumbersOnly(txtAvailableDays.Text)).ToString("dd/MM/yyyy");
        }

        private void txtExpireDate_TextChanged(object sender, EventArgs e)
        {
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            subscriptionWorkingModel.Operation = Operation.Insert;

            ClearSelectionDgv();

            subscriptionWorkingModel.TicketCode = Tickets.Create("SUB", subscriptionWorkingModel.IdClients);

            txtTicketCode.Text = subscriptionWorkingModel.TicketCode.Value;

            SetControlsActiveState();
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Guardar subscripcion ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); ;

            if (confirm == DialogResult.OK)
            {
                LoadNotification.Show("Guardando subscripcion...");

                var acctionResult = await subscriptionWorkingModel.SaveChanges();

                LoadNotification.Hide();

                if (!acctionResult.Result)
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPackage.Select();
                }
                else
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetControlsClientEnterState();
                }
            }
        }
    }
}
