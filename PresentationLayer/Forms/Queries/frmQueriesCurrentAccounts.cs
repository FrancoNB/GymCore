using BusinessLayer.Cache;
using BusinessLayer.Models;
using PresentationLayer.Forms.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Queries
{
    public partial class frmQueriesCurrentAccounts : Form, ISubscriber<CurrentAccountsModel>, ISubscriber<ClientsModel>
    {
        private static frmQueriesCurrentAccounts instance;

        private static readonly object _lock = new object();
        public static frmQueriesCurrentAccounts GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmQueriesCurrentAccounts();
                }
            }

            return instance;
        }

        private IEnumerable<ClientsModel> clientsList;
        private IEnumerable<CurrentAccountsModel> currentAccountsList;

        private int idClient;

        private frmQueriesCurrentAccounts()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void ClearClientData()
        {
            dgvCurrentAccountClientList.Rows.Clear();

            txtClientMail.Clear();
            txtClientObservations.Clear();
            txtClientPhone.Clear();
            txtClientResidence.Clear();
            txtBalance.Clear();
        }

        private void ClearSelectionDgv()
        {
            dgvCurrentAccountClientList.CurrentCell = null;
            dgvCurrentAccountClientList.ClearSelection();
        }

        private void LoadDgvCurrentAccountClientList()
        {
            dgvCurrentAccountClientList.Rows.Clear();

            if (idClient > 0)
            {
                var currentAccountClientList = currentAccountsList.ToList().FindAll(currentAccount => currentAccount.IdClients == idClient);

                foreach (CurrentAccountsModel currentAccount in currentAccountClientList)
                {
                    dgvCurrentAccountClientList.Rows.Add(currentAccount.IdClients, currentAccount.TicketCode.Value, currentAccount.DateString,
                                                         string.Format("$ {0:#,##0.00}", currentAccount.Credit), string.Format("$ {0:#,##0.00}", currentAccount.Debit),
                                                         string.Format("$ {0:#,##0.00}", currentAccount.Balance), currentAccount.Detail);
                
                    if(currentAccount.Equals(currentAccountClientList.Last()))
                        txtBalance.Text = dgvCurrentAccountClientList.Rows[dgvCurrentAccountClientList.Rows.Count - 1].Cells["Balance"].Value.ToString();
                }
            }

            ClearSelectionDgv();
        }

        private void frmQueriesCurrentAccounts_Load(object sender, EventArgs e)
        {
            dgvCurrentAccountClientList.Columns.Clear();
            dgvCurrentAccountClientList.Columns.Add("idCurrentAccount", "ID CUENTA CORRIENTE");
            dgvCurrentAccountClientList.Columns.Add("TicketCode", "COD. DE OP.");
            dgvCurrentAccountClientList.Columns.Add("Date", "FECHA");
            dgvCurrentAccountClientList.Columns.Add("Credit", "CREDITO");
            dgvCurrentAccountClientList.Columns.Add("Debit", "DEBITO");
            dgvCurrentAccountClientList.Columns.Add("Balance", "BALANCE");
            dgvCurrentAccountClientList.Columns.Add("Detail", "DETALLE");

            dgvCurrentAccountClientList.Columns["idCurrentAccount"].Visible = false;

            dgvCurrentAccountClientList.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCurrentAccountClientList.Columns["TicketCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCurrentAccountClientList.Columns["Credit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCurrentAccountClientList.Columns["Debit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCurrentAccountClientList.Columns["Balance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvCurrentAccountClientList.Columns["Date"].Width = 80;
            dgvCurrentAccountClientList.Columns["TicketCode"].Width = 150;
            dgvCurrentAccountClientList.Columns["Credit"].Width = 120;
            dgvCurrentAccountClientList.Columns["Debit"].Width = 120;
            dgvCurrentAccountClientList.Columns["Balance"].Width = 120;

            dgvCurrentAccountClientList.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCurrentAccountClientList.Columns["TicketCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCurrentAccountClientList.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCurrentAccountClientList.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCurrentAccountClientList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ClientsCache.GetInstance().Attach(this);
            CurrentAccountsCache.GetInstance().Attach(this);

            ClearClientData();

            txtClient.Select();
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

                idClient = selectedClient.IdClients;

                LoadDgvCurrentAccountClientList();
            }
            else
            {
                idClient = 0;

                ClearClientData();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClientsCache.GetInstance().Detach(this);
            CurrentAccountsCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<CurrentAccountsModel> resource)
        {
            currentAccountsList = resource;

            LoadDgvCurrentAccountClientList();
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
    }
}
