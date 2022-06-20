using BusinessLayer.Cache;
using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
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

namespace PresentationLayer.Forms.Register
{
    public partial class frmRegisterClients : Form, ISubscriber<ClientsModel>
    {
        private static frmRegisterClients instance;

        private static readonly object _lock = new object();
        public static frmRegisterClients GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmRegisterClients();
                }
            }

            return instance;
        }

        private readonly ClientsModel clientWorkingModel;
        private IEnumerable<ClientsModel> clientsList;

        public frmRegisterClients()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            clientWorkingModel = new ClientsModel();
        }

        private void ClearData()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtLocality.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtMail.Clear();
            txtObservations.Clear();
        }

        private void SetControlsDefaultState()
        {
            ClearData();

            ControlsUtilities.DisableContainerControls(pnlData);
            ControlsUtilities.EnabledContainerControls(pnlList);

            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            btnNew.Select();
        }

        private void LoadDgvClientsList()
        {
            IEnumerable<ClientsModel> clientsList = this.clientsList;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                clientsList = clientsList.ToList().FindAll(client => client.Name.ToLower().Contains(txtSearch.Text.ToLower()) || client.Surname.ToLower().Contains(txtSearch.Text.ToLower()));

            dgvClientsList.Rows.Clear();

            foreach (ClientsModel client in clientsList)
            {
                dgvClientsList.Rows.Add(client.IdClients, client.RegisterDateString, client.Name + " " + client.Surname);
            }

            ClearSelectionDgv();
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
            ControlsUtilities.EnabledContainerControls(pnlData);

            txtSearch.Clear();

            txtName.Select();
        }

        private void ClearSelectionDgv()
        {
            ClearData();

            dgvClientsList.CurrentCell = null;
            dgvClientsList.ClearSelection();
        }

        private void frmRegisterClients_Load(object sender, EventArgs e)
        {
            dgvClientsList.Columns.Clear();
            dgvClientsList.Columns.Add("idClient", "ID CLIENTE");
            dgvClientsList.Columns.Add("RegisterDate", "FEC. ALTA");
            dgvClientsList.Columns.Add("CompleteName", "NOMBRE Y APELLIDO");

            dgvClientsList.Columns["idClient"].Visible = false;

            dgvClientsList.Columns["RegisterDate"].Width = 80;

            ClientsCache.GetInstance().Attach(this);

            SetControlsDefaultState();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            clientWorkingModel.Name = txtName.Text;
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            clientWorkingModel.Surname = txtSurname.Text;
        }

        private void txtLocality_TextChanged(object sender, EventArgs e)
        {
            clientWorkingModel.Locality = txtLocality.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            clientWorkingModel.Address = txtAddress.Text;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            clientWorkingModel.Phone = txtPhone.Text;
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            clientWorkingModel.Mail = txtMail.Text;
        }

        private void txtObservations_TextChanged(object sender, EventArgs e)
        {
            clientWorkingModel.Observations = txtObservations.Text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDgvClientsList();
        }

        private void dgvClientsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectClient = clientsList.ToList().Find(client => client.IdClients == Convert.ToInt32(dgvClientsList.CurrentRow.Cells["idClient"].Value));

                clientWorkingModel.IdClients = selectClient.IdClients;
                clientWorkingModel.RegisterDate = selectClient.RegisterDate;

                txtName.Text = selectClient.Name;
                txtSurname.Text = selectClient.Surname;
                txtLocality.Text = selectClient.Locality;
                txtAddress.Text = selectClient.Address;
                txtPhone.Text = selectClient.Phone;
                txtMail.Text = selectClient.Mail;
                txtObservations.Text = selectClient.Observations;

                btnUpdate.Select();
            }
            else
            {
                ClearSelectionDgv();
            }
        }

        private void dgvClientsList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvClientsList.HitTest(e.X, e.Y).Equals(DataGridView.HitTestInfo.Nowhere))
                {
                    ClearSelectionDgv();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clientWorkingModel.Operation = Operation.Insert;

            ClearSelectionDgv();

            SetControlsActiveState();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvClientsList.CurrentCell != null)
            {
                clientWorkingModel.Operation = Operation.Update;

                SetControlsActiveState();
            }
            else
            {
                MessageBox.Show("Debes seleccionar el cliente que deseas modificar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClientsList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Eliminar cliente ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (confirm == DialogResult.OK)
                {
                    LoadNotification.Show("Eliminando cliente...");

                    clientWorkingModel.Operation = Operation.Delete;

                    var acctionResult = await clientWorkingModel.SaveChanges();

                    LoadNotification.Hide();

                    if (acctionResult.Result)
                    {
                        txtSearch.Clear();

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
                MessageBox.Show("Debes seleccionar el cliente que deseas eliminar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string footMsg;
            DialogResult confirm;

            if (clientWorkingModel.Operation == Operation.Insert)
            {
                confirm = MessageBox.Show("Guardar cliente ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Guardando cliente...";
            }
            else if (clientWorkingModel.Operation == Operation.Update)
            {
                confirm = MessageBox.Show("Modificar cliente ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Modificando cliente...";
            }
            else
            {
                MessageBox.Show("No se establecio la operacion a realizar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (confirm == DialogResult.OK)
            {
                LoadNotification.Show(footMsg);

                var acctionResult = await clientWorkingModel.SaveChanges();

                LoadNotification.Hide();

                if (!acctionResult.Result)
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Select();
                }
                else
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetControlsDefaultState();
                }   
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControlsDefaultState();
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
    }
}
