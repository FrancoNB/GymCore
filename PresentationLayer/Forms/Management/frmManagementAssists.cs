using BusinessLayer.Cache;
using BusinessLayer.Models;
using BusinessLayer.Services;
using BusinessLayer.Services.Assists;
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
    public partial class frmManagementAssists : Form, ISubscriber<ClientsModel>, ISubscriber<SubscriptionsModel>, ISubscriber<AssistsModel>
    {
        private static frmManagementAssists instance;

        private static readonly object _lock = new object();
        public static frmManagementAssists GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmManagementAssists();
                }
            }

            return instance;
        }

        private readonly AssistsModel assistWorkingModel;
        private readonly Service<AssistsModel> assistService;

        private IEnumerable<AssistsModel> assistsList;
        private IEnumerable<SubscriptionsModel> subscriptionsList;
        private IEnumerable<ClientsModel> clientsList;

        private frmManagementAssists()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            assistWorkingModel = new AssistsModel();
            assistService = new Service<AssistsModel>();
        }

        private void ClearClientData()
        {
            dgvAssistsClientList.Rows.Clear();

            txtClientMail.Clear();
            txtClientObservations.Clear();
            txtClientPhone.Clear();
            txtClientResidence.Clear();
        }

        private void SetControlsDefaultState()
        {
            txtClient.Clear();

            dtpDate.Value = dtpDate.MaxDate;

            txtClient.Enabled = true;

            dtpDate.Enabled = false;

            btnDelete.Enabled = false;
            btnClose.Enabled = true;
            btnAdd.Enabled = false;

            txtClient.Select();
        }

        private void SetControlsClientEnterState()
        {
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;

            dtpDate.Enabled = true;

            txtClient.Enabled = true;
         
            dtpDate.Value = dtpDate.MaxDate;
        }

        private void SetControlsClientEmptyState()
        {
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;

            dtpDate.Enabled = false;

            txtClient.Enabled = true;
        }

        private void ClearSelectionDgv()
        {
            dtpDate.Value = dtpDate.MaxDate;

            dgvAssistsClientList.CurrentCell = null;
            dgvAssistsClientList.ClearSelection();
        }

        private void LoadDgvAssistsClientList()
        {
            dgvAssistsClientList.Rows.Clear();

            if (assistWorkingModel.IdClients > 0)
            {
                var assistsClientsList = assistsList.ToList().FindAll(assist => assist.IdClients == assistWorkingModel.IdClients);

                assistsClientsList.Sort((x, y) => DateTime.Compare(y.Date, x.Date));

                foreach (AssistsModel assist in assistsClientsList)
                {
                    var subscriptionInfo = subscriptionsList.ToList().Find(subscription => subscription.IdSubscriptions == assist.IdSubscriptions);

                    int count = 0;
                    foreach (DataGridViewRow row in dgvAssistsClientList.Rows)
                    {
                        if (row.Cells["Package"].Value.ToString() == subscriptionInfo.Package + " [" + subscriptionInfo.IdSubscriptions + "]")
                            count++;
                    }

                    dgvAssistsClientList.Rows.Add(assist.IdAssists, assist.DateString, subscriptionInfo.Package + " [" + subscriptionInfo.IdSubscriptions + "]", subscriptionInfo.TotalSessions, subscriptionInfo.UsedSessions - count, subscriptionInfo.AvailableSessions + count);
                }
            }

            ClearSelectionDgv();
        }

        private void frmManagementAssists_Load(object sender, EventArgs e)
        {
            dtpDate.MaxDate = DateTime.Now;

            dgvAssistsClientList.Columns.Clear();
            dgvAssistsClientList.Columns.Add("idAssist", "ID ASISTENCIA");
            dgvAssistsClientList.Columns.Add("Date", "FECHA");
            dgvAssistsClientList.Columns.Add("Package", "PAQUETE");
            dgvAssistsClientList.Columns.Add("TotalSessions", "CLASES DISPONIBLES");
            dgvAssistsClientList.Columns.Add("UsedSessions", "CLASES USADAS");
            dgvAssistsClientList.Columns.Add("AvailableSessions", "CLASES RESTANTES");

            dgvAssistsClientList.Columns["idAssist"].Visible = false;

            dgvAssistsClientList.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvAssistsClientList.Columns["TotalSessions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvAssistsClientList.Columns["UsedSessions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvAssistsClientList.Columns["AvailableSessions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvAssistsClientList.Columns["Date"].Width = 100;
            dgvAssistsClientList.Columns["TotalSessions"].Width = 140;
            dgvAssistsClientList.Columns["UsedSessions"].Width = 140;
            dgvAssistsClientList.Columns["AvailableSessions"].Width = 140;

            dgvAssistsClientList.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAssistsClientList.Columns["TotalSessions"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAssistsClientList.Columns["UsedSessions"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAssistsClientList.Columns["AvailableSessions"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            ClientsCache.GetInstance().Attach(this);
            AssistsCache.GetInstance().Attach(this);
            SubscriptionsCache.GetInstance().Attach(this);

            SetControlsDefaultState();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            assistWorkingModel.Date = dtpDate.Value;
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

                assistWorkingModel.IdClients = selectedClient.IdClients;

                LoadDgvAssistsClientList();

                SetControlsClientEnterState();
            }
            else
            {
                assistWorkingModel.IdClients = 0;

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

        private void dgvAssistsClientList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectedAssist = assistsList.ToList().Find(assist => assist.IdAssists == Convert.ToInt32(dgvAssistsClientList.CurrentRow.Cells["idAssist"].Value));

                assistWorkingModel.IdSubscriptions = selectedAssist.IdSubscriptions;
                assistWorkingModel.IdAssists = selectedAssist.IdAssists;

                btnDelete.Select();
            }
            else
            {
                ClearSelectionDgv();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAssistsClientList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Eliminar asistencia ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); ;

                if (confirm == DialogResult.OK)
                {
                    assistService.SetStrategy(new AssistsDeleteService());

                    LoadNotification.Show("Eliminando asistencia...");

                    var acctionResult = await assistService.SaveChanges(assistWorkingModel);

                    LoadNotification.Hide();

                    if (!acctionResult.Result)
                    {
                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Asistencia eliminada correctamente... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtClient.Select();
                        txtClient.SelectionStart = 0;
                        txtClient.SelectionLength = txtClient.TextLength;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar la asistencia que deseas eliminar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Guardar asistencia ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); ;

            if (confirm == DialogResult.OK)
            {
                assistService.SetStrategy(new AssistsAddService());

                LoadNotification.Show("Guardando asistencia...");

                var acctionResult = await assistService.SaveChanges(assistWorkingModel);

                LoadNotification.Hide();

                if (!acctionResult.Result)
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Asistencia guardada correctamente... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtClient.Select();
                    txtClient.SelectionStart = 0;
                    txtClient.SelectionLength = txtClient.TextLength;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClientsCache.GetInstance().Detach(this);
            AssistsCache.GetInstance().Detach(this);
            SubscriptionsCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<SubscriptionsModel> resource)
        {
            subscriptionsList = resource;

            LoadDgvAssistsClientList();
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

        public void Update(IEnumerable<AssistsModel> resource)
        {
            assistsList = resource;

            LoadDgvAssistsClientList();
        }
    }
}
