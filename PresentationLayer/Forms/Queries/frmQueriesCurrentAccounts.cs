using BusinessLayer.Cache;
using BusinessLayer.Models;
using PresentationLayer.Forms.Lists;
using PresentationLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private DateTime filterStartDate;
        private DateTime filterEndDate;

        private int idClient;

        private frmQueriesCurrentAccounts()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void ClearClientData()
        {
            dgvCurrentAccountClientList.Rows.Clear();

            txtBalance.ForeColor = Color.FromArgb(139, 166, 145);
            txtBalance.BackColor = Color.FromArgb(12, 19, 46);

            txtStartDate.Enabled = false;
            txtEndDate.Enabled = false;
            btnFilter.Enabled = false;

            txtStartDate.Clear();
            txtEndDate.Clear();

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

                if(currentAccountClientList.Count > 0)
                {
                    if (currentAccountClientList.ToList().Last().Balance > 0)
                    {
                        txtBalance.ForeColor = Color.FromArgb(100, 255, 30);
                        txtBalance.BackColor = Color.FromArgb(33, 50, 16);
                    }
                    else if (currentAccountClientList.ToList().Last().Balance < 0)
                    {
                        txtBalance.ForeColor = Color.FromArgb(225, 20, 6);
                        txtBalance.BackColor = Color.FromArgb(57, 8, 1);
                    }
                    else
                    {
                        txtBalance.ForeColor = Color.FromArgb(139, 166, 145);
                        txtBalance.BackColor = Color.FromArgb(12, 19, 46);
                    }

                    txtBalance.Text = string.Format("$ {0:#,##0.00}", currentAccountClientList.ToList().Last().Balance);

                    if (filterStartDate != DateTime.MinValue)
                        currentAccountClientList = currentAccountClientList.ToList().FindAll(currentAccount => currentAccount.Date >= filterStartDate);

                    if (filterEndDate != DateTime.MinValue)
                        currentAccountClientList = currentAccountClientList.ToList().FindAll(currentAccount => currentAccount.Date <= filterEndDate);

                    foreach (CurrentAccountsModel currentAccount in currentAccountClientList)
                    {
                        dgvCurrentAccountClientList.Rows.Add(currentAccount.IdClients, currentAccount.TicketCode.Value, currentAccount.DateString,
                                                             string.Format("$ {0:#,##0.00}", currentAccount.Credit), string.Format("$ {0:#,##0.00}", currentAccount.Debit),
                                                             string.Format("$ {0:#,##0.00}", currentAccount.Balance), currentAccount.Detail);
                    }
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

            txtClient.Clear();
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

                txtStartDate.Enabled = true;
                txtEndDate.Enabled = true;
                btnFilter.Enabled = true;

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

        private void txtStartDate_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStartDate.Text))
                return;

            if (!FormatUtilities.IsDate(txtStartDate.Text))
                return;

            txtStartDate.Text = Convert.ToDateTime(txtStartDate.Text).ToString("dd/MM/yyyy");
        }

        private void txtEndDate_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEndDate.Text))
                return;

            if (!FormatUtilities.IsDate(txtEndDate.Text))
                return;  
            
            txtEndDate.Text = Convert.ToDateTime(txtEndDate.Text).ToString("dd/MM/yyyy");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtStartDate.Text))
            {
                if (FormatUtilities.IsDate(txtStartDate.Text))
                    filterStartDate = Convert.ToDateTime(txtStartDate.Text);
                else
                {
                    MessageBox.Show("El formato de la fecha desde no es correcto... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    txtStartDate.Select();
                    txtStartDate.SelectionStart = 0;
                    txtStartDate.SelectionLength = txtStartDate.TextLength;
                   
                    return;
                }
            }
            else
                filterStartDate = DateTime.MinValue;

            if (!string.IsNullOrWhiteSpace(txtEndDate.Text))
            {
                if (FormatUtilities.IsDate(txtEndDate.Text))
                    filterEndDate = Convert.ToDateTime(txtEndDate.Text);
                else
                {
                    MessageBox.Show("El formato de la fecha hasta no es correcto... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    txtEndDate.Select();
                    txtEndDate.SelectionStart = 0;
                    txtEndDate.SelectionLength = txtStartDate.TextLength;
                    
                    return;
                }
            }
            else
                filterEndDate = DateTime.MinValue;

            LoadDgvCurrentAccountClientList();
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
