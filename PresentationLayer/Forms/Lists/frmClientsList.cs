using BusinessLayer.Cache;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Lists
{
    public partial class frmClientsList : Form, ISubscriber<ClientsModel>
    {
        private static frmClientsList instance;

        private static readonly object _lock = new object();
        public static frmClientsList GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmClientsList();
                }
            }

            return instance;
        }

        private IEnumerable<ClientsModel> clientsList;
        private ClientsModel _SelectedClient;
        public ClientsModel SelectedClient { get => _SelectedClient; }

        private frmClientsList()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void ClearSelectionDgv()
        {
            dgvClientsList.CurrentCell = null;
            dgvClientsList.ClearSelection();
        }

        public void LoadDgvClientsList()
        {
            IEnumerable<ClientsModel> clientsList = this.clientsList;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                clientsList = clientsList.ToList().FindAll(package => package.Name.ToLower().Contains(txtSearch.Text.ToLower()));

            dgvClientsList.Rows.Clear();

            foreach (ClientsModel client in clientsList)
            {
                dgvClientsList.Rows.Add(client.IdClients, client.RegisterDateString, client.Name + " " + client.Surname,
                                        client.Locality, client.Address, client.Phone, client.Mail, client.Observations);
            }

            ClearSelectionDgv();
        }

        private void frmClientsList_Load(object sender, EventArgs e)
        {
            dgvClientsList.Columns.Clear();
            dgvClientsList.Columns.Add("idClient", "ID CLIENTE");
            dgvClientsList.Columns.Add("RegisterDate", "FEC. ALTA");
            dgvClientsList.Columns.Add("Name", "NOMBRE Y APELLIDO");
            dgvClientsList.Columns.Add("Locality", "LOCALIDAD");
            dgvClientsList.Columns.Add("Address", "DIRECCION");
            dgvClientsList.Columns.Add("Phone", "TELEFONO");
            dgvClientsList.Columns.Add("Mail", "MAIL");
            dgvClientsList.Columns.Add("Observations", "OBSERVACIONES");

            dgvClientsList.Columns["idClient"].Visible = false;

            dgvClientsList.Columns["RegisterDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvClientsList.Columns["RegisterDate"].Width = 80;
            dgvClientsList.Columns["Observations"].Width = 150;
            dgvClientsList.Columns["Name"].Width = 150;

            txtSearch.Clear();

            _SelectedClient = null;

            ClientsCache.GetInstance().Attach(this);

            txtSearch.Select();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDgvClientsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClientsCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<ClientsModel> resource)
        {
            clientsList = resource;

            LoadDgvClientsList();
        }

        private void dgvClientsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _SelectedClient = clientsList.ToList().Find(client => client.IdClients == Convert.ToInt32(dgvClientsList.CurrentRow.Cells["idClient"].Value));

                ClientsCache.GetInstance().Detach(this);

                this.Close();
            }
            else
            {
                ClearSelectionDgv();
            }
        }
    }
}
